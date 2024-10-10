namespace WinFormsApp1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnClickThis = new Button();
            txtLog = new RichTextBox();
            logListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnClearLog = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            splitContainer = new SplitContainer();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // btnClickThis
            // 
            btnClickThis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClickThis.Location = new Point(700, 0);
            btnClickThis.Name = "btnClickThis";
            btnClickThis.Size = new Size(100, 30);
            btnClickThis.TabIndex = 0;
            btnClickThis.Text = "执行操作";
            btnClickThis.Click += button1_Click;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.Cyan;
            txtLog.Dock = DockStyle.Fill;
            txtLog.Location = new Point(0, 0);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(800, 234);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // logListView
            // 
            logListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            logListView.Dock = DockStyle.Fill;
            logListView.FullRowSelect = true;
            logListView.Location = new Point(0, 0);
            logListView.Name = "logListView";
            logListView.Size = new Size(800, 240);
            logListView.TabIndex = 0;
            logListView.UseCompatibleStateImageBehavior = false;
            logListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "时间";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "等级";
            columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "位置";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "内容";
            columnHeader4.Width = 400;
            // 
            // btnClearLog
            // 
            btnClearLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearLog.Location = new Point(700, 204);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(100, 30);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "清空日志";
            btnClearLog.Click += btnClearLog_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 478);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 3;
            statusStrip.ItemClicked += statusStrip_ItemClicked;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(32, 17);
            toolStripStatusLabel.Text = "就绪";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(btnClickThis);
            splitContainer.Panel1.Controls.Add(logListView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(btnClearLog);
            splitContainer.Panel2.Controls.Add(txtLog);
            splitContainer.Size = new Size(800, 478);
            splitContainer.SplitterDistance = 240;
            splitContainer.TabIndex = 2;
            // 
            // Form1
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(splitContainer);
            Controls.Add(statusStrip);
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "日志管理器";
            Load += Form1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClickThis;
        private RichTextBox txtLog;
        private ListView logListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button btnClearLog;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private SplitContainer splitContainer;
    }
}
