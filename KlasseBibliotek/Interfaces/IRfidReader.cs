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
        private bool status;

        public bool Status
        {
            set { status = value; }
        }

        private int readRFID;

        public int ReadRFID
        {
            set { readRFID = value; }
        }
    }

    public interface IRfidReader
    {
        event EventHandler<RfidReaderEventArgs> RfidReaderEvent;
        void OnRfidRead(int id);

    }
    
}
