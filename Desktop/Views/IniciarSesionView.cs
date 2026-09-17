using Firebase.Auth;
using Firebase.Auth.Providers;

namespace Desktop.Views
{
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient? firebaseAuthClient;
        int intentos = 0;

        public IniciarSesionView()
        {
            InitializeComponent();
            ConfiguracionFirebaseAuthClient();
        }

        private void ConfiguracionFirebaseAuthClient()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyCZwt5YsrJMtpko94WVtP2S45f9ABYYvDM",
                AuthDomain = "inventarioisp20juampi.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            firebaseAuthClient = new FirebaseAuthClient(config);
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            intentos++;
            try
            {
                var user = await firebaseAuthClient!.SignInWithEmailAndPasswordAsync(txtUsuario.Text, txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }
                MessageBox.Show($"Bienvenido, {user.User}!");
                this.Hide();
                var mainView = new MenuPrincipalView();
                mainView.Show();
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Reason}");
            }
            if (intentos >= 3)
            {
                MessageBox.Show("Has alcanzado el número máximo de intentos. La aplicación se cerrará.");
                Application.Exit();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerPassword.Checked ? '\0' : '*';
        }
    }
}
