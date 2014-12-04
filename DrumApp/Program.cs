using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using System.Windows.Forms;

namespace DrumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //BassProvider bp = BassProvider.Instance;
            Application.Run(new MainForm());
        }
        


    }
}
