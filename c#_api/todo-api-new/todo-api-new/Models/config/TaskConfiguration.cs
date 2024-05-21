using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace todo_api_new.Models.config
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("tasks").HasKey(k => k.id);
            builder.Property(p => p.id).IsRequired();
            builder.Property(p => p.title).IsRequired();
            builder.Property(p => p.description).IsRequired();
            builder.Property(p => p.date).IsRequired();
            builder.Property(p => p.priority).HasConversion<string>().IsRequired();
            builder.Property(p => p.status).HasConversion<string>().IsRequired();
        }
    }
}
