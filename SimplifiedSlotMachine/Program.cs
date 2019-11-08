using Serilog;
using SimplifiedSlotMachine.Domain;
using System;

namespace SimplifiedSlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(ConfigManager.LoggerPath, rollingInterval: RollingInterval.Month)
                .CreateLogger();

            IOManager iOManager = new IOManager();
            iOManager.ShowMessageLine("Please deposit money you would like to play with:");
            double balanceAmount = iOManager.GetDeposit();

            SlotMachineConfig config = new SlotMachineConfig(
                  ConfigManager.AsteriskCoefficient
                , ConfigManager.AsteriskProbability
                , ConfigManager.SymbolACoefficient
                , ConfigManager.SymbolAProbability
                , ConfigManager.SymbolBCoefficient
                , ConfigManager.SymbolBProbability
                , ConfigManager.SymbolPCoefficient
                , ConfigManager.SymbolPProbability
                , ConfigManager.TableRows
                , ConfigManager.TableColumns
            );
            SlotMachineManager slotMachineManager = new SlotMachineManager(balanceAmount, config);
            do
            {
                iOManager.ShowMessageLine("Enter stake amount:");
                double stakeAmount = iOManager.GetStake(slotMachineManager.GetBalance());

                Symbol[][] resultsTable = slotMachineManager.Spin(stakeAmount);

                iOManager.ShowSpinResultsTable(resultsTable);
                iOManager.ShowMessageLine(String.Format("You have won: {0:c}", slotMachineManager.GetLastProfit()));
                iOManager.ShowMessageLine(String.Format("Current balance is: {0:c}", slotMachineManager.GetBalance()));
            } while(slotMachineManager.GetBalance() > 0);
            iOManager.ShowMessageLine("Game finished.");
        }
    }
}
