﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
   public  class PackageDTO
    {
       /// <summary>
       /// blank Constructor
       /// </summary>
       public PackageDTO()
       {
       }

        /// <summary>
        /// Parameterised Constructor.
        /// </summary>
        /// <param name="_package"></param>
       public PackageDTO(Connections.Shipping.Package _package)
       {
           if (_package.PackingId != null) this.PackingId = (Guid)_package.PackingId;
           if(_package.UserId!=null)this.UserID=(Guid)_package.UserId;
           if (_package.StationID != null) this.StationID = (Guid)_package.StationID;
           if (_package.ShippingNum != null) this.ShippingNum = (string)_package.ShippingNum;
           if (_package.StartTime != Convert.ToDateTime("01/01/0001")) this.StartTime = (DateTime)_package.StartTime;
           if (_package.EndTime != Convert.ToDateTime("01/01/0001")) this.EndTime = (DateTime)_package.EndTime;
           this.PackingStatus = (int)_package.PackingStatus;
           if (_package.ShipmentLocation != null) this.ShipmentLocation = (String)_package.ShipmentLocation;
           if (_package.ShippingID != null) this.ShippingID = (Guid)_package.ShippingID;
           this.MangerOverride = (int)_package.ManagerOverride;
           if (_package.PCKROWID != null) this.PCKROWID = (String)_package.PCKROWID;
       }

       [DataMember]
       public Guid PackingId { get; set; }

        [DataMember]
       public Guid UserID { get; set; }

        [DataMember]
       public Guid StationID { get; set; }

        [DataMember]
       public String ShippingNum { get; set; }

        [DataMember]
       public DateTime StartTime { get; set; }

        [DataMember]
       public DateTime EndTime { get; set; }

        [DataMember]
       public int PackingStatus { get; set; }

        [DataMember]
       public String ShipmentLocation { get; set; }

        [DataMember]
       public Guid ShippingID { get; set; }

        [DataMember]
       public int MangerOverride { get; set; }

        [DataMember]
       public string PCKROWID { get; set; }
    }
}
