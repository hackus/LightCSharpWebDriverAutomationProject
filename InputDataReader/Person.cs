using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputDataReader
{
    public class PlayerDataResponse : InputBase<PlayerDataResponse>
    {
        public PlayerData PlayerData { get; set; }

        public override PlayerDataResponse GenerateTestData()            
        {
            Alliance alliance = new Alliance();
            alliance.id = 1;
            alliance.name = "aliance1";

            Members member1 = new Members();
            member1.id = 1;
            member1.name = "test1";

            Members member2 = new Members();
            member2.id = 2;
            member2.name = "test2";

            PlayerData player = new PlayerData();
            player.timestamp = 1;
            player.alliance = alliance;
            player.members = new List<Members>();
            player.members.Add(member1);
            player.members.Add(member2);

            PlayerDataResponse response = new PlayerDataResponse();
            response.PlayerData = player;

            return response;
        }
    }

    public class PlayerData
    {
        public int timestamp { get; set; }
        public Alliance alliance { get; set; }
        public List<Members> members { get; set; }
    }

    public class Alliance
    { 
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Members
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
