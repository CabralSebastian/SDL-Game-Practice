using MyGame.Models.Map;
using System;
using System.Collections.Generic;

namespace MyGame.Models.Units.States
{
    internal class OnTurnState : State
    {
        private readonly Dictionary<CubeCoordinate, List<CubeCoordinate>> pathsToReach;

        internal OnTurnState(Unit unit) : base(unit) 
        {
            pathsToReach = new Dictionary<CubeCoordinate, List<CubeCoordinate>>();
        }

        internal override void PrepareToMove()
        {
            base.PrepareToMove();

            PassPathsToReachToReadyToMove();

            unit.ChangeState(StateType.ReadyToMove);
        }

        private void PassPathsToReachToReadyToMove()
        {
            ((ReadyToMoveState)unit.States[StateType.ReadyToMove]).SetPaths(pathsToReach);
        }

        internal override void PrepareToAttack()
        {
            base.PrepareToAttack();
            unit.ChangeState(StateType.ReadyToAttack);
        }

        internal override void EndTurn()
        {
            base.EndTurn();
            unit.ChangeState(StateType.Idle);
        }

        internal override void OnEnter()
        {
            base.OnEnter();
            CalculateReachableTiles();
        }

        //The logic of CalculateReachableTiles() is adopted from 
        //https://www.redblobgames.com/grids/hexagons/ Range Section, Obstacles Part at the end
        internal void CalculateReachableTilesLisat()
        {
            pathsToReach.Clear();
            pathsToReach.Add(unit.Coordinate, new List<CubeCoordinate>());

            List<CubeCoordinate> visitedTiles = new List<CubeCoordinate>() { unit.Coordinate };

            List<List<CubeCoordinate>> tilesRings = new List<List<CubeCoordinate>>() { new List<CubeCoordinate>() { unit.Coordinate } };

            for(int k  = 1; k <= 5; k++) 
            {
                tilesRings.Add(new List<CubeCoordinate>());

                foreach(CubeCoordinate coordinate in tilesRings[k-1])         
                {
                    foreach(CubeCoordinate neighbour in coordinate.Neighbours())
                    {
                        Console.WriteLine("Coordinate: " + neighbour.q + ", " + neighbour.r + ". Contained: " + visitedTiles.Contains(coordinate));
                        if (visitedTiles.Contains(coordinate) || coordinate.IsBlocked)
                            continue;
                        Console.WriteLine("Entre: ");

                        visitedTiles.Add(coordinate);
                        tilesRings[k].Add(neighbour);

                        List<CubeCoordinate> pathToReachNeightbour = new List<CubeCoordinate>(pathsToReach[coordinate]) { neighbour };
                        pathsToReach.Add(neighbour, pathToReachNeightbour);
                    }
                }
            }
            Console.WriteLine("Visited: ");
            foreach (CubeCoordinate coordinate in visitedTiles)
                Console.WriteLine("Coordinate: " + coordinate.q + ", " + coordinate.r);
        }

        internal void CalculateReachableTiles()
        {
            pathsToReach.Clear();
            pathsToReach.Add(unit.Coordinate, new List<CubeCoordinate>());

            HashSet<CubeCoordinate> visitedTiles = new HashSet<CubeCoordinate> { unit.Coordinate };
            List<List<CubeCoordinate>> tilesRings = new List<List<CubeCoordinate>> { new List<CubeCoordinate> { unit.Coordinate } };

            for (int k = 1; k <= unit.Moves; k++)
            {
                tilesRings.Add(new List<CubeCoordinate>());

                foreach (CubeCoordinate coordinate in tilesRings[k - 1])
                {
                    foreach (CubeCoordinate neighbour in coordinate.Neighbours())
                    {
                        Console.WriteLine("Coordinate: " + neighbour.q + ", " + neighbour.r + ". Contained: " + visitedTiles.Contains(neighbour));
                        if (visitedTiles.Contains(neighbour) || coordinate.IsBlocked)
                            continue;

                        Console.WriteLine("Entre: ");

                        visitedTiles.Add(neighbour);
                        tilesRings[k].Add(neighbour);

                        List<CubeCoordinate> pathToReachNeighbour = new List<CubeCoordinate>(pathsToReach[coordinate]) { neighbour };
                        pathsToReach.Add(neighbour, pathToReachNeighbour);
                    }
                }
            }

            Console.WriteLine("Visited: ");
            foreach (CubeCoordinate coordinate in visitedTiles)
                Console.WriteLine("Coordinate: " + coordinate.q + ", " + coordinate.r);
        }
    }
}
