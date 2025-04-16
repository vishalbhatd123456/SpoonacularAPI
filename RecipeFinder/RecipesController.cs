[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly SpoonacularClient _client;

    public RecipesController(SpoonacularClient client)
    {
        _client = client;
    }
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string ingredients)
    {
        var data = await _client.SearchRecipesAsync(ingredients);
        return Ok(data);
    }
}