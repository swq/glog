using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_Auth_UserMap : EntityTypeConfiguration<T_Auth_User>
    {
        public T_Auth_UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LoginName)
                .HasMaxLength(50);

            this.Property(t => t.LoginPwd)
                .HasMaxLength(50);

            this.Property(t => t.FullName)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Auth_User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LoginName).HasColumnName("LoginName");
            this.Property(t => t.LoginPwd).HasColumnName("LoginPwd");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.PwdErrorCount).HasColumnName("PwdErrorCount");
            this.Property(t => t.LoginCount).HasColumnName("LoginCount");
            this.Property(t => t.RegisterTime).HasColumnName("RegisterTime");
            this.Property(t => t.LastLoginTime).HasColumnName("LastLoginTime");
            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships

        }
    }
}
