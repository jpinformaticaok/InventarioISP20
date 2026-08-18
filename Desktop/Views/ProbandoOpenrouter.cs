using Desktop.Models;
using Desktop.Services;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ProbandoOpenrouter : Form
    {
        public ProbandoOpenrouter()
        {
            InitializeComponent();
        }

        private async void ProbandoOpenrouter_Load(object sender, EventArgs e)
        {
            tsRespuestaProgreso.Visible = false;
            try
            {
                var freeModels = await OpenRouterService.GetFreeModelsAsync();

                comboBoxModelos.DataSource = freeModels;
                comboBoxModelos.DisplayMember = "Name"; // lo que se muestra
                comboBoxModelos.ValueMember = "Id";     // lo que usás para el request
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar modelos: {ex.Message}");
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            string modeloSeleccionado = comboBoxModelos.SelectedValue.ToString();

            txtRespuesta.Text = "Procesando...";
            tsRespuestaProgreso.Visible = true;
            btnEnviar.Enabled = false;

            Env.Load("../../../");
            var apikey = Environment.GetEnvironmentVariable("APIKEY_OPENROUTER");
            if (apikey == null)
            {
                MessageBox.Show("No se encontró la variable de entorno 'APIKEY_OPENROUTER'.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPregunta.Text))
            {
                MessageBox.Show("Por favor, ingrese una consulta.");
                return;
            }

            var requestBody = new
            {
                model = modeloSeleccionado,
                messages = new[]
                {
                    new { role = "user", content = txtPregunta.Text }
                }
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apikey);

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            var httpResponse = await client.PostAsync(
                "https://openrouter.ai/api/v1/chat/completions", content);

            string responseText = await httpResponse.Content.ReadAsStringAsync();

            var resultado = OpenRouterResult.Parse(responseText);

            if (resultado.Success)
            {
                txtRespuesta.Text = resultado.AnswerText;
                lblModelo.Text = $"Modelo: {resultado.ModelUsed}";
                lblTokens.Text = $"Total Tokens usados: {resultado.TotalTokens} ";
                lblTokensPrompt.Text = $"Tokens prompt: {resultado.PromptTokens}";
                lblTokensRespuesta.Text = $"Tokens respuesta: {resultado.CompletionTokens}";
            }
            else
            {
                MessageBox.Show($"Hubo un problema:\n{resultado.ErrorMessage}", "Error");
            }

            btnEnviar.Enabled = true;
            tsRespuestaProgreso.Visible = false;
        }

        private void txtPregunta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido "beep"
                btnEnviar.PerformClick();  // Simula un clic en el botón
            }
        }
    }
}
