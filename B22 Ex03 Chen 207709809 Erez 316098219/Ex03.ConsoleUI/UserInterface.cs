using System;
using System.Collections.Generic;
using StringBuilder = System.Text.StringBuilder;
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
            Exit = 8,

        }

        private const int k_LicenseNumberLength = 20;

        private readonly List<string> r_Actions;
        private Garage m_Garage;
        public delegate bool validateFunctionInput(StringBuilder i_Input);

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
                try
                {
                    if (action != eClientChosenAction.Exit)
                    {
                        handleClientAction(action);
                    }
                }
                catch (ArgumentException argException)
                {
                    Console.WriteLine(argException);
                }
                catch (FormatException)
                {
                    Console.WriteLine
                }
                catch (ValueOutOfRangeException)
                {
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

        private void changeVehicleState()
        {
            string licenseNumber;

            getClientDetail(out licenseNumber, "Please enter the license number of your vehicle: ", isValidLicenseNumber);

            getTypeFromUser<VehicleGenerator.eVehicleType>(out vehicleType, m_Garage.VehicleGenerator.SupportedVehicles, "vehicle");
        }
        private void enterVehicleIntoGarage()
        {
            string licenseNumber = "";

            Console.WriteLine("Please enter the license number of your vehicle: ");
            licenseNumber = Console.ReadLine();
            if (m_Garage.IsVehicleExists(licenseNumber))//containsKey
            {
                Console.WriteLine(string.Format("Hello {0}, Your vehicle, is already in the garage"), m_Garage.GetClient(licenseNumber));
            }
            else
            {
                enterNewVehicle(licenseNumber);
            }

        }

        private void enterNewVehicle(string i_LicenseNumber)
        {

            //get vehicle type from user, and energy type
            string clientName;
            string clientPhoneNumber;
            VehicleGenerator.eVehicleType vehicleType;
            VehicleGenerator.eEnergyType vehicleEnergyType;

            getTypeFromUser<VehicleGenerator.eVehicleType>(out vehicleType, m_Garage.VehicleGenerator.SupportedVehicles, "vehicle");//getVehicleTypeFromClient();
            getTypeFromUser<VehicleGenerator.eEnergyType>(out vehicleEnergyType, m_Garage.VehicleGenerator.SupportedEnergySources, "vehicle's energy");//getEnergyTypeFromClient();
            getClientDetail(out clientName, "Please enter your name(max length is 20) without spaces:", isValidName);
            getClientDetail(out clientPhoneNumber, "some message", isValidePhoneNumber);
            m_Garage.AddVehicle(i_LicenseNumber, vehicleType, vehicleEnergyType, clientName, clientPhoneNumber);
        }

        private void getClientDetail(out string o_ClientDetail, String i_Message, validateFunctionInput i_ValidateInputOfClient)
        {

            bool valideInput = false;
            StringBuilder clientDetail = new StringBuilder();

            Console.WriteLine((i_Message));
            do
            {
                clientDetail.Clear();
                clientDetail.Append(Console.ReadLine());
                if (i_ValidateInputOfClient(clientDetail))
                {
                    valideInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid name, Please enter again.");
                }
            }
            while (!valideInput);

            o_ClientDetail = clientDetail.ToString();

        }

        private bool isValidLicenseNumber(StringBuilder i_ClientInput)
        {
            return i_ClientInput.Length == k_LicenseNumberLength && containOnlyDigits(i_ClientInput);
        }
        private bool isValidePhoneNumber(StringBuilder i_clientPhoneNumber)
        {
            return i_clientPhoneNumber.Length == 10 && containOnlyDigits(i_clientPhoneNumber);
        }

        private bool containOnlyDigits(StringBuilder i_clientPhoneNumber)
        {
            int index = 0;
            bool validInput = true;
            for (; index < i_clientPhoneNumber.Length && validInput; index++)
            {
                if (i_clientPhoneNumber[index] > '9' && i_clientPhoneNumber[index] < '0')
                {
                    validInput = false;
                }
            }
            return validInput;
        }

        private bool isValidName(StringBuilder i_ClientName)
        {
            bool validName = true;
            char charToCheck;

            if (i_ClientName.Length > Client.MaxNameLength)
            {
                validName = false;
            }

            for (int i = 0; i < i_ClientName.Length && validName; i++)
            {
                charToCheck = i_ClientName[i];
                if (charToCheck == ' ')
                {
                    validName = false;
                }
            }

            return validName;
        }
        private void getTypeFromUser<T>(out T o_Type, List<string> i_List, string i_TypeMessage)
        {
            bool validInput = false;
            int chosenType;

            Console.WriteLine(string.Format("Please Enter Your {0} type, press: ", i_TypeMessage));
            do
            {
                printAllSupportedProperties(i_List);
                validInput = int.TryParse(Console.ReadLine(), out chosenType);
                if (validInput)
                {
                    validInput = inputInRange(chosenType, i_List.Count);
                }

                if (!validInput)
                {
                    Console.WriteLine("Invalid input entered, please try again from the options below:");
                }

            }
            while (!validInput);

            o_Type = (T)(object)chosenType;
        }
        //private VehicleGenerator.eVehicleType getVehicleTypeFromClient()
        //{
        //    bool validInput = false;
        //    int chosenType;
        //    VehicleGenerator.eVehicleType Type = VehicleGenerator.eVehicleType.Car;
        //
        //    Console.WriteLine("Please Enter Your vehicle type, press: ");
        //    do
        //    {
        //        printAllSupportedProperties(m_Garage.VehicleGenerator.SupportedVehicles);
        //        validInput = int.TryParse(Console.ReadLine(), out chosenType);
        //        if (validInput)
        //        {
        //            validInput = inputInRange(chosenType, m_Garage.VehicleGenerator.SupportedVehicles.Count);
        //        }
        //
        //        if (!validInput)
        //        {
        //            Console.WriteLine("Invalid input entered, please try again from the options below:");
        //        }
        //
        //    }
        //    while (!validInput);
        //
        //    Type = (VehicleGenerator.eVehicleType)chosenType;
        //    return Type;
        //}
        //
        //private VehicleGenerator.eEnergyType getEnergyTypeFromClient()
        //{
        //    bool validInput = false;
        //    int chosenType;
        //    VehicleGenerator.eEnergyType Type = VehicleGenerator.eEnergyType.Fuel;
        //
        //    Console.WriteLine("Please Enter Your vehicle's Energy type, press: ");
        //    do
        //    {
        //        printAllSupportedProperties(m_Garage.VehicleGenerator.SupportedEnergySources);
        //        validInput = int.TryParse(Console.ReadLine(), out chosenType);
        //        if (validInput)
        //        {
        //            validInput = inputInRange(chosenType, m_Garage.VehicleGenerator.SupportedEnergySources.Count);
        //        }
        //
        //        if (!validInput)
        //        {
        //            Console.WriteLine("Invalid input entered, please try again from the options below:");
        //        }
        //
        //    }
        //    while (!validInput);
        //
        //    Type = (VehicleGenerator.eEnergyType)chosenType;
        //    return Type;
        //}

        private void printAllSupportedProperties(List<string> i_SupportedList)
        {
            int index = 1;

            foreach (string energyType in i_SupportedList)
            {
                Console.WriteLine(string.Format("{0}. {1}"), index, energyType);
                index++;
            }
        }

        private bool inputInRange(int i_Input, int i_SizeOfSupportedList)
        {
            return (i_Input >= 1 && i_Input <= i_SizeOfSupportedList);
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
                    throw new FormatException("Ivalid input, please choose 1 (for filter) or 2 (without filter) "); // exeption that the input is invalid
                }

            }
            while (!validInput);

        }

        private void displayLicensesNumbersWithFilter()
        {
            string filter = "";
            bool validInput = false;


            Console.WriteLine("Please Enter: ");
            Console.WriteLine("1. To display the vehicles in repair.");
            Console.WriteLine("2. To display the fixed vehicles.");
            Console.WriteLine("3. To display the paid of vehicles.");


            do
            {
                filter = Console.ReadLine();
                if (filter == "1")
                {
                    displayLicensesNumbersWithoutFilter();
                    validInput = true;
                }
                else if (filter == "2")
                {
                    displayLicensesNumbersWithFilter();
                    validInput = true;
                }
                else if (filter == "3")
                {
                    throw new FormatException("Ivalid input, please choose 1 (for filter) or 2 (without filter) "); // exeption that the input is invalid
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




