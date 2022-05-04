using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using StringBuilder = System.Text.StringBuilder;

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

        private readonly Garage r_Garage;
        private readonly List<string> r_Actions;

        private delegate bool validateFunctionInput(StringBuilder i_Input);

        public UserInterface()
        {
            r_Garage = new Garage();
            r_Actions = new List<string>();
            r_Actions.Add("Enter your Vehicle Into our Garage.");
            r_Actions.Add("Display all vehicles license numbers.");
            r_Actions.Add("Change your vehicle's state.");
            r_Actions.Add("Fill the air in your wheels to max.");
            r_Actions.Add("Fuel your vehicle.");
            r_Actions.Add("Charge your vehicle's battery.");
            r_Actions.Add("Display your vehicle's details.");
            r_Actions.Add("Exit.");
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
                validInput = int.TryParse(Console.ReadLine(), out chosenAction) && inputInRange(chosenAction, 1, r_Actions.Count);
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
            Console.Clear();
            vehicleDetails = r_Garage.GetVehicleInformation(licenseNumber);
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
            r_Garage.ChargeElectronicVehicle(licenseNumber, amountOfEelectricity);
            Console.WriteLine("The vehicle is charged! your current battery condition in percent is: {0}", r_Garage.GetClient(licenseNumber).Vehicle.EnergySource.EnergyLeftInPercentage());
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
            r_Garage.RefuelVehicle(licenseNumber, fuelType, amountOfFuel);
            Console.WriteLine("The vehicle is refueled! your current fuel in your tank in percent is: {0}", r_Garage.GetClient(licenseNumber).Vehicle.EnergySource.EnergyLeftInPercentage());
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
            string userInput = string.Empty;
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
            r_Garage.InflateWheelsAirPressureToMaximum(licenseNumber);
            Console.WriteLine("All vehicle's wheels have been inflated to the maximum air pressure: {0}", r_Garage.GetClient(licenseNumber).Vehicle.SetMaxAirPressureForTheWheels());
        }

        private void changeVehicleState()
        {
            string licenseNumber;
            string messageToScreen = "Please enter the license number of your vehicle: ";
            Garage.eVehicleStatus statusToChangeTo;

            getClientDetail(out licenseNumber, messageToScreen, isValidLicenseNumber);
            getTypeFromUser<Garage.eVehicleStatus>(out statusToChangeTo, r_Garage.StatusInGarage, "desired status");
            r_Garage.ChangeVehicleStatus(licenseNumber, statusToChangeTo);
            Console.WriteLine("The new vehicle status has been successfully changed!");
        }

        private void enterVehicleIntoGarage()
        {
            string licenseNumber;
            string licenseNumberMessageToScreen = "Please enter the license number of your vehicle (Note: the length of the license number is exactly 7): ";

            Console.Clear();
            getClientDetail(out licenseNumber, licenseNumberMessageToScreen, isValidLicenseNumber);
            if (r_Garage.IsVehicleExists(licenseNumber))
            {
                r_Garage.ChangeVehicleStatus(licenseNumber, Garage.eVehicleStatus.InRepair);
                Console.WriteLine(string.Format("Hello {0}, Your vehicle is already in the garage, so the vehicle status has been changed to In-Repair", r_Garage.GetClient(licenseNumber).Name));
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

            getTypeFromUser<VehicleGenerator.eVehicleType>(out vehicleType, r_Garage.VehicleGenerator.SupportedVehicles, "vehicle"); ////getVehicleTypeFromClient();
            getClientDetail(out clientName, nameMessageToScreen, isValidName); ////get owner vehicle name
            getClientDetail(out clientPhoneNumber, phoneNumberMessageToScreen, isValidePhoneNumber); ////get owner vehicle phone number
            r_Garage.AddVehicle(i_LicenseNumber, vehicleType, clientName, clientPhoneNumber);
            addExtraInformation(i_LicenseNumber);
            Console.WriteLine(string.Format("The vehicle entered to the garage successfully, thank you for choosing our garage{0}", Environment.NewLine));
        }

        private void addExtraInformation(string i_LicenseNumber)
        {
            Dictionary<string, string> extraDetailsToAdd = r_Garage.GetClient(i_LicenseNumber).Vehicle.GetVehicleDetails();
            bool validInput = false;
            List<string> keys = new List<string>(extraDetailsToAdd.Keys);

            foreach (string keyDetail in keys)
            {
                Console.Clear();
                Console.WriteLine(extraDetailsToAdd[keyDetail]);
                validInput = false;
                do
                {
                    try
                    {
                        extraDetailsToAdd[keyDetail] = Console.ReadLine();
                        r_Garage.AddExtraDetailsToVehicle(i_LicenseNumber, new KeyValuePair<string, string>(keyDetail, extraDetailsToAdd[keyDetail]));
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
                    catch (NullReferenceException nullException)
                    {
                        Console.WriteLine(nullException.Message);
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
            return i_ClientName.Length <= Client.MaxNameLength && i_ClientName.Length != 0 && containOnlyLettrs(i_ClientName);
        }

        private bool containOnlyLettrs(StringBuilder i_ClientName)
        {
            bool validName = true;
            for (int i = 0; i < i_ClientName.Length && validName; i++)
            {
                if (!char.IsLetter(i_ClientName[i]))
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
                validInput = int.TryParse(Console.ReadLine(), out chosenType) && inputInRange(chosenType, 1, i_List.Count);
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

        private bool inputInRange(int i_Input, int i_MinSize, int i_MaxSize)
        {
            return i_Input >= i_MinSize && i_Input <= i_MaxSize;
        }

        private void displayLicensesNumbers()
        {
            bool validInput = false;
            string withFilter = string.Empty;

            Console.Clear();
            Console.WriteLine("Please enter 1 if you want to display the license numbers by filter, else enter 2:");
            Console.WriteLine("1. Yes.");
            Console.WriteLine("2. No.");
            do
            {
                withFilter = Console.ReadLine();

                if (withFilter == "1")
                {
                    displayLicensesNumbersWithFilter();
                    validInput = true;
                }
                else if (withFilter == "2")
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
                licensesNumberByFilter = r_Garage.GetLicenseNumbersByFilter(statusFilter);
                Console.WriteLine(licensesNumberByFilter);
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }
        }

        private void displayLicensesNumbersWithFilter()
        {
            int index = 0;
            Dictionary<Garage.eVehicleStatus, bool> statusFilter = new Dictionary<Garage.eVehicleStatus, bool> { { Garage.eVehicleStatus.InRepair, false }, { Garage.eVehicleStatus.Fixed, false }, { Garage.eVehicleStatus.PaidUp, false } };
            string filter = string.Empty;
            string licensesNumberByFilter = null;
            bool validInput = true;

            Console.Clear();
            foreach (Garage.eVehicleStatus key in Enum.GetValues(typeof(Garage.eVehicleStatus)))
            {
                Console.WriteLine(string.Format("Please Enter 1 to display license numbers by {0} status, else, enter 2.", r_Garage.StatusInGarage[index]));
                validInput = true;
                do
                {
                    filter = Console.ReadLine();
                    if (filter == "1")
                    {
                        statusFilter[key] = true;
                    }
                    else if (filter == "2")
                    {
                        statusFilter[key] = false;
                    }
                    else
                    {
                        validInput = false;
                        printInvalidInputMessage();
                    }
                }
                while (!validInput);

                index++;
            }

            Console.Clear();
            licensesNumberByFilter = r_Garage.GetLicenseNumbersByFilter(statusFilter);
            Console.WriteLine(licensesNumberByFilter);
        }
    }
}