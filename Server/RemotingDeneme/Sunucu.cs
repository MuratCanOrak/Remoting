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
    public partial class Sunucu : Form, IObserver
    {

        private System.Windows.Forms.TextBox textBox1;
        private MyRemotableObject remotableObject;

        private System.ComponentModel.Container components = null;
        public Sunucu()
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            remotableObject = new MyRemotableObject();

            //************************************* TCP *************************************//
            // using TCP protocol
            TcpChannel channel = new TcpChannel(1001);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyRemotableObject), "HelloWorld", WellKnownObjectMode.Singleton);
            //************************************* TCP *************************************//
            UzakNesne.Cache.Attach(this);
        }

        /// <summary>
        ///arg1: Client tarafından gelen işlemleri hangi nesne üzerinden işlenecek 
        /// arg2: Veri alışverişinde kullanılacak dataya verilecek isim
        /// arg3: Dinleme yöntemi seçilmesi 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Sunucu_Load(object sender, EventArgs e)
        //{
        //    TcpChannel tcpChannel = new TcpChannel(1000); // Sunucunun dinleyeceği port bilgisinin verilmesi
        //    ChannelServices.RegisterChannel(tcpChannel); // Verdiğimiz portun kanal servislerine kayıt edilmesi
        //    RemotingConfiguration.RegisterWellKnownServiceType(typeof(UzakNesne.Nesne), "VeriAl", WellKnownObjectMode.SingleCall);

        //}




        //[STAThread] // BUNU ANLAMADIM  yorum satırı yapınca hata vermiyor
        //static void Main()
        //{
        //    Application.Run(new Sunucu());
        //}

        #region IObserver Members

        public void Notify(string text)
        {

            textBox1.Text = text;
        }

        public void NotifyData(object obje)
        {
            textBox1.Text = "Remoting başarılı -->>> \n" + obje.ToString();

        }

        #endregion

    }
}
