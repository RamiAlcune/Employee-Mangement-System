using DataAccessLayer_EMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_ESM
{
    public class clsPosition
    {
        public static DataTable GetAllPositions()
        {
            return clsPositionData.GetAllPositions();
        }
    }
}
