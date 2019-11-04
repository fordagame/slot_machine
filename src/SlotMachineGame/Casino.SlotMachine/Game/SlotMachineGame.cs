using Casino.Interfaces;
using Casino.SlotMachine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino.SlotMachine.Game
{
    public class SlotMachineGame : IGame
    {
        //all allowed symbols in slot machine game
        private SlotSymbol[] _symbols;
        //total probability of all symbols
        private double _totalProbabilitySum;
        //probability distribution for every symbol
        private double[] _probabilityDistribution;
        //number of cols and rows;
        private int _rows;
        private int _cols;
        private IPlayer _player;
        private bool _isGameStarted = false;
        public SlotMachineGame(SlotSymbol[] symbols, int rows, int cols)
        {
            this._symbols = symbols;
            this._rows = rows;
            this._cols = cols;
        }

        public void StartGame(IGameStartingData data)
        {
            //game should have 1 player set by starting data.
            if (data.Players.Count > 0)
            {
                this._player = data.Players[0];
            }
            this._totalProbabilitySum = 0;
            this._isGameStarted = true;
            this._probabilityDistribution = new double[this._symbols.Length];
            double probabilityDistributionStart = 0;
            //calculating total probability and probability distribution of all symbols
            for(var i = 0; i< this._symbols.Length; i++)
            {
                SlotSymbol symbol = this._symbols[i];
                this._totalProbabilitySum += symbol.Probability;
                probabilityDistributionStart += symbol.Probability;
                this._probabilityDistribution[i] = probabilityDistributionStart;
            }
        }

        public void StopGame()
        {
            this._player = null;
            this._isGameStarted = false;
        }

        public IGameState Play(IPlayerState playerState)
        {
            SlotMachineGameState state = new SlotMachineGameState();
            if (!this._isGameStarted)
            {
                state.Rows = "Game is not started";
                return state;
            }
            SlotMachinePlayerState smPlayerState = (SlotMachinePlayerState)playerState;
            if (this._player.Balance < smPlayerState.Stake)
            {
                state.Rows = "Player balance is not enough";
                return state;
            }
            this._player.Balance -= smPlayerState.Stake;
            Random rand = new Random();
            decimal winningCoeficent = 0;
            for (int i = 0; i < this._rows; i++)
            {
                //current symbol of the row. If symbol is different than next symbol, than row is lost.
                SlotSymbol _symbols = null;
                //total coeficent of the row
                decimal coeficent = 0;
                //does winning condition of row is met
                bool isWinningRow = true;
                //Row symbols
                string result = "";
                for(int j = 0; j < this._cols; j++)
                {
                    SlotSymbol currentSymbol = this.GetSymbol(rand.Next(1, (int)this._totalProbabilitySum));
                    result += currentSymbol.Symbol;
                    coeficent += currentSymbol.Coefficent;
                    if(currentSymbol.Type == SlotSymbolType.Star)
                    {
                        continue;
                    }
                    if(_symbols == null)
                    {
                        _symbols = currentSymbol;
                    }
                    if(_symbols.Symbol != currentSymbol.Symbol)
                    {
                        isWinningRow = false;
                    }
                }
                //if winning condition is true, than we add row coeficent to total coeficent
                if (isWinningRow)
                {
                    winningCoeficent += coeficent;
                }
                state.Rows += string.Format("{0}\n", result);
            }
            state.ResultBalanceWin = smPlayerState.Stake * winningCoeficent;
            this._player.Balance += state.ResultBalanceWin;
            return state;
        }

        //Based on the random number, we calculate what is next number
        private SlotSymbol GetSymbol(int probabilityRandomNumber)
        {
            SlotSymbol symbol = this._symbols[this._probabilityDistribution.Length - 1];
            for(var i = 0; i < this._probabilityDistribution.Length; i++)
            {
                if(probabilityRandomNumber <= this._probabilityDistribution[i])
                {
                    symbol = this._symbols[i];
                    break;
                }
            }
            return symbol;
        }
    }
}
