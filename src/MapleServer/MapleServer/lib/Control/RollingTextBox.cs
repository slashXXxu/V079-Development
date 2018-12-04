using MapleServer.lib;
using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Forms;

namespace MapleServer
{
    public partial class RollingTextBox : TextBox
    {
        public int MaxLines { get; set; } = 30;//默认是30行
        private ConcurrentQueue<string> _rollingLog;

        public RollingTextBox()
        {
            InitializeComponent();
            _rollingLog = new ConcurrentQueue<string>();
            if (Lines.Length > MaxLines)
            {
                Lines.Skip(Lines.Length - MaxLines).ForEach(_rollingLog.Enqueue);
            } else
            {
                Lines.ForEach(_rollingLog.Enqueue);
            }
        }
        public void AddLine(string text)
        {
            string result = null;
            while (_rollingLog.Count >= MaxLines)
            {
                _rollingLog.TryDequeue(out result);
            }
            _rollingLog.Enqueue(text);
            ForceUpdate();
        }
        private void ForceUpdate()
        {
            try
            {
                if (InvokeRequired)
                {
                    var tmp = _rollingLog.ToArray();
                    Invoke((MethodInvoker)delegate { Lines = tmp; });
                }
                else
                    Lines = _rollingLog.ToArray();
            }
            catch { }
        }
        public new void Clear()
        {
            base.Clear();
            _rollingLog = new ConcurrentQueue<string>();
            ForceUpdate();
        }
    }
}
