
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_StillageDataMap : EntityTypeConfiguration<T_StillageData>
    {
        public T_StillageDataMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_StillageData");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BTID).HasColumnName("BTID");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.ProID).HasColumnName("ProID");
            this.Property(t => t.StillageID).HasColumnName("StillageID");
        }
    }
}
