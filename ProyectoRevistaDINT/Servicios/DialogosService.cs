using Microsoft.Win32;
using System.Windows;

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

        public void MostrarDialogo(string text, string title, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(text, title, button, icon);
        }

        public MessageBoxResult MostrarDialogoPregunta(string text, string title, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(text, title, button, icon);
        }
    }
}