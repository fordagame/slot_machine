using Casino.Interfaces;
using Casino.SlotMachine.Game;
using Casino.SlotMachine.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.SlotMachine.Factories
{
    public class SlotMachineGameFactory : ICasinoGameFactory
    {
        public IGame GetGame()
        {
            SlotSymbol[] symbols = new SlotSymbol[4];
            symbols[0] = new SlotSymbol() { Type = SlotSymbolType.A, Symbol = "A", Coefficent = 0.4M, Probability = 45 };
            symbols[1] = new SlotSymbol() { Type = SlotSymbolType.B, Symbol = "B", Coefficent = 0.6M, Probability = 35 };
            symbols[2] = new SlotSymbol() { Type = SlotSymbolType.P, Symbol = "P", Coefficent = 0.8M, Probability = 15 };
            symbols[3] = new SlotSymbol() { Type = SlotSymbolType.Star, Symbol = "*", Coefficent = 0M, Probability = 5 };
            return new SlotMachineGame(symbols, 4, 3);
        }
    }
}
