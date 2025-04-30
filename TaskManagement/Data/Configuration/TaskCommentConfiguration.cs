using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Data.Configuration
{
    public class TaskCommentConfiguration : IEntityTypeConfiguration<TaskComment>
    {
        public void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            builder.Property(s => s.Details)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasOne(x => x.Task)
                .WithMany(x => x.TaskComments)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
