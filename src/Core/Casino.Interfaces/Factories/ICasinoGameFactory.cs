using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Interfaces
{
    public interface ICasinoGameFactory
    {
        IGame GetGame();
    }
}
