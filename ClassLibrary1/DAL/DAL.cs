using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using MyComponent.Security;
using MyComponent.Entities;

namespace MyComponent.DataAccess
{
    public class DAL
    {
        #region[Connection]

        SqlConnection con = new SqlConnection(EncryptAndDecrypt.Decrypt(ConfigurationManager.ConnectionStrings["tbz"].ConnectionString, true));

        #endregion

        #region [User Methods]

        public void AddNewUser(User user)
        {
            SqlCommand cmdAddNewUser = new SqlCommand();
            cmdAddNewUser.Connection = con;
            cmdAddNewUser.CommandType = CommandType.StoredProcedure;
            cmdAddNewUser.CommandText = "AddUser";

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "P_EMAIL";
            pEmail.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pEmail);
            pEmail.Value = user.Email;
            pEmail.Direction = ParameterDirection.Input;

            SqlParameter pPassword = new SqlParameter();
            pPassword.ParameterName = "P_PASSWORD";
            pPassword.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pPassword);
            pPassword.Value = user.Password;
            pPassword.Direction = ParameterDirection.Input;


            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "P_FIRST_NAME";
            pFirstName.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pFirstName);
            pFirstName.Value = user.FirstName;
            pFirstName.Direction = ParameterDirection.Input;

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "P_LAST_NAME";
            pFirstName.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pLastName);
            pLastName.Value = user.LastName;
            pLastName.Direction = ParameterDirection.Input;

            SqlParameter pImageName = new SqlParameter();
            pImageName.ParameterName = "P_IMAGE_NAME";
            pImageName.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pImageName);
            pImageName.Value = user.ImageName;
            pImageName.Direction = ParameterDirection.Input;

            SqlParameter pCv = new SqlParameter();
            pCv.ParameterName = "P_CV";
            pCv.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pCv);
            pCv.Value = user.Cv;
            pCv.Direction = ParameterDirection.Input;


            SqlParameter pRoleId = new SqlParameter();
            pRoleId.ParameterName = "P_ROLE_ID";
            pRoleId.DbType = DbType.String;
            cmdAddNewUser.Parameters.Add(pRoleId);
            pRoleId.Value = user.RoleId;
            pRoleId.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddNewUser.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeleteNewUser(int id)
        {
            SqlCommand asdDeleteNewUser = new SqlCommand();
            asdDeleteNewUser.Connection = con;
            asdDeleteNewUser.CommandType = CommandType.StoredProcedure;
            asdDeleteNewUser.CommandText = "";


            SqlParameter pRoleId = new SqlParameter();
            pRoleId.ParameterName = "P_ROLE_ID";
            pRoleId.DbType = DbType.String;
            asdDeleteNewUser.Parameters.Add(pRoleId);
            pRoleId.Value = id;
            pRoleId.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeleteNewUser.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateNewUser(User user)
        {
            SqlCommand asdUpdateNewUser = new SqlCommand();
            asdUpdateNewUser.Connection = con;
            asdUpdateNewUser.CommandType = CommandType.StoredProcedure;
            asdUpdateNewUser.CommandText = "UpdateUser";


            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "P_USER_ID";
            pUserId.DbType = DbType.Int32;
            pUserId.Value = user.ID;
            pUserId.Direction = ParameterDirection.Input;
            asdUpdateNewUser.Parameters.Add(pUserId);


            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "P_FIRST_NAME";
            pFirstName.DbType = DbType.String;
            pFirstName.Value = user.FirstName;
            pFirstName.Direction = ParameterDirection.Input;
            asdUpdateNewUser.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "P_LAST_NAME";
            pFirstName.DbType = DbType.String;
            pLastName.Value = user.LastName;
            pLastName.Direction = ParameterDirection.Input;
            asdUpdateNewUser.Parameters.Add(pLastName);

            SqlParameter pCv = new SqlParameter();
            pCv.ParameterName = "P_CV";
            pCv.DbType = DbType.String;
            pCv.Value = user.Cv;
            pCv.Direction = ParameterDirection.Input;
            asdUpdateNewUser.Parameters.Add(pCv);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdUpdateNewUser.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public User GetUserById(int userID)
        {
            SqlCommand cmdGetUserById = new SqlCommand();
            cmdGetUserById.CommandText = "GetUserById";
            cmdGetUserById.CommandType = CommandType.StoredProcedure;
            cmdGetUserById.Connection = con;

            SqlParameter pUserId = new SqlParameter();
            pUserId.DbType = DbType.Int32;
            pUserId.ParameterName = "P_USER_ID";
            pUserId.Direction = ParameterDirection.Input;
            pUserId.Value = userID;
            cmdGetUserById.Parameters.Add(pUserId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetUserById.ExecuteReader();

            User user = null;
            while (rd.Read())
            {
                user = new User();
                user.ID = Convert.ToInt32(rd["USER_ID"]);
                user.FirstName = rd["FIRST_NAME"].ToString();
                user.Password = rd["PASSWORD"].ToString();
                user.LastName = rd["LAST_NAME"].ToString();
                user.ImageName = rd["IMAGE_NAME"].ToString();
                user.RoleId = Convert.ToInt32(rd["ROLE_ID"]);
                user.Email = rd["EMAIL"].ToString();
                user.Cv = rd["CV"].ToString();
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return user;
        }

        public DataTable GetAllUsers()
        {
            SqlCommand cmdGetAllUsers = new SqlCommand();
            cmdGetAllUsers.CommandText = "GetAllUsers";
            cmdGetAllUsers.CommandType = CommandType.StoredProcedure;
            cmdGetAllUsers.Connection = con;

            // DataSet dsUsers = new DataSet();
            DataTable dtUsers = new DataTable();
            SqlDataAdapter adUser = new SqlDataAdapter();

            adUser.SelectCommand = cmdGetAllUsers;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUser.Fill(dtUsers);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dtUsers;

        }

        public DataTable GetUsersByRoleId(int roleId)
        {
            SqlCommand cmdGetUsersByRoleId = new SqlCommand();
            cmdGetUsersByRoleId.CommandText = "GetUsersByRoleId";
            cmdGetUsersByRoleId.CommandType = CommandType.StoredProcedure;
            cmdGetUsersByRoleId.Connection = con;

            SqlParameter pRoleId = new SqlParameter();
            pRoleId.ParameterName = "@P_ROLE_ID";
            pRoleId.DbType = DbType.String;
            cmdGetUsersByRoleId.Parameters.Add(pRoleId);
            pRoleId.Value = roleId;
            pRoleId.Direction = ParameterDirection.Input;

            // DataSet dsUsers = new DataSet();
            DataTable dtUsers = new DataTable();
            SqlDataAdapter adUser = new SqlDataAdapter();

            adUser.SelectCommand = cmdGetUsersByRoleId;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUser.Fill(dtUsers);

            if (con.State == ConnectionState.Open)
                con.Close();


            return dtUsers;

        }

        public DataTable GetTopUsersByRoleId(int roleId)
        {
            SqlCommand cmdGetTopUsersByRoleId = new SqlCommand();
            cmdGetTopUsersByRoleId.CommandText = "GetTopUsersByRoleId";
            cmdGetTopUsersByRoleId.CommandType = CommandType.StoredProcedure;
            cmdGetTopUsersByRoleId.Connection = con;

            SqlParameter pRoleId = new SqlParameter();
            pRoleId.ParameterName = "@P_ROLE_ID";
            pRoleId.DbType = DbType.String;
            cmdGetTopUsersByRoleId.Parameters.Add(pRoleId);
            pRoleId.Value = roleId;
            pRoleId.Direction = ParameterDirection.Input;

            // DataSet dsUsers = new DataSet();
            DataTable dtUsers = new DataTable();
            SqlDataAdapter adUser = new SqlDataAdapter();

            adUser.SelectCommand = cmdGetTopUsersByRoleId;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUser.Fill(dtUsers);

            if (con.State == ConnectionState.Open)
                con.Close();


            return dtUsers;

        }

        public void ChangeUserPassword(int userId, string password)
        {
            SqlCommand asdChangeUserPassword = new SqlCommand();
            asdChangeUserPassword.Connection = con;
            asdChangeUserPassword.CommandType = CommandType.StoredProcedure;
            asdChangeUserPassword.CommandText = "ChangeUserPassword";


            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "P_USER_ID";
            pUserId.DbType = DbType.String;
            asdChangeUserPassword.Parameters.Add(pUserId);
            pUserId.Value = userId;
            pUserId.Direction = ParameterDirection.Input;

            SqlParameter pPassword = new SqlParameter();
            pPassword.ParameterName = "P_USER_PASSWORD";
            pPassword.DbType = DbType.String;
            asdChangeUserPassword.Parameters.Add(pPassword);
            pPassword.Value = password;
            pPassword.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdChangeUserPassword.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void ChangeUserUserName(int userId, string userName)
        {
            SqlCommand asdChangeUserPassword = new SqlCommand();
            asdChangeUserPassword.Connection = con;
            asdChangeUserPassword.CommandType = CommandType.StoredProcedure;
            asdChangeUserPassword.CommandText = "ChangeUserUserName";


            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "P_USER_ID";
            pUserId.DbType = DbType.String;
            asdChangeUserPassword.Parameters.Add(pUserId);
            pUserId.Value = userId;
            pUserId.Direction = ParameterDirection.Input;

            SqlParameter pPassword = new SqlParameter();
            pPassword.ParameterName = "P_USER_USER_NAME";
            pPassword.DbType = DbType.String;
            asdChangeUserPassword.Parameters.Add(pPassword);
            pPassword.Value = userName;
            pPassword.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdChangeUserPassword.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateUserImage(int userId, string imageName)
        {
            SqlCommand cmdUpdateUserImage = new SqlCommand();
            cmdUpdateUserImage.Connection = con;
            cmdUpdateUserImage.CommandType = CommandType.StoredProcedure;
            cmdUpdateUserImage.CommandText = "UpdateUserImage";


            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "P_USER_ID";
            pUserId.DbType = DbType.String;
            cmdUpdateUserImage.Parameters.Add(pUserId);
            pUserId.Value = userId;
            pUserId.Direction = ParameterDirection.Input;

            SqlParameter pImageName = new SqlParameter();
            pImageName.ParameterName = "P_IMAGE_NAME";
            pImageName.DbType = DbType.String;
            cmdUpdateUserImage.Parameters.Add(pImageName);
            pImageName.Value = imageName;
            pImageName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateUserImage.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void ActivateUser(int userId)
        {
            SqlCommand asdActivateNewUsers = new SqlCommand();
            asdActivateNewUsers.Connection = con;
            asdActivateNewUsers.CommandType = CommandType.StoredProcedure;
            asdActivateNewUsers.CommandText = "ActivateUser";

            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "@P_User_ID";
            pUserId.DbType = DbType.Int32;
            pUserId.Value = userId;
            pUserId.Direction = ParameterDirection.Input;
            asdActivateNewUsers.Parameters.Add(pUserId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdActivateNewUsers.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeActivateUser(int userId)
        {
            SqlCommand asdDeActivateNewUsers = new SqlCommand();
            asdDeActivateNewUsers.Connection = con;
            asdDeActivateNewUsers.CommandType = CommandType.StoredProcedure;
            asdDeActivateNewUsers.CommandText = "DeActivateUser";

            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "@P_User_ID";
            pUserId.DbType = DbType.Int32;
            pUserId.Value = userId;
            pUserId.Direction = ParameterDirection.Input;
            asdDeActivateNewUsers.Parameters.Add(pUserId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeActivateNewUsers.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        #endregion

        #region [News Methods]

        public void AddNewNews(News news)
        {
            SqlCommand cmdAddNews = new SqlCommand();
            cmdAddNews.Connection = con;
            cmdAddNews.CommandType = CommandType.StoredProcedure;
            cmdAddNews.CommandText = "AddNews";

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "P_TITLE";
            pTitle.DbType = DbType.String;
            cmdAddNews.Parameters.Add(pTitle);
            pTitle.Value = news.Title;
            pTitle.Direction = ParameterDirection.Input;

            SqlParameter pBody = new SqlParameter();
            pBody.ParameterName = "P_BODY";
            pBody.DbType = DbType.String;
            cmdAddNews.Parameters.Add(pBody);
            pBody.Value = news.Body;
            pBody.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "P_PUBLISH_DATE";
            pPublish_Date.DbType = DbType.DateTime;
            cmdAddNews.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = news.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            SqlParameter pImageName = new SqlParameter();
            pImageName.ParameterName = "P_IMAGE_NAME";
            pImageName.DbType = DbType.String;
            cmdAddNews.Parameters.Add(pImageName);
            pImageName.Value = news.ImageName;
            pImageName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddNews.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();


        }

        public void DeleteNews(int id)
        {
            SqlCommand cmdDeleteNewNews = new SqlCommand();
            cmdDeleteNewNews.Connection = con;
            cmdDeleteNewNews.CommandType = CommandType.StoredProcedure;
            cmdDeleteNewNews.CommandText = "DeleteNews";

            SqlParameter pNews_Id = new SqlParameter();
            pNews_Id.ParameterName = "P_NEWS_ID";
            pNews_Id.DbType = DbType.Int32;

            pNews_Id.Value = id;
            pNews_Id.Direction = ParameterDirection.Input;
            cmdDeleteNewNews.Parameters.Add(pNews_Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteNewNews.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void PuplishNewsOnSlider(int newsId)
        {
            SqlCommand cmdDeleteNewNews = new SqlCommand();
            cmdDeleteNewNews.Connection = con;
            cmdDeleteNewNews.CommandType = CommandType.StoredProcedure;
            cmdDeleteNewNews.CommandText = "PuplishNewsOnSlider";

            SqlParameter pNews_Id = new SqlParameter();
            pNews_Id.ParameterName = "P_NEWS_ID";
            pNews_Id.DbType = DbType.Int32;

            pNews_Id.Value = newsId;
            pNews_Id.Direction = ParameterDirection.Input;
            cmdDeleteNewNews.Parameters.Add(pNews_Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteNewNews.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UnPuplishNewsOnSlider(int newsId)
        {
            SqlCommand cmdDeleteNewNews = new SqlCommand();
            cmdDeleteNewNews.Connection = con;
            cmdDeleteNewNews.CommandType = CommandType.StoredProcedure;
            cmdDeleteNewNews.CommandText = "UnPuplishNewsOnSlider";

            SqlParameter pNews_Id = new SqlParameter();
            pNews_Id.ParameterName = "P_NEWS_ID";
            pNews_Id.DbType = DbType.Int32;

            pNews_Id.Value = newsId;
            pNews_Id.Direction = ParameterDirection.Input;
            cmdDeleteNewNews.Parameters.Add(pNews_Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteNewNews.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateNews(News news)
        {
            SqlCommand cmdUpdateNews = new SqlCommand();
            cmdUpdateNews.Connection = con;
            cmdUpdateNews.CommandType = CommandType.StoredProcedure;
            cmdUpdateNews.CommandText = "UpdateNews";


            SqlParameter pID = new SqlParameter();
            pID.ParameterName = "@P_NEWS_ID";
            pID.DbType = DbType.String;
            cmdUpdateNews.Parameters.Add(pID);
            pID.Value = news.Id;
            pID.Direction = ParameterDirection.Input;

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "P_TITLE";
            pTitle.DbType = DbType.String;
            cmdUpdateNews.Parameters.Add(pTitle);
            pTitle.Value = news.Title;
            pTitle.Direction = ParameterDirection.Input;

            SqlParameter pBody = new SqlParameter();
            pBody.ParameterName = "P_BODY";
            pBody.DbType = DbType.String;
            cmdUpdateNews.Parameters.Add(pBody);
            pBody.Value = news.Body;
            pBody.Direction = ParameterDirection.Input;


            SqlParameter pImageName = new SqlParameter();
            pImageName.ParameterName = "P_IMAGE_NAME";
            pImageName.DbType = DbType.String;
            cmdUpdateNews.Parameters.Add(pImageName);
            pImageName.Value = news.ImageName;
            pImageName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateNews.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();


        }

        public News GetNewsById(int NewsID)
        {
            SqlCommand cmdGetNewsById = new SqlCommand();
            cmdGetNewsById.CommandText = "GetNewsById";
            cmdGetNewsById.CommandType = CommandType.StoredProcedure;
            cmdGetNewsById.Connection = con;

            SqlParameter pNewsId = new SqlParameter();
            pNewsId.DbType = DbType.Int32;
            pNewsId.ParameterName = "P_NEWS_ID";
            pNewsId.Direction = ParameterDirection.Input;
            pNewsId.Value = NewsID;
            cmdGetNewsById.Parameters.Add(pNewsId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetNewsById.ExecuteReader();

            News news = null;
            while (rd.Read())
            {
                news = new News();
                news.Id = Convert.ToInt32(rd["NEWS_ID"]);
                news.Title = rd["TITLE"].ToString();
                news.Body = rd["BODY"].ToString();
                news.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                news.ImageName = rd["IMAGE_NAME"] != null ? rd["IMAGE_NAME"].ToString() : string.Empty;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return news;
        }

        public DataTable GetAllNews()
        {
            SqlCommand cmdGetAllNews = new SqlCommand();
            cmdGetAllNews.CommandText = "GetAllNews";
            cmdGetAllNews.CommandType = CommandType.StoredProcedure;
            cmdGetAllNews.Connection = con;

            DataSet dsNews = new DataSet();
            dsNews.Tables.Add(new DataTable());
            SqlDataAdapter adNews = new SqlDataAdapter();

            adNews.SelectCommand = cmdGetAllNews;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adNews.Fill(dsNews.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsNews.Tables[0];

        }

        public DataTable GetTopFourNews()
        {
            SqlCommand cmdGetTopFourNews = new SqlCommand();
            cmdGetTopFourNews.CommandText = "GetTopFourNews";
            cmdGetTopFourNews.CommandType = CommandType.StoredProcedure;
            cmdGetTopFourNews.Connection = con;

            DataSet dsNews = new DataSet();
            dsNews.Tables.Add(new DataTable());
            SqlDataAdapter adNews = new SqlDataAdapter();

            adNews.SelectCommand = cmdGetTopFourNews;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adNews.Fill(dsNews.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsNews.Tables[0];

        }


        #endregion

        #region [Content Methods]

        public void AddNewContent(Content content)
        {
            SqlCommand cmdAddNewContent = new SqlCommand();
            cmdAddNewContent.Connection = con;
            cmdAddNewContent.CommandType = CommandType.StoredProcedure;
            cmdAddNewContent.CommandText = "AddContent";

            SqlParameter pFile_Name = new SqlParameter();
            pFile_Name.ParameterName = "P_File_Name";
            pFile_Name.DbType = DbType.String;
            cmdAddNewContent.Parameters.Add(pFile_Name);
            pFile_Name.Value = content.FileName;
            pFile_Name.Direction = ParameterDirection.Input;

            SqlParameter pAcademic_Type = new SqlParameter();
            pAcademic_Type.ParameterName = "P_Academic_Type";
            pAcademic_Type.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pAcademic_Type);
            pAcademic_Type.Value = content.SpecialtyId;
            pAcademic_Type.Direction = ParameterDirection.Input;

            SqlParameter pAcademic_Year = new SqlParameter();
            pAcademic_Year.ParameterName = "P_Academic_Year";
            pAcademic_Year.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pAcademic_Year);
            pAcademic_Year.Value = content.AcademicYear;
            pAcademic_Year.Direction = ParameterDirection.Input;

            SqlParameter pFile_Name_Path = new SqlParameter();
            pFile_Name_Path.ParameterName = "P_FILE_NAME_PATH";
            pFile_Name_Path.DbType = DbType.String;
            cmdAddNewContent.Parameters.Add(pFile_Name_Path);
            pFile_Name_Path.Value = content.FileNamePath;
            pFile_Name_Path.Direction = ParameterDirection.Input;

            SqlParameter pWriter_Id = new SqlParameter();
            pWriter_Id.ParameterName = "P_Writer_Id";
            pWriter_Id.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pWriter_Id);
            pWriter_Id.Value = content.WriterId;
            pWriter_Id.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "P_Publish_Date";
            pPublish_Date.DbType = DbType.DateTime;
            cmdAddNewContent.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = content.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            SqlParameter pSemester = new SqlParameter();
            pSemester.ParameterName = "P_Semester";
            pSemester.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pSemester);
            pSemester.Value = content.Semester;
            pSemester.Direction = ParameterDirection.Input;

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@P_COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pCourseId);
            pCourseId.Value = content.CourseId;
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@P_LEVEL_ID";
            pLevelId.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pLevelId);
            pLevelId.Value = content.LevelId;
            pLevelId.Direction = ParameterDirection.Input;

            SqlParameter pType = new SqlParameter();
            pType.ParameterName = "P_TYPE";
            pType.DbType = DbType.Int32;
            cmdAddNewContent.Parameters.Add(pType);
            pType.Value = content.Type;
            pType.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddNewContent.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DeleteContent(int id)
        {
            SqlCommand asdDeleteNewContent = new SqlCommand();
            asdDeleteNewContent.Connection = con;
            asdDeleteNewContent.CommandType = CommandType.StoredProcedure;
            asdDeleteNewContent.CommandText = "DeleteContent";

            SqlParameter pContent_Id = new SqlParameter();
            pContent_Id.ParameterName = "P_CONTENT_ID";
            pContent_Id.DbType = DbType.Int32;
            asdDeleteNewContent.Parameters.Add(pContent_Id);
            pContent_Id.Value = id;
            pContent_Id.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeleteNewContent.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateContent(Content content)
        {
            SqlCommand asdUpdateNewContent = new SqlCommand();
            asdUpdateNewContent.Connection = con;
            asdUpdateNewContent.CommandType = CommandType.StoredProcedure;
            asdUpdateNewContent.CommandText = "UpdateContent";

            SqlParameter pFile_Name = new SqlParameter();
            pFile_Name.ParameterName = "P_File_Name";
            pFile_Name.DbType = DbType.String;
            asdUpdateNewContent.Parameters.Add(pFile_Name);
            pFile_Name.Value = content.FileName;
            pFile_Name.Direction = ParameterDirection.Input;

            SqlParameter pAcademic_Type = new SqlParameter();
            pAcademic_Type.ParameterName = "P_Academic_Type";
            pAcademic_Type.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pAcademic_Type);
            pAcademic_Type.Value = content.SpecialtyId;
            pAcademic_Type.Direction = ParameterDirection.Input;

            SqlParameter pAcademic_Year = new SqlParameter();
            pAcademic_Year.ParameterName = "P_Academic_Year";
            pAcademic_Year.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pAcademic_Year);
            pAcademic_Year.Value = content.AcademicYear;
            pAcademic_Year.Direction = ParameterDirection.Input;

            SqlParameter pFile_Name_Path = new SqlParameter();
            pFile_Name_Path.ParameterName = "P_File_Name_Path";
            pFile_Name_Path.DbType = DbType.String;
            asdUpdateNewContent.Parameters.Add(pFile_Name_Path);
            pFile_Name_Path.Value = content.FileNamePath;
            pFile_Name_Path.Direction = ParameterDirection.Input;

            SqlParameter pWriter_Id = new SqlParameter();
            pWriter_Id.ParameterName = "P_Writer_Id";
            pWriter_Id.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pWriter_Id);
            pWriter_Id.Value = content.WriterId;
            pWriter_Id.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "P_Publish_Date";
            pPublish_Date.DbType = DbType.DateTime;
            asdUpdateNewContent.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = content.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            SqlParameter pSemester = new SqlParameter();
            pSemester.ParameterName = "P_Semester";
            pSemester.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pSemester);
            pSemester.Value = content.Semester;
            pSemester.Direction = ParameterDirection.Input;

            SqlParameter pType = new SqlParameter();
            pType.ParameterName = "P_TYPE";
            pType.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pType);
            pType.Value = content.Type;
            pType.Direction = ParameterDirection.Input;

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@P_COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pCourseId);
            pCourseId.Value = content.CourseId;
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@P_LEVEL_ID";
            pLevelId.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pLevelId);
            pLevelId.Value = content.LevelId;
            pLevelId.Direction = ParameterDirection.Input;

            SqlParameter pContentId = new SqlParameter();
            pContentId.ParameterName = "@P_CONTENT_ID";
            pContentId.DbType = DbType.Int32;
            asdUpdateNewContent.Parameters.Add(pContentId);
            pContentId.Value = content.Id;
            pContentId.Direction = ParameterDirection.Input;



            if (con.State == ConnectionState.Closed)
                con.Open();

            asdUpdateNewContent.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void IncreaseContentDownLoadCount(int contentId)
        {
            SqlCommand cmdIncreaseContentDownloadCount = new SqlCommand();
            cmdIncreaseContentDownloadCount.Connection = con;
            cmdIncreaseContentDownloadCount.CommandType = CommandType.StoredProcedure;
            cmdIncreaseContentDownloadCount.CommandText = "IncreaseContentDownloadCount";

            SqlParameter pDownloadCount = new SqlParameter();
            pDownloadCount.ParameterName = "@P_CONTENT_ID";
            pDownloadCount.DbType = DbType.Int32;
            cmdIncreaseContentDownloadCount.Parameters.Add(pDownloadCount);
            pDownloadCount.Value = contentId;
            pDownloadCount.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdIncreaseContentDownloadCount.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }


        public Content GetContentById(int ContentID)
        {
            SqlCommand cmdGetContentById = new SqlCommand();
            cmdGetContentById.CommandText = "GetContentById";
            cmdGetContentById.CommandType = CommandType.StoredProcedure;
            cmdGetContentById.Connection = con;

            SqlParameter pContentId = new SqlParameter();
            pContentId.DbType = DbType.Int32;
            pContentId.ParameterName = "P_CONTENT_ID";
            pContentId.Direction = ParameterDirection.Input;
            pContentId.Value = ContentID;
            cmdGetContentById.Parameters.Add(pContentId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetContentById.ExecuteReader();

            Content content = null;
            while (rd.Read())
            {
                content = new Content();
                content.Id = Convert.ToInt32(rd["CONTENT_ID"]);
                content.FileName = rd["FILE_NAME"].ToString();
                content.SpecialtyId = Convert.ToInt32(rd["ACADEMIC_TYPE"]);
                content.AcademicYear = rd["ACADEMIC_YEAR"].ToString();
                content.FileNamePath = rd["FILE_NAME_PATH"].ToString();
                content.WriterId = Convert.ToInt32(rd["WRITER_ID"]);
                content.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                content.DownloadCount = rd["DOWNLOAD_COUNT"] != null ? Convert.ToInt32(rd["WRITER_ID"]) : 0;


            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return content;
        }

        public DataTable GetAllContent()
        {
            SqlCommand cmdGetAllContent = new SqlCommand();
            cmdGetAllContent.CommandText = "GetAllContents";
            cmdGetAllContent.CommandType = CommandType.StoredProcedure;
            cmdGetAllContent.Connection = con;

            DataSet dsContent = new DataSet();
            dsContent.Tables.Add(new DataTable());
            SqlDataAdapter adContents = new SqlDataAdapter();

            adContents.SelectCommand = cmdGetAllContent;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adContents.Fill(dsContent.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsContent.Tables[0];

        }

        public DataTable GetTopTenContents()
        {
            SqlCommand cmdGetTopTenContents = new SqlCommand();
            cmdGetTopTenContents.CommandText = "GetTopTenContents";
            cmdGetTopTenContents.CommandType = CommandType.StoredProcedure;
            cmdGetTopTenContents.Connection = con;

            DataSet dsContent = new DataSet();
            dsContent.Tables.Add(new DataTable());
            SqlDataAdapter adContents = new SqlDataAdapter();

            adContents.SelectCommand = cmdGetTopTenContents;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adContents.Fill(dsContent.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsContent.Tables[0];

        }

        public DataTable SearchContents(int academicYear, int specialty, int semester, string fileName, int type, int courseId, int courseLevelId, int teacherId)
        {
            SqlCommand cmdSearchContent = new SqlCommand();
            cmdSearchContent.CommandText = "SearchContents";
            cmdSearchContent.CommandType = CommandType.StoredProcedure;
            cmdSearchContent.Connection = con;

            SqlParameter P_ACADEMIC_TYPE = new SqlParameter();
            P_ACADEMIC_TYPE.ParameterName = "P_ACADEMIC_TYPE";
            P_ACADEMIC_TYPE.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_ACADEMIC_TYPE);
            P_ACADEMIC_TYPE.Value = specialty;
            P_ACADEMIC_TYPE.Direction = ParameterDirection.Input;

            SqlParameter P_ACADEMIC_YEAR = new SqlParameter();
            P_ACADEMIC_YEAR.ParameterName = "P_ACADEMIC_YEAR";
            P_ACADEMIC_YEAR.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_ACADEMIC_YEAR);
            P_ACADEMIC_YEAR.Value = academicYear;
            P_ACADEMIC_YEAR.Direction = ParameterDirection.Input;

            SqlParameter P_SEMESTER = new SqlParameter();
            P_SEMESTER.ParameterName = "P_SEMESTER";
            P_SEMESTER.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_SEMESTER);
            P_SEMESTER.Value = semester;
            P_SEMESTER.Direction = ParameterDirection.Input;

            SqlParameter P_FILE_NAME = new SqlParameter();
            P_FILE_NAME.ParameterName = "P_FILE_NAME";
            P_FILE_NAME.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_FILE_NAME);
            P_FILE_NAME.Value = fileName;
            P_FILE_NAME.Direction = ParameterDirection.Input;

            SqlParameter pType = new SqlParameter();
            pType.ParameterName = "P_TYPE";
            pType.DbType = DbType.Int32;
            cmdSearchContent.Parameters.Add(pType);
            pType.Value = type;
            pType.Direction = ParameterDirection.Input;

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@P_COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            cmdSearchContent.Parameters.Add(pCourseId);
            pCourseId.Value = courseId;
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@P_LEVEL_ID";
            pLevelId.DbType = DbType.Int32;
            cmdSearchContent.Parameters.Add(pLevelId);
            pLevelId.Value = courseLevelId;
            pLevelId.Direction = ParameterDirection.Input;

            SqlParameter P_WRITER_ID = new SqlParameter();
            P_WRITER_ID.ParameterName = "P_WRITER_ID";
            P_WRITER_ID.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_WRITER_ID);
            P_WRITER_ID.Value = teacherId;
            P_WRITER_ID.Direction = ParameterDirection.Input;

            DataSet dsContent = new DataSet();
            dsContent.Tables.Add(new DataTable());

            SqlDataAdapter adContents = new SqlDataAdapter();

            adContents.SelectCommand = cmdSearchContent;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adContents.Fill(dsContent.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsContent.Tables[0];

        }

        public DataTable SearchContents(int teacherId, string fileName, int type)
        {
            SqlCommand cmdSearchContent = new SqlCommand();
            cmdSearchContent.CommandText = "SearchContents2";
            cmdSearchContent.CommandType = CommandType.StoredProcedure;
            cmdSearchContent.Connection = con;


            SqlParameter P_WRITER_ID = new SqlParameter();
            P_WRITER_ID.ParameterName = "P_WRITER_ID";
            P_WRITER_ID.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_WRITER_ID);
            P_WRITER_ID.Value = teacherId;
            P_WRITER_ID.Direction = ParameterDirection.Input;

            SqlParameter P_FILE_NAME = new SqlParameter();
            P_FILE_NAME.ParameterName = "P_FILE_NAME";
            P_FILE_NAME.DbType = DbType.String;
            cmdSearchContent.Parameters.Add(P_FILE_NAME);
            P_FILE_NAME.Value = fileName;
            P_FILE_NAME.Direction = ParameterDirection.Input;


            SqlParameter pType = new SqlParameter();
            pType.ParameterName = "P_TYPE";
            pType.DbType = DbType.Int32;
            cmdSearchContent.Parameters.Add(pType);
            pType.Value = type;
            pType.Direction = ParameterDirection.Input;

            DataSet dsContent = new DataSet();
            dsContent.Tables.Add(new DataTable());

            SqlDataAdapter adContents = new SqlDataAdapter();

            adContents.SelectCommand = cmdSearchContent;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adContents.Fill(dsContent.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsContent.Tables[0];

        }

        public DataTable GetContentByWriterId(int writerId)
        {
            SqlCommand cmdGetContentById = new SqlCommand();
            cmdGetContentById.CommandText = "GetContentByWriterId";
            cmdGetContentById.CommandType = CommandType.StoredProcedure;
            cmdGetContentById.Connection = con;

            SqlParameter pWriterId = new SqlParameter();
            pWriterId.DbType = DbType.Int32;
            pWriterId.ParameterName = "P_WRITER_ID";
            pWriterId.Direction = ParameterDirection.Input;
            pWriterId.Value = writerId;
            cmdGetContentById.Parameters.Add(pWriterId);

            DataSet dsContent = new DataSet();
            dsContent.Tables.Add(new DataTable());

            SqlDataAdapter adContents = new SqlDataAdapter();

            adContents.SelectCommand = cmdGetContentById;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adContents.Fill(dsContent.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsContent.Tables[0];
        }


        #endregion

        #region [Comments Methods]

        public void AddComment(Comment Comment)
        {
            SqlCommand cmdAddNewComments = new SqlCommand();
            cmdAddNewComments.Connection = con;
            cmdAddNewComments.CommandType = CommandType.StoredProcedure;
            cmdAddNewComments.CommandText = "AddComment";

            SqlParameter pComment_Body = new SqlParameter();
            pComment_Body.ParameterName = "P_COMMENT_BODY";
            pComment_Body.Direction = ParameterDirection.Input;
            pComment_Body.DbType = DbType.String;
            pComment_Body.Value = Comment.CommentBody;
            cmdAddNewComments.Parameters.Add(pComment_Body);

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "P_PUBLISH_DATE";
            pPublish_Date.DbType = DbType.DateTime;
            pPublish_Date.Value = Comment.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pPublish_Date);

            SqlParameter pTeacherId = new SqlParameter();
            pTeacherId.ParameterName = "P_REF_TEACHER_ID";
            pTeacherId.DbType = DbType.Int32;
            pTeacherId.Value = Comment.TeacherId;
            pTeacherId.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pTeacherId);

            SqlParameter pWriterName = new SqlParameter();
            pWriterName.ParameterName = "@P_WRITER_NAME";
            pWriterName.DbType = DbType.String;
            pWriterName.Value = Comment.WriterName;
            pWriterName.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pWriterName);

            SqlParameter pContentId = new SqlParameter();
            pContentId.ParameterName = "@P_REF_CONTENT_ID";
            pContentId.DbType = DbType.Int32;
            pContentId.Value = Comment.ContentId;
            pContentId.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pContentId);

            SqlParameter pNewsId = new SqlParameter();
            pNewsId.ParameterName = "@P_REF_NEWS_ID";
            pNewsId.DbType = DbType.Int32;
            pNewsId.Value = Comment.NewsId;
            pNewsId.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pNewsId);

            SqlParameter pArticleId = new SqlParameter();
            pArticleId.ParameterName = "@P_REF_ARTICLE_ID";
            pArticleId.DbType = DbType.Int32;
            pArticleId.Value = Comment.ArticleId;
            pArticleId.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pArticleId);

            SqlParameter pArticleWriterId = new SqlParameter();
            pArticleWriterId.ParameterName = "@P_REF_ARTICLE_WRITER_ID";
            pArticleWriterId.DbType = DbType.Int32;
            pArticleWriterId.Value = Comment.ArticleWriterId;
            pArticleWriterId.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pArticleWriterId);

            SqlParameter pUsefulInfoId = new SqlParameter();
            pUsefulInfoId.ParameterName = "@P_USEFUL_INFO_ID";
            pUsefulInfoId.DbType = DbType.Int32;
            pUsefulInfoId.Value = Comment.UsefulInfoId;
            pUsefulInfoId.Direction = ParameterDirection.Input;
            cmdAddNewComments.Parameters.Add(pUsefulInfoId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddNewComments.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeleteComment(int commentId)
        {
            SqlCommand asdDeleteNewComments = new SqlCommand();
            asdDeleteNewComments.Connection = con;
            asdDeleteNewComments.CommandType = CommandType.StoredProcedure;
            asdDeleteNewComments.CommandText = "DeleteComment";

            SqlParameter pContent_Id = new SqlParameter();
            pContent_Id.ParameterName = "P_COMMENT_ID";
            pContent_Id.DbType = DbType.Int32;
            asdDeleteNewComments.Parameters.Add(pContent_Id);
            pContent_Id.Value = commentId;
            pContent_Id.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeleteNewComments.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public DataTable GetAllComments()
        {
            SqlCommand cmdGetAllComment = new SqlCommand();
            cmdGetAllComment.CommandText = "GetAllComments";
            cmdGetAllComment.CommandType = CommandType.StoredProcedure;
            cmdGetAllComment.Connection = con;

            DataSet dsComments = new DataSet();
            dsComments.Tables.Add(new DataTable());
            SqlDataAdapter adComment = new SqlDataAdapter();

            adComment.SelectCommand = cmdGetAllComment;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adComment.Fill(dsComments.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsComments.Tables[0];

        }

        public List<Comment> GetCommentByTeacherId(int teacherId)
        {
            SqlCommand cmdGetCommentByContentId = new SqlCommand();
            cmdGetCommentByContentId.CommandText = "dbo.GetCommentsByTeacherId";
            cmdGetCommentByContentId.CommandType = CommandType.StoredProcedure;
            cmdGetCommentByContentId.Connection = con;

            SqlParameter pTeacherId = new SqlParameter();
            pTeacherId.DbType = DbType.Int32;
            pTeacherId.ParameterName = "P_REF_TEACHER_ID";
            pTeacherId.Direction = ParameterDirection.Input;
            pTeacherId.Value = teacherId;
            cmdGetCommentByContentId.Parameters.Add(pTeacherId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCommentByContentId.ExecuteReader();

            List<Comment> teacherComments = null;
            Comment comment = null;
            while (rd.Read())
            {
                if (teacherComments == null)
                    teacherComments = new List<Comment>();

                comment = new Comment();
                comment.ID = Convert.ToInt32(rd["COMMENT_ID"]);
                comment.CommentBody = rd["COMMENT_BODY"].ToString();
                comment.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                comment.WriterName = rd["WRITER_NAME"].ToString();
                comment.TeacherId = Convert.ToInt32(rd["REF_TEACHER_ID"]);
                comment.IsActive = Convert.ToBoolean(rd["IS_ACTIVE"]);

                teacherComments.Add(comment);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return teacherComments;
        }

        public List<Comment> GetCommentsByContentId(int contentId)
        {
            SqlCommand cmdGetCommentByContentId = new SqlCommand();
            cmdGetCommentByContentId.CommandText = "GetCommentsByContentId";
            cmdGetCommentByContentId.CommandType = CommandType.StoredProcedure;
            cmdGetCommentByContentId.Connection = con;

            SqlParameter pContentId = new SqlParameter();
            pContentId.DbType = DbType.Int32;
            pContentId.ParameterName = "P_REF_CONTENT_ID";
            pContentId.Direction = ParameterDirection.Input;
            pContentId.Value = contentId;
            cmdGetCommentByContentId.Parameters.Add(pContentId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCommentByContentId.ExecuteReader();

            List<Comment> ContentComments = null;
            Comment comment = null;
            while (rd.Read())
            {
                if (ContentComments == null)
                    ContentComments = new List<Comment>();

                comment = new Comment();
                comment.ID = Convert.ToInt32(rd["COMMENT_ID"]);
                comment.CommentBody = rd["COMMENT_BODY"].ToString();
                comment.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                comment.WriterName = rd["WRITER_NAME"].ToString();
                comment.ContentId = rd["REF_Content_ID"] != null ? Convert.ToInt32(rd["REF_Content_ID"]) : -1;
                comment.IsActive = Convert.ToBoolean(rd["IS_ACTIVE"]);

                ContentComments.Add(comment);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return ContentComments;
        }

        public List<Comment> GetCommentsByNewsId(int newsId)
        {
            SqlCommand cmdGetCommentByNewsId = new SqlCommand();
            cmdGetCommentByNewsId.CommandText = "GetCommentsByNewsId";
            cmdGetCommentByNewsId.CommandType = CommandType.StoredProcedure;
            cmdGetCommentByNewsId.Connection = con;

            SqlParameter pNewsId = new SqlParameter();
            pNewsId.DbType = DbType.Int32;
            pNewsId.ParameterName = "@P_REF_NEWS_ID";
            pNewsId.Direction = ParameterDirection.Input;
            pNewsId.Value = newsId;
            cmdGetCommentByNewsId.Parameters.Add(pNewsId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCommentByNewsId.ExecuteReader();

            List<Comment> NewsComments = null;
            Comment comment = null;
            while (rd.Read())
            {
                if (NewsComments == null)
                    NewsComments = new List<Comment>();

                comment = new Comment();
                comment.ID = Convert.ToInt32(rd["COMMENT_ID"]);
                comment.CommentBody = rd["COMMENT_BODY"].ToString();
                comment.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                comment.WriterName = rd["WRITER_NAME"].ToString();
                comment.NewsId = rd["REF_NEWS_ID"] != null ? Convert.ToInt32(rd["REF_NEWS_ID"]) : -1;
                comment.IsActive = Convert.ToBoolean(rd["IS_ACTIVE"]);

                NewsComments.Add(comment);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return NewsComments;
        }

        public List<Comment> GetCommentsByArticleId(int articleId)
        {
            SqlCommand cmdGetCommentByArticleId = new SqlCommand();
            cmdGetCommentByArticleId.CommandText = "GetCommentsByArticleId";
            cmdGetCommentByArticleId.CommandType = CommandType.StoredProcedure;
            cmdGetCommentByArticleId.Connection = con;

            SqlParameter pArticleId = new SqlParameter();
            pArticleId.DbType = DbType.Int32;
            pArticleId.ParameterName = "@P_REF_Article_ID";
            pArticleId.Direction = ParameterDirection.Input;
            pArticleId.Value = articleId;
            cmdGetCommentByArticleId.Parameters.Add(pArticleId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCommentByArticleId.ExecuteReader();

            List<Comment> ArticleComments = null;
            Comment comment = null;
            while (rd.Read())
            {
                if (ArticleComments == null)
                    ArticleComments = new List<Comment>();

                comment = new Comment();
                comment.ID = Convert.ToInt32(rd["COMMENT_ID"]);
                comment.CommentBody = rd["COMMENT_BODY"].ToString();
                comment.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                comment.WriterName = rd["WRITER_NAME"].ToString();
                comment.ArticleId = rd["REF_Article_ID"] != null ? Convert.ToInt32(rd["REF_Article_ID"]) : -1;
                comment.IsActive = Convert.ToBoolean(rd["IS_ACTIVE"]);

                ArticleComments.Add(comment);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return ArticleComments;
        }

        public List<Comment> GetCommentsByArticleWriterId(int articleWriterId)
        {
            SqlCommand cmdGetCommentByArticleWriterId = new SqlCommand();
            cmdGetCommentByArticleWriterId.CommandText = "GetCommentsByArticleWriterId";
            cmdGetCommentByArticleWriterId.CommandType = CommandType.StoredProcedure;
            cmdGetCommentByArticleWriterId.Connection = con;

            SqlParameter pArticleId = new SqlParameter();
            pArticleId.DbType = DbType.Int32;
            pArticleId.ParameterName = "@P_REF_ARTICLE_WRITER_ID";
            pArticleId.Direction = ParameterDirection.Input;
            pArticleId.Value = articleWriterId;
            cmdGetCommentByArticleWriterId.Parameters.Add(pArticleId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCommentByArticleWriterId.ExecuteReader();

            List<Comment> ArticleComments = null;
            Comment comment = null;
            while (rd.Read())
            {
                if (ArticleComments == null)
                    ArticleComments = new List<Comment>();

                comment = new Comment();
                comment.ID = Convert.ToInt32(rd["COMMENT_ID"]);
                comment.CommentBody = rd["COMMENT_BODY"].ToString();
                comment.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                comment.WriterName = rd["WRITER_NAME"].ToString();
                comment.ArticleWriterId = rd["REF_ARTICLE_WRITER_ID"] != null ? Convert.ToInt32(rd["REF_ARTICLE_WRITER_ID"]) : -1;
                comment.IsActive = Convert.ToBoolean(rd["IS_ACTIVE"]);

                ArticleComments.Add(comment);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return ArticleComments;
        }

        public List<Comment> GetCommentsByUsefulInfoId(int UsefulInfoId)
        {
            SqlCommand cmdGetCommentByUsefulInfoId = new SqlCommand();
            cmdGetCommentByUsefulInfoId.CommandText = "GetCommentsByUsefulInfoId";
            cmdGetCommentByUsefulInfoId.CommandType = CommandType.StoredProcedure;
            cmdGetCommentByUsefulInfoId.Connection = con;

            SqlParameter pUsefulInfoId = new SqlParameter();
            pUsefulInfoId.DbType = DbType.Int32;
            pUsefulInfoId.ParameterName = "@P_REF_USEFUL_INFO_ID";
            pUsefulInfoId.Direction = ParameterDirection.Input;
            pUsefulInfoId.Value = UsefulInfoId;
            cmdGetCommentByUsefulInfoId.Parameters.Add(pUsefulInfoId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCommentByUsefulInfoId.ExecuteReader();

            List<Comment> UsefulInfoComments = null;
            Comment comment = null;
            while (rd.Read())
            {
                if (UsefulInfoComments == null)
                    UsefulInfoComments = new List<Comment>();

                comment = new Comment();
                comment.ID = Convert.ToInt32(rd["COMMENT_ID"]);
                comment.CommentBody = rd["COMMENT_BODY"].ToString();
                comment.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                comment.WriterName = rd["WRITER_NAME"].ToString();
                comment.UsefulInfoId = rd["REF_Useful_Info_ID"] != null ? Convert.ToInt32(rd["REF_Useful_Info_ID"]) : -1;
                comment.IsActive = Convert.ToBoolean(rd["IS_ACTIVE"]);

                UsefulInfoComments.Add(comment);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return UsefulInfoComments;
        }

        public void ActivateComment(int commentId)
        {
            SqlCommand asdActivateNewComments = new SqlCommand();
            asdActivateNewComments.Connection = con;
            asdActivateNewComments.CommandType = CommandType.StoredProcedure;
            asdActivateNewComments.CommandText = "ActivateComment";

            SqlParameter pCommentId = new SqlParameter();
            pCommentId.ParameterName = "P_COMMENT_ID";
            pCommentId.DbType = DbType.Int32;
            pCommentId.Value = commentId;
            pCommentId.Direction = ParameterDirection.Input;
            asdActivateNewComments.Parameters.Add(pCommentId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdActivateNewComments.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeActivateComment(int commentId)
        {
            SqlCommand asdDeActivateNewComments = new SqlCommand();
            asdDeActivateNewComments.Connection = con;
            asdDeActivateNewComments.CommandType = CommandType.StoredProcedure;
            asdDeActivateNewComments.CommandText = "DeActivateComment";

            SqlParameter pCommentId = new SqlParameter();
            pCommentId.ParameterName = "P_COMMENT_ID";
            pCommentId.DbType = DbType.Int32;
            pCommentId.Value = commentId;
            pCommentId.Direction = ParameterDirection.Input;
            asdDeActivateNewComments.Parameters.Add(pCommentId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeActivateNewComments.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        #endregion

        #region [Banners Methods]

        public void AddBanner(Banner Banner)
        {
            SqlCommand cmdAddNewBanners = new SqlCommand();
            cmdAddNewBanners.Connection = con;
            cmdAddNewBanners.CommandType = CommandType.StoredProcedure;
            cmdAddNewBanners.CommandText = "usp_InsertBANNER";

            SqlParameter pBannerTitle = new SqlParameter();
            pBannerTitle.ParameterName = "BANNER_TITLE";
            pBannerTitle.Direction = ParameterDirection.Input;
            pBannerTitle.DbType = DbType.String;
            pBannerTitle.Value = Banner.Title;
            cmdAddNewBanners.Parameters.Add(pBannerTitle);

            SqlParameter pBannerRedirectUrl = new SqlParameter();
            pBannerRedirectUrl.ParameterName = "BANNER_REDIRECT_URL";
            pBannerRedirectUrl.Direction = ParameterDirection.Input;
            pBannerRedirectUrl.DbType = DbType.String;
            pBannerRedirectUrl.Value = Banner.RedirectUrl;
            cmdAddNewBanners.Parameters.Add(pBannerRedirectUrl);


            SqlParameter pBannerImageName = new SqlParameter();
            pBannerImageName.ParameterName = "BANNER_IMAGE_NAME";
            pBannerImageName.Direction = ParameterDirection.Input;
            pBannerImageName.DbType = DbType.String;
            pBannerImageName.Value = Banner.ImageName;
            cmdAddNewBanners.Parameters.Add(pBannerImageName);

            SqlParameter pBannerIsActive = new SqlParameter();
            pBannerIsActive.ParameterName = "BANNER_IS_ACTIVE";
            pBannerIsActive.Direction = ParameterDirection.Input;
            pBannerIsActive.DbType = DbType.Int32;
            pBannerIsActive.Value = Banner.IsActive;
            cmdAddNewBanners.Parameters.Add(pBannerIsActive);

            SqlParameter pBannerPosition = new SqlParameter();
            pBannerPosition.ParameterName = "BANNER_POSITION";
            pBannerPosition.Direction = ParameterDirection.Input;
            pBannerPosition.DbType = DbType.Int32;
            pBannerPosition.Value = Banner.Position;
            cmdAddNewBanners.Parameters.Add(pBannerPosition);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddNewBanners.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateBanner(Banner Banner)
        {
            SqlCommand cmdUpdateBanners = new SqlCommand();
            cmdUpdateBanners.Connection = con;
            cmdUpdateBanners.CommandType = CommandType.StoredProcedure;
            cmdUpdateBanners.CommandText = "usp_UpdateBANNER";

            SqlParameter pBannerId = new SqlParameter();
            pBannerId.ParameterName = "BANNER_ID";
            pBannerId.Direction = ParameterDirection.Input;
            pBannerId.DbType = DbType.Int32;
            pBannerId.Value = Banner.Title;
            cmdUpdateBanners.Parameters.Add(pBannerId);

            SqlParameter pBannerTitle = new SqlParameter();
            pBannerTitle.ParameterName = "BANNER_TITLE";
            pBannerTitle.Direction = ParameterDirection.Input;
            pBannerTitle.DbType = DbType.String;
            pBannerTitle.Value = Banner.Title;
            cmdUpdateBanners.Parameters.Add(pBannerTitle);

            SqlParameter pBannerRedirectUrl = new SqlParameter();
            pBannerRedirectUrl.ParameterName = "BANNER_REDIRECT_URL";
            pBannerRedirectUrl.Direction = ParameterDirection.Input;
            pBannerRedirectUrl.DbType = DbType.String;
            pBannerRedirectUrl.Value = Banner.RedirectUrl;
            cmdUpdateBanners.Parameters.Add(pBannerRedirectUrl);


            SqlParameter pBannerImageName = new SqlParameter();
            pBannerImageName.ParameterName = "BANNER_IMAGE_NAME";
            pBannerImageName.Direction = ParameterDirection.Input;
            pBannerImageName.DbType = DbType.String;
            pBannerImageName.Value = Banner.ImageName;
            cmdUpdateBanners.Parameters.Add(pBannerImageName);

            SqlParameter pBannerIsActive = new SqlParameter();
            pBannerIsActive.ParameterName = "BANNER_IS_ACTIVE";
            pBannerIsActive.Direction = ParameterDirection.Input;
            pBannerIsActive.DbType = DbType.Int32;
            pBannerIsActive.Value = Banner.IsActive;
            cmdUpdateBanners.Parameters.Add(pBannerIsActive);

            SqlParameter pBannerPosition = new SqlParameter();
            pBannerPosition.ParameterName = "BANNER_POSITION";
            pBannerPosition.Direction = ParameterDirection.Input;
            pBannerPosition.DbType = DbType.Int32;
            pBannerPosition.Value = Banner.Position;
            cmdUpdateBanners.Parameters.Add(pBannerPosition);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateBanners.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public DataTable GetAllBanners()
        {
            SqlCommand cmdGetAllBanner = new SqlCommand();
            cmdGetAllBanner.CommandText = "usp_SelectBANNERsAll";
            cmdGetAllBanner.CommandType = CommandType.StoredProcedure;
            cmdGetAllBanner.Connection = con;

            DataSet dsBanners = new DataSet();
            dsBanners.Tables.Add(new DataTable());
            SqlDataAdapter adBanner = new SqlDataAdapter();

            adBanner.SelectCommand = cmdGetAllBanner;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adBanner.Fill(dsBanners.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsBanners.Tables[0];

        }

        public Banner GetActiveRightBanner()
        {
            SqlCommand cmdGetActiveRightBanner = new SqlCommand();
            cmdGetActiveRightBanner.CommandText = "GetActiveRightBanner";
            cmdGetActiveRightBanner.CommandType = CommandType.StoredProcedure;
            cmdGetActiveRightBanner.Connection = con;

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetActiveRightBanner.ExecuteReader();

            Banner banner = null;
            while (rd.Read())
            {
                banner = new Banner();

                banner.Title = rd["BANNER_TITLE"].ToString();
                banner.RedirectUrl = rd["BANNER_REDIRECT_URL"].ToString();
                banner.ImageName = rd["BANNER_IMAGE_NAME"].ToString();
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return banner;
        }

        public Banner GetActiveCenterBanner()
        {
            SqlCommand cmdGetActiveRightBanner = new SqlCommand();
            cmdGetActiveRightBanner.CommandText = "GetActiveCenterBanner";
            cmdGetActiveRightBanner.CommandType = CommandType.StoredProcedure;
            cmdGetActiveRightBanner.Connection = con;

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetActiveRightBanner.ExecuteReader();

            Banner banner = null;
            while (rd.Read())
            {
                banner = new Banner();

                banner.Title = rd["BANNER_TITLE"].ToString();
                banner.RedirectUrl = rd["BANNER_REDIRECT_URL"].ToString();
                banner.ImageName = rd["BANNER_IMAGE_NAME"].ToString();
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return banner;
        }

        public Banner GetActiveLeftBanner()
        {
            SqlCommand cmdGetActiveRightBanner = new SqlCommand();
            cmdGetActiveRightBanner.CommandText = "GetActiveLeftBanner";
            cmdGetActiveRightBanner.CommandType = CommandType.StoredProcedure;
            cmdGetActiveRightBanner.Connection = con;

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetActiveRightBanner.ExecuteReader();

            Banner banner = null;
            while (rd.Read())
            {
                banner = new Banner();

                banner.Title = rd["BANNER_TITLE"].ToString();
                banner.RedirectUrl = rd["BANNER_REDIRECT_URL"].ToString();
                banner.ImageName = rd["BANNER_IMAGE_NAME"].ToString();
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return banner;
        }

        public Banner GetActiveBannerByPositionId(int positionId)
        {
            SqlCommand cmdGetActiveBannerByPositionId = new SqlCommand();
            cmdGetActiveBannerByPositionId.CommandText = "GetActiveBannerByPositionId";
            cmdGetActiveBannerByPositionId.CommandType = CommandType.StoredProcedure;
            cmdGetActiveBannerByPositionId.Connection = con;

            SqlParameter pPositionId = new SqlParameter();
            pPositionId.ParameterName = "@P_POSITION_ID";
            pPositionId.Direction = ParameterDirection.Input;
            pPositionId.DbType = DbType.Int32;
            pPositionId.Value = positionId;
            cmdGetActiveBannerByPositionId.Parameters.Add(pPositionId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetActiveBannerByPositionId.ExecuteReader();

            Banner banner = null;
            while (rd.Read())
            {
                banner = new Banner();

                banner.Title = rd["BANNER_TITLE"].ToString();
                banner.RedirectUrl = rd["BANNER_REDIRECT_URL"].ToString();
                banner.ImageName = rd["BANNER_IMAGE_NAME"].ToString();
                banner.Position = Convert.ToInt32(rd["BANNER_POSITION"]);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return banner;
        }

        public void DeleteBanner(int bannerId)
        {
            SqlCommand asdDeleteNewBanners = new SqlCommand();
            asdDeleteNewBanners.Connection = con;
            asdDeleteNewBanners.CommandType = CommandType.StoredProcedure;
            asdDeleteNewBanners.CommandText = "usp_DeleteBANNER";

            SqlParameter pBannerId = new SqlParameter();
            pBannerId.ParameterName = "@BANNER_ID";
            pBannerId.DbType = DbType.Int32;
            pBannerId.Value = bannerId;
            pBannerId.Direction = ParameterDirection.Input;
            asdDeleteNewBanners.Parameters.Add(pBannerId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeleteNewBanners.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void ActivateBanner(int bannerId)
        {
            SqlCommand asdDeleteNewBanners = new SqlCommand();
            asdDeleteNewBanners.Connection = con;
            asdDeleteNewBanners.CommandType = CommandType.StoredProcedure;
            asdDeleteNewBanners.CommandText = "ActivateBanner";

            SqlParameter pBannerId = new SqlParameter();
            pBannerId.ParameterName = "BANNER_ID";
            pBannerId.DbType = DbType.Int32;
            pBannerId.Value = bannerId;
            pBannerId.Direction = ParameterDirection.Input;
            asdDeleteNewBanners.Parameters.Add(pBannerId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeleteNewBanners.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeActivateBanner(int bannerId)
        {
            SqlCommand asdDeleteNewBanners = new SqlCommand();
            asdDeleteNewBanners.Connection = con;
            asdDeleteNewBanners.CommandType = CommandType.StoredProcedure;
            asdDeleteNewBanners.CommandText = "DeActivateBanner";

            SqlParameter pBannerId = new SqlParameter();
            pBannerId.ParameterName = "BANNER_ID";
            pBannerId.DbType = DbType.Int32;
            pBannerId.Value = bannerId;
            pBannerId.Direction = ParameterDirection.Input;
            asdDeleteNewBanners.Parameters.Add(pBannerId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            asdDeleteNewBanners.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }


        #endregion

        #region [Useful Websites Methods]

        public void AddUsefulWebsite(UsefulWebsite usefulWebsite)
        {
            SqlCommand cmdAddUsefulWebsite = new SqlCommand();
            cmdAddUsefulWebsite.Connection = con;
            cmdAddUsefulWebsite.CommandType = CommandType.StoredProcedure;
            cmdAddUsefulWebsite.CommandText = "InsertUSEFUL_WEBSITE";

            SqlParameter pWebsiteName = new SqlParameter();
            pWebsiteName.ParameterName = "@WEBSITE_NAME";
            pWebsiteName.DbType = DbType.String;
            pWebsiteName.Value = usefulWebsite.Name;
            cmdAddUsefulWebsite.Parameters.Add(pWebsiteName);
            pWebsiteName.Direction = ParameterDirection.Input;

            SqlParameter pImageName = new SqlParameter();
            pImageName.ParameterName = "@WEBSITE_IMAGE_NAME";
            pImageName.DbType = DbType.String;
            pImageName.Value = usefulWebsite.ImageName;
            cmdAddUsefulWebsite.Parameters.Add(pImageName);
            pImageName.Direction = ParameterDirection.Input;

            SqlParameter pRedirectUrl = new SqlParameter();
            pRedirectUrl.ParameterName = "@WEBSITE_REDIRECT_URL";
            pRedirectUrl.DbType = DbType.String;
            pRedirectUrl.Value = usefulWebsite.RedirectUrl;
            cmdAddUsefulWebsite.Parameters.Add(pRedirectUrl);
            pRedirectUrl.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddUsefulWebsite.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void UpdateUsefulWebsite(UsefulWebsite usefulWebsite)
        {
            SqlCommand cmdUpdateUsefulWebsite = new SqlCommand();
            cmdUpdateUsefulWebsite.Connection = con;
            cmdUpdateUsefulWebsite.CommandType = CommandType.StoredProcedure;
            cmdUpdateUsefulWebsite.CommandText = "UpdateUSEFUL_WEBSITE";

            SqlParameter pWebsiteId = new SqlParameter();
            pWebsiteId.ParameterName = "@WEBSITE_ID";
            pWebsiteId.DbType = DbType.Int32;
            pWebsiteId.Value = usefulWebsite.ID;
            cmdUpdateUsefulWebsite.Parameters.Add(pWebsiteId);
            pWebsiteId.Direction = ParameterDirection.Input;

            SqlParameter pWebsiteName = new SqlParameter();
            pWebsiteName.ParameterName = "@WEBSITE_NAME";
            pWebsiteName.DbType = DbType.String;
            pWebsiteName.Value = usefulWebsite.Name;
            cmdUpdateUsefulWebsite.Parameters.Add(pWebsiteName);
            pWebsiteName.Direction = ParameterDirection.Input;

            SqlParameter pImageName = new SqlParameter();
            pImageName.ParameterName = "@WEBSITE_IMAGE_NAME";
            pImageName.DbType = DbType.String;
            pImageName.Value = usefulWebsite.ImageName;
            cmdUpdateUsefulWebsite.Parameters.Add(pImageName);
            pImageName.Direction = ParameterDirection.Input;

            SqlParameter pRedirectUrl = new SqlParameter();
            pRedirectUrl.ParameterName = "@WEBSITE_REDIRECT_URL";
            pRedirectUrl.DbType = DbType.String;
            pRedirectUrl.Value = usefulWebsite.RedirectUrl;
            cmdUpdateUsefulWebsite.Parameters.Add(pRedirectUrl);
            pRedirectUrl.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateUsefulWebsite.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DeleteUsefulWebsite(int websiteId)
        {
            SqlCommand cmdDeleteUsefulWebsite = new SqlCommand();
            cmdDeleteUsefulWebsite.Connection = con;
            cmdDeleteUsefulWebsite.CommandType = CommandType.StoredProcedure;
            cmdDeleteUsefulWebsite.CommandText = "DeleteUSEFUL_WEBSITE";

            SqlParameter pWebsiteId = new SqlParameter();
            pWebsiteId.ParameterName = "@WEBSITE_ID";
            pWebsiteId.DbType = DbType.Int32;
            pWebsiteId.Value = websiteId;
            cmdDeleteUsefulWebsite.Parameters.Add(pWebsiteId);
            pWebsiteId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteUsefulWebsite.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public DataTable GetAllUsefulWebsites()
        {
            SqlCommand cmdGetAllUsefulWebsites = new SqlCommand();
            cmdGetAllUsefulWebsites.CommandText = "SelectUSEFUL_WEBSITEsAll";
            cmdGetAllUsefulWebsites.CommandType = CommandType.StoredProcedure;
            cmdGetAllUsefulWebsites.Connection = con;

            DataSet dsUsefulWebsites = new DataSet();
            dsUsefulWebsites.Tables.Add(new DataTable());
            SqlDataAdapter adUsefulWebsites = new SqlDataAdapter();

            adUsefulWebsites.SelectCommand = cmdGetAllUsefulWebsites;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUsefulWebsites.Fill(dsUsefulWebsites.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsUsefulWebsites.Tables[0];

        }

        public DataTable GetActiveUsefulWebsites()
        {
            SqlCommand cmdGetActiveUsefulWebsites = new SqlCommand();
            cmdGetActiveUsefulWebsites.CommandText = "GetActiveUsefulWebsites";
            cmdGetActiveUsefulWebsites.CommandType = CommandType.StoredProcedure;
            cmdGetActiveUsefulWebsites.Connection = con;

            DataSet dsUsefulWebsites = new DataSet();
            dsUsefulWebsites.Tables.Add(new DataTable());
            SqlDataAdapter adUsefulWebsites = new SqlDataAdapter();

            adUsefulWebsites.SelectCommand = cmdGetActiveUsefulWebsites;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUsefulWebsites.Fill(dsUsefulWebsites.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsUsefulWebsites.Tables[0];

        }

        public UsefulWebsite GetlUsefulWebsiteById(int websiteId)
        {
            SqlCommand cmdGetUsefulWebsiteByID = new SqlCommand();
            cmdGetUsefulWebsiteByID.CommandText = "SelectUSEFUL_WEBSITE";
            cmdGetUsefulWebsiteByID.CommandType = CommandType.StoredProcedure;
            cmdGetUsefulWebsiteByID.Connection = con;

            SqlParameter pWebsiteId = new SqlParameter();
            pWebsiteId.ParameterName = "@WEBSITE_ID";
            pWebsiteId.DbType = DbType.Int32;
            pWebsiteId.Value = websiteId;
            cmdGetUsefulWebsiteByID.Parameters.Add(pWebsiteId);
            pWebsiteId.Direction = ParameterDirection.Input;

            SqlDataReader rd;
            UsefulWebsite usefulWebsite = null;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetUsefulWebsiteByID.ExecuteReader();
            while (rd.Read())
            {
                usefulWebsite = new UsefulWebsite
                {
                    ID = Convert.ToInt32(rd["WEBSITE_ID"]),
                    Name = rd["WEBSITE_NAME"].ToString(),
                    ImageName = rd["WEBSITE_IMAGE_NAME"].ToString(),
                    RedirectUrl = rd["WEBSITE_REDIRECT_URL"].ToString(),
                };
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return usefulWebsite;
        }

        public void ActivateUsefulWebsite(int websiteId)
        {
            SqlCommand cmdActivateUsefulWebsite = new SqlCommand();
            cmdActivateUsefulWebsite.Connection = con;
            cmdActivateUsefulWebsite.CommandType = CommandType.StoredProcedure;
            cmdActivateUsefulWebsite.CommandText = "ActivateUsefulWebsite";

            SqlParameter pWebsiteId = new SqlParameter();
            pWebsiteId.ParameterName = "@WEBSITE_ID";
            pWebsiteId.DbType = DbType.Int32;
            pWebsiteId.Value = websiteId;
            cmdActivateUsefulWebsite.Parameters.Add(pWebsiteId);
            pWebsiteId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdActivateUsefulWebsite.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DectivateUsefulWebsite(int websiteId)
        {
            SqlCommand cmdDeactivateUsefulWebsite = new SqlCommand();
            cmdDeactivateUsefulWebsite.Connection = con;
            cmdDeactivateUsefulWebsite.CommandType = CommandType.StoredProcedure;
            cmdDeactivateUsefulWebsite.CommandText = "DectivateUsefulWebsite";

            SqlParameter pWebsiteId = new SqlParameter();
            pWebsiteId.ParameterName = "@WEBSITE_ID";
            pWebsiteId.DbType = DbType.Int32;
            pWebsiteId.Value = websiteId;
            cmdDeactivateUsefulWebsite.Parameters.Add(pWebsiteId);
            pWebsiteId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeactivateUsefulWebsite.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        #endregion

        #region [Academic Year Methods]

        public void AddAcademicYear(AcademicYear academicYear)
        {
            SqlCommand cmdAddAcademicYear = new SqlCommand();
            cmdAddAcademicYear.Connection = con;
            cmdAddAcademicYear.CommandType = CommandType.StoredProcedure;
            cmdAddAcademicYear.CommandText = "AddAcademic_Years";

            SqlParameter pacademicYearName = new SqlParameter();
            pacademicYearName.ParameterName = "@P_ACADEMIC_YEAR_NAME";
            pacademicYearName.DbType = DbType.String;
            cmdAddAcademicYear.Parameters.Add(pacademicYearName);
            pacademicYearName.Value = academicYear.Name;
            pacademicYearName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddAcademicYear.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeleteAcademicYear(int academicYearId)
        {
            SqlCommand cmdDeleteAcademicYear = new SqlCommand();
            cmdDeleteAcademicYear.Connection = con;
            cmdDeleteAcademicYear.CommandType = CommandType.StoredProcedure;
            cmdDeleteAcademicYear.CommandText = "DeleteAdemic_Years";

            SqlParameter pAcademicYearId = new SqlParameter();
            pAcademicYearId.ParameterName = "P_NEWS_ID";
            pAcademicYearId.DbType = DbType.Int32;

            pAcademicYearId.Value = academicYearId;
            pAcademicYearId.Direction = ParameterDirection.Input;
            cmdDeleteAcademicYear.Parameters.Add(pAcademicYearId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteAcademicYear.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public DataTable GetAllAcademicYears()
        {
            SqlCommand cmdGetAllAcademicYears = new SqlCommand();
            cmdGetAllAcademicYears.CommandText = "GetAllAcademicYears";
            cmdGetAllAcademicYears.CommandType = CommandType.StoredProcedure;
            cmdGetAllAcademicYears.Connection = con;

            DataSet dsAcademicYear = new DataSet();
            dsAcademicYear.Tables.Add(new DataTable());
            SqlDataAdapter adAcademicYear = new SqlDataAdapter();

            adAcademicYear.SelectCommand = cmdGetAllAcademicYears;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adAcademicYear.Fill(dsAcademicYear.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsAcademicYear.Tables[0];

        }

        #endregion

        #region [Specialty Methods]

        public void AddSpecialty(Specialty specialty)
        {
            SqlCommand cmdAddSpecialty = new SqlCommand();
            cmdAddSpecialty.Connection = con;
            cmdAddSpecialty.CommandType = CommandType.StoredProcedure;
            cmdAddSpecialty.CommandText = "InsertSPECIALTY";

            SqlParameter pSpecialtyName = new SqlParameter();
            pSpecialtyName.ParameterName = "@SPECIALTY_NAME";
            pSpecialtyName.DbType = DbType.String;
            cmdAddSpecialty.Parameters.Add(pSpecialtyName);
            pSpecialtyName.Value = specialty.Name;
            pSpecialtyName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddSpecialty.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateSpecialty(Specialty specialty)
        {
            SqlCommand cmdUpdateSpecialty = new SqlCommand();
            cmdUpdateSpecialty.Connection = con;
            cmdUpdateSpecialty.CommandType = CommandType.StoredProcedure;
            cmdUpdateSpecialty.CommandText = "UpdateSPECIALTY";

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@SPECIALTY_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = specialty.ID;
            cmdUpdateSpecialty.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            SqlParameter pSpecialtyName = new SqlParameter();
            pSpecialtyName.ParameterName = "@SPECIALTY_NAME";
            pSpecialtyName.DbType = DbType.String;
            cmdUpdateSpecialty.Parameters.Add(pSpecialtyName);
            pSpecialtyName.Value = specialty.Name;
            pSpecialtyName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateSpecialty.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeleteSpecialty(int specialtyId)
        {
            SqlCommand cmdDeleteSpecialty = new SqlCommand();
            cmdDeleteSpecialty.Connection = con;
            cmdDeleteSpecialty.CommandType = CommandType.StoredProcedure;
            cmdDeleteSpecialty.CommandText = "DeleteSPECIALTY";

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@P_SPECIALTY_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = specialtyId;
            cmdDeleteSpecialty.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteSpecialty.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public DataTable GetAllSpecialties()
        {
            SqlCommand cmdGetAllSpecialties = new SqlCommand();
            cmdGetAllSpecialties.CommandText = "SelectSPECIALTiesAll";
            cmdGetAllSpecialties.CommandType = CommandType.StoredProcedure;
            cmdGetAllSpecialties.Connection = con;

            DataSet dsSpecialty = new DataSet();
            dsSpecialty.Tables.Add(new DataTable());
            SqlDataAdapter adSpecialty = new SqlDataAdapter();

            adSpecialty.SelectCommand = cmdGetAllSpecialties;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adSpecialty.Fill(dsSpecialty.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsSpecialty.Tables[0];

        }

        public Specialty GetSpecialtyById(int specialtyId)
        {
            SqlCommand cmdGetSpecialtyById = new SqlCommand();
            cmdGetSpecialtyById.CommandText = "SelectSPECIALTY";
            cmdGetSpecialtyById.CommandType = CommandType.StoredProcedure;
            cmdGetSpecialtyById.Connection = con;

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@SPECIALTY_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = specialtyId;
            cmdGetSpecialtyById.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            SqlDataReader rd;
            Specialty specialty = null;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetSpecialtyById.ExecuteReader();

            while (rd.Read())
            {
                specialty = new Specialty
                {
                    ID = Convert.ToInt32(rd["SPECIALTY_ID"]),
                    Name = rd["SPECIALTY_NAME"] != null ? rd["SPECIALTY_NAME"].ToString() : string.Empty,
                };
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return specialty;

        }

        #endregion

        #region [Course Methods]

        public void AddCourse(Course course)
        {
            SqlCommand cmdAddCourse = new SqlCommand();
            cmdAddCourse.Connection = con;
            cmdAddCourse.CommandType = CommandType.StoredProcedure;
            cmdAddCourse.CommandText = "InsertCOURSE";

            SqlParameter pCourseName = new SqlParameter();
            pCourseName.ParameterName = "@COURSE_NAME";
            pCourseName.DbType = DbType.String;
            cmdAddCourse.Parameters.Add(pCourseName);
            pCourseName.Value = course.Name;
            pCourseName.Direction = ParameterDirection.Input;

            //SqlParameter pSpecialtyId = new SqlParameter();
            //pSpecialtyId.ParameterName = "@REF_SPECIALTY_ID";
            //pSpecialtyId.DbType = DbType.Int32;
            //pSpecialtyId.Value = course.SpecialtyId;
            //cmdAddCourse.Parameters.Add(pSpecialtyId);
            //pSpecialtyId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddCourse.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateCourse(Course course)
        {
            SqlCommand cmdUpdateCourse = new SqlCommand();
            cmdUpdateCourse.Connection = con;
            cmdUpdateCourse.CommandType = CommandType.StoredProcedure;
            cmdUpdateCourse.CommandText = "UpdateCOURSE";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = course.ID;
            cmdUpdateCourse.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pCourseName = new SqlParameter();
            pCourseName.ParameterName = "@COURSE_NAME";
            pCourseName.DbType = DbType.String;
            cmdUpdateCourse.Parameters.Add(pCourseName);
            pCourseName.Value = course.Name;
            pCourseName.Direction = ParameterDirection.Input;

            //SqlParameter pSpecialtyId = new SqlParameter();
            //pSpecialtyId.ParameterName = "@REF_SPECIALTY_ID";
            //pSpecialtyId.DbType = DbType.Int32;
            //pSpecialtyId.Value = course.SpecialtyId;
            //cmdUpdateCourse.Parameters.Add(pSpecialtyId);
            //pSpecialtyId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateCourse.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeleteCourse(int courseId)
        {
            SqlCommand cmdDeleteCourse = new SqlCommand();
            cmdDeleteCourse.Connection = con;
            cmdDeleteCourse.CommandType = CommandType.StoredProcedure;
            cmdDeleteCourse.CommandText = "DeleteCOURSE";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdDeleteCourse.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteCourse.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public Course GetCourseById(int courseId)
        {
            SqlCommand cmdGetCourseById = new SqlCommand();
            cmdGetCourseById.CommandText = "SelectCourse";
            cmdGetCourseById.CommandType = CommandType.StoredProcedure;
            cmdGetCourseById.Connection = con;

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdGetCourseById.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlDataReader rd;
            Course course = null;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCourseById.ExecuteReader();

            while (rd.Read())
            {
                course = new Course
                {
                    ID = Convert.ToInt32(rd["Course_ID"]),
                    Name = rd["COURSE_NAME"] != null ? rd["COURSE_NAME"].ToString() : string.Empty,
                    SpecialtyId = rd["REF_SPECIALTY_ID"] != System.DBNull.Value ? Convert.ToInt32(rd["REF_SPECIALTY_ID"]) : -1,
                };
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return course;

        }

        public DataTable GetAllCourses()
        {
            SqlCommand cmdGetAllCourses = new SqlCommand();
            cmdGetAllCourses.CommandText = "SelectCOURSEsAll";
            cmdGetAllCourses.CommandType = CommandType.StoredProcedure;
            cmdGetAllCourses.Connection = con;

            DataSet dsCourse = new DataSet();
            dsCourse.Tables.Add(new DataTable());
            SqlDataAdapter adCourse = new SqlDataAdapter();

            adCourse.SelectCommand = cmdGetAllCourses;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adCourse.Fill(dsCourse.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsCourse.Tables[0];

        }

        public DataTable GetCoursesBySpecialtyId(int specialtyId)
        {
            SqlCommand cmdGetCoursesBySpecialtyId = new SqlCommand();
            cmdGetCoursesBySpecialtyId.CommandText = "SelectCOURSEsByREF_SPECIALTY_ID";
            cmdGetCoursesBySpecialtyId.CommandType = CommandType.StoredProcedure;
            cmdGetCoursesBySpecialtyId.Connection = con;

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@REF_SPECIALTY_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = specialtyId;
            cmdGetCoursesBySpecialtyId.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            DataSet dsCourse = new DataSet();
            dsCourse.Tables.Add(new DataTable());
            SqlDataAdapter adCourse = new SqlDataAdapter();

            adCourse.SelectCommand = cmdGetCoursesBySpecialtyId;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adCourse.Fill(dsCourse.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsCourse.Tables[0];

        }

        #endregion

        #region [Level Methods]

        public void AddLevel(Level level)
        {
            SqlCommand cmdAddLevel = new SqlCommand();
            cmdAddLevel.Connection = con;
            cmdAddLevel.CommandType = CommandType.StoredProcedure;
            cmdAddLevel.CommandText = "InsertLEVEL";

            SqlParameter pLevelName = new SqlParameter();
            pLevelName.ParameterName = "@Level_NAME";
            pLevelName.DbType = DbType.String;
            cmdAddLevel.Parameters.Add(pLevelName);
            pLevelName.Value = level.Name;
            pLevelName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddLevel.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateLevel(Level level)
        {
            SqlCommand cmdUpdateLevel = new SqlCommand();
            cmdUpdateLevel.Connection = con;
            cmdUpdateLevel.CommandType = CommandType.StoredProcedure;
            cmdUpdateLevel.CommandText = "UpdateLevel";

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@Level_ID";
            pLevelId.DbType = DbType.Int32;
            pLevelId.Value = level.ID;
            cmdUpdateLevel.Parameters.Add(pLevelId);
            pLevelId.Direction = ParameterDirection.Input;

            SqlParameter pLevelName = new SqlParameter();
            pLevelName.ParameterName = "@Level_NAME";
            pLevelName.DbType = DbType.String;
            cmdUpdateLevel.Parameters.Add(pLevelName);
            pLevelName.Value = level.Name;
            pLevelName.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateLevel.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void DeleteLevel(int levelId)
        {
            SqlCommand cmdDeleteLevel = new SqlCommand();
            cmdDeleteLevel.Connection = con;
            cmdDeleteLevel.CommandType = CommandType.StoredProcedure;
            cmdDeleteLevel.CommandText = "DeleteLevel";

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@P_Level_ID";
            pLevelId.DbType = DbType.Int32;
            pLevelId.Value = levelId;
            cmdDeleteLevel.Parameters.Add(pLevelId);
            pLevelId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteLevel.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public DataTable GetAllLevels()
        {
            SqlCommand cmdGetAllLevels = new SqlCommand();
            cmdGetAllLevels.CommandText = "SelectLevelsAll";
            cmdGetAllLevels.CommandType = CommandType.StoredProcedure;
            cmdGetAllLevels.Connection = con;

            DataSet dsLevel = new DataSet();
            dsLevel.Tables.Add(new DataTable());
            SqlDataAdapter adLevel = new SqlDataAdapter();

            adLevel.SelectCommand = cmdGetAllLevels;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adLevel.Fill(dsLevel.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsLevel.Tables[0];
        }



        public Level GetLevelById(int levelId)
        {
            SqlCommand cmdGetLevelById = new SqlCommand();
            cmdGetLevelById.CommandText = "SelectLevel";
            cmdGetLevelById.CommandType = CommandType.StoredProcedure;
            cmdGetLevelById.Connection = con;

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@Level_ID";
            pLevelId.DbType = DbType.Int32;
            pLevelId.Value = levelId;
            cmdGetLevelById.Parameters.Add(pLevelId);
            pLevelId.Direction = ParameterDirection.Input;

            SqlDataReader rd;
            Level Level = null;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetLevelById.ExecuteReader();

            while (rd.Read())
            {
                Level = new Level
                {
                    ID = Convert.ToInt32(rd["Level_ID"]),
                    Name = rd["Level_NAME"] != null ? rd["Level_NAME"].ToString() : string.Empty,
                };
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return Level;

        }



        #endregion

        #region [Course Level Methods]

        public DataTable GetCourseLevelsByCourseId(int courseId)
        {
            SqlCommand cmdGetCourseLevelsById = new SqlCommand();
            cmdGetCourseLevelsById.CommandText = "SelectCOURSE_LEVELsByCOURSE_ID";
            cmdGetCourseLevelsById.CommandType = CommandType.StoredProcedure;
            cmdGetCourseLevelsById.Connection = con;

            SqlParameter pCourseLevelId = new SqlParameter();
            pCourseLevelId.ParameterName = "@COURSE_ID";
            pCourseLevelId.DbType = DbType.Int32;
            pCourseLevelId.Value = courseId;
            cmdGetCourseLevelsById.Parameters.Add(pCourseLevelId);
            pCourseLevelId.Direction = ParameterDirection.Input;

            DataSet dsCourseLevel = new DataSet();
            dsCourseLevel.Tables.Add(new DataTable());
            SqlDataAdapter adCourseLevel = new SqlDataAdapter();

            adCourseLevel.SelectCommand = cmdGetCourseLevelsById;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adCourseLevel.Fill(dsCourseLevel.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsCourseLevel.Tables[0];

        }

        public void DeleteCourseLevel(int courseId, int levelId)
        {
            SqlCommand cmdDeleteCourseLevel = new SqlCommand();
            cmdDeleteCourseLevel.Connection = con;
            cmdDeleteCourseLevel.CommandType = CommandType.StoredProcedure;
            cmdDeleteCourseLevel.CommandText = "DeleteCOURSE_LEVEL";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdDeleteCourseLevel.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@LEVEL_ID";
            pLevelId.DbType = DbType.Int32;
            pLevelId.Value = levelId;
            cmdDeleteCourseLevel.Parameters.Add(pLevelId);
            pLevelId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteCourseLevel.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void AddCourseLevel(int courseId, int levelId)
        {
            SqlCommand cmdAddCourseLevel = new SqlCommand();
            cmdAddCourseLevel.Connection = con;
            cmdAddCourseLevel.CommandType = CommandType.StoredProcedure;
            cmdAddCourseLevel.CommandText = "InsertCOURSE_LEVEL";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdAddCourseLevel.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pLevelId = new SqlParameter();
            pLevelId.ParameterName = "@LEVEL_ID";
            pLevelId.DbType = DbType.Int32;
            pLevelId.Value = levelId;
            cmdAddCourseLevel.Parameters.Add(pLevelId);
            pLevelId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddCourseLevel.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        #endregion

        #region [Teacher Course Methods]

        public void AddTeacherCourse(int courseId, int teacherId)
        {
            SqlCommand cmdAddTeacherCourse = new SqlCommand();
            cmdAddTeacherCourse.Connection = con;
            cmdAddTeacherCourse.CommandType = CommandType.StoredProcedure;
            cmdAddTeacherCourse.CommandText = "InsertTEACHER_COURSE";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdAddTeacherCourse.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pTeacherId = new SqlParameter();
            pTeacherId.ParameterName = "@Teacher_ID";
            pTeacherId.DbType = DbType.Int32;
            pTeacherId.Value = teacherId;
            cmdAddTeacherCourse.Parameters.Add(pTeacherId);
            pTeacherId.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddTeacherCourse.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DeleteTeacherCourse(int courseId, int teacherId)
        {
            SqlCommand cmdDeleteTeacherCourse = new SqlCommand();
            cmdDeleteTeacherCourse.Connection = con;
            cmdDeleteTeacherCourse.CommandType = CommandType.StoredProcedure;
            cmdDeleteTeacherCourse.CommandText = "DeleteTEACHER_COURSE";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdDeleteTeacherCourse.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pTeacherId = new SqlParameter();
            pTeacherId.ParameterName = "@Teacher_ID";
            pTeacherId.DbType = DbType.Int32;
            pTeacherId.Value = teacherId;
            cmdDeleteTeacherCourse.Parameters.Add(pTeacherId);
            pTeacherId.Direction = ParameterDirection.Input;


            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteTeacherCourse.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public DataTable GetTeachersByCourseId(int courseId)
        {
            SqlCommand cmdGetTeachersByCourseId = new SqlCommand();
            cmdGetTeachersByCourseId.CommandText = "SelectTEACHER_COURSEsByCOURSE_ID";
            cmdGetTeachersByCourseId.CommandType = CommandType.StoredProcedure;
            cmdGetTeachersByCourseId.Connection = con;

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdGetTeachersByCourseId.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            DataSet dsCourseLevel = new DataSet();
            dsCourseLevel.Tables.Add(new DataTable());
            SqlDataAdapter adCourseLevel = new SqlDataAdapter();

            adCourseLevel.SelectCommand = cmdGetTeachersByCourseId;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adCourseLevel.Fill(dsCourseLevel.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsCourseLevel.Tables[0];

        }

        public List<int> GetCoursesIdsByTeacherId(int teacherId)
        {
            SqlCommand cmdGetCoursesByTeacherId = new SqlCommand();
            cmdGetCoursesByTeacherId.CommandText = "SelectTEACHER_COURSEsByTEACHER_ID";
            cmdGetCoursesByTeacherId.CommandType = CommandType.StoredProcedure;
            cmdGetCoursesByTeacherId.Connection = con;

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@TEACHER_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = teacherId;
            cmdGetCoursesByTeacherId.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlDataReader rd;

            List<int> coursesIds = null;
            int courseId = -1;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetCoursesByTeacherId.ExecuteReader();
            while (rd.Read())
            {
                if (coursesIds == null)
                    coursesIds = new List<int>();

                courseId = Convert.ToInt32(rd["COURSE_ID"]);
                coursesIds.Add(courseId);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return coursesIds;

        }


        #endregion

        #region [Specialty Course Methods]

        public void AddSpecialtyCourse(int courseId, int SpecialtyId)
        {
            SqlCommand cmdAddCourseSpecialty = new SqlCommand();
            cmdAddCourseSpecialty.Connection = con;
            cmdAddCourseSpecialty.CommandType = CommandType.StoredProcedure;
            cmdAddCourseSpecialty.CommandText = "InsertSPECIALTY_COURSE";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdAddCourseSpecialty.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@Specialty_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = SpecialtyId;
            cmdAddCourseSpecialty.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddCourseSpecialty.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DeleteSpecialtyCourse(int courseId, int specialtyId)
        {
            SqlCommand cmdDeleteCourseSpecialty = new SqlCommand();
            cmdDeleteCourseSpecialty.Connection = con;
            cmdDeleteCourseSpecialty.CommandType = CommandType.StoredProcedure;
            cmdDeleteCourseSpecialty.CommandText = "DeleteSPECIALTY_COURSE";

            SqlParameter pCourseId = new SqlParameter();
            pCourseId.ParameterName = "@COURSE_ID";
            pCourseId.DbType = DbType.Int32;
            pCourseId.Value = courseId;
            cmdDeleteCourseSpecialty.Parameters.Add(pCourseId);
            pCourseId.Direction = ParameterDirection.Input;

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@Specialty_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = specialtyId;
            cmdDeleteCourseSpecialty.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteCourseSpecialty.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public DataTable GetSpecialtyCoursesBySpecialtyId(int specialtyId)
        {
            SqlCommand cmdGetCourseSpecialtysById = new SqlCommand();
            cmdGetCourseSpecialtysById.CommandText = "SelectSPECIALTY_COURSEsBySPECIALTY_ID";
            cmdGetCourseSpecialtysById.CommandType = CommandType.StoredProcedure;
            cmdGetCourseSpecialtysById.Connection = con;

            SqlParameter pSpecialtyId = new SqlParameter();
            pSpecialtyId.ParameterName = "@SPECIALTY_ID";
            pSpecialtyId.DbType = DbType.Int32;
            pSpecialtyId.Value = specialtyId;
            cmdGetCourseSpecialtysById.Parameters.Add(pSpecialtyId);
            pSpecialtyId.Direction = ParameterDirection.Input;

            DataSet dsCourseSpecialty = new DataSet();
            dsCourseSpecialty.Tables.Add(new DataTable());
            SqlDataAdapter adCourseSpecialty = new SqlDataAdapter();

            adCourseSpecialty.SelectCommand = cmdGetCourseSpecialtysById;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adCourseSpecialty.Fill(dsCourseSpecialty.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsCourseSpecialty.Tables[0];

        }

        #endregion

        #region [Article Methods]

        public void AddNewArticle(Article Article)
        {
            SqlCommand cmdAddArticle = new SqlCommand();
            cmdAddArticle.Connection = con;
            cmdAddArticle.CommandType = CommandType.StoredProcedure;
            cmdAddArticle.CommandText = "InsertARTICLE";

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@ARTICLE_TITLE";
            pTitle.DbType = DbType.String;
            cmdAddArticle.Parameters.Add(pTitle);
            pTitle.Value = Article.Title;
            pTitle.Direction = ParameterDirection.Input;

            SqlParameter pBody = new SqlParameter();
            pBody.ParameterName = "@ARTICLE_BODY";
            pBody.DbType = DbType.String;
            cmdAddArticle.Parameters.Add(pBody);
            pBody.Value = Article.Body;
            pBody.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "@PUBLISH_DATE";
            pPublish_Date.DbType = DbType.DateTime;
            cmdAddArticle.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = Article.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            SqlParameter pWriterId = new SqlParameter();
            pWriterId.ParameterName = "@WRITER_ID";
            pWriterId.DbType = DbType.Int32;
            cmdAddArticle.Parameters.Add(pWriterId);
            pWriterId.Value = Article.WriterId;
            pWriterId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddArticle.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DeleteArticle(int id)
        {
            SqlCommand cmdDeleteNewArticle = new SqlCommand();
            cmdDeleteNewArticle.Connection = con;
            cmdDeleteNewArticle.CommandType = CommandType.StoredProcedure;
            cmdDeleteNewArticle.CommandText = "DeleteARTICLE";

            SqlParameter pArticle_Id = new SqlParameter();
            pArticle_Id.ParameterName = "@ARTICLE_D";
            pArticle_Id.DbType = DbType.Int32;

            pArticle_Id.Value = id;
            pArticle_Id.Direction = ParameterDirection.Input;
            cmdDeleteNewArticle.Parameters.Add(pArticle_Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteNewArticle.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateArticle(Article Article)
        {
            SqlCommand cmdUpdateArticle = new SqlCommand();
            cmdUpdateArticle.Connection = con;
            cmdUpdateArticle.CommandType = CommandType.StoredProcedure;
            cmdUpdateArticle.CommandText = "UpdateARTICLE";

            SqlParameter pArticleId = new SqlParameter();
            pArticleId.ParameterName = "@ARTICLE_ID";
            pArticleId.DbType = DbType.Int32;
            cmdUpdateArticle.Parameters.Add(pArticleId);
            pArticleId.Value = Article.ID;
            pArticleId.Direction = ParameterDirection.Input;

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@ARTICLE_TITLE";
            pTitle.DbType = DbType.String;
            cmdUpdateArticle.Parameters.Add(pTitle);
            pTitle.Value = Article.Title;
            pTitle.Direction = ParameterDirection.Input;

            SqlParameter pBody = new SqlParameter();
            pBody.ParameterName = "@ARTICLE_BODY";
            pBody.DbType = DbType.String;
            cmdUpdateArticle.Parameters.Add(pBody);
            pBody.Value = Article.Body;
            pBody.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "@PUBLISH_DATE";
            pPublish_Date.DbType = DbType.DateTime;
            cmdUpdateArticle.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = Article.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            SqlParameter pWriterId = new SqlParameter();
            pWriterId.ParameterName = "@WRITER_ID";
            pWriterId.DbType = DbType.Int32;
            cmdUpdateArticle.Parameters.Add(pWriterId);
            pWriterId.Value = Article.WriterId;
            pWriterId.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateArticle.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public Article GetArticleById(int articleId)
        {
            SqlCommand cmdGetArticleById = new SqlCommand();
            cmdGetArticleById.CommandText = "SelectARTICLE";
            cmdGetArticleById.CommandType = CommandType.StoredProcedure;
            cmdGetArticleById.Connection = con;

            SqlParameter pArticleId = new SqlParameter();
            pArticleId.DbType = DbType.Int32;
            pArticleId.ParameterName = "@ARTICLE_ID";
            pArticleId.Direction = ParameterDirection.Input;
            pArticleId.Value = articleId;
            cmdGetArticleById.Parameters.Add(pArticleId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetArticleById.ExecuteReader();

            Article Article = null;
            while (rd.Read())
            {
                Article = new Article();
                Article.ID = Convert.ToInt32(rd["ARTICLE_ID"]);
                Article.Title = rd["ARTICLE_TITLE"].ToString();
                Article.Body = rd["ARTICLE_BODY"].ToString();
                Article.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
                Article.WriterId = Convert.ToInt32(rd["WRITER_ID"]);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return Article;
        }

        public DataTable GetAllArticle()
        {
            SqlCommand cmdGetAllArticle = new SqlCommand();
            cmdGetAllArticle.CommandText = "SelectARTICLEsAll";
            cmdGetAllArticle.CommandType = CommandType.StoredProcedure;
            cmdGetAllArticle.Connection = con;

            DataSet dsArticle = new DataSet();
            dsArticle.Tables.Add(new DataTable());
            SqlDataAdapter adArticle = new SqlDataAdapter();

            adArticle.SelectCommand = cmdGetAllArticle;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adArticle.Fill(dsArticle.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsArticle.Tables[0];

        }

        public DataTable GetTopTenArticles()
        {
            SqlCommand GetTopTenArticles = new SqlCommand();
            GetTopTenArticles.CommandText = "GetTopTenArticles";
            GetTopTenArticles.CommandType = CommandType.StoredProcedure;
            GetTopTenArticles.Connection = con;

            DataSet dsArticle = new DataSet();
            dsArticle.Tables.Add(new DataTable());
            SqlDataAdapter adArticle = new SqlDataAdapter();

            adArticle.SelectCommand = GetTopTenArticles;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adArticle.Fill(dsArticle.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsArticle.Tables[0];

        }

        public DataTable GetArticlesByWriterId(int wrtierId)
        {
            SqlCommand cmdGetAllArticle = new SqlCommand();
            cmdGetAllArticle.CommandText = "SelectARTICLEsByWRITER_ID";
            cmdGetAllArticle.CommandType = CommandType.StoredProcedure;
            cmdGetAllArticle.Connection = con;

            SqlParameter pArticleId = new SqlParameter();
            pArticleId.ParameterName = "@WRITER_ID";
            pArticleId.DbType = DbType.Int32;
            cmdGetAllArticle.Parameters.Add(pArticleId);
            pArticleId.Value = wrtierId;
            pArticleId.Direction = ParameterDirection.Input;

            DataSet dsArticle = new DataSet();
            dsArticle.Tables.Add(new DataTable());
            SqlDataAdapter adArticle = new SqlDataAdapter();

            adArticle.SelectCommand = cmdGetAllArticle;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adArticle.Fill(dsArticle.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsArticle.Tables[0];

        }

        public DataTable SearchArticles(int wrtierId, string articleTitle)
        {
            SqlCommand cmdSearchArticles = new SqlCommand();
            cmdSearchArticles.CommandText = "SearchArticles";
            cmdSearchArticles.CommandType = CommandType.StoredProcedure;
            cmdSearchArticles.Connection = con;

            SqlParameter pWriterId = new SqlParameter();
            pWriterId.ParameterName = "@P_WRITER_ID";
            pWriterId.DbType = DbType.Int32;
            cmdSearchArticles.Parameters.Add(pWriterId);
            pWriterId.Value = wrtierId;
            pWriterId.Direction = ParameterDirection.Input;

            SqlParameter pArticleTitle = new SqlParameter();
            pArticleTitle.ParameterName = "@P_ARTICLE_TITLE";
            pArticleTitle.DbType = DbType.String;
            cmdSearchArticles.Parameters.Add(pArticleTitle);
            pArticleTitle.Value = articleTitle;
            pArticleTitle.Direction = ParameterDirection.Input;

            DataSet dsArticle = new DataSet();
            dsArticle.Tables.Add(new DataTable());
            SqlDataAdapter adArticle = new SqlDataAdapter();

            adArticle.SelectCommand = cmdSearchArticles;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adArticle.Fill(dsArticle.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsArticle.Tables[0];

        }

        #endregion

        #region [Transaction History]

        public DataTable GetTransactionsHistoryByUserId(int userId, int recordsCount)
        {
            SqlCommand cmdGetTransactionsHistoryByUserId = new SqlCommand();
            cmdGetTransactionsHistoryByUserId.CommandText = "GetTransactionsHistoryByUserId";
            cmdGetTransactionsHistoryByUserId.CommandType = CommandType.StoredProcedure;
            cmdGetTransactionsHistoryByUserId.Connection = con;

            SqlParameter pTransactionHistoryId = new SqlParameter();
            pTransactionHistoryId.ParameterName = "@P_WRITER_ID";
            pTransactionHistoryId.DbType = DbType.Int32;
            cmdGetTransactionsHistoryByUserId.Parameters.Add(pTransactionHistoryId);
            pTransactionHistoryId.Value = userId;
            pTransactionHistoryId.Direction = ParameterDirection.Input;

            SqlParameter pRecordsCount = new SqlParameter();
            pRecordsCount.ParameterName = "@P_RECORDS_COUNT";
            pRecordsCount.DbType = DbType.Int32;
            cmdGetTransactionsHistoryByUserId.Parameters.Add(pRecordsCount);
            pRecordsCount.Value = recordsCount;
            pRecordsCount.Direction = ParameterDirection.Input;

            DataSet dsTransactionHistory = new DataSet();
            dsTransactionHistory.Tables.Add(new DataTable());
            SqlDataAdapter adTransactionHistory = new SqlDataAdapter();

            adTransactionHistory.SelectCommand = cmdGetTransactionsHistoryByUserId;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adTransactionHistory.Fill(dsTransactionHistory.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsTransactionHistory.Tables[0];
        }

        public void DeleteTransactionsHistoryByTransactionId(int transactionId)
        {
            SqlCommand cmdDeleteNewTransaction = new SqlCommand();
            cmdDeleteNewTransaction.Connection = con;
            cmdDeleteNewTransaction.CommandType = CommandType.StoredProcedure;
            cmdDeleteNewTransaction.CommandText = "DeleteTransactionsHistoryByTransactionId";

            SqlParameter pTransaction_Id = new SqlParameter();
            pTransaction_Id.ParameterName = "@P_TRANSACTION_ID";
            pTransaction_Id.DbType = DbType.Int32;

            pTransaction_Id.Value = transactionId;
            pTransaction_Id.Direction = ParameterDirection.Input;
            cmdDeleteNewTransaction.Parameters.Add(pTransaction_Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteNewTransaction.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }



        #endregion

        #region [UsefulInfo Methods]

        public void AddNewUsefulInfo(UsefulInfo UsefulInfo)
        {
            SqlCommand cmdAddUsefulInfo = new SqlCommand();
            cmdAddUsefulInfo.Connection = con;
            cmdAddUsefulInfo.CommandType = CommandType.StoredProcedure;
            cmdAddUsefulInfo.CommandText = "InsertUSEFUL_INFO";

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@Useful_Info_TITLE";
            pTitle.DbType = DbType.String;
            cmdAddUsefulInfo.Parameters.Add(pTitle);
            pTitle.Value = UsefulInfo.Title;
            pTitle.Direction = ParameterDirection.Input;

            SqlParameter pBody = new SqlParameter();
            pBody.ParameterName = "@Useful_Info_BODY";
            pBody.DbType = DbType.String;
            cmdAddUsefulInfo.Parameters.Add(pBody);
            pBody.Value = UsefulInfo.Body;
            pBody.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "@PUBLISH_DATE";
            pPublish_Date.DbType = DbType.DateTime;
            cmdAddUsefulInfo.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = UsefulInfo.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdAddUsefulInfo.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public void DeleteUsefulInfo(int id)
        {
            SqlCommand cmdDeleteNewUsefulInfo = new SqlCommand();
            cmdDeleteNewUsefulInfo.Connection = con;
            cmdDeleteNewUsefulInfo.CommandType = CommandType.StoredProcedure;
            cmdDeleteNewUsefulInfo.CommandText = "DeleteUSEFUL_INFO";

            SqlParameter pUsefulInfo_Id = new SqlParameter();
            pUsefulInfo_Id.ParameterName = "@USEFUL_INFO_ID";
            pUsefulInfo_Id.DbType = DbType.Int32;

            pUsefulInfo_Id.Value = id;
            pUsefulInfo_Id.Direction = ParameterDirection.Input;
            cmdDeleteNewUsefulInfo.Parameters.Add(pUsefulInfo_Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdDeleteNewUsefulInfo.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public void UpdateUsefulInfo(UsefulInfo UsefulInfo)
        {
            SqlCommand cmdUpdateUsefulInfo = new SqlCommand();
            cmdUpdateUsefulInfo.Connection = con;
            cmdUpdateUsefulInfo.CommandType = CommandType.StoredProcedure;
            cmdUpdateUsefulInfo.CommandText = "UpdateUseful_Info";

            SqlParameter pUsefulInfoId = new SqlParameter();
            pUsefulInfoId.ParameterName = "@Useful_Info_ID";
            pUsefulInfoId.DbType = DbType.Int32;
            cmdUpdateUsefulInfo.Parameters.Add(pUsefulInfoId);
            pUsefulInfoId.Value = UsefulInfo.ID;
            pUsefulInfoId.Direction = ParameterDirection.Input;

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@Useful_Info_TITLE";
            pTitle.DbType = DbType.String;
            cmdUpdateUsefulInfo.Parameters.Add(pTitle);
            pTitle.Value = UsefulInfo.Title;
            pTitle.Direction = ParameterDirection.Input;

            SqlParameter pBody = new SqlParameter();
            pBody.ParameterName = "@Useful_Info_BODY";
            pBody.DbType = DbType.String;
            cmdUpdateUsefulInfo.Parameters.Add(pBody);
            pBody.Value = UsefulInfo.Body;
            pBody.Direction = ParameterDirection.Input;

            SqlParameter pPublish_Date = new SqlParameter();
            pPublish_Date.ParameterName = "@PUBLISH_DATE";
            pPublish_Date.DbType = DbType.DateTime;
            cmdUpdateUsefulInfo.Parameters.Add(pPublish_Date);
            pPublish_Date.Value = UsefulInfo.PublishDate;
            pPublish_Date.Direction = ParameterDirection.Input;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmdUpdateUsefulInfo.ExecuteNonQuery();

            if (con.State != ConnectionState.Closed)
                con.Close();

        }

        public UsefulInfo GetUsefulInfoById(int UsefulInfoId)
        {
            SqlCommand cmdGetUsefulInfoById = new SqlCommand();
            cmdGetUsefulInfoById.CommandText = "SelectUSEFUL_INFO";
            cmdGetUsefulInfoById.CommandType = CommandType.StoredProcedure;
            cmdGetUsefulInfoById.Connection = con;

            SqlParameter pUsefulInfoId = new SqlParameter();
            pUsefulInfoId.DbType = DbType.Int32;
            pUsefulInfoId.ParameterName = "@Useful_Info_ID";
            pUsefulInfoId.Direction = ParameterDirection.Input;
            pUsefulInfoId.Value = UsefulInfoId;
            cmdGetUsefulInfoById.Parameters.Add(pUsefulInfoId);

            SqlDataReader rd;

            if (con.State == ConnectionState.Closed)
                con.Open();

            rd = cmdGetUsefulInfoById.ExecuteReader();

            UsefulInfo UsefulInfo = null;
            while (rd.Read())
            {
                UsefulInfo = new UsefulInfo();
                UsefulInfo.ID = Convert.ToInt32(rd["Useful_Info_ID"]);
                UsefulInfo.Title = rd["Useful_Info_TITLE"].ToString();
                UsefulInfo.Body = rd["Useful_Info_BODY"].ToString();
                UsefulInfo.PublishDate = Convert.ToDateTime(rd["PUBLISH_DATE"]);
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return UsefulInfo;
        }

        public DataTable GetAllUsefulInfo()
        {
            SqlCommand cmdGetAllUsefulInfo = new SqlCommand();
            cmdGetAllUsefulInfo.CommandText = "SelectUSEFUL_INFOsAll";
            cmdGetAllUsefulInfo.CommandType = CommandType.StoredProcedure;
            cmdGetAllUsefulInfo.Connection = con;

            DataSet dsUsefulInfo = new DataSet();
            dsUsefulInfo.Tables.Add(new DataTable());
            SqlDataAdapter adUsefulInfo = new SqlDataAdapter();

            adUsefulInfo.SelectCommand = cmdGetAllUsefulInfo;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUsefulInfo.Fill(dsUsefulInfo.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsUsefulInfo.Tables[0];

        }

        public DataTable GetTopTenUsefulInfo()
        {
            SqlCommand cmdGetTopTenUsefulInfo = new SqlCommand();
            cmdGetTopTenUsefulInfo.CommandText = "SelectUSEFUL_INFOsAll";
            cmdGetTopTenUsefulInfo.CommandType = CommandType.StoredProcedure;
            cmdGetTopTenUsefulInfo.Connection = con;

            DataSet dsUsefulInfo = new DataSet();
            dsUsefulInfo.Tables.Add(new DataTable());
            SqlDataAdapter adUsefulInfo = new SqlDataAdapter();

            adUsefulInfo.SelectCommand = cmdGetTopTenUsefulInfo;

            if (con.State == ConnectionState.Closed)
                con.Open();

            adUsefulInfo.Fill(dsUsefulInfo.Tables[0]);

            if (con.State == ConnectionState.Open)
                con.Close();

            return dsUsefulInfo.Tables[0];

        }


        #endregion
    }
}
