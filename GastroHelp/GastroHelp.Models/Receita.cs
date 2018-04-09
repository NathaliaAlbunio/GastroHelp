using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GastroHelp.Models
{
    public class Receita
    {
        public int Id_Receita { get; set; }
        public string Nome_Receita { get; set; }
        public string Resumo { get; set; }
        public Categoria Categoria { get; set; }
        public Usuario Usuario { get; set; }
        public string Nivel_Dificuldade { get; set; }
        public string Ingredientes { get; set; }
        public string Modo_Preparo { get; set; }
        public string Rendimento { get; set; }
        public string Dica { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Publicada { get; set; }
        public string Foto { get; set; }

        public string Subtitulo
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Resumo) && this.Resumo.Length > 230)
                    return string.Format("{0}...", this.Resumo.Substring(0, 230));
                return this.Resumo;
            }
        }

        public string FotoUrl
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Foto))
                    return string.Format("~/Images/{0}", this.Foto);
                return string.Empty;
            }
        }
    }
}
