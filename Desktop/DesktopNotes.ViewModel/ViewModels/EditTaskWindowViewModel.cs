using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BaseNotifyPropertyChanged;
using DesktopNotes.Model.Constants;
using DesktopNotes.Model.Enums;
using DesktopNotes.Model.ModelsForView;
using DesktopNotify.ViewModel.Commands;

namespace DesktopNotes.ViewModel.ViewModels
{
    public class EditTaskWindowViewModel : BaseNotify
    {
        private List<ComboBoxData> _cbData;
        private ComboBoxData _cbSolo;
        private Model.MainModels.Task _task;

        public Model.MainModels.Task TmpTask
        {
            get => _task;
            set => Set(ref _task, value);
        }

        public ComboBoxData cbSolo
        {
            get => _cbSolo;
            set => Set(ref _cbSolo, value);
        }

        public List<ComboBoxData> CBData
        {
            get => _cbData;
            set => Set(ref _cbData, value);
        }

        public EditTaskWindowViewModel()
        {
            TmpTask = new Model.MainModels.Task();

            SaveCommand = new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);

            CBData = new List<ComboBoxData>();
            InitializecbData(StringConstants.BlueForEditComboBox, StringConstants.TodoDefinitelyText); //  0, 148, 204
            InitializecbData(StringConstants.GreenForEditComboBox, StringConstants.TodoNeedTodoText); //   0, 178, 72
            InitializecbData(StringConstants.OrangeForEditComboBox, StringConstants.TodoDesirableText); //   249, 168, 37
        }

        private void InitializecbData(string HEX, string text)
        {
            cbSolo = new ComboBoxData(HEX, text);
            CBData.Add(cbSolo);
        }


        #region commands
        public ICommand SaveCommand { get; private set; }
        private bool CanSaveCommandExecute(object p) => true;

        private void OnSaveCommandExecuted(object p)
        {
            MessageBox.Show($"Task: {TmpTask.task}\nStatus: {cbSolo.TextConst}");
            switch (cbSolo.TextConst)
            {
                case StringConstants.TodoDefinitelyText:
                    TmpTask.statusColor = StatusColor.Blue;
                    break;
                case StringConstants.TodoNeedTodoText:
                    TmpTask.statusColor = StatusColor.Green;
                    break;
                case StringConstants.TodoDesirableText:
                    TmpTask.statusColor = StatusColor.Orange;
                    break;
            }
            //Globals.Manager.SetReturnValues<Model.MainModels.Task>(TmpTask, "EditTaskWindow");
            //Globals.Manager.CloseManager("edit");
        }

        public ICommand CancelCommand { get; private set; }
        private bool CanCancelCommandExecute(object p) => true;

        private void OnCancelCommandExecuted(object p)
        {
            //Globals.Manager.CloseManager("edit");
        }
        #endregion
    }
}