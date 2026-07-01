namespace Desktop.Views
{
    partial class MenuPrincipalView
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
            menuStrip1 = new MenuStrip();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            SubMenuArticulos = new FontAwesome.Sharp.IconMenuItem();
            SubMenuCategorias = new FontAwesome.Sharp.IconMenuItem();
            SubMenuPrestamos = new FontAwesome.Sharp.IconMenuItem();
            SubMenuUbicaciones = new FontAwesome.Sharp.IconMenuItem();
            subMenuClientes = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            SubMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            subMenuEquipos = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { SubMenuArticulos, SubMenuCategorias, SubMenuPrestamos, SubMenuUbicaciones, subMenuClientes, subMenuEquipos });
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.House;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(81, 20);
            iconMenuItem1.Text = "Principal";
            // 
            // SubMenuArticulos
            // 
            SubMenuArticulos.IconChar = FontAwesome.Sharp.IconChar.Bars;
            SubMenuArticulos.IconColor = Color.Black;
            SubMenuArticulos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuArticulos.Name = "SubMenuArticulos";
            SubMenuArticulos.Size = new Size(180, 22);
            SubMenuArticulos.Text = "Articulos";
            SubMenuArticulos.Click += SubMenuArticulos_Click;
            // 
            // SubMenuCategorias
            // 
            SubMenuCategorias.IconChar = FontAwesome.Sharp.IconChar.Neuter;
            SubMenuCategorias.IconColor = Color.Black;
            SubMenuCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuCategorias.Name = "SubMenuCategorias";
            SubMenuCategorias.Size = new Size(180, 22);
            SubMenuCategorias.Text = "Categorias";
            SubMenuCategorias.Click += SubMenuCategorias_Click;
            // 
            // SubMenuPrestamos
            // 
            SubMenuPrestamos.IconChar = FontAwesome.Sharp.IconChar.None;
            SubMenuPrestamos.IconColor = Color.Black;
            SubMenuPrestamos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuPrestamos.Name = "SubMenuPrestamos";
            SubMenuPrestamos.Size = new Size(180, 22);
            SubMenuPrestamos.Text = "Prestamos";
            SubMenuPrestamos.Click += SubMenuPrestamos_Click;
            // 
            // SubMenuUbicaciones
            // 
            SubMenuUbicaciones.IconChar = FontAwesome.Sharp.IconChar.Location;
            SubMenuUbicaciones.IconColor = Color.Black;
            SubMenuUbicaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuUbicaciones.Name = "SubMenuUbicaciones";
            SubMenuUbicaciones.Size = new Size(180, 22);
            SubMenuUbicaciones.Text = "Ubicaciones";
            SubMenuUbicaciones.Click += SubMenuUbicaciones_Click;
            // 
            // subMenuClientes
            // 
            subMenuClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            subMenuClientes.IconColor = Color.Black;
            subMenuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuClientes.Name = "subMenuClientes";
            subMenuClientes.Size = new Size(180, 22);
            subMenuClientes.Text = "Clientes";
            subMenuClientes.Click += subMenuClientes_Click;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { SubMenuSalirDelSistema });
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(57, 20);
            iconMenuItem2.Text = "Salir";
            // 
            // SubMenuSalirDelSistema
            // 
            SubMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            SubMenuSalirDelSistema.IconColor = Color.Black;
            SubMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuSalirDelSistema.Name = "SubMenuSalirDelSistema";
            SubMenuSalirDelSistema.Size = new Size(167, 22);
            SubMenuSalirDelSistema.Text = "Salir del sistema...";
            SubMenuSalirDelSistema.Click += SubMenuSalirDelSistema_Click;
            // 
            // subMenuEquipos
            // 
            subMenuEquipos.IconChar = FontAwesome.Sharp.IconChar.Computer;
            subMenuEquipos.IconColor = Color.Black;
            subMenuEquipos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuEquipos.Name = "subMenuEquipos";
            subMenuEquipos.Size = new Size(180, 22);
            subMenuEquipos.Text = "Equipos";
            subMenuEquipos.Click += subMenuEquipos_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            Text = "Sistema de Inventario ISP20 - 2do año TSDS";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem SubMenuArticulos;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalirDelSistema;
        private FontAwesome.Sharp.IconMenuItem SubMenuCategorias;
        private FontAwesome.Sharp.IconMenuItem SubMenuPrestamos;
        private FontAwesome.Sharp.IconMenuItem SubMenuUbicaciones;
        private FontAwesome.Sharp.IconMenuItem subMenuClientes;
        private FontAwesome.Sharp.IconMenuItem subMenuEquipos;
    }
}
