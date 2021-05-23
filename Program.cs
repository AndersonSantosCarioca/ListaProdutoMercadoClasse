using System;
using System.Collections.Generic;
using System.Linq;
using ListaProdutoMercadoClasse.Classes;

namespace ListaProdutoMercadoClasse
{
    class Program
    {
        /*
        <Escrever um programa que recebe alguns produtos commo argumento; <OK>
        <Validar se os produtos estão na lista de ítens do mercado;<OK>
        < Caso estejam, avisar quais produtos estão disponíveis;
        <Quais produtos não estão disponíveis;
        < exibir lista em ordem alfabética.
        */

        static void Main(string[] argumentos)
        {
            List<Produto> produtosDisponiveis = new List<Produto>();
            produtosDisponiveis.Add(new Produto() { Nome = "pao", Preco = 0.60});
            produtosDisponiveis.Add(new Produto() { Nome = "margarina", Preco = 3.60});
            produtosDisponiveis.Add(new Produto() { Nome = "leite", Preco = 3.90});
            produtosDisponiveis.Add(new Produto() { Nome = "tomate", Preco = 4.40});
            produtosDisponiveis.Add(new Produto() { Nome = "massa de tomate", Preco = 1.99});
            produtosDisponiveis.Add(new Produto() { Nome = "azeite", Preco = 11.99});
            produtosDisponiveis.Add(new Produto() { Nome = "alface", Preco = 1.00});
            produtosDisponiveis.Add(new Produto() { Nome = "carne", Preco = 35.50});

            if(argumentos.Length == 0)
            {
                Console.WriteLine("Você não passou os produtos que deseja comprar");
                return;
            }

            // Validar se os produtos estão na lista de itens disponíveirs no mercado

            var produtosSelecionadosDisponiveis = produtosDisponiveis.Where(produto => argumentos.Any(argumento => produto.Nome.ToUpper() == argumento.ToUpper()));

            foreach(var produto in produtosSelecionadosDisponiveis)
            {
                Console.WriteLine($"este produto nós temos:{produto.ExibirDadosProduto()}");
            }

            var produtosSelecionadosNaoDisponiveis = argumentos.Where(argumento =>
                     !produtosDisponiveis.Any(produto => produto.Nome.ToUpper() == argumento.ToUpper()));

            foreach(var produtoNaoDisponivel in produtosSelecionadosNaoDisponiveis)
            {
                Console.WriteLine($"este produto nós não temos {produtoNaoDisponivel}");
            }

            //Exibir a lista de produtos disponíveis ordenados em ordem alfabética
            //Par que o usuário possa escolher da próxima vez

            var produtosOrdenadosPorNome = produtosDisponiveis.OrderBy(produto => produto.Nome).ToList();
            foreach(var produtoOrdenado in produtosOrdenadosPorNome)
            {
                Console.WriteLine(produtoOrdenado.ExibirDadosProduto());
            }


            
        }
    }
}
