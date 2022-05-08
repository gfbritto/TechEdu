using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Aula> Aulas { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<Notum> Nota { get; set; } = null!;
        public virtual DbSet<PapelPessoa> PapelPessoas { get; set; } = null!;
        public virtual DbSet<Permissao> Permissaos { get; set; } = null!;
        public virtual DbSet<PermissaoPessoa> PermissaoPessoas { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Responsavel> Responsavels { get; set; } = null!;
        public virtual DbSet<TipoNotum> TipoNota { get; set; } = null!;
        public virtual DbSet<TipoPessoa> TipoPessoas { get; set; } = null!;
        public virtual DbSet<Turma> Turmas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=servidordetestes.bounceme.net;uid=adm;pwd=techedu;database=colegio", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("aluno");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PessoaId, "FK_ALUNO_PESSOA_idx");

                entity.HasIndex(e => e.ResponsavelId, "FK_ALUNO_RESPONSAVEL_idx");

                entity.HasIndex(e => e.TurmaId, "FK_ALUNO_TURMA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pessoaId");

                entity.Property(e => e.Ra)
                    .HasMaxLength(15)
                    .HasColumnName("ra")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.ResponsavelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("responsavelId");

                entity.Property(e => e.TurmaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turmaId");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALUNO_PESSOA");

                entity.HasOne(d => d.Responsavel)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.ResponsavelId)
                    .HasConstraintName("FK_ALUNO_RESPONSAVEL");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.TurmaId)
                    .HasConstraintName("FK_ALUNO_TURMA");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.ToTable("aula");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.MateriaId, "FK_AULA_MATERIA_idx");

                entity.HasIndex(e => e.ProfessorId, "FK_AULA_PROFESSOR_idx");

                entity.HasIndex(e => e.TurmaId, "FK_AULA_TURMA_idx");

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
                    .HasColumnName("local_aula")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.MateriaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("materiaId");

                entity.Property(e => e.ProfessorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("professorId");

                entity.Property(e => e.TurmaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turmaId");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.MateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AULA_MATERIA");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AULA_PROFESSOR");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.TurmaId)
                    .HasConstraintName("FK_AULA_TURMA");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.ToTable("colegio");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NomeColegio)
                    .HasMaxLength(50)
                    .HasColumnName("nomeColegio")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PessoaId, "FK_ENDERECO_PESSOA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cep)
                    .HasMaxLength(16)
                    .HasColumnName("cep")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .HasColumnName("complemento")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(85)
                    .HasColumnName("logradouro")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Numero)
                    .HasMaxLength(8)
                    .HasColumnName("numero")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.PessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pessoaId");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENDERECO_PESSOA");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.ToTable("materia");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.ToTable("nota");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.AulaId, "FK_AULA_idx");

                entity.HasIndex(e => e.AlunoId, "FK_NOTAS_ALUNO_idx");

                entity.HasIndex(e => e.TurmaId, "FK_TURMA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AlunoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("alunoId");

                entity.Property(e => e.AulaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("aulaId");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.PosicaoNota)
                    .HasColumnType("int(11)")
                    .HasColumnName("posicao_nota");

                entity.Property(e => e.TurmaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turmaId");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTA_ALUNO");

                entity.HasOne(d => d.Aula)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.AulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTA_AULA");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.TurmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTA_TURMA");
            });

            modelBuilder.Entity<PapelPessoa>(entity =>
            {
                entity.ToTable("papel_pessoa");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.AlunoId, "FK_ALUNO_idx");

                entity.HasIndex(e => e.ProfessorId, "FK_PROFESSOR_idx");

                entity.HasIndex(e => e.TipoPessoaId, "FK_TIPO_PESSOA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AlunoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("alunoId");

                entity.Property(e => e.ProfessorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("professorId");

                entity.Property(e => e.TipoPessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipoPessoaId");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.PapelPessoas)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAPELPESSOA_ALUNO");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.PapelPessoas)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAPELPESSOA_PROFESSOR");

                entity.HasOne(d => d.TipoPessoa)
                    .WithMany(p => p.PapelPessoas)
                    .HasForeignKey(d => d.TipoPessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAPELPESSOA_TIPOPESSOA");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.ToTable("permissao");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NomePermissao)
                    .HasMaxLength(50)
                    .HasColumnName("nomePermissao")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<PermissaoPessoa>(entity =>
            {
                entity.ToTable("permissao_pessoa");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PapelPessoaId, "FK_PAPEL_PESSOA_idx");

                entity.HasIndex(e => e.PermissaoId, "FK_PERMISSAO_PESSOA");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PapelPessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("papelPessoaId");

                entity.Property(e => e.PermissaoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("permissaoId");

                entity.HasOne(d => d.PapelPessoa)
                    .WithMany(p => p.PermissaoPessoas)
                    .HasForeignKey(d => d.PapelPessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSAO_PAPELPESSOA");

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.PermissaoPessoas)
                    .HasForeignKey(d => d.PermissaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSAO_PESSOA");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.PrimeiroNome)
                    .HasMaxLength(60)
                    .HasColumnName("primeiroNome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.UltimoNome)
                    .HasMaxLength(60)
                    .HasColumnName("ultimoNome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("professor");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contato)
                    .HasMaxLength(80)
                    .HasColumnName("contato")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(17)
                    .HasColumnName("cpf")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Endereco)
                    .HasColumnType("int(11)")
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Responsavel>(entity =>
            {
                entity.ToTable("responsavel");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(45)
                    .HasColumnName("telefone")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<TipoNotum>(entity =>
            {
                entity.ToTable("tipo_nota");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.QuantidadeNota)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidade_nota");
            });

            modelBuilder.Entity<TipoPessoa>(entity =>
            {
                entity.ToTable("tipo_pessoa");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turma");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ColegioId, "FK_COLEGIO_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ColegioId)
                    .HasColumnType("int(11)")
                    .HasColumnName("colegioId");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.HasOne(d => d.Colegio)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.ColegioId)
                    .HasConstraintName("FK_TURMA_COLEGIO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PermissaoId, "FK_PERMISSAOID_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.PapelPessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("papelPessoaId");

                entity.Property(e => e.PermissaoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("permissaoId");

                entity.Property(e => e.SenhaHash)
                    .HasMaxLength(64)
                    .HasColumnName("senhaHash")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.UsuarioHash)
                    .HasMaxLength(64)
                    .HasColumnName("usuarioHash")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PermissaoId)
                    .HasConstraintName("FK_USUARIO_PERMISSAO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
