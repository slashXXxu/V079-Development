using log4net;
using MapleServer.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleServer
{
    public partial class frmMain : Form
    {
        //private static ILog _onlinePlayerLog = LogManager.GetLogger("OnlinePlayers");
        public static frmMain Instance { get; private set; }

        public struct OnlinePlayerCount
        {
            public string serverName { get; set; }
            public int count { get; set; }
        }
        private int _totalConnections;

        public frmMain()
        {
            Instance = this;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var tr = new Thread(InitializeServer);
            tr.IsBackground = true;
            tr.Start();
        }
        private void InitializeServer()
        {
            try
            {

            } catch(Exception ex)
            {

            }
        }
    }
}
