using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame.Models.Map
{
    internal class CubeCoordinate : IEquatable<CubeCoordinate>
    {
        internal readonly static List<CubeCoordinate> Directions;

        static CubeCoordinate()
        {
            Directions = new List<CubeCoordinate>()
            {
                new CubeCoordinate(1,0), new CubeCoordinate(-1,0),
                new CubeCoordinate(0,1), new CubeCoordinate(0,-1),
                new CubeCoordinate(1,-1), new CubeCoordinate(-1, 1),
            };
        }

        internal readonly int q;
        internal readonly int r;
        internal bool IsBlocked;

        //internal List<CubeCoordinate> Neighbours;
        internal CubeCoordinate(int q, int r, bool isBlocked = false)
        {
            this.q = q;
            this.r = r;
            IsBlocked = isBlocked;
            
            //Estaria Fantastico Calcular los vecinos aca y que no de un error circular.
        }
        
        internal List<CubeCoordinate> Neighbours()
        {
            return CubeCoordinate.Directions.Select(direction => this + direction).ToList();
        }
        public static CubeCoordinate operator +(CubeCoordinate thisCoordinate, CubeCoordinate otherCoordinate)
        {
            return new CubeCoordinate(thisCoordinate.q + otherCoordinate.q, thisCoordinate.r + otherCoordinate.r);
        }

        public static CubeCoordinate operator -(CubeCoordinate thisCoordinate, CubeCoordinate otherCoordinate)
        {
            return new CubeCoordinate(thisCoordinate.q - otherCoordinate.q, thisCoordinate.r - otherCoordinate.r);
        }
        public static CubeCoordinate operator *(CubeCoordinate thisCoordinate, int number)
        {
            return new CubeCoordinate(thisCoordinate.q * number, thisCoordinate.q * number);
        }

        #region IEquatable Implementation
        public override bool Equals(object obj)
        {
            return Equals(obj as CubeCoordinate);
        }

        public bool Equals(CubeCoordinate otherCoordinate)
        {
            if (otherCoordinate is null) return false;
            return q == otherCoordinate.q && r == otherCoordinate.r;
        }

        public override int GetHashCode()
        {
            return (q * 37) ^ (r * 73);
        }
        #endregion
    }
}
