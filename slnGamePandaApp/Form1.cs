using System.Text.Json;

namespace slnGamePandaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7194/api/GamePanda");
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            label1.Text = json;

            List<CGame> games = JsonSerializer.Deserialize<List<CGame>>(json);
            dataGridView1.DataSource = games;
        }
    }
}