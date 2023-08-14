using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Demo
{
    public partial class FormMockImageGenerator : Form
    {
        MockImageGenerator mockImageGenerator;

        public FormMockImageGenerator()
        {
            InitializeComponent();
            mockImageGenerator = new MockImageGenerator();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            mockImageGenerator.Start();
            timerGenerator.Start();

        }

        private void timerGenerator_Tick(object sender, EventArgs e)
        {
            // Generate new Beam Image
            Bitmap beamImage = mockImageGenerator.GetImage();
            pbPreview.Image = beamImage;

            // Raise Event
            BeamImageEventArgs args = new BeamImageEventArgs();
            args.BeamImage = beamImage;
            OnBeamImageDelivered(args);
        }

        protected virtual void OnBeamImageDelivered(BeamImageEventArgs e)
        {
            EventHandler<BeamImageEventArgs> handler = BeamImageDelivered;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<BeamImageEventArgs> BeamImageDelivered;




        private void trackBarBeamRadius_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarBeamRadius.Value;
            mockImageGenerator.BeamRadius = value;
            tbBeamRadius.Text = value.ToString();

        }
        private void trackBarBeamRadiusY_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarBeamRadiusY.Value;
            mockImageGenerator.BeamRadiusY = value;
            tbBeamRadiusY.Text = value.ToString();

        }

        private void trackBarBeamRotation_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarBeamRotation.Value;
            mockImageGenerator.BeamRotation = value;
            tbBeamRotation.Text = value.ToString();

        }


        private void trackBarPower_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarPower.Value;
            mockImageGenerator.Power = value;
            tbPower.Text = value.ToString();

        }

        private void FormMockImageGenerator_Load(object sender, EventArgs e)
        {
            int value = trackBarBeamRadius.Value;
            mockImageGenerator.BeamRadius = value;
            tbBeamRadius.Text = value.ToString();

            value = trackBarBeamRadiusY.Value;
            mockImageGenerator.BeamRadiusY = value;
            tbBeamRadiusY.Text = value.ToString();

            value = trackBarBeamRotation.Value;
            mockImageGenerator.BeamRotation = value;
            tbBeamRotation.Text = value.ToString();

            value = trackBarPower.Value;
            mockImageGenerator.Power = value;
            tbPower.Text = value.ToString();
        }

        private void btnReCentre_Click(object sender, EventArgs e)
        {
            mockImageGenerator.ReCentre();
        }
    }
}
