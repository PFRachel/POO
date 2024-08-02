namespace SocketChatApp  // Programa para la interfaz
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxMessage;
        private TextBox textBoxPort;
        private Button buttonSend;
        private TextBox textBoxReceived;

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
            textBoxMessage = new TextBox();
            textBoxPort = new TextBox();
            buttonSend = new Button();
            textBoxReceived = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(24, 225);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(292, 273);
            textBoxMessage.TabIndex = 0;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(155, 156);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 1;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(155, 514);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 2;
            buttonSend.Text = "Enviar";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxReceived
            // 
            textBoxReceived.BackColor = SystemColors.Window;
            textBoxReceived.Location = new Point(416, 133);
            textBoxReceived.Multiline = true;
            textBoxReceived.Name = "textBoxReceived";
            textBoxReceived.ReadOnly = true;
            textBoxReceived.Size = new Size(274, 462);
            textBoxReceived.TabIndex = 3;
            textBoxReceived.TextChanged += textBoxReceived_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(416, 92);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 5;
            label1.Text = "Mensajes Entrantes";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = SystemColors.InactiveCaptionText;
            label2.Location = new Point(24, 9);
            label2.Name = "label2";
            label2.Size = new Size(52, 28);
            label2.TabIndex = 6;
            label2.Text = "Chat";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(24, 92);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 7;
            label3.Text = "Redactar Mensaje:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(24, 154);
            label4.Name = "label4";
            label4.Size = new Size(116, 21);
            label4.TabIndex = 8;
            label4.Text = "Puerto Destino:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 623);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxReceived);
            Controls.Add(buttonSend);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxMessage);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "Socket Chat App";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
