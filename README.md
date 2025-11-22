🌩️ **Azure Blob Storage Integration with ASP.NET Core MVC**

This project demonstrates how to integrate Azure Blob Storage (or Azurite, the local emulator) into an ASP.NET Core MVC application. The implementation includes container management, blob listing, service abstraction, and emulator-based development without requiring an Azure subscription.

📦 **Features**

List all blob containers
List blobs inside each container
Create and delete containers
Upload and manage blobs (via Storage Explorer)
Full service-layer abstraction using interfaces
Works with Azurite (local development) or real Azure Storage

🚀 **Technologies Used**

ASP.NET Core MVC
Azure.Storage.Blobs SDK
Azurite (Local Emulator)
Azure Storage Explorer

🧪 **Local Development with Azurite**
You can develop end-to-end without any Azure subscription.

Default Emulator Credentials
Blob Endpoint : http://127.0.0.1:10000/devstoreaccount1
Account Name  : devstoreaccount1
Key           : Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1...

**Tools Required**

Azurite VS Code Extension
Azure Storage Explorer
Attach Azurite in Storage Explorer → create containers → upload blobs → run the MVC project.

**Use Azure Blob Storage (or Azurite emulator) with ASP.NET Core MVC.**

- Add connection string in appsettings.json
- Register BlobServiceClient + ContainerService in Program.cs
- Use IContainerService to list/create/delete containers
- Use Azure Storage Explorer to upload blobs
- Works fully offline with Azurite



