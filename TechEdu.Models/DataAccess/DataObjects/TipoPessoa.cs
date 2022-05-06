using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class TipoPessoa
    {
        public TipoPessoa()
        {
            PapelPessoas = new HashSet<PapelPessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<PapelPessoa> PapelPessoas { get; set; }
    }
}
