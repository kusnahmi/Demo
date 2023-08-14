using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class MockImageGenerator
    {
        Size imageSize;
        Point ptCentre;
        double beamradius_X;
        double beamradius_Y;
        int rotationAngle;
        int power;
        System.Timers.Timer timer;
        Bitmap imageData;
        Random rnd;
        ColorPalette grayscalePalette;

        public MockImageGenerator()
        {
            rnd = new Random();

            // gaussian beam parameter
            imageSize = new Size(256, 256);
            ptCentre = new Point(128, 128);
            beamradius_X = 30;
            beamradius_Y = 20;
            rotationAngle = 30;
            power = 800;
            // image palette
            grayscalePalette = new Bitmap(1, 1, PixelFormat.Format8bppIndexed).Palette;
            // Create a grayscale palette
            for (int i = 0; i < 256; i++)
            {
                grayscalePalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            imageData = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format8bppIndexed);

            timer = new System.Timers.Timer(100);
            timer.Elapsed += OnTimedEvent;

            //timer.Start();

        }
       
        ~MockImageGenerator()
        {
            timer.Dispose();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public double BeamRadius
        {
            get { return beamradius_X; }
            set { beamradius_X = value; }
        }

        public double BeamRadiusY
        {
            get { return beamradius_Y; }
            set { beamradius_Y = value; }
        }
        public int BeamRotation
        {
            get { return rotationAngle; }
            set { rotationAngle = value; }
        }
        public int Power
        {
            get { return power; }
            set {  power = value; } 
        }

        public void ReCentre()
        {
            ptCentre = new Point(imageSize.Width/2, imageSize.Height/2);

        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            int movingRange = 10;

            Point ptNewCentre = ptCentre;

            int deltaX = (int)((rnd.NextDouble()-0.5) * movingRange);
            int deltaY = (int)((rnd.NextDouble()-0.5) * movingRange);

            ptNewCentre.Offset(deltaX, deltaY);

            if (ptNewCentre.X < 0) ptNewCentre.X = 0;
            else if (ptCentre.X >= imageSize.Width) ptNewCentre.X = imageSize.Width - 1;

            if (ptNewCentre.Y < 0) ptNewCentre.Y = 0;
            else if (ptCentre.Y >= imageSize.Height) ptNewCentre.Y = imageSize.Height - 1;

            ptCentre = ptNewCentre;
        }

        public Bitmap GetImage()
        {
            int width = imageSize.Width;
            int height = imageSize.Height;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            bitmap.Palette = grayscalePalette;

            double centreX = ptCentre.X;
            double centreY = ptCentre.Y;

            double rotationAngleRadian = rotationAngle * Math.PI / 180;
            unsafe
            {
                byte* pixelData = (byte*)bitmapData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Apply rotation transformation
                        double rotatedX = (x - centreX) * Math.Cos(rotationAngleRadian) - (y - centreY) * Math.Sin(rotationAngleRadian);
                        double rotatedY = (x - centreX) * Math.Sin(rotationAngleRadian) + (y - centreY) * Math.Cos(rotationAngleRadian);
                        double intensity = power / beamradius_X / beamradius_Y * Math.Exp(-(rotatedX * rotatedX / (2 * beamradius_X * beamradius_X) + rotatedY * rotatedY / (2 * beamradius_Y * beamradius_Y)));

                        if (intensity > 1.0) intensity = 1.0;

                        // Scale intensity to fit in the 0-255 range
                        byte pixelValue = (byte)(intensity * 255);

                        pixelData[x + y * width] = pixelValue;
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);
            imageData = bitmap;

            return imageData;
        }
    }
}
