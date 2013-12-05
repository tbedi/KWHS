using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class ErrorLogDTO
    {

        [DataMember]
        public Guid ErrorlogID { get; set; }

        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public String ErrorLocation { get; set; }

        [DataMember]
        public String ErrorDesc { get; set; }

        [DataMember]
        public DateTime ErrorTime { get; set; }

        /// <summary>
        /// blank Constructor
        /// </summary>
        public ErrorLogDTO()
        {

        }
        /// <summary>
        /// Paramiterised Constructor.
        /// </summary>
        /// <param name="_errorlog"></param>
        public ErrorLogDTO(Connections.Shipping.ErrorLog _errorlog)
        {
            if (_errorlog.ErrorLogID != null) this.ErrorlogID = (Guid)_errorlog.ErrorLogID;
            if (_errorlog.UserID != null) this.UserID = (Guid)_errorlog.UserID;
            if (_errorlog.ErrorLocation != null) this.ErrorLocation = (string)_errorlog.ErrorLocation;
            if (_errorlog.ErrorDesc != null) this.ErrorDesc = (string)_errorlog.ErrorDesc;
            if (_errorlog.ErrorTime != Convert.ToDateTime("01/01/0001")) this.ErrorTime = (DateTime)_errorlog.ErrorTime;
        }
    }
}
