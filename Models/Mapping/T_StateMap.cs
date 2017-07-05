using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_StateMap : EntityTypeConfiguration<T_State>
    {
        public T_StateMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.StateName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_State");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.Createtime).HasColumnName("Createtime");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
