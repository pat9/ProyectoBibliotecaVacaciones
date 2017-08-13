using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConexionDAO
    {
        string CadenaConexion = "";
        SqlConnection Conexion;
        SqlCommand Comando;
        SqlDataAdapter Adap;
        public ConexionDAO()
        {
            Comando = new SqlCommand();
            Adap = new SqlDataAdapter();
        }

        public SqlConnection Conectar()
        {
            return Conexion = new SqlConnection(CadenaConexion);
        }
        
        public void Abrir()
        {
            Conexion.Open();
        }

        public void Cerrar()
        {
            Conexion.Close();
        }

        public int EjecutarComando(SqlCommand comando)
        {
            Comando = comando;
            Comando.Connection = Conectar();
            Abrir();
            int id = 0; int.TryParse(Comando.ExecuteScalar().ToString(), out id);
            Cerrar();
            return id;
        }

        public DataSet EjecutarSentencia(SqlCommand comando)
        {
            DataSet DS = new DataSet();
            Comando = comando;
            Comando.Connection = Conectar();
            Adap.SelectCommand = Comando;
            Abrir();
            Adap.Fill(DS);
            Cerrar();
            return DS;
        }

        public DataSet EjecuatarSentencia(string comando)
        {
            DataSet DS = new DataSet();
            Comando.CommandText = comando;
            Comando.Connection = Conectar();
            Adap.SelectCommand = Comando;
            Abrir();
            Adap.Fill(DS);
            Cerrar();
            return DS;
        }

    }
}
