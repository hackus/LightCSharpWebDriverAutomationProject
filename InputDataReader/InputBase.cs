using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace InputDataReader
{
    public abstract class InputBase<T> where T : InputBase<T>
    {
        public static T ReadJsonFile(String filePath)
        {
            String filecontents;

            using (StreamReader reader = new StreamReader(filePath))
            {
                filecontents = reader.ReadToEnd();
            }

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            return jsonserializer.Deserialize<T>(filecontents);
        }

        public static T ReadJsonFile()        
        {
            String filecontents;

            using (StreamReader reader = new StreamReader(typeof(T).Name.ToString() + ".json"))
            {
                filecontents = reader.ReadToEnd();
            }

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            return jsonserializer.Deserialize<T>(filecontents);
        }

        public static void WriteJsonFile(T playerData)        
        {            
            StringBuilder sb = new StringBuilder();

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            playerData.GenerateTestData();

            jsonserializer.Serialize(playerData, sb);

            StreamWriter sw = new StreamWriter(typeof(T).Name + ".json", false);
            sw.Write(sb.ToString());
            sw.Close();
        }

        public static void WriteJsonFile(String filePath, T playerData)
        {
            StringBuilder sb = new StringBuilder();

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            jsonserializer.Serialize(playerData, sb);

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(sb.ToString());
            sw.Close();
        }

        public abstract T GenerateTestData();        
    }
}
