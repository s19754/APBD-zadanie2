using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace XYZExporter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            using var streamWriter = new StreamWriter(@"log.txt");
            string SourcePath = args[1];
            string OutPath = args[0];
            string mode = args[2];
            try
            {
                Path.GetFullPath(SourcePath);
                Path.GetFullPath(OutPath);
            }
            catch (ArgumentException e)
            {
                streamWriter.WriteLine("Podana ścieżka jest niepoprawna");
            }
           
            
           
            string[] result2 = await File.ReadAllLinesAsync(args[1]);
            await File.WriteAllLinesAsync("opcja2.txt", result2);

            var studentsList = new HashSet<Student>(new StudentComparer());

            foreach (var item in result2)
            {
                string[] kolumny = item.Split(',');
                if (kolumny.Length == 9)
                {
                    bool goodFormat = true;
                    foreach (string str in kolumny)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            goodFormat = false;
                        }
                        
                    }
                    if (goodFormat)
                    {
                        var tempStudent = new Student
                        {
                            Fname = kolumny[0],
                            Lname = kolumny[1],
                            Studies = new Studies
                            {
                                Mode = kolumny[3],
                                Name = kolumny[2]
                            },
                            IndexNumber = kolumny[4],
                            Birthdate = DateTime.Parse(kolumny[5]),
                            Email = kolumny[6],
                            MothersName = kolumny[7],
                            FathersName = kolumny[8],
                        };
                        if (studentsList.Contains(tempStudent))
                        {
                            streamWriter.WriteLine($"Student {tempStudent.Fname} już jest na liście");
                        }
                        else
                        {
                            studentsList.Add(tempStudent);
                        }
                    }
                    else
                    {
                        streamWriter.WriteLine("Błąd rekordów, conajmniej jedna kolumna jest pusta");
                    }
                }
                else
                {
                    streamWriter.WriteLine("Błąd rekordów, za mało danych (kolumn nie jest 9)");
                }
            }

               


            string a = "";
            string[] b = a.Split(',');
            new Student { };
            //var jObject = new JObject();
            // { }
            var jArray = new JArray();
            // []
            var jProperty = new JProperty("property", new JArray());
            // nazwaProperty: ""
            //Root: {}, []
            var jObject = new JObject(
                new JProperty("uczelnia", new JObject(
                    new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
                    new JProperty("author", "Tomasz Wojtkowski")
                ))
            );
            Console.WriteLine(jObject);
        }
    }
}
