using System;
using System.Collections.Generic;

namespace SistemaBiblioteca
{
    class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public bool Disponivel { get; set; } = true;

        public void ExibirInfo()
        {
            Console.WriteLine($"Livro: {Titulo}, Autor: {Autor}, Ano: {AnoPublicacao}, Disponível: {Disponivel}");
        }
    }

    class Leitor
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }

        public void ExibirInfo()
        {
            Console.WriteLine($"Leitor: {Nome}, Idade: {Idade}, Endereço: {Endereco}");
        }
    }

    class Emprestimo
    {
        public Livro Livro { get; set; }
        public Leitor Leitor { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public void ExibirEmprestimo()
        {
            Console.WriteLine($"Empréstimo -> Livro: {Livro.Titulo}, Leitor: {Leitor.Nome}, " +
                              $"Data Empréstimo: {DataEmprestimo:dd/MM/yyyy}, Data Devolução: {DataDevolucao:dd/MM/yyyy}");
        }
    }

    class Biblioteca
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Livro> Livros { get; set; } = new List<Livro>();

        public void AdicionarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        public void ListarLivros()
        {
            Console.WriteLine($"\n📚 Lista de Livros da {Nome}:");
            foreach (var livro in Livros)
            {
                livro.ExibirInfo();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca
            {
                Nome = "Biblioteca Central",
                Endereco = "Rua das Flores, 123"
            };

            Livro livro1 = new Livro { Titulo = "A Biblioteca da Meia-Noite", Autor = "Matt Haig", AnoPublicacao = 2020 };
            Livro livro2 = new Livro { Titulo = "Textos cruéis demais para serem lidos rapidamente", Autor = "Igor Pires", AnoPublicacao = 2017 };

            biblioteca.AdicionarLivro(livro1);
            biblioteca.AdicionarLivro(livro2);

            Leitor leitor = new Leitor { Nome = "Samara", Idade = 18, Endereco = "Av. Brasil, 456" };

            if (livro1.Disponivel)
            {
                Emprestimo emprestimo = new Emprestimo
                {
                    Livro = livro1,
                    Leitor = leitor,
                    DataEmprestimo = DateTime.Now,
                    DataDevolucao = DateTime.Now.AddDays(7)
                };

                livro1.Disponivel = false;

                biblioteca.ListarLivros();
                leitor.ExibirInfo();
                emprestimo.ExibirEmprestimo();

                Console.WriteLine($"\nResumo: O leitor {leitor.Nome} tem {leitor.Idade} anos e pegou emprestado o livro " +
                                  $"\"{livro1.Titulo}\" de {livro1.Autor} na {biblioteca.Nome}. " +
                                  $"Ele precisa devolver o livro em {emprestimo.DataDevolucao:dd/MM/yyyy}.");
            }
            else
            {
                Console.WriteLine("Livro não está disponível.");
            }
        }
    }
}