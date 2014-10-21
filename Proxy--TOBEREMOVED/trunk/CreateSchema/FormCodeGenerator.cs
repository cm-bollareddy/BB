using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

namespace CreateSchema
{
	public enum CodeTemplateType
	{
		Get,
		Load,
		Search,
		ListProgram,
		ListDeal,
		ListTabMap,
		ListPAADeadline,
		ListFormDeadline,
		ListMissingEpisodeFormDeadline,
		ListMissingVersionFormDeadline,
		ListPackage,
		ListMedia,
		ListInputMedia,
		ListPackageMediaInfo,
		Create,
		Delete,
		Unknown
	};

	/// <summary>
	/// Summary description for FormCodeGenerator.
	/// </summary>
	public class FormCodeGenerator : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBoxClassName;
		private System.Windows.Forms.ComboBox cboTemplateType;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Button btnGenSchema;
        private TextBox txtBoxInterfaceName;
        private Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormCodeGenerator()
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
		{
			if( disposing )
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.cboTemplateType = new System.Windows.Forms.ComboBox();
            this.txtBoxClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenSchema = new System.Windows.Forms.Button();
            this.txtBoxInterfaceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template Type: ";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(64, 142);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(176, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Generate Code Generator Class";
            this.btnGo.Click += new System.EventHandler(this.btnGenClass_Click);
            // 
            // cboTemplateType
            // 
            this.cboTemplateType.Items.AddRange(new object[] {
            "Get",
            "Load",
            "Search",
            "ListProgram",
            "ListDeal",
            "ListTabMap",
            "ListPAADeadline",
            "ListFormDeadline",
            "ListMissingEpisodeFormDeadline",
            "ListMissingVersionFormDeadline",
            "ListMedia",
            "ListPackage",
            "ListInputMedia",
            "ListPackageMediaInfo"});
            this.cboTemplateType.Location = new System.Drawing.Point(144, 86);
            this.cboTemplateType.Name = "cboTemplateType";
            this.cboTemplateType.Size = new System.Drawing.Size(320, 21);
            this.cboTemplateType.TabIndex = 2;
            this.cboTemplateType.Text = "comboBox1";
            // 
            // txtBoxClassName
            // 
            this.txtBoxClassName.Location = new System.Drawing.Point(144, 46);
            this.txtBoxClassName.Name = "txtBoxClassName";
            this.txtBoxClassName.Size = new System.Drawing.Size(320, 20);
            this.txtBoxClassName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Class Name: ";
            // 
            // btnGenSchema
            // 
            this.btnGenSchema.Location = new System.Drawing.Point(272, 142);
            this.btnGenSchema.Name = "btnGenSchema";
            this.btnGenSchema.Size = new System.Drawing.Size(136, 23);
            this.btnGenSchema.TabIndex = 5;
            this.btnGenSchema.Text = "Generate xsd && xslt";
            this.btnGenSchema.Click += new System.EventHandler(this.btnGenSchema_Click);
            // 
            // txtBoxInterfaceName
            // 
            this.txtBoxInterfaceName.Location = new System.Drawing.Point(144, 9);
            this.txtBoxInterfaceName.Name = "txtBoxInterfaceName";
            this.txtBoxInterfaceName.Size = new System.Drawing.Size(320, 20);
            this.txtBoxInterfaceName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interface Name: ";
            // 
            // FormCodeGenerator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 174);
            this.Controls.Add(this.btnGenSchema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxInterfaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxClassName);
            this.Controls.Add(this.cboTemplateType);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Name = "FormCodeGenerator";
            this.Text = "Generate Code: ";
            this.Load += new System.EventHandler(this.FormCodeGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormCodeGenerator());
		}

		private Hashtable _ParentHashtable = null;
		public Hashtable ParentHashtable
		{
			get
			{
				return _ParentHashtable;
			}
			set
			{
				_ParentHashtable = value;
			}
		}

		private Hashtable _TableNameMapping = null;
		public Hashtable TableNameMapping
		{
			get
			{
				return _TableNameMapping;
			}
			set
			{
				_TableNameMapping = value;
			}
		}

		private DataSet _SchemaDataSet = null;
		private string _TargetNamespace = "";

		private void FormCodeGenerator_Load(object sender, System.EventArgs e)
		{
			if (cboTemplateType.SelectedIndex == -1)
				cboTemplateType.SelectedIndex = 0;
		}

		private string _TargetDir = @"..\..\Target";

		private string GenTargetSchemaCodeFragment()
		{
			StringBuilder builder = new StringBuilder("", 4096);
			string strIndent = "\t\t\t";

			builder.Append("\n");
			builder.Append(strIndent + string.Format("DataSet oDataSet = new DataSet(\"{0}DataSet\");\n",
				ClassName));
			builder.Append(strIndent + string.Format("oDataSet.Namespace = \"http://localhost/BVWebService/xsd/{0}DataSet.xsd\";\n",
				_TargetNamespace));
			builder.Append("\n");

			foreach (DataTable dt in _SchemaDataSet.Tables)
			{
				string strMappedName = (string) _TableNameMapping[dt.TableName];

				string strParentName = "Root";
				if (_ParentHashtable[dt.TableName] != null)
				{
					strParentName = (string) _TableNameMapping[_ParentHashtable[dt.TableName]];
					builder.Append(strIndent + string.Format("XmlNode o{0}Node = o{1}Node.SelectSingleNode(\"FIELDS/FIELD[@attrname='{2}']\");\n",
						strMappedName, strParentName, dt.TableName));
				}
				else
				{
					builder.Append(strIndent + string.Format("XmlNode o{0}Node = XmlDocument.SelectSingleNode(\"/DATAPACKET/METADATA\");\n",
						strMappedName, strParentName));
				}

				builder.Append(strIndent + string.Format("DataTable dt{0} = new DataTable(\"{0}\");\n", strMappedName));
				builder.Append(strIndent + string.Format("XmlNodeList o{0}Nodes = o{1}Node.SelectNodes(\"FIELDS/FIELD\");\n",
						strMappedName, strMappedName));
				builder.Append(strIndent + string.Format("GenSchemaHelper.LoadColumns(dt{0}, o{0}Nodes);\n",
						strMappedName));

				string strPrimaryKey = "";
				foreach (DataColumn dc in dt.Columns)
				{
					if (dc.Unique)
					{
						if (strPrimaryKey != "")
							strPrimaryKey += ", ";

						strPrimaryKey += string.Format("dt{0}.Columns[\"{1}\"]", strMappedName, dc.ColumnName);
					}
				}
				strPrimaryKey = "new DataColumn[] {" + strPrimaryKey + "}";

				builder.Append(strIndent + string.Format("dt{0}.Constraints.Add(\"PK_{1}\", {2}, true);\n",
					strMappedName, strMappedName.ToUpper(), strPrimaryKey));
				builder.Append(strIndent + string.Format("oDataSet.Tables.Add(dt{0});\n", strMappedName));
				builder.Append("\n");
			}

			foreach (DataRelation relation in _SchemaDataSet.Relations)
			{
				builder.Append(strIndent +
					string.Format("oDataSet.Relations.Add(\"FK_{0}_{1}\", dt{2}.Columns[\"{4}\"], dt{3}.Columns[\"{5}\"]);\n",
						((string) _TableNameMapping[relation.ParentTable.TableName]).ToUpper(),
						((string) _TableNameMapping[relation.ChildTable.TableName]).ToUpper(),
						((string) _TableNameMapping[relation.ParentTable.TableName]),
						((string) _TableNameMapping[relation.ChildTable.TableName]),
						(string) relation.ParentColumns[0].ColumnName,
						(string) relation.ChildColumns[0].ColumnName));
			}

			builder.Append(strIndent + string.Format("oDataSet.WriteXmlSchema(strTargetDir + @\"\\xsd\\{0}DataSet.xsd\");\n",
				_TargetNamespace
				));

			return builder.ToString();
		}

		public void GenerateCode()
		{
			string strTargetFile = "";
			string strTemplateFile = "";
			string strObject = "";
			if (cboTemplateType.SelectedIndex == 0)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\GetTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "Get" + ClassName + ".cs";
				strObject = "Deal";
				_TargetNamespace = ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 1)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\LoadTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "Load" + ClassName + ".cs";
				strObject = "GetLookup";
				_TargetNamespace = "Load" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 2)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\SearchTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + ClassName + "Search" + ".cs";
				strObject = "Search";
				_TargetNamespace = ClassName + "Search";
			}

			else if (cboTemplateType.SelectedIndex == 3)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\ListTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 5)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\ListTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 6)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\ListTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 7)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\ListTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 8)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\ListTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 9)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\ListTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 10)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\\SearchTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 11)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\\SearchTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 12)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\\SearchTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 13)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\\SearchTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 4)
			{
				strTemplateFile = _TargetDir + @"\..\CodeGenTemplates\GetMasterDealClassTemplate.cs.txt";
				strTargetFile = _TargetDir + @"\CodeGenClass\" + "List" + ClassName + ".cs";
				strObject = "List";
				_TargetNamespace = "List" + ClassName;
			}
			else
			{
				return;
			}

			StreamReader oReader = new StreamReader(strTemplateFile, Encoding.UTF8);
			string strContent = oReader.ReadToEnd();
			oReader.Close();

			string strTargetSchema = GenTargetSchemaCodeFragment();

			string strResult = strContent.Replace(
				"<MethodName>", ClassName).Replace(
				"<GetMethodName>", "Get" + ClassName).Replace(
				"<PutMethodName>", "Put" + ClassName).Replace(
				"<LoadMethodName>", "Load" + ClassName).Replace(
				"<ListMethodName>", "List" + ClassName).Replace(
				"<SearchMethodName>", ClassName + "Search").Replace(
				"<object>", strObject).Replace(
				"<TargetSchema>", strTargetSchema);

			StreamWriter oWriter = new StreamWriter(strTargetFile, false, Encoding.UTF8);
			oWriter.Write(strResult);
			oWriter.Close();
		}

		public void GenerateSchema()
		{
            if (ClassName == string.Empty)
            {
                MessageBox.Show("Class Name is empty.");
                return;
            }

            if (InterfaceName == string.Empty)
            {
                MessageBox.Show("Interface Name is empty.");
                return;
            }


			if (cboTemplateType.SelectedIndex == 0)
			{
				_TargetNamespace = ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 1)
			{
				_TargetNamespace = "Load" + ClassName;
			}
			else if (cboTemplateType.SelectedIndex == 2)
			{
				_TargetNamespace = ClassName + "Search";
			}
			else if (cboTemplateType.SelectedIndex == 3)
			{
				_TargetNamespace = ClassName + "List";
			}
			else if (cboTemplateType.SelectedIndex == 4)
			{
				_TargetNamespace = ClassName + "ListDeal";
			}
			else if (cboTemplateType.SelectedIndex == 5)
			{
				_TargetNamespace = ClassName + "ListTabMap";
			}
			else if (cboTemplateType.SelectedIndex == 6)
			{
				_TargetNamespace = ClassName + "ListPAADeadline";
			}
			else if (cboTemplateType.SelectedIndex == 7)
			{
				_TargetNamespace = ClassName + "ListFormDeadline";
			}
			else if (cboTemplateType.SelectedIndex == 8)
			{
				_TargetNamespace = ClassName + "ListMissingEpisodeFormDeadline";
			}
			else if (cboTemplateType.SelectedIndex == 9)
			{
				_TargetNamespace = ClassName + "ListMissingVersionFormDeadline";
			}
			else if (cboTemplateType.SelectedIndex == 10)
			{
				_TargetNamespace = ClassName + "ListMedia";
			}
			else if (cboTemplateType.SelectedIndex == 11)
			{
				_TargetNamespace = ClassName + "ListPackage";
			}
			else if (cboTemplateType.SelectedIndex == 12)
			{
				_TargetNamespace = ClassName + "ListInputMedia";
			}
			else if (cboTemplateType.SelectedIndex == 13)
			{
				_TargetNamespace = ClassName + "ListPackageMediaInfo";
			}
			else
			{
				return;
			}
			string strTargetXsd = _TargetDir + @"\xsd\" + _TargetNamespace + "DataSet.xsd";

			DataSet dsTarget = new DataSet(ClassName + "DataSet");
			dsTarget.Namespace = @"http://localhost/BVWebService/xsd/" + _TargetNamespace + "DataSet.xsd";

			foreach (DataTable dt in _SchemaDataSet.Tables)
			{
				// Generate the columns for this new table...
				int nKeyColumnCount = 0;
				DataTable dtTarget = new DataTable((string) _TableNameMapping[dt.TableName]);
				foreach (DataColumn dc in dt.Columns)
				{
					DataColumn dcTarget = new DataColumn(dc.ColumnName, dc.DataType);
					dcTarget.AllowDBNull = dc.AllowDBNull;
					dcTarget.MaxLength = dc.MaxLength;
					dcTarget.ReadOnly = dc.ReadOnly;
					dtTarget.Columns.Add(dcTarget);

					if (dc.Unique)
						nKeyColumnCount++;
				}
				
				// Generate the primary key for this new table...
				DataColumn[] dcKey = new DataColumn[nKeyColumnCount];
				int i = 0;
				foreach (DataColumn dc in dt.Columns)
				{
					if (dc.Unique)
					{
						dcKey[i] = dtTarget.Columns[dc.ColumnName];
						i++;
					}
				}
				dtTarget.Constraints.Add("PK_" + (string) _TableNameMapping[dt.TableName], dcKey, true);

				// Add this table to the target DataSet
				dsTarget.Tables.Add(dtTarget);
			}

			// Now generate all the relationships...
			foreach (DataRelation relation in _SchemaDataSet.Relations)
			{
				dsTarget.Relations.Add("FK_" + (string) _TableNameMapping[relation.ParentTable.TableName] + (string) _TableNameMapping[relation.ChildTable.TableName],
					dsTarget.Tables[(string) _TableNameMapping[relation.ParentTable.TableName]].Columns[relation.ParentColumns[0].ColumnName],
					dsTarget.Tables[(string) _TableNameMapping[relation.ChildTable.TableName]].Columns[relation.ChildColumns[0].ColumnName]);
			}

			// Generate the xsd...
			dsTarget.WriteXmlSchema(strTargetXsd);

			// Generate the xslt and runtime classes
			if (cboTemplateType.SelectedIndex == 0)
			{
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(_XmlSchemaString);

				GenGetXsltHelper.GenXslTransform(_TargetDir + @"\xslt\Get" + ClassName + ".xslt", dsTarget);
				GenPutXsltHelper.GenXslTransform(_TargetDir + @"\xslt\Put" + ClassName + ".xslt", doc, dsTarget);
				GenGetClassHelper.GenClass(_TargetDir + @"\..\Templates\GetClassTemplate.cs.txt", _TargetDir + @"\xsltClass\Get" + ClassName + "Class.cs", ClassName, InterfaceName);
				GenSetClassHelper.GenClass(_TargetDir + @"\..\Templates\SetClassTemplate.cs.txt", _TargetDir + @"\xsltClass\Put" + ClassName + "Class.cs", ClassName);
			}
			else if (cboTemplateType.SelectedIndex == 1)
			{
				GenGetXsltHelper.GenXslTransform(_TargetDir + @"\xslt\Load" + ClassName + ".xslt", dsTarget);
                GenGetClassHelper.GenClass(_TargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", _TargetDir + @"\xsltClass\Load" + ClassName + "Class.cs", ClassName, InterfaceName);
			}
			else if (cboTemplateType.SelectedIndex == 2)
			{
				GenGetXsltHelper.GenXslTransform(_TargetDir + @"\xslt\" + ClassName + "Search.xslt", dsTarget);
			}

			else if (cboTemplateType.SelectedIndex == 3)
			{
				GenGetXsltHelper.GenXslTransform(_TargetDir + @"\xslt\List" + ClassName + ".xslt", dsTarget);
                GenGetClassHelper.GenClass(_TargetDir + @"\..\Templates\ListClassTemplate.cs.txt", _TargetDir + @"\xsltClass\List" + ClassName + "Class.cs", ClassName, InterfaceName);
			}

			else if (cboTemplateType.SelectedIndex == 4)
			{
				GenGetXsltHelper.GenXslTransform(_TargetDir + @"\xslt\List" + ClassName + ".xslt", dsTarget);
                GenGetClassHelper.GenClass(_TargetDir + @"\..\Templates\ListGetMasterDealClassTemplate.cs.txt", _TargetDir + @"\xsltClass\List" + ClassName + "Class.cs", ClassName, InterfaceName);
			}
		}

		private void btnGenClass_Click(object sender, System.EventArgs e)
		{
			GenerateCode();
		}

		private void btnGenSchema_Click(object sender, System.EventArgs e)
		{
			GenerateSchema();
		}

		private string _XmlSchemaString = "";
		public string XmlSchemaString
		{
			get
			{
				return _XmlSchemaString;
			}
			set
			{
				_XmlSchemaString = value;
			}
		}

		public DataSet SchemaDataSet
		{
			get
			{
				return _SchemaDataSet;
			}
			set
			{
				_SchemaDataSet = value;
			}
		}

		public string ClassName
		{
			get
			{
				return txtBoxClassName.Text;
			}
			set
			{
				txtBoxClassName.Text = value;
			}
		}

        public string InterfaceName
        {
            get
            {
                return txtBoxInterfaceName.Text;
            }
            set
            {
                txtBoxInterfaceName.Text = value;
            }
        }


		public CodeTemplateType TemplateType
		{
			get
			{
				switch (cboTemplateType.Text)
				{
					case "Get":		return CodeTemplateType.Get; 
					case "Load":	return CodeTemplateType.Load;
					case "Search":	return CodeTemplateType.Search;
					case "ListProgram":	return CodeTemplateType.ListProgram;
					case "ListDeal":	return CodeTemplateType.ListDeal;
					case "ListTabMap":	return CodeTemplateType.ListTabMap;

					case "ListPAADeadline": return CodeTemplateType.ListPAADeadline;
					case "ListFormDeadline": return CodeTemplateType.ListFormDeadline;
					case "ListMissingEpisodeFormDeadline": return CodeTemplateType.ListMissingEpisodeFormDeadline;
					case "ListMissingVersionFormDeadline": return CodeTemplateType.ListMissingVersionFormDeadline;

						
						
						
				}
				return CodeTemplateType.Unknown;
			}
			set
			{
				if (value == CodeTemplateType.Get)
				{
					cboTemplateType.SelectedIndex = 0;
				}
				else if (value == CodeTemplateType.Load)
				{
					cboTemplateType.SelectedIndex = 1;
				}
				else if (value == CodeTemplateType.Search)
				{
					cboTemplateType.SelectedIndex = 2;
				}
				else if (value == CodeTemplateType.ListProgram)
				{
					cboTemplateType.SelectedIndex = 3;
				}
				else if (value == CodeTemplateType.ListDeal)
				{
					cboTemplateType.SelectedIndex = 4;
				}
				else if (value == CodeTemplateType.ListTabMap)
				{
					cboTemplateType.SelectedIndex = 5;
				}
				else if (value == CodeTemplateType.ListPAADeadline)
				{
					cboTemplateType.SelectedIndex = 6;
				}
				else if (value == CodeTemplateType.ListFormDeadline)
				{
					cboTemplateType.SelectedIndex = 7;
				}
				else if (value == CodeTemplateType.ListMissingEpisodeFormDeadline)
				{
					cboTemplateType.SelectedIndex = 8;
				}
				else if (value == CodeTemplateType.ListMissingVersionFormDeadline)
				{
					cboTemplateType.SelectedIndex = 9;
				}
				else if (value == CodeTemplateType.ListMedia)
				{
					cboTemplateType.SelectedIndex = 10;
				}
				else if (value == CodeTemplateType.ListPackage)
				{
					cboTemplateType.SelectedIndex = 11;
				}
				else if (value == CodeTemplateType.ListInputMedia)
				{
					cboTemplateType.SelectedIndex = 12;
				}
				else if (value == CodeTemplateType.ListPackageMediaInfo)
				{
					cboTemplateType.SelectedIndex = 13;
				}
				else
				{
					throw new Exception("Unknown code template type.");
				}
			}			
		}
	}
}
