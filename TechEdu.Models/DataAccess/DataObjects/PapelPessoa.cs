using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class PapelPessoa
    {
        public PapelPessoa()
        {
            PermissaoPessoas = new HashSet<PermissaoPessoa>();
        }

        public int Id { get; set; }
        public int TipoPessoaId { get; set; }
        public int ProfessorId { get; set; }
        public int AlunoId { get; set; }

        public virtual Aluno Aluno { get; set; } = null!;
        public virtual Professor Professor { get; set; } = null!;
        public virtual TipoPessoa TipoPessoa { get; set; } = null!;
        public virtual ICollection<PermissaoPessoa> PermissaoPessoas { get; set; }
    }
}
