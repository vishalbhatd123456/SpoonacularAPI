public class SpoonacularClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com";
    private const string ApiKey =  "YOUR_API_KEY";
    private const string Host = "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com";

    public SpoonacularClient(HttpClient httpClient)
    {
        -httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key",ApiKey);
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", Host);
    }
    public async Task<string> SearchRecipesAsync(string ingredients)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/recipes/findByIngredients?ingredients={ingredients}&number=5");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}