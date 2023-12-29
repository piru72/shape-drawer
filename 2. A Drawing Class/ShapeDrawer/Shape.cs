using SplashKitSDK;

namespace ShapeDrawer
{

    public class Shape
    {
        private bool _selected;
        private Color _color;
        private int _width;
        private int _height;
        private float _x;
        private float _y;


        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
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
       

        public Shape()
        {
            Selected = false;
            Color = Color.Green;
            X = 0;
            Y = 0;
            Width = 100;
            Height = 100;
        }

        public void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillRectangle(Color, X, Y, Width,Height);
        }
        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }
        public Boolean IsAt(Point2D pt)
        {
            bool betweenWidth = (pt.X >= X) && (pt.X <= X + Width);
            bool betweenHeight = (pt.Y >= Y) && (pt.Y <= Y + Height);
            return betweenWidth && betweenHeight ;
        }

        
    }
}
