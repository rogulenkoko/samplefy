using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Samplefy.FunctionApp.Models;

namespace Samplefy.FunctionApp;

public class UploadCover
{
    private const string CoversContainerName = "covers";

    [Function("UploadCover")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")]
        HttpRequest req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger<UploadCover>();
        try
        {
            var blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("BlobStorageConnectionString"));
            var containerClient = await GetContainerClient(blobServiceClient);
        
            var coverJson = req.Form["cover"];
            var coverImage = req.Form.Files["coverImage"];

            var cover = JsonConvert.DeserializeObject<CoverModel>(coverJson);
        
            if (cover == null)
            {
                logger.LogWarning("Cover information was not found");
                return new BadRequestObjectResult("Cover information was not found");
            }
            
            if (coverImage == null)
            {
                logger.LogWarning("Cover file was not found");
                return new BadRequestObjectResult("Cover file was not found");
            }
        
            var blobName = $"cover_{cover.RecordId}";
            var blobClient = containerClient.GetBlobClient(blobName);

            await using var blobStream = coverImage.OpenReadStream();
            await blobClient.UploadAsync(blobStream, overwrite: true);
        
            return new OkResult();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            throw;
        }
    }

    private static async Task<BlobContainerClient> GetContainerClient(BlobServiceClient client)
    {
        await foreach (var container in client.GetBlobContainersAsync(prefix: CoversContainerName))
        {
            if (container.Name == CoversContainerName)
            {
                return client.GetBlobContainerClient(CoversContainerName);
            }
        }

        var result = await client.CreateBlobContainerAsync(CoversContainerName);
        return result.Value;
    }
}