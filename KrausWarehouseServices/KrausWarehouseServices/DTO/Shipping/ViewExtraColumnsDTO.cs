using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
   public class ViewExtraColumnsDTO
    {
        [DataMember]
        public String ItemName { get; set; }
        
        [DataMember]
        public String UnitOfMeasure { get; set; }
        
        [DataMember]
        public string CountryOfOrigin { get; set; }

        [DataMember]
        public Decimal MAP_Price { get; set; }

        [DataMember]
        public String TCLCOD_0 { get; set; }

        [DataMember]
        public String TarrifCode { get; set; }

        public ViewExtraColumnsDTO()
        {

        }

    }
}
