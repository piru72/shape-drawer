using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }
        public MyLine() : this(Color.Pink, 0, 0, 400, 300) { }
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            EndX = endX;
            EndY = endY;
            X = startX;
            Y = startY;
        }


        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.DrawLine(Color, EndX, EndY, X, Y);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, EndX, EndY, 15);
            SplashKit.FillCircle(Color.Black, X, Y, 15);

        }
        public override bool IsAt(Point2D pt)
        {
            bool result = SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
            return result;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
