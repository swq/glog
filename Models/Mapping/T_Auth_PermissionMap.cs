using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_Auth_PermissionMap : EntityTypeConfiguration<T_Auth_Permission>
    {
        public T_Auth_PermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Icon)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Auth_Permission");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
