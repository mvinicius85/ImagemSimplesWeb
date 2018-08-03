using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImagemSimplesWeb.Application.Model
{
    public class User
    {
        public User()
        {

        }

        public User(string u, string p)
        {
            Login = u;
            Senha = p;
        }
        [JsonProperty("Key")]
        public string Key { get; set; }
        [JsonProperty("Login")]
        public string Login { get; set; }
        [JsonProperty("Senha")]
        public string Senha { get; set; }
    }
}
