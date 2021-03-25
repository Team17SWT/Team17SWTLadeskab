using System;
using KlasseBibliotek.Interfaces;

namespace KlasseBibliotek
{
    public class Door : IDoor
    {
        public bool StateOpen { get; set; }

        public bool StateLock { get; set; }


        public event EventHandler<DoorChangedEventArgs> DoorChangedEvent;

        public void OnDoorOpen()
        {
            StateOpen = true;
            DoorChangedEvent?.Invoke(this, new DoorChangedEventArgs() { State = this.StateOpen });
        }

        public void OnDoorClose()
        {
            StateOpen = false;
            DoorChangedEvent?.Invoke(this, new DoorChangedEventArgs() { State = this.StateOpen });
        }

        public void LockDoor()
        {
            StateLock = true;
        }

        public void UnlockDoor()
        {
            StateLock = false;
        }



    }
}