
using MyGame.Models.Map;
using MyGame.Models.Units.States;
using System.Collections.Generic;

namespace MyGame.Models.Units
{
    internal abstract class Unit
    {
        internal readonly string Name;

        internal readonly int MaxHealth;

        internal int Health;

        internal readonly int Moves;

        //internal readonly WeaponStrategy Weapon;


        internal CubeCoordinate Coordinate { get; private set; }
        internal ScreenPosition Position { get; set; }

        protected State State;
        internal readonly Dictionary<StateType, State> States;

        internal Unit(string name, int moves, CubeCoordinate coordinate)
        {
            this.Name = name;
            this.Moves = moves;
            this.Coordinate = coordinate;
            Position = Program.Grid.Positions[coordinate];

            States = new Dictionary<StateType, State>();

            AddStates();
            SetInitialState();
    }

        internal abstract void AddStates();
        internal abstract void SetInitialState();

        internal void Update(float deltaTime)
        {
            State.Update(deltaTime);
        }

        internal void ChangeState(StateType newState)
        {
            State.OnExit();
            State = States[newState];
            State.OnEnter();
        }

        internal virtual void StartTurn()
        {
            State.StartTurn();
        }

        internal virtual void EndTurn()
        {
            State.EndTurn();    
            ChangeState(StateType.Idle);
        }

    }
}
