using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace diplomatik
{
    public class DataBaseFUX
    {
        public string StringCon()
        {
            return @"Data Source=CHMONIK\FUKI;Initial Catalog=DBotBoga;Integrated Security=True";
        }
        public SqlDataAdapter queryExecute(string query)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(StringCon());
                myCon.Open();

                SqlDataAdapter SDA = new SqlDataAdapter(query, myCon);

                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Действие успешно выполнено!", "Успех",MessageBoxButtons.OK,
                    MessageBoxIcon.Information); 
                return SDA;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + $"{ex.Message}", "Ошибка",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
