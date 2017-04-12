﻿using SteamKit2.GC;
using SteamKit2.GC.Dota.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Crystalys.Tests
{
	public class DotaGameClientTest
	{
        private UserInfo GetUserInfo()
        {
            return new UserInfo() {
                Username = "Thantsking",
                Password = "aPhan3sah"
            };
        }

        private long GetMatchId()
        {
            return 3111014659;
        }

        [Fact]
        public void Basic()
        {
            var userInfo = this.GetUserInfo();

            var client = new DotaGameClient(30);
            var version = client.Connect(userInfo.Username, userInfo.Password).Result;
        }


        [Fact]
		public async Task ConnectToSteam()
		{
            var userInfo = this.GetUserInfo();
            var matchid = this.GetMatchId();

            using (var client = new DotaGameClient())
            {
                await client.Connect(userInfo.Username, userInfo.Password);
            }
        }

        
        [Fact]
        public async Task DownloadMatchData()
        {
            var userInfo = this.GetUserInfo();
            var matchid = this.GetMatchId();

            using (var client = new DotaGameClient())
            {
                await client.Connect(userInfo.Username, userInfo.Password);

                var data = await client.DownloadMatchData(matchid);
                Assert.NotNull(data);
            }
        }

        [Fact]
        public async Task DownloadMeta()
        {
            var userInfo = this.GetUserInfo();
            var matchid = this.GetMatchId();

            using (var client = new DotaGameClient())
            {
                await client.Connect(userInfo.Username, userInfo.Password);

                var data = await client.DownloadMeta(matchid);
                Assert.NotNull(data);
            }
        }

        [Fact]
        public async Task DownloadReplay()
        {
            var userInfo = this.GetUserInfo();
            var matchid = this.GetMatchId();

            using (var client = new DotaGameClient())
            {
                await client.Connect(userInfo.Username, userInfo.Password);

                var data = await client.DownloadReplay(matchid);
                Assert.NotNull(data);
            }
        }
        
    }
}
