using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Endereco
    {
        public Endereco()
        {
            Alunos = new HashSet<Aluno>();
        }

        public int Id { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Logradouro { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
