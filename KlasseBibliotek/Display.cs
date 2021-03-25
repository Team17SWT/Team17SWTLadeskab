using System;
using KlasseBibliotek.Interfaces;

namespace KlasseBibliotek
{
    public class Display : IDisplay
    {
        public string _message = null;
        public void ShowConnectPhone()
        {
            _message = "Tilslut Telefon";
            Console.WriteLine(_message);
        }

        public void ShowReadRfid()
        {
            _message = "Indlæs RFID";
            Console.WriteLine(_message);
        }

        public void ShowConnectionError()
        {
            _message = "Tilslutningsfejl";
            Console.WriteLine(_message);
        }

        public void ShowOccupied()
        {
            _message = "Ladeskab Optaget";
            Console.WriteLine(_message);
        }

        public void ShowRfidError()
        {
            _message = "RFID Fejl";
            Console.WriteLine(_message);
        }

        public void ShowRemovePhone()
        {
            _message = "Fjern telefon";
            Console.WriteLine(_message);
        }

        public void ShowFullyCharged()
        {
            _message = "Telefon er fuldt opladet";
            Console.WriteLine(_message);
        }

        public void ShowCharging()
        {
            _message = "Telefonladning er igang";
            Console.WriteLine(_message);
        }

        public void ShowErrorCharging()
        {
            _message = "Fejl i ladning";
            Console.WriteLine(_message);
        }

        public void ShowStopCharge()
        {
            _message = "Ladning stoppet";
            Console.WriteLine(_message);
        }
    }
}