/// LibOpenSCLUI
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
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of References.
	/// </summary>
	public class AttributeReferences
	{
		private TreeViewSCL treeViewSCL;		
		private TreeNode nodeSCL;
		private TreeNode nodeSCL2;
		private SCL sCL;
		
		public AttributeReferences()
		{
			this.treeViewSCL = new TreeViewSCL();			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectToInsert">
		/// 
		/// </param>
		/// <param name="nodePossibleInsert">
		/// 
		/// </param>
		public void Insert(object objectToInsert, TreeNode nodePossibleInsert)
		{
			switch(objectToInsert.GetType().Name)
			{
				case "tFCDA":					
					this.nodeSCL = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tLDevice));
					if(this.nodeSCL!=null)
					{
						ObjectManagement.FindVariableAndSetValue(objectToInsert,this.nodeSCL.Tag.GetType().Name, this.nodeSCL.Tag);
					}
					break;	
				case "tConnectedAP":
					this.nodeSCL = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tAccessPoint));
					this.nodeSCL2 = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tIED));					
					if(this.nodeSCL!=null && this.nodeSCL2!=null)
					{
						ObjectManagement.FindVariableAndSetValue(objectToInsert,this.nodeSCL.Tag.GetType().Name, this.nodeSCL.Tag);
						ObjectManagement.FindVariableAndSetValue(objectToInsert,this.nodeSCL2.Tag.GetType().Name, this.nodeSCL2.Tag);
					}
					break;
				case "tServer": 
					this.sCL =(SCL) this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(SCL)).Tag;
					if(this.sCL.Communication!=null && this.sCL.Communication.SubNetwork!=null)
					{						
						object access = (nodePossibleInsert.Tag as tAccessPoint);
						object ied = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tIED)).Tag;												
						for(int i=0; i<this.sCL.Communication.SubNetwork.Length;i++)
						{
							for(int j=0; j<this.sCL.Communication.SubNetwork[i].ConnectedAP.Length;j++)
							{
								if((this.sCL.Communication.SubNetwork[i].ConnectedAP[j].iedName!=null && this.sCL.Communication.SubNetwork[i].ConnectedAP[j].apName != null))
								{
									if(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].iedName.Equals((ied as tIED).name)) 
									{
										if( this.sCL.Communication.SubNetwork[i].ConnectedAP[j].apName.Equals((access as tAccessPoint).name))
										{
											ObjectManagement.FindVariableAndSetValue(this.sCL.Communication.SubNetwork[i].ConnectedAP[j],access.GetType().Name, access);
											ObjectManagement.FindVariableAndSetValue(this.sCL.Communication.SubNetwork[i].ConnectedAP[j],ied.GetType().Name, ied);
											break;
										}										
									}	
								}								
							}
						}																	
					}					
					break;
				case "tGSEControl":
				case "tSampledValueControl":
					this.sCL =(SCL) this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(SCL)).Tag;
					if(this.sCL.Communication!=null && this.sCL.Communication.SubNetwork!=null)
					{
						object currentTag = nodePossibleInsert.Tag ;
						object tLd = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tLDevice)).Tag;
						for(int i=0; i<this.sCL.Communication.SubNetwork.Length;i++)
						{
							for(int j=0; j<this.sCL.Communication.SubNetwork[i].ConnectedAP.Length;j++)
							{
								if(currentTag.GetType().Name.Equals("tGSEControl"))
								{
									for(int k=0; this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE!=null && k<this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE.Length; k++)
									{										
										if((this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE[k].cbName!=null) && (this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE[k].ldInst!=null))
										{
											if(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE[k].cbName.Equals((currentTag as tGSEControl).name) && (this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE[k].ldInst.Equals((tLd as tLDevice).inst)))
											{
										        ObjectManagement.FindVariableAndSetValue(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE[k],currentTag.GetType().Name, currentTag);
												ObjectManagement.FindVariableAndSetValue(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].GSE[k],tLd.GetType().Name, tLd);
												break;                                                                   	
											}
										}
									}
								}
								else 
								{
									for(int k=0; this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV!=null && k<this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV.Length; k++)
									{										
										if((this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV[k].cbName!=null) && (this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV[k].ldInst!=null))
										{
											if(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV[k].cbName.Equals((currentTag as tSampledValueControl).name) && (this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV[k].ldInst.Equals((tLd as tLDevice).inst)))
											{
										        ObjectManagement.FindVariableAndSetValue(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV[k],currentTag.GetType().Name, currentTag);
												ObjectManagement.FindVariableAndSetValue(this.sCL.Communication.SubNetwork[i].ConnectedAP[j].SMV[k],tLd.GetType().Name, tLd);
												break;                                                                   	
											}
										}
									}
								}								
							}
						}
					}					
					break;
				case "tGSE":
				case "tSMV":
					this.nodeSCL = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tLDevice));
					if(this.nodeSCL!=null)
					{
						ObjectManagement.FindVariableAndSetValue(objectToInsert,this.nodeSCL.Tag.GetType().Name, this.nodeSCL.Tag);
						ObjectManagement.FindVariableAndSetValue(objectToInsert ,nodePossibleInsert.Tag.GetType().Name, nodePossibleInsert.Tag);//victor, puse esta condicion por el property del GSE está habilitado y hay que actualizar el nombre 
					}
					break;
				case "tSubstation":
					this.sCL =(SCL) this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(SCL)).Tag;
					this.nodeSCL = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(nodePossibleInsert, typeof(tSubstation));
					if(this.sCL.Substation!=null )
					{
						for(int i = 0;  this.sCL.Substation.Length > i; i++)
						{
							if(this.sCL.Substation[i].LNode != null)
							{
								for(int j = 0; this.sCL.Substation[i].LNode.Length > j; j++)
								{
									if(this.sCL.IED!=null)
									{
										for( int a = 0; a < this.sCL.IED.Length; a++ )
										{
											if(this.sCL.Substation[i].LNode[j].iedName.Equals(  this.sCL.IED[a].name ))
											{
												object ied = (this.sCL.IED[a]  as tIED);
												ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j],ied.GetType().Name, ied);
												if( this.sCL.IED[a].AccessPoint != null)
												{
													for(int b= 0;  b < this.sCL.IED[a].AccessPoint.Length; b++ )
													{
														if(this.sCL.IED[a].AccessPoint[b].Server != null)
														{
															for( int c =0; c < this.sCL.IED[a].AccessPoint[b].Server.LDevice.Length; c++)
															{
																if(this.sCL.Substation[i].LNode[j].ldInst.Equals(  this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].inst ))
																{
																	object ld = (this.sCL.IED[a].AccessPoint[b].Server.LDevice[c]  as tLDevice);
																	ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j],ld.GetType().Name, ld);
																	
																	if(this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN != null)
																	{
																		for( int d = 0; d < this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN.Length; d++)
																		{
																			if(this.sCL.Substation[i].LNode[j].lnClass.Equals(  this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d].lnClass) &&
																			      this.sCL.Substation[i].LNode[j].lnInst.Equals(  this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d].inst.ToString() ) &&
																			     this.sCL.Substation[i].LNode[j].lnType.Equals(  this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d].lnType )
																			     )
																			{
																				object ln = (this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d]  as tLN);
																				ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j],ln.GetType().Name, ln);
																				ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j], ln.GetType().Name,ln);
																				ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j], ln.GetType().Name,ln);
																			}
																		}
																	}
																}
															}
														}
														if(this.sCL.IED[a].AccessPoint[b].LN != null)
														{
															for(int d = 0; d < this.sCL.IED[a].AccessPoint[b].LN.Length; d++)
															{
																if(this.sCL.Substation[i].LNode[j].lnClass.Equals(  this.sCL.IED[a].AccessPoint[b].LN[d].lnClass) &&
																   this.sCL.Substation[i].LNode[j].lnInst.Equals( this.sCL.IED[a].AccessPoint[b].LN[d].inst.ToString() ) &&
																   this.sCL.Substation[i].LNode[j].lnType.Equals( this.sCL.IED[a].AccessPoint[b].LN[d].lnType )
																  )
																{
																	object ln = (this.sCL.IED[a].AccessPoint[b].LN[d]  as tLN);
																	ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j],ln.GetType().Name, ln);
																	ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j], ln.GetType().Name,ln);
																	ObjectManagement.FindVariableAndSetValue(this.sCL.Substation[i].LNode[j], ln.GetType().Name, ln);
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					break;
			}
		}
	}
}
