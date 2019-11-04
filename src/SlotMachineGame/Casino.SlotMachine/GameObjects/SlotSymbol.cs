using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.SlotMachine.GameObjects
{
    public enum SlotSymbolType
    {
        A = 1,
        B = 2,
        P = 3,
        Star = 4
    }
    /// <summary>
    /// Single symbol of slot machine game
    /// </summary>
    public class SlotSymbol
    {
        public SlotSymbolType Type { get; set; }
        public string Symbol { get; set; }
        public decimal Coefficent { get; set; }
        public double Probability { get; set; }
    }
}
