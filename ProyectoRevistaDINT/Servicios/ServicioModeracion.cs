using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer la moderación de las palabras prohibidas en los artículos.
    /// </summary>
    class ServicioModeracion
    {
        /// <summary>
        /// Este método sirve para filtrar las palabras prohibidas que tenga un artículo en específico.
        /// </summary>
        /// <param name="textoArticulo">En este parámetro se recibe el texto del artículo a moderar para filtrar las palabras prohibidas que tenga.</param>
        /// <param name="listaSeleccionada"></param>
        /// <returns>Este método devuelve las palabras encontradas separadas por un espacio en blanco.</returns>
        public String devolverPalabrasFeas(String textoArticulo, String listaSeleccionada) 
        {
            // Load the input text.
            //string text = "Hola buenos dias amegos como estan. Yo culo muy bien la verdad";

            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("/contentmoderator/moderate/v1.0/ProcessText/Screen", Method.Post);
            request.AddHeader("Ocp-Apim-Subscription-Key", Properties.Settings.Default.ClaveAzureModeracion);
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", textoArticulo, ParameterType.RequestBody);

            var response = client.Execute(request);
            Root objeto = JsonConvert.DeserializeObject<Root>(response.Content);

            //StringBuilder palabrasFeas = new StringBuilder();
            List<String> palabritas = new List<string>();
            StringBuilder palabritasFiltradas = new StringBuilder();

            if (objeto.Terms != null)
            {
                foreach (var item in objeto.Terms)
                {
                    if (palabritas.Count == 0)
                        palabritas.Add(item.Term);
                    else if (!palabritas.Contains(item.Term))
                    {
                        palabritas.Add(item.Term);
                    }
                }

                foreach (var item in palabritas)
                {
                    palabritasFiltradas.Append(item + " ");
                }
            }
            else
                palabritasFiltradas.Append("0");

            return palabritasFiltradas.ToString();
        }
    }

    public class Root
    {
        public string OriginalText { get; set; }
        public string NormalizedText { get; set; }
        public object Misrepresentation { get; set; }
        public string Language { get; set; }
        public List<Termino> Terms { get; set; }
        public Status Status { get; set; }
        public string TrackingId { get; set; }
    }

    public class Status
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public object Exception { get; set; }
    }

    public class Termino
    {
        public int Index { get; set; }
        public int OriginalIndex { get; set; }
        public int ListId { get; set; }
        public string Term { get; set; }
    }
}
