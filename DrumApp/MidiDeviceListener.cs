using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia;

namespace DrumApp
{
    class MidiDeviceListener : IMidiProvider
    {
        /// <summary>
        /// The midi input device
        /// </summary>
        private InputDevice inputDevice = null;

        /// <summary>
        /// Default constructor 
        /// </summary>
        public MidiDeviceListener()
        {
            if (InputDevice.DeviceCount == 0)
            {
                throw new Exception("No midi devices found");
            }
        }

        
        /// <summary>
        /// Sets the devicenumber to use
        /// </summary>
        /// <param name="deviceNumber">The devicenumber</param>
        public void SetDevice(int deviceNumber)
        {
            if (inputDevice != null)
            {
                inputDevice.StopRecording();
                inputDevice.Close();
            }
            inputDevice = new InputDevice(deviceNumber);
        }

        /// <summary>
        /// Starts the event listener
        /// </summary>
        public void StartListening()
        {
            if (inputDevice != null)
            {
                inputDevice.StartRecording();
            }
        }

        /// <summary>
        /// Stops the event listener
        /// </summary>
        public void StopListening()
        {
            if (inputDevice != null)
            {
                inputDevice.StopRecording();
            }
        }

        /// <summary>
        /// Implements the IMidiProvider interface
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public void ChannelMessageSubscribe(IMidiConsumer consumer)
        {
            inputDevice.ChannelMessageReceived += consumer.ChannelMessageHandler;
        }

        /// <summary>
        /// Implements the IMidiProvider interface
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public void ChannelMessageUnsubscribe(IMidiConsumer consumer)
        {
            inputDevice.ChannelMessageReceived -= consumer.ChannelMessageHandler;
        }
    }
}
