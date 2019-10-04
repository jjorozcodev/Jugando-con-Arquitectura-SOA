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
            <h1>Registro Web de Depósitos</h1>
            <br />
            <hr />
            <div>
                <label for="seleccion-usuario">Seleccione un usuario:</label>
                <select id="seleccion-usuario"></select>
            </div>
            <hr />
            <div>
                <h2>Nuevo Usuario</h2>
                <br />
                <label for="nombre">Nombre:</label>
                <input id="nombre" type="text" />
                <br />
                <label for="meta">Meta:</label>
                <input id="meta" type="number" />
                <br />
                <input id="btn-agregar-usuario" type="button" onclick="AgregarUsuario()" value="Agregar" />
            </div>
            <hr />
            <div>
                <h2>Realizar Depósito</h2>
                <br />
                <label for="cantidad">Cantidad:</label>
                <input id="cantidad" type="number" />
                <br />
                <input id="btn-agregr-deposito" type="button" onclick="AgregarDeposito()" value="Confirmar" />
            </div>
            <div>
                Total:
                <span id="total-usuario"></span>
                <br />
                Meta:
                <span id="meta-usuario"></span>
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
                        .add('value', usuarios[i].UsuarioId)
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
                success: CargarListaUsuarios
            });
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
        }
    </script>
</body>
</html>
