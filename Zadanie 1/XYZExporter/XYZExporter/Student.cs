using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XYZExporter
{
    class Student
    {
        [JsonPropertyName("fname")]
        public string Fname { get; set; }
        [JsonPropertyName("lname")]
        public string Lname { get; set; }
        [JsonPropertyName("studies")]
        public Studies Studies { get; set; }
        [JsonPropertyName("indexNumber")]
        public string IndexNumber { get; set; }
        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }
        private string _email;
        [JsonPropertyName("email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [JsonPropertyName("mothersName")]
        public string MothersName { get; set; }
        [JsonPropertyName("fathersName")]
        public string FathersName { get; set; }


    }
}
