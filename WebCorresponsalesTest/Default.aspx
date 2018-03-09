<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1 style="color:#0094ff">Corresponsales - Oficinas</h1>
    <form id="form1" runat="server">
        <div>

            <span style="font-weight:bold;color:#0026ff">Corresponsales:</span><br/><br/>
            <asp:DropDownList ID="ddlCorresponsales" runat="server" OnSelectedIndexChanged="ddlCorresponsales_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>

            <br />
            <br />
            <hr />
            
            <span style="font-weight:bold; color:#0026ff">Corresponsal selecionado:</span><br />
            <asp:Label ID="lblCorresponsal" runat="server"></asp:Label><br /><br />
            
            <span style="font-weight:bold; color:#0026ff"">Oficina de mayor longitud:</span><br />
            <asp:Label ID="lblOficinaLongMax" runat="server"></asp:Label>

            <hr />
            <p style="font-weight:bold">Carácteres de la oficina y veces que se repite:<asp:Table ID="tablaOficina" runat="server">
                </asp:Table>
            </p>


          <!--      <asp:Table runat="server" CellPadding="5"
            GridLines="vertical" HorizontalAlign="Center">
            <asp:TableRow>
            <asp:TableCell>Carácter</asp:TableCell>
            <asp:TableCell>Veces</asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
            <asp:TableCell>A</asp:TableCell>
            <asp:TableCell>3</asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
            <asp:TableCell>B</asp:TableCell>
            <asp:TableCell>8</asp:TableCell>
            </asp:TableRow>



            </asp:Table>-->





        </div>
    </form>
</body>
</html>
