namespace Desktop.Views
{
    partial class ProbandoOpenrouter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProbandoOpenrouter));
            comboBoxModelos = new ComboBox();
            btnEnviar = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            txtPregunta = new TextBox();
            label2 = new Label();
            label3 = new Label();
            statusStrip1 = new StatusStrip();
            lblTokensPrompt = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            lblTokensRespuesta = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            tsRespuestaProgreso = new ToolStripProgressBar();
            lblModelo = new Label();
            lblTokens = new Label();
            txtRespuesta = new RichTextBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxModelos
            // 
            comboBoxModelos.Font = new Font("Segoe UI", 9.75F);
            comboBoxModelos.FormattingEnabled = true;
            comboBoxModelos.Location = new Point(12, 130);
            comboBoxModelos.Name = "comboBoxModelos";
            comboBoxModelos.Size = new Size(508, 25);
            comboBoxModelos.TabIndex = 2;
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = Color.FromArgb(0, 120, 215);
            btnEnviar.FlatStyle = FlatStyle.Flat;
            btnEnviar.Font = new Font("Segoe UI", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnEnviar.ForeColor = Color.FromArgb(32, 32, 32);
            btnEnviar.IconChar = FontAwesome.Sharp.IconChar.SquareArrowUpRight;
            btnEnviar.IconColor = Color.Black;
            btnEnviar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEnviar.IconSize = 30;
            btnEnviar.ImageAlign = ContentAlignment.TopCenter;
            btnEnviar.Location = new Point(395, 31);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(125, 52);
            btnEnviar.TabIndex = 1;
            btnEnviar.Text = "Enviar consulta";
            btnEnviar.TextAlign = ContentAlignment.BottomCenter;
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.ForeColor = Color.FromArgb(76, 76, 76);
            label1.Location = new Point(9, 103);
            label1.Name = "label1";
            label1.Size = new Size(138, 17);
            label1.TabIndex = 2;
            label1.Text = "Elegir Modelos Gratis:";
            // 
            // txtPregunta
            // 
            txtPregunta.Font = new Font("Segoe UI", 9.75F);
            txtPregunta.Location = new Point(12, 48);
            txtPregunta.Name = "txtPregunta";
            txtPregunta.PlaceholderText = "Se sugiere agregar la frase “en 3 líneas” para una respuesta corta";
            txtPregunta.Size = new Size(370, 25);
            txtPregunta.TabIndex = 0;
            txtPregunta.KeyDown += txtPregunta_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.ForeColor = Color.FromArgb(76, 76, 76);
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(165, 17);
            label2.TabIndex = 4;
            label2.Text = "Ingresar texto para el LLM:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.ForeColor = Color.FromArgb(76, 76, 76);
            label3.Location = new Point(12, 182);
            label3.Name = "label3";
            label3.Size = new Size(118, 17);
            label3.TabIndex = 6;
            label3.Text = "Respuesta del LLM";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(240, 240, 240);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTokensPrompt, toolStripStatusLabel2, lblTokensRespuesta, toolStripStatusLabel3, tsRespuestaProgreso });
            statusStrip1.Location = new Point(0, 656);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(532, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTokensPrompt
            // 
            lblTokensPrompt.ForeColor = Color.DimGray;
            lblTokensPrompt.Name = "lblTokensPrompt";
            lblTokensPrompt.Size = new Size(99, 17);
            lblTokensPrompt.Text = "Tokens prompt: 0";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.ForeColor = Color.DimGray;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(13, 17);
            toolStripStatusLabel2.Text = "||";
            // 
            // lblTokensRespuesta
            // 
            lblTokensRespuesta.ForeColor = Color.DimGray;
            lblTokensRespuesta.Name = "lblTokensRespuesta";
            lblTokensRespuesta.Size = new Size(112, 17);
            lblTokensRespuesta.Text = "Tokens Respuesta: 0";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.ForeColor = Color.DimGray;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(13, 17);
            toolStripStatusLabel3.Text = "||";
            // 
            // tsRespuestaProgreso
            // 
            tsRespuestaProgreso.MarqueeAnimationSpeed = 30;
            tsRespuestaProgreso.Name = "tsRespuestaProgreso";
            tsRespuestaProgreso.Size = new Size(240, 16);
            tsRespuestaProgreso.Style = ProgressBarStyle.Marquee;
            tsRespuestaProgreso.Visible = false;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModelo.ForeColor = Color.FromArgb(76, 76, 76);
            lblModelo.Location = new Point(12, 585);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(66, 21);
            lblModelo.TabIndex = 8;
            lblModelo.Text = "Modelo:";
            // 
            // lblTokens
            // 
            lblTokens.AutoSize = true;
            lblTokens.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTokens.ForeColor = Color.FromArgb(76, 76, 76);
            lblTokens.Location = new Point(12, 618);
            lblTokens.Name = "lblTokens";
            lblTokens.Size = new Size(60, 21);
            lblTokens.TabIndex = 9;
            lblTokens.Text = "Tokens:";
            // 
            // txtRespuesta
            // 
            txtRespuesta.BackColor = Color.White;
            txtRespuesta.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRespuesta.ForeColor = Color.FromArgb(20, 20, 20);
            txtRespuesta.Location = new Point(12, 212);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.ReadOnly = true;
            txtRespuesta.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtRespuesta.Size = new Size(508, 359);
            txtRespuesta.TabIndex = 3;
            txtRespuesta.Text = "";
            // 
            // ProbandoOpenrouter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(532, 678);
            Controls.Add(txtRespuesta);
            Controls.Add(lblTokens);
            Controls.Add(lblModelo);
            Controls.Add(statusStrip1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPregunta);
            Controls.Add(label1);
            Controls.Add(btnEnviar);
            Controls.Add(comboBoxModelos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ProbandoOpenrouter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Probando Openrouter";
            Load += ProbandoOpenrouter_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxModelos;
        private FontAwesome.Sharp.IconButton btnEnviar;
        private Label label1;
        private TextBox txtPregunta;
        private Label label2;
        private Label label3;
        private StatusStrip statusStrip1;
        private Label lblModelo;
        private Label lblTokens;
        private RichTextBox txtRespuesta;
        private ToolStripStatusLabel lblTokensPrompt;
        private ToolStripStatusLabel lblTokensRespuesta;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripProgressBar tsRespuestaProgreso;
    }
}