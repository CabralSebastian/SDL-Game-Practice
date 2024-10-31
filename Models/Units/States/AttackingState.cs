namespace MyGame.Models.Units.States
{
    internal class AttackingState : State
    {
        private Unit target;

        internal AttackingState(Unit unit) : base(unit) { }

        internal override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //At Some Point
            //target.ReceiveDamage(unit.Weapon.Damage)

            //At Some Other Point
            // Go Back to OnTurn || Finish Turn
        }

        internal void SetTarget(Unit target)
        {
            this.target = target;
        }
    }
}
