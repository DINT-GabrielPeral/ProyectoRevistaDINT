using Microsoft.Win32;

namespace ProyectoRevistaDINT.Servicios
{
    public class DialogosService
    {
        public string AbrirDialogoCargar(string funcionalidad)
        {
            OpenFileDialog dialogoCargar = new OpenFileDialog();
            AzureService sa = new AzureService();
            switch (funcionalidad.ToUpper())
            {
                case "IMAGEN":
                    dialogoCargar.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                    break;
            }

            return dialogoCargar.ShowDialog() == true ? sa.SubirImagen(dialogoCargar.FileName) : null;
        }
    }
}