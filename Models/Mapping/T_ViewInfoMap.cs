using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_ViewInfoMap : EntityTypeConfiguration<T_ViewInfo>
    {
        public T_ViewInfoMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("T_ViewInfo");
            //this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Pro_id).HasColumnName("Pro_id");
            this.Property(t => t.View_Name).HasColumnName("View_Name");
            this.Property(t => t.Strut_Type).HasColumnName("Strut_Type");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Enable).HasColumnName("Enable");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ViewGUID).HasColumnName("ViewGUID");
        }
    }
}