<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDepositos.aspx.cs" Inherits="wsRegistroDepositos.WebFormDepositos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro Web de Depósitos</title>
    <script src="Scripts/jquery-2.0.2.min.js"></script>
</head>
<body>
    <form id="formDeposito" runat="server">
        <asp:ScriptManager runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div>
            <div class="encabezado">
                <h1>REGISTRO WEB DE DEPÓSITOS</h1>
            </div>
            <br />
            <hr />
            <div class="texto-centrado">
                <label for="seleccion-usuario">Seleccione un usuario:</label>
                <select id="seleccion-usuario"></select>
                <div>
                    Total:
                    <span id="total-usuario">0</span>
                    <br />
                    Meta:
                    <span id="meta-usuario">0</span>
                </div>
            </div>
            <hr />
            <div class="texto-centrado">
                <h2 class="verde">Nuevo Usuario</h2>
                <table align="center">
                    <tr>
                        <td><label for="nombre">Nombre:</label></td>
                        <td><input id="nombre" type="text" /></td>
                    </tr>
                    <tr>
                        <td><label for="meta">Meta:</label></td>
                        <td><input id="meta" type="number" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><input class="boton" type="button" onclick="AgregarUsuario()" value="Agregar" /></td>
                    </tr>
                </table>
                <br />
                
            </div>
            <br />
            <hr />
            <div class="texto-centrado">
                <h2 class="verde">Realizar Depósito</h2>
                 <table align="center">
                    <tr>
                        <td><label for="cantidad">Cantidad:</label></td>
                        <td><input id="cantidad" type="number" /></td>
                    </tr>
                     <tr>
                         <td colspan="2"><input class="boton" type="button" onclick="AgregarDeposito()" value="Confirmar" /></td>
                     </tr>
                </table>
            </div>
            
        </div>
    </form>
    <script type="text/javascript">
        var _usuarios;

        $(document).ready(function () {
            $('#seleccion-usuario').change(function () {
                ActualizarDatosUsuario();
            });

            CargarListaUsuarios();
        });

        function CargarListaUsuarios() {
            
            var usuarioSeleccionado = $('#seleccion-usuario');
            usuarioSeleccionado.empty();
            PageMethods.ListaUsuarios(function (usuarios) {
                _usuarios = usuarios;
                debugger;
                for (var i = 0; i < usuarios.length; i++) {
                    usuarioSeleccionado.append($('<option></option>')
                        .attr('value', usuarios[i].UsuarioId)
                        .text(usuarios[i].Nombre)
                    );
                }

                ActualizarDatosUsuario();
            });
        };

        function ActualizarDatosUsuario() {
            var indice = $("#seleccion-usuario")[0].selectedIndex;
            if (indice < 0)
                return;
            $('#meta-usuario').text(_usuarios[indice].Meta);
            $('#total-usuario').text(_usuarios[indice].Total);
        }

        function AgregarUsuario() {
            var nombre = $('#nombre').val();
            var meta = $('#meta').val();
        
            $.ajax({
                type: "POST",
                url: "WebFormDepositos.aspx/AgregarUsuario",
                data: JSON.stringify({ 'nombre': nombre, 'meta': meta }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    CargarListaUsuarios();
                    Alert('Usuario agregado correctamente.');
                }
            });

            $('#nombre').val('');;
            $('#meta').val('');
        }

        function AgregarDeposito() {
            var cantidad = $('#cantidad').val();
            var usuarioId = $('#seleccion-usuario').val();
            PageMethods.AgregarDeposito(cantidad, usuarioId, function (nuevoTotal) {
                for (var i = 0; i < _usuarios.length; i++) {
                    if (_usuarios[i].UsuarioId == usuarioId)
                        _usuarios[i].Total = nuevoTotal;
                }
                ActualizarDatosUsuario();
            });
            $('#cantidad').val('');
            Alert('Depósito agregado correctamente.');
        }
    </script>
    <style>

        body{
            background-color:#F2F2F2;
            color:#0D0D0D;
        }
        .encabezado{
            background:#52A646;
            color:#FFFFFF;
            padding:5px;
            text-align:center;
        }
        .texto-centrado{
            text-align:center;
            margin: 5px;
        }
        .verde{
            color:#52A646;
        }
        .boton{
            background: #52A646;
            border: none;
            padding: 5px;
            margin: 5px;
            color: white;
            width: 100%;
        }
    </style>
</body>
</html>
