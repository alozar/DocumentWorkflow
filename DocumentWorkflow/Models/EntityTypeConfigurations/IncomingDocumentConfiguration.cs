using DocumentWorkflow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DocumentWorkflow.Models.EntityTypeConfigurations
{
    internal class IncomingDocumentConfiguration : IEntityTypeConfiguration<IncomingDocument>
    {
        public void Configure(EntityTypeBuilder<IncomingDocument> builder)
        {
            builder.ToTable("incoming_document");

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

            builder.Property(e => e.Applicant)
                .HasColumnName("applicant")
                .HasColumnType("nvarchar(255)")
                .IsRequired();
        }
    }
}