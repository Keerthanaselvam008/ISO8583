﻿using ISO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Programs
{
    static void Main(string[] args)
    {
       Console.WriteLine("Enter Message Option: 1 -> SignOn, 2 -> SignOff, 3 -> BalanceInquiry, 4 -> CashWithdrawal, 5-> Emv Tags,6-> ARQC, Exit -> To Exit The Program");
                int msgRequired = 0;
                while (true)
        {
            string option = Console.ReadLine();
            if (option != "Exit")
            {
                if (int.TryParse(option, out msgRequired))
                {
                    Console.WriteLine(MessageFactory.ConstructMessage((RequiredMsg)msgRequired));
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter an integer.");
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
