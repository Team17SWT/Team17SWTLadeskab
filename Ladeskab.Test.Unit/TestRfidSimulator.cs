using KlasseBibliotek;
using KlasseBibliotek.Interfaces;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    public class TestRFID
    {
        private RfidReader _uut;
        private RfidReaderEventArgs _receivedRfidEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedRfidEventArgs = null;

            _uut = new RfidReader();

            _uut.RfidReaderEvent += (o, args) =>
            {
                _receivedRfidEventArgs = args;
            };

        }

        [Test]
        public void RfidStatus_StatusSetToTrue_EventRaised()
        {
            _uut.OnRfidRead(1);

            Assert.That(_receivedRfidEventArgs, Is.Not.Null);
        }
        [Test]
        public void RfidValue_ValueSetTo5_RfidValueIsCorrect()
        {
            _uut.OnRfidRead(5);

            Assert.That(_uut.RFID, Is.EqualTo(5));
        }

        [Test]
        public void RfidStatus_StatusSetToTrue_CurrentStatusIsTrue()
        {
            _uut.OnRfidRead(5);
            Assert.That(_uut.CurrentStatus, Is.EqualTo(true));
        }
    }
}