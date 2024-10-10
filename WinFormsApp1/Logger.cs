namespace WinFormsApp1
{
    public class Logger
    {
        private string _currentLogFilePath;
        private DateTime _currentLogDate;
        private readonly string _categoryName;
        private readonly string _logDirectory;
        private RichTextBox _txtLog; // 日志显示的文本框
        private Button _btnClearLog; // 清空日志按钮
        private const int MaxLogLines = 1000; // 最大行数

        public Logger(string categoryName, string logDirectory, RichTextBox txtLog, Button btnClearLog)
        {
            _categoryName = categoryName;
            _logDirectory = logDirectory;
            _txtLog = txtLog;
            _btnClearLog = btnClearLog;
        }

        // 获取日志级别标签
        public static string GetLogLevel(int level)
        {
            return level switch
            {
                0 => "[Information]",
                1 => "[Debug]",
                2 => "[Warning]",
                3 => "[Error]",
                4 => "[Fatal]",
                _ => "[Information]"
            };
        }

        // 根据日志级别设置颜色
        public static Color GetLogLevelColor(int level)
        {
            return level switch
            {
                0 => Color.Green,
                1 => Color.Gray,
                2 => Color.Orange,
                3 => Color.Red,
                4 => Color.DarkRed,
                _ => Color.Black
            };
        }

        // 记录日志并将其显示到 RichTextBox
        public void LogMessage(string message, int level)
        {
            string formattedMessage = $"{DateTime.Now}  {GetCategoryNamePart(_categoryName)}  {GetLogLevel(level)}  {message}";

            // 写入日志文件
            //WriteLogToFile(formattedMessage);

            if (_txtLog.InvokeRequired)
            {
                _txtLog.Invoke(new Action(() => { AppendLog(formattedMessage, level); }));
            }
            else
            {
                AppendLog(formattedMessage, level);
            }
        }

        // 限制日志行数并清除最早的日志
        private void AppendLog(string message, int level)
        {
            // 检查行数是否超过最大限制
            if (_txtLog.Lines.Length >= MaxLogLines)
            {
                _txtLog.Text = _txtLog.Text.Remove(0, _txtLog.Lines[0].Length + Environment.NewLine.Length); // 删除最早的一行
            }

            // 根据级别设置颜色
            _txtLog.SelectionStart = _txtLog.TextLength;
            _txtLog.SelectionLength = 0;
            _txtLog.SelectionColor = GetLogLevelColor(level); // 设置当前输入文本的颜色
            _txtLog.AppendText(message + Environment.NewLine); // 添加换行符

            // 滚动到最新行
            _txtLog.ScrollToCaret();

            // 更新“清空日志”按钮的显示状态
            UpdateClearLogButton();
        }

        // 根据日志是否存在更新清空按钮状态
        public void UpdateClearLogButton()
        {
            _btnClearLog.Visible = !string.IsNullOrWhiteSpace(_txtLog.Text);
        }

        // 写入日志到文件
        private void WriteLogToFile(string message)
        {
            try
            {
                var logFilePath = GetLogFilePath();
                if (new FileInfo(logFilePath).Length > 10 * 1024 * 1024) // 如果文件超过10MB，重命名
                {
                    string newFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                        $"{DateTime.Now:yyyyMMdd}.txt");
                    File.Move(logFilePath, newFileName);
                }

                File.AppendAllText(logFilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // 处理写入日志文件时的异常
                MessageBox.Show($"无法写入日志文件: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 获取分类名称的子部分
        private string GetCategoryNamePart(string categoryName)
        {
            var lastDotIndex = categoryName.LastIndexOf('.');
            if (lastDotIndex >= 0 && lastDotIndex < categoryName.Length - 1)
            {
                return categoryName.Substring(lastDotIndex + 1);
            }
            return categoryName; // 如果没有找到 '.' 或 '.' 是最后一个字符，则返回原始字符串
        }

        // 获取当前日期的日志文件路径
        private string GetLogFilePath()
        {
            var today = DateTime.Today;
            if (_currentLogFilePath == null || _currentLogDate != today)
            {
                var categoryPart = GetCategoryNamePart(_categoryName);
                var logDir = Path.Combine(_logDirectory, "Logs", categoryPart);
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                var fileName = $"{today:yyyyMMdd}.txt";
                _currentLogFilePath = Path.Combine(logDir, fileName);
                _currentLogDate = today;
            }

            return _currentLogFilePath;
        }
    }
}