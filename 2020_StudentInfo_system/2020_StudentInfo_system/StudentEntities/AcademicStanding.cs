using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_StudentInfo_system.StudentEntities
{
    public class AcademicStanding
    {
        #region Fields
        private int academicStandingId;
        private string academicStandingCode;
        #endregion


        #region Properties
        public int AcademicStandingId
        {
            get { return academicStandingId; }
            set { academicStandingId = value; }
        }
        public string AcademicStandingCode
        {
            get { return academicStandingCode; }
            set { academicStandingCode = value; }
        }
        #endregion
    }
}
