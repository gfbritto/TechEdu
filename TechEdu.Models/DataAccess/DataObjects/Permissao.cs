using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Permissao
    {
        public Permissao()
        {
            PermissaoPessoas = new HashSet<PermissaoPessoa>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? NomePermissao { get; set; }

        public virtual ICollection<PermissaoPessoa> PermissaoPessoas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
