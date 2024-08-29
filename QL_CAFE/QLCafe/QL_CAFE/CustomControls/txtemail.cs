using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CustomControls
{
    public class txtemail : TextBox
    {
        ErrorProvider er = new ErrorProvider();
        public txtemail()
        {
            this.KeyPress += txtemail_KeyPress;
        }

        void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!txt.Text.Contains("@") || !txt.Text.Contains(".com"))
            {
                er.SetError(txt, "Email chưa đúng định dạng");
            }
            else
            {
                er.SetError(txt, "");
            }
        }
    }
}
