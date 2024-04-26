using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace diplomatik
{
    class CodeValidation
    {
        //uwu
        public bool CodeVal(string code)
        {
            var input = code;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с кодом пустое!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var Chto = new Regex("^[0-9]+$");

            if (!Chto.IsMatch(input))
            {
                MessageBox.Show("В коде может содержаться только цифры!", "Внимание!",
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
