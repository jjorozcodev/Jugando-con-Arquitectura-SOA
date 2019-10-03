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
            if(cmbUsuarios.Items.Count > 0)
                cmbUsuarios.SelectedIndex = 0;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if(txtNombreUsuario.Text.Trim() != "" && nudMetaUsuario.Value > 0)
            {
                servicio.AgregarUsuario(txtNombreUsuario.Text, Convert.ToInt32(nudMetaUsuario.Value));
                usuarios = servicio.ListaUsuarios();
                cmbUsuarios.DataSource = usuarios;
                
                MessageBox.Show("Usuario agregado con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos de usuario.");
            }

            txtNombreUsuario.Text = "";
            nudMetaUsuario.Value = 0;
        }

        private void CambiarSeleccionUsuario(object sender, EventArgs e)
        {
            int indice = cmbUsuarios.SelectedIndex;
            lblTotal.Text = usuarios[indice].Total.ToString();
            lblMeta.Text = usuarios[indice].Meta.ToString(); 
        }

        private void Depositar(object sender, EventArgs e)
        {
            
            if(nudCantidad.Value > 0)
            {
                int usuarioId = usuarios[cmbUsuarios.SelectedIndex].UsuarioId;
                int nuevoTotal = servicio.AgregarDeposito(Convert.ToInt32(nudCantidad.Value), usuarioId);
                usuarios[cmbUsuarios.SelectedIndex].Total = nuevoTotal;
                lblTotal.Text = nuevoTotal.ToString();
                nudCantidad.Value = 0;

                MessageBox.Show("Depósito realizado con éxito.");
            }
            else
            {
                MessageBox.Show("Cantidad debe ser mayor a 0.");
            }
        }
    }
}
