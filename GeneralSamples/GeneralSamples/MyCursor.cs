using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeneralSamples
{
    class MyCursor
    {
        public MyCursor() { }

        public void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 
            int displacement = 20;
            Cursor.Position = new Point(Cursor.Position.X - displacement, Cursor.Position.Y - displacement);
            System.Threading.Thread.Sleep(1000);
            Cursor.Position = new Point(Cursor.Position.X + displacement, Cursor.Position.Y + displacement);
        }

        public static void TryMoveCursor()
        {
            MyCursor myCursor = new MyCursor();
            myCursor.MoveCursor();
        }
    }
}
