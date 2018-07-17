namespace NepslidingTools.toolbox
{
    partial class SavaAllFrom
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.save_sql_bt = new DevComponents.DotNetBar.ButtonX();
            this.backup_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backup_tim = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.remake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.backup_name,
            this.backup_tim,
            this.remake});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(13, 113);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(433, 271);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.save_sql_bt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 94);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(169, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "还原选中行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // save_sql_bt
            // 
            this.save_sql_bt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.save_sql_bt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.save_sql_bt.Location = new System.Drawing.Point(25, 39);
            this.save_sql_bt.Name = "save_sql_bt";
            this.save_sql_bt.Size = new System.Drawing.Size(125, 23);
            this.save_sql_bt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.save_sql_bt.TabIndex = 0;
            this.save_sql_bt.Text = "数据备份";
            this.save_sql_bt.Click += new System.EventHandler(this.save_sql_bt_Click);
            // 
            // backup_name
            // 
            this.backup_name.HeaderText = "备份文件";
            this.backup_name.Name = "backup_name";
            this.backup_name.ReadOnly = true;
            // 
            // backup_tim
            // 
            // 
            // 
            // 
            this.backup_tim.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.backup_tim.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.backup_tim.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.backup_tim.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.backup_tim.CustomFormat = "yyyy/MM/dd hh:mm";
            this.backup_tim.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.backup_tim.HeaderText = "备份时间";
            this.backup_tim.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            // 
            // 
            // 
            this.backup_tim.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.backup_tim.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.backup_tim.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.backup_tim.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.backup_tim.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.backup_tim.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.backup_tim.Name = "backup_tim";
            this.backup_tim.ReadOnly = true;
            this.backup_tim.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // remake
            // 
            this.remake.HeaderText = "注释";
            this.remake.Name = "remake";
            this.remake.ReadOnly = true;
            // 
            // SavaAllFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 397);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SavaAllFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据备份";
            this.Load += new System.EventHandler(this.SavaAllFrom_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX save_sql_bt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn backup_name;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn backup_tim;
        private System.Windows.Forms.DataGridViewTextBoxColumn remake;
    }
}