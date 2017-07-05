using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class SysConfig_OperateLogMap : EntityTypeConfiguration<SysConfig_OperateLog>
    {
        public SysConfig_OperateLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Area)
                .HasMaxLength(50);

            this.Property(t => t.Controller)
                .HasMaxLength(50);

            this.Property(t => t.Action)
                .HasMaxLength(50);

            this.Property(t => t.IPAddress)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.LoginName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysConfig_OperateLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LogTime).HasColumnName("LogTime");
            this.Property(t => t.LoginName).HasColumnName("LoginName");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasRequired(t => t.T_Auth_User)
                .WithMany(t => t.SysConfig_OperateLog)
                .HasForeignKey(d => d.UserId);

        }
    }
}
