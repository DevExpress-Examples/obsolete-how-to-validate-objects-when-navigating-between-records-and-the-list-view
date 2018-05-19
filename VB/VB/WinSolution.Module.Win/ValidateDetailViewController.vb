Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.SystemModule

Namespace WinSolution.Module.Win
	Public Class ValidateDetailViewController
		Inherits ViewController
		Private controller As WinDetailViewController = Nothing
		Private previouslySelectedObject As Object = Nothing
		Public Sub New()
			TargetObjectType = GetType(DomainObject1)
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			controller = Frame.GetController(Of WinDetailViewController)()
			' Prevents asking about saving. 
			controller.SuppressConfirmation = True
			If TypeOf View Is DetailView AndAlso View.IsRoot Then
				' Raises when closing the detail view.
				AddHandler (CType(Frame, WinWindow)).Closing, AddressOf WindowClosing_EventHandler
				AddHandler ObjectSpace.Refreshing, AddressOf ObjectSpace_Refreshing
			End If
			If View.IsRoot Then
				AddHandler View.CurrentObjectChanged, AddressOf CurrentObjectChanged_EventHandler
			End If
			previouslySelectedObject = View.CurrentObject
		End Sub
		Private IsRefreshing As Boolean = False
		Private Sub ObjectSpace_Refreshing(ByVal sender As Object, ByVal e As CancelEventArgs)
			IsRefreshing = True
		End Sub
		Private Sub CurrentObjectChanged_EventHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsRefreshing) AndAlso previouslySelectedObject IsNot Nothing AndAlso (Not ReferenceEquals(View.CurrentObject, previouslySelectedObject)) Then
				If (Not InternalIsValid(previouslySelectedObject)) Then
					View.CurrentObject = View.ObjectSpace.GetObject(previouslySelectedObject)
					InternalSave()
					Return
				End If
			End If
			previouslySelectedObject = View.CurrentObject
			IsRefreshing = False
		End Sub
		Private Sub WindowClosing_EventHandler(ByVal sender As Object, ByVal e As CancelEventArgs)
			InternalSafe(e)
		End Sub
		Private Function InternalIsValid(ByVal obj As Object) As Boolean
			Return Validator.RuleSet.ValidateTarget(obj, New ContextIdentifiers("Save")).IsValid
		End Function
		Private Sub InternalSafe(ByVal e As CancelEventArgs)
			Dim failed As Boolean = Not InternalIsValid(View.CurrentObject)
			InternalSave()
			' Cancels the current action.
			e.Cancel = failed
		End Sub
		Private Sub InternalSave()
			' Fires in the root detail view.
			If controller.SaveAction.Active.ResultValue AndAlso controller.SaveAction.Enabled.ResultValue Then
				controller.SaveAction.DoExecute()
			Else
				' Fires in the list view.
				If ObjectSpace.IsModified Then
					ObjectSpace.CommitChanges()
				End If
			End If
		End Sub
	End Class
End Namespace
