using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplifiedSlotMachine.Domain
{
    public class Symbol
    {
        public Symbol(char name, double coefficient, int probability)
        {
            this.Value = name;
            this.Coefficient = coefficient;
            this.Probability = probability;
        }

        public Symbol(List<Symbol> systemSymbols, Random r)
        {
            int diceRoll = r.Next(1, 100);

            int cumulative = 0;
            for(int i = 0; i < systemSymbols.Count(); i++)
            {
                cumulative += systemSymbols[i].Probability;
                if(diceRoll < cumulative)
                {
                    this.Value = systemSymbols[i].Value;
                    this.Probability = systemSymbols[i].Probability;
                    this.Coefficient = systemSymbols[i].Coefficient;
                    break;
                }
            }
        }

        public char Value { get; set; }
        public double Coefficient { get; set; }
        public int Probability { get; set; }
    }
}
