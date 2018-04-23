Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Core

Namespace SuperTipDemo.SL
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			InitializeSuperTipFromCode()
		End Sub

		Private Sub InitializeSuperTipFromCode()
			Dim tip As New SuperTip()
			Dim tipControl As New SuperTipControl()
			tipControl.SuperTip = tip
			Dim header As New SuperTipHeaderItem()
			header.Content = "New"
			Dim item As New SuperTipItem()
			item.Content = "Create a new document"

			Dim item2 As New SuperTipItem()
			item2.Content = "Opens a new document in a new tab"

			tip.Items.Add(header)
			tip.Items.Add(item)
			tip.Items.Add(New SuperTipItemSeparator())
			tip.Items.Add(item2)

			FrameworkElementHelper.SetToolTip(stdBtn, tipControl)
			barBtn.SuperTip = tip
			bNewCode.SuperTip = tip
		End Sub

		Private Sub HideGrids()
			If stdCtrlFromCode Is Nothing Then
				Return
			End If
			stdCtrlFromCode.Visibility = Visibility.Collapsed
			stdCtrlFromXaml.Visibility = Visibility.Collapsed
			barFromCode.Visibility = Visibility.Collapsed
			barFromXAML.Visibility = Visibility.Collapsed
			RibbonFromCode.Visibility = Visibility.Collapsed
			RibbonFromXAML.Visibility = Visibility.Collapsed
		End Sub

		Private Sub thRadioButton_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim rb As RadioButton = TryCast(e.OriginalSource, RadioButton)
			If rb Is Nothing Then
				Return
			End If
			Dim themeName As String = rb.Content.ToString()
			ThemeManager.ApplicationThemeName = themeName
		End Sub

		Private Sub ctrlRadioButton_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim rb As RadioButton = TryCast(sender, RadioButton)
			If rb Is Nothing OrElse stdCtrlFromCode Is Nothing Then
				Return
			End If
			HideGrids()
			If rb.Content.ToString() = "Standard Controls" Then
				stdCtrlFromCode.Visibility = Visibility.Visible
				stdCtrlFromXaml.Visibility = Visibility.Visible
			ElseIf rb.Content.ToString() = "Bars" Then
				barFromCode.Visibility = Visibility.Visible
				barFromXAML.Visibility = Visibility.Visible
			Else
				RibbonFromCode.Visibility = Visibility.Visible
				RibbonFromXAML.Visibility = Visibility.Visible
			End If
		End Sub
	End Class
End Namespace
