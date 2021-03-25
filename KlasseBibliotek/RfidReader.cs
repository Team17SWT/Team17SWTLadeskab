using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasseBibliotek.Interfaces;

namespace KlasseBibliotek
{
    public class RfidReader : IRfidReader
    {
        public int RFID { get;set; }

        public event EventHandler<RfidReaderEventArgs> RfidReaderEvent;

        public void OnRfidRead(int id)
        {
            RFID = id;
           
            RfidReaderEvent?.Invoke(this, new RfidReaderEventArgs() { ReadRFID = this.RFID});
        }
    }
}
