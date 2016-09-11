using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataFactory;
namespace Attendance_System
{
    public static class GLOBALS
    {
        //static OLEDB _DB;
        //public static OLEDB AttendanceDB
        //{
        //    get
        //    {
        //        return _DB;
        //    }
        //    set
        //    {
        //        _DB = value;
        //    }
        //}

        static SQLite _DB;
        public static SQLite AttendanceDB
        {
            get
            {
                return _DB;
            }
            set
            {
                _DB = value;
            }
        }

    }
}
