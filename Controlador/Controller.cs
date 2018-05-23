using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class Controller
    {
       
        SqlConnection con;

        public Controller()
        {
            con = new SqlConnection
            (ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString);
        }

        public bool Insert(Cadastro monitorar)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_INSERIR_DADOS";
            cmd.Parameters.Add(new SqlParameter("@Descricao", monitorar.Descricao));
            cmd.Parameters.Add(new SqlParameter("@Quantidade_Cameras", monitorar.Qtd));
            cmd.Parameters.Add(new SqlParameter("@Nome_Cliente", monitorar.Nome));
            cmd.Parameters.Add(new SqlParameter("@Valor_Pacote", monitorar.Valor));
            cmd.Parameters.Add(new SqlParameter("@Fidelidade", monitorar.Fidelidade));
            cmd.Parameters.Add(new SqlParameter("@Plano", monitorar.Plano));




            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            return true;

        }

        public DataTable Select()
        {

            DataTable dt = new DataTable();
            SqlCommand scomand = new SqlCommand();
            SqlDataAdapter ad = new SqlDataAdapter();
            con.Open();

            scomand = new SqlCommand("PR_CONSULTAR_DADOS", con);
            scomand.CommandType = CommandType.StoredProcedure;

            ad.SelectCommand = scomand;
            ad.Fill(dt);
            con.Close();
            return dt;

        }
    }
}
