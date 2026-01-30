class Program
{
    static void Main()
    {
        bool executando = true;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU CHAMADOS ===");
            Console.WriteLine("1 - Listar chamados");
            Console.WriteLine("2 - Criar chamado");
            Console.WriteLine("3 - Salvar chamados");
            Console.WriteLine("4 - Ler chamados");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");

            int.TryParse(Console.ReadLine(), out int opcao);

            switch (opcao)
            {
                case 1: Funcoes.ListarChamados(); Pause(); break;
                case 2: Funcoes.CriarChamado(); Pause(); break;
                case 3: Funcoes.SalvarArquivo(); Pause(); break;
                case 4: Funcoes.LerArquivo(); Pause(); break;
                case 5: Funcoes.SalvarArquivo(); executando = false; break;
                default: Console.WriteLine("Opção inválida!"); Pause(); break;
            }

        } while (executando);
    }

    static void Pause()
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}
