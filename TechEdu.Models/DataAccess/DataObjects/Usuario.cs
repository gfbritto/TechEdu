using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public int? PapelPessoaId { get; set; }
        public string UsuarioHash { get; set; }
        public string SenhaHash { get; set; }
        public string Nome { get; set; }
        public int? PermissaoId { get; set; }
    }
}
