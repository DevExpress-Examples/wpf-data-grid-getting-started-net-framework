Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.Data.Entity

Namespace DXGridGetStarted
	Public Class ViewModel
		Inherits ViewModelBase

		Private northwindDBContext As NorthwindEntities
		Public Sub New()
			If IsInDesignMode Then
				Orders = New ObservableCollection(Of Order)()
				Shippers = New ObservableCollection(Of Shipper)()
			Else
				northwindDBContext = New NorthwindEntities()

				northwindDBContext.Orders.Load()
				Orders = northwindDBContext.Orders.Local

				northwindDBContext.Shippers.Load()
				Shippers = northwindDBContext.Shippers.Local
			End If
			ValidateAndSaveCommand = New DelegateCommand(AddressOf ValidateAndSave)
		End Sub
		Public Property Orders() As ObservableCollection(Of Order)
			Get
				Return GetValue(Of ObservableCollection(Of Order))()
			End Get
			Private Set(ByVal value As ObservableCollection(Of Order))
				SetValue(value)
			End Set
		End Property
		Public Property Shippers() As ObservableCollection(Of Shipper)
			Get
				Return GetValue(Of ObservableCollection(Of Shipper))()
			End Get
			Private Set(ByVal value As ObservableCollection(Of Shipper))
				SetValue(value)
			End Set
		End Property
		Private privateValidateAndSaveCommand As DelegateCommand
		Public Property ValidateAndSaveCommand() As DelegateCommand
			Get
				Return privateValidateAndSaveCommand
			End Get
			Private Set(ByVal value As DelegateCommand)
				privateValidateAndSaveCommand = value
			End Set
		End Property
		Private Sub ValidateAndSave()
			northwindDBContext.SaveChanges()
		End Sub
	End Class
End Namespace