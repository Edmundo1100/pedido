using System;
using System.Collections.Generic;
using System.Globalization;

namespace curso.dominio {
    class Pedido {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public List<ItemPedido> itens { get; set; }

        public Pedido(int codigo, int dia, int mes, int ano) {
            this.codigo = codigo;
            this.data = new DateTime(ano, mes, dia);
            this.itens = new List<ItemPedido>();
        }
        public double valorTotal() {
            double soma = 0.0;
            for (int i = 0; i < itens.Count; i++) {
                soma = itens[i].subTotal();
            }
            return soma;
        }
        public override string ToString() {
            String s = "Pedido: " + codigo
                + "data: " + data.Day + "/" + data.Month + "/" + data.Year + "\n"
                + "itens:\n ";

            for (int i = 0; i < itens.Count; i++) {
                s = s + itens[i].ToString() + "\n";
            }
            s = s + "Total do Pedido: " + valorTotal().ToString("F2", CultureInfo.InvariantCulture);
            return s;
        }
    }
}
