using DevExpress.Web;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    public static DataView GetData(int reportsTo) {
        SqlDataSource sqlData = new SqlDataSource();
        sqlData.ConnectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=True";
        sqlData.SelectCommand = string.Format("SELECT [EmployeeID], [LastName], [FirstName], [Country], [ReportsTo] FROM [Employees] WHERE ([ReportsTo] = {0})", reportsTo);
        if (reportsTo == -1)
            sqlData.SelectCommand = "SELECT [EmployeeID], [LastName], [FirstName], [Country], [ReportsTo] FROM [Employees] WHERE ([ReportsTo] IS NULL)";
        DataView dataTable = sqlData.Select(DataSourceSelectArguments.Empty) as DataView;
        return dataTable;
    }
    protected void Page_Load(object sender, EventArgs e) {
        ASPxGridView1.DataSource = GetData(-1);
        ASPxGridView1.DataBind();
        ASPxGridView1.Templates.DetailRow = new MyDetailTemplate();
    }
}

public class MyDetailTemplate : ITemplate {
    protected void grid_DetailRowGetButtonVisibility(object sender, ASPxGridViewDetailRowButtonEventArgs e) {
        DataView data = _Default.GetData(Convert.ToInt32(e.KeyValue));
        if (data.Table.Rows.Count == 0)
            e.ButtonState = GridViewDetailRowButtonState.Hidden;
    }
    void ITemplate.InstantiateIn(Control container) {
        GridViewDetailRowTemplateContainer con = container as GridViewDetailRowTemplateContainer;
        ASPxGridView grid = new ASPxGridView();
        grid.ID = con.KeyValue.ToString();
        container.Controls.Add(grid);
        grid.DataSource = _Default.GetData(Convert.ToInt32(con.KeyValue));
        grid.KeyFieldName = "EmployeeID";
        grid.SettingsDetail.ShowDetailRow = true;
        grid.Templates.DetailRow = new MyDetailTemplate();
        grid.DetailRowGetButtonVisibility += new ASPxGridViewDetailRowButtonEventHandler(grid_DetailRowGetButtonVisibility);
    }
}