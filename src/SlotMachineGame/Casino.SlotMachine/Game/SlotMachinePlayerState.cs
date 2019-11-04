using Casino.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.SlotMachine.Game
{
    public class SlotMachinePlayerState : IPlayerState
    {
        public decimal Stake { get; set; }
    }
}
