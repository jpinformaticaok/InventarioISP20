namespace Desktop.Views
{
    partial class ProbandoIA_Gemini
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
            txtConsulta = new TextBox();
            btnEnviar = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            txtRespuesta = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtConsulta
            // 
            txtConsulta.Location = new Point(34, 59);
            txtConsulta.Multiline = true;
            txtConsulta.Name = "txtConsulta";
            txtConsulta.Size = new Size(411, 23);
            txtConsulta.TabIndex = 0;
            // 
            // btnEnviar
            // 
            btnEnviar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEnviar.IconColor = Color.Black;
            btnEnviar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEnviar.Location = new Point(465, 59);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 1;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 29);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 2;
            label1.Text = "Ingrese su consulta";
            // 
            // txtRespuesta
            // 
            txtRespuesta.Location = new Point(34, 150);
            txtRespuesta.Multiline = true;
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(506, 238);
            txtRespuesta.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 122);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 4;
            label2.Text = "Respuesta de Gemini";
            // 
            // ProbandoIA_Gemini
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 415);
            Controls.Add(label2);
            Controls.Add(txtRespuesta);
            Controls.Add(label1);
            Controls.Add(btnEnviar);
            Controls.Add(txtConsulta);
            Name = "ProbandoIA_Gemini";
            Text = "ProbandoIA_Gemini";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtConsulta;
        private FontAwesome.Sharp.IconButton btnEnviar;
        private Label label1;
        private TextBox txtRespuesta;
        private Label label2;
    }
}