using System;
using System.Globalization;
using curso.dominio;

namespace curso {
    class Tela {

        // interacao com o usuario

        public static void mostrarMenu() {
            Console.WriteLine("1 - Listar produtos ordenados");
            Console.WriteLine("2 - Cadastrar produto");
            Console.WriteLine("3 - Cadastrar pedido");
            Console.WriteLine("4 - Mostrar dados de um pedido");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("Digite um opção");
        }
        public static void mostarProdutos() {
            Console.WriteLine("Listagem de produtos: ");
            for (int i = 0; i < Program.produtos.Count; i++) {
                Console.WriteLine(Program.produtos[i]);
            }
        }

        public static void cadastrarProduto() {
            Console.WriteLine("Digite os dados do novo produto: ");
            Console.Write("Codigo: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Produto produtoNovo = new Produto(codigo, descricao, preco);
            Program.produtos.Add(produtoNovo);
            Program.produtos.Sort();
        }

        public static void cadastrarPedido() {
            Console.WriteLine("Digite os dados so pedido: ");
            Console.Write("Codigo: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Pedido p = new Pedido(codigo, dia, mes, ano);

            Console.Write("Quantos itens tem o pedido? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Digite os dados do " + i + "° item:");
                Console.Write("Produto (código): ");
                int codProduto = int.Parse(Console.ReadLine());
                int pos = Program.produtos.FindIndex(x => x.codigo == codProduto);
                if (pos == -1) {
                    throw new ModelException("Codigo de produto nao encontrado" + codProduto);
                }
                Console.Write("Quantidade: ");
                int qte = int.Parse(Console.ReadLine());

                Console.Write("Porcentagem de desconto: ");
                double desconto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                ItemPedido ip = new ItemPedido(qte, desconto, p, Program.produtos[pos]);
                p.itens.Add(ip);
            }
            Program.pedidos.Add(p);
        }

        public static void mostarPedido() {
            Console.WriteLine("Digite o codigo do pedido: ");
            int codpedido = int.Parse(Console.ReadLine());
            int pos = Program.pedidos.FindIndex(x => x.codigo == codpedido);
            if(pos == -1) {
                throw new ModelException("Codigo do peido não encontrado" + codpedido);
            }
            Console.WriteLine(Program.pedidos[pos]);
            Console.WriteLine();
        }
    }
}
