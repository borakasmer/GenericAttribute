using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class BaseEntity
    {
        // DB’de karşılığı olmayan kolonların, [NotMapped] olarak işaretlenmesi gerekmektedir.Aksi takdirde hata alınır.
        private DateTime dateTime;
        [NotMapped]
        public DateTime UsedTime { get { this.dateTime = DateTime.Now; return dateTime; } set { } }

        // “WriteLog()” kullanıldığı zaman, ekrana kullanım zamanı log olarak basılmaktadır.
        public void WriteLog()
        {
            Console.WriteLine("".PadRight(40, '*'));
            Console.WriteLine($"UseTime: {UsedTime.ToLongDateString()}");
            Console.WriteLine("".PadRight(40, '*'));
        }
    }
}
