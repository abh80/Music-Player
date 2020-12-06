using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
namespace Music_Player.Runner.Helpers
{
    class jsonParser
    {
        public static JSONspaceRPC Parse(String file)
        {
            var file1 = File.ReadAllText(@file);
            var parsed = JsonSerializer.Deserialize<JSONspaceRPC>(file1);
            return parsed;
        }
    }
    public class JSONspaceRPC
    {
        public bool enableRPC { get; set; }
    }
}
