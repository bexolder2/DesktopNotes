using BaseNotifyPropertyChanged;
using System;

namespace DesktopNotes.ViewModel.ViewModels
{
    public class DayControlViewModel : BaseNotify
    {
        private DateTime _dayDate;

        public DateTime DayDate
        {
            get => _dayDate;
            private set => Set(ref _dayDate, value);
        }

        public DayControlViewModel()
        {
            DayDate = DateTime.Now;
        }

        public void DayUpdater(double multiplier)
        {
            DayDate = Globals.dateManager.SetDate(DayDate, DayDate, multiplier);
        }
    }
}
