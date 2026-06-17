using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace InterstellarPixelEngine.Engine.Utilities
{
    public struct Vec2f
    {
        public float X;
        public float Y;

        public Vec2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        //Allow Vec2f to be automatically coverted to Monogame's Vector2
        public static implicit operator Vector2(Vec2f v) => new Vector2(v.X, v.Y);

        // convert monogame vector2 to vec2f
        public static implicit operator Vec2f(Vector2 v) => new Vec2f(v.X, v.Y);

        //common directional constants (screen-space: Y+ is down)
        public static readonly Vec2f Up = new Vec2f(0, -1);
        public static readonly Vec2f Down = new Vec2f(0, 1);
        public static readonly Vec2f Left = new Vec2f(-1, 0);
        public static readonly Vec2f Right = new Vec2f(1, 0);

        //utilites constants
        public static readonly Vec2f Zero = new Vec2f(0f, 0f);
        public static readonly Vec2f One = new Vec2f(1f, 1f);

        //returns true if vector is (0,0)
        public bool IsZero() => X == 0f && Y == 0f;

        //returns a vector perpendicular to thiss one (rotated 90 degrees CCW)
        //useful for normals or side directions
        public Vec2f Perpendicular() => new Vec2f(-Y, X);

        // Returns the squared length of the vector
        // faster than Lenght() and useful for comparisons
        public float LenghtSquared() => X * X + Y * Y;

        public bool NearZero(float epsilon = 0.001f)
        {
            return Math.Abs(X) < epsilon && Math.Abs(Y) < epsilon;
        }

        //Rotates the vector around the origin by an angle in radians
        public Vec2f Rotate(float radians)
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians);

            return new Vec2f(X *cos - Y * sin, X * sin + Y * cos);
        }

        //Returns the angle in radians from this vector to another vector
        public float AngleTo(Vec2f other)
        {
            Vec2f delta = other - this;
            return MathF.Atan2(delta.Y, delta.X);
        }

        //Vector addition
        public static Vec2f operator +(Vec2f a, Vec2f b) =>
            new Vec2f(a.X + b.X, a.Y + b.Y);

        //Vector subtraction
        public static Vec2f operator -(Vec2f a, Vec2f b) =>
            new Vec2f(a.X - b.X, a.Y - b.Y);

        //scalar multiplication
        public static Vec2f operator *(Vec2f a, float b) =>
            new Vec2f(a.X * b, a.Y * b);

        //Scalar Division
        public static Vec2f operator /(Vec2f a, float b) =>
            new Vec2f(a.X / b, a.Y / b);

        // equality check
        public static bool operator ==(Vec2f a,Vec2f b)=>
            a.X == b.X && a.Y == b.Y;

        //not equal check
        public static bool operator !=(Vec2f a, Vec2f b) =>
            !(a == b);

        // unary negation (flip direction)
        public static Vec2f operator -(Vec2f v) =>
            new Vec2f(-v.X, -v.Y);

        // Component-wise scaling
        public static Vec2f Scale(Vec2f a, Vec2f b) =>
            new Vec2f(a.X * b.X, a.Y * b.Y);

        //required when overloading == and !=
        public override bool Equals(object obj)
        {
            if (obj is Vec2f other)
                return this == other;
            return false;
        }

        //converts to Monogame Vector2 explicity if needed
        public Vector2 ToXna() => new Vector2(X, Y);

        //has code based on X and Y values
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        //returns the length(magnitude) of the vecotr
        public float Length()=> MathF.Sqrt(X * X + Y * Y);

        // returns a normalized (unit length) version of this vector
        public Vec2f Normalized()
        {
            float len = Length();
            if (len == 0f)
                return Zero;
            return new Vec2f(X / len, Y / len);
        }

        //Distance between two vectors
        public static float Distance(Vec2f a, Vec2f b)
        {
            return(a - b).Length();
        }

        //Returns a normalized direction from one point to another
        public static Vec2f Direction(Vec2f from, Vec2f to)
        {
            Vec2f delta = to - from;
            float length = delta.Length();
            if (length == 0f)
                return Zero;

            return delta / length;
        }

        //Reflects this vector off a surface defined by a normal
        //used for bouncing projectiles or physics responses
        public Vec2f Reflect(Vec2f normal)
        {
            normal = normal.Normalized();
            return this - normal * 2f * Dot(this, normal);
        }

        //Dot product of two vectors
        //used for angles,projections and reflections
        public static float Dot(Vec2f a, Vec2f b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        //Returns the angle this vector relative to the X-Axis
        public float Angle()
        {
            return MathF.Atan2(Y,X);
        }

        //moves a vector toward a target by a maximum distance
        //commonly used for smooth movement and camera motion
        public static Vec2f MoveTowards(Vec2f current, Vec2f target, float maxDistanceDelta)
        {
            Vec2f delta = target - current;
            float dist = delta.Length();

            if (dist == 0f || dist <= maxDistanceDelta)
                return target;

            return current + delta / dist * maxDistanceDelta;
        }

        //Linear interpolation between two vectors
        public static Vec2f Lerp(Vec2f a, Vec2f b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            return a + (b - a) * t;
        }

        //Limits the legnth of the vector without its direction
        public Vec2f ClampMagnitude(float maxLength)
        {
            float len = Length();
            if (len > maxLength)
                return this / len * maxLength;
            return this;
        }

        //clamps each compoent of the vector individually
        public Vec2f Clamp(Vec2f min,  Vec2f max)
        {
            return new Vec2f(MathF.Max(min.X,MathF.Min(max.X,X)),MathF.Max(min.Y,MathF.Min(max.Y,Y)));
        }

        //projects vector a onto vector b
        public static Vec2f Project(Vec2f a, Vec2f b)
        {
            float magSq = b.LenghtSquared();
            if (magSq == 0f)
                return Zero;

            float dot = Dot(a, b);
            return b * (dot/magSq);
        }

        public override string ToString() => $"({X},{Y}";
        
           
        

    }
}



