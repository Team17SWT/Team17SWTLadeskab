using System;
using KlasseBibliotek;
using UsbSimulator;

namespace Ladeskab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            Door door = new Door();
            RfidReader rfidReader = new RfidReader();
            LogFile logfile = new LogFile();
            Display display = new Display();
            UsbChargerSimulator usbChargerSimulator = new UsbChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(display, usbChargerSimulator);
            StationControl stationControl = new StationControl(door, display, chargeControl, logfile, rfidReader);


            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();
                        try
                        {
                            int id = Convert.ToInt32(idString);
                            rfidReader.OnRfidRead(id);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid Input, prøv igen!");
                        }
                        ;
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
