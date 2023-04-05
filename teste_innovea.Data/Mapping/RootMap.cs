using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teste_innovea.Data.Entity;

namespace teste_innovea.Data.Mapping
{

    public class RootMap : IEntityTypeConfiguration<Root> 
    {
	    public void Configure(EntityTypeBuilder<Root> builder)
	    {
		    builder.ToTable("Root", "db_a43bc6_esapp");
            builder.HasKey("Id");

        }
    }

}