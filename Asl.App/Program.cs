﻿using Asl.Core;
using System;

namespace Asl.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Asl **");
            IBusinessLogic bl = new BusinessLogic();
            
            var patients = bl.GetAllPatients();

            bl.InsertPatient("MGGDVD87H27E815Y", "Davide", "Maggiulli", "Via Fosse Ardeatine", "10", "Imola", "40026");

            patients = bl.GetAllPatients();


        }
    }
}