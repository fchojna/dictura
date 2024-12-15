using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Dictura.Api.Controllers;

[Route("[controller]")]
public class TestController(CosmosClient cosmosClient) : ControllerBase
{
    [HttpGet("echo")]
    public IActionResult Echo()
    {
        return Ok("echo");
    }

    [HttpGet("db")]
    public async Task<IActionResult> TestDb()
    {
        const string
            dbName = "TestDb",
            containerName = "TestContainer",
            itemId = "05d69b3f-4dc6-43c4-b227-be8a6841e0df";

        var container = cosmosClient.GetContainer(dbName, containerName);
        var response = await container.ReadItemAsync<dynamic>(itemId, new PartitionKey(itemId));
        var item = response.Resource;

        return Ok(new { environment = item.env.ToString() });
    }
}