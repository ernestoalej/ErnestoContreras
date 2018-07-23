using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CorresponsalesService;
/***
    Autor: Ernesto Contreras, 2018.
    Test de conocimiento asp.net y SQL Server, Hispano Soluciones

    Deault.aspx consume el servicio "CorresponsalesServe"
****/
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try {

            if (!IsPostBack)
            {

                cargarCorresponsales();

                //obtener id corresponsal seleccionado

                int idCorresponsal = Convert.ToInt32(ddlCorresponsales.SelectedValue.ToString());

                //Mostrar tabla de caracteres
                string nombreOficinaTabla = obtenerCorresponsalOficinaMaximaLongitud(idCorresponsal);
                mostrarLetrasVeces(nombreOficinaTabla);


            }
        } catch (Exception ex)
        {
            lblInfo.Text = lblInfo.Text + " . " + "<p>Ha ocurrido un error al cargar los corresponsales: (" + ex.Source + "): " + ex.Message + "</p>";
        }
    }


    public void cargarCorresponsales()
    {
        try
        {

            // Cosume el servicio y obtiene los corresponsales
            WSCorresponsalesClient client = new WSCorresponsalesClient();

            Corresponsal[] corr = client.obtenerCorresponsales();


            foreach (Corresponsal corresponsal in corr)
            {
                ddlCorresponsales.Items.Add(corresponsal.nombre + " - " + corresponsal.nroOfi.ToString());
                ddlCorresponsales.Items[ddlCorresponsales.Items.Count - 1].Value = corresponsal.id.ToString();
            }

            //mostrar corresponsal seleccionado
            lblCorresponsal.Text = ddlCorresponsales.SelectedValue.ToString();
        } catch
        {
            lblInfo.Text = "No se han podido cargar los corresponsales, verifique si hay corresponsales registrados o si el servicio se está ejecutando";
        }

    }

    protected void ddlCorresponsales_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idCorresponsal;
        idCorresponsal = Convert.ToInt32(ddlCorresponsales.SelectedValue.ToString());

        string nombreOficina = obtenerCorresponsalOficinaMaximaLongitud(idCorresponsal);

        mostrarLetrasVeces(nombreOficina);

    }


    public void mostrarLetrasVeces(string nombreOficinaTabla)
    {
        /*Contiene la lógica revisar y contrar las letras y las veces que se repite*/


        // colocar en minuscula. (Para evitar que compare una  S y s como diferentes.
        nombreOficinaTabla = nombreOficinaTabla.ToLower();

        // Elimino los caracteres repetidos usando linq Distinct().
        string nombreOficinaTablaDistinct = new string(nombreOficinaTabla.Trim().ToCharArray().Distinct().ToArray());

        // eliminar los espacios y colocar en minuscula.
        nombreOficinaTablaDistinct = nombreOficinaTablaDistinct.Trim().Replace(" ", "").ToLower();

        tablaOficina.Rows.Clear();
        tablaOficina.Caption = "";

        // obtener la longitud de la cadena sin caractres repetidos
        int l = nombreOficinaTablaDistinct.Length;

        //Crear array de TablaCaracteres para guardar las letras y las veces que aparece repetida.
        TablaCaracteres[] tablaCaracteres = new TablaCaracteres[l];
        int countCaract = 0;

        for (int i = 0; i < l; i++)
        {
            string letra = nombreOficinaTablaDistinct.Substring(i, 1);

            //contar veces que aparece la letra en el string
            long veces = nombreOficinaTabla.LongCount(sletra => sletra.ToString() == letra);

            tablaCaracteres[countCaract] = new TablaCaracteres();

            tablaCaracteres[countCaract].letra = letra;
            tablaCaracteres[countCaract].veces = veces.ToString();

            //tablaOficina.Caption = tablaOficina.Caption + ", " + tablaCaracteres[countCaract].letra + "=" + tablaCaracteres[countCaract].veces.ToString();

            countCaract++;

        }

        tabla(tablaCaracteres);
    }



    public class TablaCaracteres {
        public string letra { get; set; }
        public string veces { get; set; }
    }

    public void tabla(TablaCaracteres[] tablaCaracteres)
    {
        /* creo una tabla progranáticamente con el control table*/

        TableRow row;   // Fila
        TableCell cel;  // Columna

        //Crear header de la columna 'Letra'
        TableHeaderRow tableHeaderRow = new TableHeaderRow();
        TableHeaderCell tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Letra";
        tableHeaderCell.Scope = TableHeaderScope.Column;
        tableHeaderRow.Cells.Add(tableHeaderCell);

        //Crear header de la columna 'Veces'            
        tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Veces";
        tableHeaderCell.Scope = TableHeaderScope.Column;
        tableHeaderRow.Cells.Add(tableHeaderCell);

        tablaOficina.Rows.Add(tableHeaderRow);

        // Agregar fila que contiene el header de las dos columnas "letra|veces"
        tablaOficina.Rows.Add(tableHeaderRow);

        for (int filas = 0; filas < tablaCaracteres.Length; filas++)
        {
            row = new TableRow();

            // Columna de Nombre  de la letra      
            cel = new TableCell();
            cel.Text = tablaCaracteres[filas].letra;
            row.Cells.Add(cel);

            // Columna de valor de la letra    
            cel = new TableCell();
            cel.Text = tablaCaracteres[filas].veces;
            row.Cells.Add(cel);

            tablaOficina.Rows.Add(row);
        }
    }


    public string obtenerCorresponsalOficinaMaximaLongitud(int idCorresponsal)
    {
        // Devuelve el nombre y la oficina con mayor número de caracteres

        WSCorresponsalesClient client = new WSCorresponsalesClient();
        Corresponsal corr = client.obtenerCorresponsalOficinaMaxLong(idCorresponsal);

        lblCorresponsal.Text = corr.nombre;

        lblOficinaLongMax.Text = corr.ofiNombre;

        return corr.ofiNombre;
    }


 }
 