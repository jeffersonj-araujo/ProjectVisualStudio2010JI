using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.DataClass;

namespace ApliComBLL.Pessoa
{
    public abstract class Pessoa
    {
        //Conhecido como Atributos ou Propriedades.
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public int IdTipoPessoa { get; set; }
        public int IdPerfil { get; set; }
        public string CGC { get; set; }
        public string RazaoSocial { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string DataAniversario { get; set; }
        public bool Bloqueio { get; set; }
        public string BloqueioInformacao { get; set; }
        public string DataBloqueio { get; set; }
        public string DataInclusao { get; set; }
        public string DataAlteracao{ get; set; }
        //Conhecido como Metodo
        public abstract bool Gravar();
        public abstract bool Obter();
    }
    public class Cliente : Pessoa
    {
        //Conhecido como Atributos ou Propriedades.
        public double Limite { get; set; }

        public override bool Gravar()
        {
            string StrSql = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SPX_0000000001 ");
                sb.Append("'" + Convert.ToString(Id) + "',");
                sb.Append("'" + Convert.ToString(Codigo) + "',");
                sb.Append("'" + Nome + "',");
                sb.Append("'" + Fone + "',");
                sb.Append("'" + Fax + "',");
                sb.Append("'" + Celular + "',");
                sb.Append("'" + Email + "',");
                sb.Append("'" + Contato + "',");
                sb.Append("'" + Convert.ToString(IdTipoPessoa) + "',");
                sb.Append("'" + Convert.ToString(IdPerfil) + "',");
                sb.Append("'" + CGC + "',");
                sb.Append("'" + RazaoSocial + "',");
                sb.Append("'" + IE + "',");
                sb.Append("'" + IM + "',");
                sb.Append("'" + Convert.ToString(Limite) + "',");
                sb.Append("'" + DataAniversario + "',");
                sb.Append("'" + Convert.ToString(Bloqueio) + "',");
                sb.Append("'" + BloqueioInformacao + "',");
                sb.Append("'" + DataBloqueio + "'");
                StrSql = sb.ToString();

                return new DataClass("strcnx").Execute(StrSql);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override bool Obter()
        {
            throw new NotImplementedException();
        }
    }
    public class Fornecedor : Pessoa
    {
        //Conhecido como Atributos ou Propriedades.
        public int IdRamo { get; set; }

        public override bool Gravar()
        {
            throw new NotImplementedException();
        }

        public override bool Obter()
        {
            throw new NotImplementedException();
        }
    }
    public class Usuario : Pessoa
    {
        public override bool Gravar()
        {
            throw new NotImplementedException();
        }

        public override bool Obter()
        {
            throw new NotImplementedException();
        }
    }
}
