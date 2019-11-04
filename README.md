# slot_machine
# We have following projects:
# 1) Casino.App – this is main project, which is starting application. It is console application.
# 2) Casino.Interfaces – base interfaces for a casino game.
# 3) Casino.Core – implementation of base interfaces shared among all casino game.
# 4) Casino.SlotMachine – this is implementation of slot machine game by inheritance of casino game interfaces.
# Interfaces:
# IGame – interface of main game engine, which will control single casino game.
# IGameStartingData – Data which initialize casino game.
# IGameState – Current State of the game after a turn is done.
# IPlayerState – Update of player state after it is required by casino game
# IPlayer – participant in casino game.
# ICasinoGameFactory – Factory which is responsible for creating instance of casino game, chosen by the player.

# Slot Machine Game Engine file is SlotMachineGame.cs