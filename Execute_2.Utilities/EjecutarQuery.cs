using Execute_2.EE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execute_2.Utilities
{
    public static class EjecutarQuery
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MapeoDB"].ConnectionString;

        public static void ExecuteNonQuery(string query, Dictionary<string,object> diccionario)
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                PasarParametros(diccionario, sqlCommand);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private static void PasarParametros(Dictionary<string, object> diccionario, SqlCommand sqlCommand)
        {
            if (diccionario != null)
            {
                foreach (var param in diccionario)
                {
                    var parametros = sqlCommand.CreateParameter();
                    parametros.ParameterName = param.Key;
                    parametros.Value = param.Value;
                    sqlCommand.Parameters.Add(parametros);
                }
            }
        }

        public static IEnumerable<T> ExecuteSelectStatement<T>(string query, Dictionary<string,object> diccionario = null) where T : class,new()
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                PasarParametros(diccionario, sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                return dataSet.Tables[0].Rows.Cast<DataRow>().Select(m => (T)MapearGenero(m)).ToList();
                
            }
        }


        private static object MapearGenero(DataRow dataRow)
        {
            return new Genero
            {
                Id = (int)dataRow["id"],
                Nombre = (string)dataRow["nombre"],
                Fecha_reg = (DateTime)dataRow["fecha_reg"]
            };
        }

        private static SqlConnection CrearConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
