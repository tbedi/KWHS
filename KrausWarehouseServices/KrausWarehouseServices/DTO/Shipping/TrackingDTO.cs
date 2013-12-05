using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class TrackingDTO
    {

        [DataMember]
        public Guid TrackingID { get; set; }

        [DataMember]
        public Guid PackingID { get; set; }

        [DataMember]
        public Guid ShippingID { get; set; }

        [DataMember]
        public Guid BoxID { get; set; }

        [DataMember]
        public String SHIP_REF1 { get; set; }

        [DataMember]
        public String TrackingNum { get; set; }

        [DataMember]
        public String TrackingNum_FEDEX { get; set; }

        [DataMember]
        public String TrackingNum_UPS { get; set; }

        [DataMember]
        public String CODCHG { get; set; }

        [DataMember]
        public String PCKCHG { get; set; }

        [DataMember]
        public String Height { get; set; }

        [DataMember]
        public String Length { get; set; }

        [DataMember]
        public String Width { get; set; }

        [DataMember]
        public String BOXNUM { get; set; }

        [DataMember]
        public String CODOPT { get; set; }

        [DataMember]
        public String HDLCHG { get; set; }

        [DataMember]
        public String INSVAL { get; set; }

        [DataMember]
        public String PCKTYP { get; set; }

        [DataMember]
        public String TOTWEI { get; set; }

        [DataMember]
        public String TOTPKG { get; set; }

        [DataMember]
        public String TOTSHP { get; set; }

        [DataMember]
        public String XWAREHOUSE { get; set; }

        [DataMember]
        public String CustomerPO { get; set; }

        [DataMember]
        public String SRVTYP { get; set; }

        [DataMember]
        public String PKUDAT { get; set; }

        [DataMember]
        public String SHIDAT { get; set; }

        [DataMember]
        public String Weight { get; set; }

        [DataMember]
        public String XSPECHG_0 { get; set; }

        [DataMember]
        public String VOIIND { get; set; }

        [DataMember]
        public DateTime TrackingDate { get; set; }

        [DataMember]
        public DateTime CreatedDateTime { get; set; }

        [DataMember]
        public DateTime UpdatedDateTime { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid Updatedby { get; set; }

        [DataMember]
        public Boolean ReadyToExport { get; set; }

        [DataMember]
        public Boolean Exported { get; set; }
        /// <summary>
        /// Blanck Constructor.
        /// </summary>
        public TrackingDTO()
        {
        }

        /// <summary>
        /// paramiterised Constructor.
        /// </summary>
        /// <param name="_tracking">
        /// pass Tracking Object.
        /// </param>
        public TrackingDTO(Connections.Shipping.Tracking _tracking)
        {
            if (_tracking.TrackingID != null) this.TrackingID = _tracking.TrackingID;
            if (_tracking.PackingID != null) this.PackingID = (Guid)_tracking.PackingID;
            if (_tracking.ShippingID != null) this.ShippingID = (Guid)_tracking.ShippingID;
            if (_tracking.BoxID != null) this.BoxID = (Guid)_tracking.BoxID;
            if (_tracking.SHIP_REF1 != null) this.SHIP_REF1 = _tracking.SHIP_REF1;
            if (_tracking.TrackingNum != null) this.TrackingNum = _tracking.TrackingNum;
            if (_tracking.TrackingNum_FEDEX != null) this.TrackingNum_FEDEX = _tracking.TrackingNum_FEDEX;
            if (_tracking.TrackingNum_UPS != null) this.TrackingNum_UPS = _tracking.TrackingNum_UPS;
            if (_tracking.CODCHG != null) this.CODCHG = _tracking.CODCHG;
            if (_tracking.PCKCHG != null) this.PCKCHG = _tracking.PCKCHG;
            if (_tracking.Height != null) this.Height = _tracking.Height;
            if (_tracking.Length != null) this.Length = _tracking.Length;
            if (_tracking.Width != null) this.Width = _tracking.Width;
            if (_tracking.BOXNUM != null) this.BOXNUM = _tracking.BOXNUM;
            if (_tracking.CODOPT != null) this.CODOPT = _tracking.CODOPT;
            if (_tracking.HDLCHG != null) this.HDLCHG = _tracking.HDLCHG;
            if (_tracking.INSVAL != null) this.INSVAL = _tracking.INSVAL;
            if (_tracking.PCKTYP != null) this.PCKTYP = _tracking.PCKTYP;
            if (_tracking.TOTWEI != null) this.TOTWEI = _tracking.TOTWEI;
            if (_tracking.TOTPKG != null) this.TOTPKG = _tracking.TOTPKG;
            if (_tracking.TOTSHP != null) this.TOTSHP = _tracking.TOTSHP;
            if (_tracking.XWAREHOUSE != null) this.XWAREHOUSE = _tracking.XWAREHOUSE;
            if (_tracking.CustomerPO != null) this.CustomerPO = _tracking.CustomerPO;
            if (_tracking.SRVTYP != null) this.SRVTYP = _tracking.SRVTYP;
            if (_tracking.PKUDAT != null) this.PKUDAT = _tracking.PKUDAT;
            if (_tracking.SHIDAT != null) this.SHIDAT = _tracking.SHIDAT;
            if (_tracking.Weight != null) this.Weight = _tracking.Weight;
            if (_tracking.XSPECHG_0 != null) this.XSPECHG_0 = _tracking.XSPECHG_0;
            if (_tracking.VOIIND != null) this.VOIIND = _tracking.VOIIND;
            if (_tracking.TrackingDate != null) this.TrackingDate = (DateTime)_tracking.TrackingDate;
            if (_tracking.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_tracking.CreatedDateTime;
            if (_tracking.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_tracking.UpdatedDateTime;
            if (_tracking.CreatedBy != null) this.CreatedBy = (Guid)_tracking.CreatedBy;
            if (_tracking.Updatedby != null) this.Updatedby = (Guid)_tracking.Updatedby;
            if (_tracking.ReadyToExport != null) this.ReadyToExport = (Boolean)_tracking.ReadyToExport;
            if (_tracking.Exported != null) this.Exported = (Boolean)_tracking.Exported;
        }

    }
}
