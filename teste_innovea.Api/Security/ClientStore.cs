using teste_innovea.Service._Ports;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrantTypes = IdentityServer4.Models.GrantTypes;

namespace teste_innovea.Api.Security
{
    public class ClientStore : IClientStore
    {
        
        public ClientStore()
        {
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("TESTE_INNOVEA", "teste_innovea Api")
            };
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            dynamic usuario = new { };
            if (usuario == null)
                return null;
            return new Client()
            {
                ClientId = usuario.CodigoMasterKey,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(usuario.CodigoSecretKey.Sha256())
                },
                AllowedScopes = { "TESTE_INNOVEA_V2" }
            };
        }
    }
}
