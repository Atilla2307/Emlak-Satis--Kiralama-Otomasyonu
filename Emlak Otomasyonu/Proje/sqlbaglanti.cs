using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Data.Sql;

namespace Proje
{
    internal class sqlbaglanti
    {

        public SqlConnection connect = new SqlConnection("Data Source=ATILLA\\SQLEXPRESS01;Initial Catalog=emlak;Integrated Security=True;Encrypt=False");

     

        public void SqlOpen()
        {
            try
            {

                if (connect.State == ConnectionState.Closed) 
                {
                    connect.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı açılırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SqlClose()
        {
            try
            {
                if (connect != null && connect.State == ConnectionState.Open) 
                {
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kapatılırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
