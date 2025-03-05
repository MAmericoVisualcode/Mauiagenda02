namespace Mauiagenda02.Resources.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Validação dos campos
            if (string.IsNullOrWhiteSpace(txt_descricao.Text))
            {
                await DisplayAlert("Atenção", "A descrição não pode estar vazia.", "OK");
                return;
            }

            if (!double.TryParse(txt_quantidade.Text, out double quantidade))
            {
                await DisplayAlert("Atenção", "Quantidade inválida.", "OK");
                return;
            }

            if (!double.TryParse(txt_preco.Text, out double preco))
            {
                await DisplayAlert("Atenção", "Preço inválido.", "OK");
                return;
            }

            if (quantidade < 0)
            {
                await DisplayAlert("Atenção", "Quantidade não pode ser negativa.", "OK");
                return;
            }

            if (preco < 0)
            {
                await DisplayAlert("Atenção", "Preço não pode ser negativo.", "OK");
                return;
            }

            // Criação do objeto Produto
            Properties.Models.Produto produto = new Properties.Models.Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = quantidade,
                Preco = preco
            };

            // Inserção no banco de dados
            await App.Db.Insert(produto);

            // Exibe mensagem de sucesso
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

            // Limpa os campos de texto
            txt_descricao.Text = string.Empty;
            txt_quantidade.Text = string.Empty;
            txt_preco.Text = string.Empty;
        }
        catch (Exception ex)
        {
            // Exibe mensagem de erro
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}