using Microsoft.EntityFrameworkCore;
using System;

namespace Employee_Hub.Models
{
    public partial class KnowledgeHubDataBaseContext : DbContext
    {
        public KnowledgeHubDataBaseContext()
        {
        }

        public KnowledgeHubDataBaseContext(DbContextOptions<KnowledgeHubDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Comment> Comment { get; set; }

        public virtual DbSet<Reply> Reply { get; set; }

        public virtual DbSet<SubCategory> SubCategory { get; set; }

        public virtual DbSet<Tag> Tag { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<UserArticle> UserArticle { get; set; }

        public virtual DbSet<UserTag> UserTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:knowledge-hub.database.windows.net,1433;Initial Catalog=KnowledgeHub-DB;Persist Security Info=False;User ID=geethus;Password=KnowledgeHub123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasIndex(e => e.Url)
                    .HasName("AK_Article_Url")
                    .IsUnique();

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.PublishedAt).HasColumnType("datetime");

                entity.Property(e => e.Snippet)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_To_Article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_To_User");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_To_Comment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_User");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategory_To_Category");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Tag)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tags_To_SubCategory");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserArticle>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.UserArticle)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserArticle_Article");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.UserArticle)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tag_UserArticle");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserArticle)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserArticle_To_User");
            });

            modelBuilder.Entity<UserTag>(entity =>
            {
               

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTag)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTags_To_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
