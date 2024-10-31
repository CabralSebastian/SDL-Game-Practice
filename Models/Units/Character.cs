
using MyGame.Models.Map;
using MyGame.Models.Units.States;

namespace MyGame.Models.Units
{
    internal class Character : Unit
    {
        internal Character(string name, int moves, CubeCoordinate coordinate) : base(name, moves, coordinate) { }

        internal override void AddStates()
        {
            States[StateType.Idle] = new IdleState(this);
            States[StateType.OnTurn] = new OnTurnState(this);

            States[StateType.ReadyToMove] = new ReadyToMoveState(this);
            States[StateType.ReadyToAttack] = new ReadyToAttackState(this);

            States[StateType.Moving] = new MovingState(this);
            States[StateType.Attacking] = new AttackingState(this);
        }

        internal override void SetInitialState()
        {
            State = States[StateType.Idle];
        }


        internal virtual void PrepareToMove() 
        { 
            State.PrepareToMove();
        }
        internal virtual void PrepareToAttack() 
        { 
            State.PrepareToAttack();
        }

        internal virtual void Move(CubeCoordinate destination) 
        { 
            State.Move(destination);
        }
        internal virtual void Attack(Unit target) 
        { 
            State.Attack(target);
        }
    }
}
