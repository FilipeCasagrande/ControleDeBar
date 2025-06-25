using ControleDeBar.ConsoleApp.Compartilhado;
namespace ControleDeBar.ConsoleApp.ModuloGarçons
{
    public class TelaGarcon : TelaBase<Garcon>, ITela
    {
        public TelaGarcon(RepositorioGarcon repositorioGarcon) : base("Garçon", repositorioGarcon)
        {
        }

        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");
           
            Console.WriteLine();

            Garcon novoRegistro = ObterDados();

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

            Garcon[] garcon = repositorio.SelecionarRegistros();

            for (int i = 0; i < garcon.Length; i++)
            {
                Garcon garconRegistrado = garcon[i];

                if (garconRegistrado == null)
                {
                    continue;
                }
                if (garconRegistrado.Nome == garcon[i].Nome || garconRegistrado.CPF == garcon[i].CPF)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não pode haver dois garçons com o memso nome ou  CPF");
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
            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Garçons");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -30}",
                "Id", "Nome", "CPF"
            );

            Garcon[] garcons = repositorio.SelecionarRegistros();

            for (int i = 0; i < garcons.Length; i++)
            {
                Garcon g = garcons[i];

                if (g == null)
                    continue;


                Console.WriteLine(
                  "{0, -10} | {1, -15} | {2, -30}",
                    g.Id, g.Nome, g.CPF
                );
            }

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }


        protected override Garcon ObterDados()
        {

            Console.Write("Informe o Nome do Garçon: ");
            string nome = Console.ReadLine();

            Console.Write("Infome o CPF do garçon: ");
            string CPF = Console.ReadLine();

            Garcon garcon = new Garcon(nome, CPF);

            return garcon;

        }
    }
}
