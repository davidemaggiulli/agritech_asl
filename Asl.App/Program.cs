
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Asl.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Asl **");
            //IBusinessLogic bl = new BusinessLogic();

            //var patients = bl.GetAllPatients();
            //bl.InsertDoctor("Pippo", "Franco", new DateTime(1950, 1, 1), "Mirabilandia");
            //bl.InsertPatient("MGGDVD87H27E815Y", "Davide", "Maggiulli", "Via Fosse Ardeatine", "10", "Imola", "40026",1);

            //patients = bl.GetAllPatients();

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44340/api/doctor")
            };

            HttpResponseMessage response = client.SendAsync(message).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                IList<MyDoctor> docotrs = JsonConvert.DeserializeObject<List<MyDoctor>>(content);
                foreach(var d in docotrs)
                {
                    Console.WriteLine($"{d.Id} {d.Name} {d.Surname} {d.BirthPlace}");
                }


            }

        }
    }
}
