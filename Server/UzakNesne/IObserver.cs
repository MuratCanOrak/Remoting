using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzakNesne
{
    public interface IObserver
    {
        void Notify(string text);

        void NotifyData(Object obje);
    }
}
