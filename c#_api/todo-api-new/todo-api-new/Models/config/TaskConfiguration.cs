using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace todo_api_new.Models.config
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
         //   builder.ToTable("Task");
            builder.HasKey(k => k.id);
            builder.Property(t => t.id).ValueGeneratedOnAdd();
            builder.Property(p => p.title).IsRequired().HasColumnType("text"); ;
            builder.Property(p => p.description).IsRequired().HasColumnType("longtext"); ;
            builder.Property(p => p.date).IsRequired().HasColumnType("date"); ;
            builder.Property(p => p.priority).HasConversion<string>().IsRequired();
            builder.Property(p => p.status).HasConversion<string>().IsRequired();
        }
    }
}
