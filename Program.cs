using System;
using WebSocketSharp;
using System.Windows.Forms;
using WebSocket = WebSocketSharp.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WINFORMS_teset;
using System.Drawing.Text;
using System.Dynamic;
using System.Drawing;

namespace Csharp_WS_CLIENT
{
    internal class Program
    {
        private WebSocket eLoc;

        [STAThread]
        public static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }


    }

}