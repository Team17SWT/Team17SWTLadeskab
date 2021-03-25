using System;

namespace KlasseBibliotek.Interfaces
{
    public class DoorChangedEventArgs : EventArgs
    {
        private bool state;

        public bool State
        {
            set { state = value; }
        }
    }
    public interface IDoor
    {

        event EventHandler<DoorChangedEventArgs> DoorChangedEvent;
        void OnDoorOpen();
        void OnDoorClose();
        void LockDoor();
        void UnlockDoor();

    }
}