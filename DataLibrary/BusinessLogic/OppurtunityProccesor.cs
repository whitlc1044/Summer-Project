using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.BusinessLogic
{
    public static class OppurtunityProccesor
    {
        public static int CreateOppurtunity(int opp_ID, string opp_Name,
            string opp_Date, string opp_Center)
        {
            OppurtunityModel data = new OppurtunityModel
            {
           
               Opp_Name = opp_Name,
               Opp_Date = opp_Date,
               Opp_Center = opp_Center
                
            };

            string sql = @"insert into dbo.Oppurtunity (Opp_Name, Opp_Date, 
            Opp_Center) values (@Opp_Name, @Opp_Date, @Opp_Center);";

            return SqlDataAccess.SaveData(sql, data);

        }
        public static int EditOppurtunity(int opp_ID, string opp_Name,
            string opp_Date, string opp_Center)
        {
            OppurtunityModel data = new OppurtunityModel
            {
                Opp_ID = opp_ID,
                Opp_Name = opp_Name,
                Opp_Date = opp_Date,
                Opp_Center = opp_Center

            };

            string sql = @"update dbo.Oppurtunity set Opp_Name = @Opp_Name, Opp_Date = @Opp_Date, 
            Opp_Center = @Opp_Center where Opp_Id = @Opp_ID;";

            return SqlDataAccess.SaveData(sql, data);

        }
        public static int DelOppurtunity(int opp_ID)
        {
            OppurtunityModel data = new OppurtunityModel
            {
                Opp_ID = opp_ID
      
            };

            string sql = @"DELETE FROM dbo.Oppurtunity WHERE Opp_ID= @Opp_ID;";

            return SqlDataAccess.SaveData(sql, data);

        }


        public static List<OppurtunityModel> LoadOppurtunity()
        {
            string sql = @"select Opp_ID, Opp_Name, Opp_Date, Opp_Center
                            from dbo.Oppurtunity;";

            return SqlDataAccess.LoadData<OppurtunityModel>(sql);
        }
    }
}
