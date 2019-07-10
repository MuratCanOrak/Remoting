using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace UzakNesne
{
    public class MyRemotableObject : MarshalByRefObject 
    {


        public MyRemotableObject()
        {

        }

        public void SetMessage(string message)
        {
            Cache.GetInstance().MessageString = message;
        }

        public void SetData(object obje)
        {
            Cache.GetInstance().DataObject = obje;
        }

   

    }
}
