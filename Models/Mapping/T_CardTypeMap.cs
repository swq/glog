using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_CardTypeMap : EntityTypeConfiguration<T_CardType>
    {
        public T_CardTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CardType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_CardType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CardType).HasColumnName("CardType");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
