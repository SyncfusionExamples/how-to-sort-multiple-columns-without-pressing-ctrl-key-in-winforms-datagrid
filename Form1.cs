using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
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

        #endregion
    }
}
