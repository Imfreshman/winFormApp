using PubModel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly CommonHelper commonHelper = new CommonHelper();

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 订阅事件
            AlarmHelper alarm = AlarmHelper.Instance;
            alarm.AlarmEvent += JobAlarmEvent;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 取消事件订阅
            AlarmHelper alarm = AlarmHelper.Instance;
            alarm.AlarmEvent -= JobAlarmEvent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnClickThis.Text == "Click this")
            {
                StartTask();
                btnClickThis.Text = "Stop";
            }
            else
            {
                btnClickThis.Text = "Click this";
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            // 判断是否存在日志
            if (txtLog.Text.Length == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("确定清空日志?", "提醒", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                txtLog.Clear();
            }
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
        }

        private void StartTask()
        {
            // 模拟任务执行
            Random random = new Random();
            int taskOutcome = random.Next(0, 5); // 随机生成 0-4 之间的数字

            if (taskOutcome == 0)
            {
                // 正常执行
                commonHelper.SendEvent("JobSuccess", "任务成功完成", 0);
            }
            else if (taskOutcome == 1)
            {
                // 调试信息
                commonHelper.SendEvent("JobDebug", "任务执行中...", 1);
            }
            else if (taskOutcome == 2)
            {
                // 警告
                commonHelper.SendEvent("JobWarning", "任务可能存在问题", 2);
            }
            else if (taskOutcome == 3)
            {
                // 错误
                commonHelper.SendEvent("JobError", "任务执行失败", 3);
            }
            else
            {
                // 致命错误
                commonHelper.SendEvent("JobFatal", "任务严重失败", 4);
            }
        }

        private List<string> allLogs = new List<string>(); // 用于存储所有日志

        private void JobAlarmEvent(object sender, AlarmHelper.AlarmEventArgs e)
        {
            string logMessage = $"{DateTime.Now} [{e.AlermName}] {CommonHelper.GetLogLevel(e.AlermLevel)} {e.AlermMsg}";

            txtLog.Invoke((MethodInvoker)delegate
            {
                // 先设置光标到文本的最后
                txtLog.SelectionStart = txtLog.TextLength;
                txtLog.SelectionLength = 0;
                txtLog.SelectionColor = CommonHelper.GetLogLevelColor(e.AlermLevel);
                txtLog.AppendText(logMessage + Environment.NewLine);
                txtLog.SelectionStart = txtLog.Text.Length; // 将光标移到最后
                txtLog.ScrollToCaret(); // 自动滚动到最底部
            });
        }

        // 过滤日志
        private void FilterLogs(string filter)
        {
            txtLog.Clear(); // 清空当前日志显示
            foreach (var log in allLogs)
            {
                if (log.Contains(filter)) // 简单的关键字过滤
                {
                    txtLog.AppendText(log + Environment.NewLine);
                }
            }
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}