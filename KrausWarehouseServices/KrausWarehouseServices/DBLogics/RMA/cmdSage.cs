using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.DBLogics.RMA
{
    class cmdSage
    {
        /// <summary>
        /// Database object of x3v6 from BI server.
        /// </summary>
        x3v6Entities entX3V6 = new x3v6Entities();

        /// <summary>
        /// Get RMA details from the sage by SRNumber.
        /// </summary>
        /// <param name="SRNumber">
        /// String SRNumber. must be valied.
        /// </param>
        /// <returns>
        /// list of RMAInfoDTO class related to entered SRNumber.
        /// </returns>
        public List<RMAInfoDTO> GetRMAInfoBySRNumber(String SRNumber)
        {
            List<RMAInfoDTO> lsRMAInfo = new List<RMAInfoDTO>();
            try
            {
                var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfoDTO>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                            so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                            so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                            sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                            bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                            itm.ITMDES2_0 ProductName,CAST(sdd.QTY_0 AS INT) DeliveredQty,
                                                                            CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                            CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                            CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                            CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                            CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                            CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                            CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                            CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                            CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                            CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                            CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                            CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                            CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                            CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                            CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                            CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                            CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                            CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                            CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                            CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                            CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                            CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                            CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                            CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                            CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                            CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                            (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                            CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                            CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                            ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                            CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                            CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                            ,itm.TCLCOD_0, CAST(1 AS INT) as SKU_Sequence, CAST(0 AS INT) AS SKU_Qty_Seq
                                                                            FROM PRODUCTION.SRETURN sr
                                                                            INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                            LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                            INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SDDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                            LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                            LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                            LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                            ON itm.ITMREF_0 = srd.ITMREF_0
                                                                            WHERE sr.SRHNUM_0 ='" + SRNumber + "';").ToList();
                if (RMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in RMAdetailsInfo)
                    {
                        RMAInfoDTO rmaInfo = (RMAInfoDTO)RMAitem;
                        lsRMAInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsRMAInfo;
        }

        /// <summary>
        /// Get RMA details from the sage by PO Number.
        /// </summary>
        /// <param name="PONumber">
        /// String PO Number.
        /// </param>
        /// <returns>
        /// list of RMAInfoDTO class related to entered PONumber.
        /// </returns>
        public List<RMAInfoDTO> GetRMAInfoByPONumber(String PONumber)
        {
            List<RMAInfoDTO> lsRMAInfo = new List<RMAInfoDTO>();
            try
            {
                var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfoDTO>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                            so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                            so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                            sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                            bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                            itm.ITMDES2_0 ProductName, CAST(sdd.QTY_0 AS INT) DeliveredQty,
                                                                            CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                            CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                            CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                            CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                            CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                            CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                            CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                            CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                            CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                            CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                            CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                            CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                            CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                            CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                            CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                            CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                            CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                            CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                            CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                            CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                            CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                            CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                            CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                            CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                            CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                            CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                            (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                            CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                            CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                            ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                            CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                            CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                            ,itm.TCLCOD_0, CAST(1 AS INT) as SKU_Sequence, CAST(0 AS INT) AS SKU_Qty_Seq
                                                                            FROM PRODUCTION.SRETURN sr
                                                                            INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                            LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                            INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SDDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                            LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                            LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                            LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                            ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE so.CUSORDREF_0 ='" + PONumber + "';").ToList();
                if (RMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in RMAdetailsInfo)
                    {
                        RMAInfoDTO rmaInfo = (RMAInfoDTO)RMAitem;
                        lsRMAInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsRMAInfo;
        }

        /// <summary>
        /// Get RMA details from the sage by SO Number customer Order number.
        /// </summary>
        /// <param name="SONumber">
        /// string SOnumber .
        /// </param>
        /// <returns>
        /// List of RMA Information class.
        /// </returns>
        public List<RMAInfoDTO> GetRMAInfoBySONumber(String SONumber)
        {
            List<RMAInfoDTO> lsRMAInfo = new List<RMAInfoDTO>();
            try
            {
                var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfoDTO>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                                so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                                so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                                sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                                bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                                itm.ITMDES2_0 ProductName, CAST(sdd.QTY_0 AS INT) DeliveredQty,
                                                                                CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                                CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                                CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                                CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                                CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                                CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                                CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                                CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                                CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                                CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                                CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                                CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                                CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                                CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                                CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                                CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                                CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                                CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                                CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                                (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                                CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                                CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                                CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                                (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                                ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                                ,itm.TCLCOD_0, CAST(1 AS INT) as SKU_Sequence, CAST(0 AS INT) AS SKU_Qty_Seq
                                                                                FROM PRODUCTION.SRETURN sr
                                                                                INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                                LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                                INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SDDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                                LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                                LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                                LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                                ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE so.SOHNUM_0 ='" + SONumber + "';").ToList();
                if (RMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in RMAdetailsInfo)
                    {
                        RMAInfoDTO rmaInfo = (RMAInfoDTO)RMAitem;
                        lsRMAInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsRMAInfo;
        }

        /// <summary>
        /// Get RMA details from the sage by Shipmen Number.
        /// </summary>
        /// <param name="ShipmentNumber">
        /// string Shipment Number .
        /// </param>
        /// <returns>
        /// List of RMA Information class.
        /// </returns>
        public List<RMAInfoDTO> GetRMAInfoByShipmentNumber(String ShipmentNumber)
        {
            List<RMAInfoDTO> lsRMAInfo = new List<RMAInfoDTO>();
            try
            {
                var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfoDTO>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                            so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                            so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                            sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                            bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                            itm.ITMDES2_0 ProductName, CAST(sdd.QTY_0 AS INT) DeliveredQty,
                                                                            CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                            CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                            CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                            CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                            CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                            CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                            CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                            CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                            CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                            CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                            CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                            CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                            CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                            CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                            CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                            CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                            CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                            CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                            CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                            CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                            CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                            CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                            CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                            (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                            CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                            CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                            CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                            (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                            CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                            CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                            ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                            CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                            CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                            ,itm.TCLCOD_0, CAST(1 AS INT) as SKU_Sequence, CAST(0 AS INT) AS SKU_Qty_Seq
                                                                            FROM PRODUCTION.SRETURN sr
                                                                            INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                            LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                            INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SDDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                            LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                            LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                            LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                            ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE srd.SDHNUM_0 ='" + ShipmentNumber + "';").ToList();
                if (RMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in RMAdetailsInfo)
                    {
                        RMAInfoDTO rmaInfo = (RMAInfoDTO)RMAitem;
                        lsRMAInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsRMAInfo;
        }

        /// <summary>
        /// Get RMA details from the sage by PO Number.Don't have RMA number.
        /// </summary>
        /// <param name="PONumber">
        /// String PO Number.
        /// </param>
        /// <returns>
        /// list of RMAInfoDTO class related to entered PONumber.
        /// </returns>
        public List<RMAInfoDTO> GetNewRMAInfoByOnlyPONumber(String PONumber)
        {
            List<RMAInfoDTO> lsRMAInfo = new List<RMAInfoDTO>();
            try
            {
                var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfoDTO>(@"SELECT CAST(NULL AS NVARCHAR) RMANumber,
                                                                                    sdh.SDHNUM_0 ShipmentNumber,
                                                                                    so.SOHNUM_0 OrderNumber,
                                                                                    so.CUSORDREF_0 PONumber,
                                                                                    so.ORDDAT_0 OrderDate,
                                                                                    sdh.DLVDAT_0 DeliveryDate,
                                                                                    CAST(0 AS DATETIME) ReturnDate,
                                                                                    so.BPCORD_0 VendorNumber,
                                                                                    bpc.BPCNAM_0 VendorName, 
                                                                                    sdd.ITMDES1_0 SKUNumber, 
                                                                                    itm.ITMDES2_0 ProductName,
                                                                                    CAST(sdd.QTY_0 AS INT) DeliveredQty,
                                                                                    CAST(0 AS INT) ExpectedQty, 
                                                                                    CAST(0 AS INT) ReturnedQty,
                                                                                    so.BPDNAM_0  CustomerName1,
                                                                                    so.BPDNAM_1  CustomerName2,
                                                                                    so.BPDADDLIG_0  Address1,
                                                                                    so.BPDADDLIG_1  Address2,
                                                                                    so.BPDADDLIG_2  Address3,
                                                                                    so.BPDPOSCOD_0  ZipCode,
                                                                                    so.BPDCTY_0  City,
                                                                                    so.BPDSAT_0  State,
                                                                                    CASE so.BPDCRY_0 WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                                    ELSE so.BPDCRY_0 END Country
                                                                                    ,itm.TCLCOD_0, CAST(1 AS INT) as SKU_Sequence, CAST(0 AS INT) AS SKU_Qty_Seq
                                                                                    FROM
                                                                                    PRODUCTION.SORDER so
                                                                                    INNER JOIN PRODUCTION.SDELIVERY sdh ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                                    INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.LINTYP_0 <> 6
                                                                                    LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON so.BPCORD_0 = bpc.BPCNUM_0
                                                                                    LEFT JOIN PRODUCTION.ITMMASTER itm ON itm.ITMREF_0 = sdd.ITMREF_0
                                                                                    WHERE so.CUSORDREF_0 ='" + PONumber + "';").ToList();
                if (RMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in RMAdetailsInfo)
                    {
                        RMAInfoDTO rmaInfo = (RMAInfoDTO)RMAitem;
                        lsRMAInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsRMAInfo;
        }

        public List<String> GetNewRMAInfo(String Chars)
        {
            List<String> lsNEWRMAInfo = new List<String>();
            try
            {
                var NewRMAdetailsInfo = entX3V6.ExecuteStoreQuery<String>(@"SELECT TOP 10 ITMDES1_0 + '#' + ITMDES2_0 + '#' + TCLCOD_0 FROM PRODUCTION.ITMMASTER WHERE ITMDES1_0 LIKE '" + Chars + "%';").ToList();
                if (NewRMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in NewRMAdetailsInfo)
                    {
                        String rmaInfo = (String)RMAitem;
                        lsNEWRMAInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsNEWRMAInfo;
        }

        public String GetEANCodeByProductName(String Chars)
        {
            String StrEANCode = "";
            try
            {
                StrEANCode = entX3V6.ExecuteStoreQuery<String>(@"SELECT TOP 1 EANCOD_0 FROM PRODUCTION.ITMMASTER WHERE ITMDES1_0 ='" + Chars + "';").SingleOrDefault();
            }
            catch (Exception)
            { }
            return StrEANCode;
        }

        public String GetProductNameByEANCode(String Chars)
        {
            String StrProductName = "";
            try
            {
                StrProductName = entX3V6.ExecuteStoreQuery<String>(@"SELECT TOP 1 ITMDES1_0 FROM PRODUCTION.ITMMASTER WHERE EANCOD_0 ='" + Chars + "';").SingleOrDefault();
            }
            catch (Exception)
            { }
            return StrProductName;
        }

        public String GetSageReasons(String SRNmunber,string SKUNumber)
        {
            String StrReason = "";
            try
            {
                StrReason = entX3V6.ExecuteStoreQuery<String>(@"SELECT RTNREN_0 FROM PRODUCTION.SRETURND WHERE SRHNUM_0 ='" + SRNmunber + "' AND ITMDES1_0 ='" + SKUNumber + "';").SingleOrDefault();
            }
            catch (Exception)
            { }
            return StrReason;
        }

        public List<RMAInfoDTO> GetCustomerByPONumber(string POnumber)
        {
            List<RMAInfoDTO> lsInfo = new List<RMAInfoDTO>();
            try
            {
                var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfoDTO>(@"SELECT DISTINCT so.BPCORD_0,so.SOHNUM_0, ORDDAT_0,sdh.SDHNUM_0,
                                                                              so.CUSORDREF_0 PONumber,

(ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) CustomerName1,

(ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),''))  CustomerName2,

(ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) Address1,
CASE WHEN sr.BPDADDLIG_1 = '' THEN
(ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,

(ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) Address3,

(ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ZipCode,

(ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) City,

(ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) State,

(CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) Country
FROM PRODUCTION.SORDER so 
LEFT JOIN PRODUCTION.SDELIVERY sdh
ON so.SOHNUM_0 = sdh.SOHNUM_0
LEFT JOIN
PRODUCTION.SRETURN sr
INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
 ON sdh.SDHNUM_0 = srd.SDHNUM_0

WHERE CUSORDREF_0 ='" + POnumber + "';").ToList();
                if (RMAdetailsInfo.Count() > 0)
                {
                    foreach (var RMAitem in RMAdetailsInfo)
                    {
                        RMAInfoDTO rmaInfo = (RMAInfoDTO)RMAitem;
                        lsInfo.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsInfo;
        
        }

        public List<String> GetPOnumber(String Chars)
        {
            List<String> lsPOnumber = new List<String>();
            try
            {
                var ponumbers = entX3V6.ExecuteStoreQuery<String>(@"select TOP 10 CUSORDREF_0 FROM PRODUCTION.SORDER WHERE CUSORDREF_0 LIKE'%" + Chars + "%';").ToList();
                if (ponumbers.Count() > 0)
                {
                    foreach (var RMAitem in ponumbers)
                    {
                        String rmaInfo = (String)RMAitem;
                        lsPOnumber.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsPOnumber;
        }

        public List<String> GetVendorName(String Chars)
        {
            List<String> lsVendorName = new List<String>();
            try
            {
                var VanderName = entX3V6.ExecuteStoreQuery<String>(@"SELECT TOP 10 BPCNAM_0 FROM PRODUCTION.BPCUSTOMER WHERE Upper(BPCNAM_0) LIKE '%" + Chars + "%';").ToList();
                if (VanderName.Count() > 0)
                {
                    foreach (var RMAitem in VanderName)
                    {
                        String rmaInfo = (String)RMAitem;
                        lsVendorName.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsVendorName;
        }

        public List<String> GetVendorNumber(String Chars)
        {
            List<String> lsVendorNumber = new List<String>();
            try
            {
                var VendorNumber = entX3V6.ExecuteStoreQuery<String>(@"SELECT TOP 10 BPCNUM_0 FROM PRODUCTION.BPCUSTOMER WHERE Upper(BPCNUM_0) LIKE '%" + Chars + "%';").ToList();
                if (VendorNumber.Count() > 0)
                {
                    foreach (var RMAitem in VendorNumber)
                    {
                        String rmaInfo = (String)RMAitem;
                        lsVendorNumber.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsVendorNumber;
        }
        public String GetVendorNumberByVenderName(String VenderName)
        {
            String StrEANCode = "";
            try
            {
                StrEANCode = entX3V6.ExecuteStoreQuery<String>(@"SELECT BPCNUM_0 FROM PRODUCTION.BPCUSTOMER WHERE BPCNAM_0='" + VenderName + "';").SingleOrDefault();
            }
            catch (Exception)
            { }
            return StrEANCode;
        }

        public String GetVenderNameByVendorNumber(String VenderNumber)
        {
            String StrEANCode = "";
            try
            {
                StrEANCode = entX3V6.ExecuteStoreQuery<String>(@"SELECT BPCNAM_0 FROM PRODUCTION.BPCUSTOMER WHERE BPCNUM_0='" + VenderNumber + "';").SingleOrDefault();
            }
            catch (Exception)
            { }
            return StrEANCode;
        }
    }
}
