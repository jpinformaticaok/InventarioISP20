namespace Desktop.Views
{
    partial class TiposEquiposView
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
            dgvTiposEquipos = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTiposEquipos).BeginInit();
            SuspendLayout();
            // 
            // dgvTiposEquipos
            // 
            dgvTiposEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiposEquipos.Location = new Point(23, 26);
            dgvTiposEquipos.Name = "dgvTiposEquipos";
            dgvTiposEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiposEquipos.Size = new Size(319, 269);
            dgvTiposEquipos.TabIndex = 0;
            dgvTiposEquipos.CellEndEdit += dgvTiposEquipos_CellEndEdit_1;
            dgvTiposEquipos.UserDeletingRow += dgvTiposEquipos_UserDeletingRow;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 8);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 1;
            label1.Text = "CRUD - Tipos de Equipos";
            // 
            // TiposEquiposView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 316);
            Controls.Add(label1);
            Controls.Add(dgvTiposEquipos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TiposEquiposView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tipos Equipos";
            ((System.ComponentModel.ISupportInitialize)dgvTiposEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTiposEquipos;
        private Label label1;
    }
}