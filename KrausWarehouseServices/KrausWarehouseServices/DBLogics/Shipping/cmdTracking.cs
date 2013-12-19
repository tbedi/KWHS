using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    /// <summary>
    /// all get methods of tracking Table
    /// </summary>
    public  class cmdTracking
    {
        #region Get All Methods of Tracking.
        
        

        /// <summary>
        /// create Entity Object
        /// </summary>
        Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

        /// <summary>
        /// Check tracking Number is Present For given box Number. 
        /// if present then Reaturn the Tracking Number string
        /// </summary>
        /// <param name="BoxNum">
        /// String Box Number
        /// </param>
        /// <returns>
        /// string Tracking Number.
        /// </returns>
        public String IschecckTrackingNumberPresent(String BoxNum)
        {
            String _return = "";
            try
            {
                _return = entshipping.Trackings.FirstOrDefault(i => i.BOXNUM == BoxNum).TrackingNum;
            }
            catch (Exception)
            { }
            return _return;
        }

        /// <summary>
        /// Get all records from tracking Table.
        /// </summary>
        /// <returns>
        /// return list of tracking data.
        /// </returns>
        public List<TrackingDTO> GetAll()
        {
            List<TrackingDTO> _lstracking = new List<TrackingDTO>();
            try
            {
                var tracking = (from tra in entshipping.Trackings
                                select tra).ToList();

                foreach (var trackingitem in tracking)
                {
                    _lstracking.Add(new TrackingDTO(trackingitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstracking;
        }

        /// <summary>
        /// Get records from the tracking table by trackingId
        /// </summary>
        /// <param name="_TrackingID">
        /// pass Tracking iD to the function as parameter.
        /// </param>
        /// <returns>
        /// return the List.
        /// </returns>
        public List<TrackingDTO> GetByTrackingID(Guid _TrackingID)
        {
            List<TrackingDTO> _lsTracking = new List<TrackingDTO>();
            try
            {
                var track = (from tra in entshipping.Trackings
                             where tra.TrackingID==_TrackingID
                             select tra).ToList();
                foreach (var trackitem in track)
                {
                    _lsTracking.Add(new TrackingDTO (trackitem));
                }

            }
            catch (Exception)
            {
            }
            return _lsTracking;
        }

        /// <summary>
        /// Get Tracking By PackingID.
        /// </summary>
        /// <param name="PackingID">
        /// pass PAckingID as parameter.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<TrackingDTO> GetByPackingID(Guid PackingID)
        {
            List<TrackingDTO> _lstrack = new List<TrackingDTO>();
            try
            {
                var tracking = (from track in entshipping.Trackings
                                where track.PackingID == PackingID
                                select track).ToList();

                foreach (var trackitem in tracking)
                {
                    _lstrack.Add(new TrackingDTO(trackitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstrack;
        }

        /// <summary>
        /// get tracking records By ShippingID.
        /// </summary>
        /// <param name="_shippingID">
        /// pass shippingID as Parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<TrackingDTO> GetByShippingID(Guid _shippingID)
        {
            List<TrackingDTO> _lstracking = new List<TrackingDTO>();

            try
            {
                var tra = (from tracking in entshipping.Trackings
                           where tracking.ShippingID == _shippingID
                           select tracking).ToList();

                foreach (var trackitem in tra)
                {
                    _lstracking.Add(new TrackingDTO(trackitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstracking;
        
        }

        /// <summary>
        /// get tracking records By BoxID.
        /// </summary>
        /// <param name="_BoxID">
        /// pass BoxID as Parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<TrackingDTO> GetByBoxID(Guid _BoxID)
        {
            List<TrackingDTO> _lstracking = new List<TrackingDTO>();

            try
            {
                var tra = (from tracking in entshipping.Trackings
                           where tracking.BoxID == _BoxID
                           select tracking).ToList();

                foreach (var trackitem in tra)
                {
                    _lstracking.Add(new TrackingDTO(trackitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstracking;
        }

        /// <summary>
        /// get tracking records By TrackingNUmber.
        /// </summary>
        /// <param name="_TrackingNUmber">
        /// pass TrackingNUmber as Parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<TrackingDTO> GetByTrackingNUmber(String _TrackingNUmber)
        {
            List<TrackingDTO> _lstracking = new List<TrackingDTO>();

            try
            {
                var tra = (from tracking in entshipping.Trackings
                           where tracking.TrackingNum == _TrackingNUmber
                           select tracking).ToList();

                foreach (var trackitem in tra)
                {
                    _lstracking.Add(new TrackingDTO(trackitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstracking;
        }

        /// <summary>
        /// get tracking records By VenderID.
        /// </summary>
        /// <param name="_VenderID">
        /// pass VenderID as Parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<TrackingDTO> GetByVenderID(String _VenderID)
        {
            List<TrackingDTO> _lstracking = new List<TrackingDTO>();

            try
            {
                var tra = (from tracking in entshipping.Trackings
                           where tracking.VOIIND == _VenderID
                           select tracking).ToList();

                foreach (var trackitem in tra)
                {
                    _lstracking.Add(new TrackingDTO(trackitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstracking;
        }

        /// <summary>
        /// get tracking records By BoxNum.
        /// </summary>
        /// <param name="_BoxNum">
        /// pass BoxNum as Parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<TrackingDTO> GetByBoxNum(String _BoxNum)
        {
            List<TrackingDTO> _lstracking = new List<TrackingDTO>();

            try
            {
                var tra = (from tracking in entshipping.Trackings
                           where tracking.BOXNUM == _BoxNum
                           select tracking).ToList();

                foreach (var trackitem in tra)
                {
                    _lstracking.Add(new TrackingDTO(trackitem));
                }
            }
            catch (Exception)
            {
            }
            return _lstracking;
        }
        #endregion


        /// <summary>
        /// Update tracking by readytoexpert.
        /// </summary>
        /// <param name="ReadyToExport"></param>
        /// <returns></returns>
        public Boolean UpdateTracking(String TrackingNo, String BoxNumber,Boolean ReadyToExport)
        {
            Boolean _flag = false;
            try
            {
                Tracking tra = entshipping.Trackings.FirstOrDefault(i => i.TrackingNum == TrackingNo && i.BOXNUM == BoxNumber);
                tra.ReadyToExport = ReadyToExport;
                entshipping.SaveChanges();

                _flag = true;
            }
            catch (Exception)
            {
            }
            return _flag;
        }

    }
}
