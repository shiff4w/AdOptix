using System.Data;
using System.Data.SQLite;

namespace Optical
{
    public partial class Filter : Form
    {
        public Filter()
        {
            InitializeComponent();
            GetPatients();

            //Setting the click to the apply button
            buttonApplyFilter.Click += (s, e) =>
            {
                if (comboBoxPatients.SelectedItem == null)
                {
                    MessageBox.Show("Choose a patient.");
                    return;
                }

                int ID = Convert.ToInt32(comboBoxPatients.SelectedValue);
                Application.OpenForms.OfType<MainDashboard>().FirstOrDefault().FillEyeTestsGridViewWithFilter(ID);

                this.Close();
            };

            //Setting the click to the reset button
            buttonResetFilter.Click += (s, e) =>
            {
                Application.OpenForms.OfType<MainDashboard>().FirstOrDefault().FillEyeTestsGridView();
                this.Close();
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

            //Fill in the combobox with the patient's names, and specify id values for each patient
            comboBoxPatients.DataSource = dt;
            comboBoxPatients.ValueMember = "ID";
            comboBoxPatients.DisplayMember = "fullname";

            Helper.sqliteConn.Close();
        }

        private void Filter_Load(object sender, EventArgs e)
        {

        }
    }
}
