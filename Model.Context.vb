﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class GP_desarrolloEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=GP_desarrolloEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property ClientsView() As DbSet(Of ClientsView)
    Public Overridable Property ExchangeRateView() As DbSet(Of ExchangeRateView)
    Public Overridable Property ComponentsView() As DbSet(Of ComponentsView)
    Public Overridable Property DetailComponetsView() As DbSet(Of DetailComponetsView)
    Public Overridable Property ItemComponentsView() As DbSet(Of ItemComponentsView)
    Public Overridable Property ItemsView() As DbSet(Of ItemsView)
    Public Overridable Property ItemsGroupView() As DbSet(Of ItemsGroupView)

End Class
