using Serilog;
using SimplifiedSlotMachine.Domain;
using System;

namespace SimplifiedSlotMachine
{
    public class IOManager
    {
        public void ShowMessage(string message)
        {
            Console.Write(message);
        }

        public void ShowMessageLine(string message)
        {
            Console.WriteLine(message);
        }

        public double GetDeposit()
        {
            double balanceAmount;
            // Enter positive deposit as double
            do
            {
                string input = Console.ReadLine();
                if(!Double.TryParse(input, out balanceAmount) || balanceAmount <= 0)
                {
                    Log.Information(String.Format("Bad user input for balance: {0}", input));
                    Console.WriteLine("Bad input. Please try again:");
                }
                else
                {
                    // Convert to currency format
                    balanceAmount = Math.Round(balanceAmount, 2);
                }
            } while(balanceAmount <= 0);
            return balanceAmount;
        }

        public double GetStake(double balanceAmount)
        {
            double stakeAmount = 0.0;
            // Enter positive stake smaller than balance as double
            do
            {
                string input = Console.ReadLine();
                if(!Double.TryParse(input, out stakeAmount) || stakeAmount <= 0 || stakeAmount > balanceAmount)
                {
                    Log.Information(String.Format("Bad user input for stake: {0}", input));
                    Console.WriteLine("Bad input. Please try again:");
                }
                else
                {
                    // Convert to currency format
                    stakeAmount = Math.Round(stakeAmount, 2);
                }
            } while(stakeAmount <= 0 || stakeAmount > balanceAmount);
            return stakeAmount;
        }

        public void ShowSpinResultsTable(Symbol[][] resultsTable)
        {
            Console.WriteLine();
            for(int i = 0; i < ConfigManager.TableRows; i++)
            {
                for(int j = 0; j < ConfigManager.TableColumns; j++)
                {
                    Console.Write(resultsTable[i][j].Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
