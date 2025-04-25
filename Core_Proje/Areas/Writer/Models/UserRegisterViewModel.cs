using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lutfen Adınızı giriniz")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Lutfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lutfen resim  giriniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lutfen Kullanıcı Adını giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lutfen şifrenizi giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lutfen tekrar şifre giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lutfen mail giriniz")]
        public string Mail {  get; set; }


    }
}
