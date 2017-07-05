
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_ShipDataMap : EntityTypeConfiguration<T_ShipData>
    {
        public T_ShipDataMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_ShipData");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StillageID).HasColumnName("StillageID");
            this.Property(t => t.Createdate).HasColumnName("Createdate");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ShipID).HasColumnName("ShipID");
        }
    }
}
