using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class PermissaoPessoa
    {
        public int Id { get; set; }
        public int PermissaoId { get; set; }
        public int PapelPessoaId { get; set; }

        public virtual PapelPessoa PapelPessoa { get; set; }
        public virtual Permissao Permissao { get; set; }
    }
}
