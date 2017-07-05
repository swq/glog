using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_ProgressMap : EntityTypeConfiguration<T_Progress>
    {
        public T_ProgressMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProgressName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Progress");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProgressName).HasColumnName("ProgressName");
            this.Property(t => t.Createtime).HasColumnName("Createtime");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
