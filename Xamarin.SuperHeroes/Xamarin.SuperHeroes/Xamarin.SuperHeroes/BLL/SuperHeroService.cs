using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.SuperHeroes.Models;
using Newtonsoft.Json;

namespace Xamarin.SuperHeroes.BLL
{
    class SuperHeroService
    {
        /// <summary>
        /// Gets a collection of super heroes from a web resource
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SuperHeroModel>> GetSuperHeroesAsync()
        {
            using (var client = new HttpClient())
            {
                var jsonResourceUrl = "http://www.leoreading.com/Content/superheroes.json";
                var request = await client.GetAsync(jsonResourceUrl);
                var jsonText = request.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<SuperHeroModel>>(jsonText);
            } // end using
        } // end get super heroes async
    } // end super hero service class
} // end namespace