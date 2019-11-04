using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Interfaces
{
    public interface IGame
    {
        void StartGame(IGameStartingData data);
        void StopGame();
        IGameState Play(IPlayerState state);
    }
}
