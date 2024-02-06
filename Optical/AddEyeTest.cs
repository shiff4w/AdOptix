using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Optical
{
    public partial class AddEyeTest : Form
    {
        public AddEyeTest()
        {
            InitializeComponent();
            //Setting custom styles to the data grid view
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ddd");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            //Filling the eye combobox
            foreach (string item in new string[] { "Left", "Right" })
            {
                comboBoxEye.Items.Add(item);
            }

            GetPatients();

            //Setting the click to the view information button
            buttonViewInformation.Click += (s, e) =>
            {
                if (comboBoxPatient.SelectedValue == null)
                {
                    MessageBox.Show("Please select a patient.");
                    return;
                }

                Helper.sqliteConn.Open();

                SQLiteCommand cmd = new SQLiteCommand("select * from patient where id = " + comboBoxPatient.SelectedValue, Helper.sqliteConn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //Fetching the selection result
                    dr.Read();
                    string id = "" + dr[0];
                    string title = "" + dr[1];
                    string name = dr[2] + " " + dr[3];
                    string address = "" + dr[4];
                    string telephone = "" + dr[5];
                    string email = "" + dr[6];
                    string dateOfBirth = "" + dr[7];
                    string age = "" + dr[8];
                    string nhsPatient = "" + dr[9];

                    string message = "ID: " + id + "\n\n" +
                                     "Title: " + title + "\n\n" +
                                     "Name: " + name + "\n\n" +
                                     "Address: " + address + "\n\n" +
                                     "Telephone: " + telephone + "\n\n" +
                                     "Email: " + email + "\n\n" +
                                     "Date of Birth: " + dateOfBirth + "\n\n" +
                                     "Age: " + age + "\n\n" +
                                     "NHS Patient: " + nhsPatient;
                    MessageBox.Show(message, "Patient Information");
                }

                dr.Close();

                Helper.sqliteConn.Close();
            };

            //Setting the click to the add eye test Button
            buttonAddEyeTest.Click += (s, e) =>
            {
                if (comboBoxEye.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(textBoxSphericalPower.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCylinderPower.Text) ||
                    string.IsNullOrWhiteSpace(textBoxVisualAcuity.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAxis.Text) ||
                    string.IsNullOrWhiteSpace(textBoxIntraocularPressure.Text))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                string whichEye = comboBoxEye.Text;
                string sp = textBoxSphericalPower.Text;
                string cp = textBoxCylinderPower.Text;
                string va = textBoxVisualAcuity.Text;
                string axis = textBoxAxis.Text;
                string ip = textBoxIntraocularPressure.Text;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string whichEyeColumn = row.Cells[0].Value.ToString();
                        if (whichEye.ToLower().Trim() == whichEyeColumn.ToLower().Trim())
                        {
                            MessageBox.Show("(" + whichEyeColumn + ") eye data already exists.");
                            return;
                        }
                    }
                }

                dataGridView1.Rows.Add(whichEye, sp, cp, va, axis, ip);
            };

            //Setting the click to the create button
            buttonCreate.Click += (s, e) =>
            {
                if (comboBoxPatient.SelectedItem == null ||
                    dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Enter data in all fields.");
                    return;
                }

                //Generate json from data grid view
                //to store it in the database table as a string json field
                StringBuilder json = new StringBuilder();
                json.Append("[\n");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        json.Append("{\n");
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            string columnName = dataGridView1.Columns[i].HeaderText;
                            string columnValue = row.Cells[i].Value.ToString();

                            json.Append($"\"{columnName}\": \"{columnValue}\"");
                            if (i < dataGridView1.Columns.Count - 1)
                            {
                                json.Append(",");
                            }
                            json.Append("\n");
                        }
                        json.Append("}");
                        if (row.Index < dataGridView1.Rows.Count - 2)
                        {
                            json.Append(",");
                        }
                        json.Append("\n");
                    }
                }

                json.Append("]");

                int patientId = Convert.ToInt32(comboBoxPatient.SelectedValue.ToString());

                Helper.sqliteConn.Open();

                SQLiteCommand cmd = new SQLiteCommand(@"INSERT INTO EYE_TEST (PATIENT_ID, JSON_DATA, EYE_TEST_DATE)
                                                VALUES (@patient_id, @json_data, @date);
                                                SELECT last_insert_rowid();", Helper.sqliteConn);
                cmd.Parameters.AddWithValue("@patient_id", patientId);
                cmd.Parameters.AddWithValue("@json_data", json.ToString());
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                int eyeTestId = Convert.ToInt32(cmd.ExecuteScalar());

                Helper.sqliteConn.Close();

                Application.OpenForms.OfType<MainDashboard>().FirstOrDefault().FillEyeTestsGridView();

                new EyeTestProcess(this, eyeTestId).ShowDialog();
            };
        }

        public void GetPatients()
        {
            Helper.sqliteConn.Open();

            //Select all patients
            SQLiteCommand cmd = new SQLiteCommand("select id,title || ' ' || firstname || ' ' || lastname as 'fullname' from patient", Helper.sqliteConn);

            //Create a data adapter for the sql command
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            //Create a table
            DataTable dt = new DataTable();

            //Fill the table with the patient's data
            adapter.Fill(dt);

            //Fill in the combobox with patient's names and specify id values for each patient
            comboBoxPatient.DataSource = dt;
            comboBoxPatient.ValueMember = "id";
            comboBoxPatient.DisplayMember = "fullname";

            Helper.sqliteConn.Close();
        }

        private void textBoxSphericalPower_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
