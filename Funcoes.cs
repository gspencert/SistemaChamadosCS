using System;
using System.Collections.Generic;
using System.IO;

static class Funcoes
{
    static List<Chamado> chamados = new();
    static int proximoId = 1;
    static string caminho = "chamados.csv";

    public static void CriarChamado()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine()!;

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine()!;

        chamados.Add(new Chamado
        {
            Id = proximoId,
            Titulo = titulo,
            Descricao = descricao,
            Status = "Aberto"
        });

        proximoId++;
        Console.WriteLine("Chamado criado!");
    }

    public static void ListarChamados()
    {
        if (chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado.");
            return;
        }

        foreach (var c in chamados)
            Console.WriteLine($"{c.Id} - {c.Titulo} - {c.Status}");
    }

    public static void SalvarArquivo()
    {
        using StreamWriter sw = new StreamWriter(caminho);

        foreach (var c in chamados)
            sw.WriteLine($"{c.Id};{c.Titulo};{c.Descricao};{c.Status}");

        Console.WriteLine("Arquivo salvo!");
    }

    public static void LerArquivo()
    {
        if (!File.Exists(caminho))
            return;

        chamados.Clear();

        foreach (var linha in File.ReadAllLines(caminho))
        {
            var dados = linha.Split(';');

            chamados.Add(new Chamado
            {
                Id = int.Parse(dados[0]),
                Titulo = dados[1],
                Descricao = dados[2],
                Status = dados[3]
            });
        }

        proximoId = chamados.Count + 1;
        Console.WriteLine("Arquivo carregado!");
    }
}