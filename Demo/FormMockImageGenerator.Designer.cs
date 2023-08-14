namespace Demo
{
    partial class FormMockImageGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            label1 = new Label();
            pbPreview = new PictureBox();
            timerGenerator = new System.Windows.Forms.Timer(components);
            trackBarBeamRadius = new TrackBar();
            label2 = new Label();
            trackBarPower = new TrackBar();
            tbBeamRadius = new TextBox();
            tbPower = new TextBox();
            tbBeamRadiusY = new TextBox();
            trackBarBeamRadiusY = new TrackBar();
            label3 = new Label();
            tbBeamRotation = new TextBox();
            trackBarBeamRotation = new TrackBar();
            label4 = new Label();
            btnReCentre = new Button();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBeamRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBeamRadiusY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBeamRotation).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(293, 245);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 41);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 1;
            label1.Text = "Beam Radius X";
            // 
            // pbPreview
            // 
            pbPreview.BackColor = Color.Black;
            pbPreview.Location = new Point(12, 12);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(256, 256);
            pbPreview.TabIndex = 2;
            pbPreview.TabStop = false;
            // 
            // timerGenerator
            // 
            timerGenerator.Tick += timerGenerator_Tick;
            // 
            // trackBarBeamRadius
            // 
            trackBarBeamRadius.Location = new Point(384, 41);
            trackBarBeamRadius.Maximum = 100;
            trackBarBeamRadius.Minimum = 1;
            trackBarBeamRadius.Name = "trackBarBeamRadius";
            trackBarBeamRadius.Size = new Size(203, 45);
            trackBarBeamRadius.TabIndex = 3;
            trackBarBeamRadius.Value = 30;
            trackBarBeamRadius.ValueChanged += trackBarBeamRadius_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 188);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "Power";
            // 
            // trackBarPower
            // 
            trackBarPower.Location = new Point(384, 188);
            trackBarPower.Maximum = 1500;
            trackBarPower.Name = "trackBarPower";
            trackBarPower.Size = new Size(203, 45);
            trackBarPower.TabIndex = 5;
            trackBarPower.Value = 800;
            trackBarPower.ValueChanged += trackBarPower_ValueChanged;
            // 
            // tbBeamRadius
            // 
            tbBeamRadius.Location = new Point(604, 40);
            tbBeamRadius.Name = "tbBeamRadius";
            tbBeamRadius.ReadOnly = true;
            tbBeamRadius.Size = new Size(100, 23);
            tbBeamRadius.TabIndex = 6;
            // 
            // tbPower
            // 
            tbPower.Location = new Point(604, 188);
            tbPower.Name = "tbPower";
            tbPower.ReadOnly = true;
            tbPower.Size = new Size(100, 23);
            tbPower.TabIndex = 7;
            // 
            // tbBeamRadiusY
            // 
            tbBeamRadiusY.Location = new Point(604, 91);
            tbBeamRadiusY.Name = "tbBeamRadiusY";
            tbBeamRadiusY.ReadOnly = true;
            tbBeamRadiusY.Size = new Size(100, 23);
            tbBeamRadiusY.TabIndex = 10;
            // 
            // trackBarBeamRadiusY
            // 
            trackBarBeamRadiusY.Location = new Point(384, 92);
            trackBarBeamRadiusY.Maximum = 100;
            trackBarBeamRadiusY.Minimum = 1;
            trackBarBeamRadiusY.Name = "trackBarBeamRadiusY";
            trackBarBeamRadiusY.Size = new Size(203, 45);
            trackBarBeamRadiusY.TabIndex = 9;
            trackBarBeamRadiusY.Value = 30;
            trackBarBeamRadiusY.ValueChanged += trackBarBeamRadiusY_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(293, 92);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 8;
            label3.Text = "Beam Radius Y";
            // 
            // tbBeamRotation
            // 
            tbBeamRotation.Location = new Point(604, 136);
            tbBeamRotation.Name = "tbBeamRotation";
            tbBeamRotation.ReadOnly = true;
            tbBeamRotation.Size = new Size(100, 23);
            tbBeamRotation.TabIndex = 13;
            // 
            // trackBarBeamRotation
            // 
            trackBarBeamRotation.Location = new Point(384, 137);
            trackBarBeamRotation.Maximum = 90;
            trackBarBeamRotation.Minimum = -90;
            trackBarBeamRotation.Name = "trackBarBeamRotation";
            trackBarBeamRotation.Size = new Size(203, 45);
            trackBarBeamRotation.TabIndex = 12;
            trackBarBeamRotation.ValueChanged += trackBarBeamRotation_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(293, 137);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 11;
            label4.Text = "Beam Rotation";
            // 
            // btnReCentre
            // 
            btnReCentre.Location = new Point(384, 245);
            btnReCentre.Name = "btnReCentre";
            btnReCentre.Size = new Size(75, 23);
            btnReCentre.TabIndex = 14;
            btnReCentre.Text = "Re-Centre";
            btnReCentre.UseVisualStyleBackColor = true;
            btnReCentre.Click += btnReCentre_Click;
            // 
            // FormMockImageGenerator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 302);
            Controls.Add(btnReCentre);
            Controls.Add(tbBeamRotation);
            Controls.Add(trackBarBeamRotation);
            Controls.Add(label4);
            Controls.Add(tbBeamRadiusY);
            Controls.Add(trackBarBeamRadiusY);
            Controls.Add(label3);
            Controls.Add(tbPower);
            Controls.Add(tbBeamRadius);
            Controls.Add(trackBarPower);
            Controls.Add(label2);
            Controls.Add(trackBarBeamRadius);
            Controls.Add(pbPreview);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Name = "FormMockImageGenerator";
            Text = "FormMockImageGenerator";
            Load += FormMockImageGenerator_Load;
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBeamRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPower).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBeamRadiusY).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBeamRotation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label label1;
        private PictureBox pbPreview;
        private System.Windows.Forms.Timer timerGenerator;
        private TrackBar trackBarBeamRadius;
        private Label label2;
        private TrackBar trackBarPower;
        private TextBox tbBeamRadius;
        private TextBox tbPower;
        private TextBox tbBeamRadiusY;
        private TrackBar trackBarBeamRadiusY;
        private Label label3;
        private TextBox tbBeamRotation;
        private TrackBar trackBarBeamRotation;
        private Label label4;
        private Button btnReCentre;
    }
}