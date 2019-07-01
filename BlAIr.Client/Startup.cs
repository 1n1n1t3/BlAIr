using BlAir.Client;
using BlAIr.Client.Services.Contracts;
using BlAIr.Client.Services.Implementations;
using BlAIr.Client.States;
using Microsoft.AspNetCore.Blazor.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlAIr.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddAuthorizationCore();
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            WebAssemblyHttpMessageHandler.DefaultCredentials = FetchCredentialsOption.Include;
            app.AddComponent<App>("app");
        }
    }
}
