using Homework3.DataModels;
using Homework3.Resources;
using Homework3.Test.TestData;
using RestSharp;

namespace Homework3.Helpers
{
    /// <summary>
    /// Class containing all method for pets
    /// </summary>
    public class PetHelper
    {
        /// <summary>
        /// Send POST request to add new pet
        /// </summary>
        public static async Task<PetJsonModel> AddNewPet(RestClient client)
        {
            var newPetData = GeneratePet.PetDetails();
            var postRequest = new RestRequest(Endpoints.PostPet());

            // Send Post Request to add new pet
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<PetJsonModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
