using System;

namespace GraphicEditor
{
    class Program
    {
        static void Main()
        {
            IShape triangle = new Triangle();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(triangle);
        }
    }
}
