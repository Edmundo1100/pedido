using System;
using System.Globalization;

namespace curso.dominio {
    class Produto : IComparable {
        public int codigo { get; set; }
        public String descricao { get; set; }
        public Double preco { get; set; }

        public Produto(int codigo, String descricao, double preco) {
            this.codigo = codigo;
            this.descricao = descricao;
            this.preco = preco;
        }

        public override string ToString() {
            return codigo
                + ", "
                + descricao
                + ", "
                + preco.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj) {
            Produto outro = (Produto)obj;
            int resultado = descricao.CompareTo(outro.descricao);
            if(resultado != 0) {
                return resultado;
            }
            else {
                return -preco.CompareTo(outro.preco);
            }
        }
    }
}

