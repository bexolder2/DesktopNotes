using BaseNotifyPropertyChanged;
using DesktopNotes.Model.Enums;
using System;

namespace DesktopNotes.Model.MainModels
{
    public class Task : BaseNotify
    {
        private string _task;
        private DateTime _date;
        private StatusColor _statusColor;

        public Task()
        {

        }

        public Task(string taskInfo, DateTime selectedDate, StatusColor sc)
        {
            task = taskInfo;
            Date = selectedDate;
            statusColor = sc;
        }

        public string task
        {
            get => _task;
            set => Set(ref _task, value);
        }

        public DateTime Date
        {
            get => _date;
            set => Set(ref _date, value);
        }

        public StatusColor statusColor
        {
            get => _statusColor;
            set => Set(ref _statusColor, value);
        }
    }
}
