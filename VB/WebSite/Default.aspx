<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<p>
		<br />
	</p>
	<p>
		&nbsp;</p>
	<form id="form1" runat="server">
	<div>

		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
 KeyFieldName="EmployeeID">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" 
					VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ReportsTo" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
			</Columns>
			<SettingsDetail ShowDetailRow="True" />
		</dx:ASPxGridView>

	</div>
	</form>
</body>
</html>