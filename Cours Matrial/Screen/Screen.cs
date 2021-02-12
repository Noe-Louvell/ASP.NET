using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen
{
    public partial class Screen : Form
    {

        Inter a = new Inter();

        public static string textDisplay = "";
        public Screen()
        {
            InitializeComponent();
            panel2.Visible = false;
            Inter ecrSimu = new Inter();
            ecrSimu.Show();
            ecrSimu.clickBtn += a_clickBtn;
        }

        private void a_clickBtn(string param1)
        {
            textDisplay = param1;
            if (param1 == "Insérer votre carte")
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }

            else if (param1 == "Retirer votre carte")
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }
        private void Screen_Load(object sender, EventArgs e)
        {
         
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
