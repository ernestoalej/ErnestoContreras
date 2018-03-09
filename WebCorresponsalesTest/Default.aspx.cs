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
                ddlCorresponsales.Items.Add(corresponsal.nombre + " - "  +  corresponsal.nroOfi.ToString());
                ddlCorresponsales.Items[ddlCorresponsales.Items.Count - 1].Value = corresponsal.id.ToString();
            }

            lblCorresponsal.Text = ddlCorresponsales.SelectedValue.ToString();

            int idCorresponsal;
            idCorresponsal = Convert.ToInt32(ddlCorresponsales.SelectedValue.ToString());

            obtenerCorresponsalOficinaMaximaLongitud(idCorresponsal);
        }

    }

    protected void ddlCorresponsales_SelectedIndexChanged(object sender, EventArgs e)
    {     
        int idCorresponsal;
        idCorresponsal = Convert.ToInt32(ddlCorresponsales.SelectedValue.ToString());

        obtenerCorresponsalOficinaMaximaLongitud(idCorresponsal);

    }


    public void obtenerCorresponsalOficinaMaximaLongitud(int idCorresponsal )
    {

        WSCorresponsalesClient client = new WSCorresponsalesClient();

        Corresponsal corr = client.obtenerCorresponsalOficinaMaxLong(idCorresponsal);

        lblCorresponsal.Text = corr.nombre;

        lblOficinaLongMax.Text = corr.ofiNombre;
    }
}   