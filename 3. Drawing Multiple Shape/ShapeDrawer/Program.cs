using SplashKitSDK;
using System.Drawing;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind { Rectangle, Circle, Line }
        public static void Main()
        {
            ShapeKind kindToAdd;
            kindToAdd = ShapeKind.Circle;
            Window drawingScreen = new Window("ShapeDrawer", 800, 600);
            Drawing drawObject;
            drawObject = new Drawing();


            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                    kindToAdd = ShapeKind.Rectangle;

                if (SplashKit.KeyTyped(KeyCode.CKey))
                    kindToAdd = ShapeKind.Circle;

                if (SplashKit.KeyTyped(KeyCode.LKey))
                    kindToAdd = ShapeKind.Line;

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                    drawObject.SelectShapesAt(SplashKit.MousePosition());

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape shapeObject;
                    if (kindToAdd == ShapeKind.Rectangle)
                        shapeObject = new MyRectangle();
                    else if (kindToAdd == ShapeKind.Circle)
                        shapeObject = new MyCircle();
                    else
                        shapeObject = new MyLine();

                    shapeObject.X = SplashKit.MouseX();
                    shapeObject.Y = SplashKit.MouseY();
                    drawObject.AddShape(shapeObject);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                    drawObject.Background = SplashKit.RandomRGBColor(255);

                if (SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape shape in drawObject.SelectedShapes)
                        drawObject.RemoveShape(shape);
                }
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in drawObject.SelectedShapes)
                        drawObject.RemoveShape(shape);
                }

                drawObject.Draw();
                SplashKit.RefreshScreen();
            } while (!drawingScreen.CloseRequested);

        }
    }
}
