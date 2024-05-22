using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomatik
{
    public partial class Vxodit : Form
    {
        public Vxodit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                MessageBox.Show("Поле с паролем пустое!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PasswordValid PassV = new PasswordValid();
            {
                if (PassV.PasswordVal(textBox2.Text) == false)
                {
                    return;
                }

            }

            string ff = textBox3.Text;
            if (string.IsNullOrWhiteSpace(ff) | textBox3.Text == "Эл. почта")
            {
                MessageBox.Show("Нужно заполнить почту!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Podtverit.email = textBox3.Text;
            Podtverit.pssw = textBox2.Text;
            Podtverit.vx = true;

            Podtverit frm = new Podtverit();
            frm.ShowDialog();
        }

        private void Vxodit_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Podtverit.vx = false;
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = null;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "Эл. почта")
            {
                textBox3.Text = null;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
