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
        public static int CreateOppurtunity(string opp_Name,
            string opp_Date, string opp_Center, string opp_Desc)
        {
            OppurtunityModel data = new OppurtunityModel
            {

                Opp_Name = opp_Name,
                Opp_Date = opp_Date,
                Opp_Center = opp_Center,
                Opp_Desc = opp_Desc

            };

            string sql = @"insert into dbo.Oppurtunity (Opp_Name, Opp_Date, 
            Opp_Center,opp_Desc) values (@Opp_Name, @Opp_Date, @Opp_Center,@Opp_Desc);";

            return SqlDataAccess.SaveData(sql, data);

        }
        public static int EditOppurtunity(int opp_ID, string opp_Name,
            string opp_Date, string opp_Center, string opp_Desc)
        {
            OppurtunityModel data = new OppurtunityModel
            {
                Opp_ID = opp_ID,
                Opp_Name = opp_Name,
                Opp_Date = opp_Date,
                Opp_Center = opp_Center,
                Opp_Desc = opp_Desc
            };

            string sql = @"update dbo.Oppurtunity set Opp_Name = @Opp_Name, Opp_Date = @Opp_Date, 
            Opp_Center = @Opp_Center, Opp_Desc = @opp_Desc where Opp_Id = @Opp_ID;";

            return SqlDataAccess.SaveData(sql, data);

        }
        public static int DelOppurtunity(int opp_ID)
        {
            OppurtunityModel data = new OppurtunityModel
            {
              Opp_ID = opp_ID

            };

            string sql = @"DELETE FROM dbo.Oppurtunity WHERE Opp_ID= @opp_ID;";

            return SqlDataAccess.SaveData(sql, data);

        }
        public static List<OppurtunityModel> FindOpp(string searchString)
        {
            string sql = @"select Opp_ID, Opp_Name, Opp_Date, Opp_Center,Opp_Desc
                            from dbo.Oppurtunity
                            where Opp_Name Like '%" + @searchString + "%';";

            return SqlDataAccess.LoadData<OppurtunityModel>(sql);
        }

        public static List<OppurtunityModel> CenterAsc()
        {
            string sql = @"select Opp_ID, Opp_Name, Opp_Date, Opp_Center,Opp_Desc
                            from dbo.Oppurtunity
                            order by Opp_center asc;";

            return SqlDataAccess.LoadData<OppurtunityModel>(sql);
        }
        public static List<OppurtunityModel> Recent()
        {
            string sql = @"select Opp_ID, Opp_Name, Opp_Date, Opp_Center,Opp_Desc
                            from dbo.Oppurtunity
                            order by Opp_Date asc;";

            return SqlDataAccess.LoadData<OppurtunityModel>(sql);
        }

        public static List<OppurtunityModel> RecentFilter()
        {
            string sql = @"select Opp_ID, Opp_Name, Opp_Date, Opp_Center,Opp_Desc
                            from dbo.Oppurtunity
                            where Opp_Date <= DATEADD(d,60, getdate())";

            return SqlDataAccess.LoadData<OppurtunityModel>(sql);
        }
        public static List<MatchOppVol> LoadMatch()
        {
            string sql = @"select dbo.Volunteer.FirstName, dbo.Volunteer.LastName, dbo.Volunteer.UserName,dbo.Oppurtunity.Opp_Name, dbo.Oppurtunity.Opp_Center ,dbo.Oppurtunity.Opp_Desc
                                from dbo.Volunteer, dbo.Oppurtunity
                                where dbo.Volunteer.Center = dbo.Oppurtunity.Opp_Center;";

            return SqlDataAccess.LoadData<MatchOppVol>(sql);
        }
        public static List<OppurtunityModel> LoadOppurtunity()
        {
            string sql = @"select Opp_ID, Opp_Name, Opp_Date, Opp_Center,Opp_Desc
                            from dbo.Oppurtunity;";

            return SqlDataAccess.LoadData<OppurtunityModel>(sql);
        }
    }
}
