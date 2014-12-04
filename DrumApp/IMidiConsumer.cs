using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumApp
{
    /// <summary>
    /// Provides a consumer for midi events
    /// </summary>
    public interface IMidiConsumer
    {
        /// <summary>
        /// Handles the midi channel event
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The event args</param>
        void ChannelMessageHandler(object sender, ChannelMessageEventArgs e);
    }
}
