using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Interfaces
{
    public interface IPlayer
    {
        decimal Balance { get; set; }
        string Name { get; set; }
    }
}
