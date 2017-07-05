using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_Auth_ModulePermissionMap : EntityTypeConfiguration<T_Auth_ModulePermission>
    {
        public T_Auth_ModulePermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Auth_ModulePermission");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ModuleId).HasColumnName("ModuleId");
            this.Property(t => t.PermissionId).HasColumnName("PermissionId");
            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasRequired(t => t.T_Auth_Module)
                .WithMany(t => t.T_Auth_ModulePermission)
                .HasForeignKey(d => d.ModuleId);
            this.HasRequired(t => t.T_Auth_Permission)
                .WithMany(t => t.T_Auth_ModulePermission)
                .HasForeignKey(d => d.PermissionId);

        }
    }
}
