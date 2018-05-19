Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinSolution.Module
	<DefaultClassOptions> _
	Public Class DomainObject1
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _propertyName1 As String
		<RuleRequiredField("1", DefaultContexts.Save)> _
		Public Property PropertyName1() As String
			Get
				Return _propertyName1
			End Get
			Set(ByVal value As String)
				SetPropertyValue("PropertyName1", _propertyName1, value)
			End Set
		End Property
		Private _propertyName2 As String
		<RuleRequiredField("2", DefaultContexts.Save)> _
		Public Property PropertyName2() As String
			Get
				Return _propertyName2
			End Get
			Set(ByVal value As String)
				SetPropertyValue("PropertyName2", _propertyName2, value)
			End Set
		End Property
	End Class

End Namespace
