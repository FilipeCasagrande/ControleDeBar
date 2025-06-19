using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarçons;
namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase<Produto>, ITela
    {

        public TelaProduto(RepositorioProduto repositorioProduto) : base("Produto", repositorioProduto)
        {
        }

        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            Produto novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                CadastrarRegistro();
                return;
            }

            Produto[] produto = repositorio.SelecionarRegistros();

            for (int i = 0; i < produto.Length; i++)
            {
                Produto produtoRegistrado = produto[i];

                if (produtoRegistrado == null)
                {
                    continue;
                }
                if (produtoRegistrado.Nome == produto[i].Nome)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não pode haver dois produtos com o memso nome");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    CadastrarRegistro();

                    Console.ReadLine();
                    return;
                }
            }
            
            repositorio.CadastrarRegistro(novoRegistro);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ResetColor();

            Console.ReadLine();
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            {
                if (exibirCabecalho)
                    ExibirCabecalho();

                Console.WriteLine("Visualização de Produtos");

                Console.WriteLine();

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -30}",
                    "Id", "Nome Produto", "Preço"
                );

                Produto[] produtos = repositorio.SelecionarRegistros();

                for (int i = 0; i < produtos.Length; i++)
                {
                    Produto p = produtos[i];

                    if (p == null)
                        continue;


                    Console.WriteLine(
                      "{0, -10} | {1, -15} | {2, -30}",
                        p.Id, p.Nome, p.Preco.ToString("C2")
                    );
                }

                ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
            }

        }

        protected override Produto ObterDados()
        {

            Console.Write("Informe o Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Infome o preço do produto: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Produto produto = new Produto(nome, preco);

            return produto;
        }
    }
}
