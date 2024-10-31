
using MyGame.Models.Map;
using System.Collections.Generic;
using System.IO;

namespace MyGame.Models.Units.States
{
    internal class ReadyToMoveState : State
    {
        private Dictionary<CubeCoordinate, List<CubeCoordinate>> pathsToReach;

        internal ReadyToMoveState(Unit unit) : base(unit) { }

        internal void SetPaths(Dictionary<CubeCoordinate, List<CubeCoordinate>> pathsToReach)
        {
            this.pathsToReach = pathsToReach;
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

        internal override void Move(CubeCoordinate destination)
        {
            base.Move(destination);

            if(!pathsToReach.ContainsKey(destination))
                return;

            List<CubeCoordinate> path = pathsToReach[destination];

            ((MovingState)unit.States[StateType.Moving]).SetPath(path);
            unit.ChangeState(StateType.Moving);
        }

        internal override void OnEnter()
        {
            base.OnEnter();

            foreach(KeyValuePair<CubeCoordinate, List<CubeCoordinate>> keyValuePair in pathsToReach)
            {
                Program.HighlightsManager.TurnOnHighlight(Color.Blue, keyValuePair.Key);
            }
        }

        internal override void OnExit()
        {
            base.OnExit();
            foreach (KeyValuePair<CubeCoordinate, List<CubeCoordinate>> keyValuePair in pathsToReach)
            {
                Program.HighlightsManager.TurnOffHighlight(keyValuePair.Key);
            }
        }
    }
}
