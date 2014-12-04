using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrumApp
{
    public partial class MainForm : Form
    {
        MidiFilePlayer mfPlayer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mfPlayer = new MidiFilePlayer();
            ZmqMidiPublisher midiFilePublisher = new ZmqMidiPublisher(7284);
            //mfPlayer.LoadFile("D:\\Downloads\\metronome_80.mid");
            mfPlayer.LoadFile("D:\\Downloads\\funky-fusion-110.mid");
            //mfPlayer.ChannelMessageSubscribe(BassProvider.Instance);
            mfPlayer.ChannelMessageSubscribe(midiFilePublisher);


            ZmqMidiPublisher midiDevicePublisher = new ZmqMidiPublisher(7285);
            MidiDeviceListener mdListener = new MidiDeviceListener();
            mdListener.SetDevice(0);
            mdListener.StartListening();
            //mdListener.ChannelMessageSubscribe(BassProvider.Instance);
            mdListener.ChannelMessageSubscribe(midiDevicePublisher);
        }

        private void btnStartMetronome_Click(object sender, EventArgs e)
        {
            mfPlayer.Play();
        }

        private void btnStopMetronome_Click(object sender, EventArgs e)
        {
            mfPlayer.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            mfPlayer.Reset();
        }
    }
}
