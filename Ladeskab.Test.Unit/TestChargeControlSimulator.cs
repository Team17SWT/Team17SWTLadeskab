using KlasseBibliotek;
using KlasseBibliotek.Interfaces;
using NSubstitute;
using NUnit.Framework;

//TEST 

namespace Ladeskab.Test.Unit
{
    public class TestChargeControlSimulator
    {
        private ChargeControl _uut;
        private IDisplay _display;
        private IUsbCharger _usbCharger;

        [SetUp]

        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();

            _uut = new ChargeControl(_display,_usbCharger);
        }

        [Test]

        public void IsConnected_PhoneIsConnected_ReturnsTrue()
        {
            _usbCharger.Connected.Returns(true);

            Assert.IsTrue(_uut.IsConnected());
        }

        [Test]

        public void IsConnected_PhoneIsNotConnected_ReturnsFalse()
        {
            _usbCharger.Connected.Returns(false);

            Assert.IsFalse(_uut.IsConnected());
        }

        [Test]

        public void ChargeControl_StartCharge_CallsFunctionsCorrect()
        {
            _uut.StartCharge();

            _usbCharger.Received().StartCharge();
            _display.Received().ShowCharging();
        }

        [Test]

        public void ChargeControl_StopCharge_CallsFunctionsCorrect()
        {
            _uut.StopCharge();

            _usbCharger.Received().StopCharge();
            _display.Received().ShowStopCharge();
        }

        [Test]

        public void HandleEvent_Between0and5_EventCalled()
        {
            _uut.HandleUsbChangedEvent(this, new CurrentEventArgs() { Current = 3.0 });

            _display.Received().ShowFullyCharged();

        }

        [Test]

        public void HandleEvent_Over500_EventCalled()
        {
            _uut.HandleUsbChangedEvent(this, new CurrentEventArgs() {Current = 600.0});
            
            _display.Received().ShowErrorCharging();

        }




    }
}