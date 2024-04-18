using System;
using System.Windows.Forms;

namespace diplomatik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MessageBox.Show("Для начала использования нашего приложения, вам нужно пройти регистрацию/вход",
                "Добро пожаловать!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Проверка тексбоксов

            if (textBox1.Text == "Логин")
            {
                
                MessageBox.Show("Поле с логином пустое!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginValidation LoginV = new LoginValidation();
            {
                if(LoginV.LogVal(textBox1.Text) == false)
                {
                    return;
                }
            }

            if (textBox2.Text == "Пароль")
            {
                MessageBox.Show("Поле с паролем пустое!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PasswordValid PassV = new PasswordValid();
            {
                if(PassV.PasswordVal(textBox2.Text) == false)
                {
                    return;
                }

            }

            if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("Пароль и логин не должны совпадать!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ff = textBox3.Text;
            if(string.IsNullOrWhiteSpace(ff) | textBox3.Text == "Эл. почта")
            {
                MessageBox.Show("Нужно заполнить почту!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Самое интересное

            Podtverit.email = textBox3.Text;
            Podtverit.lg = textBox1.Text;
            Podtverit.pssw = textBox2.Text;

            Podtverit frm = new Podtverit();
            frm.ShowDialog();
        }
        
        private void textBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Логин")
            {
                textBox1.Text = null;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = null;
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Эл. почта")
            {
                textBox3.Text = null;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
