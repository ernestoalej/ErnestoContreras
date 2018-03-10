<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Corresponsales Test - Hispano Soluciones</title>


    <style>

          html,body { 
            margin:0px;
            padding:0px
        }


        #cuerpo{
            margin-left: 30px;
        }


        #tablaOficina th{
            background-color:#303f9f;
            color: #ebf3f2;
        }

        #tablaOficina tr {

            background-color:#ddfce1;
        }

        #tablaOficina{
            border-collapse:collapse;
        }
        #tablaOficina td{
            width: 100px;
        }

        #tablaOficina, th, tr, td{
           border: 1px solid #808080;            
        }

      

        footer {
            background:#3e3d3d;
            color:#ebf3f2;
            text-align:center;
            padding:10px;
            font-family:Verdana;
            font-size:small;
            padding:1px;                
        }   

        footer a, a:active {
            color:white;
        }

     
        footer {
            margin:0px;
            padding-left:0px;
        }
    </style>

</head>
<body>    
    <form id="form1" runat="server">
        <div id="cuerpo">
            <h1 style="color:#3f51b5">Corresponsales - Oficinas</h1>

            <span style="font-weight:bold;color:#0026ff">Corresponsales:</span><br/><br/>
            <asp:DropDownList ID="ddlCorresponsales" runat="server" OnSelectedIndexChanged="ddlCorresponsales_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>

            <br />
            <asp:Label ID="lblInfo" runat="server" ForeColor="#993366"></asp:Label>
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


        </div>
    </form>
    <br/>
    <br/>
    <br/>
    <footer>
        <p>Desarrollado por Ernesto Contreras</p>
        <a href="mailto:ernestocontreras28@gmail.com">ernestocontreras28@gmail.com</a>
        <p>Test asp.net y SQL Server</p>
        <p>Hispano Soluciones, C.A</p>
    </footer>
</body>
</html>
