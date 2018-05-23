using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cadastro
    {

        public int ID { get; set; }
        public String Descricao { get; set; }
        public int Qtd { get; set; }
        public String Nome { get; set; }
        public Decimal Valor { get; set; }
        public String Fidelidade { get; set; }
        public String Plano { get; set; }
    }
}
