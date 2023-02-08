//using System;
//using WebSocketSharp;
//using System.Windows.Forms;
//using WebSocket = WebSocketSharp.WebSocket;
//using Newtonsoft.Json;

//using Newtonsoft.Json.Linq;

//namespace Csharp_WS_CLIENT
//{
  //  internal class Program
    //{
      //  [STAThread]


        //static void Main(string[] args)
        //{

           // Locals
          //  string host = "127.0.0.1";
            //int port = 7456;
            //int Frq_Reconnect = 10000;
            //WebSocket ws;

            // Callback handlers
            //void ws_OnClose(object sender, CloseEventArgs e)
            //{
              //  Console.WriteLine("Closed for: " + e.Reason);
            //}

            //void ws_OnError(object sender, ErrorEventArgs e)
            //{
              //  Console.WriteLine("Errored");
            //}

            //void ws_OnMessage(object sender, MessageEventArgs e)
            //{
             //   Console.WriteLine("Messaged: " + e.Data);
            //}

            //void ws_OnOpen(object sender, EventArgs e)
            //{
              //  Console.WriteLine("Opened");
            //}


            // Start WebSocket Client
            //ws = new WebSocket(string.Format("ws://{0}:{1}", host, port));
            //ws.OnOpen += new EventHandler(ws_OnOpen);
            //ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
            //ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
            //ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);

            //dynamic json = new JObject();
            //json.message = "Connection Alive";
            // Connection loop
            //while (true)
            //{
              //  try
                //{
                  //  if (!ws.IsAlive)
                    //{
                      //  ws.Connect();
                        //if (ws.IsAlive)
                        //{
                          //  ws.Send(JsonConvert.SerializeObject(json, Formatting.None));
                        //}
                        //else
                        //{
                          //  Console.WriteLine(string.Format("Attempting to reconnect in {0} s", Frq_Reconnect / 1000));
                            //System.Threading.Thread.Sleep(Frq_Reconnect);
                        //}
                    //}
                //}
                //catch (Exception e)
                //{
                  //  string errMsg = e.Message.ToString();
                    //if (errMsg.Equals("The current state of the connection is not Open."))
                    //{// remote host does not exist
                     //   Console.WriteLine(string.Format("Failed to connect to {0}:{1}", host, port));
                    //}
                    //if (errMsg.Equals("A series of reconnecting has failed."))
                    //{// refusal of ws object to reconnect; create new ws-object

                      //  ws.Close();

                        //ws = new WebSocket(string.Format("ws://{0}:{1}", host, port));
                        //ws.OnOpen += new EventHandler(ws_OnOpen);
                        //ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
                        //ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
                        //ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);

                    //}
                    //else
                    //{// any other exception
                      //  Console.WriteLine(e.ToString());
                    //}

                //}




            //}// end      static void Main(...)

        //}

        //private static void Ws_OnMessage(object sender, MessageEventArgs e)
        //{
          //  Console.WriteLine("Recieved from the server:  " + e.Data);

        //}



    //}
// }

