using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;
        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshop.Any()) 
                {

                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    { 
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis mazda ",
                        ContactDetails = new Domain.Entities.CarWorkshopContactDetails 
                        { 
                        City = "Krakow",
                        Street = "szewska 2 ",
                        PostalCode = "30-001",
                        PhoneNumber = "+48222333444"
                        }
                        
                    };
                    mazdaAso.EncodeName();
                    _dbContext.CarWorkshop.Add(mazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
