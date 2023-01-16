using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using GridControlCellTemplate.Model;
using System.Linq;

namespace GridControlCellTemplate.Helpers
{
    class ReadOnSelectionBehavior : Behavior<GridControl>
    {
        protected override void OnAttached() {
            base.OnAttached();

            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
            AssociatedObject.SelectedItemChanged += AssociatedObject_SelectedItemChanged;
        }

        private void AssociatedObject_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e) {
            var selectedItem = AssociatedObject.SelectedItem as Record;

            if (selectedItem != null) {
                selectedItem.IsRead = true;
            }
        }

        protected override void OnDetaching() {
            base.OnDetaching();

            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            AssociatedObject.SelectedItemChanged -= AssociatedObject_SelectedItemChanged;
        }

        private void AssociatedObject_SelectionChanged(object sender, GridSelectionChangedEventArgs e) {
            foreach (var item in AssociatedObject.SelectedItems.OfType<Record>()) {
                item.IsRead = true;
            }
        }
    }
}