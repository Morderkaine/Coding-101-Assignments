/***************************************************************************************************************
*
* Coding 101
* On The TWiT Network ( www.twit.tv )
*
* 101 Coding Example 5
* Description: Build a menu system using conditional If statments, methods\functions, and the console.
*
* Remark(s): BTW - This section, with lots of *'s, is called a comment section.
*
* Assignment: Add Some more menu items! Maybe try adding some more functions that do things!
*
* @LouMM, @PadreSJ, @Snubs
* 
* Changes made to orginal ep.005 code:
* 	-Changed the menu to assign numbers instead of letters to the methods.
* 	-Re-ordered the menu and methods.
* 	-Added a method to display an error message for invalid user inputs.
* 	-Changed the menu to display an error message for invalid selections rather than looping.
* 	-Added calls to error message for other methods where in invalid input was possible.
* 	-Added a menu option to quit the program.
* 	-Added a menu option that calls a method to display key ID values.
* 	-Added a method that displays key ID values.
* 	-Changed all methods to clear the console before running.
* 	-Changed all methods to pause and wait for the user to press a key before returning to menu.
* 	-Changed title from "Example 5" to "Assignment 5"
* 	-Commented new code and edited comments on existing code.
****************************************************************************************************************/
using System;

namespace TWiT.Tv.Coding101

{
	class Ep005
	{
		private static void Main(string[] args)
		{
			int selection = 0;
			string userName = Environment.UserName;

			while (true) //Keeps looping since this is always true.
			{
				PrintMenu(userName);
				selection = (int) Console.ReadKey().Key;
				Console.WriteLine();

				if (selection == 49 || selection == 97) //1 selected
				{
					SayHello(userName); //Call the method to say hello to the user, passing it the UserName variable.
				}
				else if (selection == 50 || selection == 98) //2 selected
				{
					ConvertIntToBinary(); //Call the method to convert a number into binary.
				}
				else if (selection == 51 || selection == 99) //3 selected
				{
					RepeatWord(); //Call the method to repeat a word.
				}
				else if (selection == 52 || selection == 100) //4 selected
				{
					GetKeyValue(); //Call the method to display key identifier numbers.
				}
				else if (selection == 53 || selection == 101) //5 selected
				{
					break; //Breaks the loop so it doesn't go forever, and stops the program.
				}
				else
				{
					ErrorMessage(); //Call the method to display an error message for an invalid input.
				}
				Console.WriteLine(Environment.NewLine);
			}
		}

		/// <summary>
		/// This is a method with no return value, but takes a person's name or username as a parameter.
		/// </summary>
		/// <param name="name">Name of UserName of a person.</param>
		static void PrintMenu(string name)
		{
			Console.Title = "TwiT.Tv Coding 101 - Assigmnet 5"; //Set the title of the console window.

			Console.Clear(); //Clears the pervious information from the console window so the method starts with a blank screen.

			Console.WriteLine("*** Welcome, {0}, to Coding 101! ***", name); //Print a welcome message using a personalized name.
			Console.WriteLine("Please select a menu item.");
			Console.WriteLine();
			Console.WriteLine("1) Say Hello");
			Console.WriteLine("2) Convert a number to binary");
			Console.WriteLine("3) Repeat a word");
			Console.WriteLine("4) Get identifier value of a key");
			Console.WriteLine("5) Quit");
			Console.WriteLine();
		}
			
		/// <summary>
		/// Method that says hello to a user using a name parameter.
		/// </summary>
		/// <param name="name">The name of the user to say hello to.</param>
		static void SayHello(string name)
		{
			Console.Clear(); //Clears the pervious information from the console window so the method starts with a blank screen.

			Console.ForegroundColor = ConsoleColor.Cyan; //Changed the color of the text.
			Console.WriteLine("Hi {0}!", name); //Say Hello to the user.
			Console.ResetColor(); //Reset the console color.
			Console.WriteLine("\nPress any key to return to menu."); //Pause the program and wait for the user to press a key.
			Console.ReadKey(); //Return to the menu.
		}

		/// <summary>
		/// Takes a number and converts it to binary
		/// </summary>
		/// <param name="number">the number entered</param>
		/// <returns>returns a binary number as a string for displaying to users</returns>
		static void ConvertIntToBinary()
		{
			Console.Clear(); //Clears the pervious information from the console window so the method starts with a blank screen.

			//Ask the user to enter a binary number:
			Console.Write("Please Enter a Whole Number (example: 240): ");


			//This is where we read what binary number the user typed and hit <enter>
			//We store it in this fancy string variable for use later.
			int numberEntered = 0;
			if (int.TryParse(Console.ReadLine(), out numberEntered))
			{
				int bits = (sizeof (int)*8); //32bits
				char[] result = new char[bits]; //Array to hold the binary numbers http://msdn.microsoft.com/en-us/library/aa288453(v=vs.71).aspx


				while (bits > 0)
				{
					bits = bits - 1;
					int remainder = numberEntered % 2;
					//% called mod or modulo which computes the remainder after dividing http://msdn.microsoft.com/en-us/library/0w4e0fzs.aspx


					if (remainder == 1) //If remainder is 1, store it as 1
					{
						result[bits] = '1';
					}
					else
					{
						result[bits] = '0'; //Otherwise store it as 0
					}

					numberEntered = numberEntered / 2; //Take the original number, divide it by 2
				}

				Console.WriteLine("Binary Number: {0}", new String(result).Trim());
				Console.WriteLine("\nPress any key to return to menu."); //Pause the program and wait for the user to press a key.
				Console.ReadKey(); //Return to the menu.
			}
			else
			{
				ErrorMessage(); //Call the method to display an error message for an invalid input.
			}
		}

		/// <summary>
		/// Method that asks a user for a word to repeat.
		/// </summary>
		static void RepeatWord()
		{
			Console.Clear(); //Clears the pervious information from the console window so the method starts with a blank screen.

			Console.Write("What word do you want to repeat?: ");
			string textToRepeat = Console.ReadLine();

			int repeatNumber = 0;
			Console.Write("\nHow many times would you like to repeat?: ");
			if(int.TryParse( Console.ReadLine(), out repeatNumber))
			{
				int count = 1;
				//Initializer moved to outer scope, or intialized outside the loop for use later to display the count to the user.
				for (; count <= repeatNumber; count++)
				{
					//Write the text out with a space in between using {composite formatting} which is the 0 place holder that is replaced with the text.
					//http://msdn.microsoft.com/en-us/library/txafckwd(v=vs.110).aspx
					Console.WriteLine("{0}", textToRepeat);
				}
				Console.WriteLine("\nPress any key to return to menu."); //Pause the program and wait for the user to press a key.
				Console.ReadKey(); //Return to the menu.
			}
			else
			{
				ErrorMessage(); //Call the method to display an error message for an invalid input.
			}
		}

		/// <summary>
		/// Method that prints to screen the value of the key identifier for any key the user presses.
		/// </summary>
		static void GetKeyValue()
		{
			Console.Clear(); //Clears the pervious information from the console window so the method starts with a blank screen.

			bool run = true; //Initialise a variable that determines whether or not the method runs.
			while (run == true) //Loop the method while the run variable is true.
			{
				Console.Write("Press a key. "); //Ask the user to press a key.
				int key = (int) Console.ReadKey().Key; //Read the key the user pressed and store it's ID number in a new variable called key.
				Console.Write("\nThe key ID value is {0}.", key); //Print the ID value of the key the user pressed.
				Console.Write("\nWould you like to get the value for another key? (y/n) "); //Ask the user if they'd like to get the value of another key.
				key = (int) Console.ReadKey().Key; //Store the user's answer in the key variable.
				if (key == 89) //User pressed y.
				{
					Console.WriteLine ("\n"); //Insert a blank line between successive runs of the loop.
				}
				else
				{
					run = false;
					Console.Write("\nPress any key to return to menu."); //Pause the program and wait for the user to press a key.
					Console.ReadKey(); //Return to the menu.
				}
			}
		}

		/// <summary>
		/// Method to display an error message whenever the user inputs an invalid response.
		/// </summary>
		static void ErrorMessage()
		{
			Console.Clear(); //Clears the pervious information from the console window so the method starts with a blank screen.

			Console.ForegroundColor = ConsoleColor.Red; //Change the text colour to red.
			Console.WriteLine("Invalid Input!\nPlease try again."); //Print the error message.
			Console.ResetColor(); //Reset text colour.
			Console.Write("Press any key to return to menu."); //Pause the program and wait for the user to press a key.
			Console.ReadKey(); //Return to the menu.
		}
	}
}