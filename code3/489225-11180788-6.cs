    public abstract class Curve 
    {
        public float EaseIn(double s);
        public float EaseOut(double s);
        public static float EaseInOut(double s);
    }
    public class StepCurve : Curve
    {
        public override float EaseIn(double s)
        {
            return s < 0.5 ? 0.0f : 1.0f;
        }
        public override float EaseOut(double s)
        {
            return s < 0.5 ? 0.0f : 1.0f;
        }
        public override float EaseInOut(double s)
        {
            return s < 0.5 ? 0.0f : 1.0f;
        }
    }
    public class LinearCurve : Curve
    {
        public override float EaseIn(double s)
        {
            return (float)s;
        }
        public override float EaseOut(double s)
        {
            return (float)s;
        }
        public override float EaseInOut(double s)
        {
            return (float)s;
        }
    }
    public class SineCurve : Curve
    {
        public override float EaseIn(double s)
        {
            return (float)Math.Sin(s * MathHelper.HalfPi - MathHelper.HalfPi) + 1;
        }
        public override float EaseOut(double s)
        {
            return (float)Math.Sin(s * MathHelper.HalfPi);
        }
        public override float EaseInOut(double s)
        {
            return (float)(Math.Sin(s * MathHelper.Pi - MathHelper.HalfPi) + 1) / 2;
        }
    }
    public class PowerCurve : Curve
    {
        int _power;
        public PowerCurve(int power)
        {
            _power = power;
        }
        public override float EaseIn(double s)
        {
            return (float)Math.Pow(s, _power);
        }
        public override float EaseOut(double s)
        {
            var sign = _power % 2 == 0 ? -1 : 1;
            return (float)(sign * (Math.Pow(s - 1, _power) + sign));
        }
        public override float EaseInOut(double s)
        {
            s *= 2;
            if (s < 1) return EaseIn(s, _power) / 2;
            var sign = _power % 2 == 0 ? -1 : 1;
            return (float)(sign / 2.0 * (Math.Pow(s - 2, _power) + sign * 2));
        }
    }
