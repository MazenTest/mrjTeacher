using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyComponent.DataAccess;
using MyComponent.Entities;
using System.Data;

namespace MyComponent.Business
{
    public static class BLL
    {
        #region [User Functions]

        public static void AddNewUser(User user)
        {
            DAL dal = new DAL();
            dal.AddNewUser(user);
        }

        public static void DeleteNewUser(int userId)
        {
            DAL dal = new DAL();
            dal.DeleteNewUser(userId);
        }

        public static void UpdateUser(User user)
        {
            DAL dal = new DAL();
            dal.UpdateNewUser(user);
        }

        public static User GetUserById(int userId)
        {
            DAL dal = new DAL();
            return dal.GetUserById(userId);
        }

        public static DataTable GetAllUsers()
        {
            DAL dal = new DAL();
            return dal.GetAllUsers();
        }

        public static DataTable GetUsersByRoleId(int roleId)
        {
            DAL dal = new DAL();
            return dal.GetUsersByRoleId(roleId);
        }

        public static DataTable GetTopUsersByRoleId(int roleId)
        {
            DAL dal = new DAL();
            return dal.GetTopUsersByRoleId(roleId);
        }

        public static void ChangeUserPassword(int userId, string password)
        {
            DAL dal = new DAL();
            dal.ChangeUserPassword(userId, password);
        }

        public static void ChangeUserUserName(int userId, string userName, ref string errorMessage)
        {
            // Validate User Name Existance :
            errorMessage = ValidateUsernameExistance(userId, userName, errorMessage);
            if (string.IsNullOrEmpty(errorMessage))
            {
                DAL dal = new DAL();
                dal.ChangeUserUserName(userId, userName);
            }
        }

        public static void UpdateUserImage(int userId, string imageName)
        {
            DAL dal = new DAL();
            dal.UpdateUserImage(userId, imageName);
        }

        public static void ActivateUser(int userId)
        {
            DAL dal = new DAL();
            dal.ActivateUser(userId);
        }

        public static void DeActivateUser(int userId)
        {
            DAL dal = new DAL();
            dal.DeActivateUser(userId);
        }

        #endregion

        #region [News Function]

        public static void AddNews(News news)
        {
            DAL dal = new DAL();
            dal.AddNewNews(news);
        }

        public static void DeleteNews(int newsId)
        {
            DAL dal = new DAL();
            dal.DeleteNews(newsId);
        }

        public static void PuplishNewsOnSlider(int newsId)
        {
            DAL dal = new DAL();
            dal.PuplishNewsOnSlider(newsId);
        }

        public static void UnPuplishNewsOnSlider(int newsId)
        {
            DAL dal = new DAL();
            dal.UnPuplishNewsOnSlider(newsId);
        }

        public static void UpdateNews(News news)
        {
            DAL dal = new DAL();
            dal.UpdateNews(news);
        }

        public static News GetNewsById(int newsId)
        {
            DAL dal = new DAL();
            return dal.GetNewsById(newsId);
        }

        public static DataTable GetAllNews()
        {
            DAL dal = new DAL();
            return dal.GetAllNews();
        }

        public static DataTable GetTopFourNews()
        {
            DAL dal = new DAL();
            return dal.GetTopFourNews();
        }

        #endregion

        #region [Content Functions]

        public static void AddContent(Content content)
        {
            DAL dal = new DAL();
            dal.AddNewContent(content);
        }

        public static void IncreaseContentDownLoadCount(int contentId)
        {
            DAL dal = new DAL();
            dal.IncreaseContentDownLoadCount(contentId);
        }

        public static void DeleteContent(int contentId)
        {
            DAL dal = new DAL();
            dal.DeleteContent(contentId);
        }

        public static void UpdateContent(Content content)
        {
            DAL dal = new DAL();
            dal.UpdateContent(content);
        }

        public static Content GetContentById(int contentId)
        {
            DAL dal = new DAL();
            return dal.GetContentById(contentId);
        }

        public static DataTable GetAllContent()
        {
            DAL dal = new DAL();
            return dal.GetAllContent();
        }

        public static DataTable GetTopTenContents()
        {
            DAL dal = new DAL();
            return dal.GetTopTenContents();
        }

        public static DataTable SearchContents(int academicYear, int specialty, int semester, string fileName, int type, int courseId, int courseLevelId, int teacherId)
        {
            DAL dal = new DAL();
            return dal.SearchContents(academicYear, specialty, semester, fileName, type, courseId, courseLevelId, teacherId);
        }

        public static DataTable SearchContents(int teacherId, string fileName, int type)
        {
            DAL dal = new DAL();
            return dal.SearchContents(teacherId, fileName, type);
        }

        public static DataTable GetContentByWriterId(int writerId)
        {
            DAL dal = new DAL();
            return dal.GetContentByWriterId(writerId);
        }


        #endregion

        #region [Comments Functions]

        public static void AddComment(Comment comment)
        {
            DAL dal = new DAL();
            dal.AddComment(comment);
        }

        public static void DeleteComment(int commentId)
        {
            DAL dal = new DAL();
            dal.DeleteComment(commentId);

        }

        public static DataTable GetAllComments()
        {
            DAL dal = new DAL();
            return dal.GetAllComments();
        }

        public static List<Comment> GetCommentsByTeacherId(int teacherId)
        {
            DAL dal = new DAL();
            return dal.GetCommentByTeacherId(teacherId);
        }

        public static List<Comment> GetCommentsByContentId(int contentId)
        {
            DAL dal = new DAL();
            return dal.GetCommentsByContentId(contentId);
        }

        public static List<Comment> GetCommentsByNewsId(int newsId)
        {
            DAL dal = new DAL();
            return dal.GetCommentsByNewsId(newsId);
        }

        public static List<Comment> GetCommentsByArticleId(int articleId)
        {
            DAL dal = new DAL();
            return dal.GetCommentsByArticleId(articleId);
        }

        public static List<Comment> GetCommentsByArticleWriterId(int articleWriterId)
        {
            DAL dal = new DAL();
            return dal.GetCommentsByArticleWriterId(articleWriterId);
        }

        public static List<Comment> GetCommentsByUsefulInfoId(int UsefulInfoId)
        {
            DAL dal = new DAL();
            return dal.GetCommentsByUsefulInfoId(UsefulInfoId);
        }

        public static void ActivateComment(int commentId)
        {
            DAL dal = new DAL();
            dal.ActivateComment(commentId);

        }

        public static void DeActivateComment(int commentId)
        {
            DAL dal = new DAL();
            dal.DeActivateComment(commentId);

        }

        #endregion

        #region [Banner Methods]

        public static void AddBanner(Banner Banner)
        {
            DAL dal = new DAL();
            dal.AddBanner(Banner);
        }

        public static void UpdateBanner(Banner Banner)
        {
            DAL dal = new DAL();
            dal.UpdateBanner(Banner);
        }

        public static DataTable GetAllBanners()
        {
            DAL dal = new DAL();
            return dal.GetAllBanners();
        }

        public static Banner GetActiveRightBanner()
        {
            DAL dal = new DAL();
            return dal.GetActiveRightBanner();
        }

        public static Banner GetActiveCenterBanner()
        {
            DAL dal = new DAL();
            return dal.GetActiveCenterBanner();
        }

        public static Banner GetActiveLeftBanner()
        {
            DAL dal = new DAL();
            return dal.GetActiveLeftBanner();
        }

        public static Banner GetActiveBannerByPositionId(int positionId)
        {
            DAL dal = new DAL();
            return dal.GetActiveBannerByPositionId(positionId);
        }

        public static void ActivateBanner(int bannerId)
        {
            DAL dal = new DAL();
            dal.ActivateBanner(bannerId);
        }

        public static void DeActivateBanner(int bannerId)
        {
            DAL dal = new DAL();
            dal.DeActivateBanner(bannerId);
        }

        public static void DeleteBanner(int bannerId)
        {
            DAL dal = new DAL();
            dal.DeleteBanner(bannerId);
        }


        #endregion

        #region [Useful Websites Methods]

        public static void AddUsefulWebsite(UsefulWebsite usefulWebsite)
        {
            DAL dal = new DAL();
            dal.AddUsefulWebsite(usefulWebsite);
        }

        public static void UpdateUsefulWebsite(UsefulWebsite usefulWebsite)
        {
            DAL dal = new DAL();
            dal.UpdateUsefulWebsite(usefulWebsite);
        }

        public static void DeleteUsefulWebsite(int websiteId)
        {
            DAL dal = new DAL();
            dal.DeleteUsefulWebsite(websiteId);
        }

        public static UsefulWebsite GetlUsefulWebsiteById(int websiteId)
        {
            DAL dal = new DAL();
            return dal.GetlUsefulWebsiteById(websiteId);
        }

        public static DataTable GetAllUsefulWebsites()
        {
            DAL dal = new DAL();
            return dal.GetAllUsefulWebsites();
        }

        public static void ActivateUsefulWebsite(int websiteId)
        {
            DAL dal = new DAL();
            dal.ActivateUsefulWebsite(websiteId);
        }

        public static void DectivateUsefulWebsite(int websiteId)
        {
            DAL dal = new DAL();
            dal.DectivateUsefulWebsite(websiteId);
        }

        public static DataTable GetActiveUsefulWebsites()
        {
            DAL dal = new DAL();
            return dal.GetActiveUsefulWebsites();
        }

        #endregion

        #region [Academic Year Methods]

        public static void AddAcademicYear(AcademicYear academicYear)
        {
            DAL dal = new DAL();
            dal.AddAcademicYear(academicYear);
        }

        public static void DeleteAcademicYear(int academicYearId)
        {
            DAL dal = new DAL();
            dal.DeleteAcademicYear(academicYearId);
        }

        public static DataTable GetAllAcademicYears()
        {
            DAL dal = new DAL();
            return dal.GetAllAcademicYears();
        }

        #endregion

        #region [Specialty Methods]

        public static void AddSpecialty(Specialty specialty)
        {
            DAL dal = new DAL();
            dal.AddSpecialty(specialty);
        }

        public static void UpdateSpecialty(Specialty specialty)
        {
            DAL dal = new DAL();
            dal.UpdateSpecialty(specialty);
        }

        public static void DeleteSpecialty(int specialtyId)
        {
            DAL dal = new DAL();
            dal.DeleteSpecialty(specialtyId);
        }

        public static DataTable GetAllSpecialties()
        {
            DAL dal = new DAL();
            return dal.GetAllSpecialties();
        }

        public static Specialty GetSpecialtyById(int specialtyId)
        {
            DAL dal = new DAL();
            return dal.GetSpecialtyById(specialtyId);
        }

        #endregion

        #region [Course Methods]

        public static void AddCourse(Course course)
        {
            DAL dal = new DAL();
            dal.AddCourse(course);
        }

        public static void UpdateCourse(Course course)
        {
            DAL dal = new DAL();
            dal.UpdateCourse(course);
        }

        public static void DeleteCourse(int courseId)
        {
            DAL dal = new DAL();
            dal.DeleteCourse(courseId);
        }

        public static Course GetCourseById(int courseId)
        {
            DAL dal = new DAL();
            return dal.GetCourseById(courseId);
        }

        public static DataTable GetAllCourses()
        {
            DAL dal = new DAL();
            return dal.GetAllCourses();
        }

        public static DataTable GetCoursesBySpecialtyId(int specialtyId)
        {
            DAL dal = new DAL();
            return dal.GetCoursesBySpecialtyId(specialtyId);
        }

        #endregion

        #region [Level Methods]

        public static void AddLevel(Level level)
        {
            DAL dal = new DAL();
            dal.AddLevel(level);
        }

        public static void UpdateLevel(Level level)
        {
            DAL dal = new DAL();
            dal.UpdateLevel(level);
        }

        public static void DeleteLevel(int levelId)
        {
            DAL dal = new DAL();
            dal.DeleteLevel(levelId);
        }

        public static DataTable GetAllLevels()
        {
            DAL dal = new DAL();
            return dal.GetAllLevels();
        }

        public static Level GetLevelById(int GetLevelById)
        {
            DAL dal = new DAL();
            return dal.GetLevelById(GetLevelById);
        }

        #endregion

        #region [Course Level Methods]

        public static DataTable GetCourseLevelsByCourseId(int courseId)
        {
            DAL dal = new DAL();
            return dal.GetCourseLevelsByCourseId(courseId);
        }

        public static void DeleteCourseLevel(int courseId, int levelId)
        {
            DAL dal = new DAL();
            dal.DeleteCourseLevel(courseId, levelId);
        }

        public static void AddCourseLevel(int courseId, int levelId)
        {
            DAL dal = new DAL();
            dal.AddCourseLevel(courseId, levelId);
        }

        #endregion

        #region [Teacher Course Methods]

        public static void AddTeacherCourse(int courseId, int teacherId)
        {
            DAL dal = new DAL();
            dal.AddTeacherCourse(courseId, teacherId);
        }

        public static void DeleteTeacherCourse(int courseId, int teacherId)
        {
            DAL dal = new DAL();
            dal.DeleteTeacherCourse(courseId, teacherId);
        }

        public static DataTable GetTeachersByCourseId(int courseId)
        {
            DAL dal = new DAL();
            return dal.GetTeachersByCourseId(courseId);
        }

        public static List<int> GetCoursesIdsByTeacherId(int teacherId)
        {
            DAL dal = new DAL();
            return dal.GetCoursesIdsByTeacherId(teacherId);
        }

        #endregion

        #region [Specialty Course Methods]

        public static void AddSpecialtyCourse(int courseId, int specialtyId)
        {
            DAL dal = new DAL();
            dal.AddSpecialtyCourse(courseId, specialtyId);
        }

        public static void DeleteSpecialtyCourse(int courseId, int specialtyId)
        {
            DAL dal = new DAL();
            dal.DeleteSpecialtyCourse(courseId, specialtyId);
        }

        public static DataTable GetSpecialtyCoursesBySpecialtyId(int specialtyId)
        {
            DAL dal = new DAL();
            return dal.GetSpecialtyCoursesBySpecialtyId(specialtyId);
        }

        #endregion

        #region [Validation Methods]

        private static string ValidateUsernameExistance(int userId, string userName, string errorMessage)
        {
            DataTable dtAllUsers = BLL.GetAllUsers();
            if (dtAllUsers != null && (dtAllUsers.Rows != null && dtAllUsers.Rows.Count > 0))
            {
                foreach (DataRow row in dtAllUsers.Rows)
                {
                    if (Convert.ToInt32(row["USER_ID"]) != userId &&
                        string.Equals(row["EMAIL"].ToString(), userName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        errorMessage = "اسم المستخدم موجود";
                        break;
                    }
                }
            }
            return errorMessage;
        }

        #endregion

        #region [Article Methods]

        public static void AddNewArticle(Article article)
        {
            DAL dal = new DAL();
            dal.AddNewArticle(article);
        }

        public static void DeleteArticle(int articleId)
        {
            DAL dal = new DAL();
            dal.DeleteArticle(articleId);
        }

        public static void UpdateArticle(Article article)
        {
            DAL dal = new DAL();
            dal.UpdateArticle(article);
        }

        public static Article GetArticleById(int articleId)
        {
            DAL dal = new DAL();
            return dal.GetArticleById(articleId);
        }

        public static DataTable GetAllArticle()
        {
            DAL dal = new DAL();
            return dal.GetAllArticle();
        }

        public static DataTable GetTopTenArticles()
        {
            DAL dal = new DAL();
            return dal.GetTopTenArticles();
        }

        public static DataTable SearchArticles(int wrtierId, string articleTitle)
        {
            DAL dal = new DAL();
            return dal.SearchArticles(wrtierId, articleTitle);
        }
        public static DataTable GetArticlesByWriterId(int wrtierId)
        {
            DAL dal = new DAL();
            return dal.GetArticlesByWriterId(wrtierId);
        }

        #endregion

        #region [Transaction History]

        public static DataTable GetTransactionsHistoryByUserId(int userId, int recordsCount)
        {
            DAL dal = new DAL();
            return dal.GetTransactionsHistoryByUserId(userId, recordsCount);
        }

        public static void DeleteTransactionsHistoryByTransactionId(int transactionId)
        {
            DAL dal = new DAL();
            dal.DeleteTransactionsHistoryByTransactionId(transactionId);
        }

        #endregion

        #region [UsefulInfo Methods]

        public static void AddNewUsefulInfo(UsefulInfo UsefulInfo)
        {
            DAL dal = new DAL();
            dal.AddNewUsefulInfo(UsefulInfo);
        }

        public static void DeleteUsefulInfo(int id)
        {
            DAL dal = new DAL();
            dal.DeleteUsefulInfo(id);
        }

        public static void UpdateUsefulInfo(UsefulInfo UsefulInfo)
        {
            DAL dal = new DAL();
            dal.UpdateUsefulInfo(UsefulInfo);
        }

        public static UsefulInfo GetUsefulInfoById(int UsefulInfoId)
        {
            DAL dal = new DAL();
            return dal.GetUsefulInfoById(UsefulInfoId);
        }

        public static DataTable GetAllUsefulInfo()
        {
            DAL dal = new DAL();
            return dal.GetAllUsefulInfo();
        }

        public static DataTable GetTopTenUsefulInfo()
        {
            DAL dal = new DAL();
            return dal.GetTopTenUsefulInfo();
        }

        #endregion
    }
}
