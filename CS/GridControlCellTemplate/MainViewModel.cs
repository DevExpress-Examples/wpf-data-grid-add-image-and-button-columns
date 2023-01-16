using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using GridControlCellTemplate.Model;

namespace GridControlCellTemplate
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Record> Source { get; } = new ObservableCollection<Record>(Record.GetData(100));

        [Command]
        public void RemoveRow(Record item) {
            Source.Remove(item);
        }
    }
}