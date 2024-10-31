namespace MyGame.Models.Units.States
{
    internal class ReadyToAttackState : State
    {
        internal ReadyToAttackState(Unit unit) : base(unit) { }

        internal override void PrepareToMove()
        {
            base.PrepareToMove();
            unit.ChangeState(StateType.ReadyToMove);
        }

        internal override void EndTurn()
        {
            base.EndTurn();
            unit.ChangeState(StateType.Idle);
        }

        internal override void Attack(Unit target)
        {
            base.Attack(target);
            ((AttackingState)unit.States[StateType.Attacking]).SetTarget(target);
            unit.ChangeState(StateType.Attacking);
        }
    }
}
