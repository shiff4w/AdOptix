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
    public partial class AddPatientForm : Form
    {
        bool previous_patient = false;
        public AddPatientForm()
        {
            InitializeComponent();
            //Filling up drop down lists
            foreach (string item in new string[] { "Mr", "Mrs.", "Miss", "Ms.", "Dr.", "Other" })
                comboBoxTitle.Items.Add(item);
            foreach (string item in new string[] { "True", "False" })
                comboBoxNHSPatient.Items.Add(item);
            foreach (string item in new string[] { "Sight Test", "CUES", "Post Catarct", "Follow-Up", "Other" })
                comboBoxAppointmentType.Items.Add(item);

            GetPatients();

            comboBoxPatients.SelectedIndexChanged += (s, e) =>
            {
                foreach (Control con in new Control[] {comboBoxTitle,comboBoxTitle, textBoxFirstName, textBoxLastName,
                                                        textBoxAddress, textBoxTelephone, textBoxEmail, comboBoxNHSPatient})
                {
                    if (comboBoxPatients.SelectedItem != null)
                    {
                        if (comboBoxPatients.Text.ToString().ToLower().Trim() == "none")
                        {
                            //con.Enabled = true;
                            previous_patient = false;
                            if (con is ComboBox)
                            {
                                ((ComboBox)con).SelectedIndex = -1;
                            }
                            else if (con is TextBox)
                            {
                                ((TextBox)con).Text = "";
                            }
                        }
                        else
                        {
                            //con.Enabled = false;
                            previous_patient = true;
                            FillPatientInformation(Convert.ToInt32(comboBoxPatients.SelectedValue.ToString()));
                        }
                    }
                }
            };

            //Setting the click to the create button
            buttonCreate.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(comboBoxTitle.Text) ||
                    string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                    string.IsNullOrWhiteSpace(textBoxTelephone.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxAppointmentType.Text))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                string title = string.IsNullOrWhiteSpace(comboBoxTitle.Text) ? string.Empty : comboBoxTitle.Text;
                string firstname = string.IsNullOrWhiteSpace(textBoxFirstName.Text) ? string.Empty : textBoxFirstName.Text;
                string lastname = string.IsNullOrWhiteSpace(textBoxLastName.Text) ? string.Empty : textBoxLastName.Text;
                string address = string.IsNullOrWhiteSpace(textBoxAddress.Text) ? string.Empty : textBoxAddress.Text;
                string telephone = string.IsNullOrWhiteSpace(textBoxTelephone.Text) ? string.Empty : textBoxTelephone.Text;
                string email = string.IsNullOrWhiteSpace(textBoxEmail.Text) ? string.Empty : textBoxEmail.Text;
                string age = (DateTime.Now.Year - dateTimePicker1.Value.Year).ToString();
                bool nhsPatient = comboBoxNHSPatient.Text == "True";
                string appointmentType = string.IsNullOrWhiteSpace(comboBoxAppointmentType.Text) ? string.Empty : comboBoxAppointmentType.Text;

                Helper.sqliteConn.Open();

                SQLiteCommand cmd = new SQLiteCommand(@"INSERT INTO PATIENT (TITLE, FIRSTNAME, LASTNAME, [ADDRESS], TELEPHONENO, EMAIL, DATEOFBIRTH, AGE, NHSPATIENT)
                                                VALUES (@title, @firstname, @lastname, @address, @telephone, @email, @birthday, @age, @nhs_patient);
                                                SELECT last_insert_rowid();", Helper.sqliteConn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@telephone", telephone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@birthday", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@nhs_patient", nhsPatient);

                //Insert and get the inserted patient id
                int patientId;
                if (previous_patient == false)
                    patientId = Convert.ToInt32(cmd.ExecuteScalar());
                else patientId = Convert.ToInt32(comboBoxPatients.SelectedValue.ToString());

                cmd.Dispose();

                cmd = new SQLiteCommand("INSERT INTO PATIENT_HISTORY (PATIENT_ID, APPOINTMENTTYPE, APPOINTMENT_DATE) VALUES(@patient_id, @appointment_type, @date)", Helper.sqliteConn);
                cmd.Parameters.AddWithValue("@patient_id", patientId);
                cmd.Parameters.AddWithValue("@appointment_type", appointmentType);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                cmd.ExecuteNonQuery();

                Helper.sqliteConn.Close();

                Application.OpenForms.OfType<MainDashboard>().FirstOrDefault().FillPatientsGridView();

                MessageBox.Show("Added Successfully.");

                this.Close();
            };
        }

        public void FillPatientInformation(int patientId)
        {
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("select * from PATIENT where ID =" + patientId, Helper.sqliteConn);

            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                string title = "" + dr[1];
                string firstname = "" + dr[2];
                string lastname = "" + dr[3];
                string address = "" + dr[4];
                string telephone = "" + dr[5];
                string email = "" + dr[6];
                string date = "" + dr[7];
                string nhsPatient = "" + dr[9];

                comboBoxTitle.SelectedItem = title;
                textBoxFirstName.Text = firstname;
                textBoxLastName.Text = lastname;
                textBoxAddress.Text = address;
                textBoxTelephone.Text = telephone;
                textBoxEmail.Text = email;
                dateTimePicker1.Value = DateTime.Parse(date);
                comboBoxNHSPatient.SelectedItem = nhsPatient == "1" ? "True" : "False";
            }

            dr.Close();

            Helper.sqliteConn.Close();
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

            //Create columns for the data table
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("fullname", typeof(string));

            dt.Rows.Add(0, "None");

            //Fill the table with the patient's data
            adapter.Fill(dt);

            //Fill in the combobox with the patient's names, and specify id values for each patient
            comboBoxPatients.DataSource = dt;
            comboBoxPatients.ValueMember = "id";
            comboBoxPatients.DisplayMember = "fullname";

            Helper.sqliteConn.Close();
        }

        private void comboBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}