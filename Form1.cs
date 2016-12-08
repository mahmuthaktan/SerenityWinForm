using SereneWınFormTest.Northwind.Entities;
using SereneWınFormTest.Northwind.Repositories;
using Serenity.Data;
using Serenity.Services;
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
            var cs = SqlConnections.GetConnectionString("Northwind");

            if (cs.Dialect.GetType() == typeof(OracleDialect))
                return;

            var cb = cs.ProviderFactory.CreateConnectionStringBuilder();
            cb.ConnectionString = cs.ConnectionString;

            string catalogKey = "?";
            foreach (var ck in new[] { "Initial Catalog", "Database", "AttachDBFilename" })
                if (cb.ContainsKey(ck))
                {
                    catalogKey = ck;
                    break;
                }

            var catalog = cb[catalogKey] as string;
            cb[catalogKey] = null;

            var connection = SqlConnections.New(cb.ConnectionString, cs.ProviderName);

     

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

            var notes = new NoteRepository().List(connection, listRequest).Entities;

        }
    }
}
