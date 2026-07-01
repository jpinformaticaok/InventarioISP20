namespace Desktop.Views
{
    partial class EquiposView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquiposView));
            label1 = new Label();
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            btnTiposEquipo = new Button();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnNuevo = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            txtBusqueda = new TextBox();
            label2 = new Label();
            dataGridEquipos = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            cbTipoEquipo = new ComboBox();
            txtNumeroSerie = new TextBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEquipos).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 30);
            label1.TabIndex = 1;
            label1.Text = "CRUD - Equipos";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(12, 59);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 379);
            tabControl.TabIndex = 2;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnTiposEquipo);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(txtBusqueda);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridEquipos);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(768, 351);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnTiposEquipo
            // 
            btnTiposEquipo.Location = new Point(638, 300);
            btnTiposEquipo.Name = "btnTiposEquipo";
            btnTiposEquipo.Size = new Size(124, 45);
            btnTiposEquipo.TabIndex = 8;
            btnTiposEquipo.Text = "CRUD Tipos de Equipo";
            btnTiposEquipo.UseVisualStyleBackColor = true;
            btnTiposEquipo.Click += btnTiposEquipo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 15;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(665, 176);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "  Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.IconSize = 15;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(665, 128);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "   Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.IconChar = FontAwesome.Sharp.IconChar.File;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNuevo.IconSize = 15;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(665, 72);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 15;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(665, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "   Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(54, 21);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(578, 23);
            txtBusqueda.TabIndex = 3;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            txtBusqueda.KeyPress += txtBusqueda_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 24);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Buscar";
            // 
            // dataGridEquipos
            // 
            dataGridEquipos.AllowUserToAddRows = false;
            dataGridEquipos.AllowUserToDeleteRows = false;
            dataGridEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEquipos.Location = new Point(6, 59);
            dataGridEquipos.Name = "dataGridEquipos";
            dataGridEquipos.ReadOnly = true;
            dataGridEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEquipos.Size = new Size(626, 286);
            dataGridEquipos.TabIndex = 1;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(cbTipoEquipo);
            tabPageAgregarEditar.Controls.Add(txtNumeroSerie);
            tabPageAgregarEditar.Controls.Add(txtModelo);
            tabPageAgregarEditar.Controls.Add(txtMarca);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Controls.Add(label4);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Location = new Point(4, 24);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(768, 351);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar / Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // cbTipoEquipo
            // 
            cbTipoEquipo.FormattingEnabled = true;
            cbTipoEquipo.Location = new Point(118, 287);
            cbTipoEquipo.Name = "cbTipoEquipo";
            cbTipoEquipo.Size = new Size(515, 23);
            cbTipoEquipo.TabIndex = 3;
            // 
            // txtNumeroSerie
            // 
            txtNumeroSerie.Location = new Point(120, 209);
            txtNumeroSerie.Name = "txtNumeroSerie";
            txtNumeroSerie.Size = new Size(513, 23);
            txtNumeroSerie.TabIndex = 2;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(120, 130);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(513, 23);
            txtModelo.TabIndex = 1;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(120, 42);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(513, 23);
            txtMarca.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 289);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 5;
            label6.Text = "Tipo de equipo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 212);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 4;
            label5.Text = "Numero de serie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 136);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 3;
            label4.Text = "Modelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 53);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 2;
            label3.Text = "Marca";
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(674, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "   Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(674, 87);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // EquiposView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EquiposView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Equipos";
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEquipos).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl;
        private TabPage tabPageLista;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private TextBox txtBusqueda;
        private Label label2;
        private DataGridView dataGridEquipos;
        private TabPage tabPageAgregarEditar;
        private TextBox txtNumeroSerie;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private ComboBox cbTipoEquipo;
        private Button btnTiposEquipo;
    }
}