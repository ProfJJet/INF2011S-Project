using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_StudentInfo_system.StudentEntities
{
   public class RegisteredCourse:Course
    {
        #region Fields
        private int regID;
        private Course courseDetails;
        private string symbol;
        private double percent;
        #endregion

        #region  Properties 
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public double Percent
        {
            get { return percent; }
            set { percent = value; }
        }
        public Course CourseDetails
        {
            get { return courseDetails; }
            set { courseDetails = value; }
        }
        public int RegID
        {
            get { return regID; }
            set { regID = value; }
        }
        #endregion

        #region Constructors
        public RegisteredCourse()
        {
            courseDetails = null;
            symbol = "";
            percent = 0.0;
        }
        public RegisteredCourse(int Id, string code, string descript, string sessionVal, int units, double mark = 0.0, string symbolVal = "")
            : base(Id, code, descript, sessionVal, units)
        {
            courseDetails = new Course(Id, code, descript, sessionVal, units);
            symbol = symbolVal;
            percent = mark;
        }
        #endregion
    }
}
