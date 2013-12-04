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
       

      

       }

       public Guid BoxID { get; set; }
       public Guid PackingID { get; set; }
       public string BoxType { get; set; }
       public Double BoxWeight { get; set; }
       public Double BoxLength { get; set; }
       public Double BoxHeight { get; set; }
       public Double BoxWidth { get; set; }
       public DateTime BoxCreatedTime { get; set; }
       public DateTime BoxMeasurementTime { get; set; }
       public int ROWID { get; set; }
       public string BOXNUM { get; set; }
    }
}
