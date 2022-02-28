using BaseNotifyPropertyChanged;
using System;

namespace DesktopNotes.ViewModel.ViewModels
{
    public class DayViewModel : BaseNotify
    {
        private DayOfWeek _currentDay;
        private DateTime _currentDate;
        //private DayControl _dayControl;


        public DayOfWeek CurrentDay
        {
            get => _currentDay;
            private set => Set(ref _currentDay, value);
        }

        public DateTime CurrentDate
        {
            get => _currentDate;
            private set => Set(ref _currentDate, value);
        }

        //public DayControl dayControl
        //{
        //    get => _dayControl;
        //    private set => Set(ref _dayControl, value);
        //}

        public DayViewModel()
        {
            CurrentDate = DateTime.Now;
            CurrentDay = DateTime.Now.DayOfWeek;
            //dayControl = new DayControl();
        }
    }
}
