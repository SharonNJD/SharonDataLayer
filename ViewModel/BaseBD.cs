using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace ViewModel
{
    public abstract class BaseDB
    {

        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;
        protected static string connectionString;

        protected abstract BaseEntity NewEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);
        protected abstract void LoadParameters(BaseEntity entity);


        public BaseDB()
        {
            if (connectionString == null)
            {
                connectionString = @"Server=tcp:sharonprojectserver.database.windows.net,1433;Initial Catalog=SharonDataBaseProject;Persist Security Info=False;User ID=sharon;Password=Project2006;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public List<BaseEntity> ExecuteCommand() //עבודה וניהול התקשורת מול המסד
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                connection.Open(); //פתיחת תקשורת עם המסד
                reader = command.ExecuteReader(); //ביצוע השאילתה
                while (reader.Read()) //מעבר על כל התוצאות
                {
                    BaseEntity entity = NewEntity(); //יצירת עצם חדש מותאם לצורך הנוכחי
                    list.Add(CreateModel(entity)); //מילוי העצם בתכונות מותאמות
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }
        public object ExecuteResult() //עבודה וניהול התקשורת מול המסד
        {
            object result = null;
            try
            {
                connection.Open(); //פתיחת תקשורת עם המסד
                reader = command.ExecuteReader(); //ביצוע השאילתה
                while (reader.Read())
                {
                    result = reader[0];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return result;
        }
        public int ExecuteCRUD() //עבודה וניהול התקשורת מול המסד
        {
            int records = 0;
            try
            {
                connection.Open(); //פתיחת תקשורת עם המסד
                records = command.ExecuteNonQuery(); //ביצוע השאילתה                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return records;
        }
        private static string Path()
        {
            string s = Environment.CurrentDirectory; //המיקום שבו רץ הפרויקט
            string[] sub = s.Split('\\'); //פירוק מחרוזת הכתובת למערך לפי תיקיות

            int index = sub.Length - 3; //חזרה אחורה 2 תיקיות
            sub[index] = "ViewModel";     //שינוי התיקיה לתיקיה המתאימה
            Array.Resize(ref sub, index + 1); //תיקון של אורך המערך, לאורך המתאים לתיקייה

            s = String.Join("\\", sub);  //חיבור מחדש של המערך עם / מפריד אישי 
            return s;
        }
    }
}

