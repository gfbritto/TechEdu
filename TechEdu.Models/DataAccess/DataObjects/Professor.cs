using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Endereco { get; set; }
        public string Cpf { get; set; }
        public string Contato { get; set; }
    }
}
