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
            m_Garage.AddVehicleToGarage(i_LicenseNumber, vehicleType, EnergyType);
        }

        private eClientChosenAction getClientChosenAction()
        {
            eClientChosenAction chosenAction;
            bool validInput = false;

            while (!validInput)
            {
                validInput = chosen
            }

        }


    }
}
