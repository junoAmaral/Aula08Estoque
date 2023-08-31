namespace Aula08Estoque
{
    public partial class Form1 : Form
    {
        //Variáveis globais
        List<string> produto_nome = new List<string>();
        List<int> produto_quantidade = new List<int>();

        //-----------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
        }

        //Minhas funções
        void adiciona_produto()
        {
            string nome = txtNome.Text;
            int quantidade = int.Parse(txtQuantidade.Text);
            produto_nome.Add(nome);
            produto_quantidade.Add(quantidade);
        }

        void atualiza_interface()
        {
            int quantidade_cadastrada = produto_nome.Count();
            lblCadastrados.Text = quantidade_cadastrada.ToString();
        }

        void limpa_campos()
        {
            txtNome.Clear();
            txtQuantidade.Clear();
            txtNome.Focus();
        }

        void mostra_produto(bool primeiro)
        {
            if (lista_vazia() == true)
            {
                MessageBox.Show("Não há produtos cadastrados.");
                return;
            }

            string nome;
            int quantidade;

            if (primeiro == true)
            {
                nome = produto_nome[0];
                quantidade= produto_quantidade[0];
            }
            else
            {
                nome = produto_nome[produto_nome.Count - 1];
                quantidade = produto_quantidade[produto_quantidade.Count - 1];
            }

            MessageBox.Show($"Nome: {nome}, Quantidade: {quantidade}");
        }

        void deleta_produto()
        {
            if (lista_vazia() == true)
            {
                MessageBox.Show("Não há produtos cadastrados.");
            }
            else
            {
                produto_nome.RemoveAt(0);
                produto_quantidade.RemoveAt(0);
            }
        }

        bool lista_vazia()
        {
            if (produto_nome.Count > 0)
            {
                return false;
            }
            else
            { 
                return true; 
            }
        }

        //-----------------------------------------------------------------------

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            adiciona_produto();
            atualiza_interface();
            limpa_campos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpa_campos();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            mostra_produto(false);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            deleta_produto();
            atualiza_interface();
        }
    }
}