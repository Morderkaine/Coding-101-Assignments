using System;

namespace KeyIdentifier
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Title = "Key Identifier"; //Change the window title to display the name of the program.

			bool run = true; //Iniallize a variable that defines whether or not the program runs.
			while (run == true) //Run the program if the run variable is true.
			{
				Console.Write ("Press a key. "); //Prompt the user to press a key.
				int key = (int) Console.ReadKey ().Key; //Initialize a variable for the key identifier and store it there.
				Console.WriteLine ("\nThe Key's ID number is {0}", key); //Print the value of the key identifier.
				Console.Write ("Get another key? (y/n) "); //Ask the user if they would like to get the value for another key.
				key = (int) Console.ReadKey ().Key; //Get the user's answer and store it in the key variable.
				if (key == 89) //The user said yes.
				{
					Console.WriteLine ("\n"); //Insert a blank line between each succesive loop.

				}
				else //The user didn't say yes.
				{
					run = false; //Set the program to end.
				}
			}
		}
	}
}