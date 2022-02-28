using BaseNotifyPropertyChanged;
using System.Windows.Media;

namespace DesktopNotes.Model.ModelsForView
{
    public class ComboBoxData : BaseNotify
    {
        private Brush _labelsColor;
        private string _textConst;

        public Brush LabelsColor
        {
            get => _labelsColor;
            private set => Set(ref _labelsColor, value);
        }

        public string TextConst
        {
            get => _textConst;
            private set => Set(ref _textConst, value);
        }

        public ComboBoxData(string HEXcolor, string text) 
        {
            var converter = new BrushConverter();
            LabelsColor = (Brush)converter.ConvertFromString(HEXcolor);
            TextConst = text;
        }
    }
}