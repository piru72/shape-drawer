using SplashKitSDK;
namespace ShapeDrawer
{
    public class Drawing
    {
        private List<Shape> _shapes;
        private Color _background;

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();

                foreach (Shape s in _shapes)
                    if (s.Selected)
                        result.Add(s);

                return result;
            }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing() : this(Color.White) { }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            Background = background;
        }


        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);

            foreach (Shape shape in _shapes)
                shape.Draw();
        }


        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                    shape.Selected = true;
                else
                    shape.Selected = false;
            }
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteColor(Color.White);
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }



        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            try
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    string kind = reader.ReadLine();

                    Shape s;
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind : " + kind);
                    }

                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }


    }
}
