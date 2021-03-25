using KlasseBibliotek;
using KlasseBibliotek.Interfaces;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    public class TestDisplaySimulator
    {
        private Display _uut;

        [SetUp]

        public void Setup()
        {
            _uut = new Display();
        }

        [Test]

        public void ConnectPhone_MessageIsCorrect_MessageIsConnectPhone()
        {
            _uut.ShowCharging();

            Assert.That(_uut._message, Is.EqualTo("Tilslut Telefon"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsReadRfid()
        {
            _uut.ShowReadRfid();

            Assert.That(_uut._message, Is.EqualTo("Indlæs RFID"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsConnectionError()
        {
            _uut.ShowConnectionError();

            Assert.That(_uut._message, Is.EqualTo("Tilslutningsfejl"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsOccupied()
        {
            _uut.ShowOccupied();

            Assert.That(_uut._message, Is.EqualTo("Ladeskab Optaget"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsRfidError()
        {
            _uut.ShowRfidError();

            Assert.That(_uut._message, Is.EqualTo("RFID Fejl"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsRemovePhone()
        {
            _uut.ShowRemovePhone();

            Assert.That(_uut._message, Is.EqualTo("Fjern telefon"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsFullyCharged()
        {
            _uut.ShowFullyCharged();

            Assert.That(_uut._message, Is.EqualTo("Telefon er fuldt opladet"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsCharging()
        {
            _uut.ShowCharging();

            Assert.That(_uut._message, Is.EqualTo("Telefonladning er igang"));
        }

        [Test]

        public void RfidRead_MessageIsCorrect_MessageIsStopCharging()
        {
            _uut.ShowStopCharging();

            Assert.That(_uut._message, Is.EqualTo("Fejl i ladning"));
        }





    }
}