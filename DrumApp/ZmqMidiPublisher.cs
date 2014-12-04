using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;

namespace DrumApp
{
    class ZmqMidiPublisher : IMidiConsumer
    {
        NetMQ.NetMQContext context;
        NetMQ.Sockets.PublisherSocket pubSocket;

        public ZmqMidiPublisher(int portNumber)
        {
            context = NetMQContext.Create();
            pubSocket = context.CreatePublisherSocket();
            pubSocket.Bind("tcp://127.0.0.1:" + portNumber);
            Console.WriteLine("Server started");
        }

        public void ChannelMessageHandler(object sender, Sanford.Multimedia.Midi.ChannelMessageEventArgs e)
        {
            if (pubSocket != null)
            {
                pubSocket.Send(e.Message.Data1 + "," + e.Message.Data2);
            }
        }
    }
}
