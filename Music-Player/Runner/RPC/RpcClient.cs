using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace Music_Player.Runner.RPC
{
    class RpcClient
    {
        public String SongName { get; set; }
        public String ArtistName { get; set; }
        public bool isPlaying { get; set; }
        public DateTime StartTime { get; set; }

        private DiscordRpcClient Client { get; set; }
        public RpcClient()
        {
            Client = new DiscordRpcClient("785029220954275861");
            Client.Initialize();
        }
    public void setPresence() {
            Client.SetPresence(new RichPresence() {
                Details = $"Listening {SongName}",
                State = $"by {ArtistName}",
                Timestamps = new Timestamps()
                {
                    Start = StartTime
                },
            Assets = new Assets()
            {
                LargeImageKey = "app",
                LargeImageText = "Listening with Music Player",
                SmallImageKey = isPlaying ? "playing" : "paused",
                SmallImageText = isPlaying ? "Playing" : "Paused"
            }
            }) ; 

        }
        public void update()
        {
            Client.Invoke();
        }
    }
}
