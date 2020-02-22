using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    public partial class RemoteControlService : ServiceBase
    {
        public RemoteControlService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();

            while (true)   //we wait for a connection
            {
                TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it

                NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

                byte[] hello = new byte[100];   //any message must be serialized (converted to byte array)
                hello = Encoding.Default.GetBytes("hello world");  //conversion string => byte array

                ns.Write(hello, 0, hello.Length);     //sending the message

                while (client.Connected)  //while the client is connected, we look for incoming messages
                {
                    byte[] msg = new byte[1024];     //the messages arrive as byte array
                    ns.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                    string text = Encoding.Default.GetString(msg); //now , we write the message as string
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
