using BaseNotifyPropertyChanged;
using DesktopNotes.Model.Enums;
using DesktopNotify.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopNotes.ViewModel.ViewModels
{
    public class MainWindowViewModel : BaseNotify
    {
        public Dictionary<DesktopNotes.Model.MainModels.Task, DateTime> Tasks; //TODO: add data

        private ObservableCollection<Page> _pages; //???ObservableDictionary
        //private DisplayState _displayState;
        private DateTime _currentDateMain;

        #region Get/Set
        public ObservableCollection<Page> Pages
        {
            get => _pages;
            private set => Set(ref _pages, value);
        }
    
        //public DisplayState displayState
        //{
        //    get => _displayState;
        //    private set => Set(ref _displayState, value);
        //}

        public DateTime CurrentDateMain
        {
            get => _currentDateMain;
            set => Set(ref _currentDateMain, value);
        }
        #endregion

        public MainWindowViewModel()
        {
            //TODO:Serialize display state
            Globals.displayState = DisplayState.Week;
            CurrentDateMain = DateTime.Now;           
            Tasks = new Dictionary<DesktopNotes.Model.MainModels.Task, DateTime>();
            InitializePagesCollection();
            DisplayDayCommand = new LambdaCommand(OnDisplayDayCommandExecuted, CanDisplayDayCommandExecute);
            DisplayWeekCommand = new LambdaCommand(OnDisplayWeekCommandExecuted, CanDisplayWeekCommandExecute);
            DisplayMonthCommand = new LambdaCommand(OnDisplayMonthCommandExecuted, CanDisplayMonthCommandExecute);
            EditCommand = new LambdaCommand(OnEditCommandExecuted, CanEditCommandExecute);
            NextPageCommand = new LambdaCommand(OnNextPageCommandExecuted, CanNextPageCommandExecute);
            PreviousPageCommand = new LambdaCommand(OnPreviousPageCommandExecuted, CanPreviousPageCommandExecute);
        }

        private void InitializePagesCollection()
        {
            Pages = new ObservableCollection<Page>();
            AddPage(new Day());
            AddPage(new Week());
            AddPage(new Month());
        }

        private void AddPage(Page p)
        {
            Page tempPage = p;
            Pages.Add(tempPage);
        }

        #region commands
        public ICommand DisplayDayCommand { get; private set; }
        private bool CanDisplayDayCommandExecute(object p) => true;

        private void OnDisplayDayCommandExecuted(object p)
        {
            Globals.displayState = DisplayState.Day; //TODO: add data to new page
        }

        public ICommand DisplayWeekCommand { get; private set; }
        private bool CanDisplayWeekCommandExecute(object p) => true;

        private void OnDisplayWeekCommandExecuted(object p)
        {
            Globals.displayState = DisplayState.Week;
        }

        public ICommand DisplayMonthCommand { get; private set; }
        private bool CanDisplayMonthCommandExecute(object p) => true;

        private void OnDisplayMonthCommandExecuted(object p)
        {
            Globals.displayState = DisplayState.Month;
        }

        public ICommand NextPageCommand { get; private set; }
        private bool CanNextPageCommandExecute(object p) => true;

        private void OnNextPageCommandExecuted(object p)
        {
            //TODO: next (month) navigation
            switch (Globals.displayState)
            {
                case DisplayState.Day:
                    Globals.dateManager.DayVM.dayControl.DayUpdater(1);
                    break;
                case DisplayState.Week:
                    for(int i = 6; i >= 0; --i)
                    {
                        Globals.dateManager.WeekVM.dayControls[i].DayUpdater(7);
                    }
                    break;
                case DisplayState.Month:
                    break;
                default:
                    break;
            }
        }

        public ICommand PreviousPageCommand { get; private set; }
        private bool CanPreviousPageCommandExecute(object p) => true;

        private void OnPreviousPageCommandExecuted(object p)
        {
            //TODO: previous month navigation
            switch (Globals.displayState)
            {
                case DisplayState.Day:
                    Globals.dateManager.DayVM.dayControl.DayUpdater(-1);
                    break;
                case DisplayState.Week:
                    for (int i = 6; i >= 0; --i)
                    {
                        Globals.dateManager.WeekVM.dayControls[i].DayUpdater(-7);
                    }
                    break;
                case DisplayState.Month:
                    break;
                default:
                    break;
            }
        }

        public ICommand EditCommand { get; private set; }
        private bool CanEditCommandExecute(object p) => true;

        private void OnEditCommandExecuted(object p)
        {
            //TODO: edit return result logic
            Globals.Manager.ShowManager("edit");

            switch (Globals.displayState)
            {
                case DisplayState.Day:
                    DesktopNotes.Model.MainModels.Task test = Globals.Manager.GetReturnValues("EditTaskWindow") as DesktopNotes.Model.MainModels.Task; //TODO: delete test info
                    Tasks.Add(Globals.Manager.GetReturnValues("EditTaskWindow") as DesktopNotes.Model.MainModels.Task, Globals.dateManager.GetDate("DayVM"));
                    MessageBox.Show(Tasks[test].ToString()); //TODO: delete test info
                    break;
                case DisplayState.Week:
                    
                    break;
                case DisplayState.Month:
                    break;
                default:
                    break;
            }
            //TODO: switch expression with dateView type
        }
        #endregion
    }
}
