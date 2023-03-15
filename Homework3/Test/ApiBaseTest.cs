using Homework3.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Homework3.Test
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }
        public PetJsonModel PetDetails { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            RestClient = new RestClient();
        }
    }
}
