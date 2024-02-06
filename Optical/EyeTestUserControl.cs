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
    public partial class EyeTestUserControl : UserControl
    {
        bool filter = false;
        int patientID = 0;
        public EyeTestUserControl()
        {
            InitializeComponent();
            //Setting custom styles to the data grid view
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#aaa");
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            FillEyeTestsGridView();

            //Setting the click to thr create button
            buttonCreate.Click += (s, e) =>
            {
                new AddEyeTest().ShowDialog();
            };

            //Setting the click to the filter button
            buttonFilter.Click += (s, e) =>
            {
                new Filter().ShowDialog();
            };

            //Setting the click on data grid view to trigger the prescription button
            //click foreach row
            dataGridView1.CellContentClick += (s, e) =>
            {
                int row = e.RowIndex;
                int column = e.ColumnIndex;

                DataGridViewCell cell = dataGridView1.Rows[row].Cells[column];
                try
                {
                    if(cell is DataGridViewButtonCell && cell != null)
                    {
                        if(dataGridView1.Rows[row].Cells[14].Value != null)
                        {
                            int eyeTestId = Convert.ToInt32(dataGridView1.Rows[row].Cells[14].Value.ToString());
                            new PrescriptionDetails(eyeTestId).ShowDialog();
                        }
                    }
                }
                catch { }
            };
        }

        public void FillEyeTestsGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 15;

            dataGridView1.Columns[0].Name = "Patient Name";

            dataGridView1.Columns[1].Name = "Eye (Left)";
            dataGridView1.Columns[2].Name = "SP (Left)";
            dataGridView1.Columns[3].Name = "CP (Left)";
            dataGridView1.Columns[4].Name = "VA (Left)";
            dataGridView1.Columns[5].Name = "Axis (Left)";
            dataGridView1.Columns[6].Name = "IP (Left)";

            dataGridView1.Columns[7].Name = "Eye (Right)";
            dataGridView1.Columns[8].Name = "SP (Right)";
            dataGridView1.Columns[9].Name = "CP (Right)";
            dataGridView1.Columns[10].Name = "VA (Right)";
            dataGridView1.Columns[11].Name = "Axis (Right)";
            dataGridView1.Columns[12].Name = "IP (Right)";

            dataGridView1.Columns[13].Name = "Eye Test Date";

            dataGridView1.Columns[14].Name = "Id";
            dataGridView1.Columns[14].Visible = false;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Prescription";
            buttonColumn.Text = "Prescription";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.FlatStyle = FlatStyle.Flat;

            buttonColumn.DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);

            dataGridView1.Columns.Add(buttonColumn);

            Helper.sqliteConn.Open();

            string query = filter ? "select (select firstname || ' ' || lastname from patient  where id=ET.PATIENT_ID),* from EYE_TEST ET where ET.PATIENT_ID = " + patientID :
                "select (select firstname || ' ' || lastname from patient  where id=ET.PATIENT_ID),* from EYE_TEST ET";

            SQLiteCommand cmd = new SQLiteCommand(query, Helper.sqliteConn);

            string temp = "";
            string[] array;

            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string ID = "" + dr[1];
                    string name = "" + dr[0];
                    string json = "" + dr[3];
                    string date;
                    if (dr[4] != null && !string.IsNullOrWhiteSpace(dr[4].ToString()) && dr[4].ToString().IndexOf(" ") != -1)
                        date = dr[4].ToString().Split(' ')[0];
                    else date = "" + dr[4];

                    string eyeLeft = "Left";
                    string spLeft = "";
                    string cpLeft = "";
                    string vaLeft = "";
                    string axisLeft = "";
                    string ipLeft = "";

                    string eyeRight = "Right";
                    string spRight = "";
                    string cpRight = "";
                    string vaRight = "";
                    string axisRight = "";
                    string ipRight = "";

                    if(json.ToLower().IndexOf("left") != -1)
                    {
                        //[ { "Eye": "Left", "SP": "1", "CP": "2", "VA": "34", "Axis": "4", "IP": "5" } ]
                        temp = json.Substring(json.ToLower().IndexOf("left"));
                        temp = temp.Substring(temp.IndexOf(",") + 1);
                        temp = temp.Remove(temp.IndexOf("}")).Trim();

                        array = temp.Split(',');

                        spLeft = array[0].Split(':')[1].Replace("\"", "").Trim();
                        cpLeft = array[1].Split(':')[1].Replace("\"", "").Trim();
                        vaLeft = array[2].Split(':')[1].Replace("\"", "").Trim();
                        axisLeft = array[3].Split(':')[1].Replace("\"", "").Trim();
                        ipLeft = array[4].Split(':')[1].Replace("\"", "").Trim();
                    }

                    if (json.ToLower().IndexOf("right") != -1)
                    {
                        //[ { "Eye": "Right", "SP": "1", "CP": "2", "VA": "34", "Axis": "4", "IP": "5" } ]
                        temp = json.Substring(json.ToLower().IndexOf("right"));
                        temp = temp.Substring(temp.IndexOf(",") + 1);
                        temp = temp.Remove(temp.IndexOf("}")).Trim();

                        array = temp.Split(',');

                        spRight = array[0].Split(':')[1].Replace("\"", "").Trim();
                        cpRight = array[1].Split(':')[1].Replace("\"", "").Trim();
                        vaRight = array[2].Split(':')[1].Replace("\"", "").Trim();
                        axisRight = array[3].Split(':')[1].Replace("\"", "").Trim();
                        ipRight = array[4].Split(':')[1].Replace("\"", "").Trim();
                    }

                    dataGridView1.Rows.Add(name, eyeLeft, spLeft, cpLeft, vaLeft, axisLeft, ipLeft, eyeRight,spRight,cpRight,
                                            vaRight, axisRight, ipRight, date, ID); 
                }
            }

            dr.Close();

            Helper.sqliteConn.Close();
        }

        public void FillEyeTestsGridViewWithFilter(int patientID)
        {
            this.patientID = patientID;
            filter = true;
            FillEyeTestsGridView();
            filter = false;
        }
    }
}
