using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace diplomatik
{
    class LoginValidation
    {
        public bool LogVal(string login)
        {
            var input = login;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с логином пустое!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var TtT = new Regex(@"^[a-zA-Z0-9]{4,12}$");
            var Ang = new Regex("^[a-zA-Z0-9]+$");
            
            if (!Ang.IsMatch(input))
            {
                MessageBox.Show("В логине может содержаться только цифры и анг. буквы!", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!TtT.IsMatch(input))
            {
                MessageBox.Show("Логин должен быть от 4 до 12 символов!", "Внимание!",
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
