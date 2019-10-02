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
    }
}
