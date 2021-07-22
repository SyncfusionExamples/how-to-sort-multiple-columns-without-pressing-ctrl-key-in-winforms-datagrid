# How to sort multiple columns without pressing Ctrl key in WinForms DataGrid (SfDataGrid)?

# About the sample

This example illustrates how to sort multiple columns without pressing Ctrl key in WinForms DataGrid (SfDataGrid).

[WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid) allows you to perform the multiple sorting without pressing the Ctrl Key. You can achieve this by using the [SortColumnsChanging](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_SortColumnsChanging) event which will be raised while clicking on the column header to sort the column. You have to cancel the current sorting process and add the new sort column to the [SorColumnDescriptions](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_SortColumnDescriptions) collection.

```C#
public Form1()
{
    InitializeComponent();
    sfDataGrid1.DataSource = new OrderInfoCollection().OrdersListDetails;
    this.sfDataGrid1.SortColumnsChanging += OnSfDataGrid_SortColumnsChanging;
}

private void OnSfDataGrid_SortColumnsChanging(object sender, Syncfusion.WinForms.DataGrid.Events.SortColumnsChangingEventArgs e)
{
    e.Cancel = true;

    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
    {
        this.sfDataGrid1.BeginInvoke(new Action(() =>
        {
            this.sfDataGrid1.SortColumnDescriptions.Add(e.AddedItems[0]);
        }));

    }
    else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
    {
        this.sfDataGrid1.BeginInvoke(new Action(() =>
        {
            var sortDescription = this.sfDataGrid1.SortColumnDescriptions.FirstOrDefault(sd => sd.ColumnName == e.AddedItems[0].ColumnName);
            this.sfDataGrid1.SortColumnDescriptions.Remove(sortDescription);
            this.sfDataGrid1.SortColumnDescriptions.Add(e.AddedItems[0]);
        }));
    }
}

```

![MultiColumn Sorting](MultiColumnSorting.gif)


## Requirements to run the demo

Visual Studio 2015 and above versions.
