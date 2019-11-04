using System.Collections.Generic;
using Casino.Interfaces;

namespace Casino.SlotMachine.Game
{
    public class SlotMachineGameStartingData : IGameStartingData
    {
        public List<IPlayer> Players { get; set; }
    }
}
