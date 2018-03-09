using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CorresponsalesService;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WSCorresponsalesClient client = new WSCorresponsalesClient();

            Corresponsal[] corr = client.obtenerCorresponsales();

            foreach (Corresponsal corresponsal in corr)
            {
                ddlCorresponsales.Items.Add(corresponsal.nombre + " - " + corresponsal.nroOfi.ToString());
                ddlCorresponsales.Items[ddlCorresponsales.Items.Count - 1].Value = corresponsal.id.ToString();
            }

            lblCorresponsal.Text = ddlCorresponsales.SelectedValue.ToString();

            int idCorresponsal;
            idCorresponsal = Convert.ToInt32(ddlCorresponsales.SelectedValue.ToString());

            string nombreOficinaTabla = obtenerCorresponsalOficinaMaximaLongitud(idCorresponsal);

            nombreOficinaTabla = nombreOficinaTabla.Trim().Replace(" ", "");

            mostrarLetrasVeces(nombreOficinaTabla);
        }

    }

    protected void ddlCorresponsales_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idCorresponsal;
        idCorresponsal = Convert.ToInt32(ddlCorresponsales.SelectedValue.ToString());

        string nombreOficina = obtenerCorresponsalOficinaMaximaLongitud(idCorresponsal);

        //tablaOficina.Caption = nombreOficina;

        string nombreOficinaTabla = nombreOficina.Trim().Replace(" ", "");
      

      //  string letraContadas = "";


        //string[] colVeces2 = new string[6];

       // int contadorFila=0;

  

        mostrarLetrasVeces(nombreOficinaTabla);


    }


    public void mostrarLetrasVeces(string nombreOficinaTabla)
    {
        tablaOficina.Rows.Clear();
        tablaOficina.Caption = "";
        string letraContadas = "";

        int l = nombreOficinaTabla.Length;

        for (int i = 0; i < l; i++)
        {
            string letra = nombreOficinaTabla.Substring(i, 1);

           

            if (!letraContadas.Contains(letra))
            {

                //contar veces que aparece la letra en el string
                long veces = nombreOficinaTabla.LongCount(sletra => sletra.ToString() == letra);


                //tablaOficina.Caption = nombreOficina;

                tablaOficina.Caption = tablaOficina.Caption + ", " + letra + "=" + veces.ToString();

                //guardo las letras ya contadas para no repetirlas
                letraContadas = letraContadas + letra;
            }

        }

    }

    public void tabla(string[] colLetra, string[] colVeces)
    {
        /*   Comentado , falta */ 

       /* TableRow row;
        TableCell cel;

        for (int filas = 1; filas <= colLetra.Length; filas++)
        {
            row = new TableRow();

            for (int columna = 1; columna <= 2; columna++)
            {
                cel = new TableCell();

                cel.Text = colLetra[filas-1].ToString();

                row.Cells.Add(cel);
            }

            tablaOficina.Rows.Add(row);

        }*/

    }


    public string obtenerCorresponsalOficinaMaximaLongitud(int idCorresponsal )
    {

        WSCorresponsalesClient client = new WSCorresponsalesClient();

        Corresponsal corr = client.obtenerCorresponsalOficinaMaxLong(idCorresponsal);

        lblCorresponsal.Text = corr.nombre;

        lblOficinaLongMax.Text = corr.ofiNombre;

        return corr.ofiNombre;
    }
}   