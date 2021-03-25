namespace KlasseBibliotek.Interfaces
{
    public interface IChargeControl
    {
        bool IsConnected();


        void StartCharge();

        void StopCharge();
    }
}