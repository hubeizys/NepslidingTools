namespace NepslidingTools.toolbox
{
    partial class AddComponent
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
            this.lab_name = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_gongdan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bianhao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_cc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_sm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_picname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ofd_sm = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(71, 63);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(41, 12);
            this.lab_name.TabIndex = 0;
            this.lab_name.Text = "零件名";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(141, 60);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_gongdan
            // 
            this.textBox_gongdan.Location = new System.Drawing.Point(248, 19);
            this.textBox_gongdan.Name = "textBox_gongdan";
            this.textBox_gongdan.Size = new System.Drawing.Size(100, 21);
            this.textBox_gongdan.TabIndex = 4;
            this.textBox_gongdan.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "工单号";
            this.label2.Visible = false;
            // 
            // textBox_bianhao
            // 
            this.textBox_bianhao.Location = new System.Drawing.Point(141, 104);
            this.textBox_bianhao.Name = "textBox_bianhao";
            this.textBox_bianhao.Size = new System.Drawing.Size(100, 21);
            this.textBox_bianhao.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "生成编号";
            // 
            // textBox_cc
            // 
            this.textBox_cc.Location = new System.Drawing.Point(141, 147);
            this.textBox_cc.Name = "textBox_cc";
            this.textBox_cc.Size = new System.Drawing.Size(100, 21);
            this.textBox_cc.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "尺寸";
            // 
            // textBox_sm
            // 
            this.textBox_sm.Location = new System.Drawing.Point(141, 192);
            this.textBox_sm.Name = "textBox_sm";
            this.textBox_sm.Size = new System.Drawing.Size(100, 21);
            this.textBox_sm.TabIndex = 10;
            this.textBox_sm.Click += new System.EventHandler(this.textBox_sm_Click);
            this.textBox_sm.TextChanged += new System.EventHandler(this.textBox_sm_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "数模";
            // 
            // textBox_picname
            // 
            this.textBox_picname.Location = new System.Drawing.Point(141, 236);
            this.textBox_picname.Name = "textBox_picname";
            this.textBox_picname.Size = new System.Drawing.Size(100, 21);
            this.textBox_picname.TabIndex = 12;
            this.textBox_picname.Visible = false;
            this.textBox_picname.Click += new System.EventHandler(this.textBox_picname_Click);
            this.textBox_picname.TextChanged += new System.EventHandler(this.textBox_picname_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "图片名称";
            this.label6.Visible = false;
            // 
            // ofd_sm
            // 
            this.ofd_sm.FileName = "file";
            this.ofd_sm.InitialDirectory = "shumo";
            // 
            // AddComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 375);
            this.Controls.Add(this.textBox_picname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_sm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_cc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_bianhao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_gongdan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.lab_name);
            this.Name = "AddComponent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddComponent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddComponent_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_gongdan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_bianhao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_cc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_sm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_picname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog ofd_sm;
    }
}