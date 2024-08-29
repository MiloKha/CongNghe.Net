using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CustomControls
{
    public class txtnum:TextBox
    {
        ErrorProvider er = new ErrorProvider();
        public txtnum()
        {
            this.KeyPress += txtnum_KeyPress;
        }

        void txtnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
