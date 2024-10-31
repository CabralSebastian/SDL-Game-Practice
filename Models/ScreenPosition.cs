using System;

namespace MyGame.Models
{
    struct ScreenPosition
    {
        internal float x;
        internal float y;

        internal ScreenPosition(float x, float y)
        {
            this.x = x; 
            this.y = y;
        }

        internal float DistanceTo(ScreenPosition otherPosition)
        {
            ScreenPosition diference = this - otherPosition;

            return (float)Math.Sqrt((double)(diference.x * diference.x + diference.y * diference.y));
        }

        public static ScreenPosition operator +(ScreenPosition thisPosition, ScreenPosition otherPosition)
        {
            return new ScreenPosition(thisPosition.x + otherPosition.x, thisPosition.y + otherPosition.y);
        }

        public static ScreenPosition operator -(ScreenPosition thisPosition, ScreenPosition otherPosition)
        {
            return new ScreenPosition(thisPosition.x - otherPosition.x, thisPosition.y - otherPosition.y);
        }
    }
}