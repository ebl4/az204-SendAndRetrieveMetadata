using Azure;
using Azure.Storage.Blobs;

namespace az204_SendAndRetrieveMetadata
{
    public class ContainerMetadata
    {
        public static async Task AddContainerMetadataAsync(BlobContainerClient container)
        {
            try
            {
                IDictionary<string, string> metadata = new Dictionary<string, string>();

                // Add some metadata to the container
                metadata.Add("docType", "textDocuments");
                metadata.Add("category", "guidence");

                // Set the container's metadata
                await container.SetMetadataAsync(metadata);

            } catch (RequestFailedException e)
            {
                Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static async Task ReadContainerMetadataAsync(BlobContainerClient containerClient)
        {
            try
            {
                var properties = await containerClient.GetPropertiesAsync();

                // Enumerate the container's metadata
                foreach (var metadataItem in properties.Value.Metadata)
                {
                    Console.WriteLine($"\tKey: {metadataItem.Key}");
                    Console.WriteLine($"\tValue: {metadataItem.Value}");
                }
            } catch (RequestFailedException e)
            {
                Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
