namespace QLKSSML
{
    partial class FRepass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tentk = new System.Windows.Forms.TextBox();
            this.mkcu = new System.Windows.Forms.TextBox();
            this.mkm = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.xnmkcu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(165, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đổi Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tài khoản ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu cũ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu mới ";
            // 
            // tentk
            // 
            this.tentk.Location = new System.Drawing.Point(202, 121);
            this.tentk.Name = "tentk";
            this.tentk.Size = new System.Drawing.Size(357, 26);
            this.tentk.TabIndex = 4;
            // 
            // mkcu
            // 
            this.mkcu.Location = new System.Drawing.Point(202, 176);
            this.mkcu.Name = "mkcu";
            this.mkcu.Size = new System.Drawing.Size(357, 26);
            this.mkcu.TabIndex = 5;
            // 
            // mkm
            // 
            this.mkm.Location = new System.Drawing.Point(201, 234);
            this.mkm.Name = "mkm";
            this.mkm.Size = new System.Drawing.Size(357, 26);
            this.mkm.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 62);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đổi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 62);
            this.button2.TabIndex = 8;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // xnmkcu
            // 
            this.xnmkcu.Location = new System.Drawing.Point(210, 292);
            this.xnmkcu.Name = "xnmkcu";
            this.xnmkcu.Size = new System.Drawing.Size(357, 26);
            this.xnmkcu.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Xác nhận mật khẩu mới";
            // 
            // FRepass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 468);
            this.Controls.Add(this.xnmkcu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mkm);
            this.Controls.Add(this.mkcu);
            this.Controls.Add(this.tentk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FRepass";
            this.Text = "FRepass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tentk;
        private System.Windows.Forms.TextBox mkcu;
        private System.Windows.Forms.TextBox mkm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox xnmkcu;
        private System.Windows.Forms.Label label5;
    }
}