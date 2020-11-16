using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Poppel_Ordering_System.Properties;

namespace Poppel_Ordering_System.DatabaseLayer
{
    public class DB
    {
        #region Fields
        private string strConn = Settings.Default.PoppelDBConnectionString;
        protected SqlConnection cnMain;
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                cnMain = new SqlConnection(strConn);
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");
                return;
            }
        }
        #endregion

        #region methods
        protected bool UpdateDataSource(SqlCommand currentCommand)
        {
            bool success;
            try
            {
                cnMain.Open();
                currentCommand.CommandType = CommandType.Text;
                currentCommand.ExecuteNonQuery();
                cnMain.Close();
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
                success = false;
            }
            return success;
        }
        #endregion
    }
}
