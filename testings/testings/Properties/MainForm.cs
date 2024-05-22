using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace diplomatik
{
    public partial class MainForm : Form
    {
        public static string city1; public static int price1;
        public static string city2; public static int price2;
        public static string city3; public static int price3;
        public static string city4; public static int price4;
        public static string city5; public static int price5;
        public static string city6; public static int price6;
        public static string city7; public static int price7;
        public static string city8; public static int price8;
        public static string city9; public static int price9;
        public static string city10; public static int price10;

        public static string punkt1; public static string punkt3;
        public static string punkt2; public static string punkt4;
        public static string viezd; public static string viezd2;
        public static string priezd; public static string priezd2;
        public static int pricePons; public static int pricePons2;

        string pnkt1 = MainForm.punkt1; string pnkt3 = MainForm.punkt3;
        string pnkt2 = MainForm.punkt2; string pnkt4 = MainForm.punkt4;
        string vzd = MainForm.viezd; string vzd2 = MainForm.viezd2;
        string przd = MainForm.priezd; string przd2 = MainForm.priezd2;
        int prc = MainForm.pricePons; int prc2 = MainForm.pricePons2;

        string ct1 = MainForm.city1; int pr1 = MainForm.price1;
        string ct2 = MainForm.city2; int pr2 = MainForm.price2;
        string ct3 = MainForm.city3; int pr3 = MainForm.price3;
        string ct4 = MainForm.city4; int pr4 = MainForm.price4;
        string ct5 = MainForm.city5; int pr5 = MainForm.price5;
        string ct6 = MainForm.city6; int pr6 = MainForm.price6;
        string ct7 = MainForm.city7; int pr7 = MainForm.price7;
        string ct8 = MainForm.city8; int pr8 = MainForm.price8;
        string ct9 = MainForm.city9; int pr9 = MainForm.price9;
        string ct10 = MainForm.city10; int pr10 = MainForm.price10;

        int tyty = 0;

        public MainForm()
        {
            InitializeComponent();

            tyty++;
            string connectionString = @"Data Source = CHMONIK\FUKI ;Initial Catalog=DBotBoga;Integrated Security=True";

            List<Kykrinis> kykrini = new List<Kykrinis>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT id, city, price FROM CDB", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Kykrinis kykrinis = new Kykrinis
                    {
                        id = (int)reader["id"],
                        city = reader["city"].ToString(),
                        price = (int)reader["price"]
                    };

                    kykrini.Add(kykrinis);
                }

                reader.Close();
            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 1)
                {
                    ct1 = cityAndPrice.city;
                    pr1 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 2)
                {
                    ct2 = cityAndPrice.city;
                    pr2 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 3)
                {
                    ct3 = cityAndPrice.city;
                    pr3 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 4)
                {
                    ct4 = cityAndPrice.city;
                    pr4 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 5)
                {
                    ct5 = cityAndPrice.city;
                    pr5 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 6)
                {
                    ct6 = cityAndPrice.city;
                    pr6 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 7)
                {
                    ct7 = cityAndPrice.city;
                    pr7 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 8)
                {
                    ct8 = cityAndPrice.city;
                    pr8 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 9)
                {
                    ct9 = cityAndPrice.city;
                    pr9 = cityAndPrice.price;
                    break;
                }

            }

            foreach (Kykrinis cityAndPrice in kykrini)
            {
                if (cityAndPrice.id == 10)
                {
                    ct10 = cityAndPrice.city;
                    pr10 = cityAndPrice.price;
                    break;
                }

            }

            string[] cityMassiv = { ct1, ct2, ct3, ct4, ct5, ct6, ct7, ct8, ct9, ct10 };
            int[] priceMassiv = { pr1, pr2, pr3, pr4, pr5, pr6, pr7, pr8, pr9, pr10 };
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                int fig1 = random.Next(0, cityMassiv.Length);
                int fig2;

                do
                {
                    fig2 = random.Next(0, cityMassiv.Length);
                } while (fig2 == fig1);



                int hours = random.Next(0, 24); // Генерируем случайное количество часов от 0 до 23
                int minutes = random.Next(0, 60); // Генерируем случайное количество минут от 0 до 59
                int minutes3 = random.Next(0, 60);

                string time = $"{hours:D2}:{minutes:D2}"; // Форматируем время вылета в строку

                int obsh = random.Next(2, 6); // Генерируем случайную продолжительность полета (в часах) от 2 до 5

                // Вычисляем время прибытия
                int arrivalHours = hours + obsh; // Часы прибытия = часы вылета + продолжительность полета
                int arrivalMinutes = minutes3; // Минуты прибытия остаются теми же

                // Корректируем часы, если они превышают 24
                if (arrivalHours >= 24)
                {
                    arrivalHours %= 24; // Получаем остаток от деления на 24, чтобы часы были в пределах 0-23
                }

                string timeprib = $"{arrivalHours:D2}:{arrivalMinutes:D2}"; // Форматируем время прибытия в строку

                //string timeprib = $"{hours:D2}:{minutes:D2}";

                int ponPrice = (priceMassiv[fig1] + priceMassiv[fig2]) / 2;

                var messageLines = new string[]
                        {
                            cityMassiv[fig1] + " - " + cityMassiv[fig2],
                            "Время вылета: " + time,
                            "Время прибытия: " + timeprib,
                            "Цена: " + ponPrice,
                            "Авиа компания"
                        };

                pnkt1 = cityMassiv[fig1];
                pnkt2 = cityMassiv[fig2];
                vzd = time;
                przd = timeprib;
                prc = ponPrice;

                // Создание кнопки
                
                

                Button but = new Button();
                but.Text = string.Join("\n", messageLines);

                but.Click += Button_Click;

                // Установка расположения кнопки 
                but.Location = new Point(15, 177 + 140 * i);
                but.Size = new Size(283, 106);

                this.Controls.Add(but);

                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Enabled = false;
                pic.Size = new Size(285, 145);
                pic.Location = new Point(16, 161 + 140 * i);
                pic.Image = testings.Properties.Resursiki.photo_2024_05_21_19_52_11;
                pic.Parent = but;
                this.Controls.Add(pic);
                pic.BringToFront();

                Label lbpr = new Label();
                lbpr.Location = new Point(27, 193 + 140 * i);
                lbpr.BackColor = Color.White;
                lbpr.Font = new Font("Palatino Linotype", 14);
                lbpr.TextAlign = ContentAlignment.TopLeft;
                lbpr.AutoSize = true;
                lbpr.Text = ponPrice.ToString() + " ₽";

                this.Controls.Add(lbpr);
                lbpr.BringToFront();

                Label lbtm = new Label();
                lbtm.Location = new Point(27, 255 + 140 * i);
                lbtm.BackColor = Color.Gainsboro;
                lbtm.Font = new Font("Palatino Linotype", 9);
                lbtm.TextAlign = ContentAlignment.TopLeft;
                lbtm.AutoSize = true;
                lbtm.Text = time + " - " + timeprib;

                this.Controls.Add(lbtm);
                lbtm.BringToFront();

                Label lbct = new Label();
                lbct.Location = new Point(27, 234 + 140 * i);
                lbct.BackColor = Color.Gainsboro;
                lbct.Font = new Font("Palatino Linotype", 8);
                lbct.TextAlign = ContentAlignment.TopLeft;
                lbct.AutoSize = true;
                lbct.Text = pnkt1 + " - " + pnkt2;

                this.Controls.Add(lbct);
                lbct.BringToFront();

            }

            for (int i = 0; i < 3; i++)
            {
                int fig3 = random.Next(0, cityMassiv.Length);
                int fig4;

                do
                {
                    fig4 = random.Next(0, cityMassiv.Length);
                } while (fig4 == fig3);

                int hours2 = random.Next(0, 24); // Генерируем случайное количество часов от 0 до 23
                int minutes2 = random.Next(0, 60); // Генерируем случайное количество минут от 0 до 59
                int minutes4 = random.Next(0, 60);

                string time2 = $"{hours2:D2}:{minutes2:D2}"; // Форматируем время вылета в строку

                int obsh2 = random.Next(2, 6); // Генерируем случайную продолжительность полета (в часах) от 2 до 5

                // Вычисляем время прибытия
                int arrivalHours2 = hours2 + obsh2; // Часы прибытия = часы вылета + продолжительность полета
                int arrivalMinutes2 = minutes4; // Минуты прибытия остаются теми же

                // Корректируем часы, если они превышают 24
                if (arrivalHours2 >= 24)
                {
                    arrivalHours2 %= 24; // Получаем остаток от деления на 24, чтобы часы были в пределах 0-23
                }

                string timeprib2 = $"{arrivalHours2:D2}:{arrivalMinutes2:D2}";

                int ponPrice2 = (priceMassiv[fig3] + priceMassiv[fig4]) / 2;

                var messageLines2 = new string[]
                        {
                            cityMassiv[fig3] + " - " + cityMassiv[fig4],
                            "Время вылета: " + time2,
                            "Время прибытия: " + timeprib2,
                            "Цена: " + ponPrice2,
                            "Авиа компания"
                        };

                pnkt3 = cityMassiv[fig3];
                pnkt4 = cityMassiv[fig4];
                vzd2 = time2;
                przd2 = timeprib2;
                prc2 = ponPrice2;

                // Создание кнопки
                Button but1 = new Button();
                but1.Text = string.Join("\n", messageLines2);

                but1.Click += Button2_Click;
                but1.Location = new Point(309, 177 + 140 * i);
                but1.Size = new Size(283, 106);
                this.Controls.Add(but1);
                
                PictureBox pic2 = new PictureBox();
                pic2.SizeMode = PictureBoxSizeMode.Zoom;
                pic2.Enabled = false;
                pic2.Size = new Size(285, 145);
                pic2.Location = new Point(310, 161 + 140 * i); 
                pic2.Image = testings.Properties.Resursiki.photo_2024_05_21_19_52_11;
                pic2.Parent = but1;
                this.Controls.Add(pic2);
                pic2.BringToFront();

                Label lbpr2 = new Label();
                lbpr2.Location = new Point(323, 193 + 140 * i);
                lbpr2.BackColor = Color.White;
                lbpr2.Font = new Font("Palatino Linotype", 14);
                lbpr2.TextAlign = ContentAlignment.TopLeft;
                lbpr2.AutoSize = true;
                lbpr2.Text = ponPrice2.ToString() + " ₽";

                this.Controls.Add(lbpr2);
                lbpr2.BringToFront();
                
                Label lbtm2 = new Label();
                lbtm2.Location = new Point(323, 255 + 140 * i); 
                lbtm2.BackColor = Color.Gainsboro;
                lbtm2.Font = new Font("Palatino Linotype", 9);
                lbtm2.TextAlign = ContentAlignment.TopLeft;
                lbtm2.AutoSize = true;
                lbtm2.Text = time2 + " - " + timeprib2;

                this.Controls.Add(lbtm2);
                lbtm2.BringToFront();

                Label lbct2 = new Label();
                lbct2.Location = new Point(323, 234 + 140 * i);
                lbct2.BackColor = Color.Gainsboro;
                lbct2.Font = new Font("Palatino Linotype", 8);
                lbct2.TextAlign = ContentAlignment.TopLeft;
                lbct2.AutoSize = true;
                lbct2.Text = pnkt3 + " - " + pnkt4;

                this.Controls.Add(lbct2);
                lbct2.BringToFront();


            }


        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = testings.Properties.Resursiki.photo_2024_05_21_19_52_34;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = testings.Properties.Resursiki.photo_2024_05_21_19_52_01;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = testings.Properties.Resursiki.photo_2024_05_21_19_52_30;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
