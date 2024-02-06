﻿using System;
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
    public partial class PrescriptionDetails : Form
    {
        public PrescriptionDetails(int eyeTestId)
        {
            InitializeComponent();
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("select * from PATIENT where id in (select PATIENT_ID from EYE_TEST where ID = " + eyeTestId + ")", Helper.sqliteConn);

            SQLiteDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                string name = dr[1] + " " + dr[2] + " " + dr[3];
                labelPatient.Text = name;

                int id = Convert.ToInt32(dr[0].ToString());

                //Setting the click to the details button
                buttonDetails.Click += (s, e) =>
                {
                    ShowDetails(id);
                };
            }

            dr.Close();
            cmd.Dispose();

            cmd = new SQLiteCommand("select * from PRESCRIPTION where EYE_TEST_ID =" + eyeTestId, Helper.sqliteConn);

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                string lens_type = "" + dr[2];
                string notes = "" + dr[3];

                labelLensType.Text = lens_type;
                labelNotes.Text = notes;
            }

            Helper.sqliteConn.Close();
        }

        public void ShowDetails(int ID)
        {
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("select * from patient where ID = " + ID, Helper.sqliteConn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                //Fetching the selection result
                dr.Read();
                string title = "" + dr[1];
                string name = dr[2] + " " + dr[3];
                string address = "" + dr[4];
                string telephone = "" + dr[5];
                string email = "" + dr[6];
                string dateOfBirth = "" + dr[7];
                string age = "" + dr[8];
                string nhsPatient = "" + dr[9];

                string message = "ID: " + ID + "\n\n" +
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
        }
    }
}
