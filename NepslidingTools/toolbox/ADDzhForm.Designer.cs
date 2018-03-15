namespace NepslidingTools.toolbox
{
    partial class ADDzhForm
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
            this.txt_n = new System.Windows.Forms.TextBox();
            this.txt_p = new System.Windows.Forms.TextBox();
            this.txt_q = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DTP = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "权限";
            // 
            // txt_n
            // 
            this.txt_n.Location = new System.Drawing.Point(102, 18);
            this.txt_n.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_n.Name = "txt_n";
            this.txt_n.Size = new System.Drawing.Size(88, 22);
            this.txt_n.TabIndex = 4;
            // 
            // txt_p
            // 
            this.txt_p.Location = new System.Drawing.Point(102, 59);
            this.txt_p.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_p.Name = "txt_p";
            this.txt_p.Size = new System.Drawing.Size(88, 22);
            this.txt_p.TabIndex = 5;
            // 
            // txt_q
            // 
            this.txt_q.Location = new System.Drawing.Point(102, 130);
            this.txt_q.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_q.Name = "txt_q";
            this.txt_q.Size = new System.Drawing.Size(88, 22);
            this.txt_q.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 171);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DTP
            // 
            this.DTP.Location = new System.Drawing.Point(102, 90);
            this.DTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTP.Name = "DTP";
            this.DTP.Size = new System.Drawing.Size(176, 22);
            this.DTP.TabIndex = 9;
            // 
            // ADDzhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 211);
            this.Controls.Add(this.DTP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_q);
            this.Controls.Add(this.txt_p);
            this.Controls.Add(this.txt_n);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ADDzhForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_n;
        private System.Windows.Forms.TextBox txt_p;
        private System.Windows.Forms.TextBox txt_q;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker DTP;
    }
}