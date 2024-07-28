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
            this.txtPuertoDestino = new System.Windows.Forms.TextBox();
            this.lbPuertoDestino = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(360, 350);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(25, 350);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(320, 20);
            this.txtMensaje.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(25, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(410, 225);
            this.listBox1.TabIndex = 2;
            // 
            // txtPuertoDestino
            // 
            this.txtPuertoDestino.Location = new System.Drawing.Point(80, 310);
            this.txtPuertoDestino.Name = "txtPuertoDestino";
            this.txtPuertoDestino.Size = new System.Drawing.Size(150, 20);
            this.txtPuertoDestino.TabIndex = 4;
            // 
            // lbPuertoDestino
            // 
            this.lbPuertoDestino.AutoSize = true;
            this.lbPuertoDestino.Location = new System.Drawing.Point(25, 313);
            this.lbPuertoDestino.Name = "lbPuertoDestino";
            this.lbPuertoDestino.Size = new System.Drawing.Size(49, 13);
            this.lbPuertoDestino.TabIndex = 5;
            this.lbPuertoDestino.Text = "Destino:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.lbPuertoDestino);
            this.Controls.Add(this.txtPuertoDestino);
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
        private System.Windows.Forms.TextBox txtPuertoDestino;
        private System.Windows.Forms.Label lbPuertoDestino;
    }
}
