using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Xml;
using TVSServer = OrionProxy;
using System.IO;


using BVWebService;


namespace CreateSchema
{
	/// <summary>
	/// Summary description for FormAdHocGenerator.
	/// </summary>
	public class FormAdHocGenerator : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog assemblyChooserFileDialog;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnChoose;
		private System.Windows.Forms.TextBox txtAssemblyPath;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.ComboBox cboMethods;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboTypes;
		private System.Windows.Forms.DataGrid dataGridParams;
		private System.Windows.Forms.CheckBox chkFiltered;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private CreateSchema.PBS.ParamDataset paramDataset;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.Button btnInvoke;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAdHocGenerator()
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
			this.txtAssemblyPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.assemblyChooserFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnChoose = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cboMethods = new System.Windows.Forms.ComboBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.dataGridParams = new System.Windows.Forms.DataGrid();
			this.paramDataset = new CreateSchema.PBS.ParamDataset();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.cboTypes = new System.Windows.Forms.ComboBox();
			this.chkFiltered = new System.Windows.Forms.CheckBox();
			this.btnInvoke = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridParams)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paramDataset)).BeginInit();
			this.SuspendLayout();
			// 
			// txtAssemblyPath
			// 
			this.txtAssemblyPath.Location = new System.Drawing.Point(112, 8);
			this.txtAssemblyPath.Name = "txtAssemblyPath";
			this.txtAssemblyPath.Size = new System.Drawing.Size(344, 20);
			this.txtAssemblyPath.TabIndex = 0;
			//this.txtAssemblyPath.Text = ".\\Interop.TVSServer.dll";
            this.txtAssemblyPath.Text = ".\\OrionProxyLib.dll";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Assembly Path: ";
			// 
			// assemblyChooserFileDialog
			// 
			this.assemblyChooserFileDialog.DefaultExt = "*.dll";
			//this.assemblyChooserFileDialog.FileName = "Interop.TVSServer.dll";
            this.assemblyChooserFileDialog.FileName = "OrionProxyLib.dll";
            this.assemblyChooserFileDialog.Filter = "Assembly|*.dll;*.exe";
			this.assemblyChooserFileDialog.InitialDirectory = ".";
			this.assemblyChooserFileDialog.ReadOnlyChecked = true;
			this.assemblyChooserFileDialog.RestoreDirectory = true;
			this.assemblyChooserFileDialog.ShowReadOnly = true;
			this.assemblyChooserFileDialog.Title = "Please choose an assembly file...";
			// 
			// btnChoose
			// 
			this.btnChoose.Location = new System.Drawing.Point(472, 8);
			this.btnChoose.Name = "btnChoose";
			this.btnChoose.Size = new System.Drawing.Size(24, 23);
			this.btnChoose.TabIndex = 2;
			this.btnChoose.Text = "...";
			this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "Method: ";
			// 
			// cboMethods
			// 
			this.cboMethods.Location = new System.Drawing.Point(112, 72);
			this.cboMethods.Name = "cboMethods";
			this.cboMethods.Size = new System.Drawing.Size(344, 21);
			this.cboMethods.Sorted = true;
			this.cboMethods.TabIndex = 4;
			this.cboMethods.SelectedIndexChanged += new System.EventHandler(this.cboMethods_SelectedIndexChanged);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(512, 8);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.TabIndex = 5;
			this.btnLoad.Text = "LOAD";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// dataGridParams
			// 
			this.dataGridParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridParams.CaptionText = "Method Parameters";
			this.dataGridParams.DataMember = "";
			this.dataGridParams.DataSource = this.paramDataset.Param;
			this.dataGridParams.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridParams.Location = new System.Drawing.Point(8, 104);
			this.dataGridParams.Name = "dataGridParams";
			this.dataGridParams.PreferredColumnWidth = 100;
			this.dataGridParams.Size = new System.Drawing.Size(576, 288);
			this.dataGridParams.TabIndex = 6;
			this.dataGridParams.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dataGridTableStyle1});
			// 
			// paramDataset
			// 
			this.paramDataset.DataSetName = "ParamDataset";
			this.paramDataset.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridParams;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.PreferredColumnWidth = 120;
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Name";
			this.dataGridTextBoxColumn1.MappingName = "Name";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 150;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Data Type";
			this.dataGridTextBoxColumn2.MappingName = "DataType";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 200;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Value";
			this.dataGridTextBoxColumn3.MappingName = "InOut";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.MappingName = "Value";
			this.dataGridTextBoxColumn4.Width = 200;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.TabIndex = 7;
			this.label3.Text = "Type: ";
			// 
			// cboTypes
			// 
			this.cboTypes.Location = new System.Drawing.Point(112, 40);
			this.cboTypes.Name = "cboTypes";
			this.cboTypes.Size = new System.Drawing.Size(344, 21);
			this.cboTypes.Sorted = true;
			this.cboTypes.TabIndex = 8;
			this.cboTypes.SelectedIndexChanged += new System.EventHandler(this.cboTypes_SelectedIndexChanged);
			// 
			// chkFiltered
			// 
			this.chkFiltered.Checked = true;
			this.chkFiltered.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFiltered.Location = new System.Drawing.Point(472, 40);
			this.chkFiltered.Name = "chkFiltered";
			this.chkFiltered.TabIndex = 9;
			this.chkFiltered.Text = "PBS Filtered";
			this.chkFiltered.CheckedChanged += new System.EventHandler(this.chkFiltered_CheckedChanged);
			// 
			// btnInvoke
			// 
			this.btnInvoke.Enabled = false;
			this.btnInvoke.Location = new System.Drawing.Point(472, 72);
			this.btnInvoke.Name = "btnInvoke";
			this.btnInvoke.TabIndex = 10;
			this.btnInvoke.Text = "Execute";
			this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
			// 
			// FormAdHocGenerator
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 406);
			this.Controls.Add(this.btnInvoke);
			this.Controls.Add(this.chkFiltered);
			this.Controls.Add(this.cboTypes);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dataGridParams);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.cboMethods);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnChoose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAssemblyPath);
			this.Name = "FormAdHocGenerator";
			this.Text = "Browse Component Result Schema...";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAdHocGenerator_Closing);
			this.Load += new System.EventHandler(this.FormAdHocGenerator_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridParams)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paramDataset)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		private Assembly _currentAssembly = null;
		private Type _currentType = null;
		private MethodInfo _currentMethod = null;
		private int _numArgs = 0;
		private string _SessionID = "";

		private string _TargetDir = "..\\..\\Target";
		public string TargetDir
		{
			set
			{
				_TargetDir = value;
			}
		}


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormAdHocGenerator());
		}

		private void btnChoose_Click(object sender, System.EventArgs e)
		{
			if (assemblyChooserFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				txtAssemblyPath.Text = assemblyChooserFileDialog.FileName;
			}
		}


        /// <summary>
        /// Quick and Dirty method used to retrive a string listing of the BV Object heirarchy
        /// </summary>
        /// <returns></returns>
        private string GetBroadViewInventory()
        {
            System.Text.StringBuilder oSB = new System.Text.StringBuilder();
            try
            {
                Assembly _currentAssembly = Assembly.LoadFrom(txtAssemblyPath.Text);
                foreach (Type type in _currentAssembly.GetTypes())
                {
                    oSB.AppendLine("Type: " + type.ToString());
                    foreach (MethodInfo methodInfo in type.GetMethods())
                    {

                        oSB.AppendLine("Type: " + type.ToString() + "\t\t" + "Method: " + methodInfo.Name );
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

            return oSB.ToString();
        }



		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Load given assembly and populate the type list box with all its types...
				_currentAssembly = Assembly.LoadFrom(txtAssemblyPath.Text);

				paramDataset.Param.Rows.Clear();
				btnInvoke.Enabled = false;
				cboMethods.Items.Clear(); cboMethods.Text = "";
				cboTypes.Items.Clear(); cboTypes.Text = "";
				foreach (Type type in _currentAssembly.GetTypes())
				{
					if (! chkFiltered.Checked)
					{
						cboTypes.Items.Add(type.ToString());
					}
					else
					{
						string strClassName = type.Name;
						//if (strClassName.StartsWith("rdmPBS") && strClassName.EndsWith("Class"))
                        if (strClassName.StartsWith("rdmPBS"))
						{

						//if (strClassName.StartsWith("rdmPBS"))
						//{
							cboTypes.Items.Add(type.ToString());
						}
					}
				}


			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				_currentAssembly = null;
			}
		}

		private void cboTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cbo = (ComboBox) sender;

			if (_currentAssembly != null)
			{
				try
				{
					// Load given type and populate the method list box with all its methods...
					_currentType = _currentAssembly.GetType(cbo.Text, true);

					paramDataset.Param.Rows.Clear();
					btnInvoke.Enabled = false;
					cboMethods.Items.Clear(); cboMethods.Text = "";
					foreach (MethodInfo methodInfo in _currentType.GetMethods())
					{
						string strMethodName = methodInfo.Name;
						if (! chkFiltered.Checked)
						{
							cboMethods.Items.Add(strMethodName);

						}
						else
						{
							if (strMethodName.StartsWith("Get") ||
								strMethodName.StartsWith("Load") ||
								strMethodName.StartsWith("List") ||
								strMethodName.StartsWith("Put") ||
								strMethodName.StartsWith("Create") ||
								strMethodName.StartsWith("Delete") ||
								strMethodName.StartsWith("DetailedAirDate") ||
								strMethodName.StartsWith("ValidateEpisodeSlate") ||
								(strMethodName.IndexOf("Search") != -1))
							{
								cboMethods.Items.Add(strMethodName);
							}
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					_currentType = null;
				}

			}
		}

		private void cboMethods_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cbo = (ComboBox) sender;

			if (_currentType != null)
			{
				try
				{
					// Load given method and populate the grid with current set of parameters
					_currentMethod = _currentType.GetMethod(cbo.Text);

					paramDataset.Param.Rows.Clear();
					btnInvoke.Enabled = true;
					foreach (ParameterInfo paramInfo in _currentMethod.GetParameters())
					{
						paramDataset.Param.AddParamRow(paramInfo.Name, paramInfo.ParameterType.ToString(),
							paramInfo.IsIn ? "In" : (paramInfo.IsOut ? (paramInfo.IsRetval ? "Out, Retval" : "Out") : ""),
							"");

						if ((paramInfo.Name.StartsWith("aXMLData")) && (paramInfo.IsOut))
							btnInvoke.Enabled = true;
					}
					_numArgs = paramDataset.Param.Rows.Count;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					_currentMethod = null;
				}
			}
		}

		private void chkFiltered_CheckedChanged(object sender, System.EventArgs e)
		{
			// Reload the assembly and reload the type combo box
			btnLoad_Click(btnLoad, e);
		}

		private void FormAdHocGenerator_Load(object sender, System.EventArgs e)
		{
			btnLoad_Click(btnLoad, e);		
		}

		private void btnInvoke_Click(object sender, System.EventArgs e)
		{
			int nXMLResult = -1;
			try
			{
				// Throw up a wait cursor...
				Cursor = Cursors.WaitCursor;

				if (_SessionID == "")
				{
					BVSession s = new BVSession();
					_SessionID = s.Login();
				}

				// Save user changes...
				paramDataset.AcceptChanges();

				// Set up the parameter array...
				object[] objArgs = new object[_numArgs];
				for (int i = 0; i < _numArgs; i++)
				{
					//if (paramDataset.Param.Rows[i]["InOut"].ToString() == "In")
                    if (paramDataset.Param.Rows[i]["InOut"].ToString() == "")
					{
						if (paramDataset.Param.Rows[i]["Name"].ToString() == "aSessionID")
						{
							objArgs[i] = _SessionID;
						}
						else if (paramDataset.Param.Rows[i]["Value"].ToString() != "")
						{
							string strValue = paramDataset.Param.Rows[i]["Value"].ToString();

							switch (paramDataset.Param.Rows[i]["DataType"].ToString())
							{

								case "System.Int32":	objArgs[i] = int.Parse(strValue);	break;
								case "System.String":	objArgs[i] = strValue;				break;
								case "System.Boolean":  objArgs[i] = bool.Parse(strValue);	break;
								default:                
									throw new Exception("Unsupported argument type: " + strValue);
							}
						}
						else
						{
							switch (paramDataset.Param.Rows[i]["DataType"].ToString())
							{
								case "System.Int32":	objArgs[i] = (object) null;     break;
								case "System.String":	objArgs[i] = (object) null;    break;
								case "System.Boolean":  objArgs[i] = (object) false; break;
								default:                objArgs[i] = new object();   break;
							}
						}
					}
					else
					{
						switch (paramDataset.Param.Rows[i]["DataType"].ToString())
						{
							case "System.Int32&":	 objArgs[i] = null;  break;
							case "System.String&":	 objArgs[i] = null; break;
							case "System.Boolean&":  objArgs[i] = null; break;
							default:                 objArgs[i] = null; break;
						}

						if ((paramDataset.Param.Rows[i]["InOut"].ToString() == "Out") &&
							(paramDataset.Param.Rows[i]["Name"].ToString().StartsWith("aXMLData")))
						if ((paramDataset.Param.Rows[i]["InOut"].ToString() == "Out"))
						{
							nXMLResult = i;
						}
					}
				}
			
				if (nXMLResult != -1)
				{
					object o = ComponentFactory.CreateObject(cboTypes.Text, txtAssemblyPath.Text);

					//TVSServer.rdmPBSManageTable o = ComponentFactory.CreateManageTableClass();
					Type objectType = o.GetType();
					string strResult =string.Empty;
					try
					{
						MethodInfo methodInfo = objectType.GetMethod(cboMethods.Text);

//						if (cboMethods.Text!="CreateMediaInventoryRevision")
//						{
							//objArgs[1] = getlockid(objArgs[0]);

//						}
//						object[] objSearchParams = new object[1];
//						objSearchParams[0] = new object[2];
//						((object[]) objSearchParams[0])[0] = "REVISIONHOUSENUMBER";
//						((object[]) objSearchParams[0])[1] = "10004-0";
//						objArgs[1]=objSearchParams;

						methodInfo.Invoke(o, objArgs);

						//string a=string.Empty;
						//string b = string.Empty;
						//o.GetVisualArt(_SessionID,0,false,out a,out strResult,out b);
						


						 //
						
						strResult = objArgs[nXMLResult].ToString();
						//strResult = objArgs[3].ToString();

					}
					catch(Exception ex)
					{
						string sEx =  ex.Message;

					}

					// Save this out....
//					XmlDocument XmlDocument = new XmlDocument();
//					XmlDocument.LoadXml(strResult);
//
//					// Create an XmlTextWriter and save it out
//					XmlTextWriter XmlWriter = new XmlTextWriter(_TargetDir + @"\BVSchema\" +
//						cboMethods.Text + ".xml", System.Text.Encoding.UTF8);
//					XmlDocument.WriteTo(XmlWriter);
//					XmlWriter.Flush();
//					XmlWriter.Close();

					//for get talent we have
					if (cboMethods.Text!="GetTalent")
					{
						CreateXMLSchemaFile(strResult,cboMethods.Text);

					}
					else
					{
						//CreateXMLSchemaFile(objArgs[4].ToString(),"DataEpisodeAppliesTo");
						  CreateXMLSchemaFile(objArgs[5].ToString(),"DataEpisodeTalent");
						//CreateXMLSchemaFile(objArgs[6].ToString(),"DataTalent");

					}

					// Show the result...
					//MessageBox.Show(strResult);
					
				}
				else
				{
					if (cboMethods.Text=="GetBarCode")
					{

                        TVSServer.rdmPBSMediaInventory med = ComponentFactory.CreateMediaInventoryClass();
						object oBarCode =  null;
						string sECode = string.Empty;
						int nerr = med.GetBarCode(_SessionID,8114,out oBarCode,out sECode);
						if (null!=oBarCode)
						{
							
							Array arr  =  (Array) oBarCode;
							byte[] bbar =  new byte[arr.LongLength];
							for (long i = 0;i<arr.LongLength; i++)
							{
								bbar[i] = (byte)arr.GetValue(i);

							}
							FileStream newFile = new FileStream("C:\\Scriptsandstuff\\Jimupdatequeries\\barcode.pdf",FileMode.CreateNew);	
							newFile.Write(bbar,0,bbar.Length);
							newFile.Close();

						}
					}
					else
					{
						MessageBox.Show("This method cannot be executed. The output parameter aXMLData is missing!");
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private string getlockid(string sessionid)
		{
//			string strLockID = string .Empty;
//			object[] objArgs = new object[4];
//			objArgs[0] =sessionid;
//			objArgs[1] =8114;
//			objArgs[2] =true;
//			objArgs[2] =true;
//			objArgs[2] =true;

			return string.Empty;


		}

		private void CreateXMLSchemaFile(string sXML , string fName)

		{
			// Save this out....
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(sXML);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(_TargetDir + @"\BVSchema\" +
			fName + ".xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();

			FormSchemaEditor formSchemaEditor = new FormSchemaEditor();
			formSchemaEditor.Path = _TargetDir + @"\BVSchema\" +fName + ".xml";
			formSchemaEditor.MethodName = cboMethods.Text;
			formSchemaEditor.ShowDialog(this);




		}

		private void FormAdHocGenerator_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (_SessionID != "")
			{
				BVSession s = new BVSession();
				s.Logout(_SessionID);
				_SessionID = "";
			}
		}
	}
}