
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class TC_CompanyMap : EntityTypeConfiguration<TC_Company>
    {
        public TC_CompanyMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);
            this.Property(t => t.Company_Code).HasMaxLength(20);
            this.Property(t => t.Company).HasMaxLength(100);
            this.Property(t => t.Company_EN).HasMaxLength(100);

            this.ToTable("TC_Company");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Company_Code).HasColumnName("Company_Code");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Company_EN).HasColumnName("Company_EN");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.Enable).HasColumnName("Enable");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserCode).HasColumnName("CreateUserCode");
            this.Property(t => t.ModifiedUserID).HasColumnName("ModifiedUserID");
            this.Property(t => t.ModifiedUserCode).HasColumnName("ModifiedUserCode");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Note).HasColumnName("Note");
        }
    }
}