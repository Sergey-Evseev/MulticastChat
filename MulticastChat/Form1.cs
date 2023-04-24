/*Lesson 5. С использование схемы маршрутизации multicast, реализуйте без серверный чат 
с графическим пользовательским интерфейсом. То есть такой чат, которому не нужен сервер, 
и который отправлял бы сообщения только тем компьютерам, которые его ожидают. 
Так же предусмотрите возможность мониторинга пользователей, находящихся онлайн.*/

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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using MetroFramework;
using MetroFramework.Forms;

namespace MulticastChat
{
    public partial class Form1 : MetroForm
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
        private string userName = "";
        //interval for sending heartbeat messages, in milliseconds
        private int heartbeatInterval = 5000;



        public Form1()
        {
            InitializeComponent();            

        } //end of public Form1()
        private void Form1_Load(object sender, EventArgs e)
        {
            userName = Interaction.InputBox("Please enter your user name:", "User Name", "");

           //do chat text box inaccessible programatically
            txtChat.Enabled = false;

            //Create UDP client and multicast endpoint
            udpClient = new UdpClient();

            //join the client to the multicast group specified by the multicastAddress variable
            //This tells the operating system that the UDP client is interested in receiving
            //messages sent to the specified multicast group.
            udpClient.JoinMulticastGroup(multicastAddress);

            //This endpoint will be used to SEND and RECEIVE data to/from the multicast group
            //using the UdpClient.
            multicastEndPoint = new IPEndPoint(multicastAddress, multicastPort);

            //Fix of Bind exception
            //UdpClient needs to be bound to a local port before it can receive messages.
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, multicastPort));

            //запуск таймера с заданным интервалом (после создания udpClient)
            timerHeartbeat.Interval = heartbeatInterval;
            timerHeartbeat.Start();

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
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"{timestamp} : {userName}: {txtMessage.Text}";
                        

            //The GetBytes method of the Encoding.ASCII class is used to convert the message to a byte array.
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

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
            txtMessage.Clear();
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
                //UTF-8 is a common encoding that supports a wide range of characters, including Cyrillic
                string message = Encoding.UTF8.GetString(messageBytes);

                //Check if message is a heartbeat message
                if (message.StartsWith("heartbeat"))
                {
                    //This code splits a string message using the colon character (":") as the delimiter
                    //and stores the resulting substrings in an array called messageParts.
                    string[] messageParts = message.Split('|');
                    // retrieves the second substring from the messageParts array
                    string username = messageParts[1];

                    UpdateUserList(username);
                }    
                else
                {
                    //Update chat log with message
                    UpdateChatLog(message);
                }                
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
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"heartbeat| {timestamp} - {userName} (online)";
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            udpClient.Send(messageBytes, message.Length, multicastEndPoint);
            //UpdateUserList(message);
        }

        private void UpdateUserList(string userMessage)
        {            
            //lstUsers.Items.Clear();

            //Add new item to the ListBox
            lstUsers.Items.Add(userMessage);
            //last items at the bottom of the ListBox
            lstUsers.TopIndex = lstUsers.Items.Count - 1;
        }

        private void btnSetChatColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the background color of the txtChat control
                txtChat.BackColor = colorDialog.Color;
            }
        }

        private void btnSetFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Set the font color of the txtChat control
                txtChat.ForeColor = colorDialog1.Color;
            }
        }

        private void btnSetFontSize_Click(object sender, EventArgs e)
        {
            // Display a font dialog box to let the user choose the font and size
            FontDialog fontDialog1 = new FontDialog();

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                // Set the font size of the txtChat control
                txtChat.Font = new Font(txtChat.Font.FontFamily, fontDialog1.Font.Size);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop the receive thread
            receiveThread.Abort();

            // Close the UDP client
            udpClient.Close();

            // Stop the application
            Application.Exit();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // prevent the enter key from being processed by the textbox
                btnSend.PerformClick(); // simulate a click on the send button
            }
        }
    }//end of public partial class Form1
 } //end of namespace MulticastChat
