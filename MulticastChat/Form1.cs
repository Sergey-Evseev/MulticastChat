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
        //variable that will be used to store the name of the user or device that is sending the heartbeat messages.
        private string userName;
        //interval for sending heartbeat messages, in milliseconds
        private int heartbeatInterval = 5000;



        public Form1()
        {
            InitializeComponent();
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

        }

        private void ReceiveMessages()
        {
            //Create buffer for receiving messages
            byte[] receiveBuffer = new byte[1024];

            //Start loop for receiving messages
            while (true)
            {
                //Receive message from multicast group
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] messageBytes = udpClient.Receive(ref remoteEndPoint);
            }
}

        
    }
}
