using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace diplomatik
{
    class PasswordValid
    {
        public bool PasswordVal(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с паролем пустое!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var Bukvins = new Regex(@"^[a-zA-Z0-9]{6,12}$");
            var Ang = new Regex("^[a-zA-Z0-9]+$");

            if (!Ang.IsMatch(input))
            {
                MessageBox.Show("В пароле может содержаться только цифры и анг. буквы!", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Bukvins.IsMatch(input))
            {
                MessageBox.Show("Пароль должен быть от 6 до 12 символов", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        } 
    }
}
