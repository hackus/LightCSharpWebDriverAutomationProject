using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace InputDataReader
{
    class Test
    {
        public void ReadJsonFile(String filePath)
        { 
            String filecontents;

            using (StreamReader reader = new StreamReader(filePath))
	        {
                filecontents = reader.ReadToEnd();
	        }

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();
            PlayerDataResponse playerData = jsonserializer.Deserialize<PlayerDataResponse>(filecontents);
        }

        public void WriteJsonFile(String filePath, PlayerDataResponse playerData)
        {
            String filecontents;
            StringBuilder sb = new StringBuilder();

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            jsonserializer.Serialize(playerData, sb);

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(sb.ToString());            
            sw.Close();
        }

        public PlayerDataResponse GenerateDumyData()
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

        public static void Main()
        {
            String filepath = @"file1.json";
            Test test = new Test();
            PlayerDataResponse player = test.GenerateDumyData();

            test.WriteJsonFile(filepath, player);
            test.ReadJsonFile(filepath);
        }
    }
}
