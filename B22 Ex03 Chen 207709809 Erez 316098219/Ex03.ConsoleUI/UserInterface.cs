using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public enum eClientChosenAction
        {
            EnterVehicleIntoGarage = 1,
            DisplayLicenseNumbers = 2,
            ChangeVehicleState = 3,
            FillAirToMax = 4,
            FuelVehicle = 5,
            ChargeVehicle = 6,
            DisplayVheicleDetails = 7,
            Exit = 9,

        }

        private Garage m_Garage;

        public UserInterface()
        {
            m_Garage = new Garage();
        }

        public void GarageIsOpen()
        {
            eClientChosenAction action = eClientChosenAction.DisplayLicenseNumbers;

            do
            {
                action = getClientChosenAction();
                if (action != eClientChosenAction.Exit)
                {
                    handleClientAction(action);
                }

            }
            while (action != eClientChosenAction.Exit);

            Console.WriteLine("Thank you for coming to our garage, goodbye");
        }

        private void handleClientAction(eClientChosenAction i_Action)
        {
            if (i_Action == eClientChosenAction.EnterVehicleIntoGarage)
            {
                enterVehicleIntoGarage();
            }
            else if (i_Action == eClientChosenAction.DisplayLicenseNumbers)
            {
                displayLicensesNumbers();
            }
            else if (i_Action == eClientChosenAction.ChangeVehicleState)
            {
                changeVehicleState();
            }
            else if (i_Action == eClientChosenAction.FillAirToMax)
            {
                fillAirToMax();
            }
            else if (i_Action == eClientChosenAction.FuelVehicle)
            {
                fuelVehicle();
            }
            else if (i_Action == eClientChosenAction.ChargeVehicle)
            {
                chargeVehicle();
            }
            else if (i_Action == eClientChosenAction.DisplayVheicleDetails)
            {
                displayVheicleDetails();
            }
        }

        private void enterVehicleIntoGarage()
        {
            string licenseNumber = "";

            Console.WriteLine("Please enter the license number of your vehicle: ");
            licenseNumber = Console.ReadLine();
            if (m_Garage.)//containsKey
            {
                Console.WriteLine(string.format("Hello {0}, your {1}, is already in the garage"), m_Garage.nameOfOwner m_Garage.vehicleType)//the right vehicle connected to the license number)
            }
            else
            {
                enterNewVehicle(licenseNumber);
            }

        }

        private void enterNewVehicle(string i_LicenseNumber)
        {

            //get vehicle type from user, and energy type
            VehicleGenerator.eVehicleType vehicleType = getVehicleTypeFromClient();
            VehicleGenerator.eEnergyType vehicleEnergyType = getEnergyTypeFromClient();
            m_Garage.AddVehicle(i_LicenseNumber, vehicleType, vehicleEnergyType);
        }

        private VehicleGenerator.eVehicleType getVehicleTypeFromClient()
        {
            VehicleGenerator.eVehicleType Type = VehicleGenerator.eVehicleType.Car;

            Console.WriteLine("Please Enter Your vehicle type: ");
            Console.WriteLine("Press ");

        }

        private VehicleGenerator.eEnergyType getEnergyTypeFromClient()
        {
            string UserInputType = "";
            VehicleGenerator.eEnergyType energyType = VehicleGenerator.eEnergyType.Fuel;

            Console.WriteLine("Please Enter Your vehicle Energy type: ");
            UserInputType = Console.ReadLine();
            //exeption here if not fuel or electric
            if (UserInputType == "Fuel")
            {
                energyType = VehicleGenerator.eEnergyType.Fuel;
            }
            else
            {
                energyType = VehicleGenerator.eEnergyType.Electric;
            }
            return energyType;
        }

        private void displayLicensesNumbers()
        {
            bool validInput = false;
            string withFilter = "";

            Console.WriteLine(string.Format("Please press 1 if you want to display the license numbers by filter, else press 2:{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("1. Yes. {0}"), Environment.NewLine);
            Console.WriteLine(string.Format("2. No. {0}"), Environment.NewLine);

            do
            {
                withFilter = Console.ReadLine();
                if (withFilter == "1")
                {
                    displayLicensesNumbersWithoutFilter();
                    validInput = true;
                }
                else if (withFilter == "2")
                {
                    displayLicensesNumbersWithFilter();
                    validInput = true;
                }
                else
                {
                    // exeption that the input is invalid
                }

            }
            while (!validInput);



        }
        private eClientChosenAction getClientChosenAction()
        {
            string chosenAction = "";

            Console.WriteLine(string.Format("Hello, welcome to our garage, please choose an action from the list below:{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("1. Enter your Vehicle Into our Garage.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("2. Display all vehicles license numbers.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("3. Change your vehicle's state.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("4. Fill the air in yout wheels to max.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("5. Fuel your vehicle.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("6. Charge your vehicle's battery.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("7. Display your vehicle's details.{0}"), Environment.NewLine);
            Console.WriteLine(string.Format("9. Exit.{0}"), Environment.NewLine);
            //check here in loop maybe until the input is correct.
            chosenAction = Console.ReadLine();
            return (eClientChosenAction)int.Parse(chosenAction);
        }


    }
}
