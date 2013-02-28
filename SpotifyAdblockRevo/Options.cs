using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mutify
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Program.MutifyStatus;
        }

        bool getSetting(string field)
        {
           return Convert.ToBoolean(Program.SettingFile.IniReadValue("Mutify", field));
        }

        void safeBox(CheckBox box)
        {
            Program.SettingFile.IniWriteValue("Mutify", box.Name, Convert.ToString(box.Checked));
        }

        public void Options_Load(object sender, EventArgs e)
        {
            string a = File.ReadAllText(Program.SettingFile.path);
            if (a.Length < 1)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if(c.GetType().Name == downloadCoverArt.GetType().Name)
                        safeBox((CheckBox)c);
                }
            }

            toolStripStatusLabel2.Text = "Spotify Version: " + Program.SpotifyVersion;

            foreach (Control c in groupBox1.Controls)
            {
                if (c.GetType().Name == downloadCoverArt.GetType().Name)
                    ((CheckBox)c).Checked = getSetting(c.Name);
            }
        }

        private void messageLoad_CheckedChanged(object sender, EventArgs e)
        {
            safeBox((CheckBox)sender);
        }
    }
}
