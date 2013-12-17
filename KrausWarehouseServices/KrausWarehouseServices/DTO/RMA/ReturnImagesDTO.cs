using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
    public class ReturnImagesDTO
    {
        public ReturnImagesDTO(ReturnImage ReturnImages)
        {
            if (ReturnImages.ReturnImageID != Guid.Empty) this.ReturnImageID = ReturnImages.ReturnImageID;
            if (ReturnImages.ReturnDetailID != Guid.Empty) this.ReturnDetailID = ReturnImages.ReturnDetailID;
            if (ReturnImages.SKUImagePath != null) this.SKUImagePath = ReturnImages.SKUImagePath;
            if (ReturnImages.CreatedBy != Guid.Empty) this.CreatedBy = (Guid)ReturnImages.CreatedBy;
            if (ReturnImages.UpadatedBy != Guid.Empty) this.UpadatedBy = (Guid)ReturnImages.UpadatedBy;
            if (ReturnImages.CreatedDate != null) this.CreatedDate = (DateTime)ReturnImages.CreatedDate;
            if (ReturnImages.UpadatedDate != null) this.UpadatedDate = (DateTime)ReturnImages.UpadatedDate;
        }

        public ReturnImagesDTO()
        {

        }

        [DataMember]
        public Guid ReturnImageID { get; set; }

        [DataMember]
        public Guid ReturnDetailID { get; set; }

        [DataMember]
        public String SKUImagePath { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid UpadatedBy { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime UpadatedDate { get; set; }

    }
}
