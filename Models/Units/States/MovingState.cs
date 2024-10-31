using MyGame.Models.Map;
using System;
using System.Collections.Generic;

namespace MyGame.Models.Units.States
{
    internal class MovingState : State
    {
        const float MOVEMENT_SPEED = 200f;

        private List<CubeCoordinate> path;

        internal MovingState(Unit unit) : base(unit) { }

        private ScreenPosition PositionToReach => Program.Grid.Positions[path[0]];

        internal override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            unit.Position = MoveTowards(unit.Position, PositionToReach, MOVEMENT_SPEED * deltaTime);

            if ( unit.Position.Equals(PositionToReach) ) //float comparison using an EPSILON
            {
                unit.Position = PositionToReach;
                path.RemoveAt(0);

                if (path.Count == 0)
                    unit.ChangeState(StateType.OnTurn);
            }
        }

        private ScreenPosition MoveTowards(ScreenPosition from, ScreenPosition to, float speed)
        {
            float DistanceToReach = from.DistanceTo(to);
            ScreenPosition direction = (to - from) / DistanceToReach;

            return from + direction * Math.Min(DistanceToReach, speed);
        }

        internal void SetPath(List<CubeCoordinate> path)
        {
            this.path = path;
        }
    }
}
