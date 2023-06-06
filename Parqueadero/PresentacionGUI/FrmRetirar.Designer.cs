namespace PresentacionGUI
{
    partial class RetirarVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetirarVehiculo));
            this.btAtras2 = new System.Windows.Forms.Button();
            this.ListaRegistro = new System.Windows.Forms.DataGridView();
            this.textBuscar = new System.Windows.Forms.TextBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.textPlaca = new System.Windows.Forms.TextBox();
            this.btRetirar = new System.Windows.Forms.Button();
            this.lbPago = new System.Windows.Forms.Label();
            this.lbDatos = new System.Windows.Forms.Label();
            this.cbHora = new System.Windows.Forms.ComboBox();
            this.lbHora = new System.Windows.Forms.Label();
            this.lbNombre1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbBuscarNombre = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListaRegistro)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btAtras2
            // 
            this.btAtras2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAtras2.Location = new System.Drawing.Point(12, 479);
            this.btAtras2.Name = "btAtras2";
            this.btAtras2.Size = new System.Drawing.Size(65, 27);
            this.btAtras2.TabIndex = 0;
            this.btAtras2.Text = "Atras";
            this.btAtras2.UseVisualStyleBackColor = true;
            this.btAtras2.Click += new System.EventHandler(this.btAtras2_Click);
            // 
            // ListaRegistro
            // 
            this.ListaRegistro.AllowUserToAddRows = false;
            this.ListaRegistro.AllowUserToDeleteRows = false;
            this.ListaRegistro.AllowUserToOrderColumns = true;
            this.ListaRegistro.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListaRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaRegistro.Location = new System.Drawing.Point(5, 23);
            this.ListaRegistro.Name = "ListaRegistro";
            this.ListaRegistro.ReadOnly = true;
            this.ListaRegistro.Size = new System.Drawing.Size(682, 439);
            this.ListaRegistro.TabIndex = 1;
            this.ListaRegistro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaRegistro_CellContentClick);
            // 
            // textBuscar
            // 
            this.textBuscar.Location = new System.Drawing.Point(723, 54);
            this.textBuscar.Multiline = true;
            this.textBuscar.Name = "textBuscar";
            this.textBuscar.Size = new System.Drawing.Size(148, 21);
            this.textBuscar.TabIndex = 3;
            this.textBuscar.TextChanged += new System.EventHandler(this.textBuscar_TextChanged);
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbDatos.Controls.Add(this.txtTotalPagar);
            this.gbDatos.Controls.Add(this.textPlaca);
            this.gbDatos.Controls.Add(this.btRetirar);
            this.gbDatos.Controls.Add(this.lbPago);
            this.gbDatos.Controls.Add(this.lbDatos);
            this.gbDatos.Controls.Add(this.cbHora);
            this.gbDatos.Controls.Add(this.lbHora);
            this.gbDatos.Controls.Add(this.lbNombre1);
            this.gbDatos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.Location = new System.Drawing.Point(693, 137);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(208, 208);
            this.gbDatos.TabIndex = 4;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.Location = new System.Drawing.Point(115, 104);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(88, 26);
            this.txtTotalPagar.TabIndex = 8;
            // 
            // textPlaca
            // 
            this.textPlaca.Enabled = false;
            this.textPlaca.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPlaca.Location = new System.Drawing.Point(78, 23);
            this.textPlaca.Name = "textPlaca";
            this.textPlaca.Size = new System.Drawing.Size(124, 26);
            this.textPlaca.TabIndex = 7;
            // 
            // btRetirar
            // 
            this.btRetirar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetirar.Location = new System.Drawing.Point(78, 160);
            this.btRetirar.Name = "btRetirar";
            this.btRetirar.Size = new System.Drawing.Size(124, 25);
            this.btRetirar.TabIndex = 6;
            this.btRetirar.Text = "Retirar";
            this.btRetirar.UseVisualStyleBackColor = true;
            this.btRetirar.Click += new System.EventHandler(this.btRetirar_Click);
            // 
            // lbPago
            // 
            this.lbPago.AutoSize = true;
            this.lbPago.Location = new System.Drawing.Point(14, 110);
            this.lbPago.Name = "lbPago";
            this.lbPago.Size = new System.Drawing.Size(94, 15);
            this.lbPago.TabIndex = 4;
            this.lbPago.Text = "TOTAL PAGAR  ";
            // 
            // lbDatos
            // 
            this.lbDatos.AutoSize = true;
            this.lbDatos.Location = new System.Drawing.Point(122, 29);
            this.lbDatos.Name = "lbDatos";
            this.lbDatos.Size = new System.Drawing.Size(0, 15);
            this.lbDatos.TabIndex = 3;
            // 
            // cbHora
            // 
            this.cbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHora.FormattingEnabled = true;
            this.cbHora.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cbHora.Location = new System.Drawing.Point(141, 68);
            this.cbHora.Name = "cbHora";
            this.cbHora.Size = new System.Drawing.Size(61, 23);
            this.cbHora.TabIndex = 2;
            this.cbHora.SelectedIndexChanged += new System.EventHandler(this.cbHora_SelectedIndexChanged);
            // 
            // lbHora
            // 
            this.lbHora.AutoSize = true;
            this.lbHora.Location = new System.Drawing.Point(14, 72);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(53, 15);
            this.lbHora.TabIndex = 1;
            this.lbHora.Text = "HORAS ";
            // 
            // lbNombre1
            // 
            this.lbNombre1.AutoSize = true;
            this.lbNombre1.Location = new System.Drawing.Point(14, 29);
            this.lbNombre1.Name = "lbNombre1";
            this.lbNombre1.Size = new System.Drawing.Size(46, 15);
            this.lbNombre1.TabIndex = 0;
            this.lbNombre1.Text = "PLACA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(693, 351);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lbBuscarNombre
            // 
            this.lbBuscarNombre.AutoSize = true;
            this.lbBuscarNombre.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBuscarNombre.Location = new System.Drawing.Point(720, 34);
            this.lbBuscarNombre.Name = "lbBuscarNombre";
            this.lbBuscarNombre.Size = new System.Drawing.Size(76, 17);
            this.lbBuscarNombre.TabIndex = 6;
            this.lbBuscarNombre.Text = "BUSCAR:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(796, 81);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // RetirarVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(908, 518);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lbBuscarNombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.textBuscar);
            this.Controls.Add(this.ListaRegistro);
            this.Controls.Add(this.btAtras2);
            this.Name = "RetirarVehiculo";
            this.Text = "RETIRAR VEHICULO";
            this.Load += new System.EventHandler(this.RetirarVehiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaRegistro)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAtras2;
        private System.Windows.Forms.DataGridView ListaRegistro;
        private System.Windows.Forms.TextBox textBuscar;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lbNombre1;
        private System.Windows.Forms.Label lbDatos;
        private System.Windows.Forms.ComboBox cbHora;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Label lbPago;
        private System.Windows.Forms.Button btRetirar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbBuscarNombre;
        private System.Windows.Forms.TextBox textPlaca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtTotalPagar;
    }
}