using KlasseBibliotek.Interfaces;
using UsbSimulator;

namespace KlasseBibliotek
{
    public class ChargeControl : IChargeControl
    {
        private readonly IUsbCharger _usbCharger;

        private readonly IDisplay _display;

        public ChargeControl(IDisplay display, IUsbCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += HandleUsbChangedEvent;
        }
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
            _display.ShowCharging();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
            _display.ShowStopCharge();
        }

        private void HandleUsbChangedEvent(object sender, CurrentEventArgs e)
        {
            if (e.Current > 0.0 && e.Current <= 5.0)
            {
                StopCharge();
                _display.ShowFullyCharged();
            }
            if (e.Current > 500.0)
            {
                StopCharge();
                _display.ShowErrorCharging();
            }
        }
    }
}