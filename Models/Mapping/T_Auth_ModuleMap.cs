using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_Auth_ModuleMap : EntityTypeConfiguration<T_Auth_Module>
    {
        public T_Auth_ModuleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name).HasMaxLength(50);

            this.Property(t => t.LinkUrl)
                .HasMaxLength(100);

            this.Property(t => t.Icon)
                .HasMaxLength(100);

            this.Property(t => t.Code)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Auth_Module");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LinkUrl).HasColumnName("LinkUrl");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.OrderSort).HasColumnName("OrderSort");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsMenu).HasColumnName("IsMenu");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasOptional(t => t.T_Auth_Module2)
                .WithMany(t => t.T_Auth_Module1)
                .HasForeignKey(d => d.ParentId);

        }
    }
}
