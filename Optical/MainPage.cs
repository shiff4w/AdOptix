namespace Optical
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            //Setting images to picture boxes
            Bitmap close = new Bitmap(Image.FromFile(@"resources\icons\close.png"));
            pictureBoxClose.Image = close;
            Bitmap minimize = new Bitmap(Image.FromFile(@"resources\icons\minimize.png"));
            pictureBoxMinimize.Image = minimize;
            Bitmap logo = new Bitmap(Image.FromFile(@"resources\images\logo.png"));
            pictureBoxLogo.Image = logo;

            pictureBoxClose.Click += (s, e) =>
            {
                this.Close();
            };

            pictureBoxMinimize.Click += (s, e) =>
            {
                this.WindowState = FormWindowState.Minimized;
            };

            //Setting the click to the login button
            buttonLogin.Click += (s, e) =>
            {
                new LoginPage().ShowDialog();
            };
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }
    }
}