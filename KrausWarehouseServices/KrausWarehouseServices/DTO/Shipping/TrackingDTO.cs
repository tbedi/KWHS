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
       /// <summary>
       /// Blanck Constructor.
       /// </summary>
       public TrackingDTO()
       {
       }
        [DataMember]
       public Guid TrackingID { get; set; }

        [DataMember]
       public Guid PackingID { get; set; }

        [DataMember]
       public Guid ShippingID { get; set; }

        [DataMember]
       public String BoxNum { get; set; }

        [DataMember]
       public String TrackingNum { get; set; }

        [DataMember]
       public DateTime TrackingDate { get; set; }

        [DataMember]
       public DateTime CreatedDateTime { get; set; }

        [DataMember]
       public DateTime UpdatedDateTime { get; set; }

        [DataMember]
       public String VOIIND { get; set; }

        [DataMember]
       public Boolean ReadyToExport { get; set; }

        [DataMember]
       public Boolean Exported { get; set; }
       
        [DataMember]
       public String PCKCHG { get; set; }

        [DataMember]
       public String Weight { get; set; }

        [DataMember]
       public Guid CreatedBy { get; set; }

        [DataMember]
       public Guid Updatedby { get; set; }


       /// <summary>
       /// paramiterised Constructor.
       /// </summary>
       /// <param name="_tracking">
       /// pass Tracking Object.
       /// </param>
       public TrackingDTO(Connections.Shipping.Tracking _tracking)
       {
           if (_tracking.TrackingID != null) this.TrackingID = (Guid)_tracking.TrackingID;
           if (_tracking.PackingID != null) this.PackingID = (Guid)_tracking.PackingID;
           if (_tracking.ShippingID != null) this.ShippingID = (Guid)_tracking.ShippingID;
           if (_tracking.BOXNUM != null) this.BoxNum = (String)_tracking.BOXNUM;
           if (_tracking.TrackingNum != null) this.TrackingNum = (String)_tracking.TrackingNum;
           if (_tracking.TrackingDate!=Convert.ToDateTime("01/01/0001")) this.TrackingDate=(DateTime)_tracking.TrackingDate;
           if (_tracking.UpdatedDateTime != Convert.ToDateTime("01/01/0001")) this.UpdatedDateTime = (DateTime)_tracking.UpdatedDateTime;
           if (_tracking.CreatedDateTime != Convert.ToDateTime("01/01/0001")) this.CreatedDateTime = (DateTime)_tracking.CreatedDateTime;
           if (_tracking.VOIIND != null) this.VOIIND = (String)_tracking.VOIIND;
           if (_tracking.ReadyToExport != null) this.ReadyToExport = (Boolean)_tracking.ReadyToExport;
           if (_tracking.Exported != null) this.Exported = (Boolean)_tracking.Exported;
           if (_tracking.PCKCHG != null) this.PCKCHG =(String) _tracking.PCKCHG;
           if (_tracking.Weight != null) this.PCKCHG = (String)_tracking.Weight;
           if (_tracking.CreatedBy != null) this.CreatedBy = (Guid)_tracking.CreatedBy;
           if (_tracking.Updatedby != null) this.Updatedby = (Guid)_tracking.Updatedby;
       }

    }
}
