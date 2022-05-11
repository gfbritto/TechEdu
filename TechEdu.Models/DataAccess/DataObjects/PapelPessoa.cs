using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class PapelPessoa
    {
        public PapelPessoa()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
