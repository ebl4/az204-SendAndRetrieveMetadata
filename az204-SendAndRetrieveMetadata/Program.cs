using az204_SendAndRetrieveMetadata;
using Azure.Storage.Blobs;

string conectionString = "CONNECTION_STRING";

BlobServiceClient blobServiceClient = new BlobServiceClient(conectionString);

string containerName = "wtblob" + Guid.NewGuid().ToString();

BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

await ContainerMetadata.AddContainerMetadataAsync(containerClient);
await ContainerMetadata.ReadContainerMetadataAsync(containerClient);