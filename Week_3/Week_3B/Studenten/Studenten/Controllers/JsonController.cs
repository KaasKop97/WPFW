using System;
using System.Text.Json;
namespace Studenten.Controllers
{
    public class JsonController
    {
        public bool writeToFile(string jsonData)
        {
            System.IO.File.WriteAllText("studenten.json", jsonData);
            return false;
        }
    }
}