Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.OleDb
Imports DevExpress.Web.ASPxGridView
Imports System.Data


Public Class MyDetailTemplate
	Implements ITemplate

	Protected Sub grid_DetailRowGetButtonVisibility(ByVal sender As Object, ByVal e As ASPxGridViewDetailRowButtonEventArgs)
		Dim data As DataView = _Default.GetData(Convert.ToInt32(e.KeyValue))
		If data.Table.Rows.Count = 0 Then
			e.ButtonState = GridViewDetailRowButtonState.Hidden
		End If
	End Sub

	Private Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
		Dim con As GridViewDetailRowTemplateContainer = TryCast(container, GridViewDetailRowTemplateContainer)
		Dim grid As New ASPxGridView()
		grid.ID = con.KeyValue.ToString()
		container.Controls.Add(grid)
		grid.DataSource = _Default.GetData(Convert.ToInt32(con.KeyValue))
		grid.KeyFieldName = "EmployeeID"
		grid.SettingsDetail.ShowDetailRow = True
		grid.Templates.DetailRow = New MyDetailTemplate()
		AddHandler grid.DetailRowGetButtonVisibility, AddressOf grid_DetailRowGetButtonVisibility
	End Sub
End Class


Partial Public Class _Default
	Inherits System.Web.UI.Page


	Public Shared Function GetData(ByVal reportsTo As Integer) As DataView
		Dim sqlData As New SqlDataSource()
		sqlData.ConnectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True"
		sqlData.SelectCommand = String.Format("SELECT [EmployeeID], [LastName], [FirstName], [Country], [ReportsTo] FROM [Employees] WHERE ([ReportsTo] = {0})", reportsTo)
		If reportsTo = -1 Then
			sqlData.SelectCommand = "SELECT [EmployeeID], [LastName], [FirstName], [Country], [ReportsTo] FROM [Employees] WHERE ([ReportsTo] IS NULL)"
		End If
		Dim dataTable As DataView = TryCast(sqlData.Select(DataSourceSelectArguments.Empty), DataView)
		Return dataTable
	End Function

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxGridView1.DataSource = GetData(-1)
		ASPxGridView1.DataBind()
		ASPxGridView1.Templates.DetailRow = New MyDetailTemplate()
	End Sub

End Class
