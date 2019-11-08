using System;
using System.Collections.Generic;

namespace SimplifiedSlotMachine.Domain
{
    public class SlotMachineManager
    {
        private double balanceAmount;
        private double lastProfitAmount;
        private readonly List<Symbol> systemSymbols;
        private readonly SlotMachineConfig config;

        public SlotMachineManager(double balanceAmount, SlotMachineConfig config)
        {
            this.balanceAmount = balanceAmount;
            this.systemSymbols = new List<Symbol>
            {
                 new Symbol('*',config.AsteriskCoefficient,config.AsteriskProbability)
                ,new Symbol('A',config.SymbolACoefficient,config.SymbolAProbability)
                ,new Symbol('B',config.SymbolBCoefficient,config.SymbolBProbability)
                ,new Symbol('P',config.SymbolPCoefficient,config.SymbolPProbability)
            };
            this.config = config;
        }

        public Symbol[][] Spin(double stakeAmount)
        {
            this.balanceAmount -= stakeAmount;

            Symbol[][] resultsTable = new Symbol[config.TableRows][];
            Random r = new Random();
            // Spin the slot machine
            for(int i = 0; i < config.TableRows; i++)
            {
                resultsTable[i] = new Symbol[]
                {
                    new Symbol(systemSymbols,r),
                    new Symbol(systemSymbols,r),
                    new Symbol(systemSymbols,r)
                };
            }

            double profitCoefficient = 0;
            char wildcard = '*';
            for(int i = 0; i < config.TableRows; i++)
            {
                double rowCoefficient = 0;
                char rowStandard = resultsTable[i][0].Value;
                for(int j = 0; j < config.TableColumns; j++)
                {
                    if(rowCoefficient == -1)
                    {
                        continue;
                    }

                    // Set standard to first non-wildcard symbol
                    if(rowStandard == wildcard && rowStandard != resultsTable[i][j].Value)
                    {
                        rowStandard = resultsTable[i][j].Value;
                    }

                    if(resultsTable[i][j].Value == rowStandard)
                    {
                        rowCoefficient += resultsTable[i][j].Coefficient;
                    }
                    // Flag as mismatched row
                    else if(resultsTable[i][j].Value != wildcard)
                    {
                        rowCoefficient = -1;
                    }
                }

                if(rowCoefficient > 0)
                {
                    profitCoefficient += rowCoefficient;
                }
            }
            double profitAmount = stakeAmount * profitCoefficient;
            this.balanceAmount = Math.Round(this.balanceAmount + profitAmount, 2);
            lastProfitAmount = profitAmount;

            return resultsTable;
        }

        public double GetBalance()
        {
            return this.balanceAmount;
        }

        public double GetLastProfit()
        {
            return this.lastProfitAmount;
        }
    }
}
