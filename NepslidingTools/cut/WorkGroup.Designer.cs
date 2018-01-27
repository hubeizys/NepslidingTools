namespace NepslidingTools.cut
{
    partial class WorkGroup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.main_tpl = new System.Windows.Forms.TableLayoutPanel();
            this.main_flp = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.main_tpl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_tpl
            // 
            this.main_tpl.ColumnCount = 1;
            this.main_tpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main_tpl.Controls.Add(this.main_flp, 0, 1);
            this.main_tpl.Controls.Add(this.panel1, 0, 0);
            this.main_tpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tpl.Location = new System.Drawing.Point(0, 0);
            this.main_tpl.Name = "main_tpl";
            this.main_tpl.RowCount = 2;
            this.main_tpl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.main_tpl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main_tpl.Size = new System.Drawing.Size(539, 365);
            this.main_tpl.TabIndex = 0;
            // 
            // main_flp
            // 
            this.main_flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_flp.Location = new System.Drawing.Point(3, 43);
            this.main_flp.Name = "main_flp";
            this.main_flp.Size = new System.Drawing.Size(533, 319);
            this.main_flp.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 34);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "XX组";
            // 
            // WorkGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.main_tpl);
            this.Name = "WorkGroup";
            this.Size = new System.Drawing.Size(539, 365);
            this.main_tpl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tpl;
        private System.Windows.Forms.FlowLayoutPanel main_flp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
