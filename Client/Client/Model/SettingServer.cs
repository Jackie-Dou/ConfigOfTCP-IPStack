using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class SettingServer
    {
        public string IP { get; set; }
        public int Host { get; set; }
        public Color ColorText { get; set; }
        public Color ColorFrons { get; set; }
        public int HigthText { get; set; }

        public SettingServer()
        {
            ColorFrons = Color.White;
            ColorText = Color.Black;
            HigthText = 8;
        }
    }
}
