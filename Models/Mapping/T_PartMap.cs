using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_PartMap : EntityTypeConfiguration<T_Part>
    {
        public T_PartMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.FName_EN)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("T_Part");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.FParentID).HasColumnName("FParentID");
            this.Property(t => t.FLevel).HasColumnName("FLevel");
            this.Property(t => t.FName).HasColumnName("FName");
            this.Property(t => t.FName_EN).HasColumnName("FName_EN");
            this.Property(t => t.Createtime).HasColumnName("Createtime");
            this.Property(t => t.FIsDelete).HasColumnName("FIsDelete");

        }
    }
}
