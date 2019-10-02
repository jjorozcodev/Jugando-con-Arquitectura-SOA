using clientPlayingSOA.ServiceReferenceDepositos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientPlayingSOA
{
    public partial class wfRegistroDepositos : Form
    {
        private wsRegistroDepositosSoapClient servicio = new wsRegistroDepositosSoapClient();
        private Usuario[] usuarios;
        public wfRegistroDepositos()
        {
            InitializeComponent();
        }

        private void Onload(object sender, EventArgs e)
        {
            usuarios = servicio.ListaUsuarios();
            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.DisplayMember = "Nombre";
            cmbUsuarios.ValueMember = "UsuarioId";
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if(txtNombreUsuario.Text.Trim() != "" && txtMetaUsuario.Text.Trim() != "")
            {
                servicio.AgregarUsuario(txtNombreUsuario.Text, int.Parse(txtMetaUsuario.Text));
                usuarios = servicio.ListaUsuarios();
                cmbUsuarios.DataSource = usuarios;

                txtNombreUsuario.Text = "";
                txtMetaUsuario.Text = "";
            }
        }

        private void CambiarSeleccionUsuario(object sender, EventArgs e)
        {
            int indice = cmbUsuarios.SelectedIndex;
            lblTotal.Text = usuarios[indice].Total.ToString();
            lblMeta.Text = usuarios[indice].Meta.ToString(); 
        }

        private void Depositar(object sender, EventArgs e)
        {
            int usuarioId = usuarios[cmbUsuarios.SelectedIndex].UsuarioId;
            int nuevoTotal = servicio.AgregarDeposito(int.Parse(txtCantidad.Text), usuarioId);
            usuarios[cmbUsuarios.SelectedIndex].Total = nuevoTotal;
            lblTotal.Text = nuevoTotal.ToString();
            txtCantidad.Text = "";
        }
    }
}
