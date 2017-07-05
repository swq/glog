using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gLog_FrontEnd.Models.Mapping
{
    public class CNYD_B_PROJECTMAP : EntityTypeConfiguration<CNYD_B_PROJECT>
    {

        public CNYD_B_PROJECTMAP()
        {
            // Primary Key
            this.HasKey(t => t.ID_);
            this.ToTable("CNYD_B_PROJECT");

            this.Property(t => t.ID_).HasColumnName("ID_");
            this.Property(t => t.PJ_NUMBER_).HasColumnName("PJ_NUMBER_");
            this.Property(t => t.PJ_NAME_YE_).HasColumnName("PJ_NAME_YE_");
            this.Property(t => t.PJ_NAME_CN_).HasColumnName("PJ_NAME_CN_");
            this.Property(t => t.PJ_COMMENTS_).HasColumnName("PJ_COMMENTS_");
            this.Property(t => t.PJ_MAINCONTRACTOR_).HasColumnName("PJ_MAINCONTRACTOR_");
            this.Property(t => t.PJ_ARCHITECT_).HasColumnName("PJ_ARCHITECT_");
            this.Property(t => t.PJ_COUNTRY_).HasColumnName("PJ_COUNTRY_");
            this.Property(t => t.PJ_TYPE_).HasColumnName("PJ_TYPE_");
            this.Property(t => t.PJ_STATUS_).HasColumnName("PJ_STATUS_");
            this.Property(t => t.RECAUTONR_).HasColumnName("RECAUTONR_");
            this.Property(t => t.RECCREATED_).HasColumnName("RECCREATED_");
            this.Property(t => t.RECCREATEDBY_).HasColumnName("RECCREATEDBY_");
            this.Property(t => t.RECCREATEDBYUSRID_).HasColumnName("RECCREATEDBYUSRID_");
            this.Property(t => t.RECLASTMODIFIED_).HasColumnName("RECLASTMODIFIED_");
            this.Property(t => t.RECLASTMODIFIEDBY_).HasColumnName("RECLASTMODIFIEDBY_");
            this.Property(t => t.RECLASTMODIFIEDBYUSRID_).HasColumnName("RECLASTMODIFIEDBYUSRID_");
            this.Property(t => t.RECOWNER_).HasColumnName("RECOWNER_");
            this.Property(t => t.RECLOCK_).HasColumnName("RECLOCK_");
            this.Property(t => t.RECCHANGES_).HasColumnName("RECCHANGES_");
            this.Property(t => t.RECDELETED_).HasColumnName("RECDELETED_");
            this.Property(t => t.PJ_BACKENDFILE_).HasColumnName("PJ_BACKENDFILE_");
            this.Property(t => t.PJ_PROJECTPATH_).HasColumnName("PJ_PROJECTPATH_");
            this.Property(t => t.SAP_COMPANY_).HasColumnName("SAP_COMPANY_");
            this.Property(t => t.SAP_DEPARTMENT_).HasColumnName("SAP_DEPARTMENT_");
            this.Property(t => t.SAP_PRCTR_).HasColumnName("SAP_PRCTR_");
            this.Property(t => t.SAP_PSPNR_).HasColumnName("SAP_PSPNR_");
            this.Property(t => t.SSDATE_).HasColumnName("SSDATE_");
            this.Property(t => t.FFDATE_).HasColumnName("FFDATE_");
            this.Property(t => t.COMPANYID_).HasColumnName("COMPANYID_");
        }
    }
}