using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace Builders.Application.IntegrationTests.Setup
{
    public class Fixture : IDisposable
    {
        public HttpClient Client;

        public Fixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost"),
            };

            var factory = new AppFactory();
            Client = factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
