using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CustomControls
{
   public class txtsdt:TextBox
    {
        ErrorProvider er = new ErrorProvider();
        public txtsdt()
        {
            this.KeyPress += txtsdt_KeyPress;
            this.Leave += txtsdt_Leave;
        }

        void txtsdt_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string regexPattern = @"^(?:03|05|07|08|09)[0-9]{8}$";
            Regex regex = new Regex(regexPattern);
            if (regex.IsMatch(txt.Text) == false)
            {
                er.SetError((TextBox)sender, "Số điện thoại chưa đúng!");
            }
            else
                er.SetError((TextBox)sender, "");
        }

        void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }
    }
}
