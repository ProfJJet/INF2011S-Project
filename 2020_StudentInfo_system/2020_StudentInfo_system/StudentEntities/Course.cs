using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_StudentInfo_system.StudentEntities
{
   public class Course
    {
        #region Course Fields
        private int courseId;
        private string course_Code;
        private string course_Description;
        private string session;
        private int units_Taken;
        #endregion

        #region Course Properties
        public int ID
        {
            get { return courseId; }
            set { courseId = value; }
        }
        public string Code
        {
            get { return course_Code; }
            set { course_Code = value; }
        }
        public string Description
        {
            get { return course_Description; }
            set { course_Description = value; }
        }
        public string Session
        {
            get { return session; }
            set { session = value; }
        }
        public int Units
        {
            get { return units_Taken; }
            set { units_Taken = value; }
        }
        #endregion

        #region Course Constructors
        public Course()
        {
            courseId = 0;
            course_Code = "";
            course_Description = "";
            session = "";
            units_Taken = 0;
        }
        public Course(int Id, string code, string descript, string sessionVal, int units)
        {
            courseId = Id;
            course_Code = code;
            course_Description = descript;
            session = sessionVal;
            units_Taken = units;
        }
        #endregion
    }
}
