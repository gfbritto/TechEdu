using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Aluno
    {
        public Aluno()
        {
            Nota = new HashSet<Notum>();
            PapelPessoas = new HashSet<PapelPessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? TurmaId { get; set; }
        public string Ra { get; set; }
        public int? EnderecoId { get; set; }
        public string Cpf { get; set; }
        public DateTime? Nascimento { get; set; }
        public int? ResponsavelId { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Responsavel Responsavel { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
        public virtual ICollection<PapelPessoa> PapelPessoas { get; set; }
    }
}
