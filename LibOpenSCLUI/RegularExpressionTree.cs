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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of RegularExpresionValidation.
	/// </summary>
	public class RegularExpressionTree
	{		
		public RegularExpressionTree()
		{
			
		}
		
		/// <summary>
		/// This method gets an expression that is used to delete a node and his references from the tree.
		/// </summary>
		/// <param name="sCLTreeNode">
		/// Node of the tree that will be deleted.
		/// </param>
		/// <returns>
		/// It returns the expression that it's used to delete the node with all hs references from the tree. 
		/// </returns>
		public string GetRegExpToDelete(TreeNode sCLTreeNode)
		{			
			if(sCLTreeNode.Tag.GetType().IsArray)
			{
				return("%*0");
			}			
			else
			{				
				switch(sCLTreeNode.Tag.GetType().Name)
				{						
					case "tLN":		
						if(sCLTreeNode.Parent.Parent.Tag is tAccessPoint)
						{												
							return "-DOI/%&lnType->[4]&lnType->[2]&lnClass->[0]&inst->[1]&....type->[5]&name->[3]^^-lnClass=&lnInst=&lnType=&iedName=;-id=&iedType=;%%*1";
						}
						else if(sCLTreeNode.Parent.Parent.Tag is tLDevice)
						{							
							return "-DOI/%&lnType->[5]&lnType->[2]&lnClass->[0]&inst->[1]&..inst->[3]&.....type->[6]&name->[4]^^-lnClass=&lnInst=&lnType=&ldInst=&iedName=;-id=&iedType=;%%*1";
						}							
						else
						{
							return "-*1";
						}					
					case "LN0":
						return"-DataSet/%&-ReportControl/%&-DOI/%&-GSEControl/%&-LogControl/%&-Inputs/%&-SettingControl/%&-SCLControl/%&-Log/%&lnType->&......type->^-id=&iedType=;%%*1";
					case"tIED":
						return"-AccessPoint/%&name->^-iedName=;%%*1";
					case"tAccessPoint":
						return"-Server/%&name->&..name->^-apName=&iedName=;%%*1";
					case"tServer":
						return"-LDevice/%&...name->^-iedName=;%%*1";
					case "tLNodeType":
						return "-DO/%*1";
					case "tLDevice":
						return"-LN/%&inst->^-ldInst=;%%*1";
					//It should taken in count the tree kind of object that has it: tLDevice, tAccessPoint and LN0		
					case "tDOI":
						//Finding : tFCDA                          tDO     Deleting : tFCDA                 tDO
						return "-SDI/%&name->..lnType->&lnClass->&inst->^[1]&[0]^-doName=&ldInst=&lnClass=&lnInst=;-id=&name=;%%*1";												
					case "tDO":			
						//Finding : tDOType        Deleting : tDOType
						return "type->..iedType->^-id=&iedType=;%%*1";						
					case"tSDI":
						return "-SDI/%&-DAI/%*1";						
					case "tDOType":
						//Finding all the tDA that contents this object and use his regular expression to delete it.
						return "-DA/%&-SDO/%*1";
					case "tDA":
						//Finding: tDOType        Deleting: tDaType if the bType is equal to bType
						return "type->&bType->==Struct1#&..iedType->^-id=&iedType=;%%*1"; 
					case"tRptEnabled":
						return"-ClientLN/%*1";
					case "tSDO":
						return "type->^-id=;%%*1";
					case "tDAType":
						return "-BDA/%*1"; 
					// This node is used on Substation
					case "tDataSet" :
						return "-FCDA/%*1";
					case"tInputs":
						return"-ExtRef/%*1";
					case"tLogControl":
						return"-TrgOps/%*1";
					case "tBDA" :
						return "type->==$0&bType->==Struct1#^-id=;%%*1"; 							
					default:
						return "-*1";
				}			
			}		
		}
	}

	/// <summary>
	/// This class contents the methods to validate an expression.
	/// </summary>
	public class AutomataForValidateToTreeNode
	{
		List<ErrorsManagement> ListErrors;
		TreeNode node;
		int index;		
		string keys;
		char[] character;		
		RegularExpression regularExpression;		
		string nameProperty;
		ArrayList property;
		ArrayList valueProperties;		
		ArrayList namesPropertiesObject;
		object valueProperty;
		ObjectManagement objectManagement;
		object objectSCL;				
		string number;		
		int kTemp2;		
		int indexOfObject;
		bool flag;
		List<bool> flags;
		char operation;
		RegularExpressionTree regularExpressionTree;	
		TreeNode selectNodeToDelete;
		TreeViewSCL treeViewSCL = new TreeViewSCL ();
		
		public AutomataForValidateToTreeNode(TreeNode node, string keys)
		{
			this.ListErrors = new List<ErrorsManagement>();
			this.node = node;
			this.keys = keys;
			this.index = 0;
			this.regularExpression = new RegularExpression();
			this.property = new ArrayList();
			this.valueProperties = new ArrayList();
			this.objectManagement = new ObjectManagement();
			this.objectSCL = this.node.Tag;			
			this.namesPropertiesObject = new ArrayList ();			
			this.flag = true;
			this.flags = new List<bool>();		
			this.selectNodeToDelete = node;
		}
		
		/// <summary>
		/// Thisd method gets a string and analize it to eliminate the objects that are acording to the string. 
		/// </summary>
		/// <returns>
		/// If an error occurs when the analisis is made then it returns an error list.
		/// </returns>
		public List <ErrorsManagement> InterpretString()
		{															
		  if(this.index < this.keys.Length)
		  {		
		  	switch(this.keys.Substring(this.index,1))
			{		
		  		case "/" :
		  			this.nameProperty = this.ConcatenateProperty();
		  			this.valueProperty = this.objectManagement.FindVariable(this.objectSCL, nameProperty);
		  			if(!this.valueProperty.ToString().Equals("null")&&this.valueProperty.GetType().IsArray)
		  			{			  				
		  				for(int i = 0; i < this.node.Nodes.Count; i++)
		  				{
			  				if(this.node.Nodes[i].Text.Equals(this.nameProperty))
			  				{			  							  								  					
		  						this.node = this.node.Nodes[i];
		  						this.index++;
		  						this.InterpretString();		  					
		  						break;		  							  				
			  				}
		  				}
		  			}
		  			else if(!this.valueProperty.ToString().Equals("null"))
		  			{		
		  				this.node =  this.node.Nodes[this.valueProperty.GetType().Name.ToString()];
		  				this.index +=1;
		  				this.InterpretString();	
		  			}		
		  			else 
		  			{
		  				this.index +=2;
		  				this.InterpretString();	
		  			}
		  			
		  			break;
				case "%":						
					AutomataForValidateToTreeNode automataForValidateToTreeNode;
					TreeNode temporalNode = this.selectNodeToDelete;		
					if(this.keys.Substring(this.index+1,1).Equals("%"))
					{						
						this.index+=2;
						automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.node,
						   this.regularExpressionTree.GetRegExpToDelete(this.node));							
						automataForValidateToTreeNode.InterpretString();						
						this.node = temporalNode;
						this.InterpretString();
					}
					else
					{		
						for(int x = 0; x < this.node.Nodes.Count;)
						{									
							automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.node.Nodes[x],
						  	  this.regularExpressionTree.GetRegExpToDelete(this.node.Nodes[x]));	
							automataForValidateToTreeNode.InterpretString();														
						}				
						this.node = temporalNode;
						this.index++;						  	
						this.InterpretString();												
					}	
					break;
				case "[":
					 this.index++;
					 this.ConcatenateNumber();				 
					 if(this.keys.Substring(this.index,1).Equals("]"))
					 {
					 	this.number = this.ConcatenateProperty();					 	
					 	this.valueProperties.Add( this.valueProperties[(int) System.Convert.ChangeType(this.number, typeof(int))]);					 	
					 	this.ValidateEmptyString(this.valueProperties[(int) System.Convert.ChangeType(this.number, typeof(int))]);
					 	this.index++;
				 		this.InterpretString();
					 }
					 else
					 {			
						 this.ListErrors.Add(new ErrorsManagement("One of the brakets is missing"));
						 return this.ListErrors;	
					 }
					break;
				case "-":
					 this.nameProperty = this.ConcatenateProperty();					 					 
					 if(this.keys.Substring(this.index+1,1).Equals(">"))
					 {
					 	if(this.keys.Substring(this.index+2,1).Equals("["))
					 	{
					 		this.index+=3;
					 		this.ConcatenateNumber();
					 		this.number = this.ConcatenateProperty();
					 		int valueNumber = (int) System.Convert.ChangeType(this.number, typeof(int));
					 		if(this.keys.Substring(this.index,1).Equals("]"))
					 		{
					 			if(valueNumber > this.valueProperties.Count-1)
					 			{
					 				for(int count = this.valueProperties.Count-1; count < valueNumber; count++)
					 				{
					 					this.valueProperties.Add("");
					 				}
					 			}				
					 			this.valueProperty = this.objectManagement.FindVariable(this.objectSCL, this.nameProperty);					 		
					 			this.ValidateEmptyString(this.valueProperty);					 			
					 			this.valueProperties[valueNumber] = this.valueProperty;
					 			this.index++;					 			
				 				this.InterpretString();
					 		}
					 		else
					 		{
					 			 this.ListErrors.Add(new ErrorsManagement("One of the brakets is missing"));
						 		return this.ListErrors;
					 		}
					 	}
					 	else
					 	{
					 		this.index+=2;					 	
					 		this.valueProperty = this.objectManagement.FindVariable(this.objectSCL, this.nameProperty);					 							 		
					 		if(this.keys.Substring(this.index+1,1).Equals("="))
						 	{
						 		this.index--;
						 		this.ValidateEmptyString(this.valueProperty);						 		
						 		this.index++;						 		
						 		if(this.valueProperty!=null)
					 			{					 			
						 			this.valueProperties.Add(this.valueProperty);					 		
						 		}
						 		else
						 		{
						 			this.valueProperties.Add("");
						 		}
						 	}	
					 		else if(this.valueProperty!=null)
					 		{					 			
						 		this.valueProperties.Add(this.valueProperty);					 		
						 	}
						 	else
						 	{
						 		this.ListErrors.Add(new ErrorsManagement("Incorrect string: this.property"+this.nameProperty+"unknow "));
							 	return this.ListErrors;	
						 	}				 					 	
						 	this.InterpretString();
					 	}
					 						 	
					 }
					 else
					 {	
					 	this.operation = '-';
					 	this.index++;
					 	this.InterpretString();
					 }				
					 break;								 
				case "&":					
					this.index++;
					this.InterpretString();
					break;
				case ".":
					 this.node = this.node.Parent;					 
					 this.objectSCL = this.node.Tag;
					 this.index++;
					 this.InterpretString();
					 break;
				case "=":	
					 if(this.keys.Substring(this.index+1,1).Equals("="))
					 {					 	
					 	this.index+=2;
					 	this.InterpretString();
					 }
					 else
					 {
					 	this.namesPropertiesObject.Add(this.ConcatenateProperty());
					 	this.index++;
					 	this.InterpretString();
					 }		
					 break;		
					case "^":
					 	this.flags.Add(this.flag);
					 	this.flag = true;
					 	this.index++;
						this.InterpretString(); 
					 break;
					case "#":
					 	this.valueProperties.RemoveAt(valueProperties.Count-1);
					 	this.index++;
						this.InterpretString(); 
					 break;
					case ";":		
						if(this.flags[0])
					 	{
							this.FindReference(this.node.TreeView.Nodes);
							if(this.index+2 < this.keys.Length && this.keys.Substring(this.index+1,2).Equals("%%"))
							{
								this.index +=3;
					 			this.InterpretString();
							}					 		
						}	
					 	else if(this.keys.Substring(this.index+1,2).Equals("%%"))
						{
					 		this.index +=3;
					 		this.InterpretString();
					 	}					 		
						for(this.indexOfObject = 0; this.indexOfObject < this.namesPropertiesObject.Count;this.indexOfObject++)
						{
							this.valueProperties.RemoveAt(0);
						}						
						this.namesPropertiesObject.Clear();
						this.flags.RemoveAt(0);						
						this.index++;
						this.InterpretString();
					 break;					
					case "*":					 
					 if((int) System.Convert.ChangeType(this.keys.Substring(this.index+1,1), typeof(int))==1)
					 {
					 	switch(this.operation)
					 	{
					 		case '-':					 			
								this.treeViewSCL.Remove(this.selectNodeToDelete);
								break;								
						}
					 }	
					 this.index += 2;
					 this.InterpretString();
					 break;
				default:
					 if(regularExpression.IsWordCharacter(this.keys.Substring(this.index,1)))
					 {	
					 	this.ConcatenateLetter();
					 	this.InterpretString();
					 }	
					 else
					 	this.index++;
					break;
			}		  	
		  }				  		  	
		  return this.ListErrors;
		}		
		
		/// <summary>
		/// This method takes some strings of letters and concatenate them. This string identifies an object property.
		/// </summary>
		/// <returns>
		/// The string that was concatenated. 
		/// </returns>
		private string ConcatenateProperty()
		{
			this.character = (char[]) Array.CreateInstance(typeof(char) , this.property.Count);
			this.property.CopyTo(this.character);			
			this.property.Clear();						
			return new string(this.character);
		}
		
		/// <summary>
		/// This method finds the objects selected on the tree and inicialize the variables to find them.
		/// </summary>
		/// <param name="nodes">
		/// Tree that contains the nodes where the objects will be found.
		/// </param>
		private void FindReference(TreeNodeCollection nodes)
		{			 
            foreach (TreeNode n in nodes)
            {         
            	int k = 0;            	
                this.FindChilds(n,k);
            }
		}
		
		/// <summary>
		/// This method look for the objects selected.
		/// </summary>
		/// <param name="treeNodeSCL">
		/// Tree of nodes that represent the SCL objects.
		/// </param>
		/// <param name="k">
		/// Position of the variable that is looking for.
		/// </param>
		public void FindChilds(TreeNode treeNodeSCL, int k)
		{						
			object nodeObject;										
			int indexOfRemove = 0;		
			int kTemp = k;
			while(indexOfRemove < treeNodeSCL.Nodes.Count)
			{
				k=kTemp;
				TreeNode tn = treeNodeSCL.Nodes[indexOfRemove];
				nodeObject = tn.Tag;
				if(nodeObject!= null)
				{						
					this.kTemp2 = k;
					while( k< this.namesPropertiesObject.Count)
					{							
						this.valueProperty =  this.objectManagement.FindVariable(nodeObject, this.namesPropertiesObject[k].ToString());
						if(this.valueProperty!=null&&this.valueProperty.ToString().Equals(this.valueProperties[k].ToString()))
						{								
							k++;							
							if(this.namesPropertiesObject.Count==k)
							{								
								k = this.kTemp2;									
								if(this.index+2 < this.keys.Length &&this.keys.Substring(this.index+1,1).Equals("%")&&this.keys.Substring(this.index+2,1).Equals("%"))
								{
									this.node = tn;												
									this.index++;									
									this.InterpretString();
								}								
								else
								{
									switch(this.operation)
					 				{
					 					case '-':
											this.treeViewSCL.Remove(tn);
											break;
									}
								}								
								break;
							}							
						}
						else
						{		
							indexOfRemove++;
							this.FindChilds(tn,k);
							break;
						}							
					}										
				}						
			}			
		}
	
		/// <summary>
		/// This method is used to concatenate letters of a string provided to identify an expressions included on it.
		/// </summary>
		private void ConcatenateLetter()
		{
			while(regularExpression.IsWordCharacter(this.keys.Substring(this.index,1)))
			{					 	
				this.character = this.keys.ToCharArray(this.index,1);
				this.property.Add(this.character[0]);
				this.index++;									
			}
		}
		
		/// <summary>
		/// This method is used to concatenate numbers of a string provided to identify an expressions included on it.		
		/// </summary>		
		private void ConcatenateNumber()
		{
			while(regularExpression.IsNumber(this.keys.Substring(this.index,1)))
			{					 							
				this.character = this.keys.ToCharArray(this.index,1);
				this.property.Add(this.character[0]);
				this.index++;					 	
			}	
		}
		
		/// <summary>
		/// This method identifies if one of the expressions included on the string should delete a specific property. If the 
		/// expression is null or empty a value of 0 or 1 should be stablished. If the value is 0 then the expression should 
		/// be ignored, and if the value is 1, then the expression should delete the specific property.
		/// </summary>
		/// <remarks>
		/// The logic operator "XOR" was used to determine if the expression will be made or not.
		/// </remarks>
		/// <param name="PossibleEmptyString">
		/// Value of the expression that will determine if the property should be deleted.
		/// </param>
		private void ValidateEmptyString(object PossibleEmptyString)
		{						
			if(this.keys.Substring(this.index+1,2).Equals("==")&&(!this.keys.Substring(this.index+3,1).Equals("$"))&&(PossibleEmptyString!=null&&!PossibleEmptyString.ToString().Equals("")))
			{
				this.index += 3;
				if(regularExpression.IsWordCharacter(this.keys.Substring(this.index,1)))
				{	
					this.ConcatenateLetter();					
				}	
				this.nameProperty = this.ConcatenateProperty();												
				this.flag = PossibleEmptyString.ToString().Equals(this.nameProperty) ^ (((int) System.Convert.ChangeType(this.keys.Substring(this.index,1), typeof(int)))==0);
			}
			else if(this.keys.Substring(this.index+1,3).Equals("==$")&&(PossibleEmptyString==null||PossibleEmptyString.ToString().Equals("")))
			{				
				this.index += 4;						
				this.flag = true ^ (((int) System.Convert.ChangeType(this.keys.Substring(this.index,1), typeof(int)))==0);				
			}
			else if(this.keys.Substring(this.index+1,3).Equals("==$")&&(PossibleEmptyString!=null||!PossibleEmptyString.ToString().Equals("")))
			{							
				this.index += 4;						
				this.flag = false ^ (((int) System.Convert.ChangeType(this.keys.Substring(this.index,1), typeof(int)))==0);				
			}
		}
	}
}
