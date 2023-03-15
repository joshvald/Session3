namespace Homework3.Resources
{
    /// <summary>
    /// Class containing all endpoints used in API tests
    /// </summary>
    public class Endpoints
    {
        // Base URL
        private static readonly string BaseURL = "https://petstore.swagger.io/v2";

        private static readonly string PetEndpoint = "pet";
        public static string GetPetById(long petId) => $"{BaseURL}/{PetEndpoint}/{petId}";
        public static string PostPet() => $"{BaseURL}/{PetEndpoint}";
        public static string DeletePetById(long petId) => $"{BaseURL}/{PetEndpoint}/{petId}";
    }
}
