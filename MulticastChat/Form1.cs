using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace MulticastChat
{
    public partial class Form1 : Form
    {
        //Multicast group address and port number
        //The multicast address 239.0.0.1 is a reserved address used for "all hosts
        //on this subnet". It is a special address that is used for local network
        //communication, and it is not routable over the Internet.
        private IPAddress multicastAddress = IPAddress.Parse("239.0.0.1");
        private int multicastPort = 8000;

        //UDP client and multicast endpoint:
        //This variable will be used to send and receive data to/from the multicast group.
        private UdpClient udpClient;
        //This variable will be used to specify the destination for the multicast messages
        //sent by the UdpClient.
        private IPEndPoint multicastEndPoint;

        //Thread for receiving messages
        //new thread that runs in the background to receive messages sent to the multicast group
        //program can continue to execute other tasks without being blocked while waiting
        //for incoming messages
        private Thread receiveThread;

        //User name and heartbeat interval
        //variable that will be used to store the name of the user or device
        //that is sending the heartbeat messages.
        private string userName;
        //interval for sending heartbeat messages, in milliseconds
        private int heartbeatInterval = 5000;



        public Form1()
        {
            InitializeComponent();
            timerHeartbeat.Interval = heartbeatInterval;
            timerHeartbeat.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            
            //Create UDP client and multicast endpoint
            udpClient = new UdpClient();
            
            //join the client to the multicast group specified by the multicastAddress variable
            //This tells the operating system that the UDP client is interested in receiving
            //messages sent to the specified multicast group.
            udpClient.JoinMulticastGroup(multicastAddress);

            //This endpoint will be used to SEND and RECEIVE data to/from the multicast group
            //using the UdpClient.
            multicastEndPoint = new IPEndPoint(multicastAddress, multicastPort);

            //fix of Bind exception
            //UdpClient needs to be bound to a local port before it can receive messages.
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, multicastPort));

            //Start thread for receiving messages
            //starts a new thread to run the ReceiveMessages method in the background
            //The constructor takes a delegate that represents the method that will be executed
            //in the new thread.  In this case, the delegate is created using the ThreadStart
            //constructor, which takes a reference to the ReceiveMessages method.
            receiveThread = new Thread(new ThreadStart(ReceiveMessages));
            receiveThread.Start();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            //Construct message and convert to bytes
            //userName the name of the user sending the message
            string message = userName + ": " + txtMessage.Text;

            //The GetBytes method of the Encoding.ASCII class is used to convert the message to a byte array.
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            //Send message to multicast group
            //The messageBytes byte array contains the message data
            //messageBytes.Length specifies the length of the message data in bytes
            //multicastEndPoint variable specifies the IP endpoint of the multicast group to which
            //the message should be sent.
            udpClient.Send(messageBytes, messageBytes.Length, multicastEndPoint);
            //Overall, this code constructs a message string from the user's name and the text entered in a text box,
            //encodes the message as a byte array using ASCII encoding, and sends the message to the multicast
            //group using the UdpClient class.


            //Clear message text box
            //line clears the text box containing the message text, so that the user can enter a new message.
            txtMessage.Text = "";
        }

        private void ReceiveMessages()
        {
            //Create buffer for receiving messages
            byte[] receiveBuffer = new byte[1024];

            //Start loop for receiving messages
            while (true)
            {
                //Receive message from multicast group
                //the endpoint will listen for incoming messages from any IP address and any port number.
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                
                //receives a message sent to the UDP client using the Receive method of the UdpClient class
                //Receive method blocks the thread until a message is received, and then returns
                //the received data as a byte array. The ref remoteEndPoint parameter is used to return
                //the IP endpoint from which the message was received.
                byte[] messageBytes = udpClient.Receive(ref remoteEndPoint);

                //Convert message to string
                //The Encoding.ASCII class provides methods for converting strings to
                //and from ASCII-encoded byte arrays
                string message = Encoding.ASCII.GetString(messageBytes);

                //Update chat log with message
                UpdateChatLog(message);
            }//end of while loop
        }//end of ReceiveMessages()

        private void UpdateChatLog(string message)
        {
            //Свойство InvokeRequired проверяет, явл. ли текущий поток потоком,
            //создавшим элемент управления текстбокс txtChat.
            //Если это не так, то к элементу управления нельзя получить доступ непосредственно
            //из текущего потока, поэтому к нему нужно обратиться из потока пользовательского интерфейса.
            //Метод Invoke ставит делегат в очередь на выполнение в потоке, который создал элемент управления.
            if (txtChat.InvokeRequired)
            {
                //Invoke UpdateChatlog on UI thread
                Invoke(new Action(() => UpdateChatLog(message)));
            }

            //Если текущим потоком является поток пользовательского интерфейса, метод добавляет сообщение
            //в журнал чата, вызывая метод AppendText элемента управления txtChat
            else
            {
                //Append message to chat log
                txtChat.AppendText(message + "\r\n");
            }
        }//end of UpdateChatLog()

        //In the timerHeartbeat_Tick method, we construct a heartbeat message indicating
        //that the user is online and send it to the multicast group using the udpClient.
        private void timerHeartbeat_Tick(object sender, EventArgs e)
        {
            //Send message to multicast group
            string message = userName + " (online)";
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            udpClient.Send(messageBytes, message.Length, multicastEndPoint);

        }

        private void UpdateUserList(string[] userList)
        {
            if (lstUsers.InvokeRequired)
            {
                // Invoke UpdateUserList on UI thread
                Invoke(new Action(() => UpdateUserList(userList)));
            }
            else
            {
                // Clear user list and add active users
                lstUsers.Items.Clear();

                foreach (string user in userList)
                {
                    lstUsers.Items.Add(user);
                }
            }

        }
    }//end of public partial class Form1
 } //end of namespace
