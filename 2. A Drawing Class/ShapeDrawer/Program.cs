using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window drawingScreen = new Window("ShapeDrawer", 800, 600);
            Drawing drawObject;
            drawObject = new Drawing();
            
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                    drawObject.SelectShapesAt(SplashKit.MousePosition());

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape shapeObject;
                    shapeObject = new Shape();

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
                if ( SplashKit.KeyTyped(KeyCode.BackspaceKey))
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
