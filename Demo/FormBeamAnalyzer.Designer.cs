namespace Demo
{
    partial class FormBeamAnalyzer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbImageView = new PictureBox();
            tbAnalysis = new TextBox();
            pbCrossSection = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbImageView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCrossSection).BeginInit();
            SuspendLayout();
            // 
            // pbImageView
            // 
            pbImageView.BackColor = Color.Black;
            pbImageView.Location = new Point(12, 12);
            pbImageView.Name = "pbImageView";
            pbImageView.Size = new Size(256, 256);
            pbImageView.TabIndex = 3;
            pbImageView.TabStop = false;
            // 
            // tbAnalysis
            // 
            tbAnalysis.Location = new Point(308, 12);
            tbAnalysis.Multiline = true;
            tbAnalysis.Name = "tbAnalysis";
            tbAnalysis.Size = new Size(365, 200);
            tbAnalysis.TabIndex = 4;
            // 
            // pbCrossSection
            // 
            pbCrossSection.BackColor = Color.White;
            pbCrossSection.Location = new Point(12, 292);
            pbCrossSection.Name = "pbCrossSection";
            pbCrossSection.Size = new Size(256, 146);
            pbCrossSection.TabIndex = 5;
            pbCrossSection.TabStop = false;
            // 
            // FormBeamAnalyzer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbCrossSection);
            Controls.Add(tbAnalysis);
            Controls.Add(pbImageView);
            Name = "FormBeamAnalyzer";
            Text = "Beam Analyzer";
            Load += FormBeamAnalyzer_Load;
            ((System.ComponentModel.ISupportInitialize)pbImageView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCrossSection).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImageView;
        private TextBox tbAnalysis;
        private PictureBox pbCrossSection;
    }
}