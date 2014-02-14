using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace InputDataReader
{
    public abstract class InputBase
    {
        public T ReadJsonFile<T>(String filePath) where T : InputBase
        {
            String filecontents;

            using (StreamReader reader = new StreamReader(filePath))
            {
                filecontents = reader.ReadToEnd();
            }

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            return jsonserializer.Deserialize<T>(filecontents);
        }

        public T ReadJsonFile<T>() where T : InputBase      
        {
            String filecontents;

            using (StreamReader reader = new StreamReader(typeof(T).Name.ToString() + ".json"))
            {
                filecontents = reader.ReadToEnd();
            }

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            return jsonserializer.Deserialize<T>(filecontents);
        }

        public void WriteJsonFile<T>(T playerData) where T : InputBase     
        {            
            StringBuilder sb = new StringBuilder();

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            //playerData.GenerateTestData();

            jsonserializer.Serialize(playerData, sb);

            StreamWriter sw = new StreamWriter(typeof(T).Name + ".json", false);
            sw.Write(sb.ToString());
            sw.Close();
        }

        public void WriteJsonFile<T>(String filePath, T playerData) where T : InputBase
        {
            StringBuilder sb = new StringBuilder();

            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();

            jsonserializer.Serialize(playerData, sb);

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(sb.ToString());
            sw.Close();
        }

        public abstract InputBase GenerateTestData();        
    }
}
