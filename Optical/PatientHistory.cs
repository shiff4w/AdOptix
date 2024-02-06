using System.Data;
using System.Data.SQLite;

namespace Optical
{
    public partial class PatientHistory : Form
    {
        public PatientHistory(int patientId)
        {
            InitializeComponent();
            //Setting custom styles to the data grid view
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ddd");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            FillPatientsHistoryGridView(patientId);
        }

        public void FillPatientsHistoryGridView(int patientId)
        {
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT ID, PATIENT_hID, APPOINTMENTTYPE, DATE(APPOINTMENT_DATE) FROM PATIENT_HISTORY where PATIENT_ID = " + patientId, Helper.sqliteConn);

            DataTable dataTable = new DataTable();

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;

            Helper.sqliteConn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
