using _211086.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211086.Views
{
    public partial class FrmCidade : Form
    {
        public FrmCidade()
        {
            InitializeComponent();
        }

        private void FrmCidade_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return ;

            c = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }
    }
}
