
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class CNYD_STRUCT_TREEMap : EntityTypeConfiguration<CNYD_STRUCT_TREE>
    {
        public CNYD_STRUCT_TREEMap()
        {

            // Primary Key
            this.HasKey(t => t.ID_);

            this.ToTable("CNYD_STRUCT_TREE");
            this.Property(t => t.ID_).HasColumnName("ID_");
            this.Property(t => t.CASCADE_ID_).HasColumnName("CASCADE_ID_");
            this.Property(t => t.STRUCT_KEY_).HasColumnName("STRUCT_KEY_");
            this.Property(t => t.STRUCT_NAME_).HasColumnName("STRUCT_NAME_");
            this.Property(t => t.STRUCT_TYPEID).HasColumnName("STRUCT_TYPEID");
            this.Property(t => t.PARENT_ID_).HasColumnName("PARENT_ID_");
            this.Property(t => t.IS_LEAF_).HasColumnName("IS_LEAF_");
            this.Property(t => t.IS_AUTO_EXPAND_).HasColumnName("IS_AUTO_EXPAND_");
            this.Property(t => t.ICON_NAME_).HasColumnName("ICON_NAME_");
            this.Property(t => t.SORT_NO_).HasColumnName("SORT_NO_");
            this.Property(t => t.PJ_ID_).HasColumnName("PJ_ID_");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Enable).HasColumnName("Enable");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserCode).HasColumnName("CreateUserCode");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifiedUserID).HasColumnName("ModifiedUserID");
            this.Property(t => t.ModifiedUserCode).HasColumnName("ModifiedUserCode");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.STRUCT_NAME_EN).HasColumnName("STRUCT_NAME_EN");
            this.Property(t => t.MAT_STATUS).HasColumnName("MAT_STATUS");
        }
    }
}
