using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BussinessLogic
{
    public static class VolunteerProcessor
    {
        public static int CreateVolunteer(string firstName, string lastName, string userName, string password, string center,
            string skills, string availability, string address, string phoneNumber, string emailAddress, string education,
            string licenses, string ecName, string ecPhone, string ecEmail, string ecAddress, string approvalStatus, bool driversLicenseOnFile, bool sSCardOnFile
           )
        {
            VolunteerModel data = new VolunteerModel
            {

                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Center = center,
                Skills = skills,
                Availability = availability,
                Address = address,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress,
                Education = education,
                Licenses = licenses,
                ECName = ecName,
                ECPhone = ecPhone,
                ECEmail = ecEmail,
                ECAddress = ecAddress,
                ApprovalStatus = approvalStatus,
                DriversLicenseOnFile = driversLicenseOnFile,
                SSCardOnFile = sSCardOnFile

            };

            string sql = @"insert into dbo.Volunteer (FirstName, LastName, UserName, Password, Center, Skills, Availability, Address, PhoneNumber,
                            EmailAddress, Education, Licenses, ECName, ECPhone, ECEmail, ECAddress, ApprovalStatus, DriversLicenseOnFile, SSCardOnFile )
                          values(@FirstName, @LastName, @UserName, @Password, @Center, @Skills, @Availability, @Address, @PhoneNumber,
                            @EmailAddress, @Education, @Licenses, @ECName, @ECPhone, @ECEmail, @ECAddress, @ApprovalStatus, @DriversLicenseOnFile, @SSCardOnFile);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int EditVolunteer(int Vol_Id, string firstName, string lastName, string userName, string password, string center,
           string skills, string availability, string address, string phoneNumber, string emailAddress, string education,
           string licenses, string ecName, string ecPhone, string ecEmail, string ecAddress, string approvalStatus, bool driversLicenseOnFile, bool sSCardOnFile
           )
        {
            VolunteerModel data = new VolunteerModel
            {
                Vol_Id = Vol_Id,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Center = center,
                Skills = skills,
                Availability = availability,
                Address = address,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress,
                Education = education,
                Licenses = licenses,
                ECName = ecName,
                ECPhone = ecPhone,
                ECEmail = ecEmail,
                ECAddress = ecAddress,
                ApprovalStatus = approvalStatus,
                DriversLicenseOnFile = driversLicenseOnFile,
                SSCardOnFile = sSCardOnFile

            };
       

            string sql = @"update dbo.Volunteer set FirstName = @FirstName, LastName= @LastName, UserName= @UserName, Password = @Password,
                        Center= @Center,  Skills = @Skills, Availability= @Availability, Address= @Address, PhoneNumber= @PhoneNumber,
                            EmailAddress= @EmailAddress,  Education= @Education, Licenses= @Licenses, ECName= @ECName,
                    ECPhone= @ECPhone, ECEmail= @ECEmail, ECAddress=  @ECAddress,  ApprovalStatus= @ApprovalStatus, DriversLicenseOnFile= @DriversLicenseOnFile,
                    SSCardOnFile= @SSCardOnFile where Vol_Id = @Vol_Id;";


            return SqlDataAccess.SaveData(sql, data);
        }
        public static int DelVolunteer(int Vol_ID)
        {
            VolunteerModel data = new VolunteerModel
            {
               Vol_Id = Vol_ID

            };

            string sql = @"DELETE FROM dbo.Volunteer WHERE Vol_id= @Vol_ID;";

            return SqlDataAccess.SaveData(sql, data);

        }
        public static List<VolunteerModel> FindVol(string searchString)
        {
            string sql = @"select FirstName, LastName, UserName, Password, Center, Skills, Availability, Address, PhoneNumber,
                            EmailAddress, Education, Licenses, ECName, ECPhone, ECEmail, ECAddress, ApprovalStatus, DriversLicenseOnFile, SSCardOnFile
                            from dbo.Volunteer
                            where FirstName Like '%" + @searchString + "%' OR LastName Like '%" + @searchString + "%' OR UserName Like '%" + @searchString + "%';";

            return SqlDataAccess.LoadData<VolunteerModel>(sql);
        }
        public static List<VolunteerModel> ApprovalStatus(string filter)
        {
            string sql = @"select FirstName, LastName, UserName, Password, Center, Skills, Availability, Address, PhoneNumber,
                            EmailAddress, Education, Licenses, ECName, ECPhone, ECEmail, ECAddress, ApprovalStatus, DriversLicenseOnFile, SSCardOnFile
                            from dbo.Volunteer
                            where ApprovalStatus Like '"+ @filter + "';";

            return SqlDataAccess.LoadData<VolunteerModel>(sql);
        }
        public static List<VolunteerModel> AP()
        {
            string sql = @"select FirstName, LastName, UserName, Password, Center, Skills, Availability, Address, PhoneNumber,
                            EmailAddress, Education, Licenses, ECName, ECPhone, ECEmail, ECAddress, ApprovalStatus, DriversLicenseOnFile, SSCardOnFile
                            from dbo.Volunteer
                            where ApprovalStatus Like 'Approved' OR ApprovalStatus Like 'Pending Approval';";

            return SqlDataAccess.LoadData<VolunteerModel>(sql);
        }
        public static List<MatchOppVol> LoadMatch()
        {
            string sql = @"select dbo.Volunteer.FirstName, dbo.Volunteer.LastName, dbo.Volunteer.UserName,dbo.Oppurtunity.Opp_Name, dbo.Oppurtunity.Opp_Center ,dbo.Oppurtunity.Opp_Desc
                                from dbo.Volunteer, dbo.Oppurtunity
                                where dbo.Volunteer.Center = dbo.Oppurtunity.Opp_Center;";

            return SqlDataAccess.LoadData<MatchOppVol>(sql);
        }

        public static List<VolunteerModel> LoadVolunteer()
        {

            string sql = @"select Vol_Id, FirstName, LastName, UserName, Password, Center,  Skills, Availability, Address, PhoneNumber, 
                EmailAddress, Education, Licenses, ECName, ECPhone, ECEmail, ECAddress, ApprovalStatus, DriversLicenseOnFile, SSCardOnFile from dbo.Volunteer;";

            return SqlDataAccess.LoadData<VolunteerModel>(sql);
        }
    }
}
