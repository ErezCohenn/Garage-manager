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




        private Garage m_Garage;
        public delegate bool validateFunctionInput(StringBuilder i_Input);
        private readonly List<string> r_Actions = new List<string>() {"Enter your Vehicle Into our Garage.", "Display all vehicles license numbers."
            , "Change your vehicle's state.", "Fill the air in yout wheels to max.", "Fuel your vehicle.", "Charge your vehicle's battery."
            , "Display your vehicle's details.", "Exit." };

        public UserInterface()
        {
            m_Garage = new Garage();
        }

        private eClientChosenAction getClientChosenAction()
        {
            string chosenAction = "";
            int numberOfAction = 1;
            Console.WriteLine(string.Format("Hello, welcome to our garage, please choose an action from the list below:{0}"), Environment.NewLine);
            foreach (string action in r_Actions)
            {
                Console.WriteLine(string.Format("{0}. {1}", numberOfAction, action));
                numberOfAction++;
            }
            //check here in loop maybe until the input is correct.
            chosenAction = Console.ReadLine();
            return (eClientChosenAction)int.Parse(chosenAction);
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

            Console.WriteLine("Thank you for coming to our garage, goodbye.");
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

        private void displayVheicleDetails()
        {
            string licenseNumber;
            string licenseMessageToScreen = "Please enter the license number of your vehicle: ";
            getClientDetail(out licenseNumber, licenseMessageToScreen, isValidLicenseNumber);

            Console.WriteLine(m_Garage.GetVehicleInformation(licenseNumber));
        }

        private void chargeVehicle()
        {
            string licenseNumber;
            float amountOfEelectricity;
            string licenseMessageToScreen = "Please enter the license number of your vehicle: ";
            string elecreicityToFillMessageToScreen = "Please enter the amount of electricity to charge your vehicle with: ";

            getClientDetail(out licenseNumber, licenseMessageToScreen, isValidLicenseNumber);
            getAmountOfEnergyFromUser(out amountOfEelectricity, elecreicityToFillMessageToScreen);

            m_Garage.ChargeElectronicVehicle(licenseNumber, amountOfEelectricity);
        }

        private void fuelVehicle()
        {
            string licenseNumber;
            string licenseMessageToScreen = "Please enter the license number of your vehicle: ";
            string FuelTypeMessageToScreen = "Please enter the amount of fuel you wish to refuel with: ";
            FuelEnergy.eType fuelType;
            float amountOfFuel;

            getClientDetail(out licenseNumber, licenseMessageToScreen, isValidLicenseNumber);
            getTypeFromUser<FuelEnergy.eType>(out fuelType, FuelEnergy.FuelTypes, "Fuel");
            getAmountOfEnergyFromUser(out amountOfFuel, FuelTypeMessageToScreen);
            m_Garage.RefuelVehicle(licenseNumber, fuelType, amountOfFuel);
        }

        private void getAmountOfEnergyFromUser(out float o_AmountOfFuel, string i_EnergyTypeMessage)
        {
            bool validInput = false;
            string userInput = "";
            float inputedAmount = 0;

            Console.WriteLine(i_EnergyTypeMessage);
            while (!validInput)
            {
                userInput = Console.ReadLine();
                try
                {
                    validInput = float.TryParse(userInput, out inputedAmount);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please input float number");
                }
            }
            o_AmountOfFuel = inputedAmount;

        }

        private void fillAirToMax()
        {
            string licenseNumber;
            string messageToScreen = "Please enter the license number of your vehicle: ";

            getClientDetail(out licenseNumber, messageToScreen, isValidLicenseNumber);
            m_Garage.InflateWheelsAirPressureToMaximum(licenseNumber);
        }

        private void changeVehicleState()
        {
            string licenseNumber;
            string messageToScreen = "Please enter the license number of your vehicle: ";
            Garage.eVehicleStatus statusToChangeTo;
            getClientDetail(out licenseNumber, messageToScreen, isValidLicenseNumber);
            getTypeFromUser<Garage.eVehicleStatus>(out statusToChangeTo, m_Garage.StatusInGarage, "desired status");
            m_Garage.ChangeVehicleStatus(licenseNumber, statusToChangeTo);
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
            string nameMessageToScreen = "Please enter your name(max length is 20) without spaces:";
            string phoneNumberMessageToScreen = "Please enter your phone Number(10 straight digits):";
            VehicleGenerator.eVehicleType vehicleType;
            VehicleGenerator.eEnergyType vehicleEnergyType;

            getTypeFromUser<VehicleGenerator.eVehicleType>(out vehicleType, m_Garage.VehicleGenerator.SupportedVehicles, "vehicle");//getVehicleTypeFromClient();
            getTypeFromUser<VehicleGenerator.eEnergyType>(out vehicleEnergyType, m_Garage.VehicleGenerator.SupportedEnergySources, "vehicle's energy");//getEnergyTypeFromClient();
            getClientDetail(out clientName, nameMessageToScreen, isValidName);
            getClientDetail(out clientPhoneNumber, phoneNumberMessageToScreen, isValidePhoneNumber);
            m_Garage.AddVehicle(i_LicenseNumber, vehicleType, vehicleEnergyType, clientName, clientPhoneNumber);
            addExtraInformation(i_LicenseNumber);
        }

        private void addExtraInformation(string i_LicenseNumber)
        {
            Dictionary<string, string> extraDetailsToAdd = m_Garage.GetClient(i_LicenseNumber).Vehicle.GetVehicleDetails();
            bool validInput = false;


            foreach (KeyValuePair<string, string> details in extraDetailsToAdd)
            {
                Console.WriteLine(string.Format("Please enter {0}", details.Key));
                extraDetailsToAdd[details.Key] = Console.ReadLine();
                while (!validInput)
                {
                    try
                    {
                        //m_Garage.;
                        validInput = true;
                    }
                    catch ()
                    {
                        Console.WriteLine();//get as an argument
                    }



                }

            }
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
            return i_ClientInput.Length == Vehicle.LicenseNumberLength && containOnlyDigits(i_ClientInput);
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
            Console.WriteLine("1. Yes.");
            Console.WriteLine("2. No.");

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

        private void displayLicensesNumbersWithoutFilter()
        {
            bool vehicleInRepair = true;
            bool vehicleFixed = true;
            bool vehiclePaidUp = true;
            m_Garage.GetLicenseNumbersByFilter(vehicleInRepair, vehicleFixed, vehiclePaidUp);
        }

        private void displayLicensesNumbersWithFilter()
        {
            int i = 0;
            string filter = "";
            bool vehicleInRepair = false;
            bool vehicleFixed = false;
            bool vehiclePaidUp = false;
            bool[] statusFilter = new bool[3] { vehicleInRepair, vehicleFixed, vehiclePaidUp };

            for (; i < statusFilter.Length; i++)
            {
                Console.WriteLine(string.Format("Please Enter 1 to display by {0} status, else, enter any other key.", m_Garage.StatusInGarage[i]));
                filter = Console.ReadLine();
                if (filter == "1")
                {
                    statusFilter[i] = true;
                }
            }
            m_Garage.GetLicenseNumbersByFilter(vehicleInRepair, vehicleFixed, vehiclePaidUp);
        }
    }
}




