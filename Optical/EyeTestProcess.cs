using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical
{
    public partial class EyeTestProcess : Form
    {
        public EyeTestProcess(Form parent, int eyeTestId)
        {
            InitializeComponent();
            //Setting the gif image to a picture box
            pictureBoxProcess.ImageLocation = @"resources\gif\process.gif";

            //Setting click to proceed button
            buttonProceed.Click += (s, e) =>
            {
                new Prescription(this, eyeTestId).ShowDialog();
            };

            //Close this form's parent
            this.FormClosed += (s, e) =>
            {
                parent.Close();
            };
        }

        private void EyeTestProcess_Load(object sender, EventArgs e)
        {

        }
    }
}
