using Homework3.DataModels;
using Homework3.Helpers;
using Homework3.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;

namespace Homework3.Test
{
    [TestClass]
    public class APIHomeworkTest : ApiBaseTest
    {
        private readonly List<PetJsonModel> petcleanUpList = new List<PetJsonModel>();

        /// <summary>
        /// Add the 
        /// </summary>
        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }

        /// <summary>
        /// Get the created pet
        /// </summary>
        [TestMethod]
        public async Task GetPet()
        {
            // ARRANGE
            var petGetRequest = new RestRequest(Endpoints.GetPetById(PetDetails.Id));
            petcleanUpList.Add(PetDetails);

            // ACT
            var getResponse = await RestClient.ExecuteGetAsync<PetJsonModel>(petGetRequest);

            // ASSERTIONS
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode, "Status code is not equal to 200");
            Assert.AreEqual(PetDetails.Name, getResponse.Data.Name, "Name did not match.");
            Assert.AreEqual(PetDetails.Category.Id, getResponse.Data.Category.Id, "Category Id did not match.");
            Assert.AreEqual(PetDetails.Category.Name, getResponse.Data.Category.Name, "Category name did not match.");
            Assert.AreEqual(PetDetails.PhotoUrls[0], getResponse.Data.PhotoUrls[0], "Photo URLs did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Id, getResponse.Data.Tags[0].Id, "Tags did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Name, getResponse.Data.Tags[0].Name, "Tags did not match.");
            Assert.AreEqual(PetDetails.Status, getResponse.Data.Status, "Status did not match.");
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            foreach (var data in petcleanUpList)
            {
                var deletePetRequest = new RestRequest(Endpoints.GetPetById(data.Id));
                var deletePetResponse = await RestClient.DeleteAsync(deletePetRequest);
            }
        }
    }
}
