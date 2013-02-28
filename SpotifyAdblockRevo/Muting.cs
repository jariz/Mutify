using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAudioApi;
using System.Diagnostics;
using JBox;

namespace Mutify
{
    class Muting
    {
        public static bool Muted
        {
            get
            {
                return getAudioVolume().Mute;
            }
        }


        public static void Mute(bool mute)
        {
            Out.WriteBlank();
            Out.WriteDebug("Mutify.Muting is looking for Spotify...");
            getAudioVolume().Mute = mute;
        }

        static SimpleAudioVolume getAudioVolume()
        {
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            MMDevice device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            // Note the AudioSession manager did not have a method to enumerate all sessions in windows Vista
            // this will only work on Win7 and newer.
            bool found = false;
            for (int i = 0; i < device.AudioSessionManager.Sessions.Count; i++)
            {
                AudioSessionControl session = device.AudioSessionManager.Sessions[i];

                if (Process.GetProcessById(Convert.ToInt32(session.ProcessID)).ProcessName.ToLower() == "spotify")
                {
                    found = true;
                    Out.WriteLine("FOUND SPOTIFY " + session.SessionIdentifier);
                    return session.SimpleAudioVolume;
                }
            }
            if (!found)
            {
                System.Windows.Forms.MessageBox.Show("Unable to find Spotify!\r\nAre you sure you're running win7 and spotify is enabled?", "MUTING FAILED", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            return null;
        }
    }
}
