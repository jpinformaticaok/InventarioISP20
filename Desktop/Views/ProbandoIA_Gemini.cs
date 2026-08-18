using Desktop.Models;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ProbandoIA_Gemini : Form
    {
        public ProbandoIA_Gemini()
        {
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            txtRespuesta.Text = "Procesando...";
            Env.Load("../../../");
            var apikey = Environment.GetEnvironmentVariable("APIKEY_GEMINI");
            if (apikey == null)
            {
                MessageBox.Show("No se encontró la variable de entorno 'APIKEY_GEMINI'.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtConsulta.Text))
            {
                MessageBox.Show("Por favor, ingrese una consulta.");
                return;
            }
            //txtRespuesta.Text = $"API Key: {apikey}";
            using (var client = new HttpClient())
            {
                var url = "https://generativelanguage.googleapis.com/v1beta/interactions";
                var requestBody = new
                {
                    model = "gemini-3.5-flash",
                    input = txtConsulta.Text
                };
                client.DefaultRequestHeaders.Add("x-goog-api-key", $"{apikey}");

                var response = await client.PostAsJsonAsync(url, requestBody);
                if (response == null)
                {
                    MessageBox.Show("Error: La respuesta del servidor es nula.");
                    return;
                }

                ResponseGemini? responseGemini = await response.Content.ReadFromJsonAsync<ResponseGemini>();

                if (responseGemini == null)
                {
                    MessageBox.Show("Error: No se pudo deserializar la respuesta del servidor.");
                    return;
                }
                txtRespuesta.Text = responseGemini.steps[1].content[0].text;
            }
        }
    }
}
