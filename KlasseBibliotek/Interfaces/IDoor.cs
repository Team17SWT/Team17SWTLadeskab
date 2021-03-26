using System;

namespace KlasseBibliotek.Interfaces
{
    public class DoorChangedEventArgs : EventArgs
    {
        public bool State { get; set; }
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