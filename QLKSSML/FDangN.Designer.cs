namespace QLKSSML
{
    partial class FDangN
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
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.txttentk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(282, 294);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(158, 65);
            this.btnthoat.TabIndex = 11;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(88, 295);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(158, 65);
            this.btnlogin.TabIndex = 10;
            this.btnlogin.Text = "Đăng Nhập";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtmk
            // 
            this.txtmk.Location = new System.Drawing.Point(213, 183);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(100, 26);
            this.txtmk.TabIndex = 9;
            this.txtmk.UseSystemPasswordChar = true;
            // 
            // txttentk
            // 
            this.txttentk.Location = new System.Drawing.Point(213, 119);
            this.txttentk.Name = "txttentk";
            this.txttentk.Size = new System.Drawing.Size(100, 26);
            this.txttentk.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mật Khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên Tài Khoản";
            // 
            // FDangN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 418);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txttentk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FDangN";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FDangN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.TextBox txttentk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}