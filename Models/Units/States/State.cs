using MyGame.Models.Map;

namespace MyGame.Models.Units.States
{
    internal abstract class State
    {
        protected readonly Unit unit;

        internal State(Unit unit) 
        {  
            this.unit = unit;
        }

        internal virtual void Update(float deltaTime) { }

        internal virtual void OnEnter() { }
        internal virtual void OnExit() { }

        internal virtual void StartTurn() { }
        internal virtual void EndTurn() { }

        internal virtual void PrepareToMove() { }
        internal virtual void PrepareToAttack() { }

        internal virtual void Move(CubeCoordinate destination) { }
        internal virtual void Attack(Unit target) { }

    }
}
