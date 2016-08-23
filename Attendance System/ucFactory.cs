using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseControl;
using Attendance_System.Base_Contents;

namespace Attendance_System
{
    class ucFactory
    {
        public static BaseContent LoadContentItem( string _ObjectID)
        {
            switch(_ObjectID)
            {
                case "Biodata":
                    return Biodata();
                case "Courses":
                    return Courses();
                case "ucEvent":
                    return ucEvents();
                case "Attendance":
                    return Attendance();

                default :
                    return null;
            }
        }
        
        //Biodata
        static BaseContent _Biodata = null  ;
        protected static BaseContent Biodata()
        {
            if (_Biodata==null)
            {
                _Biodata = new Biodata();
            }
            return _Biodata;
        }

        //Courses
        static BaseContent _Courses = null;
        protected static BaseContent Courses()
        {
            if (_Courses == null)
            {
                _Courses = new Courses() ;
            }
            return _Courses;
        }

        //ucEvents
        static BaseContent _ucEvent = null;
        protected static BaseContent ucEvents()
        {
            if (_ucEvent == null)
            {
                _ucEvent = new ucEvent();
            }
            return _ucEvent;
        }

        //Attendance
        static BaseContent _Attendance = null;
        protected static BaseContent Attendance()
        {
            if (_Attendance == null)
            {
                _Attendance = new Attendance();
            }
            return _Attendance;
        }
        
    }
}
