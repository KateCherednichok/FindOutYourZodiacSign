using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindOutYourZodiacSign.Models
{
    class ZodiacSignModel
    {

        private DateTime _birthDate = DateTime.Today;
        private int? _age;
        private string _westernZodiacSign = String.Empty;
        private string _chineseZodiacSign = String.Empty;

        public int? Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

       
        public string WesternZodiacSign
        {
            get { return _westernZodiacSign; }
            set { _westernZodiacSign = value; }
        }

        public string ChineseZodiacSign
        {
            get { return _chineseZodiacSign; }
            set { _chineseZodiacSign = value; }
        }
    }
}
