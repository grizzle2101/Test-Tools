using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SettingsConfigurator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Display Confingured Connection Strings:
            Console.WriteLine("--- Encrypt & Submit Settings Generator ---");

            //Task 1 - Retrive Settings from Config
            var ConfiguredMainDatabase = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString);
            var ConfiguredSettingsDatabase = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SettingsContext"].ConnectionString);
            Console.WriteLine("---Application:[{0}]  & Target Database:[{1}]---", ConfiguredMainDatabase.InitialCatalog, ConfiguredSettingsDatabase.InitialCatalog);          

            //Task 2 - Lookup UserId using Config
            var DatabaseContext = new DatabaseContext();
            var TargetDatabaseId = DatabaseContext.UIDatabases
                .Where(d => d.Name.Contains(ConfiguredSettingsDatabase.InitialCatalog))
                .Select(d => new { d.ID, d.Name})
                .FirstOrDefault();

            var ID = TargetDatabaseId.ID.ToString();

            //Task 3 - Retrive Unique Records from View
            Console.WriteLine("--- Retreieving Data from View ----");
            var context = new SettingsContext();
            var deliveries = context.UI_vDeliveries
                .Where(x => x.Regime == "US FATCA" && x.TransmittingCountry != "ES")
                .Select(x => new { Transmitter = x.B021, Country = x.TransmittingCountry })
                .Distinct();

            foreach (var d in deliveries)
                Console.WriteLine("{0}", d.Transmitter);

            //Task 4 - Create Settings Using Data from View.
            Console.WriteLine("\n --- Adding Entries to EncryptSubmitSettings ---");
            foreach (var d in deliveries)
            {
                Console.WriteLine("Adding Settings for - {0}", d.Transmitter);
                context.EncryptSubmitSettings
                    .AddOrUpdate(
                    new EncryptSubmitSetting
                    {
                        DatabaseId = ID, //Point to Database
                        Transmitter = d.Transmitter,
                        Country = d.Country,
                        Regime = "US FATCA",
                        Production = true, //True = Production Data
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
            context.SaveChanges();
            Console.ReadKey();
        }
    }
}
