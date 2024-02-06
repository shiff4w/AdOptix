using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Optical
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();

            this.SizeChanged += (s, e) =>
            {
                dashboardContainer.Left = (panel1.Width - dashboardContainer.Width) / 2;
                dashboardContainer.Top = (panel1.Height - dashboardContainer.Height) / 2;
            };
        }

        public void GetData()
        {
            Helper.sqliteConn.Open();

            string patientsRecordsCount = new SQLiteCommand("select count(*) from PATIENT", Helper.sqliteConn).ExecuteScalar().ToString();
            labelPatientRecordsValue.Text = patientsRecordsCount;
            labelPatientRecordsKey.Left = labelPatientRecordsValue.Width + labelPatientRecordsValue.Left - 10;

            string patientsHistoryCount = new SQLiteCommand("select count(*) from PATIENT_HISTORY", Helper.sqliteConn).ExecuteScalar().ToString();
            labelPatientsHistoryValue.Text = patientsHistoryCount;
            labelPatientsHistoryKey.Left = labelPatientsHistoryValue.Width + labelPatientsHistoryValue.Left - 10;

            string eyeTestsCount = new SQLiteCommand("select count(*) from EYE_TEST", Helper.sqliteConn).ExecuteScalar().ToString();
            labelEyeTestRecordsValue.Text = eyeTestsCount;
            labelEyeTestRecordsKey.Left = labelEyeTestRecordsValue.Width + labelEyeTestRecordsValue.Left - 10;

            string prescriptionsCount = new SQLiteCommand("select count(*) from PRESCRIPTION", Helper.sqliteConn).ExecuteScalar().ToString();
            labelPrescriptionsValue.Text = prescriptionsCount;
            labelPrescriptionsKey.Left = labelPrescriptionsValue.Width + labelPrescriptionsValue.Left - 10;

            string usersCount = new SQLiteCommand("select count(*) from Users", Helper.sqliteConn).ExecuteScalar().ToString();
            labelUsersValue.Text = usersCount;
            labelUsersKey.Left = labelUsersValue.Width + labelUsersValue.Left - 10;

            Helper.sqliteConn.Close();
        }

        private void dashboardContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
