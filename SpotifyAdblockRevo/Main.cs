using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mutify.API;
using JBox;

namespace Mutify
{
    public partial class Main : Form
    {
        
        public Main()
        {
            
            InitializeComponent();

            Program.StatusChanged += new Program.StatusChangedHandler(Program_StatusChanged);
        }

        void Program_StatusChanged()
        {
            Invoke(new Program.StatusChangedHandler(Refresh));
        }

        Responses.Internal.track lastTrack = null;

        private void Refresh()
        {
            Out.WriteLine("Refreshing interface");
            if (Program.Status != null)
            {
                if (Program.Status.track != null)
                {
                    
                    Out.WriteLine(string.Format("Playing: {0} Song: {1} - {2} - {3}", Program.Status.playing, Program.Status.track.track_resource.name, Program.Status.track.artist_resource.name, Program.Status.track.album_resource.name));

                    if(lastTrack == null)
                        lastTrack = Program.Status.track;
                    if (Program.getSettingb("messageTrack") && Program.Status.playing && Program.Status.track.track_type != "ad" && lastTrack.track_resource.uri != Program.Status.track.track_resource.uri)
                    {
                        lastTrack = Program.Status.track;
                        notifyIcon1.ShowBalloonTip(1337, null, string.Format("{0}\r\n{1}\r\n{2}", Program.Status.track.track_resource.name, Program.Status.track.artist_resource.name, Program.Status.track.album_resource.name), ToolTipIcon.None);
                    }
                    if (Program.Status.track.track_type != "ad")
                    {
                        if (Program.getSettingb("blockAds"))
                        {
                            pictureBox1.ImageLocation = Program.API.getArt(Program.Status.track.album_resource.uri);
                            if (pictureBox1.ImageLocation == "nope")
                            {
                                pictureBox1.ImageLocation = "";
                                pictureBox1.Image = Properties.Resources.mutify;
                            }
                        }
                        else IdleInterface();
                    }
                    else
                        pictureBox1.Image = Mutify.Properties.Resources.advertisment;

                    if (Program.Status.track.track_type != "ad")
                    {
                        label1.Text = Program.Status.track.track_resource.name;
                        label1.Text += "\n" + Program.Status.track.artist_resource.name;
                        label1.Text += "\n" + Program.Status.track.album_resource.name;
                    }
                    else label1.Text = "";

                    if (Program.Status.playing)
                        pictureBox2.Image = Properties.Resources.pause;
                    else pictureBox2.Image = Properties.Resources.PLAY;
                }
                else IdleInterface();
            }
            else IdleInterface();
        }

        void IdleInterface()
        {
            pictureBox1.Image = Properties.Resources.mutify;
            pictureBox1.ImageLocation = "";
            label1.Text = "";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Program.getSettingb("startMinimized")) Signatures.ShowWindow(this.Handle, Signatures.ShowWindowCommands.Hide);
            else WindowState = FormWindowState.Normal;
            if(Program.getSettingb("messageLoad")) notifyIcon1.ShowBalloonTip(1337, "Mutify - Hai", "I'm blocking your ads now.\r\nIf you want to see the user interface click this icon!", ToolTipIcon.Info);
            Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Signatures.ShowWindow(this.Handle, Signatures.ShowWindowCommands.Hide);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Signatures.ShowWindow(this.Handle, Signatures.ShowWindowCommands.Restore);
                Signatures.ShowWindow(this.Handle, Signatures.ShowWindowCommands.Show);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            
            Environment.Exit(1337);
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = "Mutify - " + Program.MutifyStatus;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog();
        }

        private void surpiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (new Random().Next(0, 9))
            {
                case 0:
                    Program.API.URI = "spotify:track:7sXxvOVFtMr31xj0kX9BFV"; //hit the road jack
                    break;
                case 1:
                    Program.API.URI = "spotify:track:3wcekXbEsDFv9OfyJe1q5d"; //evil boy
                    break;
                case 2:
                    Program.API.URI = "spotify:track:4AwNkK2LXPTsb3fouwQou2"; //kokomo
                    break;
                case 3:
                    Program.API.URI = "spotify:track:7766dSH6uDD3qjI3TATbtr"; //to be the best
                    break;
                case 4:
                    Program.API.URI = "spotify:track:0pvBjNpFLSfKMeYg0DALBR"; //ERB
                    break;
                case 5:
                    Program.API.URI = "spotify:track:6dkBHisZKepfXvqudMxhlK"; // ja ik tweet 't
                    break;
                case 6:
                    Program.API.URI = "spotify:track:2BZOQSIXRegXkSMT265hOn"; //nyan
                    break;
                case 7:
                    Program.API.URI = "spotify:track:0jg01gxAuty5Wq0qnel1Kj"; //e40
                    break;
                case 8:
                    Program.API.URI = "spotify:track:6J1NDncyE32ESFN45kGQU0"; //boat
                    break;
            }
            Program.Status = Program.API.Play;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (Program.Status.playing)
                Program.Status = Program.API.Pause;
            else
                Program.Status = Program.API.Resume;

            Refresh();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1337);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by JariZ.nl\r\nUses the SpotifyLocalApi (code.google.com/p/spotify-local-api)", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
