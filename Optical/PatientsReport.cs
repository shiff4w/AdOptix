using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical
{
    public partial class PatientsReport : Form
    {
        public PatientsReport()
        {
            InitializeComponent();
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM patient p INNER JOIN PATIENT_HISTORY ph ON p.id = ph.patient_id ORDER BY APPOINTMENT_DATE DESC LIMIT 30", Helper.sqliteConn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Helper.sqliteConn.Close();

            chart1.Series.Clear();

            chart1.Series.Add("PatientHistory");

            chart1.Series["PatientHistory"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            int c = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                int patientId = Convert.ToInt32(row["ID"]);
                DateTime dateValue = Convert.ToDateTime(row["APPOINTMENT_DATE"]);
                string patientName = row["TITLE"] + " " + row["FIRSTNAME"] + " " + row["LASTNAME"];

                chart1.Series["PatientHistory"].Points.AddXY(c, dateValue);

                c++;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
