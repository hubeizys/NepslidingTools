namespace NepslidingTools.testModel
{
    partial class QrDlg
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_cl = new System.Windows.Forms.Button();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_OK.Location = new System.Drawing.Point(315, 18);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_cl
            // 
            this.btn_cl.Location = new System.Drawing.Point(315, 50);
            this.btn_cl.Name = "btn_cl";
            this.btn_cl.Size = new System.Drawing.Size(75, 23);
            this.btn_cl.TabIndex = 1;
            this.btn_cl.Text = "取消";
            this.btn_cl.UseVisualStyleBackColor = true;
            this.btn_cl.Click += new System.EventHandler(this.btn_cl_Click);
            // 
            // tb_code
            // 
            this.tb_code.Location = new System.Drawing.Point(22, 50);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(274, 21);
            this.tb_code.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入或者扫描进编号 ";
            // 
            // QrDlg
            // 
            this.AcceptButton = this.btn_cl;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_OK;
            this.ClientSize = new System.Drawing.Size(423, 92);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.btn_cl);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "QrDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请输入编号";
            this.Load += new System.EventHandler(this.QrDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_cl;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Label label1;
    }
}