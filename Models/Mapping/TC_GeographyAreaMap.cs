
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class TC_GeographyAreaMap : EntityTypeConfiguration<TC_GeographyArea>
    {
        public TC_GeographyAreaMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("TC_GeographyArea");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Enable).HasColumnName("Enable");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserCode).HasColumnName("CreateUserCode");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifiedUserID).HasColumnName("ModifiedUserID");
            this.Property(t => t.ModifiedUserCode).HasColumnName("ModifiedUserCode");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Area_EN).HasColumnName("Area_EN");
        }
    }
}
