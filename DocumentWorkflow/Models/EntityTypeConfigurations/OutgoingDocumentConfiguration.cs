using DocumentWorkflow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentWorkflow.Models.EntityTypeConfigurations
{
    internal class OutgoingDocumentConfiguration : IEntityTypeConfiguration<OutgoingDocument>
    {
        public void Configure(EntityTypeBuilder<OutgoingDocument> builder)
        {
            builder.ToTable("outgoing_document");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.Number)
                .HasColumnName("number")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(e => e.StatusEnum)
                .HasColumnName("status")
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(e => e.Theme)
                .HasColumnName("theme")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(e => e.Addressee)
                .HasColumnName("addressee")
                .HasColumnType("nvarchar(255)")
                .IsRequired();            

            builder.Property(e => e.Signer)
                .HasColumnName("signer")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(e => e.IncomingDocumentId)
                .HasColumnName("incoming_document_id")
                .HasColumnType("int");
        }
    }
}