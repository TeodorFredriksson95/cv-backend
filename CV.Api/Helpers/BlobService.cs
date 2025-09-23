using Azure.Storage.Blobs;

namespace CV_backend.Helpers
{
    public class BlobService
    {
        private string connectionString = ""; // Find this in your Azure Storage Account settings

        public async Task UploadTextToBlobAsync(string content, string containerName, string blobName)
        {
            try
            {
                // Create a BlobServiceClient
                var blobServiceClient = new BlobServiceClient(connectionString);

                // Get a reference to a container
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);

                // Get a reference to a blob
                var blobClient = blobContainerClient.GetBlobClient(blobName);

                // Upload text to the blob
                using var memoryStream = new MemoryStream();
                using var writer = new StreamWriter(memoryStream);
                writer.Write(content);
                writer.Flush();
                memoryStream.Position = 0;

                await blobClient.UploadAsync(memoryStream, overwrite: true);
                Console.WriteLine($"Uploaded to Blob storage as blob:\n{blobClient.Uri}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
