using Azure.Storage.Blobs;
using System.IO;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer los servicios de la plataforma de Azure.
    /// </summary>
    public class AzureService
    {
        /// <summary>
        /// Este método sirve para subir una imagen local al contenedor de Azure Blob Storage.
        /// </summary>
        /// <param name="rutaImagenLocal">En este parámetro se almacena la ruta local de la imagen a subir.</param>
        /// <returns>Este método devuelve la URL de la imagen subida al contenedor de Azure Blob Storage.</returns>
        public string SubirImagen(string rutaImagenLocal)
        {
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialpablos;AccountKey=E3/ytDcBrNy5/XqhlF8stLFgAMnJT+QBz19F6WymeCcNxJJ31YlmgrMpCK+S/LYnt8R2no8GdrSF+AStSAOp5Q==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
            string nombreContenedorBlobs = "revista"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure
            string rutaImagen = rutaImagenLocal;

            //Obtenemos el cliente del contenedor
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            if (!clienteContenedor.GetBlobClient(nombreImagen).Exists())
            {
                clienteContenedor.UploadBlob(nombreImagen, streamImagen);
            }

            //Una vez subida, obtenemos la URL para referenciarla
            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;

            return urlImagen;
        }
    }
}
