using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    /// <summary>
    /// Get And Upsert Operation on Stayion Master.
    /// </summary>
   public  class cmdStationMaster
    {
        /// <summary>
        /// Create the Object OF Shipping Entity.
        /// </summary>
        Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

        #region Get Methods For Station Master.

       /// <summary>
       /// Get all records from the Station table.
       /// </summary>
       /// <returns>
       /// Return list.
       /// </returns>
        public List<StationMasterDTO> GetAll()
        {
            List<StationMasterDTO> _lsstation = new List<StationMasterDTO>();
            try
            {
                var station = (from stationall in entshipping.Stations
                               select stationall).ToList();

                foreach (var stationitem in station)
                {
                    _lsstation.Add(new StationMasterDTO(stationitem));
                }
            }
            catch (Exception)
            {
            }
            return _lsstation;
        }

       /// <summary>
       /// Get records from the station table by stationID.
       /// </summary>
       /// <param name="_stationID">
       /// pass stationid as parameter. 
       /// </param>
       /// <returns>
       /// Return list.
       /// </returns>
        public List<StationMasterDTO> GetByStationID(Guid _stationID)
        {
            List<StationMasterDTO> _lsstation = new List<StationMasterDTO>();

            try
            {
                var staion = (from sta in entshipping.Stations
                              where sta.StationID == _stationID
                              select sta).ToList();

                foreach (var statiionitem in staion)
                {
                    _lsstation.Add(new StationMasterDTO(statiionitem));
                }
            }
            catch (Exception)
            {
            }
            return _lsstation;
        
        }

       /// <summary>
       /// Get data from Station table by Station Name. 
       /// </summary>
       /// <param name="StationName">
       /// pass parameter StationName.
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
        public List<StationMasterDTO> GetByStattionName(String StationName)
        {
            List<StationMasterDTO> _lsstation = new List<StationMasterDTO>();
            try
            {
                var station = (from sta in entshipping.Stations
                               where sta.StationName == StationName
                               select sta).ToList();
                foreach (var stationitem in station)
                {
                    _lsstation.Add(new StationMasterDTO(stationitem));
                }
            }
            catch (Exception)
            {
            }
            return _lsstation;
        }

        /// <summary>
        /// Get data from Station table by RequestedUserID. 
        /// </summary>
        /// <param name="RequestedUserID">
        /// pass parameter StationName.
        /// </param>
        /// <returns>
        /// Return List.
        /// </returns>
        public List<StationMasterDTO> GetByRequestedUserID(Guid RequestedUserID)
        {
            List<StationMasterDTO> _lsstation = new List<StationMasterDTO>();
            try
            {
                var station = (from sta in entshipping.Stations
                               where sta.RequestedUserID == RequestedUserID
                               select sta).ToList();
                foreach (var stationitem in station)
                {
                    _lsstation.Add(new StationMasterDTO(stationitem));
                }
            }
            catch (Exception)
            {
            }
            return _lsstation;
        }

        #endregion

        #region Upsert Method

       /// <summary>
       /// Upsert Operation on Station Table.
       /// </summary>
       /// <param name="_station">
       /// pass Station MAster DTO object.
       /// </param>
       /// <returns>
       /// return Boolean Values.
       /// </returns>
        public Boolean UpsertStation(List<StationMasterDTO> _station)
        {
            Boolean _flag = false;
            try
            {
                foreach (var stationitem in _station)
                {
                    Station statinsave = new Station();
                    statinsave = entshipping.Stations.SingleOrDefault(re => re.StationID == stationitem.StationID);
                    if (statinsave == null)
                    {
                        statinsave = new Station();
                        statinsave.StationID = stationitem.StationID;
                        statinsave.StationName = stationitem.StationName;
                        statinsave.RequestedUserID = stationitem.RequestedUserID;
                        statinsave.StationAlive = stationitem.StationAlive;
                        statinsave.DeviceNumber = stationitem.DeviceNumber;
                        statinsave.StationLocation = stationitem.StaionLocation;
                        statinsave.RegistrationDate = stationitem.RegistrationDate;
                        statinsave.Updatedby = stationitem.Updatedby;
                        statinsave.CreatedBy = stationitem.CreatedBy;
                        statinsave.CreatedDateTime = stationitem.CreatedDateTime;
                        statinsave.UpdatedDateTime = stationitem.UpdatedDateTime;
                        entshipping.AddToStations(statinsave);
                    }
                    else
                    {
                        statinsave.StationName = stationitem.StationName;
                        statinsave.RequestedUserID = stationitem.RequestedUserID;
                        statinsave.StationAlive = stationitem.StationAlive;
                        statinsave.DeviceNumber = stationitem.DeviceNumber;
                        statinsave.StationLocation = stationitem.StaionLocation;
                        statinsave.RegistrationDate = stationitem.RegistrationDate;
                        statinsave.Updatedby = stationitem.Updatedby;
                        statinsave.CreatedBy = stationitem.CreatedBy;
                        statinsave.CreatedDateTime = stationitem.CreatedDateTime;
                        statinsave.UpdatedDateTime = stationitem.UpdatedDateTime;
                    }
                }

            }
            catch (Exception)
            {
            }
            entshipping.SaveChanges();
            return _flag;
        }
 
        #endregion

    }
}
