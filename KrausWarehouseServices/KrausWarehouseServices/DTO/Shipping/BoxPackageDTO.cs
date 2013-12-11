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
    public class BoxPackageDTO
    {
       

        [DataMember]
        public Guid BoxID { get; set; }

        [DataMember]
        public Guid PackingID { get; set; }

        [DataMember]
        public string BoxType { get; set; }

        [DataMember]
        public Double BoxWeight { get; set; }

        [DataMember]
        public Double BoxLength { get; set; }

        [DataMember]
        public Double BoxHeight { get; set; }

        [DataMember]
        public Double BoxWidth { get; set; }

        [DataMember]
        public DateTime BoxCreatedTime { get; set; }

        [DataMember]
        public DateTime BoxMeasurementTime { get; set; }

        [DataMember]
        public int ROWID { get; set; }

        [DataMember]
        public string BOXNUM { get; set; }

        /// <summary>
        /// Blank Conctructor
        /// </summary>
        public BoxPackageDTO()
        {

        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="_boxpackage">
        /// Pass the BoxPackage Object.
        /// </param>
        public BoxPackageDTO(Connections.Shipping.BoxPackage _boxpackage)
        {
            if (_boxpackage.BoxID != null) this.BoxID = (Guid)_boxpackage.BoxID;
            if (_boxpackage.PackingID != null) this.PackingID = (Guid)_boxpackage.PackingID;
            if (_boxpackage.BoxWeight != null) this.BoxWeight = (Double)_boxpackage.BoxWeight;
            if (_boxpackage.BoxLength != null) this.BoxLength = (Double)_boxpackage.BoxLength;
            if (_boxpackage.BoxHeight != null) this.BoxHeight = (Double)_boxpackage.BoxHeight;
            if (_boxpackage.BoxWidth != null) this.BoxWidth = (double)_boxpackage.BoxWidth;
            if (_boxpackage.BoxCreatedTime != null) this.BoxCreatedTime = (DateTime)_boxpackage.BoxCreatedTime;
            if (_boxpackage.BoxMeasurementTime != null) this.BoxMeasurementTime = (DateTime)_boxpackage.BoxMeasurementTime;
            this.ROWID = _boxpackage.ROWID;
            if (_boxpackage.BOXNUM != null) this.BOXNUM = (String)_boxpackage.BOXNUM;

        }
    }
}
