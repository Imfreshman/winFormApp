public interface ILogger
{
    void Log(string level, string location, string message);
}

public class LogService : ILogger
{
    private readonly ListView _logListView;

    public LogService(ListView logListView)
    {
        _logListView = logListView;
    }

    public void Log(string level, string location, string message)
    {
        var logItem = new ListViewItem(new string[]
        {
            DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            level,
            location,
            message
        });
        if (level == "ERROR")
            logItem.ForeColor = Color.Red;
        else
            logItem.ForeColor = Color.Black;
    }
}