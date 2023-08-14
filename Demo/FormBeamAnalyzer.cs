using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Demo
{
    public partial class FormBeamAnalyzer : Form
    {
        FormMockImageGenerator formMockImageGenerator;
        BeamAnalyzer beamAnalyzer;
        double[] crossSection;

        public FormBeamAnalyzer()
        {
            InitializeComponent();

            crossSection = new double[256];
            for (int i = 0; i < crossSection.Length; i++)
            {
                crossSection[i] = Math.Sin(i / 256.0 * 4 * Math.PI) + 1;
            }

        }

        private void FormBeamAnalyzer_Load(object sender, EventArgs e)
        {
            formMockImageGenerator = new FormMockImageGenerator();
            formMockImageGenerator.Show();

            formMockImageGenerator.BeamImageDelivered += cbBeamImageDelivered;

            beamAnalyzer = new BeamAnalyzer();
        }

        // Event Handler: When the generator makes mock image, this function is called to analyze the image.
        private void cbBeamImageDelivered(object sender, BeamImageEventArgs e)
        {
            // Retrieve image
            Bitmap beamImage = e.BeamImage;

            // Analyze image: Fit ellipse 
            beamAnalyzer.Image = beamImage;
            tbAnalysis.Text = beamAnalyzer.ToString();

            // Overlay axes on the image
            Bitmap beamImageOverlayed = beamImage;
            if (beamAnalyzer.ValidEllipse)
            {
                // Convert 8bpp indexed image into 24bpp rgb image. To use graphics object, rgb format is required.
                beamImageOverlayed = ConvertToRgbBitmap(beamImage);

                using (Graphics graphics = Graphics.FromImage(beamImageOverlayed))
                {
                    PointF center = beamAnalyzer.Center;
                    double majorAxisLength = beamAnalyzer.MajorAxisLength;
                    double minorAxisLength = beamAnalyzer.MinorAxisLength;
                    double rotationAngle = beamAnalyzer.RotationAngle;
                    Point[] ptsContour = beamAnalyzer.Contour;

                    // Draw Contour
                    Pen polygonPen = new Pen(Color.Red, 2);
                    graphics.DrawPolygon(polygonPen, ptsContour);
                    Pen axisPen = new Pen(Color.Green, 2);
                    Pen axisPen2 = new Pen(Color.Blue, 2);
                    Point[] pointsAxis = new Point[4];

                    // Draw Axes
                    Point[] ptMajorAxis =
                        { new Point ((int)(center.X - majorAxisLength / 2 * Math.Sin(rotationAngle / 180 * Math.PI)), (int)(center.Y + majorAxisLength / 2 * Math.Cos(rotationAngle / 180 * Math.PI)) ),
                        new Point ((int)(center.X + majorAxisLength / 2 * Math.Sin(rotationAngle / 180 * Math.PI)), (int)(center.Y - majorAxisLength / 2 * Math.Cos(rotationAngle / 180 * Math.PI)) ) };
                    Point[] ptMinorAxis =
                        { new Point ((int)(center.X + minorAxisLength / 2 * Math.Cos(rotationAngle / 180 * Math.PI)), (int)(center.Y + minorAxisLength / 2 * Math.Sin(rotationAngle / 180 * Math.PI)) ),
                        new Point ((int)(center.X - minorAxisLength / 2 * Math.Cos(rotationAngle / 180 * Math.PI)), (int)(center.Y - minorAxisLength / 2 * Math.Sin(rotationAngle / 180 * Math.PI)) ) };
                    graphics.DrawLines(axisPen, ptMajorAxis);
                    graphics.DrawLines(axisPen2, ptMinorAxis);
                }

                tbAnalysis.Text += "Max: " + beamAnalyzer.CrossSectionArray.Max() + "\r\n"
                    + "Min: " + beamAnalyzer.CrossSectionArray.Min() + "\r\n"
                    + "Len: " + beamAnalyzer.CrossSectionArray.Length + "\r\n";
            }

            // Show this image on the form
            pbImageView.Image = beamImageOverlayed;

            if (beamAnalyzer.ValidEllipse)
            {
                crossSection = beamAnalyzer.CrossSectionArray;
                ShowCrossSection();

                tbAnalysis.Text += "FWHM: " + beamAnalyzer.FWHM + "\r\n";
            }
        }

        static Bitmap ConvertToRgbBitmap(Bitmap indexedBitmap)
        {
            Image<Bgr, byte> emguBgrImage = indexedBitmap.ToImage<Bgr, byte>();
            Bitmap rgbBitmap = emguBgrImage.ToBitmap();

            return rgbBitmap;
        }

        // Show Cross Section along the major axis and Full width half maximum.
        private void ShowCrossSection()
        {
            Size sizePb = pbCrossSection.Size;
            double max = crossSection.Max();
            double min = crossSection.Min();
            Point[] points = new Point[crossSection.Length];

            for (int i = 0; i < crossSection.Length; i++)
            {
                points[i] = new Point(i * sizePb.Width / crossSection.Length, (int)((max - crossSection[i]) * sizePb.Height / (max - min)));
            }

            PointF[] FWHM = beamAnalyzer.ptsFWHM;
            Point[] pointsFWHM = new Point[4];
            for (int i=0; i<2; i++)
            {
                pointsFWHM[i] = new Point((int)(FWHM[i].X * sizePb.Width / crossSection.Length), (int)((max - FWHM[i].Y) * sizePb.Height / (max - min)));
            }
            pointsFWHM[2] = new Point(pointsFWHM[1].X, sizePb.Height - 1);
            pointsFWHM[3] = new Point(pointsFWHM[0].X, sizePb.Height - 1);

            Bitmap imageCrossSection = new Bitmap(sizePb.Width, sizePb.Height);
            using (Graphics graphics = Graphics.FromImage(imageCrossSection))
            {
                Pen graphPen = new Pen(Color.Black, 2);
                graphics.DrawLines(graphPen, points);

                Brush fwhmBrush = new SolidBrush(Color.Gray);
                graphics.FillPolygon(fwhmBrush, pointsFWHM);
            }
            pbCrossSection.Image = imageCrossSection;

        }
    }
}