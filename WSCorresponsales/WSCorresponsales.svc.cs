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

        public List<Corresponsal> obtenerCorresponsales()
        {
            string sql = "SELECT COR_CORRESPONSAL_ID, COR_NOMBRE, COUNT(O.OFI_CORRESPONSAL_ID) AS COR_NRO_OFI " +
                           "FROM CORRESPONSALES AS C " +
                         "INNER JOIN OFICINAS AS O " +
                             "ON O.OFI_CORRESPONSAL_ID = C.COR_CORRESPONSAL_ID " +
                        "GROUP BY COR_CORRESPONSAL_ID, COR_NOMBRE ORDER BY COR_NOMBRE;";
     

            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataReader dr = cmd.ExecuteReader();

                List<Corresponsal> Lista = new List<Corresponsal>();

                while (dr.Read())
                {
                    Corresponsal corr = new Corresponsal() {

                        id = Convert.ToInt32(dr["COR_CORRESPONSAL_ID"]),
                        nombre = dr["COR_NOMBRE"].ToString(),
                        // ofiNombre = dr["OFI_NOMBRE"].ToString()

                        nroOfi = Convert.ToInt32(dr["COR_NRO_OFI"])
                    };

                    
                    Lista.Add(corr);
                                
                }

                return Lista;
            }
            
        }


        public Corresponsal obtenerCorresponsalOficinaMaxLong(int corresponsalID)
        {

            try
            {
                string sql = "SELECT TOP 1 " +
                                "C.COR_CORRESPONSAL_ID, C.COR_NOMBRE, O.OFI_NOMBRE " +
                                "FROM Corresponsales AS C " +
                                "INNER JOIN OFICINAS AS O " +
                                       "ON C.COR_CORRESPONSAL_ID = O.OFI_CORRESPONSAL_ID " +
                                "WHERE LEN(OFI_NOMBRE) = (SELECT MAX(LEN(OFI_NOMBRE)) FROM OFICINAS WHERE OFICINAS.OFI_CORRESPONSAL_ID = O.OFI_CORRESPONSAL_ID )" +
                                "AND C.COR_CORRESPONSAL_ID = " + corresponsalID.ToString();

                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();
                    ///////////////////////////////////////////////////////////
                    Corresponsal corr = new Corresponsal()
                    {
                        id = Convert.ToInt32(dr["COR_CORRESPONSAL_ID"]),
                        nombre = dr["COR_NOMBRE"].ToString(),
                        ofiNombre = dr["OFI_NOMBRE"].ToString()

                    };

                    return corr;
                }

            } catch 
            {
                return null;
            }
        }
    }
}
