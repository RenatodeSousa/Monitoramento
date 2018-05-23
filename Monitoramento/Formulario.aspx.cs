using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Monitoramento
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)

        {

            String Descricao = textDescricao.Text;
            int Qtd = Int32.Parse(TextQtd.Text);
            String Nome = TextNome.Text;
            Decimal Valor = Convert.ToDecimal(TextValor.Text);
            String Fidelidade = rblFidelidade.SelectedValue;
            String Plano_f = "";
            LBL.Text = "Dados inseridos com sucesso";

            InsertBanco(Descricao, Qtd, Nome, Valor, Fidelidade, Plano_f);
        }

        private void InsertBanco(String Descricao_f, int Qtd_f, String Nome_f, Decimal Valor_f, String Fidelidade_f,String Plano_f)
        {
        
            
            var retorno = Calcular(Valor_f, Qtd_f,  Fidelidade_f, Plano_f);


            Controller c = new Controller();
            Cadastro monit = new Cadastro();
            monit.Descricao = Descricao_f;
            monit.Qtd = Qtd_f;
            monit.Nome = Nome_f;
            monit.Valor = retorno.Item1;
            monit.Plano = retorno.Item2;
            monit.Fidelidade = Fidelidade_f;
            c.Insert(monit);
        }

        private Tuple<Decimal,String> Calcular(Decimal Valor_f, int Qtd_f,String Fidelidade_f,String Plano_f)
        {

            if (Fidelidade_f == "1")
            {

                if (Qtd_f == 1 || Qtd_f == 2)
                {

                    Valor_f = Valor_f - (Valor_f * 0.1m);
                    Plano_f = "Cliente Padrão";

                }
                else if (Qtd_f == 3 || Qtd_f == 4)
                {

                    Valor_f = Valor_f - (Valor_f * 0.2m);
                    Plano_f = "Cliente Intermediário";

                }
                else if (Qtd_f >= 5)
                {

                    Valor_f = Valor_f - (Valor_f * 0.3m);
                    Plano_f = "Cliente Avançado";

                }

                return Tuple.Create(Valor_f,Plano_f);

            }
            else
            {

                if (Qtd_f == 1 || Qtd_f == 2)
                {

                    Valor_f = Valor_f - (Valor_f * 0.05m);
                    Plano_f = "Cliente Padrão";

                }
                else if (Qtd_f == 3 || Qtd_f == 4)
                {

                    Valor_f = Valor_f - (Valor_f * 0.1m);
                    Plano_f = "Cliente Intermediário";

                }
                else if (Qtd_f >= 5)
                {

                    Valor_f = Valor_f - (Valor_f * 0.15m);
                    Plano_f = "Cliente Avançado";
                }

                return Tuple.Create(Valor_f, Plano_f);
            }
          
        }

        private void ListarDados()
        {
            GDV.DataSource = new Controller().Select();
            GDV.DataBind();
        }

        protected void BtnListar_Click(object sender, EventArgs e)
        {     
            ListarDados();
            LBL.Text = "Dados carregados com sucesso!";
        }

        protected void GDV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}