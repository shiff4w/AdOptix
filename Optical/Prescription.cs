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
    public partial class Prescription : Form
    {
        public Prescription(Form parent, int eyeTestId)
        {
            InitializeComponent();
            //Filling the combobox with data
            foreach (string item in new string[] { "Single Vision Lenses", "Bifocal Lenses", "Progressive Lenses", "Reading Glasses",
                                                    "Computer Glasses", "Photochromic Lenses"})
            {
                comboBoxLensType.Items.Add(item);
            }

            //Setting the click to the confirm button
            buttonConfirm.Click += (s, e) =>
            {
                if (comboBoxLensType.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(richTextBoxPrescription.Text))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                int patientId = Convert.ToInt32(comboBoxLensType.SelectedValue);
                string lensType = comboBoxLensType.Text;
                string prescription = richTextBoxPrescription.Text;

                Helper.sqliteConn.Open();

                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO PRESCRIPTION (EYE_TEST_ID, LENS_TYPE, NOTES) VALUES (@id, @lens_type, @notes)", Helper.sqliteConn);
                cmd.Parameters.AddWithValue("@id", eyeTestId);
                cmd.Parameters.AddWithValue("@lens_type", lensType);
                cmd.Parameters.AddWithValue("@notes", prescription);

                cmd.ExecuteNonQuery();

                Helper.sqliteConn.Close();

                MessageBox.Show("Added Successfully.");

                this.Close();
            };

            //Close the parent form
            this.FormClosed += (s, e) =>
            {
                parent.Close();
            };
        }

        private void Prescription_Load(object sender, EventArgs e)
        {

        }
    }
}
