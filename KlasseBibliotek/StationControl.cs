using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasseBibliotek;
using KlasseBibliotek.Interfaces;
using UsbSimulator;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        //private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IRfidReader _rfidReader;
        private ILogFile _logFile;
        private static IDisplay _display;
        private IChargeControl _chargeControl = new ChargeControl(new Display(), new UsbChargerSimulator());
        private bool CurrentStateDoor { get; set; }

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl()
        {
            _door.DoorChangedEvent += HandleDoorChangedEvent;
            _rfidReader.RfidReaderEvent += HandleRfidStatusEvent;
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        //private void RfidDetected(int id)
        //{
        //    switch (_state)
        //    {
        //        case LadeskabState.Available:
        //            // Check for ladeforbindelse
        //            if (_chargeControl.IsConnected())
        //            {
        //                _door.LockDoor();
        //                _chargeControl.StartCharge();
        //                _oldId = id;
        //                _logFile.LogDoorLocked(id);

        //                Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        //                _state = LadeskabState.Locked;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        //            }

        //            break;

        //        case LadeskabState.DoorOpen:
        //            // Ignore
        //            break;

        //        case LadeskabState.Locked:
        //            // Check for correct ID
        //            if (id == _oldId)
        //            {
        //                _charger.StopCharge();
        //                _door.UnlockDoor();
        //                _logFile.LogDoorUnlocked(id);

        //                Console.WriteLine("Tag din telefon ud af skabet og luk døren");
        //                _state = LadeskabState.Available;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Forkert RFID tag");
        //            }

        //            break;
        //    }
        //}

        // Her mangler de andre trigger handlere
        private void HandleDoorChangedEvent(object sender, DoorChangedEventArgs e)
        {
            CurrentStateDoor = e.State;

            if (CurrentStateDoor == true)
            {
                DoorOpened();
            }
            else
            {
                DoorClosed();
            }
        }

        public void DoorOpened()
        {
            if (_state == LadeskabState.Available)
            {
                _state = LadeskabState.DoorOpen;
                _display.ShowConnectPhone();
            }
        }

        public void DoorClosed()
        {
            if (_state == LadeskabState.DoorOpen)
            {
                _state = LadeskabState.Available;
                _display.ShowReadRfid();
            }
        }

        private void HandleRfidStatusEvent(object sender, RfidReaderEventArgs e)
        {
            if (_state == LadeskabState.Available || _state == LadeskabState.Locked)
            {
                //RfidDetected(e.ReadRFID);
            }
        }
    }
}