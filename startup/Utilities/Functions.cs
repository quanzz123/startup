

using System.Security.Cryptography;
using System.Text;

namespace startup.Utilities
{
    public class Functions
    {
        // khai báo các biến nhằm mục đích lưu lại thông tin đăng nhập
        // trong quá trình thực hiện, nếu kiểm tra không có thông tin này 
        // sẽ bắt buộc phải đăng nhập lại
        public static int _UserID = 0;
        public static string _UserName = String.Empty;
        public static string _Email = String.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;

        public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }

        public static string getCurentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBui = new StringBuilder();
            for ( int i = 0; i < result.Length; i++)
            {
                strBui.Append(result[i].ToString("x2"));
            }
            return strBui.ToString();
        }
        public static string MD5Password(string? text) {
            string str = MD5Hash(text);
            // lặp thêm 5 lần mã háo xấu đảm bào tính bảo mật
            // mỗi lần  lặp nhân đôi mã hoá, ở giữa thêm "_"
            //có thể làm cách khác để tăng tính bảo mật ở đây
            for (int i = 0; i<= 5; i++)
            {
                str = MD5Hash(str + "_" + str);

            }
            return str;
        }

        public static bool IsLogin()
        {
            if(string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserID <= 0))
            {
                return false;
            }
            return true;
        }
    }
}
