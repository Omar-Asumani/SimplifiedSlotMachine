using System;
using System.Configuration;

namespace SimplifiedSlotMachine
{
    public static class ConfigManager
    {
        public static string LoggerPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("LoggerPath");
            }
        }

        public static double AsteriskCoefficient
        {
            get
            {
                return Double.Parse(ConfigurationManager.AppSettings.Get("AsteriskCoefficient"));
            }
        }
        public static int AsteriskProbability
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("AsteriskProbability"));
            }
        }

        public static double SymbolACoefficient
        {
            get
            {
                return Double.Parse(ConfigurationManager.AppSettings.Get("SymbolACoefficient"));
            }
        }
        public static int SymbolAProbability
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("SymbolAProbability"));
            }
        }

        public static double SymbolBCoefficient
        {
            get
            {
                return Double.Parse(ConfigurationManager.AppSettings.Get("SymbolBCoefficient"));
            }
        }
        public static int SymbolBProbability
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("SymbolBProbability"));
            }
        }

        public static double SymbolPCoefficient
        {
            get
            {
                return Double.Parse(ConfigurationManager.AppSettings.Get("SymbolPCoefficient"));
            }
        }
        public static int SymbolPProbability
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("SymbolPProbability"));
            }
        }

        public static int TableRows
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("TableRows"));
            }
        }
        public static int TableColumns
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings.Get("TableColumns"));
            }
        }
    }
}