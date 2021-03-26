using KlasseBibliotek;
using KlasseBibliotek.Interfaces;
using NSubstitute;
using NUnit.Framework;

//TEST 

namespace Ladeskab.Test.Unit
{
    public class TestStationControl
    {
        private StationControl _uut;
        private IDisplay _display;
        private IUsbCharger _usbCharger;
        private IDoor _door;
        private IRfidReader _rfidReader;
        private ILogFile _logFile;
        private IChargeControl _chargeControl;

        [SetUp]

        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _rfidReader = Substitute.For<IRfidReader>();
            _logFile = Substitute.For<ILogFile>();
            _chargeControl = Substitute.For<IChargeControl>();

            _uut = new StationControl(_door, _display, _chargeControl, _logFile, _rfidReader);
        }

        [Test]

        public void StationControl_CheckIdCorrect_ReturnsTrue()
        {
            var checkId = _uut.CheckId(1, 1);

            Assert.That(checkId, Is.EqualTo(true));

        }

        [Test]
        public void StationControl_CheckIdNotCorrect_ReturnsFalse()
        {
            var checkId = _uut.CheckId(1, 2);

            Assert.That(checkId, Is.EqualTo(false));

        }

        [Test]

        public void StationControl_CheckOpenDoor_EventCalled()
        {
            _uut.HandleDoorChangedEvent(this, new DoorChangedEventArgs() {State = true});

            _display.Received().ShowConnectPhone();
        }

        [Test]

        public void StationControl_CheckCloseDoor_EventCalled()
        {
            _uut.DoorOpened();
            _uut.HandleDoorChangedEvent(this, new DoorChangedEventArgs() {State = false});

            _display.Received().ShowReadRfid();
        }

        [Test]

        public void StationControl_RfidReadPhoneConnected_EventCalled()
        {
            _chargeControl.IsConnected().Returns(true);

            _uut.HandleRfidStatusEvent(this, new RfidReaderEventArgs() { ReadRFID = 1 });

            Assert.Multiple(() =>
            {
                _door.Received().LockDoor();
                _chargeControl.Received().StartCharge();
                _logFile.Received().LogDoorLocked(1);
                _display.Received().ShowOccupied();
            });
        }

        [Test]

        public void StationControl_RfidReadPhoneIsNotConnected_EventCalled()
        {
            
            _uut.HandleRfidStatusEvent(this, new RfidReaderEventArgs() { ReadRFID = 1 });

            _display.Received().ShowConnectionError();
        }
    }
}