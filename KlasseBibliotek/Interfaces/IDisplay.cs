namespace KlasseBibliotek.Interfaces
{
    public interface IDisplay
    {
        void ShowConnectPhone();
        void ShowReadRfid();
        void ShowConnectionError();
        void ShowOccupied();
        void ShowRfidError();
        void ShowRemovePhone();
        void ShowFullyCharged();
        void ShowCharging();
        void ShowStopCharging();
    }
}