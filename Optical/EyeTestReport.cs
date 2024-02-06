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
    public partial class EyeTestReport : Form
    {
        public EyeTestReport()
        {
            InitializeComponent();
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM patient p INNER JOIN EYE_TEST et ON p.id = et.patient_id ORDER BY et.EYE_TEST_DATE DESC LIMIT 30", Helper.sqliteConn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Helper.sqliteConn.Close();

            chart1.Series.Clear();

            chart1.Series.Add("EyeTest");

            chart1.Series["EyeTest"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            int c = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                int patientId = Convert.ToInt32(row["id"]);
                DateTime dateValue = Convert.ToDateTime(row["EYE_TEST_DATE"]);

                chart1.Series["EyeTest"].Points.AddXY(c, dateValue);

                c++;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
