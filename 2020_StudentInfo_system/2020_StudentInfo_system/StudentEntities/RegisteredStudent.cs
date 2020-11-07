using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_StudentInfo_system.StudentEntities
{
   public class RegisteredStudent:Student
    {
        #region Fields
        private AcademicStanding acaStanding;
        private int acaYear;
        private int termCareerGPAUnits;
        private double termCareerGPA;
        private int cumCareerGPAUnits;
        private double cumCareerGPA;
        private Collection<RegisteredCourse> regCourses;

        #endregion

        #region Property methods
        public Collection<RegisteredCourse> RegCourses
        {
            get
            {
                return regCourses;
            }
        }
        public AcademicStanding AcaStanding
        {
            get { return acaStanding; }
        }
        public int AcademicYear
        {
            get { return acaYear; }
            set { acaYear = value; }
        }
        public int TermCareerGPAUnits
        {
            get { return termCareerGPAUnits; }
            set { termCareerGPAUnits = value; }
        }

        public double CumCareerGPA
        {
            get { return cumCareerGPA; }
            set { cumCareerGPA = value; }
        }

        public int CumCareerGPAUnits
        {
            get { return cumCareerGPAUnits; }
            set { cumCareerGPAUnits = value; }
        }

        #endregion

        #region Constructor
        public RegisteredStudent() : base()
        {
            regCourses = new Collection<RegisteredCourse>();
        }
        #endregion
    }
}
