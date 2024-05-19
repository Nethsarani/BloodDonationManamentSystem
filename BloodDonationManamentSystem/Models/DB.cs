using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using BloodDonationManamentSystem.Models;
using System.Security.RightsManagement;


namespace BloodDonationManamentSystem
{
    public class DB
    {
        public SqlConnection con = new SqlConnection(@"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=nethsarani_BloodSystem;User ID=nethsarani_BloodSystem;Password=neth1234;TrustServerCertificate=true;Encrypt=false;multisubnetfailover=true;");
        SqlCommand command;
        public void insertToDatabase(object classobj, string type)
        {
            if(con.State == ConnectionState.Closed){con.Open();}

            if (type == "Hospital")
            {
                try
                {
                    Hospital obj = (Hospital)classobj;
                    command = new SqlCommand("insert into HospitalTable (Name,RegNo,Location,ContactNo,Email,IsTesting,IsCollecting,OpenTimes,Username,Password,Status) values (@name, @regNo, @location, @contact, @email, @testing, @collecting, @open, @username, @password, @status);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam1.DbType = DbType.String;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@regNo", obj.RegNo);
                    sqlParam2.DbType = DbType.String;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                    sqlParam3.DbType = DbType.Xml;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                    sqlParam4.DbType = DbType.String;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@testing", obj.isTesting);
                    sqlParam5.DbType = DbType.Boolean;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@collecting", obj.isCollecting);
                    sqlParam6.DbType = DbType.Boolean;
                    SqlParameter sqlParam7 = command.Parameters.AddWithValue("@open", objToXml(obj.OpenTimes));
                    sqlParam7.DbType = DbType.Xml;
                    SqlParameter sqlParam8 = command.Parameters.AddWithValue("@username", obj.Username);
                    sqlParam8.DbType = DbType.String;
                    SqlParameter sqlParam9 = command.Parameters.AddWithValue("@password", obj.Password);
                    sqlParam9.DbType = DbType.String;
                    SqlParameter sqlParam10 = command.Parameters.AddWithValue("@status", obj.Status);
                    sqlParam10.DbType = DbType.String;
                    SqlParameter sqlParam11 = command.Parameters.AddWithValue("@email", obj.Email);
                    sqlParam11.DbType = DbType.String;
                }
                catch
                {

                }
                
            }
            else if (type == "DonationCamp")
            {
                try
                {
                    DonationCamp obj = (DonationCamp)classobj;
                    command = new SqlCommand("insert into DonationCampTable (Name, Date, StartTime, EndTime, ContactNo ,Email, Location, Username, Password, Status) values (@name, @date, @starttime, @endtime, @contact, @email, @location, @username, @password, @status);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam1.DbType = DbType.String;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@date", obj.Date);
                    sqlParam2.DbType = DbType.DateTime;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                    sqlParam3.DbType = DbType.Xml;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                    sqlParam4.DbType = DbType.String;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@email", obj.Email);
                    sqlParam5.DbType = DbType.String;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@starttime", obj.StartTime);
                    sqlParam6.DbType = DbType.Date;
                    SqlParameter sqlParam7 = command.Parameters.AddWithValue("@endtime", obj.EndTime);
                    sqlParam7.DbType = DbType.Date;
                    SqlParameter sqlParam8 = command.Parameters.AddWithValue("@username", obj.Username);
                    sqlParam8.DbType = DbType.String;
                    SqlParameter sqlParam9 = command.Parameters.AddWithValue("@password", obj.Password);
                    sqlParam9.DbType = DbType.String;
                    SqlParameter sqlParam10 = command.Parameters.AddWithValue("@status", obj.Status);
                    sqlParam10.DbType = DbType.String;
                }
                catch
                {

                }
                
            }
            else if (type == "Donor")
            {
                try
                {
                    Donor obj = (Donor)classobj;
                    command = new SqlCommand("insert into DonorTable (Name, Gender, NIC, Location, DOB, ContactNo, Email, BloodType, HealthCondition, Username, Password, Status) values (@name, @gender, @nic, @location, @dob, @contact, @email, @type, @health, @username, @password, @status);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam1.DbType = DbType.String;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@gender", obj.Gender);
                    sqlParam2.DbType = DbType.String;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                    sqlParam3.DbType = DbType.String;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                    sqlParam4.DbType = DbType.Xml;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@dob", obj.DOB);
                    sqlParam5.DbType = DbType.DateTime;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                    sqlParam6.DbType = DbType.String;
                    SqlParameter sqlParam7 = command.Parameters.AddWithValue("@email", obj.Email);
                    sqlParam7.DbType = DbType.String;
                    SqlParameter sqlParam8 = command.Parameters.AddWithValue("@type", obj.BloodType);
                    sqlParam8.DbType = DbType.String;
                    SqlParameter sqlParam9 = command.Parameters.AddWithValue("@health", objToXml(obj.health));
                    sqlParam9.DbType = DbType.Xml;
                    SqlParameter sqlParam10 = command.Parameters.AddWithValue("@username", obj.Username);
                    sqlParam10.DbType = DbType.String;
                    SqlParameter sqlParam11 = command.Parameters.AddWithValue("@password", obj.Password);
                    sqlParam11.DbType = DbType.String;
                    SqlParameter sqlParam12 = command.Parameters.AddWithValue("@status", "Pending");
                    sqlParam12.DbType = DbType.String;
                }
                catch
                {

                }
                
            }
            else if (type == "Donation")
            {
                try
                {
                    Donation obj = (Donation)classobj;
                    command = new SqlCommand("insert into DonationTable (DonorID, Place, Date, Status) values (@donor, @place, @date, @status);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@donor", obj.Donor.ID);
                    sqlParam1.DbType = DbType.Int32;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@place", obj.collectionPoint.ID);
                    sqlParam2.DbType = DbType.Int32;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@date", obj.Date);
                    sqlParam3.DbType = DbType.Date;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@status", obj.Status);
                    sqlParam4.DbType = DbType.String;
                }
                catch
                { 

                }
                
            }
            else if (type == "Appointment")
            {
                try
                {
                    Appointment obj = (Appointment)classobj;
                    command = new SqlCommand("insert into AppointmentTable (DonorID, CollectionPointID, Date, Time, Description, Status) values (@donor, @place, @date, @time, @desc, @status);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@donor", obj.Donor.ID);
                    sqlParam1.DbType = DbType.Int32;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@place", obj.Place.ID);
                    sqlParam2.DbType = DbType.Int32;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@date", obj.Date);
                    sqlParam3.DbType = DbType.Date;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@time", obj.Time);
                    sqlParam4.DbType = DbType.Time;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@desc", obj.Description);
                    sqlParam5.DbType = DbType.String;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@status", obj.Status);
                    sqlParam6.DbType = DbType.String;
                }
                catch
                {

                }
                
            }
            else if (type == "BloodStock")
            {
                try
                {
                    BloodStock obj = (BloodStock)classobj;
                    command = new SqlCommand("insert into BloodStockTable (Name, Location, Type, Amount, ExpiryDate) values (@name, @location, @type, @amount, @expire);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam1.DbType = DbType.String;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                    sqlParam2.DbType = DbType.Xml;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@type", obj.BloodType);
                    sqlParam3.DbType = DbType.String;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@amount", obj.BloodAmount);
                    sqlParam4.DbType = DbType.Decimal;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@expire", obj.ExpireDate);
                    sqlParam5.DbType = DbType.Date;
                }
                catch
                {

                }
                
            }
            else if (type == "Request")
            {
                try
                {
                    Request obj = (Request)classobj;
                    command = new SqlCommand("insert into RequestTable (HospitalID, Date, BloodType, Amount, Status) values (@hospital, @date, @type, @amount, @status);", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@hospital", obj.Hospital.ID);
                    sqlParam1.DbType = DbType.Int32;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@date", obj.Date);
                    sqlParam2.DbType = DbType.Date;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@type", obj.BloodType);
                    sqlParam3.DbType = DbType.String;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@amount", obj.BloodAmount);
                    sqlParam4.DbType = DbType.Decimal;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@status", "Pending");
                    sqlParam5.DbType = DbType.String;
                }
                catch
                {

                }
                
            }
            else if (type == "HospitalUsers")
            {
                try
                {
                    HospitalUser obj = (HospitalUser)classobj;
                    command = new SqlCommand("insert into HospitalUsersTable (HospitalID, Name, NIC, Position, ContactNo, Email, Username, Password, Privileges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@hospital", obj.hospital.ID);
                    sqlParam1.DbType = DbType.Int32;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam2.DbType = DbType.String;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                    sqlParam3.DbType = DbType.String;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@position", obj.Position);
                    sqlParam4.DbType = DbType.String;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                    sqlParam5.DbType = DbType.String;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@email", obj.Email);
                    sqlParam6.DbType = DbType.String;
                    SqlParameter sqlParam7 = command.Parameters.AddWithValue("@username", obj.UserName);
                    sqlParam7.DbType = DbType.String;
                    SqlParameter sqlParam8 = command.Parameters.AddWithValue("@password", obj.Password);
                    sqlParam8.DbType = DbType.String;
                    SqlParameter sqlParam9 = command.Parameters.AddWithValue("@privilages", objToXml(obj.Privilages));
                    sqlParam9.DbType = DbType.Xml;
                }
                catch
                {

                }
                
            }
            else if (type == "DonationCampUsers")
            {
                try
                {
                    DonationCampUser obj = (DonationCampUser)classobj;
                    command = new SqlCommand("insert into DonationCampUsersTable (DonationCampID, Name, NIC, Position, ContactNo, Email, Username, Password, Privileges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@hospital", obj.donationCamp.ID);
                    sqlParam1.DbType = DbType.Int32;
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam2.DbType = DbType.String;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                    sqlParam3.DbType = DbType.String;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@position", obj.Position);
                    sqlParam4.DbType = DbType.String;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                    sqlParam5.DbType = DbType.String;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@email", obj.Email);
                    sqlParam6.DbType = DbType.String;
                    SqlParameter sqlParam7 = command.Parameters.AddWithValue("@username", obj.UserName);
                    sqlParam7.DbType = DbType.String;
                    SqlParameter sqlParam8 = command.Parameters.AddWithValue("@password", obj.Password);
                    sqlParam8.DbType = DbType.String;
                    SqlParameter sqlParam9 = command.Parameters.AddWithValue("@privilages", objToXml(obj.Privilages));
                    sqlParam9.DbType = DbType.Xml;
                }
                catch
                {

                }
                
            }
            else if (type == "BloodBankUsers")
            {
                try
                {
                    User obj = (User)classobj;
                    command = new SqlCommand("insert into BloodBankUsersTable (Name, NIC, Position, ContactNo, Email, Username, Password, Privileges) values (@name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                    SqlParameter sqlParam2 = command.Parameters.AddWithValue("@name", obj.Name);
                    sqlParam2.DbType = DbType.String;
                    SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                    sqlParam3.DbType = DbType.String;
                    SqlParameter sqlParam4 = command.Parameters.AddWithValue("@position", obj.Position);
                    sqlParam4.DbType = DbType.String;
                    SqlParameter sqlParam5 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                    sqlParam5.DbType = DbType.String;
                    SqlParameter sqlParam6 = command.Parameters.AddWithValue("@email", obj.Email);
                    sqlParam6.DbType = DbType.String;
                    SqlParameter sqlParam7 = command.Parameters.AddWithValue("@username", obj.UserName);
                    sqlParam7.DbType = DbType.String;
                    SqlParameter sqlParam8 = command.Parameters.AddWithValue("@password", obj.Password);
                    sqlParam8.DbType = DbType.String;
                    SqlParameter sqlParam9 = command.Parameters.AddWithValue("@privilages", objToXml(obj.Privilages));
                    sqlParam9.DbType = DbType.Xml;
                }
                catch
                {

                }
                
            }
            else
            {
                command = new SqlCommand();
            }
            try
            {
                command.ExecuteNonQuery();
                con.Close();
            }
            catch { }
            
        }

        public void TestData()
        {
            Donor a = new Donor();
            a.Name= "Test5";
            a.Gender = "Male";
            a.NIC = "12345";
            a.Location=new Location();
            a.DOB = DateTime.Today;
            a.ContactNo = "098765432";
            a.Email = "sdfgh@dfgh.com";
            a.Username = "Test5";
            a.BloodType = "O";
            a.Password = "12345";
            a.Status = "Pending";
            a.health = new HealthCondition();
            insertToDatabase(a, "Donor");
            Appointment appointment = new Appointment();
            appointment.Donor = a;
            appointment.Place = getDonationCamp(2);
            appointment.Date = DateTime.Today;
            appointment.Time = DateTime.Now;
            appointment.Description="Donation";
            appointment.Status = "Complete";
            insertToDatabase(appointment,"Appointment");

        }

        public bool userCheck(string type, string username)
        {
            bool available = true;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select Count(ID) from " + type + "Table WHERE Username=@user;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@user", username);
                sqlParam1.DbType = DbType.String;
                SqlDataReader reader = command.ExecuteReader();
                int x = 0;
                while (reader.Read())
                {
                    x = reader.GetInt32(0);
                }
                con.Close();
                if (x > 0)
                {
                    available = false;
                }
            }
            catch
            {

            }
            return available;
        }

        public int IDCheck(string type, string value, string property)
        {
            int x = 0;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select ID from " + type + "Table WHERE " + property + "=@value;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@value", value);
                sqlParam1.DbType = DbType.String;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    x = reader.GetInt32(0);
                }
                con.Close();
            }
            catch { }

            return x;
        }

        public List<String> getDistrict()
        {
            List<String> x = new List<string>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select name_en from districtsTable;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    x.Add(reader.GetString(0));
                }
                con.Close();
            }
            catch
            {

            }
            
            return x;
        }

        public List<String> getCity(String district)
        {
            List<String> x = new List<string>();
            try
            {
                int disID = IDCheck("districts", district, "name_en");
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select name_en from citiesTable WHERE district_id=@id;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@id", disID);
                sqlParam1.DbType = DbType.String;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    x.Add(reader.GetString(0));
                }
                con.Close();
            }
            catch
            {
                
            }
            
            return x;
        }

        public Dictionary<int, String> getCentre(String city)
        {
            Dictionary<int, String> list = new Dictionary<int, String>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string sql = string.Format(@"Select ID,Name From [HospitalTable] Where Location.exist('/Location[City={0}]')=1", city);
                command = new SqlCommand(sql, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader.GetInt32(0), reader.GetString(1));

                }
                con.Close();
                if (con.State == ConnectionState.Closed) { con.Open(); }
                sql = string.Format(@"Select ID,Name From [DonationCampTable] Where Location.exist('/Location[City={0}]')=1", city);
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetInt32(0), reader.GetString(1));
                }
                con.Close();
            }
            catch
            {

            }
            
            return list;
        }

        public List<TimeRange> checkTime(int id)
        {
            DateTime date;
            TimeSpan start;
            TimeSpan end;
            List<TimeRange> x = new List<TimeRange>();

            if (id % 2 == 0)
            {
                try
                {
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    command = new SqlCommand("Select Date,StartTime,EndTime from DonationCampTable WHERE IDd=@id;", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@id", id);
                    sqlParam1.DbType = DbType.String;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TimeRange x1 = new TimeRange();
                        x1.Date = reader.GetDateTime(0).ToString();
                        x1.Open = reader.GetTimeSpan(1).ToString();
                        x1.Close = reader.GetTimeSpan(2).ToString();
                    }
                    con.Close();
                }
                catch
                {

                }
                
            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    command = new SqlCommand("Select OpenTimes from HospitalTable WHERE ID=@id;", con);
                    SqlParameter sqlParam1 = command.Parameters.AddWithValue("@id", id);
                    sqlParam1.DbType = DbType.String;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string xml = reader.GetString(0);
                        x.Add(xmlToObject<TimeRange>(xml));
                    }
                    con.Close();
                }
                catch
                {

                }
            }
            return x;
        }


        public List<Request> getRequests(String blood)
        {
            List<Request> x = new List<Request>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select HospitalID, Amount from RequestTable WHERE BloodType=@type AND Status='Pending';", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@type", blood);
                sqlParam1.DbType = DbType.String;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Request request = new Request();
                    request.HosId = reader.GetInt32(0);
                    request.BloodAmount = reader.GetDecimal(1);
                    x.Add(request);
                }
                con.Close();
                foreach (Request request in x)
                {
                    request.Hospital = getHospital(request.HosId);
                }
            }
            catch
            {

            }
            
            return x;
        }

        public List<Appointment> getAllAppointments()
        {
            List<Appointment> x = new List<Appointment>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select * from AppointmentTable;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appoint = new Appointment();
                    appoint.Id = reader.GetInt32(0);
                    appoint.donorId = reader.GetInt32(1);
                    appoint.placeId = reader.GetInt32(2);

                    appoint.Date = reader.GetDateTime(3);
                    DateTime a = new DateTime();
                    appoint.Time = new DateTime() + (TimeSpan)reader.GetTimeSpan(4);
                    appoint.Description = reader.GetString(5);
                    appoint.Status = reader.GetString(6);
                    x.Add(appoint);
                }
                con.Close();
                foreach (Appointment appoint in x)
                {
                    appoint.Donor = getDonor(appoint.donorId);
                    if (appoint.placeId % 2 == 0)
                    {
                        appoint.Place = getDonationCamp(appoint.placeId);
                    }
                    else
                    {
                        appoint.Place = getHospital(appoint.placeId);
                    }
                }
            }
            catch
            {

            }
            return x;
        }
        
        public List<Donation> getAllDonations()
        {
            List<Donation> x = new List<Donation>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select * from DonationTable;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Donation appoint = new Donation();
                    appoint.ID = reader.GetInt32(0);
                    appoint.donorId = reader.GetInt32(1);
                    appoint.placeId = reader.GetInt32(2);
                    appoint.Date = reader.GetDateTime(3);
                    appoint.Status = reader.GetString(4);
                    x.Add(appoint);
                }
                con.Close();
                foreach (Donation appoint in x)
                {
                    appoint.Donor = getDonor(appoint.donorId);
                    if (appoint.placeId % 2 == 0)
                    {
                        appoint.collectionPoint = getDonationCamp(appoint.placeId);
                    }
                    else
                    {
                        appoint.collectionPoint = getHospital(appoint.placeId);
                    }
                }
            }
            catch
            {

            }
            
            return x;
        }
        
        public List<Donor> getAllDonors()
        {
            List<Donor> y = new List<Donor>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select * from DonorTable;", con);
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Donor x = new Donor();
                    x.ID = reader.GetInt32(0);
                    x.Name = reader.GetString(1);
                    x.Gender = reader.GetString(2);
                    x.NIC = reader.GetString(3);
                    x.Location = xmlToObject<Location>(reader.GetString(4));
                    x.DOB = reader.GetDateTime(5);
                    x.ContactNo = reader.GetString(6);
                    x.Email = reader.GetString(7);
                    x.BloodType = reader.GetString(8);
                    x.health = xmlToObject<HealthCondition>(reader.GetString(9));
                    x.Username = reader.GetString(10);
                    x.Password = reader.GetString(11);
                    x.Status = reader.GetString(12);
                    y.Add(x);
                }
                con.Close();
            }
            catch
            {

            }
            
            return y;
        }

        public List<User> getAllUsers(string type)
        {
            List<User> y = new List<User>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select * from " + type + "UsersTable;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User x = new User();
                    x.Id = reader.GetInt32(0);
                    x.Name = reader.GetString(2);
                    x.NIC = reader.GetString(3);
                    x.Position = reader.GetString(4);
                    x.ContactNo = reader.GetString(5);
                    x.Email = reader.GetString(6);
                    x.UserName = reader.GetString(7);
                    x.Password = reader.GetString(8);
                    x.Privilages = xmlToObject<Privilages>(reader.GetString(9));
                    if (type == "Hospital")
                    {
                        x.placeID = reader.GetInt32(1);
                    }
                    else if (type == "DonationCamp")
                    {
                        x.placeID = reader.GetInt32(1);
                    }
                    else
                    {
                        x.placeID = 0;
                    }
                    y.Add(x);
                }
                con.Close();
            }
            catch
            {

            }
            
            return y;
        }

        public List<BloodStock> getTotalStock()
        {
            List<BloodStock> x = new List<BloodStock>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select Type,SUM(Amount) from BloodStockTable WHERE ExpiryDate>=@today GROUP BY Type;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@today", DateTime.Today);
                sqlParam1.DbType = DbType.DateTime;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BloodStock stk = new BloodStock();
                    stk.BloodType = reader.GetString(0);
                    stk.BloodAmount = reader.GetDecimal(1);
                    x.Add(stk);
                }
                con.Close();
            }
            catch
            {

            }
            return x;
        }

        public List<BloodStock> getAllStock()
        {
            List<BloodStock> x = new List<BloodStock>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select * from BloodStockTable;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@today", DateTime.Today);
                sqlParam1.DbType = DbType.DateTime;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BloodStock stk = new BloodStock();
                    stk.Id = reader.GetInt32(0);
                    stk.Name = reader.GetString(1);
                    stk.Location = xmlToObject<Location>(reader.GetString(2));
                    stk.BloodType = reader.GetString(3);
                    stk.BloodAmount = reader.GetDecimal(4);
                    stk.ExpireDate = reader.GetDateTime(5);
                    x.Add(stk);
                }
                con.Close();
            }
            catch
            {

            }
            
            return x;
        }


        public List<Donation> getDonation(int id)
        {
            List<Donation> x = new List<Donation>();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select CollectionPointID,Date from DonationTable WHERE DonorID=@id;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@id", id);
                sqlParam1.DbType = DbType.Int32;
                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    Donation don = new Donation();
                    don.placeId = reader2.GetInt32(0);
                    don.Date = reader2.GetDateTime(1);
                    x.Add(don);
                }
                con.Close();
                foreach (Donation don in x)
                {
                    if (reader2.GetInt32(0) % 2 == 0)
                    {
                        don.collectionPoint = getDonationCamp(reader2.GetInt32(0));
                    }
                    else
                    {
                        don.collectionPoint = getHospital(reader2.GetInt32(0));
                    }
                }
            }
            catch
            {

            }
            return x;
        }

        public Hospital getHospital(int id)
        {
            Hospital x = new Hospital();
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand("Select * from HospitalTable WHERE ID=@id;", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@id", id);
                sqlParam1.DbType = DbType.Int32;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    x.ID = reader.GetInt32(0);
                    x.Name = reader.GetString(1);
                    x.RegNo = reader.GetString(2);
                    x.Location = xmlToObject<Location>(reader.GetString(3));
                    x.ContactNo = reader.GetString(4);
                    x.Email = reader.GetString(5);
                    x.isTesting = reader.GetBoolean(6);
                    x.isCollecting = reader.GetBoolean(7);
                    x.OpenTimes = xmlToObject<List<TimeRange>>(reader.GetString(8));
                    x.Username = reader.GetString(9);
                    x.Password = reader.GetString(10);
                    x.Status = reader.GetString(11);

                }
                con.Close();
            }
            catch
            {

            }
            
            return x;
        }

        public Donor getDonor(int id)
        {
            Donor x = new Donor();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    { con.Open(); }
                }
                SqlCommand command2 = new SqlCommand("Select * from DonorTable WHERE ID=@id;", con);
                SqlParameter sqlParam1 = command2.Parameters.AddWithValue("@id", id);
                sqlParam1.DbType = DbType.Int32;
                SqlDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                {
                    x.ID = reader.GetInt32(0);
                    x.Name = reader.GetString(1);
                    x.Gender = reader.GetString(2);
                    x.NIC = reader.GetString(3);
                    x.Location = xmlToObject<Location>(reader.GetString(4));
                    x.DOB = reader.GetDateTime(5);
                    x.ContactNo = reader.GetString(6);
                    x.Email = reader.GetString(7);
                    x.BloodType = reader.GetString(8);
                    x.health = xmlToObject<HealthCondition>(reader.GetString(9));
                    x.Username = reader.GetString(10);
                    x.Password = reader.GetString(11);
                    x.Status = reader.GetString(12);
                }
                con.Close();
            }
            catch
            {

            }
            return x;
        }
        public DonationCamp getDonationCamp(int id)
        {
            DonationCamp x = new DonationCamp();
            try
            {
                if (con.State == ConnectionState.Closed) { if (con.State == ConnectionState.Closed) { con.Open(); } }

                command = new SqlCommand("Select * from DonationCampTable WHERE ID=@id;", con);

                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@id", id);
                sqlParam1.DbType = DbType.Int32;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    x.ID = reader.GetInt32(0);
                    x.Name = reader.GetString(1);
                    x.Date = reader.GetDateTime(2);
                    x.StartTime = reader.GetTimeSpan(3).ToString();
                    x.EndTime = reader.GetTimeSpan(4).ToString();
                    x.ContactNo = reader.GetString(5);
                    x.Email = reader.GetString(6);
                    x.Location = xmlToObject<Location>(reader.GetString(7));
                    x.Username = reader.GetString(8);
                    x.Password = reader.GetString(9);
                    x.Status = reader.GetString(10);
                }
                con.Close();
            }
            catch { }
            
            return x;
        }

        static T xmlToObject<T>(string xmlString)
        {

            T classObject=default;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (StringReader stringReader = new StringReader(xmlString))
                {
                    classObject = (T)xmlSerializer.Deserialize(stringReader);
                }
            }
            catch
            {

            }
            return classObject;
        }

        static string objToXml(object classObject)
        {
            string xmlString = "";
            try
            {
                if (classObject != null)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        xmlSerializer.Serialize(memoryStream, classObject);
                        memoryStream.Position = 0;
                        xmlString = new StreamReader(memoryStream).ReadToEnd();
                    }
                }
            }
            catch
            {

            }
            
            return xmlString;
        }


        public User Login(string username, string password, string type)
        {
            User temp = null;
            try
            {
                if (con.State == ConnectionState.Closed) { if (con.State == ConnectionState.Closed) { con.Open(); } }
                command = new SqlCommand(@"Select * From [" + type + "Table] Where Username=@username and Password=@password", con);
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@username", username);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@password", password);
                sqlParam3.DbType = DbType.String;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (type == "HospitalUsers")
                    {
                        temp = new HospitalUser();
                        temp.placeID = reader.GetInt32(1);
                    }
                    else if (type == "DonationCampUsers")
                    {
                        temp = new DonationCampUser();
                        temp.placeID = reader.GetInt32(1);
                    }
                    else
                    {
                        temp = new User();
                        temp.placeID = 0;
                    }
                    temp.Id = reader.GetInt32(0);
                    temp.Name = reader.GetString(2);
                    temp.NIC = reader.GetString(3);
                    temp.Position = reader.GetString(4);
                    temp.ContactNo = reader.GetString(5);
                    temp.Email = reader.GetString(6);
                    temp.Password = reader.GetString(8);
                    temp.UserName = reader.GetString(7);
                    string xml = reader.GetString(9);
                    temp.Privilages = (Privilages)xmlToObject<Privilages>(xml);
                }
                con.Close();
            }
            catch
            {

            }
            return temp;
        }

        public Donor DonorLogin(string username, string password)
        {
            Donor temp = null;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                command = new SqlCommand(@"Select * From [DonorsTable] Where Username=@username and Password=@password", con);
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@username", username);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@password", password);
                sqlParam3.DbType = DbType.String;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    temp = new Donor();
                    temp.ID = reader.GetInt32(0);
                    temp.Name = reader.GetString(1);
                    temp.Gender = reader.GetString(2);
                    temp.NIC = reader.GetString(3);
                    string xml1 = reader.GetString(4);
                    temp.Location = (Location)xmlToObject<Location>(xml1);
                    temp.DOB = DateTime.Parse(reader.GetString(5));
                    temp.ContactNo = reader.GetString(6);
                    temp.Email = reader.GetString(7);
                    temp.BloodType = reader.GetString(8);
                    temp.health = (HealthCondition)xmlToObject<HealthCondition>(reader.GetString(9));
                    temp.Username = reader.GetString(10);
                    temp.Password = reader.GetString(11);
                    temp.Status = reader.GetString(12);
                }
                con.Close();
            }
            catch
            {

            }
            return temp;
        }


    }
}

