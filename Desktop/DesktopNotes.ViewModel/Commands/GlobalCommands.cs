using System.Windows.Input;

namespace DesktopNotify.ViewModel.Commands
{
    public class GlobalCommands
    {
        public GlobalCommands()
        {
            NewTaskCommand = new LambdaCommand(OnNewTaskCommandExecuted, CanNewTaskCommandExecute);
        }

        #region command for views(day, week, month)
        public ICommand NewTaskCommand { get; private set; }
        private bool CanNewTaskCommandExecute(object p) => true;

        private void OnNewTaskCommandExecuted(object p)
        {
            Globals.Manager.ShowManager("edit");
            //TODO: return values
            //TODO: save date
        }
        #endregion
    }
}
