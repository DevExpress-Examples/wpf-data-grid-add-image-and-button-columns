Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Namespace GridControlCellTemplate.Model

    Public Class Record
        Inherits BindableBase

        Public Property Text As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property IsRead As Boolean
            Get
                Return GetValue(Of Boolean)()
            End Get

            Set(ByVal value As Boolean)
                SetValue(value)
            End Set
        End Property

        Public Sub New(ByVal text As String)
            Me.Text = text
        End Sub

        Public Shared Iterator Function GetData(ByVal quantity As Integer) As IEnumerable(Of Record)
            Dim sentences = Regex.Split(File.ReadAllText("Model/Sentences.txt"), "(?<=[\.!\?])\s+")
            Dim gen = New Random(42)
            For i As Integer = 0 To quantity - 1
                Yield New Record(sentences(gen.[Next](sentences.Length)))
            Next
        End Function
    End Class
End Namespace
