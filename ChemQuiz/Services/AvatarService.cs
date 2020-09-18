using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ChemQuiz.Models;
using Newtonsoft.Json;

namespace ChemQuiz.Services
{
    public class AvatarService : IService<Task<Avatar>,Avatar>
    {
        HttpClient client;

        public AvatarService()
        {
            client = new HttpClient();
        }

        public Task<Avatar> Create(Avatar a)
        {
            throw new NotImplementedException();
        }

        public Task<Avatar> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Avatar>> FindAll()
        {
            List<Avatar> Items = new List<Avatar>();
            Uri uri = new Uri(string.Format(Constants.URL + "avatar"));
            HttpResponseMessage response = await client.GetAsync(uri);
            
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                
                Items = JsonConvert.DeserializeObject<List<Avatar>>(content);
            }
            return Items;
        }

        public Task<Avatar> FindByID(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Avatar> Update(Avatar a)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Task<Avatar>> IService<Task<Avatar>, Avatar>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
