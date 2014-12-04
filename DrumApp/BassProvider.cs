using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;
using Un4seen.BassAsio;

namespace DrumApp
{
    class BassProvider : IMidiConsumer
    {
        /// <summary>
        /// The singleton instance object
        /// </summary>
        private static BassProvider _instance;

        /// <summary>
        /// The music stream for bass.net to use
        /// </summary>
        private int stream;

        /// <summary>
        /// BassAsioHandler private audio device
        /// </summary>
        private BassAsioHandler _asio;

        /// <summary>
        /// Provides a singleton access point
        /// </summary>
        public static BassProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BassProvider();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Default constructor 
        /// Initializes the bassprovider instance
        /// </summary>
        private BassProvider()
        {
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 0);
            Bass.BASS_Init(-1, 48000, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            BassAsio.BASS_ASIO_Init(0, BASSASIOInit.BASS_ASIO_THREAD);

            int fontfile = Un4seen.Bass.AddOn.Midi.BassMidi.BASS_MIDI_FontInit("D:\\Downloads\\56-drum-percussion-sf\\Drum & Percussion Soundfonts\\GoldDrums.sf2");
            Console.WriteLine(BassMidi.BASS_MIDI_FontGetInfo(fontfile));
            BASS_MIDI_FONT[] fonts = { new BASS_MIDI_FONT(fontfile, -1, 0) };

            stream = BassMidi.BASS_MIDI_StreamCreate(16, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT, 1);

            Un4seen.Bass.AddOn.Midi.BassMidi.BASS_MIDI_StreamSetFonts(stream, fonts, fonts.Length);
            Bass.BASS_ChannelPlay(stream, false);
            Console.WriteLine(Bass.BASS_ChannelIsActive(stream));

            if (stream != 0)
            {
                _asio = new BassAsioHandler(0, 0, stream);
                _asio.Start(0, 0);
            }

        }

        /// <summary>
        /// Plays a midi note
        /// </summary>
        /// <param name="note">The note number</param>
        /// <param name="velocity">The velocity (loudness) of a note</param>
        private void PlayNote(int note, int velocity)
        {
            if (velocity == 0)
            {
                return;
            }
            BassMidi.BASS_MIDI_StreamEvent(stream, 0, BASSMIDIEvent.MIDI_EVENT_NOTE, (byte) note, (byte) velocity); 
        }

        /// <summary>
        /// Implements the IMidiConsumer interface
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The midievent</param>
        public void ChannelMessageHandler(object sender, Sanford.Multimedia.Midi.ChannelMessageEventArgs e)
        {
            PlayNote(e.Message.Data1, e.Message.Data2);
        }
    }
}
