
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class T_TA_STRUCTMap : EntityTypeConfiguration<T_TA_STRUCT>
    {
        public T_TA_STRUCTMap()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("T_TA_STRUCT");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.STRUCT_TREE_ID).HasColumnName("STRUCT_TREE_ID");
            this.Property(t => t.T_TA_Info).HasColumnName("T_TA_Info");
        }
    }
}