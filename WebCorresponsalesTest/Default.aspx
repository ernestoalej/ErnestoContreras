<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Corresponsales - Oficinas</h1>
    <form id="form1" runat="server">
        <div>

            <span style="font-weight:bold">Corresponsales:</span><br/><br/>
            <asp:DropDownList ID="ddlCorresponsales" runat="server" OnSelectedIndexChanged="ddlCorresponsales_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>

            <br />
            <br />
            <hr />
            
            <span style="font-weight:bold">Corresponsal selecionado:</span><br />
            <asp:Label ID="lblCorresponsal" runat="server"></asp:Label><br /><br />
            
            <span style="font-weight:bold">Oficina de mayor longitud:</span><br />
            <asp:Label ID="lblOficinaLongMax" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
