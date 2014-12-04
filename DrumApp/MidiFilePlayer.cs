using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia;

namespace DrumApp
{
    /// <summary>
    /// Plays midi files
    /// </summary>
    class MidiFilePlayer : IMidiProvider
    {
        /// <summary>
        /// The sequencer to use
        /// </summary>
        Sequencer sequencer;

        /// <summary>
        /// The sequence (Series of midi notes)
        /// </summary>
        Sequence sequence;

        /// <summary>
        /// Default constructor, initializer sequencer and sequence
        /// </summary>
        public MidiFilePlayer() {
            sequencer = new Sequencer();
            sequence = new Sequence();
            sequencer.Sequence = sequence;
        }

        /// <summary>
        /// Loads a midi file into the sequencer
        /// </summary>
        /// <param name="path">The path to load the file from</param>
        public void LoadFile(string path)
        {
            sequencer.Stop();
            sequence.Load(path);
        }

        /// <summary>
        /// Starts playing of the file
        /// </summary>
        public void Play()
        {
            sequencer.Start();
        }

        /// <summary>
        /// Stops playing of the file
        /// </summary>
        public void Stop()
        {
            sequencer.Stop();
        }

        /// <summary>
        /// Resets playback to the beginning of the file
        /// </summary>
        public void Reset()
        {
            sequencer.Position = 0;
        }


        /// <summary>
        /// Implements the IMidiProvider interface
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public void ChannelMessageSubscribe(IMidiConsumer consumer)
        {
            sequencer.ChannelMessagePlayed += consumer.ChannelMessageHandler;
        }

        /// <summary>
        /// Implements the IMidiProvider interface
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public void ChannelMessageUnsubscribe(IMidiConsumer consumer)
        {
            sequencer.ChannelMessagePlayed -= consumer.ChannelMessageHandler;
        }
    }
}
