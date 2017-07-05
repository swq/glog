using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_ViewCelldataMap : EntityTypeConfiguration<T_ViewCelldata>
    {
        public T_ViewCelldataMap()
        {
            this.HasKey(s => s.ID);
            this.ToTable("T_ViewCelldata");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ViewGUID).HasColumnName("ViewGUID");
            this.Property(t => t.CellValue).HasColumnName("CellValue");
            this.Property(t => t.Cell_X).HasColumnName("Cell_X");
            this.Property(t => t.Cell_Y).HasColumnName("Cell_Y");
        }
    }
}