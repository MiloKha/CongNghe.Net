using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CustomControls
{
    public class txtuser:TextBox
    {
        ErrorProvider er = new ErrorProvider();
        public txtuser()
        {
            this.KeyPress += txtuser_KeyPress;
        }

        void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && txt.Text.Length < 6)
            {
                er.SetError((TextBox)sender, "Không được chứa ký tự đặc biệt!");
            }
            else
            {
                er.SetError((TextBox)sender, "");
            }
        }
    }
}
