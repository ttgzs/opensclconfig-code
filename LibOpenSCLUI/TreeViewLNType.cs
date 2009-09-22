// LibOpenSCLUI
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of TreeViewLNType.
	/// </summary>
	public class TreeViewLNType
	{
		private TreeNode node;
		private ObjectManagement objectManagement;		
		private Utils guiUtils;
		private object classDataType;
		private TreeNode treeLNType;
		private TreeNode treeSCL;
		private int positionIED;
		private int positionAccessPoint;
		private int positionLN;
		private int positionLDevice;
		private bool bandAddLNToAP;
		private bool valueCheck;		
		private TreeNode nodeSDI;
		private TreeNode nodetSDI;
		private int countBandRepeateSDIDADataTypeBDA;
		private int countSDI;
		private TreeNode nodeDAI;
		private TreeNode nodetDAI;	
		private TreeNode nodeSDO;
		private TreeNode nodetSDO;
		private TreeNode nodeDOI;
		private TreeNode nodetDOI;		
		private TreeNode nodeDataType;		
		private TreeNode nodeLNodeType;
		private TreeNode nodetLNodeType;
		private TreeNode nodeDO; 
		private TreeNode nodetDO;		
		private TreeNode nodeDOType;
		private TreeNode nodetDOType;
		private TreeNode nodeDA;
		private TreeNode nodetDA;		
		private TreeNode nodeDAType;
		private TreeNode nodetDAType;
		private TreeNode nodeBDA;
		private TreeNode nodetBDA;		
		private TreeNode nodeEnum;
		private TreeNode nodetEnum;
		private TreeNode nodeEnumVal;
		private TreeNode nodetEnumVal;	
		private OpenSCL.Object sCL = new OpenSCL.Object();
		
		public TreeViewLNType(TreeNode treeSCL, SCL sCLObject)		
		{			
			this.treeSCL = treeSCL;
			this.sCL.Configuration = sCLObject;
			this.guiUtils = new Utils();						
			this.objectManagement = new ObjectManagement();						
			this.bandAddLNToAP = false;
			this.countSDI = 0;
			this.countBandRepeateSDIDADataTypeBDA = 0;
		}
				
		/// <summary>
		/// This method creates a TreeNode acording to specific structure.This structure contains primitive and personalized 
		/// datas for tDOI's, CDC. This structure is assigned to the LN type that is used as parameter. 
		/// </summary>
		/// <param name="lN">
		/// LN selected that is used to create a specific TreeNode. 
		/// </param>
		/// <returns>
		/// TreeNode created.
		/// </returns>
		/// <remarks>
		/// The LN types are included on the LNTypes.cs file.
		/// The "lnType" property shall have a value or an error will occur. 
		/// </remarks>
		public TreeNode GetTreeNodeTypesLNs(object lN)
		{
			this.setIndextIEDAccessPointLDevice();			
			this.treeLNType = new TreeNode();					
			object logicNodeType = this.CreateLogicNodeType(lN);			
			if(logicNodeType != null)
			{				
				this.CreateRootTreeLNType(logicNodeType);
				this.GetNameNodes(logicNodeType, treeLNType);
			}
			return this.treeLNType;
		}
		
		/// <summary>
		/// This method creates an object that has the structure of the LN selected.
		/// </summary>
		/// <param name="lN">
		/// LN selected that is used to create the structure. 
		/// </param>
		/// <returns>
		/// An object that has the structure for the LN selected.
		/// </returns>
		/// <remarks>
		/// The LN types are included on the LNTypes.cs file.
		/// </remarks>
		private object CreateLogicNodeType(object lN)
		{
			if(lN is tLN)
			{
				return this.objectManagement.CreateObject((lN as tLN).lnClass.ToString(),(lN as tLN).lnType, this.sCL.Configuration.IED[this.positionIED].type);
			}
			else if(lN is tLN0)
			{
				return this.objectManagement.CreateObject((lN as tLN0).lnClass.ToString(),(lN as tLN0).lnType, this.sCL.Configuration.IED[this.positionIED].type);
			}
			else
			{
				return null;
			}			
		}
		
		/// <summary>
		/// This method creates the root node of the TreeNode.
		/// </summary>
		/// <param name="LogicNodeType">
		/// Object that contains the specific structure of the LN type selected.
		/// </param>
		private void CreateRootTreeLNType(object logicNodeType)
		{
			this.treeLNType = new TreeNode();
			this.treeLNType.Name = "root";
			this.treeLNType.Text = "LN:"+logicNodeType.GetType().Name;
			this.treeLNType.Checked = true;
			this.treeLNType.Tag = logicNodeType;			
		}					
		
		/// <summary>
		/// This method gets the object that has the specific structure or some of the elements that composed it to create the 
		/// TreeNode.
		/// </summary>
		/// <param name="LNType">
		/// Object, where his properties will be used to creates TreeNodes.
		/// </param>
		/// <param name="treeLNType">
		/// TreeNode created from the elements of a predefined structure.
		/// </param>
		private void GetNameNodes(object LNType, TreeNode treeLNType)
		{
			object valueAttributeObject;
			PropertyInfo[] attributesInformation = LNType.GetType().GetProperties();			
			foreach (PropertyInfo attributeInformation in attributesInformation)
			{
				if((attributeInformation.PropertyType!=null&&
					(attributeInformation.PropertyType.Equals(typeof(SDIDADataTypeBDA))) ||
					(attributeInformation.PropertyType.BaseType!=null &&
				    (attributeInformation.PropertyType.BaseType.Equals(typeof(DOData)) ||
				     attributeInformation.PropertyType.BaseType.Equals(typeof(DADataType)) ||
				     attributeInformation.PropertyType.BaseType.Equals(typeof(SDIDADataTypeBDA)) ||
				     attributeInformation.PropertyType.BaseType.Equals(typeof(SDOSDIDOTypeDA)))))) 
				{
					valueAttributeObject = this.objectManagement.FindVariable(LNType,attributeInformation.Name);
					this.AddNodesOfArray(attributeInformation, valueAttributeObject, treeLNType);
				}
				else if(attributeInformation.PropertyType.Equals(typeof(DOData)))
				{
					valueAttributeObject = this.objectManagement.FindVariable(LNType,attributeInformation.Name);
				    this.GetNameNodes(valueAttributeObject, treeLNType);
				}
			}
		}
		
		/// <summary>
		/// This method gets the information and value of the attribute, creates the specific TreeNode and adds it to the 
		/// complete TreeNode.
		/// </summary>
		/// <param name="attributeInformation">
		/// Information of the attribute to create his TreeNode.
		/// </param>
		/// <param name="valueAttributeObject">
		/// Attributte's value.
		/// </param>
		/// <param name="treeSCL">
		/// TreeNode where the new TreeNode of the attribute will be included.
		/// </param>
		private void AddNodesOfArray(PropertyInfo attributeInformation, object valueAttributeObject, TreeNode treeSCL)
		{
			node = new TreeNode();
			node.Name = attributeInformation.Name;
			node.Tag = valueAttributeObject;
			foreach (object AttributeRestriction in attributeInformation.GetCustomAttributes(typeof(RequiredAttribute), true))
			{
				node.Checked=true;
				node.ForeColor = Color.Blue;
			}			
			this.valueCheck = (bool) this.objectManagement.FindVariable(valueAttributeObject,"CheckSelection");
			if(this.valueCheck)
			{
				node.Checked= true;
			}			
			if(attributeInformation.PropertyType!=null&& attributeInformation.PropertyType.BaseType!=null
			   &&(valueAttributeObject.GetType().BaseType.Equals(typeof(DOData))))
			{
				node.Text = "DO : "+(valueAttributeObject as DOData).name +" ( type ="+ attributeInformation.PropertyType.Name +" ) ";
				treeSCL.Nodes.Add(node);			
				this.GetNameNodes(valueAttributeObject, treeSCL.Nodes[attributeInformation.Name]);
			}
			else if(valueAttributeObject.GetType().BaseType.Equals(typeof(DADataType)))
			{
				classDataType = this.objectManagement.FindVariable(valueAttributeObject, "bType").ToString();
				node.Text = "DA : "+attributeInformation.Name+" ( type ="+ classDataType +" ) ";
				treeSCL.Nodes.Add(node);							
			}
			else if(valueAttributeObject.GetType().BaseType.Equals(typeof(SDIDADataTypeBDA))||valueAttributeObject.GetType().Equals(typeof(SDIDADataTypeBDA)))
			{
				classDataType = this.objectManagement.FindVariable(valueAttributeObject, "bType").ToString();
				if(classDataType.ToString().Equals("Struct"))
				{					
					if(node.Name.Equals("SDIDADataTypeBDA"))
					{
						node.Text = "SDI : "+this.objectManagement.FindVariable(valueAttributeObject, "name").ToString()+" ( type ="+ classDataType +" ) ";
					}
					else
					{
						node.Text = "SDI : "+attributeInformation.Name+" ( type ="+ classDataType +" ) ";
					}	
					treeSCL.Nodes.Add(node);			
					this.GetNameNodes(valueAttributeObject, treeSCL.Nodes[attributeInformation.Name]);
				}
				else
				{					
					node.Text = "DA : "+attributeInformation.Name+" ( type ="+ classDataType +" ) ";
					treeSCL.Nodes.Add(node);	
				}
			}
			else if(attributeInformation.PropertyType!=null&& attributeInformation.PropertyType.BaseType!=null
			   &&(valueAttributeObject.GetType().BaseType.Equals(typeof(SDOSDIDOTypeDA))))
			{					
				if(this.objectManagement.FindVariable(valueAttributeObject, "iedType").ToString().Equals("null"))
				{
					node.Text = "DA : "+attributeInformation.Name+" ( type ="+ (valueAttributeObject as SDOSDIDOTypeDA).bType +" ) ";
				}			
				else
				{
					node.Text = "SDO : "+(valueAttributeObject as SDOSDIDOTypeDA).name +" ( type ="+ (valueAttributeObject as SDOSDIDOTypeDA).cdc +" ) ";
				}
				treeSCL.Nodes.Add(node);			
				this.GetNameNodes(valueAttributeObject, treeSCL.Nodes[attributeInformation.Name]);
			}
		}
		
		/// <summary>
		/// This method sets a null value to the attribute's value selected on the TreeView of the LNTypes and includes 
		/// them to the main TreeView.
		/// </summary>
		public void EmptyTreeNodeLNType()
		{				
			this.setIndextIEDAccessPointLDevice();
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"]==null)
			{				
				tDataTypeTemplates dataTypeTemplates = new tDataTypeTemplates();
				this.objectManagement.AddObjectToSCLObject(dataTypeTemplates, sCL.Configuration);							
				this.nodeDataType = new TreeNode();				
				this.nodeDataType.Name = "tDataTypeTemplates";
				this.nodeDataType.Tag = sCL.Configuration.DataTypeTemplates;
				this.nodeDataType.Text = "tDataTypeTemplates";				
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeDataType);
			}
			else
			{
				this.nodeDataType = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"];
			}						
			tLNodeType lNodeType = new tLNodeType();		
			this.guiUtils.EmptyGUIObjectoSCLObject(this.treeLNType.Tag, lNodeType);	
			tLN lN = new tLN();		
			this.guiUtils.EmptyGUIObjectoSCLObject(this.treeLNType.Tag,lN);			
			if(this.objectManagement.AddObjectToArrayObjectOfParentObject(lNodeType,sCL.Configuration.DataTypeTemplates))
			{		
				if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[nodeDataType.Name].Nodes["tLNodeType[]"]==null)
				{
					this.nodeLNodeType = new TreeNode();
					this.nodeLNodeType.Name = "tLNodeType[]";
					this.nodeLNodeType.Text = "LNodeType";
					this.nodeLNodeType.Tag = sCL.Configuration.DataTypeTemplates.LNodeType;
					this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[nodeDataType.Name].Nodes.Add(nodeLNodeType);
				}
				else
				{
					this.nodeLNodeType = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tLNodeType[]"];			
				}											
				this.nodetLNodeType = new TreeNode();			
				this.nodetLNodeType.Name = lNodeType.id;
				this.nodetLNodeType.Tag = lNodeType;
				this.nodetLNodeType.Text = "tLNodeType";//lNodeType.id;
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[nodeDataType.Name].Nodes[nodeLNodeType.Name].Nodes.Add(nodetLNodeType);							
				this.InspectionNode(this.treeLNType);					
			}
		}
		
		/// <summary>
		/// This method gets a predefined class and his elements to identify if the values of the attributes  
		/// should be used in the predefined structure.
		/// </summary>
		/// <param name="treeLNType">
		/// A TreeNode that includes the attribute's value on the predefined structure.
		/// </param>
		private void InspectionNode(TreeNode treeLNType)			
		{			
			//this variable is used to count the SDI number of the same level.
			int countBand = 0;
			PropertyInfo[] attributesInformation = treeLNType.Tag.GetType().GetProperties();			
			foreach (PropertyInfo attributeInformation in attributesInformation)
			{
				if((attributeInformation.PropertyType.BaseType != null &&
				   (attributeInformation.PropertyType.BaseType.Equals(typeof(DOData)) || 
				    attributeInformation.PropertyType.BaseType.Equals(typeof(DADataType)) ||
				    attributeInformation.PropertyType.BaseType.Equals(typeof(SDIDADataTypeBDA)) ||
				    attributeInformation.PropertyType.BaseType.Equals(typeof(SDOSDIDOTypeDA))))&&
				   (treeLNType.Nodes[attributeInformation.Name].Checked))			  
				{					
					if(attributeInformation.PropertyType.BaseType.Equals(typeof(SDIDADataTypeBDA)))
					{						
						countBand++;   
					}
					this.countBandRepeateSDIDADataTypeBDA = countBand;
					this.GetValueNode(attributeInformation, treeLNType);
				}
				else if(attributeInformation.PropertyType.Equals(typeof(SDIDADataTypeBDA)))
				{
					this.classDataType = this.objectManagement.FindVariable(treeLNType.Tag, "bType").ToString();
					if(this.classDataType.ToString().Equals("Struct"))
					{						
						if(treeLNType.Nodes[attributeInformation.Name].Parent != null &&(!(treeLNType.Nodes[attributeInformation.Name].Parent.Tag is DOData))&&(attributeInformation.PropertyType.Equals(typeof(SDIDADataTypeBDA))))
						{						
							countBand++;
						}
						this.countBandRepeateSDIDADataTypeBDA = countBand;
						this.GetValueNode(attributeInformation, treeLNType);					
					}	
				}
				else if(attributeInformation.PropertyType.Equals(typeof(DOData)))
				{
					countBand++;
					this.countBandRepeateSDIDADataTypeBDA = countBand;
					treeLNType.Tag = this.objectManagement.FindVariable(treeLNType.Tag,attributeInformation.Name);				
				    this.InspectionNode(treeLNType);
				}
			}			
		}
		
		/// <summary>
		/// This method inlcudes the TreeNode of the LNType on the SCL treeNode according to the valid attributes of the 
		/// predefined structure. 
		/// </summary>
		/// <param name="attributeInformation">
		/// Attribute's information to be added on the SCL TreeNode (included on the main window).
		/// </param>
		/// <param name="treeLNType">
		/// TreeNode of the LNType that where selected by the user and that will be included on the main SCL TreeNode.
		/// </param>
		private void GetValueNode(PropertyInfo attributeInformation, TreeNode treeLNType)
		{
			node = treeLNType.Nodes[attributeInformation.Name];
			if(node.Tag is DOData)
			{					
				tDO dO = new tDO();
				this.guiUtils.EmptyGUIObjectoSCLObject(node.Tag, dO);
				this.objectManagement.AddObjectToArrayObjectOfParentObject(dO,
				this.sCL.Configuration.DataTypeTemplates.LNodeType[sCL.Configuration.DataTypeTemplates.LNodeType.Length-1]);
				if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tLNodeType[]"].Nodes[this.nodetLNodeType.Name].Nodes["tDO"+this.nodetLNodeType.Name]==null)
				{
					this.nodeDO = new TreeNode();
					this.nodeDO.Name = "tDO"+this.nodetLNodeType.Name;
					this.nodeDO.Text = "DO";	
					this.nodeDO.Tag = this.sCL.Configuration.DataTypeTemplates.LNodeType[sCL.Configuration.DataTypeTemplates.LNodeType.Length-1].DO;					
					this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeLNodeType.Name].Nodes[this.nodetLNodeType.Name].Nodes.Add(this.nodeDO);
				}
				else
				{
					this.nodeDO = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tLNodeType[]"].Nodes[this.nodetLNodeType.Name].Nodes["tDO"+this.nodetLNodeType.Name];						
				}		
				this.nodetDO = new TreeNode();					
				this.nodetDO.Name = "tDO"+(this.sCL.Configuration.DataTypeTemplates.LNodeType[sCL.Configuration.DataTypeTemplates.LNodeType.Length-1].DO.Length-1).ToString();
				this.nodetDO.Tag = dO;
				/// <code>
				/// "tDO"+(this.sCL.DataTypeTemplates.LNodeType[sCL.DataTypeTemplates.LNodeType.Length-1].DO.Length-1).ToString();
				/// </code>
				this.nodetDO.Text = "tDO"; 
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeLNodeType.Name].Nodes[this.nodetLNodeType.Name].Nodes[nodeDO.Name].Nodes.Add(nodetDO);					
				this.CreateDOType(node.Tag);
				this.CreateDOI(node.Tag);
				this.InspectionNode(node);
			}
			else if(node.Tag is DADataType)
			{										
				if(this.node.Parent.Tag is SDIDADataTypeBDA)
				{
					this.CreateBDA(node.Tag);
					this.CreateDAI(node.Tag);
				}
				else
				{
					this.CreateDA(node.Tag);
					this.CreateDAI(node.Tag);
					if((node.Tag as tDA).bType == tBasicTypeEnum.Struct)
					{
						this.CreateDAType(node.Tag);				
					}
					else if((node.Tag as tDA).bType == tBasicTypeEnum.Enum)
					{
						this.EmptyEnum();
					}
				}
			}
			else if(node.Tag is SDIDADataTypeBDA)
			{
				this.classDataType = this.objectManagement.FindVariable(node.Tag, "bType").ToString();
				if(this.classDataType.ToString().Equals("Struct"))
				{
					if(node.Parent.Tag is SDIDADataTypeBDA)
					{
						this.CreateBDA(node.Tag);
					}
					this.CreateSDI(node.Tag);
				}
				//This condition is used to get the DA property.
				else 
				{
					if(this.node.Parent.Tag is SDIDADataTypeBDA)
					{
						this.CreateBDA(node.Tag);
						this.CreateDAI(node.Tag);
					}
					else
					{
						this.CreateDA(node.Tag);
						this.CreateDAI(node.Tag);
						if((node.Tag as tDA).bType == tBasicTypeEnum.Struct)
						{
							this.CreateDAType(node.Tag);
						}
						else if((node.Tag as tDA).bType == tBasicTypeEnum.Enum)
						{
							this.EmptyEnum();
						}
					}				
				}				
			}	
			else if(node.Tag is SDOSDIDOTypeDA)
			{	
				classDataType = this.objectManagement.FindVariable(node.Tag, "iedType").ToString();
				if(classDataType.Equals("null"))
				{
					this.CreateDA(node.Tag);
					this.CreateDAI(node.Tag);
				}
				else
				{
					this.CreateSDO(node.Tag);
					this.CreateSDI(node.Tag);
				}				
			}
		}
				
		/// <summary>
		/// This method adds to the main SCL treeNode, the attributes of an Enum Type selected on the TreeNode of the LNType.
		/// </summary>
		/// <param name="enumtoDraw">
		/// Object used to create the TreeNodes on the main SCL tree.
		/// </param>
		private void drawEnums(tEnumType enumtoDraw)
		{			
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes["tEnumType[]"]==null)
			{
				this.nodeEnum = new TreeNode();
				this.nodeEnum.Name = "tEnumType[]";
				/// <code>
				/// "EnumType";
				/// </code>
				this.nodeEnum.Text = "EnumType";
				this.nodeEnum.Tag = this.sCL.Configuration.DataTypeTemplates.EnumType;
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes.Add(this.nodeEnum);		    
			}
			else
			{
				this.nodeEnum = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes["tEnumType[]"];			
			}			
			this.nodetEnum = new TreeNode();				
			this.nodetEnum.Name = "tEnumType"+(this.sCL.Configuration.DataTypeTemplates.EnumType.Length-1).ToString();
			/// <code>
			/// "tEnumType"+(this.sCL.DataTypeTemplates.EnumType.Length-1).ToString();//"tEnumType";
			/// </code>			
			this.nodetEnum.Text = "tEnumType";
			this.nodetEnum.Tag = enumtoDraw;
			this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeEnum.Name].Nodes.Add(this.nodetEnum);						
			this.nodeEnumVal = new TreeNode();
			this.nodeEnumVal.Name = enumtoDraw.id;
			/// <code>
			/// enumtoDraw.id;
			/// </code>
			this.nodeEnumVal.Text = "EnumVal";
			this.nodeEnumVal.Tag = enumtoDraw.EnumVal;				
			this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeEnum.Name].Nodes[this.nodetEnum.Name].Nodes.Add(this.nodeEnumVal);;
			for(int i=0; i<enumtoDraw.EnumVal.Length;i++)
			{					
				this.nodetEnumVal = new TreeNode();				
				this.nodetEnumVal.Name = "tEnumVal"+i.ToString();
				/// <code>
				/// "tEnumVal"+i.ToString();
				/// </code>
				this.nodetEnumVal.Text = "tEnumVal";
				this.nodetEnumVal.Tag = enumtoDraw.EnumVal[i];
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeEnum.Name].Nodes[this.nodetEnum.Name].Nodes[this.nodeEnumVal.Name].Nodes.Add(this.nodetEnumVal);
			}				
		}
		
		/// <summary>
		/// This method is used to get the position of the SDI, so the DAI and SDI can be added in his own SDI.		
		/// </summary>
		/// <param name="dOIs">
		/// DOI's type where the search of the required SDI will start.
		/// </param>
		/// <returns>
		/// Returns the SDI where the DAI's or SDI's will be added.
		/// </returns>
		// The search is limited by two counters countBandRepeateSDIDADataTypeBDA (it counts the quantity of the equal objects types 
		// are in the same level) and countSDI (it adds one by SDI level).
		private tSDI[] SearchSDI(tDOI dOI)
		{					
			if(this.countBandRepeateSDIDADataTypeBDA < 2)
			{
				if(this.countSDI!=0)
				{
					tSDI[] sDIs = (tSDI[]) this.objectManagement.FindVariable(dOI, "SDI");
					this.nodeSDI = this.nodeDOI.Nodes[this.nodeDOI.Nodes.Count-1].Nodes["tSDI[]"];
					for(int x = 1; x < this.countSDI; x++)
					{
						sDIs = (tSDI[]) this.objectManagement.FindVariable(sDIs[sDIs.Length-1], "SDI");
						this.nodeSDI = this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tSDI[]"];
					}
					return sDIs;
				}
				else return null;
			}
			else
			{
				this.countSDI = this.CountLevelLNTypeTreeNode(this.node, typeof(DOData));
				if(this.countSDI-1!=0)
				{
					tSDI[] sDIs = (tSDI[]) this.objectManagement.FindVariable(dOI, "SDI");
					this.nodeSDI = this.nodeDOI.Nodes[this.nodeDOI.Nodes.Count-1].Nodes["tSDI[]"];
					for(int x = 1; x < this.countSDI-1; x++)
					{
						sDIs = (tSDI[]) this.objectManagement.FindVariable(sDIs[sDIs.Length-1], "SDI");
						this.nodeSDI = this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tSDI[]"];
					}
					return sDIs;
				}
				else return null;
			}		
		}
		
		/// <summary>
		/// This method creates the DO type that will be added to the SCL tree.
		/// </summary>
		/// <param name="doTypePossible">
		/// DO information that will be added.
		/// </param>
		private void CreateDOType(object doTypePossible)
		{
			if(doTypePossible is SDOSDIDOTypeDA)
			{
				doTypePossible = this.objectManagement.FindVariable(doTypePossible, "DOData");
			}
			tDOType dOType = new tDOType();
			this.guiUtils.EmptyGUIObjectoSCLObject(doTypePossible, dOType);
			this.objectManagement.AddObjectToArrayObjectOfParentObject(dOType,this.sCL.Configuration.DataTypeTemplates);			
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDOType[]"]==null)
			{
				this.nodeDOType = new TreeNode();
				this.nodeDOType.Name = "tDOType[]";
				this.nodeDOType.Text = "DOType";
				this.nodeDOType.Tag = this.sCL.Configuration.DataTypeTemplates.DOType;
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes.Add(this.nodeDOType);
			}
			else
			{
				this.nodeDOType = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDOType[]"];
			}			
			this.nodetDOType = new TreeNode();
			/// <code>
			/// "tDOType"+(this.sCL.DataTypeTemplates.DOType.Length-1).ToString();
			/// </code>
			this.nodetDOType.Name = dOType.id;
			this.nodetDOType.Tag  = dOType;
			/// <code>
			/// dOType.id+this.nodeDOType.Nodes.Count;//"tDOType"+(this.sCL.DataTypeTemplates.DOType.Length-1).ToString();
			/// </code>			
			this.nodetDOType.Text = "tDOType";
			this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes.Add(this.nodetDOType);			
		}
		
		/// <summary>
		/// This method creates the DOI that will be added to the SCL tree.
		/// </summary>
		/// <param name="dOIPossible">
		/// DOI information that will be added.
		/// </param>
		private void CreateDOI(object dOIPossible)
		{
			tDOI dOI = new tDOI();
			this.guiUtils.EmptyGUIObjectoSCLObject(dOIPossible, dOI);			
			tDOI[] tDOIArray;
			if(this.bandAddLNToAP)
			{
				this.objectManagement.AddObjectToArrayObjectOfParentObject(dOI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN]);
				tDOIArray = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI;				
			}
			else
			{
				if(this.treeSCL.Tag is tLN0)
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(dOI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0);
					tDOIArray = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI;
				}
				else
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(dOI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN]);
					tDOIArray = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI;
				}
			}			
			if(this.treeSCL.Nodes["tDOI[]"]==null)
			{
				this.nodeDOI = new TreeNode();
				this.nodeDOI.Name = "tDOI[]";
				/// <code>
				/// "DOI";
				/// </code>					
				this.nodeDOI.Text = "DOI";
				this.nodeDOI.Tag = tDOIArray;
				this.treeSCL.Nodes.Add(nodeDOI);
			}
			else
			{
				this.nodeDOI = this.treeSCL.Nodes["tDOI[]"];
			}			
			this.nodetDOI = new TreeNode();
			this.nodetDOI.Name = "tDOI"+(tDOIArray.Length-1).ToString();
			this.nodetDOI.Tag = dOI;
			/// <code>
			/// "tDOI"+(tDOIArray.Length-1).ToString();//"tDOI";
			/// </code>				
			this.nodetDOI.Text = "tDOI";
			this.treeSCL.Nodes[this.nodeDOI.Name].Nodes.Add(this.nodetDOI);
		}
		
		/// <summary>
		/// This method creates the SDI that will be added on the SCL tree.
		/// </summary>
		/// <param name="sDIPossible">
		/// SDI information to be included.
		/// </param>
		private void CreateSDI(object sDIPossible)
		{
			tSDI sDI = new tSDI();
			this.guiUtils.EmptyGUIObjectoSCLObject(sDIPossible, sDI);
			tSDI[] tSDIArrayTemp;
			if((node.Parent != null &&(node.Parent.Tag is DOData))&&(node.Parent.Parent != null &&!(node.Parent.Parent.Tag is DOData)))
			{
				if(this.bandAddLNToAP)
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(sDI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].
					 DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI.Length-1]);					
					tSDIArrayTemp = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].
						DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI.Length-1].SDI;
				}
				else
				{
					if(this.treeSCL.Tag is tLN0)
					{
						this.objectManagement.AddObjectToArrayObjectOfParentObject(sDI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
						 LDevice[this.positionLDevice].LN0.DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI.Length-1]);						
						tSDIArrayTemp = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
							LDevice[this.positionLDevice].LN0.DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI.Length-1].SDI;
					}
					else
					{
						this.objectManagement.AddObjectToArrayObjectOfParentObject(sDI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
						  LDevice[this.positionLDevice].LN[this.positionLN].DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI.Length-1]);						
						tSDIArrayTemp = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
							LDevice[this.positionLDevice].LN[this.positionLN].DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI.Length-1].SDI;
					}
				}				
				if(this.treeSCL.Nodes["tDOI[]"].Nodes[this.nodetDOI.Index].Nodes["tSDI[]"]==null)
				{
					this.nodeSDI = new TreeNode();
					this.nodeSDI.Name = "tSDI[]";
					this.nodeSDI.Tag = tSDIArrayTemp;
					this.nodeSDI.Text = "SDI";
					this.treeSCL.Nodes[this.nodeDOI.Name].Nodes[this.nodetDOI.Name].Nodes.Add(nodeSDI);
				}
				else
				{
					this.nodeSDI = this.treeSCL.Nodes[this.nodeDOI.Name].Nodes[this.nodetDOI.Name].Nodes["tSDI[]"];
				}
				if(this.countBandRepeateSDIDADataTypeBDA < 2||this.countSDI==0)
				{
					this.countSDI++;
				}
				this.nodetSDI = new TreeNode();
				this.nodetSDI.Name = "tSDI"+(tSDIArrayTemp.Length-1).ToString();
				this.nodetSDI.Tag = sDI;
				this.nodetSDI.Text = "tSDI";
				this.treeSCL.Nodes[this.nodeDOI.Name].Nodes[this.nodetDOI.Name].Nodes[this.nodeSDI.Name].Nodes.Add(this.nodetSDI);				
				if(node.Tag is SDIDADataTypeBDA)
				{
					this.CreateDA(node.Tag);
					//Creating DAType
					this.CreateDAType(node.Tag);
				}
				else if(node.Tag is SDOSDIDOTypeDA)
				{
					this.CreateDOType(node.Tag);
				}				
				this.InspectionNode(node);
				this.countSDI = 0;
				this.nodeSDI = null;
			}
			else
			{
				tSDI[] sDIsTemp;
				int positionDOI;
				if(this.bandAddLNToAP)
				{
					positionDOI = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI.Length-1;					
					sDIsTemp = this.SearchSDI(this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI[positionDOI]);
					this.objectManagement.AddObjectToArrayObjectOfParentObject(sDI, sDIsTemp[sDIsTemp.Length-1]);
					tSDIArrayTemp = sDIsTemp[sDIsTemp.Length-1].SDI;
				}
				else
				{
					if(this.treeSCL.Tag is tLN0)
					{
						positionDOI = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI.Length-1;
						sDIsTemp = this.SearchSDI(this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI[positionDOI]);
						this.objectManagement.AddObjectToArrayObjectOfParentObject(sDI, sDIsTemp[sDIsTemp.Length-1]);						
						tSDIArrayTemp = sDIsTemp[sDIsTemp.Length-1].SDI;
					}
					else
					{
						positionDOI = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI.Length-1;
						sDIsTemp = this.SearchSDI(this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI[positionDOI]);
						this.objectManagement.AddObjectToArrayObjectOfParentObject(sDI, sDIsTemp[sDIsTemp.Length-1]);						
						tSDIArrayTemp = sDIsTemp[sDIsTemp.Length-1].SDI;
					}
				}
				if(this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tSDI[]"]==null)
				{
					TreeNode SDITemporal = new TreeNode();
					SDITemporal.Name = "tSDI[]";
					SDITemporal.Tag = tSDIArrayTemp;
					SDITemporal.Text = "SDI";
					this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes.Add(SDITemporal);
				}				
				this.nodetSDI = new TreeNode();
				this.nodetSDI.Name = "tSDI"+(tSDIArrayTemp.Length-1).ToString();
				this.nodetSDI.Tag = sDI;
				this.nodetSDI.Text = "tSDI";
				this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tSDI[]"].Nodes.Add(this.nodetSDI);
				if(this.countBandRepeateSDIDADataTypeBDA < 2)
				{
					this.countSDI++;
				}							
				if(node.Parent!=null&&node.Parent.Tag is DOData && node.Parent.Parent!=null&&node.Parent.Parent.Tag is DOData)
				{
					this.CreateDA(this.node.Tag);
				}				
				//Creating DAType
				if(node.Tag is SDIDADataTypeBDA)
				{
					this.CreateDAType(node.Tag);
				}									
				this.InspectionNode(node);
			}
		}
		
		/// <summary>
		///  This method creates the SDO that will be added on the SCL tree.
		/// </summary>
		/// <param name="sDOPossible">
		/// SDO information to be included.
		/// </param>
		private void CreateSDO(object sDOPossible)
		{
			tSDO sDO = new tSDO();
			this.guiUtils.EmptyGUIObjectoSCLObject(sDOPossible, sDO);			
			int countSDO = 0;			
			while(countSDO < this.sCL.Configuration.DataTypeTemplates.DOType.Length)
			{
				if(this.sCL.Configuration.DataTypeTemplates.DOType[countSDO].id.Equals((this.node.Parent.Tag as tDOType).id))
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(sDO, this.sCL.Configuration.DataTypeTemplates.DOType[countSDO]);
					break;
				}
				countSDO++;
			}				
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDOType[]"].Nodes[countSDO].Nodes["tSDO[]"]==null)
			{
				this.nodeSDO = new TreeNode();
				this.nodeSDO.Name = "tSDO[]";
				/// <code>
				/// "DA";
				/// </code>				
				this.nodeSDO.Text = "SDO";
				this.nodeSDO.Tag = this.sCL.Configuration.DataTypeTemplates.DOType[sCL.Configuration.DataTypeTemplates.DOType.Length-1].SDO;
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes[this.nodetDOType.Name].Nodes.Add(this.nodeSDO);				
			}
			else
			{
				this.nodeSDO = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes[countSDO].Nodes["tSDO[]"];
			}			
			this.nodetSDO = new TreeNode();
			/// <code>
			/// "tDA"+(this.sCL.DataTypeTemplates.DOType[sCL.DataTypeTemplates.DOType.Length-1].DA.Length-1).ToString();
			/// </code>
			this.nodetSDO.Name = sDO.name;
			this.nodetSDO.Tag = sDO;
			/// <code>
			/// SDO.name;
			/// </code>
			this.nodetSDO.Text = "tSDO";
			this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes[countSDO].Nodes[this.nodeSDO.Name].Nodes.Add(this.nodetSDO);			
		}
		
		/// <summary>
		/// This method creates the DA that will be added on the SCL tree.
		/// </summary>
		/// <param name="dAPossible">
		/// DADataType and SDIDADataTypeBDA information to be included.
		/// </param>
		private void CreateDA(object dAPossible)
		{
			tDA dA = new tDA();
			this.guiUtils.EmptyGUIObjectoSCLObject( dAPossible, dA);
			int countDA = 0;
			while(countDA < this.sCL.Configuration.DataTypeTemplates.DOType.Length)
			{
				if(this.sCL.Configuration.DataTypeTemplates.DOType[countDA].id.Equals((this.node.Parent.Tag as tDOType).id))
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(dA, this.sCL.Configuration.DataTypeTemplates.DOType[countDA]);
					break;
				}
				countDA++;
			}			
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDOType[]"].Nodes[this.nodetDOType.Name].Nodes["tDA[]"]==null)
			{
				this.nodeDA = new TreeNode();
				this.nodeDA.Name = "tDA[]";
				/// <code>
				/// "DA";
				/// </code>
				this.nodeDA.Text = "DA";
				this.nodeDA.Tag = this.sCL.Configuration.DataTypeTemplates.DOType[sCL.Configuration.DataTypeTemplates.DOType.Length-1].DA;
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes[this.nodetDOType.Name].Nodes.Add(this.nodeDA);				
			}
			else
			{
				this.nodeDA = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes[this.nodetDOType.Name].Nodes["tDA[]"];
			}			
			this.nodetDA = new TreeNode();
			/// <code>
			/// "tDA"+(this.sCL.Configuration.DataTypeTemplates.DOType[sCL.Configuration.DataTypeTemplates.DOType.Length-1].DA.Length-1).ToString();
			/// </code>
			this.nodetDA.Name = dA.name;
			this.nodetDA.Tag = dA;
			/// <code>
			/// dA.name;
			/// </code>
			this.nodetDA.Text = "tDA";
			this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDOType.Name].Nodes[this.nodetDOType.Name].Nodes[this.nodeDA.Name].Nodes.Add(this.nodetDA);
		}
		
		/// <summary>
		/// This method creates the DAI that will be added on the SCL tree.
		/// </summary>
		/// <param name="dAIPossible">
		/// DADataType information to be included.
		/// </param>
		private void CreateDAI(object dAIPossible)
		{
			tDAI dAI = new tDAI();
			this.guiUtils.EmptyGUIObjectoSCLObject(dAIPossible, dAI);
			tDAI[] tDAIArrayTemp;
			if(this.nodeSDI == null)
			{
				if(this.bandAddLNToAP)
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(dAI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].
						DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI.Length-1]);						
					tDAIArrayTemp = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].
						DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI.Length-1].DAI;
				}
				else
				{
					if(this.treeSCL.Tag is tLN0)
					{
						this.objectManagement.AddObjectToArrayObjectOfParentObject(dAI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
							LDevice[this.positionLDevice].LN0.DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI.Length-1]);							
						tDAIArrayTemp = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
							LDevice[this.positionLDevice].LN0.DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI.Length-1].DAI;
					}
					else
					{
						this.objectManagement.AddObjectToArrayObjectOfParentObject(dAI, this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
							LDevice[this.positionLDevice].LN[this.positionLN].DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI.Length-1]);							
						tDAIArrayTemp = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.
							LDevice[this.positionLDevice].LN[this.positionLN].DOI[this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI.Length-1].DAI;
					}
				}					
				if(this.treeSCL.Nodes["tDOI[]"].Nodes[this.nodetDOI.Index].Nodes["tDAI[]"]==null)
				{
					this.nodeDAI = new TreeNode();
					this.nodeDAI.Name = "tDAI[]";
					this.nodeDAI.Tag = tDAIArrayTemp;
					this.nodeDAI.Text = "DAI";//"DAI";
					this.treeSCL.Nodes[this.nodeDOI.Name].Nodes[this.nodetDOI.Name].Nodes.Add(nodeDAI);
				}
				else
				{
					this.nodeDAI = this.treeSCL.Nodes[this.nodeDOI.Name].Nodes[this.nodetDOI.Name].Nodes["tDAI[]"];
				}
				this.nodetDAI = new TreeNode();
				this.nodetDAI.Name = "tDAI"+(tDAIArrayTemp.Length-1).ToString();
				this.nodetDAI.Tag = dAI;
				/// <code>
				/// "tDAI"+(tDAIArrayTemp.Length-1).ToString();
				/// "tDAI";
				/// </code>
				this.nodetDAI.Text = "tDAI";
				this.treeSCL.Nodes[this.nodeDOI.Name].Nodes[this.nodetDOI.Name].Nodes[this.nodeDAI.Name].Nodes.Add(this.nodetDAI);
			}
			else if(this.nodeSDI != null)
			{
				int positionDOI;
				tSDI[] sDIsTemp;
				if(this.bandAddLNToAP)
				{
					positionDOI = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI.Length-1;						
					sDIsTemp = this.SearchSDI(this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].LN[this.positionLN].DOI[positionDOI]);
					this.objectManagement.AddObjectToArrayObjectOfParentObject(dAI, sDIsTemp[sDIsTemp.Length-1]);
					tDAIArrayTemp = sDIsTemp[sDIsTemp.Length-1].DAI;						
				}
				else
				{
					if(this.treeSCL.Tag is tLN0)
					{
						positionDOI = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI.Length-1;
						sDIsTemp = this.SearchSDI(this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN0.DOI[positionDOI]);
						this.objectManagement.AddObjectToArrayObjectOfParentObject(dAI, sDIsTemp[sDIsTemp.Length-1]);							
						tDAIArrayTemp = sDIsTemp[sDIsTemp.Length-1].DAI;
					}
					else
					{
						positionDOI = this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI.Length-1;
						sDIsTemp = this.SearchSDI(this.sCL.Configuration.IED[this.positionIED].AccessPoint[this.positionAccessPoint].Server.LDevice[this.positionLDevice].LN[this.positionLN].DOI[positionDOI]);
						this.objectManagement.AddObjectToArrayObjectOfParentObject(dAI, sDIsTemp[sDIsTemp.Length-1]);							
						tDAIArrayTemp = sDIsTemp[sDIsTemp.Length-1].DAI;							
					}
				}					
				if(this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tDAI[]"]==null)
				{
					this.nodeDAI = new TreeNode();
					this.nodeDAI.Name = "tDAI[]";
					this.nodeDAI.Tag = tDAIArrayTemp;
					/// <code>
					/// "DAI";
					/// </code>
					this.nodeDAI.Text = "DAI";
					this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes.Add(this.nodeDAI);
				}
				else
				{
					this.nodeDAI = this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tDAI[]"];
				}
				this.nodetDAI = new TreeNode();
				this.nodetDAI.Name = "tDAI"+(tDAIArrayTemp.Length-1).ToString();
				this.nodetDAI.Tag = dAI;
				/// <code>
				/// "tDAI"+(tDAIArrayTemp.Length-1).ToString();
				/// "tDAI";
				/// </code>
				this.nodetDAI.Text = "tDAI";
				this.nodeSDI.Nodes[this.nodeSDI.Nodes.Count-1].Nodes["tDAI[]"].Nodes.Add(this.nodetDAI);
			}		
		}
		
		/// <summary>
		/// This method creates the DAType that will be added on the SCL tree.
		/// </summary>
		/// <param name="dATypePossible">
		/// DADataType and SDIDADataTypeBDA information to be included.
		/// </param>
		private void CreateDAType(object dATypePossible)
		{
			tDAType dAType = new tDAType();
			this.guiUtils.EmptyGUIObjectoSCLObject(dATypePossible, dAType);					
			this.objectManagement.AddObjectToArrayObjectOfParentObject(dAType, this.sCL.Configuration.DataTypeTemplates);						
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes["tDAType[]"]==null)
			{	
				this.nodeDAType = new TreeNode();
				this.nodeDAType.Name = "tDAType[]";
				/// <code>
				/// "DAType";	
				/// </code>				
				this.nodeDAType.Text = "DAType";
				this.nodeDAType.Tag = this.sCL.Configuration.DataTypeTemplates.DAType;
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes.Add(this.nodeDAType);							
			}
			else
			{
				this.nodeDAType = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes["tDAType[]"];
			}
			
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[dAType.id]==null)
			{
				this.nodetDAType = new TreeNode();
				this.nodetDAType.Name = dAType.id;
				this.nodetDAType.Tag  = dAType;
				/// <code>
				/// dAType.id;
				/// </code>
				this.nodetDAType.Text = "tDAType";
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes.Add(this.nodetDAType);
				this.InspectionNode(node);
				this.nodeSDI = this.nodetSDI = null;
			}
			else
			{
				this.nodetDAType = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[dAType.id];
			}						
		}
		
		/// <summary>
		/// This method creates the BDA that will be added on the SCL tree.
		/// </summary>
		/// <param name="bDAPossible">
		/// BDA information to be included.
		/// </param>
		private void CreateBDA(object bDAPossible)
		{
			tBDA bDA = new tBDA();
			this.guiUtils.EmptyGUIObjectoSCLObject(bDAPossible, bDA);			
			int countDAType = 0;
			if(this.countBandRepeateSDIDADataTypeBDA < 2)
			{
				this.objectManagement.AddObjectToArrayObjectOfParentObject(bDA, this.sCL.Configuration.DataTypeTemplates.DAType[this.sCL.Configuration.DataTypeTemplates.DAType.Length-1]);
			}
			else
			{
				while(countDAType < this.sCL.Configuration.DataTypeTemplates.DAType.Length)
				{					
					if(this.sCL.Configuration.DataTypeTemplates.DAType[countDAType].id.Equals((this.node.Parent.Tag as tDA).type))
					{
						this.objectManagement.AddObjectToArrayObjectOfParentObject(bDA, this.sCL.Configuration.DataTypeTemplates.DAType[countDAType]);
						break;
					}
					countDAType++;
				}				
			}		
			this.nodetBDA = new TreeNode();			
			if(this.countBandRepeateSDIDADataTypeBDA < 2)
			{			
				if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[this.nodetDAType.Name].Nodes["tBDA[]"]==null)
				{
					this.nodeBDA = new TreeNode();
					this.nodeBDA.Name = "tBDA[]";
					/// <code>
					/// "BDA";
					/// </code>
					this.nodeBDA.Text = "BDA";
					this.nodeBDA.Tag = this.sCL.Configuration.DataTypeTemplates.DAType[this.sCL.Configuration.DataTypeTemplates.DAType.Length-1].BDA;
					this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[this.nodetDAType.Name].Nodes.Add(this.nodeBDA);
				}
				else
				{
					this.nodeBDA = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[this.nodetDAType.Name].Nodes["tBDA[]"];
				}			
				this.nodetBDA.Name = "tBDA"+(this.sCL.Configuration.DataTypeTemplates.DAType[this.sCL.Configuration.DataTypeTemplates.DAType.Length-1].BDA.Length-1).ToString();
				this.nodetBDA.Tag = bDA;
				/// <code>
				/// "tBDA"+(this.sCL.DataTypeTemplates.DAType[this.sCL.DataTypeTemplates.DAType.Length-1].BDA.Length-1).ToString();"tBDA";
				/// "tBDA";
				/// </code>
				this.nodetBDA.Text = "tBDA";
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[this.nodetDAType.Name].Nodes[this.nodeBDA.Name].Nodes.Add(this.nodetBDA);
			}
			else
			{
				if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[countDAType].Nodes["tBDA[]"]==null)
				{
					this.nodeBDA = new TreeNode();
					this.nodeBDA.Name = "tBDA[]";
					/// <code>
					/// "tBDA"
					/// </code>
					this.nodeBDA.Text = "BDA";
					this.nodeBDA.Tag = this.sCL.Configuration.DataTypeTemplates.DAType[countDAType].BDA;
					this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[countDAType].Nodes.Add(this.nodeBDA);
				}
				else
				{
					this.nodeBDA = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[countDAType].Nodes["tBDA[]"];
				}
				this.nodetBDA.Name = "tBDA"+(this.sCL.Configuration.DataTypeTemplates.DAType[countDAType]).ToString();
				this.nodetBDA.Tag = bDA;
				/// <code>
				/// "tBDA"+(this.sCL.DataTypeTemplates.DAType[this.sCL.DataTypeTemplates.DAType.Length-1].BDA.Length-1).ToString();
				/// "tBDA";
				/// </code>
				this.nodetBDA.Text = "tBDA";
				this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes[this.nodeDataType.Name].Nodes[this.nodeDAType.Name].Nodes[countDAType].Nodes[this.nodeBDA.Name].Nodes.Add(this.nodetBDA);
			}						
			if(bDA.bType == tBasicTypeEnum.Enum)
			{
				this.EmptyEnum();
			}
		}
		
		/// <summary>
		/// This method inicialize, adds and returns the level on a TreeNode that contains the specific data.
		/// </summary>
		/// <param name="lNTypeTreeNode">
		/// Level of the LNtype on the TreeNode.
		/// </param>
		/// <param name="typeLNToSearch">
		/// Type included on the Parent Treenode that will finish the count.
		/// </param>
		/// <returns>
		/// Returns the level of the specific TreeNode, if the type is not located to finish the count process then 
		/// a -1 value is returned.
		/// </returns>
		private int CountLevelLNTypeTreeNode(TreeNode lNTypeTreeNode, Type typeLNToSearch)
		{
			int countLevel = -1;
			if(lNTypeTreeNode==null||lNTypeTreeNode.Parent ==null)
			{
				return -1;
			}
			else if(lNTypeTreeNode.Tag.GetType().BaseType == typeLNToSearch)
			{
				if(lNTypeTreeNode.Parent != null && lNTypeTreeNode.Parent.Tag.GetType().BaseType == typeLNToSearch)
				{
					return (countLevel +=2);					
				}				
				else
				{
					return ++countLevel;
				}			 	
			}
			else
			{
				++countLevel;
				return this.CountLevelLNTypeTreeNode(lNTypeTreeNode.Parent, typeLNToSearch, countLevel);
			}
		}
		
		/// <summary>
		/// This method inicialize, adds and returns the level on a TreeNode that contains the specific data.
		/// </summary>
		/// <param name="lNTypeTreeNode">
		/// Level of the LNtype on the TreeNode.
		/// </param>
		/// <param name="typeLNToSearch">
		/// Type included on the Parent Treenode that will finish the count.
		/// </param>
		/// <param name="countLevel">
		/// Count of the Level on the Tree.
		/// </param>
		/// <returns>
		/// Returns the level of the specific TreeNode, if the type is not located to finish the count process then 
		/// a -1 value is returned.
		/// </returns>
		private int CountLevelLNTypeTreeNode(TreeNode lNTypeTreeNode, Type typeLNToSearch, int countLevel)
		{			
			if(lNTypeTreeNode==null||lNTypeTreeNode.Parent ==null)
			{
				return -1;
			}
			else if(lNTypeTreeNode.Tag.GetType().BaseType == typeLNToSearch)
			{
				if(lNTypeTreeNode.Parent != null && lNTypeTreeNode.Parent.Tag.GetType().BaseType == typeLNToSearch)
				{
					return (countLevel +=2);					
				}				
				else
				{
					return ++countLevel;
				}		
			}
			else
			{
				++countLevel;
				return this.CountLevelLNTypeTreeNode(lNTypeTreeNode.Parent, typeLNToSearch, countLevel);
			}
		}
				
		/// <summary>
		/// This method inicialize the IED, AccessPoint and LDevice positions. The LDevice position is assigned only if a DOI
		/// will be added on his tLN.
		/// </summary>
		/// <remarks>
		/// If the tLN belongs to an AccessPoint node then a true value will be assigned to the variable "bandAddLNToAP" otherwise
		/// a false value will be assigned.
		/// </remarks>
		private void setIndextIEDAccessPointLDevice()
		{
			this.positionLN = this.treeSCL.Index;
			if(this.treeSCL.Parent.Parent.Tag is tAccessPoint)
			{
				this.bandAddLNToAP = true;
				this.positionAccessPoint = this.treeSCL.Parent.Parent.Index; 						
				this.positionIED = this.treeSCL.Parent.Parent.Parent.Parent.Index; 				
			}
			else if(this.treeSCL.Tag is LN0)
			{			
				this.bandAddLNToAP = false;																		
				this.positionLDevice = this.treeSCL.Parent.Index; 			
				this.positionAccessPoint = this.treeSCL.Parent.Parent.Parent.Parent.Index; 
				this.positionIED = this.treeSCL.Parent.Parent.Parent.Parent.Parent.Parent.Index; 				
			}	
			else if(this.treeSCL.Parent.Parent.Tag is tLDevice)
			{			
				this.bandAddLNToAP = false;								
				this.positionLDevice = this.treeSCL.Parent.Parent.Index;
				this.positionAccessPoint = this.treeSCL.Parent.Parent.Parent.Parent.Parent.Index; 
				this.positionIED = this.treeSCL.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Index; 									
			}		
		}		

		/// <summary>
		/// This method sets the values of an specific LN that was previously selected to a structure of LNTypes to modify them. 
		/// </summary>
		/// <param name="lN">
		/// LN object that will be used to set his values at predefined structure.
		/// </param>
		/// <returns>
		/// A TreeNode where shows the attributes of the LN previously selected to be modified. 
		/// </returns>
		public TreeNode ReloadLNType(object lN)
		{
			this.setIndextIEDAccessPointLDevice();			
			this.treeLNType = new TreeNode();
			object logicNodeType = this.CreateLogicNodeType(lN);			
			if(logicNodeType != null)				
			{			
				this.CreateRootTreeLNType(logicNodeType);
				this.ReloadValuesToTreeNodeLNType((CommonLogicalNode) logicNodeType);
				this.GetNameNodes(logicNodeType, treeLNType);
			}
			return this.treeLNType;
		}
		
		/// <summary>
		/// This method sets the values of an specific LN that was previously selected to a structure of LNTypes to modify them. 
		/// </summary>
		/// <param name="logicNodeType">
		/// Main clase that use all the values included on the predefined structures to create the TreeNode.
		/// </param>
		private void ReloadValuesToTreeNodeLNType(CommonLogicalNode logicNodeType)
		{			
			for(int x = 0; x < this.sCL.Configuration.DataTypeTemplates.LNodeType.Length; x++)
			{
				if(this.sCL.Configuration.DataTypeTemplates.LNodeType[x].id.Equals(logicNodeType.id ))
				{
					int z = 0;
					for(int y = 0; y < this.sCL.Configuration.DataTypeTemplates.LNodeType[x].DO.Length; y++)
					{
						for(; z < this.sCL.Configuration.DataTypeTemplates.DOType.Length; z++)
						{
							if(this.sCL.Configuration.DataTypeTemplates.DOType[z].id.Equals(this.sCL.Configuration.DataTypeTemplates.LNodeType[x].DO[y].type))
							{
								object DOData = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].cdc, this.sCL.Configuration.DataTypeTemplates.LNodeType[x].DO[y].name, logicNodeType.lnType, logicNodeType.iedType);
								this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DOType[z], DOData);	
								if(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA!=null)
								{
									this.objectManagement.FindVariableAndSetValue(DOData, "DA", null);
								}		
								this.objectManagement.FindVariableAndSetValue(DOData, "CheckSelection", true);										
								this.objectManagement.FindVariableAndSetValue(logicNodeType, this.sCL.Configuration.DataTypeTemplates.LNodeType[x].DO[y].name,DOData);
								this.ReloadDADataType(DOData, z, logicNodeType.lnType);
								object SDOSDIDOTypeDA;
								if(this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO!=null)
								{	
									this.objectManagement.FindVariableAndSetValue(DOData, "SDO", null);
									int count = 0;
									for(; count < this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO.Length; count++)
									{
										SDOSDIDOTypeDA = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO[count].name, logicNodeType.iedType, this.sCL.Configuration.DataTypeTemplates.DOType[z].id);
										this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO[count], SDOSDIDOTypeDA);	
										this.objectManagement.FindVariableAndSetValue(DOData, this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO[count].name, SDOSDIDOTypeDA);	
										this.objectManagement.FindVariableAndSetValue(SDOSDIDOTypeDA, "CheckSelection", true);
										for(int count2 = z+1; count2 < this.sCL.Configuration.DataTypeTemplates.DOType.Length; count2++)
										{
											if(this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO[count].type == this.sCL.Configuration.DataTypeTemplates.DOType[count2].id)
											{
												object DODataSon = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DOType[count2].cdc, "",this.sCL.Configuration.DataTypeTemplates.DOType[z].SDO[count].type, logicNodeType.iedType);
												this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DOType[count2], DODataSon);													
												this.objectManagement.FindVariableAndSetValue(DODataSon, "DA", null);
												this.objectManagement.FindVariableAndSetValue(DODataSon, "SDO", null);												
												this.objectManagement.FindVariableAndSetValue(DODataSon, "CheckSelection", true);	
												this.objectManagement.SetValueMethod(SDOSDIDOTypeDA, "SetLinkDOData", DODataSon);
												this.ReloadDADataType(DODataSon, count2, logicNodeType.lnType);
												break;
											}											
										}									
									}
								}								
								break;
							}
						}
					}				
					break;
				}				
			}			
		}	

		/// <summary>
		/// This method sets the values of the DA classes to the properties on a predefined class.
		/// </summary>
		/// <param name="DOData">
		/// DO object where the DA classes will be added.
		/// </param>
		/// <param name="z">
		/// Position where DA is located.
		/// </param>
		/// <param name="iedType">
		/// Type of the IED.
		/// </param>
		private void ReloadDADataType(object DOData, int z, string iedType)
		{
			for(int index = 0; this.sCL.Configuration.DataTypeTemplates.DOType[z].DA != null &&index < this.sCL.Configuration.DataTypeTemplates.DOType[z].DA.Length; index++)
			{
				object DADataType;
				if(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].bType == tBasicTypeEnum.Struct)
				{
					DADataType = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].name, iedType, this.sCL.Configuration.DataTypeTemplates.DOType[z].id);
				}
				else
				{
					DADataType = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].name, this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].bType );
				}
				this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index], DADataType);			
				this.objectManagement.FindVariableAndSetValue(DADataType, "CheckSelection", true);
				this.objectManagement.FindVariableAndSetValue(DOData, this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].name, DADataType);
				if(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].bType == tBasicTypeEnum.Struct)
				{
					for(int index2 = 0; index2 <this.sCL.Configuration.DataTypeTemplates.DAType.Length; index2++)
					{
						if(this.sCL.Configuration.DataTypeTemplates.DAType[index2].id == this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].type)
						{
							object sDIDADataTypeBDA = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].name, this.sCL.Configuration.DataTypeTemplates.DAType[index2].iedType, this.sCL.Configuration.DataTypeTemplates.DOType[z].id);
							this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index], sDIDADataTypeBDA);
							this.objectManagement.FindVariableAndSetValue(sDIDADataTypeBDA, "CheckSelection", true);
							this.objectManagement.FindVariableAndSetValue(DOData, this.sCL.Configuration.DataTypeTemplates.DOType[z].DA[index].name, sDIDADataTypeBDA);
							this.ReloadSDIDADataTypeBDA(sDIDADataTypeBDA, ref index2);
						}
					}
				}
			}
		}
		
		/// <summary>
		/// This method sets the values of the DAType and BDA classes to the properties on a predefined class. 
		/// </summary>
		/// <param name="sDIDADataTypeBDA">
		/// DAType or BDA object where the values will be assigned.
		/// </param>		
		/// <param name="index2">
		/// Position where the DAType is located.
		/// </param>
		private void ReloadSDIDADataTypeBDA(object sDIDADataTypeBDA, ref int index2)
		{
			int index2Temp = index2;
			for(int index3 = 0; this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA !=null && index3 <  this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA.Length; index3++)
			{
				if(this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].bType.ToString().Equals("Struct"))
				{							
					object sDIDADataTypeBDASon = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].name, this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].iedType, this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].id);
					this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3], sDIDADataTypeBDASon);
					this.objectManagement.FindVariableAndSetValue(sDIDADataTypeBDASon, "CheckSelection", true);
					this.classDataType = this.objectManagement.FindVariable(sDIDADataTypeBDA, "SDIDADataTypeBDA");
					if(this.classDataType!=null)
					{
						this.objectManagement.FindVariableAndSetValue(sDIDADataTypeBDA, "SDIDADataTypeBDA", sDIDADataTypeBDASon);
					}
					else
					{
						this.objectManagement.FindVariableAndSetValue(sDIDADataTypeBDA, this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].name, sDIDADataTypeBDASon);
					}					
					if(this.sCL.Configuration.DataTypeTemplates.DAType[index2+1].id == this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].type)
					{						
						index2++;
						this.ReloadSDIDADataTypeBDA(sDIDADataTypeBDASon, ref index2);
					}
				}
				else
				{					
					object BDAData = this.objectManagement.CreateObject(this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].name,this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].bType);
					this.guiUtils.EmptySCLObjectoGUIObject(this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3], BDAData);
					this.objectManagement.FindVariableAndSetValue(BDAData, "CheckSelection", true);
					this.objectManagement.FindVariableAndSetValue(sDIDADataTypeBDA, this.sCL.Configuration.DataTypeTemplates.DAType[index2Temp].BDA[index3].name, BDAData);
				}
			}
		}
		
		/// <summary>
		/// This method verifies if there is an object tEnum, if there is not then it is added to the SCL class.
		/// </summary>
		private void EmptyEnum()
		{			
			tEnumType enumType = new tEnumType();
			this.guiUtils.EmptyGUIObjectoSCLObject(node.Tag, enumType);			
			if(this.sCL.Configuration.DataTypeTemplates.EnumType!=null)
			{				
				for(int j=0; j < this.sCL.Configuration.DataTypeTemplates.EnumType.Length; j++)
				{
					if(this.sCL.Configuration.DataTypeTemplates.EnumType[j].id == enumType.id)
					{
						enumType = null;
						break;
					}
				}				
			}				
			if(enumType!=null)
			{
				this.objectManagement.AddObjectToArrayObjectOfParentObject(enumType, this.sCL.Configuration.DataTypeTemplates);			
				this.drawEnums(enumType);
			}			
		}
	}
}