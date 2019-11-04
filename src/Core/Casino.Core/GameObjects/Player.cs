using Casino.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Core.GameObjects
{
    public class Player : IPlayer
    {
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}
