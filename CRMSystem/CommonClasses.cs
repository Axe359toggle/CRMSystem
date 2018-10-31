using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CRMSystem
{
    public class BackButton
    {


        static string[] previousWindows;
        static int noOfWindows = 0;

        public BackButton()
        {
            previousWindows = new string[10];
        }

        public BackButton(int mostNoOfWindows)
        {
            previousWindows = new string[mostNoOfWindows];
        }

        public int getNoOfWindows()
        {
            return noOfWindows;
        }

        public string getPreviousWindow()
        {
            string value;
            if (noOfWindows > 0)
            {
                value = previousWindows[noOfWindows - 1];
            }
            else
            {
                value = "Error";
            }
            return value;
        }

        public void backButton(Window Window1)
        {

            Window currentWindow = Window1;
            if (noOfWindows > 0)
            {
                Window Window2 = (Window)Activator.CreateInstance(Type.GetType(previousWindows[noOfWindows - 1]));
                previousWindows[noOfWindows] = null;
                noOfWindows--;
                Window2.Show();
                currentWindow.Hide();
            }
            else
            {
                MessageBox.Show("No available previous Windows");
            }

        }

        public void backButton()
        {
            if (noOfWindows > 0)
            {
                Window Window2 = (Window)Activator.CreateInstance(Type.GetType(previousWindows[noOfWindows - 1]));
                previousWindows[noOfWindows] = null;
                noOfWindows--;
                Window2.Show();

            }
            else
            {
                MessageBox.Show("No available Windows");
            }

        }

        public void addCurrentWindow(Window Window1)
        {
            previousWindows[noOfWindows] = Window1.GetType().FullName;
            noOfWindows++;
        }

        public void addWindowAndOpenNextWindow(Window Window1, Window Window2)
        {
            addCurrentWindow(Window1);
            Window2.Show();
            Window1.Hide();

        }
        ~BackButton() { }
    }


    class Person
    {
        string id;
        string fname;
        string nic;

        public Person(string x, string y, string z)
        {
            id = x;
            fname = y;
            nic = z;
        }

        public string getID()
        {
            return id;
        }
        public string getFname()
        {
            return fname;
        }
        public string getNic()
        {
            return nic;
        }
        ~Person() { }
    }
    class Database
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public Database()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-99OKMBM;Initial Catalog=AttendanceLeaveManagemenDB;Integrated Security=True";
        }

        public void openCon()
        {
            con.Open();
        }
        public void closeCon()
        {
            con.Close();
        }

        public int Save_Del_Update(string query)
        {
            int rows;
            try
            {
                openCon();
            }
            catch (SqlException)
            {
                MessageBox.Show("Check the Database Connection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            cmd = new SqlCommand(query, con);
            rows = cmd.ExecuteNonQuery();
            cmd.Dispose();
            closeCon();
            return rows;
        }
        public DataTable GetData(string query)
        {
            try
            {
                openCon();
            }
            catch (SqlException)
            {
                MessageBox.Show("Check the Database Connection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closeCon();
            return dt;
        }

        public string ReadData(string query, string column)
        {
            string tb = "555";
            try
            {
                openCon();
            }
            catch (SqlException)
            {
                MessageBox.Show("Check the Database Connection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                tb = Convert.ToString(dr[column]);
            }
            else
            {
                MessageBox.Show("Either returns multiple values or does not return a value");
            }
            closeCon();

            return tb;

        }

        public Person ReadData1(string query)
        {
            string x = "";
            string y = "";
            string z = "";

            try
            {
                openCon();
            }
            catch (SqlException)
            {
                MessageBox.Show("Check the Database Connection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                x = Convert.ToString(dr["emp_id"]);
                y = Convert.ToString(dr["password"]);
                z = Convert.ToString(dr["desID"]);
            }
            else
            {
                MessageBox.Show("Either returns multiple values or does not return a value");
            }
            closeCon();
            Person p = new Person(x, y, z);
            return p;

        }
        ~Database() { }
    }
}






