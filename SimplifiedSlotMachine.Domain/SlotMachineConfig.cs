namespace SimplifiedSlotMachine.Domain
{
    public class SlotMachineConfig
    {
        public readonly double AsteriskCoefficient;
        public readonly int AsteriskProbability;
        public readonly double SymbolACoefficient;
        public readonly int SymbolAProbability;
        public readonly double SymbolBCoefficient;
        public readonly int SymbolBProbability;
        public readonly double SymbolPCoefficient;
        public readonly int SymbolPProbability;
        public readonly int TableRows;
        public readonly int TableColumns;

        public SlotMachineConfig(
              double asteriskCoefficient
            , int asteriskProbability
            , double symbolACoefficient
            , int symbolAProbability
            , double symbolBCoefficient
            , int symbolBProbability
            , double symbolPCoefficient
            , int symbolPProbability
            , int tableRows
            , int tableColumns)
        {
            this.AsteriskCoefficient = asteriskCoefficient;
            this.AsteriskProbability = asteriskProbability;
            this.SymbolACoefficient = symbolACoefficient;
            this.SymbolAProbability = symbolAProbability;
            this.SymbolBCoefficient = symbolBCoefficient;
            this.SymbolBProbability = symbolBProbability;
            this.SymbolPCoefficient = symbolPCoefficient;
            this.SymbolPProbability = symbolPProbability;
            this.TableRows = tableRows;
            this.TableColumns = tableColumns;
        }
    }
}
