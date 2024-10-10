using PubModel;

namespace JobLibary
{
    public class Job_Test
    {
        private CommonHelper commonHelper = new();
        private readonly string jobName = "JobTest";

        private void Do_Job()
        {
            commonHelper.SendEvent(jobName, "Test", 1);
            commonHelper.SendEvent(jobName, "Test", 2);
            commonHelper.SendEvent(jobName, "Test", 3);
            commonHelper.SendEvent(jobName, "Test", 4);
        }
    }
}