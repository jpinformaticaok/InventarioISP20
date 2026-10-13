namespace Desktop.Views
{
    partial class SplashView
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pbSplash = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 109);
            label1.Name = "label1";
            label1.Size = new Size(414, 59);
            label1.TabIndex = 0;
            label1.Text = "Inventario ISP20";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pngwing_com;
            pictureBox1.Location = new Point(321, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(478, 331);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pbSplash
            // 
            pbSplash.Location = new Point(12, 369);
            pbSplash.Name = "pbSplash";
            pbSplash.Size = new Size(488, 52);
            pbSplash.Step = 20;
            pbSplash.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // SplashView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(pbSplash);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SplashView";
            Text = "SplashView";
            Activated += SplashView_Activated;
            Load += SplashView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private ProgressBar pbSplash;
        private System.Windows.Forms.Timer timer1;
    }
}