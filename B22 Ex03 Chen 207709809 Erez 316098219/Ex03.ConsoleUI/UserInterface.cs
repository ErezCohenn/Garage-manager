using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using StringBuilder = System.Text.StringBuilder;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        /******************************************************/
        private void createTestVehicles()
        {
            //************First fuel car**************//
            m_Garage.AddVehicle("1234567", VehicleGenerator.eVehicleType.FuelCar, "Tikva", "1111111111");
            Dictionary<string, string> extraDetails = m_Garage.GetClient("1234567").Vehicle.GetVehicleDetails();
            extraDetails["Current Amount Of Energy"] = "10";
            extraDetails["Manufacturer wheel Name"] = "2KOOL4SKOOL";
            extraDetails["Current Air Pressure of the wheel"] = "15";
            extraDetails["ModelName"] = "Ferari x-325";
            extraDetails["Color (Red/White/Green/Blue/)"] = "Red";
            extraDetails["Doors (Two/Three/Four/Five/)"] = "Four";

            foreach (KeyValuePair<string, string> extra in extraDetails)
            {
                m_Garage.AddExtraDetailsToVehicle("1234567", extra);
            }

            extraDetails.Clear();

            //************Second electric car**************//
            m_Garage.AddVehicle("2345678", VehicleGenerator.eVehicleType.ElectricCar, "Menash", "2222222222");
            extraDetails = m_Garage.GetClient("2345678").Vehicle.GetVehicleDetails();
            extraDetails["Current Amount Of Energy"] = "3";
            extraDetails["Manufacturer wheel Name"] = "2KOOL5SKOOL";
            extraDetails["Current Air Pressure of the wheel"] = "15";
            extraDetails["ModelName"] = "Mitsubishi-Attrage";
            extraDetails["Color (Red/White/Green/Blue/)"] = "White";
            extraDetails["Doors (Two/Three/Four/Five/)"] = "Two";

            foreach (KeyValuePair<string, string> extra in extraDetails)
            {
                m_Garage.AddExtraDetailsToVehicle("2345678", extra);
            }

            extraDetails.Clear();

            //************third fuel motorcycle**************//
            m_Garage.AddVehicle("3456789", VehicleGenerator.eVehicleType.FuelMotorcycle, "Nahum", "3333333333");
            extraDetails = m_Garage.GetClient("3456789").Vehicle.GetVehicleDetails();
            extraDetails["Current Amount Of Energy"] = "1";
            extraDetails["Manufacturer wheel Name"] = "2KOOL6SKOOL";
            extraDetails["Current Air Pressure of the wheel"] = "2";
            extraDetails["ModelName"] = "Honda-NemesisXG";
            extraDetails["Motorcylce License Type (A/A1/B1/BB/)"] = "A";
            extraDetails["Motorcycle Engine Capacity"] = "2";

            foreach (KeyValuePair<string, string> extra in extraDetails)
            {
                m_Garage.AddExtraDetailsToVehicle("3456789", extra);
            }

            extraDetails.Clear();

            //************fourth electric motorcycle**************//
            m_Garage.AddVehicle("3456743", VehicleGenerator.eVehicleType.FuelMotorcycle, "AlsoABigMoma", "4444444444");
            extraDetails = m_Garage.GetClient("3456743").Vehicle.GetVehicleDetails();
            extraDetails["Current Amount Of Energy"] = "1.1";
            extraDetails["Manufacturer wheel Name"] = "2KOOL7SKOOL";
            extraDetails["Current Air Pressure of the wheel"] = "1.1";
            extraDetails["ModelName"] = "BigMoma";
            extraDetails["Motorcylce License Type (A/A1/B1/BB/)"] = "A1";
            extraDetails["Motorcycle Engine Capacity"] = "5";

            foreach (KeyValuePair<string, string> extra in extraDetails)
            {
                m_Garage.AddExtraDetailsToVehicle("3456743", extra);
            }

            Dictionary<string, string> extraDetails2;

            //************fifth fuel motorcycle**************//
            m_Garage.AddVehicle("5678123", VehicleGenerator.eVehicleType.FuelTruck, "chen", "5555555555");
            extraDetails2 = m_Garage.GetClient("5678123").Vehicle.GetVehicleDetails();
            extraDetails2["Current Amount Of Energy"] = "5.3";
            extraDetails2["Manufacturer wheel Name"] = "2KOOL8SKOOL";
            extraDetails2["Current Air Pressure of the wheel"] = "15";
            extraDetails2["ModelName"] = "Toyota";
            extraDetails2["CargoCapcity"] = "45";
            extraDetails2["CanCarryRefrigerated"] = "True";

            foreach (KeyValuePair<string, string> extra in extraDetails2)
            {
                m_Garage.AddExtraDetailsToVehicle("5678123", extra);
            }

        }

        /******************************************************/

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
        private readonly List<string> r_Actions;

        public UserInterface()
        {
            m_Garage = new Garage();
            r_Actions = new List<string>() {"Enter your Vehicle Into our Garage.", "Display all vehicles license numbers."
            , "Change your vehicle's state.", "Fill the air in your wheels to max.", "Fuel your vehicle.", "Charge your vehicle's battery."
            , "Display your vehicle's details.", "Exit." };
        }

        private void getClientChosenAction(out eClientChosenAction o_UserInputAction)
        {
            int chosenAction;
            int numberOfAction = 1;
            bool validInput = false;

            Console.Clear();
            Console.WriteLine("==================================================================================");
            Console.WriteLine("Hello client, welcome to our garage, please choose an action from the list below:");
            Console.WriteLine("==================================================================================");
            do
            {
                numberOfAction = 1;
                foreach (string action in r_Actions)
                {
                    Console.WriteLine(string.Format("{0}. {1}", numberOfAction, action));
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    numberOfAction++;
                }

                Console.WriteLine("==================================================================================");
                validInput = int.TryParse(Console.ReadLine(), out chosenAction) && inputInRange(chosenAction, r_Actions.Count);
                if (!validInput)
                {
                    Console.Clear();
                    printInvalidInputMessage();
                }
            }
            while (!validInput);

            o_UserInputAction = (eClientChosenAction)chosenAction;
        }

        public void GarageIsOpen()
        {
            eClientChosenAction action;
            createTestVehicles();///delete!!!!!!!!!!!!!!
            do
            {
                getClientChosenAction(out action);
                try
                {
                    if (action != eClientChosenAction.Exit)
                    {
                        handleClientAction(action);
                    }
                }
                catch (ArgumentException argExcption)
                {
                    Console.WriteLine(argExcption.Message);
                }
                catch (ValueOutOfRangeException outOfRangeExcption)
                {
                    Console.WriteLine(outOfRangeExcption.Message);
                }
                catch (InvalidCastException castExcption)
                {
                    Console.WriteLine(castExcption.Message);
                }

                if (action != eClientChosenAction.Exit)
                {
                    printContinueMessage();
                }
            }
            while (action != eClientChosenAction.Exit);

            Console.WriteLine("Thank you for coming to our garage, goodbye.");
            Console.ReadKey();
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
                reFuelVehicle();
            }
            else if (i_Action == eClientChosenAction.ChargeVehicle)
            {
                chargeVehicle();
            }
            else if (i_Action == eClientChosenAction.DisplayVheicleDetails)
            {
                displayVehicleDetails();
            }
        }

        private void displayVehicleDetails()
        {
            string licenseNumber;
            string licenseMessageToScreen = "Please enter the license number of your vehicle: ";
            string vehicleDetails = null;

            getClientDetail(out licenseNumber, licenseMessageToScreen, isValidLicenseNumber);
            vehicleDetails = m_Garage.GetVehicleInformation(licenseNumber);
            Console.WriteLine(vehicleDetails);
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
            Console.WriteLine("The vehicle is charged! your current battery condition in percent is: {0}", m_Garage.GetClient(licenseNumber).Vehicle.EnergySource.EnergyLeftInPercentage());
        }

        private void reFuelVehicle()
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
            Console.WriteLine("The vehicle is refueled! your current fuel in your tank in percent is: {0}", m_Garage.GetClient(licenseNumber).Vehicle.EnergySource.EnergyLeftInPercentage());
        }

        private void printInvalidInputMessage()
        {
            Console.WriteLine("Invalid input inserted! Please try again.");
        }

        private void printContinueMessage()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void getAmountOfEnergyFromUser(out float o_AmountOfFuel, string i_EnergyTypeMessage)
        {
            bool validInput = false;
            string userInput = "";
            float inputedAmount = 0;

            Console.WriteLine(i_EnergyTypeMessage);
            do
            {
                userInput = Console.ReadLine();
                validInput = float.TryParse(userInput, out inputedAmount);
                if (!validInput)
                {
                    printInvalidInputMessage();
                }

            }
            while (!validInput);

            o_AmountOfFuel = inputedAmount;
        }

        private void fillAirToMax()
        {
            string licenseNumber;
            string messageToScreen = "Please enter the license number of your vehicle: ";

            getClientDetail(out licenseNumber, messageToScreen, isValidLicenseNumber);
            m_Garage.InflateWheelsAirPressureToMaximum(licenseNumber);
            Console.WriteLine("All vehicle's wheels have been inflated to the maximum air pressure: {0}", m_Garage.GetClient(licenseNumber).Vehicle.MaxAirPressureInTheWheels());
        }

        private void changeVehicleState()
        {
            string licenseNumber;
            string messageToScreen = "Please enter the license number of your vehicle: ";
            Garage.eVehicleStatus statusToChangeTo;

            getClientDetail(out licenseNumber, messageToScreen, isValidLicenseNumber);
            getTypeFromUser<Garage.eVehicleStatus>(out statusToChangeTo, m_Garage.StatusInGarage, "desired status");
            m_Garage.ChangeVehicleStatus(licenseNumber, statusToChangeTo);
            Console.WriteLine("The new vehicle status has been successfully changed!");
        }

        private void enterVehicleIntoGarage()
        {
            string licenseNumber = "";

            Console.Clear();
            Console.WriteLine("Please enter the license number of your vehicle (Note: the length of the license number is exactly 7): ");
            licenseNumber = Console.ReadLine();
            if (m_Garage.IsVehicleExists(licenseNumber))
            {
                m_Garage.ChangeVehicleStatus(licenseNumber, Garage.eVehicleStatus.InRepair);
                Console.WriteLine(string.Format("Hello {0}, Your vehicle is already in the garage, so the vehicle status has been changed to In-Repair", m_Garage.GetClient(licenseNumber).Name));
            }
            else
            {
                enterNewVehicle(licenseNumber);
            }
        }

        private void enterNewVehicle(string i_LicenseNumber)
        {
            string clientName;
            string clientPhoneNumber;
            string nameMessageToScreen = "Please enter your name without spaces (Note: the max name length is 20):";
            string phoneNumberMessageToScreen = "Please enter your phone Number(Note: A phone number contains 10 digits exactly):";
            VehicleGenerator.eVehicleType vehicleType;

            getTypeFromUser<VehicleGenerator.eVehicleType>(out vehicleType, m_Garage.VehicleGenerator.SupportedVehicles, "vehicle");//getVehicleTypeFromClient();
            getClientDetail(out clientName, nameMessageToScreen, isValidName); //get owner vehicle name
            getClientDetail(out clientPhoneNumber, phoneNumberMessageToScreen, isValidePhoneNumber); //get owner vehicle phone number
            m_Garage.AddVehicle(i_LicenseNumber, vehicleType, clientName, clientPhoneNumber);
            addExtraInformation(i_LicenseNumber);
            Console.WriteLine("The vehicle entered to the garage successfully, thank you for choosing our garage");
        }

        private void addExtraInformation(string i_LicenseNumber)
        {
            Dictionary<string, string> extraDetailsToAdd = m_Garage.GetClient(i_LicenseNumber).Vehicle.GetVehicleDetails();
            List<string> keys = new List<string>(extraDetailsToAdd.Keys);
            bool validInput = false;

            Console.Clear();
            foreach (string key in keys)
            {
                Console.WriteLine(string.Format("Please enter {0}:", key));
                validInput = false;
                do
                {
                    try
                    {
                        extraDetailsToAdd[key] = Console.ReadLine();
                        m_Garage.AddExtraDetailsToVehicle(i_LicenseNumber, new KeyValuePair<string, string>(key, extraDetailsToAdd[key]));
                        validInput = true;
                    }
                    catch (FormatException exceptionThrown)
                    {
                        Console.WriteLine(exceptionThrown.Message);
                    }
                    catch (ArgumentException exceptionThrown)
                    {
                        Console.WriteLine(exceptionThrown.Message);
                    }
                    catch (ValueOutOfRangeException exceptionThrown)
                    {
                        Console.WriteLine(exceptionThrown.Message);
                    }
                }
                while (!validInput);
            }
        }

        private void getClientDetail(out string o_ClientDetail, string i_Message, validateFunctionInput i_ValidateInputOfClient)
        {
            bool valideInput = false;
            StringBuilder clientDetail = new StringBuilder();

            Console.Clear();
            Console.WriteLine(i_Message);
            do
            {
                clientDetail.Clear();
                clientDetail.Append(Console.ReadLine());
                valideInput = i_ValidateInputOfClient(clientDetail);
                if (!valideInput)
                {
                    printInvalidInputMessage();
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
            bool validInput = true;

            for (int i = 0; i < i_clientPhoneNumber.Length && validInput; i++)
            {
                if (i_clientPhoneNumber[i] > '9' || i_clientPhoneNumber[i] < '0')
                {
                    validInput = false;
                    break;
                }
            }

            return validInput;
        }

        private bool isValidName(StringBuilder i_ClientName)
        {
            bool validName = true;
            char charToCheck = ' ';

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

            Console.Clear();
            Console.WriteLine(string.Format("Please Enter Your {0} type: ", i_TypeMessage));
            do
            {
                printAllSupportedProperties(i_List);
                validInput = int.TryParse(Console.ReadLine(), out chosenType) && inputInRange(chosenType, i_List.Count);
                if (!validInput)
                {
                    printInvalidInputMessage();
                }
            }
            while (!validInput);

            o_Type = (T)(object)chosenType;
        }

        private void printAllSupportedProperties(List<string> i_SupportedList)
        {
            int index = 1;

            foreach (string energyType in i_SupportedList)
            {
                Console.WriteLine(string.Format("{0}. {1}", index, energyType));
                index++;
            }
        }

        private bool inputInRange(int i_Input, int i_SizeOfSupportedList)
        {
            return i_Input >= 1 && i_Input <= i_SizeOfSupportedList;
        }

        private void displayLicensesNumbers()
        {
            bool validInput = false;
            char withFilter = ' ';

            Console.Clear();
            Console.WriteLine("Please press 1 if you want to display the license numbers by filter, else press 2:");
            Console.WriteLine("1. Yes.");
            Console.WriteLine("2. No.");
            do
            {
                withFilter = Console.ReadKey().KeyChar;
                if (withFilter == '1')
                {
                    displayLicensesNumbersWithFilter();
                    validInput = true;
                }
                else if (withFilter == '2')
                {
                    displayLicensesNumbersWithoutFilter();
                    validInput = true;
                }
                else
                {
                    printInvalidInputMessage();
                }
            }
            while (!validInput);
        }

        private void displayLicensesNumbersWithoutFilter()
        {
            string licensesNumberByFilter = null;
            Dictionary<Garage.eVehicleStatus, bool> statusFilter = new Dictionary<Garage.eVehicleStatus, bool> { { Garage.eVehicleStatus.InRepair, true }, { Garage.eVehicleStatus.Fixed, true }, { Garage.eVehicleStatus.PaidUp, true } };

            Console.Clear();
            try
            {
                licensesNumberByFilter = m_Garage.GetLicenseNumbersByFilter(statusFilter);
                Console.WriteLine(licensesNumberByFilter);
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }
        }

        private void displayLicensesNumbersWithFilter()
        {
            int i = 0;
            Dictionary<Garage.eVehicleStatus, bool> statusFilter = new Dictionary<Garage.eVehicleStatus, bool> { { Garage.eVehicleStatus.InRepair, false }, { Garage.eVehicleStatus.Fixed, false }, { Garage.eVehicleStatus.PaidUp, false } };
            char filter = ' ';
            string licensesNumberByFilter = null;

            Console.Clear();
            foreach (Garage.eVehicleStatus key in Enum.GetValues(typeof(Garage.eVehicleStatus)))
            {
                Console.WriteLine(string.Format("Please Enter 1 to display license numbers by {0} status, else, enter any other key.", m_Garage.StatusInGarage[i]));
                filter = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (filter == '1')
                {
                    statusFilter[key] = true;
                }
                i++;
            }

            Console.Clear();
            licensesNumberByFilter = m_Garage.GetLicenseNumbersByFilter(statusFilter);
            Console.WriteLine(licensesNumberByFilter);
        }
    }
}