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
    public partial class PatientsUserControl : UserControl
    {
        public PatientsUserControl()
        {
            InitializeComponent();
            //Setting custom styles to the data grid view
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#aaa");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            FillPatientsGridView();

            //Setting the click to the create button
            buttonCreate.Click += (s, e) =>
            {
                new AddPatientForm().ShowDialog();
            };

            //Setting the click on data grid view to the trigger history button
            //Click for each row
            dataGridView1.CellContentClick += (s, e) =>
            {
                int row = e.RowIndex;
                int column = e.ColumnIndex;
                int columnsCount = dataGridView1.Columns.Count;
                DataGridViewCell cell = dataGridView1.Rows[row].Cells[column];
                try
                {
                    if (cell is DataGridViewButtonCell && cell != null)
                    {
                        int id = 0;
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            if (col.HeaderText.ToLower().Trim() == "ID")
                            {
                                id = Convert.ToInt32(dataGridView1.Rows[row].Cells[col.Index].Value.ToString());
                            }
                        }
                        if (dataGridView1.Rows[row].Cells[1].Value != null)
                        {
                            int patientId = id;
                            new PatientHistory(patientId).ShowDialog();
                        }
                    }
                }
                catch { }
            };
        }

        public void FillPatientsGridView()
        {
            Helper.sqliteConn.Open();

            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = null;

            SQLiteCommand cmd = new SQLiteCommand(@"SELECT
    ID,
    TITLE,
    FIRSTNAME,
    LASTNAME,
    ADDRESS,
    TELEPHONENO,
    EMAIL,
    DATEOFBIRTH,
    AGE,
    CASE
        WHEN NHSPATIENT = 1 THEN 'True'
        WHEN NHSPATIENT = 0 THEN 'False'
    END AS NHSPATIENT
FROM PATIENT;", Helper.sqliteConn);

            DataTable dataTable = new DataTable();

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }

            dataGridView1.DataSource = dataTable;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "History";
            buttonColumn.Text = "History";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.FlatStyle = FlatStyle.Flat;

            buttonColumn.DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);

            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.Columns[0].Visible = false;

            Helper.sqliteConn.Close();
        }
    }
}
