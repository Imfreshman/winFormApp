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
            // �����¼�
            AlarmHelper alarm = AlarmHelper.Instance;
            alarm.AlarmEvent += JobAlarmEvent;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ȡ���¼�����
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
            // �ж��Ƿ������־
            if (txtLog.Text.Length == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("ȷ�������־?", "����", MessageBoxButtons.YesNo);
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
            // ģ������ִ��
            Random random = new Random();
            int taskOutcome = random.Next(0, 5); // ������� 0-4 ֮�������

            if (taskOutcome == 0)
            {
                // ����ִ��
                commonHelper.SendEvent("JobSuccess", "����ɹ����", 0);
            }
            else if (taskOutcome == 1)
            {
                // ������Ϣ
                commonHelper.SendEvent("JobDebug", "����ִ����...", 1);
            }
            else if (taskOutcome == 2)
            {
                // ����
                commonHelper.SendEvent("JobWarning", "������ܴ�������", 2);
            }
            else if (taskOutcome == 3)
            {
                // ����
                commonHelper.SendEvent("JobError", "����ִ��ʧ��", 3);
            }
            else
            {
                // ��������
                commonHelper.SendEvent("JobFatal", "��������ʧ��", 4);
            }
        }

        private List<string> allLogs = new List<string>(); // ���ڴ洢������־

        private void JobAlarmEvent(object sender, AlarmHelper.AlarmEventArgs e)
        {
            string logMessage = $"{DateTime.Now} [{e.AlermName}] {CommonHelper.GetLogLevel(e.AlermLevel)} {e.AlermMsg}";

            txtLog.Invoke((MethodInvoker)delegate
            {
                // �����ù�굽�ı������
                txtLog.SelectionStart = txtLog.TextLength;
                txtLog.SelectionLength = 0;
                txtLog.SelectionColor = CommonHelper.GetLogLevelColor(e.AlermLevel);
                txtLog.AppendText(logMessage + Environment.NewLine);
                txtLog.SelectionStart = txtLog.Text.Length; // ������Ƶ����
                txtLog.ScrollToCaret(); // �Զ���������ײ�
            });
        }

        // ������־
        private void FilterLogs(string filter)
        {
            txtLog.Clear(); // ��յ�ǰ��־��ʾ
            foreach (var log in allLogs)
            {
                if (log.Contains(filter)) // �򵥵Ĺؼ��ֹ���
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