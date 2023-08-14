using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;

namespace Demo
{
    internal class BeamAnalyzer
    {
        Bitmap image;
        PointF center;
        double majorAxisLength;
        double minorAxisLength;
        double rotationAngle;
        bool validEllipse;
        Point[] ptsContour;

        double[] arrayCrossSection;
        double fwhm_l;
        double fwhm_h;
        double fwhm_value;

        public BeamAnalyzer()
        {
            validEllipse = false;
            center = new PointF(0, 0);
            majorAxisLength = 0;
            minorAxisLength = 0;
            rotationAngle = 0;
        }

        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                AnalyzeImage();
                if (validEllipse)
                {
                    ResampleMajorAxis();
                }
            }
        }

        public double[] CrossSectionArray
        {
            get { return arrayCrossSection; }
        }
        public bool ValidEllipse { get { return validEllipse; } }
        public PointF Center { get { return center; } }
        public double MajorAxisLength { get { return majorAxisLength; } }
        public double MinorAxisLength { get { return minorAxisLength; } }
        public double RotationAngle { get { return rotationAngle; } }
        public Point[] Contour { get { return ptsContour; } }
        public double FWHM { get { return fwhm_h - fwhm_l; } }
        public PointF[] ptsFWHM {
            get 
            {
                PointF[] retValue = new PointF[2];
                retValue[0] = new PointF((float)fwhm_l, (float)fwhm_value);
                retValue[1] = new PointF((float)fwhm_h, (float)fwhm_value);
                return retValue; 
            } 
        }

        private void AnalyzeImage()
        {
            using (Mat matBeamImage = image.ToMat()) // Convert Bitmap to Mat
            {
                Mat matGrayBeamImage = new Mat();
                CvInvoke.CvtColor(matBeamImage, matGrayBeamImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray); // Convert Mat image into Grayscale

                // Find Contour
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(matGrayBeamImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

                // Find best contour for ellipse
                double maxArea = -1;
                RotatedRect selectedEllipse = new RotatedRect();
                int selectedIndex = -1;
                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    {
                        if (contour.Size >= 5) // Minimum number of points required for fitting an ellipse
                        {
                            RotatedRect ellipse = CvInvoke.FitEllipse(contour);

                            double area = ellipse.Size.Height * ellipse.Size.Width;
                            if (area > maxArea)
                            {
                                maxArea = area;
                                selectedEllipse = ellipse;
                                selectedIndex = i;
                            }
                        }
                    }
                }

                if (selectedIndex >= 0)
                {
                    validEllipse = true;
                    center = selectedEllipse.Center;
                    majorAxisLength = selectedEllipse.Size.Height;
                    minorAxisLength = selectedEllipse.Size.Width;
                    rotationAngle = selectedEllipse.Angle;
                    ptsContour = contours[selectedIndex].ToArray();
                }
                else
                {
                    validEllipse = false;
                }
            }
        }
        public override string ToString()
        {
            if (validEllipse)
            {
                string retValue = "Center: " + center + "\r\n"
                    + "Major Axis Length: " + majorAxisLength + "\r\n"
                    + "Minor Axis Length: " + minorAxisLength + "\r\n"
                    + "Rotation Angle: " + rotationAngle + "\r\n";

                return retValue;
            }
            else
            {
                return "No valid ellipse.";
            }
        }

        // Resample 1D array along the major axis of the ellipse.
        private void ResampleMajorAxis()
        {

            // Convert input image to openCV Mat object
            Image<Gray, byte> emguImage = image.ToImage<Gray, byte>();
            Mat matImage = emguImage.Mat;

            // Rotate the Mat from the centre to bring the major axis to X-axis.
            Mat rotationMatrix = new Mat();
            CvInvoke.GetRotationMatrix2D(center, rotationAngle+90, 1.0, rotationMatrix);
            Mat rotatedMat = new Mat();
            CvInvoke.WarpAffine(emguImage.Mat, rotatedMat, rotationMatrix, emguImage.Size);

            // Convert the rotated Mat back to Bitmap
            Bitmap rotatedImage = rotatedMat.ToBitmap();
            rotationMatrix.Dispose();
            rotatedMat.Dispose();

            // Calculate the length of the cross-section
            int crossSectionLength = (int)Math.Ceiling(majorAxisLength);
            if (crossSectionLength % 2 == 0)
                crossSectionLength += 1;

            // Create the cross-section values array
            double[] crossSectionValues = new double[image.Width];
            Color pxcolor;
            for (int i = 0; i < image.Width; i++)
            {
                pxcolor = rotatedImage.GetPixel(i, (int)(center.Y));
                crossSectionValues[i] = pxcolor.G;

            }

            arrayCrossSection = crossSectionValues;





            // Find FWHM
            double max = crossSectionValues.Max();
            double min = crossSectionValues.Min();
            double HM = min + (max - min) / 2.0;

            int index_h = -1;
            for (int i=(int)center.X; i<image.Width; i++)
            {
                if (crossSectionValues[i] < HM)
                {
                    index_h = i; break;
                }
            }
            if (index_h == -1) index_h = image.Width - 1;

            int index_l = -1;
            for (int i = (int)center.X; i >= 0; i--)
            {
                if (crossSectionValues[i] < HM)
                {
                    index_l = i; break;
                }
            }
            if (index_l == -1) index_h = 0;

            fwhm_l = index_l;
            fwhm_h = index_h;
            fwhm_value = HM;
        }
    }
}
