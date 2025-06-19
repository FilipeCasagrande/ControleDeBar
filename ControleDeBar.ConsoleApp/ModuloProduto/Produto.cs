using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string Nome {  get; set; }
        public decimal Preco {  get; set; }


        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override void AtualizarRegistro(Produto registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            Preco = registroAtualizado.Preco;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Nome.Length < 2)
                erros += "O campo \"Nome\" deve conter mais que 2 caracteres.\n";

            return erros;
        }
    }
}
