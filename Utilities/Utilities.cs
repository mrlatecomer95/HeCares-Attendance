using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities
{
    /// Utilities
    public class Utilities
    {

    }

    //UtilColors
    public static class UtilColor
    {
        static Color _SelColor; //Init Selected Color
        public static Color SelectedColor
        {
            get { return _SelColor; }
            set { _SelColor = value; }
        }
        
        static Color _EditedColor = Color.DodgerBlue; //Init Selected Color
        public static Color EditedColor
        {
            get { return _EditedColor; }
            set { _EditedColor = value; }
        }


    }


}
