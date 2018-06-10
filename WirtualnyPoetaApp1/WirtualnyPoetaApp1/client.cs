using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;



namespace WirtualnyPoetaApp1
{


    public class Client
    {
        private static IPHostEntry ipHostInfo;
        public static IPAddress ipAddress;
        private static IPEndPoint remoteEP;
        private static byte[] bytes = new byte[8192];
        public static string tekst;
        public static string show;
        public static string message;
        // Create a TCP/IP  socket.  
        private static Socket sender;

        public static bool checkbox1;
        public static bool checkbox2;
        public static bool checkbox3;
        public static bool checkbox4;
        public static bool checkbox5;

        public static void StartClient()
        {
            // Data buffer for incoming data.  

            // Connect to a remote device.  
            try
            {
                
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.  
                sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                sender.ReceiveTimeout = 1000;
                sender.SendTimeout = 1000;
                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    message = ("Socket connected to {0}" + sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] options = new byte[5];
                    options[0] = Convert.ToByte(checkbox1);
                    options[1] = Convert.ToByte(checkbox2);
                    options[2] = Convert.ToByte(checkbox3);
                    options[3] = Convert.ToByte(checkbox4);
                    options[4] = Convert.ToByte(checkbox5);

                    byte[] msg = Encoding.UTF8.GetBytes(tekst);

                    // Send the data through the socket.  

                    //int bytesSent1 = sender.Send(options);
                    int bytesSent2 = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    show = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    message = ("ArgumentNullException : {0}" + ane.ToString());
                }
                catch (SocketException se)
                {
                    message = ("SocketException : {0}" + se.ToString());
                }
                catch (Exception e)
                {
                    message = ("Unexpected exception : {0}" + e.ToString());
                }

            }
            catch (Exception e)
            {
                message = (e.ToString());
            }
        }

    }
}
