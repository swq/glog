
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_TA_InfoMap : EntityTypeConfiguration<T_TA_Info>
    {
        public T_TA_InfoMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_TA_Info");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TA_Code).HasColumnName("TA_Code");
            this.Property(t => t.Note_EN).HasColumnName("Note_EN");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Floors).HasColumnName("Floors");
            this.Property(t => t.PJ_ID).HasColumnName("PJ_ID");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Enable).HasColumnName("Enable");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserCode).HasColumnName("CreateUserCode");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifiedUserID).HasColumnName("ModifiedUserID");
            this.Property(t => t.ModifiedUserCode).HasColumnName("ModifiedUserCode");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder"); 
            this.Property(t => t.TA_TYPE).HasColumnName("TA_TYPE");
        }
    }
}