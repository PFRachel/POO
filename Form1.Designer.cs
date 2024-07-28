namespace Cliente
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbTitulo1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lbPuerto = new System.Windows.Forms.Label();
            this.txtPuertoDestino = new System.Windows.Forms.TextBox();
            this.lbPuertoDestino = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(277, 250);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(25, 250);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(222, 20);
            this.txtMensaje.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(25, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(327, 208);
            this.listBox1.TabIndex = 2;
            // 
            // lbTitulo1
            // 
            this.lbTitulo1.AutoSize = true;
            this.lbTitulo1.Location = new System.Drawing.Point(22, 280);
            this.lbTitulo1.Name = "lbTitulo1";
            this.lbTitulo1.Size = new System.Drawing.Size(43, 13);
            this.lbTitulo1.TabIndex = 3;
            this.lbTitulo1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(71, 277);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(177, 275);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 5;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(71, 303);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 20);
            this.txtPuerto.TabIndex = 6;
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(22, 306);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(38, 13);
            this.lbPuerto.TabIndex = 7;
            this.lbPuerto.Text = "Puerto";
            // 
            // txtPuertoDestino
            // 
            this.txtPuertoDestino.Location = new System.Drawing.Point(71, 329);
            this.txtPuertoDestino.Name = "txtPuertoDestino";
            this.txtPuertoDestino.Size = new System.Drawing.Size(100, 20);
            this.txtPuertoDestino.TabIndex = 8;
            // 
            // lbPuertoDestino
            // 
            this.lbPuertoDestino.AutoSize = true;
            this.lbPuertoDestino.Location = new System.Drawing.Point(22, 332);
            this.lbPuertoDestino.Name = "lbPuertoDestino";
            this.lbPuertoDestino.Size = new System.Drawing.Size(38, 13);
            this.lbPuertoDestino.TabIndex = 9;
            this.lbPuertoDestino.Text = "Destino";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lbPuertoDestino);
            this.Controls.Add(this.txtPuertoDestino);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lbTitulo1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnEnviar);
            this.Name = "Form1";
            this.Text = "Chat Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbTitulo1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label lbPuerto;
        private System.Windows.Forms.TextBox txtPuertoDestino;
        private System.Windows.Forms.Label lbPuertoDestino;
    }
}
