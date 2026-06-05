using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SkyGameEngine.Engine.Utilities
{
    public struct Vec2f
    {
        public float X;
        public float Y;

        public Vec2f(float x, float y)  //constructor
        {
            X = x;
            Y = y;
        }

        //allows you to use Vec2f wherever a Vector2 is expected without needing to manually convert it.
        public static implicit operator Vector2(Vec2f v) => new Vector2(v.X, v.Y);

        // convert Monogame vector2 to our custom Vec2f struct, allowing for seamless interoperability between the two types.
        public static implicit operator Vec2f(Vector2 v) => new Vec2f(v.X, v.Y);

        //common directional constants (screen space: Y increases downwards)
        public static readonly Vec2f Up = new Vec2f(0, -1);
        public static readonly Vec2f Down = new Vec2f(0, 1);
        public static readonly Vec2f Left = new Vec2f(-1, 0);
        public static readonly Vec2f Right = new Vec2f(1, 0);


        //utilities constants
        public static readonly Vec2f Zero = new Vec2f(0f, 0f);
        public static readonly Vec2f One = new Vec2f(1f, 1f);


        //returns true if both components of the vector are zero,
        //which can be useful for optimization or to check if a vector has been initialized.
        public bool IsZero() => X == 0f && Y == 0f;

        //returns a vector that is perpendicular to the original vector.
        public Vec2f Perpendicular() => new Vec2f(-Y, X);

        //Returns the squared length of the vector, which is more efficient to compute than the actual
        //length (magnitude) - avoids the square root operation.
        public float LengthSquared() => X * X + Y * Y;

        public bool NearZero(float epsilon = 0.001f)
        {
            return Math.Abs(X) < epsilon && Math.Abs(Y) < epsilon;
        }

        //Rotates the vector by a specified angle in radians.
        public Vec2f Rotate(float radians)
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians); 
            return new Vec2f(X  *  cos - Y  *  sin, X  *  sin + Y  *  cos);
        }

        //returns the angle in radians from this vector to another vector,
        //which can be useful for determining the direction from one point to another.
        public float AngleTo(Vec2f other)
        {
            Vec2f delta = other - this;
            return MathF.Atan2(other.Y - Y, other.X - X);
        }

        //Vector addition
        public static Vec2f operator +(Vec2f a, Vec2f b) => new Vec2f(a.X + b.X, a.Y + b.Y);

        //Vector subtraction
        public static Vec2f operator -(Vec2f a, Vec2f b) => new Vec2f(a.X - b.X, a.Y - b.Y);

        //Scalar multiplication
        public static Vec2f operator *(Vec2f a, float b) => new Vec2f(a.X * b, a.Y * b);


    }
}
