using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teste_innovea.Data.Entity;

namespace teste_innovea.Data.Mapping
{

    public class ArticleMap : IEntityTypeConfiguration<Article> 
    {
	    public void Configure(EntityTypeBuilder<Article> builder)
	    {
		    builder.ToTable("Article", "db_a43bc6_esapp");
            builder.HasKey("id");

        }
    }

}