
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_BT_INFOMap : EntityTypeConfiguration<T_BT_INFO>
    {
        public T_BT_INFOMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_BT_INFO");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TA_ID).HasColumnName("TA_ID");
            this.Property(t => t.BT_Code).HasColumnName("BT_Code");
            this.Property(t => t.Description_EN).HasColumnName("Description_EN");
            this.Property(t => t.Description_CN).HasColumnName("Description_CN");
            this.Property(t => t.Units).HasColumnName("Units");
            this.Property(t => t.Qty).HasColumnName("Qty.");
            this.Property(t => t.Drawing).HasColumnName("Drawing");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.Dimension).HasColumnName("Dimension");
            this.Property(t => t.Specification).HasColumnName("Specification");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.Pro_ID).HasColumnName("Pro_ID");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifiedUserID).HasColumnName("ModifiedUserID");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.ListNO).HasColumnName("ListNO");
            this.Property(t => t.TA_CODE).HasColumnName("TA_CODE");
            this.Property(t => t.TA_DES).HasColumnName("TA_DES");
            this.Property(t => t.BTType).HasColumnName("BTType");
        }
    }
}
