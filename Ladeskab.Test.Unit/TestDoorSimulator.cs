using KlasseBibliotek;
using KlasseBibliotek.Interfaces;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    public class Tests
    {
        private Door _uut;
        private DoorChangedEventArgs _receivedDoorEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedDoorEventArgs = null;

            _uut = new Door();

            _uut.DoorChangedEvent += (o, args) =>
            {
                _receivedDoorEventArgs = args;
            };

        }

        [Test]
        public void DoorState_StateSetToOpen_EventRaised()
        {
            _uut.OnDoorOpen();

            Assert.That(_receivedDoorEventArgs, Is.Not.Null);
        }

        [Test]
        public void DoorState_StateSetToClose_EventRaised()
        {
            _uut.OnDoorClose();

            Assert.That(_receivedDoorEventArgs, Is.Not.Null);
        }

        [Test]
        public void DoorState_StateSetToOpen_DoorStateIsTrue()
        {
            _uut.OnDoorOpen();

            Assert.That(_uut.StateOpen, Is.EqualTo(true));
        }

        [Test]
        public void DoorState_StateSetToClose_DoorStateIsFalse()
        {
            _uut.OnDoorClose();

            Assert.That(_uut.StateOpen, Is.EqualTo(false));
        }
    }
}