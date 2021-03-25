using KlasseBibliotek.Interfaces;
using UsbSimulator;

namespace KlasseBibliotek
{
    public class ChargeControl : IChargeControl
    {
        private UsbChargerSimulator _usbCharger = new UsbChargerSimulator();
        public bool IsConnected()
        {

            if (_usbCharger.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }

    }
}