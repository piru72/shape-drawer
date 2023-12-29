using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;

        }


        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }
        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 3, Y - 3, Width + 5, Height + 5);
        }
        public override bool IsAt(Point2D pt)
        {
            bool betweenWidth = (pt.X >= X) && (pt.X <= X + Width);
            bool betweenHeight = (pt.Y >= Y) && (pt.Y <= Y + Height);
            bool result = betweenWidth && betweenHeight;
            return result;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
