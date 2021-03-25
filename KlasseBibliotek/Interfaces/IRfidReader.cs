using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasseBibliotek.Interfaces
{
    public class RfidReaderEventArgs : EventArgs
    { 
        public bool Status { private get; set; }
        public int ReadRFID { private get; set; }
    }
    public interface IRfidReader
    {
        event EventHandler<RfidReaderEventArgs> RfidReaderEvent;
        void OnRfidRead(int id);

    }
}
