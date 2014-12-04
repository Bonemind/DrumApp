using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumApp
{
    /// <summary>
    /// Provides an interface for midi device event raisers
    /// </summary>
    public interface IMidiProvider
	{
        /// <summary>
        /// Registers a consumer with this midi event provider
        /// </summary>
        /// <param name="consumer">The consumer to register</param>
        void ChannelMessageSubscribe(IMidiConsumer consumer);

        /// <summary>
        /// Unsubscribes a channel message with a midi consumer
        /// </summary>
        /// <param name="consumer">The consumer to unsubscribe</param>
        void ChannelMessageUnsubscribe(IMidiConsumer consumer);
		
    }
}
