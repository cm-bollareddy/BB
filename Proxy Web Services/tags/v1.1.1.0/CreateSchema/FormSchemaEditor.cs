using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data;
using System.Xml;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for FormSchemaViewer.
	/// </summary>
	public class FormSchemaEditor : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSchemaEditor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSchemaEditor));
			this.txtBoxSchema = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cboTables = new System.Windows.Forms.ComboBox();
			this.dataGridSchema = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridBoolColumn();
			this.schemaGridDataSet = new CreateSchema.PBS.SchemaDataset();
			this.groupBoxRelationship = new System.Windows.Forms.GroupBox();
			this.cboChildColumn = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cboChildTable = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cboParentColumn = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBoxNameMapping = new System.Windows.Forms.TextBox();
			this.btnGenSchema = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSchema)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.schemaGridDataSet)).BeginInit();
			this.groupBoxRelationship.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtBoxSchema
			// 
			this.txtBoxSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxSchema.Location = new System.Drawing.Point(16, 32);
			this.txtBoxSchema.Multiline = true;
			this.txtBoxSchema.Name = "txtBoxSchema";
			this.txtBoxSchema.ReadOnly = true;
			this.txtBoxSchema.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBoxSchema.Size = new System.Drawing.Size(504, 56);
			this.txtBoxSchema.TabIndex = 0;
			this.txtBoxSchema.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Schema Content: ";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Work on Table: ";
			// 
			// cboTables
			// 
			this.cboTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboTables.Location = new System.Drawing.Point(128, 104);
			this.cboTables.Name = "cboTables";
			this.cboTables.Size = new System.Drawing.Size(392, 21);
			this.cboTables.TabIndex = 4;
			this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
			// 
			// dataGridSchema
			// 
			this.dataGridSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridSchema.CaptionText = "Table Schema";
			this.dataGridSchema.DataMember = "";
			this.dataGridSchema.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridSchema.Location = new System.Drawing.Point(16, 144);
			this.dataGridSchema.Name = "dataGridSchema";
			this.dataGridSchema.PreferredColumnWidth = 120;
			this.dataGridSchema.Size = new System.Drawing.Size(504, 136);
			this.dataGridSchema.TabIndex = 5;
			this.dataGridSchema.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dataGridTableStyle1});
			this.dataGridSchema.Validated += new System.EventHandler(this.dataGridSchema_Validated);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridSchema;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Name";
			this.dataGridTextBoxColumn1.MappingName = "Name";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 120;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Type";
			this.dataGridTextBoxColumn2.MappingName = "Type";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 120;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.FalseValue = false;
			this.dataGridTextBoxColumn3.MappingName = "PrimaryKey";
			this.dataGridTextBoxColumn3.NullValue = ((object)(resources.GetObject("dataGridTextBoxColumn3.NullValue")));
			this.dataGridTextBoxColumn3.TrueValue = true;
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// schemaGridDataSet
			// 
			this.schemaGridDataSet.DataSetName = "SchemaDataset";
			this.schemaGridDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBoxRelationship
			// 
			this.groupBoxRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxRelationship.Controls.Add(this.cboChildColumn);
			this.groupBoxRelationship.Controls.Add(this.label6);
			this.groupBoxRelationship.Controls.Add(this.cboChildTable);
			this.groupBoxRelationship.Controls.Add(this.label5);
			this.groupBoxRelationship.Controls.Add(this.cboParentColumn);
			this.groupBoxRelationship.Controls.Add(this.label4);
			this.groupBoxRelationship.Location = new System.Drawing.Point(16, 288);
			this.groupBoxRelationship.Name = "groupBoxRelationship";
			this.groupBoxRelationship.Size = new System.Drawing.Size(504, 136);
			this.groupBoxRelationship.TabIndex = 6;
			this.groupBoxRelationship.TabStop = false;
			this.groupBoxRelationship.Text = "Relationship";
			// 
			// cboChildColumn
			// 
			this.cboChildColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboChildColumn.Location = new System.Drawing.Point(128, 88);
			this.cboChildColumn.Name = "cboChildColumn";
			this.cboChildColumn.Size = new System.Drawing.Size(360, 21);
			this.cboChildColumn.TabIndex = 5;
			this.cboChildColumn.SelectedIndexChanged += new System.EventHandler(this.cboChildColumn_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(8, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 31);
			this.label6.TabIndex = 4;
			this.label6.Text = "Child Column: ";
			// 
			// cboChildTable
			// 
			this.cboChildTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboChildTable.Location = new System.Drawing.Point(128, 24);
			this.cboChildTable.Name = "cboChildTable";
			this.cboChildTable.Size = new System.Drawing.Size(360, 21);
			this.cboChildTable.TabIndex = 3;
			this.cboChildTable.SelectedIndexChanged += new System.EventHandler(this.cboChildTable_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 31);
			this.label5.TabIndex = 2;
			this.label5.Text = "Child Table: ";
			// 
			// cboParentColumn
			// 
			this.cboParentColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboParentColumn.Location = new System.Drawing.Point(128, 56);
			this.cboParentColumn.Name = "cboParentColumn";
			this.cboParentColumn.Size = new System.Drawing.Size(360, 21);
			this.cboParentColumn.TabIndex = 1;
			this.cboParentColumn.SelectedIndexChanged += new System.EventHandler(this.cboChildColumn_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 31);
			this.label4.TabIndex = 0;
			this.label4.Text = "Parent Column: ";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnGenerate.Location = new System.Drawing.Point(144, 472);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(104, 32);
			this.btnGenerate.TabIndex = 10;
			this.btnGenerate.Text = "GENERATE CODE!";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(16, 440);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 31);
			this.label3.TabIndex = 8;
			this.label3.Text = "Map table name to: ";
			// 
			// txtBoxNameMapping
			// 
			this.txtBoxNameMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxNameMapping.Location = new System.Drawing.Point(144, 440);
			this.txtBoxNameMapping.MaxLength = 50;
			this.txtBoxNameMapping.Name = "txtBoxNameMapping";
			this.txtBoxNameMapping.Size = new System.Drawing.Size(360, 20);
			this.txtBoxNameMapping.TabIndex = 9;
			this.txtBoxNameMapping.Text = "";
			this.txtBoxNameMapping.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxNameMapping_Validating);
			this.txtBoxNameMapping.Validated += new System.EventHandler(this.txtBoxNameMapping_Validated);
			// 
			// btnGenSchema
			// 
			this.btnGenSchema.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnGenSchema.Location = new System.Drawing.Point(312, 472);
			this.btnGenSchema.Name = "btnGenSchema";
			this.btnGenSchema.Size = new System.Drawing.Size(96, 32);
			this.btnGenSchema.TabIndex = 11;
			this.btnGenSchema.Text = "GENERATE SCHEMA!";
			this.btnGenSchema.Click += new System.EventHandler(this.btnGenSchema_Click);
			// 
			// FormSchemaEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 518);
			this.Controls.Add(this.btnGenSchema);
			this.Controls.Add(this.txtBoxNameMapping);
			this.Controls.Add(this.txtBoxSchema);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.groupBoxRelationship);
			this.Controls.Add(this.dataGridSchema);
			this.Controls.Add(this.cboTables);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormSchemaEditor";
			this.Text = "View XML Schema and Generate Code";
			this.Load += new System.EventHandler(this.FormSchemaEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridSchema)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.schemaGridDataSet)).EndInit();
			this.groupBoxRelationship.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//
		// Application specific codes
		//
		private string _Path = @"..\..\Target\BVSchema\GetDeal.xml";
		private string _MethodName = "GetDeal";
		private string _XmlSchemaString = "";
		private string _MasterTableName = @"MASTER";
		private string _CurrentTableName = @"";
		private DataSet _SchemaDataSet = null;
		private Hashtable _ParentHashtable = null;
		private Hashtable _TableNameMapping = null;
		//private DataView _SchemaDataView;

		//
		// Designer controls
		//
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dataGridSchema;
		private System.Windows.Forms.TextBox txtBoxSchema;
        private CreateSchema.PBS.SchemaDataset schemaGridDataSet;
		private System.Windows.Forms.ComboBox cboChildColumn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cboChildTable;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboParentColumn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridBoolColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.GroupBox groupBoxRelationship;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.TextBox txtBoxNameMapping;
		private System.Windows.Forms.Button btnGenSchema;
		private System.Windows.Forms.ComboBox cboTables;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormSchemaEditor());
		}

		private void ConstructSchema(
			DataSet ds,
			DataTable dt,
			Hashtable parentHashtable,
			XmlNode oNode)
		{
			// Select children nodes
			XmlNodeList oNodeList = oNode.SelectNodes("FIELDS/FIELD");

			// Generate the schema for this table
			GenSchemaHelper.LoadColumns(dt, oNodeList);

			// Add this table to our DataSet
			ds.Tables.Add(dt);

			// Do for each child table
			foreach (XmlNode oChildNode in oNode.SelectNodes("FIELDS/FIELD[@fieldtype='nested']"))
			{
				// This is the table name
				string strTableName = oChildNode.Attributes["attrname"].Value;

				// Create a new table
				DataTable dtChild = new DataTable(strTableName);

				// Link this to its parent
				parentHashtable[strTableName] = dt.TableName;

				// Construct its schema
				ConstructSchema(ds, dtChild, parentHashtable, oChildNode);
			}
		}

		private void LoadSchema(string XmlString)
		{
			// Set schema text box content
			txtBoxSchema.Text = XmlString;

			// Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create our DataSet
			_SchemaDataSet = new DataSet("Schema");

			// Create our parent table hashes
			_ParentHashtable = new Hashtable(10);

			// Recursively populate the schema with table definitions....			
			// Create the columns for the master table
			DataTable dtMaster        = new DataTable(_MasterTableName);
			XmlNode oNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			_ParentHashtable[_MasterTableName] = null;	// This is the root node, it has no parent
			ConstructSchema(_SchemaDataSet, dtMaster, _ParentHashtable, oNode);

			// Construct the table name mappings with defaults...
			_TableNameMapping = new Hashtable(10);
			foreach (DataTable dt in _SchemaDataSet.Tables)
			{
				_TableNameMapping[dt.TableName] = dt.TableName;
			}

			// Populate the cboTable names with our table names...
			cboTables.Items.Clear();
			foreach (DataTable dt in _SchemaDataSet.Tables)
			{
				cboTables.Items.Add(dt.TableName);
			}
		}

		private void InitControls()
		{
			// Initialize all screen controls to default states...
			cboTables.Enabled = true;
			//dataGridSchema.Enabled = false;
			groupBoxRelationship.Enabled = false;
			txtBoxNameMapping.Enabled = false;

			// No table currently selected
			_CurrentTableName = "";
		}

		private void UpdatePrimaryKeySettings()
		{
			if ((dataGridSchema.Enabled) && (_CurrentTableName != "") && (schemaGridDataSet != null))
			{
				// Update grid dataset with screen changes...
				schemaGridDataSet.AcceptChanges();

				DataTable dt = _SchemaDataSet.Tables[_CurrentTableName];
				int nKeyColumn = 0;
				foreach (DataRow dr in schemaGridDataSet.TableSchema)
				{
					DataColumn dc = dt.Columns[(string) dr["Name"]];

					try
					{
						dc.Unique = (bool) dr["PrimaryKey"];
					}
					catch(Exception)
					{
					}

					if (dc.Unique)
					{
						nKeyColumn++;
					}
				}
			}
		}

		private void FormSchemaEditor_Load(object sender, System.EventArgs e)
		{
			try
			{
				using (StreamReader oReader = new StreamReader(_Path, Encoding.UTF8))
				{
					_XmlSchemaString = oReader.ReadToEnd();
				}

				// Convert and load up our XML schema
				LoadSchema(_XmlSchemaString);

				// Initialize our controls on the screen
				InitControls();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cboTables_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Update primary key settings
			UpdatePrimaryKeySettings();

			// Now work with the current values...
			string strSelectedTable = ((ComboBox) sender).Text;
			_CurrentTableName = strSelectedTable;
			if (_CurrentTableName == "")	// Sanity check...
				return;

            schemaGridDataSet = new CreateSchema.PBS.SchemaDataset();
			DataTable dtGrid = schemaGridDataSet.TableSchema;

			foreach (DataColumn dc in _SchemaDataSet.Tables[strSelectedTable].Columns)
			{
				DataRow dr = dtGrid.NewRow();
				dr["Name"] = dc.ColumnName;
				dr["Type"] = dc.DataType.ToString();
				dr["MaxLength"] = dc.MaxLength;
				dr["Required"] = ! dc.AllowDBNull;
				dr["Readonly"] = dc.ReadOnly;

				if (! dc.AllowDBNull)
				{
					dr["PrimaryKey"] = dc.Unique;
				}
				else
				{
					dr["PrimaryKey"] = false;
				}

				dtGrid.Rows.Add(dr);
			}
			dataGridSchema.DataSource = dtGrid;

			// Populate the parent columns combo...
			cboParentColumn.Items.Clear();
			foreach (DataColumn dc in _SchemaDataSet.Tables[strSelectedTable].Columns)
			{
				//if (dc.Unique || (! dc.AllowDBNull))
				//{
					cboParentColumn.Items.Add(dc.ColumnName);
				//}
			}

			// Populate the child table combo...
			cboChildTable.Items.Clear();
			foreach (string s in _ParentHashtable.Keys)
			{
				if ((string)_ParentHashtable[s] == strSelectedTable)
				{
					cboChildTable.Items.Add(s);
				}
			}
			cboChildTable.Text = "";

			// Clear the child column combo...
			cboChildColumn.Items.Clear();
			cboChildColumn.Text = "";

			// Disable child relationship if no child table found
			if ((cboParentColumn.Items.Count == 0) || (cboChildTable.Items.Count == 0))
			{
				groupBoxRelationship.Enabled = false;
			}
			else
			{
				groupBoxRelationship.Enabled = true;
			}

			// Populate the table name mapping...
			txtBoxNameMapping.Text = (string) _TableNameMapping[strSelectedTable];
			txtBoxNameMapping.Enabled = true;
		}

		private void cboChildTable_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strParentTable = cboTables.Text;
			string strChildTable = ((ComboBox) sender).Text;

			// Populate the child columns combo...
			cboChildColumn.Items.Clear();
			foreach (DataColumn dc in _SchemaDataSet.Tables[strChildTable].Columns)
			{
				//if (dc.Unique || (! dc.AllowDBNull))
				//{
					cboChildColumn.Items.Add(dc.ColumnName);
				//}
			}

			// Find any foreign constraint between given table and select the column...
			foreach (DataRelation dr in _SchemaDataSet.Relations)
			{
				if ((dr.ParentTable.TableName == strParentTable) &&
					(dr.ChildTable.TableName == strChildTable))
				{
					cboParentColumn.SelectedIndex = cboParentColumn.Items.IndexOf(dr.ParentColumns[0].ColumnName);
					cboChildColumn.SelectedIndex = cboChildColumn.Items.IndexOf(dr.ChildColumns[0].ColumnName);
					return;
				}
			}

			// If we get there, then there isn't any relationship set up... so default to the first items
			cboParentColumn.SelectedIndex = 0;
			cboChildColumn.SelectedIndex = 0;
		}

		private void cboChildColumn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Sanity check...
			if ((cboParentColumn.SelectedIndex == -1) ||
				(cboChildColumn.SelectedIndex == -1) ||
				(cboChildTable.SelectedIndex == -1))
				return;

			// Parent and child table names...
			string strParentTable = cboTables.Text;
			string strChildTable = cboChildTable.Text;

			// Find any foreign constraint between given table and remove it...
			foreach (DataRelation dr in _SchemaDataSet.Relations)
			{
				if ((dr.ParentTable.TableName == strParentTable) &&
					(dr.ChildTable.TableName == strChildTable))
				{
					_SchemaDataSet.Relations.Remove(dr.RelationName);
					break;
				}
			}

			// Add this relationship...
			try
			{
				DataRelation relation = new DataRelation("FK_" + strParentTable + "_" + strChildTable,
					_SchemaDataSet.Tables[strParentTable].Columns[cboParentColumn.Text],
					_SchemaDataSet.Tables[strChildTable].Columns[cboChildColumn.Text]);
				_SchemaDataSet.Relations.Add(relation);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\nPlease choose a different set of columns.");

				// Unselect columns...
				cboParentColumn.SelectedIndex = -1;
				cboChildColumn.SelectedIndex = -1;
			}
		}

		private bool ValidateSchema()
		{
			// Validate that our tables have their proper primary keys...
			foreach (DataTable dt in _SchemaDataSet.Tables)
			{
				bool bHasPrimaryKey = false;
				foreach (DataColumn dc in dt.Columns)
				{
					if (dc.Unique)
					{
						bHasPrimaryKey = true;
					}
				}

				if (! bHasPrimaryKey)
				{
					MessageBox.Show("Table " + dt.TableName + " does not have a primary key. Please specify one!");
					return false;
				}

				// If it has a parent table, then make sure that a relationship has been set up...
				if (_ParentHashtable[dt.TableName] != null)
				{
					string strParentTable = (string) _ParentHashtable[dt.TableName];

					// We name our relation FK_<parent>_<child>, so find it here...
					if (! _SchemaDataSet.Relations.Contains("FK_" + strParentTable + "_" + dt.TableName))
					{
						MessageBox.Show("Table " + dt.TableName + " is a child table of " + strParentTable + ". But no relationship has been set up!");
						return false;
					}
				}
			}
			return true;
		}

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			if (! ValidateSchema())
				return;

			// Go ahead and generate the code...
			FormCodeGenerator formGenerator = new FormCodeGenerator();

			if (_MethodName.StartsWith("Get"))
			{
				formGenerator.ClassName = _MethodName.Substring(3);
				formGenerator.TemplateType = CodeTemplateType.Get;
			}
			else if (_MethodName.StartsWith("Load"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.Load;
			}
			else if (_MethodName.StartsWith("ListProgram"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListProgram;
			}
			else if (_MethodName.StartsWith("ListDeal"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListDeal;
			}
			else if (_MethodName.StartsWith("ListMediaCutsInfo"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListMedia;
			}
			else if (_MethodName.StartsWith("ListPackageCutsInfo"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListPackage;
			}
			else if (_MethodName.StartsWith("ListPackageMediaInfo"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListPackageMediaInfo;
			}
			else if (_MethodName.StartsWith("ListInputMediaInfo"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListPackageMediaInfo;
			}
			else if (_MethodName.StartsWith("ListPackage"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListPackage;
			}
			else if (_MethodName.StartsWith("ListTab"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListTabMap;
			}
			else if (_MethodName.StartsWith("ListPAA"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListPAADeadline;
			}
			else if (_MethodName.StartsWith("ListFormDead"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListFormDeadline;
			}
			else if (_MethodName.StartsWith("ListMissingEpisode"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListMissingEpisodeFormDeadline;
			}
			else if (_MethodName.StartsWith("ListMissingVersion"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListMissingVersionFormDeadline;
			}
			else if (_MethodName.IndexOf("Search") != -1)
			{
				formGenerator.ClassName = _MethodName.Substring(0, _MethodName.IndexOf("Search"));
				formGenerator.TemplateType = CodeTemplateType.Search;
			}
			else if (_MethodName.IndexOf("DetailedAirDate") != -1)
			{
				formGenerator.ClassName = "DetailedAirDate";
				formGenerator.TemplateType = CodeTemplateType.Search;
			}
			else if (_MethodName.IndexOf("ValidateEpisodeSlate") != -1)
			{
				formGenerator.ClassName = "ValidateEpisodeSlate";
				formGenerator.TemplateType = CodeTemplateType.Search;
			}
			else
			{
				MessageBox.Show("Cannot generate code for unsupported method type!");
				return;
			}

			formGenerator.ParentHashtable = _ParentHashtable;
			formGenerator.TableNameMapping = _TableNameMapping;
			formGenerator.XmlSchemaString = txtBoxSchema.Text;
			formGenerator.SchemaDataSet = _SchemaDataSet;
			formGenerator.GenerateCode();
			MessageBox.Show("Code generated!");
		}

		private void btnGenSchema_Click(object sender, System.EventArgs e)
		{
			if (! ValidateSchema())
				return;

			// Go ahead and generate the code...
			FormCodeGenerator formGenerator = new FormCodeGenerator();

			if (_MethodName.StartsWith("Get"))
			{
				formGenerator.ClassName = _MethodName.Substring(3);
				formGenerator.TemplateType = CodeTemplateType.Get;
			}
			else if (_MethodName.StartsWith("Load"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.Load;
			}
			else if (_MethodName.StartsWith("ListProgram"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListProgram;
			}
			else if (_MethodName.StartsWith("ListDeal"))
			{
				formGenerator.ClassName = _MethodName.Substring(4);
				formGenerator.TemplateType = CodeTemplateType.ListDeal;
			}
			else if (_MethodName.IndexOf("Search") != -1)
			{
				formGenerator.ClassName = _MethodName.Substring(0, _MethodName.IndexOf("Search"));
				formGenerator.TemplateType = CodeTemplateType.Search;
			}
			else if (_MethodName.IndexOf("DetailedAirDate") != -1)
			{
				formGenerator.ClassName = "DetailedAirDate";
				formGenerator.TemplateType = CodeTemplateType.Search;
			}
			else if (_MethodName.IndexOf("ValidateEpisodeSlate") != -1)
			{
				formGenerator.ClassName = "ValidateEpisodeSlate";
				formGenerator.TemplateType = CodeTemplateType.Search;
			}
			else
			{
				MessageBox.Show("Cannot generate code for unsupported method type!");
				return;
			}

			formGenerator.ParentHashtable = _ParentHashtable;
			formGenerator.TableNameMapping = _TableNameMapping;
			formGenerator.XmlSchemaString = txtBoxSchema.Text;
			formGenerator.SchemaDataSet = _SchemaDataSet;
			formGenerator.GenerateSchema();
			MessageBox.Show("Schema generated!");		
		}

		private void txtBoxNameMapping_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string strTableName = ((TextBox) sender).Text;
			if (strTableName == "")
			{
				MessageBox.Show("Table name must not be empty!");
				e.Cancel = true;
			}
			else if (strTableName == _CurrentTableName)
			{
				return;
			}
			else
			{
				// Table name must only be letter/digits/_
				foreach (char c in strTableName)
				{
					if (char.IsLetterOrDigit(c) || (c == '_'))
					{
						continue;
					}
					else
					{
						MessageBox.Show("Table name must contain only letters, digits and underscore(_)!");
						e.Cancel = true;
					}
				}

				// Table name must not conflict with existing table names
				if (_TableNameMapping.ContainsValue(strTableName))
				{
					MessageBox.Show("Given table name must not be one of the children tables!");
					e.Cancel = true;
				}
			}
		}

		private void txtBoxNameMapping_Validated(object sender, System.EventArgs e)
		{
			string strTableName = ((TextBox) sender).Text;
			_TableNameMapping[_CurrentTableName] = strTableName;
		}

		private void dataGridSchema_Validated(object sender, System.EventArgs e)
		{
			UpdatePrimaryKeySettings();		
		}
	
		public string Path
		{
			get
			{
				return _Path;
			}
			set
			{
				_Path = value;
			}
		}

		public string MasterTableName
		{
			get
			{
				return _MasterTableName;
			}
			set
			{
				_MasterTableName = value;
			}
		}

		public string MethodName
		{
			get
			{
				return _MethodName;
			}
			set
			{
				_MethodName = value;
			}
		}
	}
}
