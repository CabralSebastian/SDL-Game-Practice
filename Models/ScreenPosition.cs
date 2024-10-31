using System;

namespace MyGame.Models
{
    struct ScreenPosition
    {
        const float EPSILON = 0.01f;
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

        internal bool Equals(ScreenPosition otherPosition)
        {
            return Math.Abs(x - otherPosition.x) < EPSILON && Math.Abs(y - otherPosition.y) < EPSILON;
        }

        public static ScreenPosition operator +(ScreenPosition thisPosition, ScreenPosition otherPosition)
        {
            return new ScreenPosition(thisPosition.x + otherPosition.x, thisPosition.y + otherPosition.y);
        }

        public static ScreenPosition operator -(ScreenPosition thisPosition, ScreenPosition otherPosition)
        {
            return new ScreenPosition(thisPosition.x - otherPosition.x, thisPosition.y - otherPosition.y);
        }

        public static ScreenPosition operator *(ScreenPosition thisPosition, float number)
        {
            return new ScreenPosition(thisPosition.x * number, thisPosition.y * number);
        }

        public static ScreenPosition operator /(ScreenPosition thisPosition, float number)
        {
            return new ScreenPosition(thisPosition.x / number, thisPosition.y / number);
        }
    }
}