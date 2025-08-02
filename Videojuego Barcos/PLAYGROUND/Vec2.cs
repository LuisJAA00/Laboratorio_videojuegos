using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    public class Vec2
    {
        public float X,Y;

        public Vec2(float x, float y)
        { 
            this.X = x; this.Y = y;
        }

        public static Vec2 operator -(Vec2 v)
        {
            return new Vec2 (-v.X, -v.Y);
        }

        public static Vec2 operator +(Vec2 a,Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }

        public static Vec2 operator +(Vec2 a, float b)
        {
            return new Vec2(a.X + b, a.Y + b);
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }
        public static Vec2 operator -(Vec2 a, float b)
        {
            return new Vec2(a.X - b, a.Y - b);
        }

        public static Vec2 operator *(float a, Vec2 v)
        {
            return new Vec2(a*v.X,a*v.Y);
        }

        public static Vec2 operator *(Vec2 v, float a)
        {
            return new Vec2(a * v.X, a * v.Y);
        }

        public static Vec2 operator /(Vec2 v, float a)
        {
            return new Vec2(v.X/a,v.Y/a);
        }

        public float MagSqr()
        {
            return this.X*this.X + this.Y*this.Y;
        }

        public float Lenght()
        {
            return (float)Math.Sqrt((float)this.MagSqr());
        }

        public float Distance(Vec2 other)
        {
            return (float)Math.Sqrt((float)((this.X - other.X) * (this.X - other.X) + (this.Y - other.Y) * (this.Y - other.Y)));

        }

    }
}
