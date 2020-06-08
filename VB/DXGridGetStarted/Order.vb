﻿Imports System.Collections.Generic
Imports System

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Namespace DXGridGetStarted

	Partial Public Class Order
		<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")>
		Public Sub New()
			Me.Order_Details = New HashSet(Of Order_Detail)()
		End Sub

		Public Property OrderID() As Integer
		Public Property CustomerID() As String
		Public Property EmployeeID() As Integer?
		Public Property OrderDate() As DateTime?
		Public Property RequiredDate() As DateTime?
		Public Property ShippedDate() As DateTime?
		Public Property ShipVia() As Integer?
		Public Property Freight() As Decimal?
		Public Property ShipName() As String
		Public Property ShipAddress() As String
		Public Property ShipCity() As String
		Public Property ShipRegion() As String
		Public Property ShipPostalCode() As String
		Public Property ShipCountry() As String

		Public Overridable Property Customer() As Customer
		Public Overridable Property Employee() As Employee
		<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")>
		Public Overridable Property Order_Details() As ICollection(Of Order_Detail)
		Public Overridable Property Shipper() As Shipper
	End Class
End Namespace
