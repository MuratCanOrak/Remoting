using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace UzakNesne
{
    public partial class Form1 : Form
    {


        MyRemotableObject remoteObject;

       


        public Form1()
        {
            InitializeComponent();
            //************************************* TCP *************************************//
            // using TCP protocol
            // running both client and server on same machines
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan);
            // Create an instance of the remote object
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://localhost:1001/HelloWorld");
            // if remote object is on another machine the name of the machine should be used instead of localhost.
            //************************************* TCP *************************************//
        }

      // Nesne nesne;


        ///// <summary>
        ///// başka pc olsaydı o sunucunun IP adresi localhost yerine yazılırdı. 
        ///// tcp://192.168.1.45:1000/VeriAl
        ///// object -> nesne Cast işlemi
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
        //       nesne = (Nesne)Activator.GetObject(typeof(UzakNesne.Nesne), "tcp://localhost:1001/HelloWorld");
        //    Process[] process = Process.GetProcessesByName("RemotingDeneme");
        //    if (process.Length == 0)
        //    {
        //        Process p = new Process();
        //        p.StartInfo = new ProcessStartInfo() { FileName = "RemotingDeneme", WindowStyle = ProcessWindowStyle.Hidden };
        //        p.Start();
        //    }
    }

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show(nesne.IsimVer());
        //}

        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    UzakNesne.Request request = new UzakNesne.Request();
        //    request.Data = textIstemci.Text;
        //    UzakNesne.Response response = nesne.DataAlCevapDon(request);


        //}

        //private void Button3_Click(object sender, EventArgs e)
        //{

        //    UzakNesne.Request request = new UzakNesne.Request();
        //    UzakNesne.Nesne nesne2 = new UzakNesne.Nesne();
        //    request.Veri = nesne2.Ac(textIstemci.Text);

        //}





        private void textBox1_TextChanged(object sender, System.EventArgs e)
        { alVer();
          //  remoteObject.SetMessage(" İstemci1: " + textBox1.Text);
           
        }
     

       
        public void alVer()
        {
            Object obje = textBox1.Text;
                remoteObject.SetData(obje); 
        }


    }
}
