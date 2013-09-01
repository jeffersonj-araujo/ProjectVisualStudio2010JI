using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApliComBLL.Pessoa;

namespace ApliCom
{
    public partial class teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

 
           
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Id = 0;
            cliente.Nome = txtNome.Text.Trim();
            cliente.Codigo = Convert.ToInt32(txtCodigo.Text.Trim());
            cliente.Fone = txtFone.Text.Trim();
            cliente.Fax = txtFax.Text.Trim();
            cliente.Celular = txtCelular.Text.Trim();
            cliente.Email = txtEmail.Text.Trim();
            cliente.Contato = txtContato.Text.Trim();
            cliente.IdTipoPessoa = Convert.ToInt32(txtIdTipoPessoa.Text.Trim());
            cliente.IdPerfil = Convert.ToInt32(txtIdPerfil.Text.Trim());
            cliente.CGC = txtCGC.Text.Trim();
            cliente.RazaoSocial = txtRazaoSocial.Text.Trim();
            cliente.IE = txtIE.Text.Trim();
            cliente.IM = txtIM.Text.Trim();
            cliente.Limite = Convert.ToDouble(txtLimite.Text.Trim());
            cliente.DataAniversario = txtDataAniversario.Text.Trim();
            cliente.Bloqueio = Convert.ToBoolean(txtBloqueio.Text.Trim());
            cliente.BloqueioInformacao = txtBloqueioInformacao.Text.Trim();
            cliente.DataBloqueio = txtDataBloqueio.Text.Trim();
            cliente.Gravar();
        }
    }
}