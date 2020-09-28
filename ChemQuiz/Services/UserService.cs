using ChemQuiz.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuiz.Services
{
    public class UserService : IService<Task<User>, User>
    {
        private AuthenticationResult authenticationResult;
        public UserService(AuthenticationResult authenticationResult)
        {
            this.authenticationResult = authenticationResult;
        }
        public async Task<User> Create(User a)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByID(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByAuthID(string Id)
        {
            try
            {
                User user = new User();
                var baseAddr = new Uri(Constants.URL);
                var client = new HttpClient { BaseAddress = baseAddr };

                var reviewUri = new Uri(baseAddr, "appuser/" + Id);

                var request = new HttpRequestMessage(HttpMethod.Get, reviewUri);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);

                var response = await client.SendAsync(request);
                
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                }
                else if(response.StatusCode == HttpStatusCode.NotFound)
                {
                    //se não existir cria um novo
                    request = new HttpRequestMessage(HttpMethod.Post, new Uri(baseAddr, "appuser/"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
                    var newUser = new User()
                    {
                        Coins = 200,
                        AuthId = Constants.LoggedUser.AuthId,
                    };
                    string json = JsonConvert.SerializeObject(newUser);
                    StringContent strcontent = new StringContent(json, Encoding.UTF8, "application/json");
                    request.Content = strcontent;
                    response = await client.SendAsync(request);
                    string content = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
                    user = JsonConvert.DeserializeObject<User>(content);
                }
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }

        public Task<User> Update(User a)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Task<User>> IService<Task<User>, User>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
