using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoscowCamerat.Domain
{
    [MetadataType(typeof(AccountMetaData))]
    public partial class Account
    {
    }
    public partial class AccountMetaData
    {
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Не корректный E-Mail.")]
        public string email { get; set; }
    }

    [MetadataType(typeof(PhotoMetaData))]
    public partial class Photo
    {
    }

    public partial class PhotoMetaData
    {
        [DisplayName("Название")]
        public string eventDesc { get; set; }

        [DisplayName("День")]
        public string eventDay { get; set; }

        [DisplayName(".Месяц.Год - пример: .01.2020")]
        public string eventMonthYear { get; set; }

        [DisplayName("Время")]
        public string eventTime { get; set; }

        [DisplayName("Время")]
        public DateTime dateConcert { get; set; }

        [DisplayName("Сортировка")]
        public int sort { get; set; }
    }
}
