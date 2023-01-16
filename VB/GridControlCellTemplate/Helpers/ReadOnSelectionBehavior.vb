Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports GridControlCellTemplate.Model
Imports System.Linq

Namespace GridControlCellTemplate.Helpers

    Friend Class ReadOnSelectionBehavior
        Inherits Behavior(Of GridControl)

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AddHandler AssociatedObject.SelectionChanged, AddressOf AssociatedObject_SelectionChanged
            AddHandler AssociatedObject.SelectedItemChanged, AddressOf AssociatedObject_SelectedItemChanged
        End Sub

        Private Sub AssociatedObject_SelectedItemChanged(ByVal sender As Object, ByVal e As SelectedItemChangedEventArgs)
            Dim selectedItem As Record = Nothing
            If CSharpImpl.__Assign(selectedItem, TryCast(AssociatedObject.SelectedItem, Record)) IsNot Nothing Then
                selectedItem.IsRead = True
            End If
        End Sub

        Protected Overrides Sub OnDetaching()
            MyBase.OnDetaching()
            RemoveHandler AssociatedObject.SelectionChanged, AddressOf AssociatedObject_SelectionChanged
            RemoveHandler AssociatedObject.SelectedItemChanged, AddressOf AssociatedObject_SelectedItemChanged
        End Sub

        Private Sub AssociatedObject_SelectionChanged(ByVal sender As Object, ByVal e As GridSelectionChangedEventArgs)
            For Each item In AssociatedObject.SelectedItems.OfType(Of Record)()
                item.IsRead = True
            Next
        End Sub

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
