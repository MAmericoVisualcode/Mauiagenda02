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
            // Valida��o dos campos
            if (string.IsNullOrWhiteSpace(txt_descricao.Text))
            {
                await DisplayAlert("Aten��o", "A descri��o n�o pode estar vazia.", "OK");
                return;
            }

            if (!double.TryParse(txt_quantidade.Text, out double quantidade))
            {
                await DisplayAlert("Aten��o", "Quantidade inv�lida.", "OK");
                return;
            }

            if (!double.TryParse(txt_preco.Text, out double preco))
            {
                await DisplayAlert("Aten��o", "Pre�o inv�lido.", "OK");
                return;
            }

            if (quantidade < 0)
            {
                await DisplayAlert("Aten��o", "Quantidade n�o pode ser negativa.", "OK");
                return;
            }

            if (preco < 0)
            {
                await DisplayAlert("Aten��o", "Pre�o n�o pode ser negativo.", "OK");
                return;
            }

            // Cria��o do objeto Produto
            Properties.Models.Produto produto = new Properties.Models.Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = quantidade,
                Preco = preco
            };

            // Inser��o no banco de dados
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