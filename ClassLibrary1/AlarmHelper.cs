namespace PubModel
{
    public class AlarmHelper
    {
        private static AlarmHelper instance;

        public static AlarmHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlarmHelper();
                }

                return instance;
            }
        }

        // 定义委托
        public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

        //事件的声明
        public event AlarmEventHandler AlarmEvent = delegate { };

        // 事件的触发
        public void SendEvent(AlarmEventArgs e)
        {
            if (AlarmEvent != null)
                AlarmEvent.Invoke(this, e);
        }

        public class AlarmEventArgs : EventArgs
        {
            /// <summary>
            /// 消息事件的名称
            /// </summary>
            public string AlermName { set; get; }

            /// <summary>
            /// 消息事件的内容
            /// </summary>
            public string AlermMsg { set; get; }

            /// <summary>
            /// 消息事件的等级
            /// 0：错误事件
            /// </summary>
            public int AlermLevel { set; get; }

            public AlarmEventArgs(string name, string msg, int level)
            {
                this.AlermName = name;
                this.AlermMsg = msg;
                this.AlermLevel = level;
            }
        }
    }
}