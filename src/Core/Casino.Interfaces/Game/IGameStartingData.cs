using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Interfaces
{
    public interface IGameStartingData
    {
        List<IPlayer> Players { get; set; }
    }
}
