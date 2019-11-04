using Casino.Core.GameObjects;
using Casino.Interfaces;
using Casino.SlotMachine.Factories;
using Casino.SlotMachine.Game;
using System;
using System.Collections.Generic;

namespace Casino.App
{
    class App
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Console.WriteLine("Hello in Casion!");
            Console.WriteLine("Please deposit money you would like to play with: ");
            string balanceString = Console.ReadLine();
            decimal balance = 0;
            if (decimal.TryParse(balanceString, out balance))
            {
                player.Balance = balance;
            }
            else
            {
                Console.WriteLine("Balance is not a number!");
                return;
            }

            IGame game = GetGame(GameTypes.SlotMachine);
            SlotMachineGameStartingData data = new SlotMachineGameStartingData();
            List<IPlayer> players = new List<IPlayer>();
            players.Add(player);
            data.Players = players;
            game.StartGame(data);
            while (player.Balance > 0)
            {
                Console.WriteLine("Enter stake amount: ");
                string stakeString = Console.ReadLine();
                decimal stake = 0;
                if (decimal.TryParse(stakeString, out stake))
                {
                    SlotMachinePlayerState playerState = new SlotMachinePlayerState();
                    playerState.Stake = stake;
                    SlotMachineGameState state = (SlotMachineGameState)game.Play(playerState);
                    Console.WriteLine(state.Rows);
                    Console.WriteLine("You have won: {0}", state.ResultBalanceWin);
                    Console.WriteLine("Current balance: {0}", player.Balance);
                }
                else
                {
                    Console.WriteLine("Stake is not a number!");
                }
            }
            Console.WriteLine("You have no more money!");
        }

        public static IGame GetGame(GameTypes type)
        {
            ICasinoGameFactory factory;
            switch (type)
            {
                case GameTypes.SlotMachine:
                default:
                    factory = new SlotMachineGameFactory();
                    break;
            }
            return factory.GetGame();
        }
    }
}
