Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports GridControlCellTemplate.Model

Namespace GridControlCellTemplate

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Source As ObservableCollection(Of Record) = New ObservableCollection(Of Record)(Record.GetData(100))

        <Command>
        Public Sub RemoveRow(ByVal item As Record)
            Source.Remove(item)
        End Sub
    End Class
End Namespace
