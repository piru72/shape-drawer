using SplashKitSDK;
namespace ShapeDrawer
{
    internal class MyCircle : Shape
    {
        private int _radius;

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        public MyCircle() : this(Color.Blue, 50) { }

        public MyCircle(Color color, int radius) : base(color)
        {
            Radius = radius;
        }



        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        public override bool IsAt(Point2D pt)
        {
            bool result = SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius)); ;
            return result;
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, Radius + 2);
        }
    }
}

