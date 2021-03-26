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
        private int _oldId;
        private readonly IDoor _door;
        private readonly IRfidReader _rfidReader;
        private readonly ILogFile _logFile;
        private readonly IDisplay _display;
        private readonly IChargeControl _chargeControl;
        private bool CurrentStateDoor { get; set; }

        // Her mangler constructor
        public StationControl(IDoor door, IDisplay display, IChargeControl chargeControl, ILogFile logFile, IRfidReader rfidReader)
        {

            _door = door;
            _display = display;
            _chargeControl = chargeControl;
            _logFile = logFile;
            _rfidReader = rfidReader;

            _door.DoorChangedEvent += HandleDoorChangedEvent;
            _rfidReader.RfidReaderEvent += HandleRfidStatusEvent;
          
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_chargeControl.IsConnected())
                    {
                        _door.LockDoor();
                        _chargeControl.StartCharge();
                        _oldId = id;
                        _logFile.LogDoorLocked(id);

                        _display.ShowOccupied();
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ShowConnectionError();
                    }

                    break;

                //case LadeskabState.DoorOpen:
                //    // Ignore
                //    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (CheckId(_oldId, id))
                    {
                        _chargeControl.StopCharge();
                        _door.UnlockDoor();
                        _logFile.LogDoorUnlocked(id);

                        _display.ShowRemovePhone();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.ShowRfidError();
                    }

                    break;
            }
        }

        public bool CheckId(int oldId, int id)
        {
            if (id == oldId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Her mangler de andre trigger handlere
        public void HandleDoorChangedEvent(object sender, DoorChangedEventArgs e)
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

        public void HandleRfidStatusEvent(object sender, RfidReaderEventArgs e)
        {
            if (_state == LadeskabState.Available || _state == LadeskabState.Locked)
            {
                RfidDetected(e.ReadRFID);
            }
        }
    }
}