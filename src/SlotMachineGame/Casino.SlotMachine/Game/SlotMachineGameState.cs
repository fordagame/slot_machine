using Casino.Interfaces;
using System;

namespace Casino.SlotMachine.Game
{
    public class SlotMachineGameState : IGameState
    {
        public string Rows { get; set; }
        public decimal ResultBalanceWin { get; set; }
    }
}
