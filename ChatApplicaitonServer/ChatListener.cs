using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace ChatApplicaitonServer
{
    internal class ChatListener
    {
        internal void StartListener()
        {

            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse("192.168.1.200"), 2706);
                   
                server.Start();

                while (true)
                {

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    ParameterizedThreadStart ts = new ParameterizedThreadStart(Worker);
                    Thread clientThread = new Thread(ts);
                    clientThread.Start(client);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
        }

        public void Worker(object o)
        {
            TcpClient client = (TcpClient)o;
            NetworkStream stream = client.GetStream();


            string data = ReadStringFromStream(stream);

            Console.WriteLine("%s", data);

        }


        public static string ReadStringFromStream(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
            return response;
        }
    }
}
