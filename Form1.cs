using SereneWınFormTest.Northwind.Entities;
using SereneWınFormTest.Northwind.Repositories;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using SerenityWinForm.Northwind.Entities;
using SerenityWinForm.Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerenityWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var notes = TwoLevelCache.GetLocalStoreOnly("Notes:SomeKey", TimeSpan.FromSeconds(5),
                NoteRow.Fields.GenerationKey, () =>
                {
                    using (var connection = SqlConnections.NewByKey("Northwind"))
                    {
                        var fld = NoteRow.Fields;

                        var listRequest = new ListRequest
                        {
                            ColumnSelection = ColumnSelection.List,
                            //EqualityFilter = new Dictionary<string, object>
                            //{
                            //    { fld.EntityType.PropertyName, handler.Row.Table },
                            //    { fld.EntityId.PropertyName, idField[handler.Row] ?? -1 }
                            //}
                        };
                        return new NoteRepository().List(connection, listRequest).Entities;
                    }
                });

            var suppliers = TwoLevelCache.GetLocalStoreOnly("Suppliers:SomeKey", TimeSpan.FromSeconds(5),
                SupplierRow.Fields.GenerationKey, () =>
                {
                    using (var connection = SqlConnections.NewByKey("Northwind"))
                    {
                        var listRequest = new ListRequest
                        {
                            ColumnSelection = ColumnSelection.List,
                            //EqualityFilter = new Dictionary<string, object>
                            //{
                            //    { fld.EntityType.PropertyName, handler.Row.Table },
                            //    { fld.EntityId.PropertyName, idField[handler.Row] ?? -1 }
                            //}
                        };
                        return new SupplierRepository().List(connection, listRequest).Entities;
                    }
                });

            MessageBox.Show(JSON.StringifyIndented(suppliers));
        }
    }
}
