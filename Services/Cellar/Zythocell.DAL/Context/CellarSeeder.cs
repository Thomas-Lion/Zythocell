using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Extensions;

namespace Zythocell.DAL.Context
{
    public class CellarSeeder
    {
        private readonly ZythocellContext context;
        private readonly IWebHostEnvironment hosting;

        public CellarSeeder(ZythocellContext context, IWebHostEnvironment hosting)
        {
            this.context = context;
            this.hosting = hosting;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();
            CellarJsonSeeder();
            BeverageJsonSeeder();
            RateJsonSeeder();

            context.SaveChanges();
        }

        private void CellarJsonSeeder()
        {
            if (!context.Cellars.Any())
            {
                var filepath = Path.Combine("C:/Users/Thomas/source/repos/Zythocell/Services/Cellar/Zythocell.DAL/Context/cellar.json");
                var json = File.ReadAllText(filepath);
                var cellars = JsonConvert.DeserializeObject<IEnumerable<CellarTO>>(json);

                foreach (var item in cellars)
                {
                    context.Cellars.AddRange(item.ToEF());
                }
            }
        }
        
        private void BeverageJsonSeeder()
        {
            if (!context.Beverages.Any())
            {
                var filepath = Path.Combine("C:/Users/Thomas/source/repos/Zythocell/Services/Cellar/Zythocell.DAL/Context/beverage.json");
                var json = File.ReadAllText(filepath);
                var beverages = JsonConvert.DeserializeObject<IEnumerable<BeverageTO>>(json);

                foreach (var item in beverages)
                {
                    context.Beverages.AddRange(item.ToEF());
                }
            }
        }
        
        private void RateJsonSeeder()
        {
            if (!context.Rates.Any())
            {
                var filepath = Path.Combine("C:/Users/Thomas/source/repos/Zythocell/Services/Cellar/Zythocell.DAL/Context/rate.json");
                var json = File.ReadAllText(filepath);
                var rates = JsonConvert.DeserializeObject<IEnumerable<RateTO>>(json);

                foreach (var item in rates)
                {
                    context.Rates.AddRange(item.ToEF());
                }
            }
        }
    }
}
