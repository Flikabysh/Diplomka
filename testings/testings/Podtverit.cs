using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace diplomatik
{
    public partial class Podtverit : Form
    {
        public static string lg;
        public static string pssw;
        public static string email;
        public static bool vx;

        int m = 0, s = 0;
        string[] Rur = new string[6];
        Random rannd = new Random();
        int cho = 0;

        bool vxodims = Podtverit.vx;
        string tyr = Podtverit.email;
        string vyr = Podtverit.lg;
        string myr = Podtverit.pssw;

        public Podtverit()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            button2.Enabled = false;

            textBox1.TabIndex = 0;
            textBox1.KeyUp += new KeyEventHandler(textBox1_KeyUp);
            textBox2.KeyUp += new KeyEventHandler(textBox2_KeyUp);
            textBox3.KeyUp += new KeyEventHandler(textBox3_KeyUp);
            textBox4.KeyUp += new KeyEventHandler(textBox4_KeyUp);
            textBox5.KeyUp += new KeyEventHandler(textBox5_KeyUp);
            textBox6.KeyUp += new KeyEventHandler(textBox6_KeyUp);
        }

        private void Podtverit_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (m > 59)
            {
                button2.Enabled = true;
                timer1.Stop();
                m = 0;
                s = 0;
                label8.Text = "00";
                label5.Text = "00";
            }

            for (int i = 0; i < 6; i++)
            {
                Rur[i] = Convert.ToString(rannd.Next(0, 9));
            }

            string far = Convert.ToString(Rur[0]) + Convert.ToString(Rur[1]) + Convert.ToString(Rur[2]) +
                Convert.ToString(Rur[3]) + Convert.ToString(Rur[4]) + Convert.ToString(Rur[5]);

            SendMes(lg);
        }

        private void SendMes(string lg)
        {
            string far = Convert.ToString(Rur[0]) + Convert.ToString(Rur[1]) + Convert.ToString(Rur[2]) +
                Convert.ToString(Rur[3]) + Convert.ToString(Rur[4]) + Convert.ToString(Rur[5]);

            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "slobodan.avia@mail.ru";
            string smtpPassword = "BEm72ae91jmgQwLgQ4jd";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(email);
                    if (vxodims == false)
                        mailMessage.Subject = "Здравствуйте, " + lg + "!";
                    else
                    {
                        mailMessage.Subject = "С возвращением, Пользователь!";
                    }
                    mailMessage.Body = $"Ваш проверочный код для сервиса СЛОБОДАН: \r\n{far} \r\n " +
                        $" \r\n" +
                        $"Если вы ничего не делали, то просто проигнорируйте";

                    try
                    {
                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Сообщение успешно отправлено", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Что-то пошло не так: " + $"{ex.Message}");
                    }
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bur = Convert.ToString(textBox1.Text) + Convert.ToString(textBox2.Text) +
                Convert.ToString(textBox3.Text) + Convert.ToString(textBox4.Text) +
                Convert.ToString(textBox5.Text) + Convert.ToString(textBox6.Text);

            string far = Convert.ToString(Rur[0]) + Convert.ToString(Rur[1]) + Convert.ToString(Rur[2]) +
                Convert.ToString(Rur[3]) + Convert.ToString(Rur[4]) + Convert.ToString(Rur[5]);

            CodeValidation CodeV = new CodeValidation();
            {
                if (CodeV.CodeVal(bur) == false)
                {
                    return;
                }
            }

            if (far == bur & vxodims == false)
            {
                Registriki(vyr, myr, tyr);
            }
            else if (far == bur & vxodims == true)
            {
                Vxod(vyr, tyr);
            }
            else
            {
                MessageBox.Show("Неправильный код", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);                                                                   //uwu за диплом пять
                return;
            }
        }

        private void Vxod(string myr, string tyr)
        {
            /*
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = Chmonik\FUKI; Initial Catalog = DBotBoga; Integrated Security = True");
                con.Open();
                SqlCommand command = new SqlCommand("select password, email from [dbo].[TDB] where password = @Pass and email = @Email", con);
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = myr;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = tyr;
                command.ExecuteNonQuery();
                //DataSend.text = vyr;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + ex.ToString());
                return;
            }
            MainForm frm = new MainForm();
            frm.Show();
            
            testings.Properties.Settings.Default.voshol = true;
            testings.Properties.Settings.Default.Save();

            MessageBox.Show("Приложение перезапустится для дальнейшей работы", "Внимание!");
            Application.Exit();
            */

          
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = Chmonik\FUKI; Initial Catalog = DBotBoga; Integrated Security = True"))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("select password, email from [dbo].[TDB] where password = @Pass and email = @Email", con))
                    {
                        command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = myr;
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = tyr;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Successful login
                                MainForm frm = new MainForm();
                                frm.Show();

                                testings.Properties.Settings.Default.voshol = true;
                                testings.Properties.Settings.Default.Save();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }


        }

        private void Registriki(string vyr, string myr, string tyr)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = CHMONIK\FUKI; Initial Catalog = DBotBoga; Integrated Security = True");
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[TDB] (login, password, email) VALUES (@Log, @Pass, @Email)", con);
                command.Parameters.Add("@Log", SqlDbType.VarChar).Value = vyr;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = myr;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = tyr;
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Новый пользователь добавлен!");

                MainForm frm = new MainForm();
                frm.Show();

                testings.Properties.Settings.Default.voshol = true;
                testings.Properties.Settings.Default.Save();

                MessageBox.Show("Приложение перезапустится для дальнейшей работы", "Внимание!");
                Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + ex.ToString());
                return;
            }

            


        }
        private void button2_Click(object sender, EventArgs e)
        {
            cho++;
            if(cho == 3)
            {
                MessageBox.Show("Внимание!", "Слишком много попыток!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            button2.Enabled = false;
            timer1.Start();

            for (int i = 0; i < 6; i++)
            {
                Rur[i] = Convert.ToString(rannd.Next(0, 9));
            }

            string far = Convert.ToString(Rur[0]) + Convert.ToString(Rur[1]) + Convert.ToString(Rur[2]) +
                Convert.ToString(Rur[3]) + Convert.ToString(Rur[4]) + Convert.ToString(Rur[5]);

            string bur = Convert.ToString(textBox1.Text) + Convert.ToString(textBox2.Text) +
                Convert.ToString(textBox3.Text) + Convert.ToString(textBox4.Text) +
                Convert.ToString(textBox5.Text) + Convert.ToString(textBox6.Text);
            SendMes(lg);

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(textBox1.TextLength == textBox1.MaxLength)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.TextLength == textBox2.MaxLength)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.TextLength == textBox3.MaxLength)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox4.TextLength == textBox4.MaxLength)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox5.TextLength == textBox5.MaxLength)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox6.TextLength == textBox6.MaxLength)
            {
                textBox1.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(s < 59)
            {
                s++;
                if (s < 10)
                    label5.Text = "0" + s.ToString();
                else
                    label5.Text = s.ToString();
            }
            else
            {
                if (m < 59)
                {
                    m++;
                    if (m < 10)
                        label8.Text = "0" + m.ToString();
                    else
                        label8.Text = m.ToString();
                    s = 0;
                    label5.Text = "00";
                }
                else
                {
                    m = 0;
                    label8.Text = "00";
                }
            }
            if(label8.Text == "01")
            {
                timer1.Stop();
                m = 0;
                s = 0;
                label8.Text = "00";
                label5.Text = "00";
                button2.Enabled = true;
            }
        }
    }
}
