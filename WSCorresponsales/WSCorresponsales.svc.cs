using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WSCorresponsales
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSCorresponsalesImpl : IWSCorresponsales
    {
        string cnnString = "";

        public WSCorresponsalesImpl()
        {
            cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["cnn"].ToString();
        }

        public Corresponsal obtenerCorresponsales()
        {
            string sql = "SELECT COR_CORRESPONSAL_ID, COR_NOMBRE FROM CORRESPONSALES;";

            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Corresponsal corr = new Corresponsal() {

                        id = Convert.ToInt32(dr["COR_CORRESPONSAL_ID"]),
                        nombre = dr["COR_NOMBRE"].ToString()

                    };

                    return corr;
                }
            }

            return null;
        }
    }
}
