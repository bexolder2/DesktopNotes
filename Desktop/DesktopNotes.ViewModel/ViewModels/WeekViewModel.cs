using BaseNotifyPropertyChanged;
using System.Collections.Generic;

namespace DesktopNotes.ViewModel.ViewModels
{
    public class WeekViewModel : BaseNotify
    {
        //private List<DayControl> _dayControls;

        //public List<DayControl> dayControls
        //{
        //    get => _dayControls;
        //    private set => Set(ref _dayControls, value);
        //}

        public WeekViewModel()
        {
            //dayControls = new List<DayControl>();
            //for(uint i = 0; i < 7; ++i)
            //{
            //    dayControls.Add(new DayControl());
            //}
            DateInitialize();
        }

        private void DateInitialize()
        {
            for(int i = 0; i < 7; ++i)
            {
                //dayControls[i].DayUpdater(i);
            }
        }
    }
}
