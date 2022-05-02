﻿using Ex03.GarageLogic;
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

        private Garage m_Garage;
        public delegate bool validateFunctionInput(StringBuilder i_Input);
        private readonly List<string> r_Actions;

        public UserInterface()
        {
            m_Garage = new Garage();
            r_Actions = new List<string>() {"Enter your Vehicle Into our Garage.", "Display all vehicles license numbers."
            , "Change your vehicle's state.", "Fill the air in yout wheels to max.", "Fuel your vehicle.", "Charge your vehicle's battery."
            , "Display your vehicle's details.", "Exit." };
        }

        private void getClientChosenAction(out eClientChosenAction o_UserInputAction)
        {
            int chosenAction;
            int numberOfAction = 1;
            bool validInput = false;

            Console.Clear();
            Console.WriteLine(string.Format("Hello client, welcome to our garage, please choose an action from the list below"));
            do
            {
                numberOfAction = 1;
                foreach (string action in r_Actions)
                {
                    Console.WriteLine(string.Format("{0}. {1}", numberOfAction, action));
                    numberOfAction++;
                }

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
                catch (ArgumentException argException) //todo
                {
                    Console.WriteLine(argException.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                }
                catch (ValueOutOfRangeException)
                {
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
            try
            {
                vehicleDetails = m_Garage.GetVehicleInformation(licenseNumber);
                Console.WriteLine(vehicleDetails);
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }

            printContinueMessage();
        }

        private void chargeVehicle()
        {
            string licenseNumber;
            float amountOfEelectricity;
            string licenseMessageToScreen = "Please enter the license number of your vehicle: ";
            string elecreicityToFillMessageToScreen = "Please enter the amount of electricity to charge your vehicle with: ";

            getClientDetail(out licenseNumber, licenseMessageToScreen, isValidLicenseNumber);
            getAmountOfEnergyFromUser(out amountOfEelectricity, elecreicityToFillMessageToScreen);
            try
            {
                m_Garage.ChargeElectronicVehicle(licenseNumber, amountOfEelectricity);
                Console.WriteLine("The vehicle is charged! your current battery condition in percent is: {0}", m_Garage.GetClient(licenseNumber).Vehicle.EnergySource.EnergyLeftInPercentage());
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

            printContinueMessage();
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
            try
            {
                m_Garage.RefuelVehicle(licenseNumber, fuelType, amountOfFuel);
                Console.WriteLine("The vehicle is refueled! your current fuel in your tank in percent is: {0}", m_Garage.GetClient(licenseNumber).Vehicle.EnergySource.EnergyLeftInPercentage());
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

            printContinueMessage();
        }

        private void printInvalidInputMessage()
        {
            Console.WriteLine("Invalid input inserted! Please try again");
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
            try
            {
                m_Garage.InflateWheelsAirPressureToMaximum(licenseNumber);
                Console.WriteLine("All vehicle's wheels have been inflated to the maximum air pressure: {0}", m_Garage.GetClient(licenseNumber).Vehicle.MaxAirPressureInTheWheels());
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }

            printContinueMessage();
        }

        private void changeVehicleState()
        {
            string licenseNumber;
            string messageToScreen = "Please enter the license number of your vehicle: ";
            Garage.eVehicleStatus statusToChangeTo;
            getClientDetail(out licenseNumber, messageToScreen, isValidLicenseNumber);
            getTypeFromUser<Garage.eVehicleStatus>(out statusToChangeTo, m_Garage.StatusInGarage, "desired status");
            try
            {
                m_Garage.ChangeVehicleStatus(licenseNumber, statusToChangeTo);
                Console.WriteLine("The new vehicle status has been successfully changed!");
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }

            printContinueMessage();
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
                Console.WriteLine(string.Format("Hello {0}, Your vehicle is already in the garage, so the vehicle status has been changed to In-Repair"), m_Garage.GetClient(licenseNumber).Name);
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
            VehicleGenerator.eEnergyType vehicleEnergyType;

            getTypeFromUser<VehicleGenerator.eVehicleType>(out vehicleType, m_Garage.VehicleGenerator.SupportedVehicles, "vehicle");//getVehicleTypeFromClient();
            getTypeFromUser<VehicleGenerator.eEnergyType>(out vehicleEnergyType, m_Garage.VehicleGenerator.SupportedEnergySources, "vehicle's energy");//getEnergyTypeFromClient();
            getClientDetail(out clientName, nameMessageToScreen, isValidName); //get owner vehicle name
            getClientDetail(out clientPhoneNumber, phoneNumberMessageToScreen, isValidePhoneNumber); //get owner vehicle phone number
            try
            {
                m_Garage.AddVehicle(i_LicenseNumber, vehicleType, vehicleEnergyType, clientName, clientPhoneNumber);
                addExtraInformation(i_LicenseNumber);
                Console.WriteLine("The vehicle entered to the garage successfully, thank you for choosing our garage");
            }
            catch (AggregateException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }

            printContinueMessage();
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
                if (i_clientPhoneNumber[i] > '9' && i_clientPhoneNumber[i] < '0')
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

            printContinueMessage();
        }

        private void displayLicensesNumbersWithoutFilter()
        {
            bool vehicleInRepair = true;
            bool vehicleFixed = true;
            bool vehiclePaidUp = true;
            string licensesNumberByFilter = null;

            Console.Clear();
            try
            {
                licensesNumberByFilter = m_Garage.GetLicenseNumbersByFilter(vehicleInRepair, vehicleFixed, vehiclePaidUp);
                Console.WriteLine(licensesNumberByFilter);
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }
        }

        private void displayLicensesNumbersWithFilter()
        {
            char filter = ' ';
            bool vehicleInRepair = false;
            bool vehicleFixed = false;
            bool vehiclePaidUp = false;
            bool[] statusFilter = new bool[3] { vehicleInRepair, vehicleFixed, vehiclePaidUp };
            string licensesNumberByFilter = null;

            Console.Clear();
            for (int i = 0; i < statusFilter.Length; i++)
            {
                Console.WriteLine(string.Format("Please Enter 1 to display license numbers by {0} status, else, enter any other key.", m_Garage.StatusInGarage[i]));
                filter = Console.ReadKey().KeyChar;
                if (filter == '1')
                {
                    statusFilter[i] = true;
                }
            }

            try
            {
                licensesNumberByFilter = m_Garage.GetLicenseNumbersByFilter(vehicleInRepair, vehicleFixed, vehiclePaidUp);
                Console.WriteLine(licensesNumberByFilter);
            }
            catch (ArgumentException argExcption)
            {
                Console.WriteLine(argExcption.Message);
            }
        }
    }
}




