using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_StudentInfo_system.StudentEntities
{
    public class Student
    #region Explaining what a class is
    /*Classes are the main focus in Object oriented programming (OOP). 
        A class is like a blueprint of a specific object.
        A class is a collection of objects of similar type.
        A class is a model for creating objects.
     */
    #endregion
    {
     #region Encapsulation 
        /* To achieve encapsulation: Step 1:  Declare the variables OR Fields of a class as private   */

       #region Student Fields
        /*  Fields are actual variables in your object that stores a particular piece of information. 
            The data and the methods are called members of an object.*/
             private int studentId;
             private string gender;
             private string popGroup;
             private string home_Language;
             private string sa_Citizenship_Status;
             private string foreign_Country;
        #endregion

        /* To achieve encapsulation: Step 2: Provide public setter and getter methods to modify 
           and view the variables values - using Property Methods.
            ⇒⇒Fields are like variables because they can be read or set directly, 
            subject to applicable access modifiers.
            ⇒⇒ Properties have get and set accessors, which provide more control on 
            how values are set or returned. 
         */

        #region Student Property Methods
        /* To achieve encapsulation: Step 2: Provide public setter and getter methods to modify and view the variables values.
            ⇒⇒Fields are like variables because they can be read or set directly, 
            subject to applicable access modifiers.
            ⇒⇒ Properties have get and set accessors, which provide more control on 
            how values are set or returned. 
         */
        public int StudentId
         {
             get { return studentId; }
             set { studentId = value; }
         }
         public string Gender
         {
             get { return gender; }
             set { gender = value; }
         }
         public string PopGroup
         {
             get { return popGroup; }
             set { popGroup = value; }
         }
         public string HomeLanguage
         {
             get { return home_Language; }
             set { home_Language = value; }
         }
         public string SA_Citizenship_Status
         {
             get { return sa_Citizenship_Status; }
             set { sa_Citizenship_Status = value; }
         }
         public string Foreign_Country
         {
             get { return foreign_Country; }
             set { foreign_Country = value; }
         }
        #endregion

        #endregion

     #region Student Constructors
        /* Each class should have a constructor - a method whose name is the same as the name of its type 
            its a special type of method that’s executed when an object is instantiated.
            Its method signature includes only the method name and its parameter list; 
            it does not include a return type.
            Whenever a class is created, its constructor is called.
            A class may have multiple constructors that take different arguments.
            Constructors enable the programmer to set default values, limit instantiation, 
            and write code that is flexible and easy to read.
         */
        public Student()
         {
             studentId = 0;
             gender = "";
             popGroup = "";
             home_Language = "";
             sa_Citizenship_Status = "";
             foreign_Country = "";
         }
         public Student(int idVal, string genderVal, string popGroupVal, string homeLVal, string citizenVal, string countryVal)
         {
             studentId = idVal;
             gender = genderVal;
             popGroup = popGroupVal;
             home_Language = homeLVal;
             sa_Citizenship_Status = citizenVal;
             foreign_Country = countryVal;
         }
 #endregion
    }
}
