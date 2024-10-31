namespace MyGame.Models.Units.States
{
    internal class IdleState : State
    {
        internal IdleState(Unit unit) : base(unit) { }

        internal override void StartTurn()
        {
            base.StartTurn();
            unit.ChangeState(StateType.OnTurn);
        }

    }
}
