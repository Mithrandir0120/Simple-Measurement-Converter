using System;

namespace SimpleMeasurementConverter
{
    /// <summary>
    /// Class Name:     MainClass
    /// Description:    This is a simple menu-driven program 
    ///                 which will allow the user to convert a subset of measurements, 
    ///                 e.g. from metres to inches, from metres to feet, from metres to yards, 
    ///                 from yards to centimetres and from yards to metres
    /// Auther:         Mithrandir He
    /// Stu No:         1622441019
    /// Date:           October 17, 2018
    /// </summary>
    class MainClass {

        // Set the conversion formulas
        const double metresToInches = 39.370079;
        const double metresToFeet = 3.280839895;
        const double metresToYards = 1.093613298;
        const double yardsToCentimetres = 91.44;
        const double yardsToMetres = 0.9144;

        // Set the maximum and minimum values that the program can calculate
        const double maxData = 100000000.0;
        const double minData = 0.0;

        /// <summary>
        /// Method Name:    WelcomeMessage
        /// Description:    Output the welcome message
        /// </summary>
        static void WelcomeMessage() {
            string message = "********************************************\n" +
                "Welcome to the Simple Measurement Converter!\n" +
                "********************************************\n\n\n";
            Console.Write(message);
        }// end WelcomeMessage

        /// <summary>
        /// Method Name:    MainMenu
        /// Description:    Show the main menu
        /// </summary>
        static void MainMenu() {
            string mainMenu = "MAIN MENU\n" +
                "***************************************\n" +
                "1: metric to imperial conversion\n" +
                "2: imperial to metric conversion\n" +
                "0: quit\n\n";
            Console.Write(mainMenu);
        }// end MainMenu

        /// <summary>
        /// Method Name:    SubMenuMetric
        /// Description:    Show the submenu of Metric to Imperial
        /// </summary>
        static void SubMenuMetric() {
            string subMenuMetric = "Convert meters to: \n" +
                "1: inches\n" +
                "2: feet\n" +
                "3: yards\n" +
                "0: return to main menu\n\n";
            Console.Write(subMenuMetric);
        }// end SubMenuMetric

        /// <summary>
        /// Method Name:    SubMenuImperial
        /// Description:    Show the submenu of Imperial to Metric
        /// </summary>
        static void SubMenuImperial() {
            string subMenuImperial = "Convert yards to; \n" +
                "1: cm\n" +
                "2: meters\n" +
                "0: return to main menu\n\n";
            Console.Write(subMenuImperial);
        }// end SubMenuImperial

        /// <summary>
        /// Method Name:    ExitMessage
        /// Description:    Output the exit message
        /// </summary>
        static void ExitMessage() {
            string exitMessage = "Thanks for using the Simple Measurement Converter\n" +
                "...So long, and thanks for the fish\n";
            Console.WriteLine(exitMessage);
            // Ask user to enter any key to exit
            Console.WriteLine("Enter any key to exit...");
            Console.ReadKey();
        }// end ExitMessage

        /// <summary>
        /// Method Name:    ReadOption
        /// Description:    Read the option typed by user, 
        ///                 and check the option right or not
        /// </summary>
        /// <returns>The right option typed by user</returns>
        /// <param name="minOption">Minimum option which user can type in</param>
        /// <param name="maxOption">Maximum option which user can type in</param>
        static int ReadOption(int minOption, int maxOption) {
            string choice;
            int option;
            bool okayChoice;
            // Read and check the option
            // If option is wrong, read the option again
            do {
                // Ask the user input the option
                Console.Write("Enter your choice: ");
                // Read the option
                choice = Console.ReadLine();
                // Check the option
                okayChoice = int.TryParse(choice, out option);
                // If option is wrong, output the error message
                if (!okayChoice || option < minOption || option > maxOption) {
                    Console.WriteLine("You did not enter a correct option.");
                    Console.WriteLine("Please try again!\n");
                    okayChoice = false;
                }// end IF
            } while (!okayChoice);
            // Display user's option
            Console.WriteLine("\nUser entered {0}\n", option);

            return option;
        }// end ReadOption

        /// <summary>
        /// Method Name:    ReadData
        /// Description:    Read the value typed by user, 
        ///                 and check the value right or not
        /// </summary>
        /// <returns>The right value typed by user</returns>
        static double ReadData() { 
            string choice;
            double data;
            bool okayChoice;
            // Read and check the value
            // If value is wrong, read the value again
            do {
                // Ask the user to input the value
                Console.Write("Enter the value: ");
                // Read the value
                choice = Console.ReadLine();
                // Check the value
                okayChoice = double.TryParse(choice, out data);
                // If value is wrong, output the error message
                if (!okayChoice || data < minData || data > maxData) {
                    Console.WriteLine("Input must be a positive number.");
                    Console.WriteLine("Please try again!\n");
                    okayChoice = false;
                }// end IF
            } while (!okayChoice);

            return data;
        }// end ReadData

        /// <summary>
        /// Method Name:    Calculator
        /// Description:    Calculate the value by formul, 
        ///                 and store the result in a binary array
        /// </summary>
        /// <returns>The result of conversion stored in a binary array</returns>
        /// <param name="data">The value typed by user</param>
        static double[,] Calculator(double data) {
            // Declare a binary array to store the results of conversion
            double[,] resultArray = new double[2,3];
            // resultArray[mainOption - 1, subOption - 1]
            // from metres to inches
            resultArray[0, 0] = data * metresToInches;
            // from metres to feet
            resultArray[0, 1] = data * metresToFeet;
            // from metres to yards
            resultArray[0, 2] = data * metresToYards;
            // from yards to centimetres
            resultArray[1, 0] = data * yardsToCentimetres;
            // from yards to metres
            resultArray[1, 1] = data * yardsToMetres;

            return resultArray;
        }// end Calculator

        /// <summary>
        /// Method Name:    OutputResult
        /// Description:    Output the result of conversion
        /// </summary>
        /// <param name="mainOption">User's option in the main menu</param>
        /// <param name="subOption">User's option in the sub menu</param>
        /// <param name="data">The value typed by user</param>
        /// <param name="resultArray">The result of conversion stored in a binary array</param>
        static void OutputResult(int mainOption, int subOption, double data, double[,] resultArray) {
            // Input unit
            string[] inputArray = new string[2];
            inputArray[0] = "metres/s";
            inputArray[1] = "yards/s";

            // Output unit
            string[,] stringArray = new string[2,4];
            stringArray[0, 0] = "inches/s";
            stringArray[0, 1] = "feet/s";
            stringArray[0, 2] = "yards/s";
            stringArray[1, 0] = "centimetres/s";
            stringArray[1, 1] = "metres/s";

            // Output the result
            Console.WriteLine("RESULT: {0:F2} " + inputArray[mainOption - 1] + 
                              " is equivalent to {1:F2} " + stringArray[mainOption - 1, subOption - 1], 
                              data, resultArray[mainOption - 1, subOption - 1]);
            Console.WriteLine();
        }// end OutputResult

        /// <summary>
        /// Method Name:    Display
        /// Description:    Display a main menu and control the activities 
        ///                 by choosing different options
        /// </summary>
        static void Display() {
            MainMenu();
            //Get option from user
            int mainOption = ReadOption(0, 2);

            switch (mainOption) {
                //If option is m -> i, mainOption == 1
                case 1:
                    SubMetric();
                    break;
                //If option is i -> m, mainOption == 2
                case 2:
                    SubImperial();
                    break;
                //Otherwise display exit message, mainOption == 0
                case 0:
                    ExitMessage();
                    break;
            }// end Switch
        }//end Display

        /// <summary>
        /// Method Name:    SubMetric
        /// Description:    Display the submenu of m -> i, 
        ///                 and control the conversion and output by choosing different options
        /// </summary>
        static void SubMetric() {
            // mainOption == 1
            // Display the submenu of m -> i
            SubMenuMetric();
            double data;
            int subOption = ReadOption(0, 3);
            // When user choose continue
            if (subOption != 0) {
                data = ReadData();
                switch (subOption) {
                    // from metres to inches
                    case 1:
                        OutputResult(1, 1, data, Calculator(data));
                        break;
                    // from metres to feet
                    case 2:
                        OutputResult(1, 2, data, Calculator(data));
                        break;
                    // from metres to yards
                    case 3:
                        OutputResult(1, 3, data, Calculator(data));
                        break;
                }// end Switch
            }// end if
            // Go back to the main menu 
            Display();
        }// end SubMetric

        /// <summary>
        /// Method Name:    SubImperial
        /// Description:    Display the submenu of i -> m, 
        ///                 and control the conversion and output by choosing different options
        /// </summary>
        static void SubImperial() {
            // mainOption == 2
            // Dispaly the submenu of i -> m
            SubMenuImperial();
            double data;
            int subOption = ReadOption(0, 2);
            // When user choose continue
            if (subOption != 0) {
                data = ReadData();
                switch (subOption) {
                    // from yards to centimetres
                    case 1:
                        OutputResult(2, 1, data, Calculator(data));
                        break;
                    // from yards to metres
                    case 2:
                        OutputResult(2, 2, data, Calculator(data));
                        break;
                }
            }
            // Go back to the main menu
            Display();
        }

        /// <summary>
        /// Method Name:    Main
        /// Description:    The entry point of the program, 
        ///                 where the program control starts and ends.
        /// </summary>
        public static void Main() {
            //Display welcome message
            WelcomeMessage();
            //Display main menu
            Display();
            //Exit the program
        }// end Main
    }
}
