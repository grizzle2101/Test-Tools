using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsConfigurator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Get User Input for Database & Type of Data:
            Console.WriteLine("Enter Database Number:");
            var DatabaseNumber = Console.ReadLine();

            Console.WriteLine("Production(True) or Test Data(False)? ");
            Boolean TestDataType = bool.Parse(Console.ReadLine());

            //Task 1 - Retrive Unique Records from View
            var context = new SettingsContext();
            var deliveries = context.UI_vDeliveries
                .Where(x => x.Regime == "US FATCA" && x.TransmittingCountry != "ES")
                .Select(x => new { Transmitter = x.B021, Country = x.TransmittingCountry})
                .Distinct();

            foreach (var d in deliveries)
                Console.WriteLine("{0} {1}", d.Transmitter);

            //Task 2 - Add Records to Encrypt & Submit Settings Table.
            Console.WriteLine("Retrieved Deliveries from View:");
            foreach (var d in deliveries)
            {
                Console.WriteLine("Adding Settings for - {0}", d.Transmitter);
                context.EncryptSubmitSettings
                    .AddOrUpdate(
                    new EncryptSubmitSetting
                    {
                        DatabaseId = DatabaseNumber, //Point to Database
                        Transmitter = d.Transmitter,
                        Country = d.Country,
                        Regime = "US FATCA",
                        Production = TestDataType, //True = Production Data
                        ServerName = null,
                        Username = "fitaxidestest", //Can Change Default Values if needed.
                        Password = "N8jJTIPaKXItjhvqbJ8WIIs0G+t/5QqR3/Hs95vXJgs=",
                        Email = "fitaxidestest@bearingpoint.com",
                        DataPacketSigningCert = "Bank_AT#AT#US FATCA#Production#DataPacketSigningCert.pfx",
                        DataPacketSigningCertPassword = "N8PwGilHHdYHtXQge7xFCoWcQkVAr5Z5saxaLh8whRfmiLGt1g+uzqyoe/efDIxNz5JA8i76zNvDnye430lmYA==",
                        SFTPServer = "www.idesgateway.com",
                        SFTPPort = "4022",
                        SFTPUsername = "diarmuid.delaney",
                        SFTPPassword = "V8cBePrI1hA0l88KU2WsZ2arn1CMnpQM0CDEB9byvDo=",
                        MailServerType = "Exchange",
                        
                    }
                    );
            }
            context.SaveChangesAsync();
            Console.ReadKey();
        }
    }
}
