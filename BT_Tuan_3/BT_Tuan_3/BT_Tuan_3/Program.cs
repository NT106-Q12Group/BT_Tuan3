using System;
using System.Windows.Forms;

namespace BT_Tuan_3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new SignIn());
        }
    }
}
