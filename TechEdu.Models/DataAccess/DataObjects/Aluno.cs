using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Aluno
    {
        public Aluno()
        {
            Enderecos = new HashSet<Endereco>();
            Nota = new HashSet<Notum>();
            PapelPessoas = new HashSet<PapelPessoa>();
        }

        public int Id { get; set; }
        public int? TurmaId { get; set; }
        public string? Ra { get; set; }
        public int? ResponsavelId { get; set; }
        public string PrimeiroNome { get; set; } = null!;
        public string? UltimoNome { get; set; }
        public DateOnly? DataNascimento { get; set; }

        public virtual Responsavel? Responsavel { get; set; }
        public virtual Turma? Turma { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
        public virtual ICollection<PapelPessoa> PapelPessoas { get; set; }
    }
}
