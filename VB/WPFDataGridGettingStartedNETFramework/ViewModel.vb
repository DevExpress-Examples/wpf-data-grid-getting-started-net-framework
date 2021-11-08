Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System.Collections.ObjectModel
Imports System.Data.Entity

Namespace WPFDataGridGettingStartedNETFramework

    Public Class ViewModel
        Inherits ViewModelBase

        Private northwindDBContext As NorthwindEntities

        Public Property Orders As ObservableCollection(Of Order)
            Get
                Return GetValue(Of ObservableCollection(Of Order))()
            End Get

            Private Set(ByVal value As ObservableCollection(Of Order))
                SetValue(value)
            End Set
        End Property

        Public Property Shippers As ObservableCollection(Of Shipper)
            Get
                Return GetValue(Of ObservableCollection(Of Shipper))()
            End Get

            Private Set(ByVal value As ObservableCollection(Of Shipper))
                SetValue(value)
            End Set
        End Property

        Public Sub New()
            northwindDBContext = New NorthwindEntities()
            If IsInDesignMode Then
                Orders = New ObservableCollection(Of Order)()
                Shippers = New ObservableCollection(Of Shipper)()
            Else
                northwindDBContext.Orders.Load()
                Orders = northwindDBContext.Orders.Local
                northwindDBContext.Shippers.Load()
                Shippers = northwindDBContext.Shippers.Local
            End If
        End Sub

        <Command>
        Public Sub ValidateAndSave(ByVal args As RowValidationArgs)
            northwindDBContext.SaveChanges()
        End Sub
    End Class
End Namespace
