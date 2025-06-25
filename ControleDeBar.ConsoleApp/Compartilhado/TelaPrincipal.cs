using ControleDeBar.ConsoleApp.Modulo_Conta;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;

namespace ControleDeBar.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private RepositorioConta repositorioConta;
    private TelaConta telaConta;

    private RepositorioMesa repositorioMesa;
    private TelaMesa telaMesa;

    private RepositorioGarcon repositoioGarcon;
    private TelaGarcon telaGarcon;

    private RepositorioProduto repositoProduto;
    private TelaProduto telaProduto;

    public TelaPrincipal()
    {
        repositoioGarcon = new RepositorioGarcon();
        telaGarcon = new TelaGarcon(repositoioGarcon);

        repositoProduto = new RepositorioProduto();
        telaProduto = new TelaProduto(repositoProduto);

        repositorioMesa = new RepositorioMesa();
        telaMesa = new TelaMesa(repositorioMesa);

        repositorioConta = new RepositorioConta();
        telaConta = new TelaConta(repositorioConta,
                                  repositoProduto,
                                  repositorioMesa, 
                                  repositoioGarcon);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|           Controle de Bar            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Mesas");
        Console.WriteLine("2 - Controle de Garçons");
        Console.WriteLine("3 - Controle de Produtos");
        Console.WriteLine("4 - Controle de Contas");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()![0];
    }

    public ITela ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaMesa;

        if (opcaoEscolhida == '2')
            return telaGarcon;

        if (opcaoEscolhida == '3')
            return telaProduto;

        if (opcaoEscolhida == '4')
            return telaConta;

        return null;
    }
}
