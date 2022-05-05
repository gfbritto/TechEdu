using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class ColegioContext : DbContext
    {
        public ColegioContext()
        {
        }

        public ColegioContext(DbContextOptions<ColegioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<Colegio> Colegios { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<PapelPessoa> PapelPessoas { get; set; }
        public virtual DbSet<Permissao> Permissaos { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Responsavel> Responsavels { get; set; }
        public virtual DbSet<TipoPessoa> TipoPessoas { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=servidordetestes.bounceme.net;port=3306;uid=adm;pwd=techedu;database=colegio", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("alunos");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(17)
                    .HasColumnName("cpf");

                entity.Property(e => e.Enderecos)
                    .HasColumnType("int(11)")
                    .HasColumnName("enderecos");

                entity.Property(e => e.Nascimento)
                    .HasColumnType("date")
                    .HasColumnName("nascimento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Ra)
                    .HasMaxLength(15)
                    .HasColumnName("ra");

                entity.Property(e => e.Responsavel)
                    .HasColumnType("int(11)")
                    .HasColumnName("responsavel");

                entity.Property(e => e.Turma)
                    .HasColumnType("int(11)")
                    .HasColumnName("turma");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.ToTable("aulas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Duracao)
                    .HasColumnType("datetime")
                    .HasColumnName("duracao");

                entity.Property(e => e.Horario)
                    .HasColumnType("datetime")
                    .HasColumnName("horario");

                entity.Property(e => e.LocalAula)
                    .HasMaxLength(200)
                    .HasColumnName("local_aula");

                entity.Property(e => e.Materias)
                    .HasColumnType("int(11)")
                    .HasColumnName("materias");

                entity.Property(e => e.Professor)
                    .HasColumnType("int(11)")
                    .HasColumnName("professor");

                entity.Property(e => e.Turma)
                    .HasColumnType("int(11)")
                    .HasColumnName("turma");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.ToTable("colegios");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NomeColegio)
                    .HasMaxLength(50)
                    .HasColumnName("nome_colegio");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("enderecos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cep)
                    .HasMaxLength(16)
                    .HasColumnName("cep");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .HasColumnName("complemento");

                entity.Property(e => e.Numero)
                    .HasMaxLength(8)
                    .HasColumnName("numero");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("materias");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.ToTable("notas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Aluno)
                    .HasColumnType("int(11)")
                    .HasColumnName("aluno");

                entity.Property(e => e.Aula)
                    .HasColumnType("int(11)")
                    .HasColumnName("aula");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Nota1).HasColumnName("nota");

                entity.Property(e => e.PosicaoNota)
                    .HasColumnType("int(11)")
                    .HasColumnName("posicao_nota");

                entity.Property(e => e.Turmas)
                    .HasColumnType("int(11)")
                    .HasColumnName("turmas");
            });

            modelBuilder.Entity<PapelPessoa>(entity =>
            {
                entity.ToTable("papel_pessoa");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Aluno)
                    .HasColumnType("int(11)")
                    .HasColumnName("aluno");

                entity.Property(e => e.Professor)
                    .HasColumnType("int(11)")
                    .HasColumnName("professor");

                entity.Property(e => e.TipoPessoa)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo_pessoa");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.ToTable("permissao");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NomePermissao)
                    .HasMaxLength(50)
                    .HasColumnName("nome_permissao");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("professor");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contato)
                    .HasMaxLength(80)
                    .HasColumnName("contato");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(17)
                    .HasColumnName("cpf");

                entity.Property(e => e.Endereco)
                    .HasColumnType("int(11)")
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Responsavel>(entity =>
            {
                entity.ToTable("responsavel");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(45)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<TipoPessoa>(entity =>
            {
                entity.ToTable("tipo_pessoa");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turmas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Colegio)
                    .HasColumnType("int(11)")
                    .HasColumnName("colegio");

                entity.Property(e => e.NomeClasse)
                    .HasMaxLength(45)
                    .HasColumnName("nome_classe");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.PapelPessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("papel_pessoa_id");

                entity.Property(e => e.PermissaoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("permissao_id");

                entity.Property(e => e.SenhaHash)
                    .HasMaxLength(64)
                    .HasColumnName("senha_hash");

                entity.Property(e => e.UsuarioHash)
                    .HasMaxLength(64)
                    .HasColumnName("usuario_hash");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
