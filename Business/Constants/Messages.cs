using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";

        public static string CarNameInvalid = "Araç İsmi Geçersiz";

        public static string MaintenanceTime="Sistem Bakımda";

        public static string CarListed = "Ürünler Listelendi";

        public static string CarCountOfColorError = "Bir renkte en fazla 10 araç olabilir.";

        public static string ColorLimitExceded = "Renk limiti aşıldığı için yeni renk eklenemiyor";

        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string CarImageLimitExceeded = "En fazla 5 resim ekleyebilirsiniz";

        public static string ColorAdded ="Renk Eklendi";

        public static string ColorDeleted ="Renk Silindi";

        public static string ColorUpdated = "Renk Güncellendi";

        public static string BrandAdded ="Marka Eklendi";
        
        public static string BrandUpdated = "Marka Güncellendi";
        
        public static string BrandDeleted ="Marka Silindi";

        public static string UserAdded = "Kullanıcı Eklendi";

        public static string UserDeleted = "Kullanıcı Silindi";

        public static string UserUpdated = "Kullanıcı Güncellendi";

        public static string AccessTokenCreated ="Token Oluşturuldu";

        public static string SuccessfulLogin="Başarılı Giriş";

        public static string PasswordError="Parola Hatası";

        public static string UserNotFound ="Kullanıcı Bulunamadı";

        public static string UserRegistered ="Kayıt Oldu";

        public static string UserAlreadyExists ="Kullanıcı Mevcut";
    }
}
