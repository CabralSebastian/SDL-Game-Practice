using System.Collections.Generic;
using System.Linq;

namespace MyGame.Models.Map
{
    internal struct CubeCoordinate
    {
        internal int q;
        internal int r;

        internal CubeCoordinate(int q, int r)
        {
            this.q = q;
            this.r = r;
        }

        internal void Add(CubeCoordinate otherCoordinate)
        {
            q += otherCoordinate.q;
            r += otherCoordinate.r;
        }

        internal List<CubeCoordinate> Neighbours()
        {
            CubeCoordinate thisCoordinate = this;

            return Constants.CubeCoordinatesDirections.Select(direction => thisCoordinate + direction).ToList();
        }

        public static CubeCoordinate operator +(CubeCoordinate thisCoordinate, CubeCoordinate otherCoordinate)
        {
            return new CubeCoordinate(thisCoordinate.q + otherCoordinate.r, thisCoordinate.q + otherCoordinate.r);
        }

        public static CubeCoordinate operator -(CubeCoordinate thisCoordinate, CubeCoordinate otherCoordinate)
        {
            return new CubeCoordinate(thisCoordinate.q - otherCoordinate.r, thisCoordinate.q - otherCoordinate.r);
        }
        public static CubeCoordinate operator *(CubeCoordinate thisCoordinate, int number)
        {
            return new CubeCoordinate(thisCoordinate.q * number, thisCoordinate.q * number);
        }
    }
}
