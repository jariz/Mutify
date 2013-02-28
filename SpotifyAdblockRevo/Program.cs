using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mutify.API;
using JBox;
using System.Threading;
using System.Windows.Forms;

namespace Mutify
{
    class Program
    {
        static string OAuth = "";
        static string CFID = "";
        static string Host = "mutify.spotilocal.com"; //lulz?
        public static SpotifyAPI API;
        public static Responses.Status Status;

        public delegate void StatusChangedHandler();
        public static event StatusChangedHandler StatusChanged;

        public static string MutifyStatus = "Authenticating....";

        public static string SpotifyVersion = "";

        public static IniFile SettingFile = new IniFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Mutify.ini");

        // when play and status is triggered at the same time, webclient crashes.
        public static bool DontRecieve = false;


        public static string getSetting(string setting)
        {
            return SettingFile.IniReadValue("Mutify", setting);
        }

        public static bool getSettingb(string setting)
        {
            return Convert.ToBoolean(SettingFile.IniReadValue("Mutify", setting));
        }

        [STAThread]
        static void Main(string[] args)
        {
            /*Console.Title = "SpotifyAPI";
            Console.WindowHeight = Console.LargestWindowHeight -25;
            Console.WindowWidth = Console.LargestWindowWidth -25;
            Console.WindowLeft = 0;
            Console.WindowTop = 0;*/


            Out.WriteLine("SpotifyAPI 1.0");

            Application.EnableVisualStyles();


            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                if (MessageBox.Show("Mutify is already running, are you sure you want to start another Mutify?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    Environment.Exit(1);

            if (File.ReadAllText(SettingFile.path).Length < 1)
            {
                Options a = new Options();
                a.Options_Load(new object(), new EventArgs());
                a.Dispose();
            }
            
            OAuth = SpotifyAPI.GetOAuth();
            Out.WriteDebug("Downloaded OAuth: " + OAuth);
            Out.WriteLine("Connecting to Spotify....");
            API = new SpotifyAPI(OAuth, Host);
            Responses.ClientVersion version = API.ClientVersion;
            Out.WriteLine("Connected. Client version: " + version.client_version + " Version: " + version.version);
            SpotifyVersion = version.version + " " + version.client_version;
            CFID = API.CFID.token;
            Out.WriteLine("Requested CFID = " + CFID);

            MutifyStatus = "Successfully loaded";
            new Thread(main).Start();
            //printTrack(Status);


            DateTime cfid_age = DateTime.Now;
            
            while (true)
            {
                
                if (new TimeSpan(DateTime.Now.Ticks).TotalSeconds - new TimeSpan(cfid_age.Ticks).TotalSeconds > 600)
                {
                    Out.WriteLine("Credentials expired");
                    Out.WriteLine("Requesting new credentials...");
                    OAuth = SpotifyAPI.GetOAuth();
                    API = new SpotifyAPI(OAuth, Host);
                    CFID = API.CFID.token;
                    cfid_age = DateTime.Now;
                }

                Status = API.Status;
                if (Status.running)
                {
                    MutifyStatus = "Recieved track information.";
                    processStatus(Status);
                }
                else
                {
                    MutifyStatus = "Spotify is not running";
                    Thread.Sleep(500);
                }
                API.Wait = 60;
            }
        }

        static void processStatus(Responses.Status Status)
        {
            if (Status.track != null)
            {
                if (Status.track.track_type == "ad")
                {
                    if (getSettingb("blockAds")) MutifyStatus = "Blocking ad!";
                    else MutifyStatus = "Not blocking this ad";
                    Out.WriteLine("Ad detected!, blocking it");
                    if(getSettingb("blockAds")) Muting.Mute(true);
                    API.Wait = -1; //remove waiting time
                    bool playing = API.Status.playing;
                    while (!playing)
                    {
                        Status = API.Resume;
                        playing = Status.playing;
                    }
                    API.Wait = 60; //set back to default
                }
                else
                {
                    if (Muting.Muted)
                    {
                        Muting.Mute(false);
                    }
                }
            }
            if (StatusChanged != null)
                StatusChanged();
        }

        static void main()
        {
            Application.Run(new Main());
        }
    }
}
