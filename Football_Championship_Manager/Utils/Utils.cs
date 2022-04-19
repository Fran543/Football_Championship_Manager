using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    public class Utils
    {
        public static T GetControl<T>(Control parent)
        {
            foreach (var ctrl in parent.Controls)
            {
                if (ctrl is T)
                    return (T)ctrl;
            }
            return default;
        }
    }
}
