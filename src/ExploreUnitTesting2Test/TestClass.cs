using ExploreUnitTesting2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreUnitTesting2Test
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public async Task TestStartup()
        {
            var host = new WebHostBuilder()
			    .UseKestrel()
			    .UseContentRoot(Directory.GetCurrentDirectory())
			    .UseIISIntegration()
			    .UseStartup<Startup>()
			    .Build();

            using (var server = TestServer.Create<Startup>())
            {
                var response = await server.HttpClient.GetAsync("/Home");
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine("body: ");
                Console.WriteLine(body);
                Assert.IsTrue(body.Contains("Hello World!"));
            }
        }
    }
}
