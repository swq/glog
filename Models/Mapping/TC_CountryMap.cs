
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class TC_CountryMap : EntityTypeConfiguration<TC_Country>
    {
        public TC_CountryMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("TC_Country");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Country_EN).HasColumnName("Country_EN");
            this.Property(t => t.AreaID).HasColumnName("AreaID");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Enable).HasColumnName("Enable");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserCode).HasColumnName("CreateUserCode");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifiedUserID).HasColumnName("ModifiedUserID");
            this.Property(t => t.ModifiedUserCode).HasColumnName("ModifiedUserCode");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
