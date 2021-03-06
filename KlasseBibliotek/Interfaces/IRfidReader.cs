using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KlasseBibliotek.Interfaces
{
    public class RfidReaderEventArgs : EventArgs
    {
        public int ReadRFID { get; set; }
    }

    public interface IRfidReader
    {
        event EventHandler<RfidReaderEventArgs> RfidReaderEvent;
        void OnRfidRead(int id);

    }
    
}
