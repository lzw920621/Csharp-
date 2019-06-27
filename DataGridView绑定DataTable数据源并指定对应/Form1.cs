using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView绑定DataTable数据源并指定对应
{
    /*
    //指定对应关系的关键在于两点：

    1、dgv的 AutoGenerateColumns = false;

    2、DataGridView新加入列的fieldNameColumn.DataPropertyName = "field-name";//这要和DataTable的属性名一样

    */
    public partial class Form1 : Form
    {
        DataTable itemAttributeDataTable = new DataTable();
        BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设计datagridview样式
        /// </summary>
        private void SetSettingGridViewDisplay()
        {            
            this.GV_ColumnInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            this.GV_ColumnInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;

            this.GV_ColumnInfo.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            this.GV_ColumnInfo.RowHeadersVisible = false;

            this.GV_ColumnInfo.AutoGenerateColumns = false;

            this.GV_ColumnInfo.AllowUserToAddRows = false;

            this.GV_ColumnInfo.AllowUserToResizeRows = false;
        }

        private void BindDatatable()
        {
            itemAttributeDataTable.Columns.Add(new DataColumn("field_name", typeof(string)));
            itemAttributeDataTable.Columns.Add(new DataColumn("id", typeof(int)));
            itemAttributeDataTable.Columns.Add(new DataColumn("identifier", typeof(string)));
            itemAttributeDataTable.Columns.Add(new DataColumn("length", typeof(int)));

            DataRow dataRow = itemAttributeDataTable.NewRow();
            dataRow["field_name"] = "张三";
            dataRow["id"] = 1;
            dataRow["identifier"] = "21345";
            dataRow["length"] = 10;

            itemAttributeDataTable.Rows.Add(dataRow);

            dataRow = itemAttributeDataTable.NewRow();
            dataRow["field_name"] = "李四";
            dataRow["id"] = 2;
            dataRow["identifier"] = "2467";
            dataRow["length"] = 32;

            itemAttributeDataTable.Rows.Add(dataRow);

            bindingSource.DataSource = itemAttributeDataTable;

            this.GV_ColumnInfo.DataSource = bindingSource;



            DataGridViewColumn fieldNameColumn = new DataGridViewTextBoxColumn();

            fieldNameColumn.HeaderText = "field_name";

            fieldNameColumn.DataPropertyName = "field_name";//这个很重要，对应的是你数据源的字段名

            this.GV_ColumnInfo.Columns.Add(fieldNameColumn);



            DataGridViewColumn idColumn = new DataGridViewTextBoxColumn();

            idColumn.HeaderText = "id";

            idColumn.DataPropertyName = "id";

            this.GV_ColumnInfo.Columns.Add(idColumn);



            DataGridViewColumn identifierColumn = new DataGridViewTextBoxColumn();

            identifierColumn.HeaderText = "identifier";

            identifierColumn.DataPropertyName = "identifier";

            this.GV_ColumnInfo.Columns.Add(identifierColumn);


            /*

            //下拉列表绑定时候，DataPropertyName和ValueMember做对比，

            DataGridViewComboBoxColumn typeColumn = new DataGridViewComboBoxColumn();

            typeColumn.DataSource = GetComBoxDataSource();

            typeColumn.Width = 200;

            typeColumn.DataPropertyName = "type";

            typeColumn.DisplayMember = "Text";

            typeColumn.ValueMember = "Values";

            typeColumn.HeaderText = "type";

            //typeColumn = ComboBoxStyle.DropDownList;

            this.GV_ColumnInfo.Columns.Add(typeColumn);

            */

            DataGridViewColumn lengthColumn = new DataGridViewTextBoxColumn();

            lengthColumn.HeaderText = "length";

            lengthColumn.DataPropertyName = "length";

            this.GV_ColumnInfo.Columns.Add(lengthColumn);
        }

        private object GetComBoxDataSource()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSettingGridViewDisplay();
            BindDatatable();
        }
    }
}
