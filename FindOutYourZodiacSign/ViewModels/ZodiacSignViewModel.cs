using CommunityToolkit.Mvvm.Input;
using FindOutYourZodiacSign.Models;
using System.ComponentModel;
using System.Windows;

namespace FindOutYourZodiacSign.ViewModels
{
    class ZodiacSignViewModel : INotifyPropertyChanged
    {
    
        private const int MaxAge = 135;
        private ZodiacSignModel _zodiacSignModel = new ZodiacSignModel();

        public DateTime BirthdayDate
        {
            get => _zodiacSignModel.BirthDate;
            set
            {
                _zodiacSignModel.BirthDate = value;
                OnPropertyChanged(nameof(BirthdayDate));
            }
        }

        public int? Age
        {
            get => _zodiacSignModel.Age;
            private set
            {
                _zodiacSignModel.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string WesternZodiacSign
        {
            get => _zodiacSignModel.WesternZodiacSign;
            private set
            {
                _zodiacSignModel.WesternZodiacSign = value;
                OnPropertyChanged(nameof(WesternZodiacSign));
            }
        }

        public string ChineseZodiacSign
        {
            get => _zodiacSignModel.ChineseZodiacSign;
            private set
            {
                _zodiacSignModel.ChineseZodiacSign = value;
                OnPropertyChanged(nameof(ChineseZodiacSign));
            }
        }

        public RelayCommand CalculateCommand { get; }
        public RelayCommand ExitCommand { get; }

        public ZodiacSignViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }

        private void Calculate()
        {
            if (CanExecute(BirthdayDate))
            {
                SetBirthInfo(ZodiacUtils.CalculateAge(BirthdayDate),
                    ZodiacUtils.GetWesternZodiacSign(BirthdayDate),
                    ZodiacUtils.GetChineseZodiacSign(BirthdayDate));
                if (ZodiacUtils.IfItIsBirthdayToday(BirthdayDate))
                {
                    MessageBox.Show("Вітаємо з Днем Народження!");
                }
            }
            else
            {
                SetBirthInfo(null, string.Empty, string.Empty);
                if (BirthdayDate.CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show("Не коректна дата народження! Ви з майбутнього!");
                }
                else
                {
                    MessageBox.Show("Не коректна дата народження! Ви не можете бути старшими за 135 років!");
                }

            }
        }

        private void SetBirthInfo(int? age, string westernSign, string chineseSign)
        {
            Age = age;
            WesternZodiacSign = westernSign;
            ChineseZodiacSign = chineseSign;
        }

        private bool CanExecute(DateTime date)
        {
            return ZodiacUtils.CalculateAge(BirthdayDate) <= MaxAge && date.CompareTo(DateTime.Now) < 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
