using Homework3.DataModels;

namespace Homework3.Test.TestData
{
    public class GeneratePet
    {
        public static PetJsonModel PetDetails()
        {
            return new PetJsonModel
            {
                Id = 2521,
                Category = new Category()
                {
                    Id = 2521,
                    Name = "RestSharp Category",
                },
                Name = "RestSharp.Post",
                PhotoUrls = new string[]
                {
                    "string"
                },
                Tags = new Category[]
                {
                    new Category() { Id = 2521, Name = "RestSharp Category" }
                },
                Status = "available"
            };
        }
    }
}
