using System;
using System.Collections.Generic;

#nullable disable

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

        public virtual Aluno Aluno { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual TipoPessoa TipoPessoa { get; set; }
        public virtual ICollection<PermissaoPessoa> PermissaoPessoas { get; set; }
    }
}
