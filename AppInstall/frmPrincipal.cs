using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apps.DataDb.Models;
using Apps.DataDb.Repositories;
using Apps.Utils;

namespace AppInstall
{
    public partial class FrmPrincipal : Form
    {
        private static readonly HttpClient Client = new HttpClient();

        public FrmPrincipal()
        {
            InitializeComponent();
                       
            Client.BaseAddress = new Uri(Config.UrlApi());
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Pesquisa();
            textBox1.Focus();
        }

        private static async Task<IEnumerable<App>> GetItems(string path)
        {
            var response = await Client.GetAsync("/v1/search/" + path);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadAsAsync<List<App>>();
        }

        private async void Pesquisa()
        {
            listBox1.Items.Clear();

            //                        var list = repoApp.FindByText(textBox1.Text);

            try
            {
                var list = await GetItems(textBox1.Text);
                //                Console.WriteLine("Items read using the web api GET");
                //                Console.WriteLine(string.Join(string.Empty, items.Aggregate((current, next) => current + ", " + next)));

                foreach (var a in list)
                {
                    listBox1.Items.Add(a);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar acessar o servidor: \n\n" + e.Message);

                //                Console.WriteLine(e.Message);
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            else
            {
                Data2Label(new App());
            }
        }

        public void Execute(object obj)
        {
            var app = (obj as App);

            try
            {
                Process p = new Process();
                p.StartInfo.FileName = app.PathExe;
                p.StartInfo.Arguments = app.ParamSilentInstall;

                p.Start();
            }
            catch
            {
                MessageBox.Show("Não foi possível executar o programa selecionado.");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Pesquisa();

            //IConfiguration config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", true, true)
            //    .Build();

            //var ctx = new AppDbContext();

            //var repoApp = new AppsRepository(ctx);

            //var list = repoApp.GetAllAsync().ConfigureAwait(true).GetAwaiter().GetResult();

            //var list = await repoApp.GetAllAsync();

            /*
            var list = repoApp.GetAll();
            foreach (var s in list)
            {
                listBox1.Items.Add(s);
            }
            */

            /*
            var ctx = new AppDbContext();


            string connectionString;
            MySqlConnection cnn;
            connectionString = @"Server=localhost;userid=root;pwd=sasasa;port=3306;database=apps";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();

            var repoApp = new AppsRepository(cnn);


            //MessageBox.Show("Connection Open  !");
            cnn.Close();
            */
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Execute(listBox1.SelectedItem);
            //MessageBox.Show((listBox1.SelectedItem as App).PathExe);
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // MÉTODO NÃO UTILIZADO
            // SOLUÇÃO ADOTADA (OVERRIDE DE ToString()) NA CLASS App

            //e.DrawBackground();
            //if (e.Index != -1)
            //{
            //    e.Graphics.DrawString((listBox1.Items[e.Index] as App).Nome, Font, SystemBrushes.ControlText, e.Bounds);
            //}

            /*
                        if (listBox1.Items[e.Index] != "none")
                        {
                            using (var brush = new SolidBrush(Color.FromName(Colors[e.Index])))
                            {
                                e.Graphics.FillRectangle(brush, e.Bounds);
                            }
                        }
                        e.Graphics.DrawString(Colors[e.Index], Font, SystemBrushes.ControlText, e.Bounds);
            */
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data2Label((listBox1.SelectedItem as App));
        }

        private void Data2Label(App app)
        {
            lblNome.Text = app.Nome;
            lblPlataforma.Text = app.Plataforma;
            lblVersao.Text = app.Versao;
            lblDescricao.Text = app.Descricao;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Pesquisa();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                if (listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex--;
                }
            }
        }

        private void lblDescricao_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
