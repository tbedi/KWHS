using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    public class cmdGetAverageTime
    {
        public List<KeyValuePair<string, float>> Execute(Guid UserID)
        {
            Guid _userId = UserID;

            List<KeyValuePair<string, float>> list = new List<KeyValuePair<string, float>>();
            DateTime currentDate = DateTime.UtcNow;

            Connections.Shipping.Shipping_ManagerEntities1 entities = new Connections.Shipping.Shipping_ManagerEntities1();
            var result = from pd in entities.PackageDetails
                         join p in entities.Packages on pd.PackingId equals p.PackingId
                         join u in entities.Users on p.UserId equals u.UserID
                         where p.UserId == _userId && EntityFunctions.TruncateTime(p.StartTime) == (EntityFunctions.TruncateTime(currentDate))
                         select new
                         {
                             difference = SqlFunctions.DateDiff("s", p.StartTime, p.EndTime)

                         };

            int total = 0;
            foreach (var data in result)
            {
                int diff = (int)data.difference;
                total = total + diff;
            }

            if (total > 0)
            {
                float averageTime = (total / result.Count());
                list.Add(new KeyValuePair<string, float>("Average Time", averageTime));
            }
            else
            {
                list.Add(new KeyValuePair<string, float>("Average Time", 0));
            }

            return list;
        }
    } 
}
