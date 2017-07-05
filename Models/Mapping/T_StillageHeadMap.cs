
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_StillageHeadMap : EntityTypeConfiguration<T_StillageHead>
    {
        public T_StillageHeadMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_StillageHead");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DeliveryNote).HasColumnName("DeliveryNote");
            this.Property(t => t.Goods_PreparedBy).HasColumnName("Goods_PreparedBy");
            this.Property(t => t.Goods_PreparedFor).HasColumnName("Goods_PreparedFor");
            this.Property(t => t.Shipping).HasColumnName("Shipping");
            this.Property(t => t.Planned_Packing_Date).HasColumnName("Planned_Packing_Date");
            this.Property(t => t.Actual_Packing_Date).HasColumnName("Actual_Packing_Date");
            this.Property(t => t.Stillage_Status).HasColumnName("Stillage_Status");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Stillage_Type).HasColumnName("Stillage_Type");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.Createdate).HasColumnName("Createdate");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Pro_ID).HasColumnName("Pro_ID");
        }
    }
}