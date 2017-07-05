
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_ShipHeaderMap : EntityTypeConfiguration<T_ShipHeader>
    {
        public T_ShipHeaderMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_ShipHeader");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ShipRef).HasColumnName("ShipRef");
            this.Property(t => t.ShipFrom).HasColumnName("ShipFrom");
            this.Property(t => t.ShipTo).HasColumnName("ShipTo");
            this.Property(t => t.ShipType).HasColumnName("ShipType");
            this.Property(t => t.Forwarder).HasColumnName("Forwarder");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.SenderAddr).HasColumnName("SenderAddr");
            this.Property(t => t.PickAddr).HasColumnName("PickAddr");
            this.Property(t => t.ContactSender).HasColumnName("ContactSender");
            this.Property(t => t.ReceiveAddr).HasColumnName("ReceiveAddr");
            this.Property(t => t.DeliveryAddr).HasColumnName("DeliveryAddr");
            this.Property(t => t.ContactReceiver).HasColumnName("ContactReceiver");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.etc).HasColumnName("etc");
            this.Property(t => t.ShipStatus).HasColumnName("ShipStatus");
        }
    }
}
