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
        [STAThread]
        public static void Main(string[] args)
        {
            PictureBox pictureBox;

            int Frq_Reconnect = 10000; //10 seconds
            WebSocket wsc = new WebSocket("ws://localhost:7456/Echo");
            wsc.OnOpen += (sender, e) =>
            {
                SendConnectMessage();
                //Form1 form1 = new Form1();
               // Form1.StartSendingLocationUpdates();
            };
            wsc.OnClose += (sender, e) =>
            {
                if (wsc.ReadyState == WebSocketState.Open)
                {
                    SendDisconnectMessage();
                }
            };
            wsc.Connect();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            void SendConnectMessage()
            {
                var connectMessage = new
                {
                    type = "connect",
                    message = "Client connected."
                };

                string jsonMessage = JsonConvert.SerializeObject(connectMessage);
                wsc.Send(jsonMessage);
            }

            void SendDisconnectMessage()
            {
                var disconnectMessage = new
                {
                    type = "disconnect",
                    message = "Client disconnected."
                };

                string jsonMessage = JsonConvert.SerializeObject(disconnectMessage);
                wsc.Send(jsonMessage);
            }




            dynamic json = new JObject();
            json.message = "Connection Alive";

            // Connection loop
            while (true)
            {
                try
                {
                    if (!wsc.IsAlive)
                    {
                        wsc.Send("Connection Died");
                        wsc.Connect();
                        if (wsc.IsAlive)
                        {
                            // Connection established, send a message to the server

                            wsc.Send("Connection Alive");
                            wsc.Send(JsonConvert.SerializeObject(json, Formatting.None));

                        }
                        else
                        {
                            Console.WriteLine(string.Format("Attempting to reconnect in {0} s", Frq_Reconnect / 1000));
                            System.Threading.Thread.Sleep(Frq_Reconnect);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Failed to connect to 127.0.0.1:7456 Exception: {0}", e.Message));
                    System.Threading.Thread.Sleep(Frq_Reconnect);
                }
            }

        }


    }
    
    
}

