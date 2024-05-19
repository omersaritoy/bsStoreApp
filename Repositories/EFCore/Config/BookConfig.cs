
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitiess.Models;

namespace Repositories.EFCore.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book { Id = 6, Title = "Dede Korkut", Price = 86 },
            new Book { Id = 8, Title = "Jigjiga", Price = 89 },
            new Book { Id = 9, Title = "Simyacı", Price = 91 },
            new Book { Id = 7, Title = "Dönüşüm", Price = 96 }
            );
    }
}
