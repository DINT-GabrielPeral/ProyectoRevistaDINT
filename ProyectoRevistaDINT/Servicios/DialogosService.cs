using Microsoft.Win32;
using System.Windows;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer los diálogos que existen en los sistemas operativos
    /// </summary>
    public class DialogosService
    {
        /// <summary>
        /// Este método sirve para abrir el diálogo de cargar un archivo
        /// </summary>
        /// <param name="funcionalidad">En este parámetro se almacena el tipo de archivo que se necesita, por ejemplo una imagen, un PDF, un video, etc.</param>
        /// <returns>Este método devuelve la ruta local del archivo cargado por el usuario.</returns>
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

        /// <summary>
        /// Este método sirve para mostrar un diálogo de información al usuario.
        /// </summary>
        /// <param name="text">En este parámetro se recibe el texto descriptivo del diálogo.</param>
        /// <param name="title">En este parámetro se recibe el título del diálogo para saber qué tipo de información nos están diciendo.</param>
        /// <param name="button">En este parámetro se recibe el tipo de botón que va a tener el diálogo, dependiendo del tipo puede haber uno o dos botones.</param>
        /// <param name="icon">En este parámetro se recibe el icono del diálogo para saber el tipo de información es informativo, de error, de advertencia, etc.</param>
        public void MostrarDialogo(string text, string title, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(text, title, button, icon);
        }

        /// <summary>
        /// Este método sirve para mostrar un diálogo de pregunta al usuario diciendo si está seguro de que quiere realizar la acción.
        /// </summary>
        /// <param name="text">En este parámetro se recibe la pregunta para decirle al usuario de que piense bien en lo que va a hacer.</param>
        /// <param name="title">En este parámetro se recibe el título del diálogo diciendo el tipo de pregunta que se le está mostrando.</param>
        /// <returns>Este método devuelve el resultado de la acción realizada en el diálogo, es decir, si el usuario le ha dado al botón de Sí o al botón de No.</returns>
        public MessageBoxResult MostrarDialogoPregunta(string text, string title)
        {
            return MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
    }
}