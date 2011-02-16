// LibOpenSCL
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
using IEC61850.SCL;

namespace OpenSCL
{
	/// <summary>
	/// Description of DataSet.
	/// Aquí se hace la manipulación referente al DataSet.
	/// </summary>
	/// <remarks>
	/// To accept any Logical Node without shows an error on the tree, the type of lnClass attribute 
	/// has to be changed from Enum to String.
	/// </remarks>	 	
	public class DataSet
	{		
		private string ldInst;
		private string prefix;
		private string lnClass;
		private string lnInst;
		private string lnType;		
		private tDataSet dataSet;
        private tLDevice tLDevice;
		
		public DataSet()
		{
			this.dataSet = new tDataSet();
		}
		
		/// <summary>
		/// This method sets and gets the FCDA of an LN0.
		/// </summary>
		/// <param name="ldInst">
		/// Attribute "inst" that belongs to LDevice class, it is used on the FCDA class. 
		/// </param>
		/// <param name="lN">
		/// Logical node selected where FCDA will be assigned.
		/// </param>
		/// <param name="dataTypeTemplates">
		/// DataTypeTemplates Node of the SCL project. This node is used to create and assign the information 
		/// to the Logical Node.
		/// </param>
		/// <returns>
		/// It returns the FCDA of the logical Node selected.
		/// </returns>
		public tDataSet GetLN0FCDAs(tLDevice tLDevice, LN0 lN, tDataTypeTemplates dataTypeTemplates)
		{
			this.tLDevice = tLDevice;			
			this.lnClass = lN.lnClass.ToString();
			this.lnInst = lN.inst;
			this.lnType = lN.lnType;			
			this.CreateFCDAs(lN, dataTypeTemplates);
			return this.dataSet;
		}
		
		/// <summary>
		/// This method sets and gets the FCDA of an LN.
		/// </summary>
		/// <param name="ldInst">
		/// Attribute "inst" that belongs to LDevice class, it is used on the FCDA class. 		
		/// </param>
		/// <param name="lN">
		/// Logical node selected where FCDA will be assigned.
		/// </param>
		/// <param name="dataTypeTemplates">
		/// DataTypeTemplates Node of the SCL project. This node is used to create and assign the information 
		/// to the Logical Node.
		/// </param>
		/// <returns>
		/// It returns the FCDA of the logical Node selected.
		/// </returns>
		public tDataSet GetLNFCDAs(tLDevice tLDevice, tLN lN, tDataTypeTemplates dataTypeTemplates)
		{
			this.tLDevice = tLDevice;			
			this.prefix = lN.prefix;
			this.lnClass = lN.lnClass;
			this.lnInst = lN.inst.ToString();
			this.lnType = lN.lnType;			
			this.CreateFCDAs(lN, dataTypeTemplates);
			return this.dataSet;
		}
		
		/// <summary>
		/// This method allows to create the FCDA on the LN selected.
		/// </summary>
		/// <param name="lN">
		/// Logical node selected where FCDA will be assigned.
		/// </param>
		/// <param name="dataTypeTemplates">
		/// DataTypeTemplates Node of the SCL project. This node is used to create and assign the information 
		/// to the Logical Node.
		/// </param>
		private void CreateFCDAs(tAnyLN lN, tDataTypeTemplates dataTypeTemplates)
		{
			//The variable "a" is the index for the LNodeType (Don't change this class!!) 
			for(int a = 0; dataTypeTemplates!= null && dataTypeTemplates.LNodeType != null && a < dataTypeTemplates.LNodeType.Length; a++)
			{
				if(lN.lnType.Equals(dataTypeTemplates.LNodeType[a].id))
				{
					//The variable "c" is the index of the DOType (This class can be manipulated)					
					int c = 0; 
					//The variable "b" is the index of the DO (Don't change this class!!)
					for(int b = 0; dataTypeTemplates.LNodeType[a].DO != null && b < dataTypeTemplates.LNodeType[a].DO.Length; b++)
					{
						tFCDA fCDA = new tFCDA();
						fCDA.ldInst = this.ldInst;
						fCDA.prefix = this.prefix;
						fCDA.lnClass = this.lnClass;
						fCDA.lnInst = this.lnInst;
						fCDA.doName = dataTypeTemplates.LNodeType[a].DO[b].name;						
						if(this.tLDevice!=null)
						{
							ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
						}
						ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);
						for(; c < dataTypeTemplates.DOType.Length; c++)
						{
							if(dataTypeTemplates.LNodeType[a].DO[b].type.Equals(dataTypeTemplates.DOType[c].id))
							{
								this.InsertDaName(dataTypeTemplates, dataTypeTemplates.DOType[c], dataTypeTemplates.LNodeType[a].DO[b].name);
								int count2 = c+1;
								// The variable "count" is the SDO's index (Don't change this class!!)								
								for(int count = 0; dataTypeTemplates.DOType[c].SDO != null && count < dataTypeTemplates.DOType[c].SDO.Length; count++)
								{									
									//The variable "count2" is the DOType index (This class can be used).									
									while(count2 < dataTypeTemplates.DOType.Length)
									{
										if(dataTypeTemplates.DOType[c].SDO[count].type == dataTypeTemplates.DOType[count2].id)
										{
											fCDA = new tFCDA();
											fCDA.ldInst = this.ldInst;
											fCDA.prefix = this.prefix;
											fCDA.lnClass = this.lnClass;
											fCDA.lnInst = this.lnInst;
											fCDA.doName = dataTypeTemplates.LNodeType[a].DO[b].name;											
											fCDA.daName = dataTypeTemplates.DOType[c].SDO[count].name;
											if(this.tLDevice!=null)
											{
												ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
											}
											ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);
											this.InsertDaNameParent(dataTypeTemplates, dataTypeTemplates.DOType[count2], dataTypeTemplates.LNodeType[a].DO[b].name, dataTypeTemplates.DOType[c].SDO[count].name);
											count2++;
											break;
										}
									}
								}
								c = count2;
								break;
							}
						}
					}
					break;
				}
			}		
		}
		
		/// <summary>
		/// This method creates the FCDA for the DA.
		/// </summary>
		/// <param name="dataTypeTemplates">
		/// DataTypeTemplates Node of the SCL project. This node is used to create and assign the information 
		/// to the Logical Node.
		/// </param>
		/// <param name="dOType">
		/// DA information where their names will be gotten and are necessaries for the creation of the FCDAs.
		/// </param>
		/// <param name="doName">
		/// DO name that contains the DA used to create the FCDA.
		/// </param>
		private void InsertDaName(tDataTypeTemplates dataTypeTemplates, tDOType dOType, string doName)
		{
			// The variable "d" is the index of the DA (Don't change this class!!)
			for(int d = 0; d < dOType.DA.Length; d++)
			{
				if(dOType.DA[d].bTypeEnum == tBasicTypeEnum.Struct)
				{
					for(int e = 0; e < dataTypeTemplates.DAType.Length; )
					{
						if(dOType.DA[d].type.Equals(dataTypeTemplates.DAType[e].id))
						{
							this.InsertDaNameParent(dataTypeTemplates, ref e, doName, dOType.DA[d].name);
							break;
						}
						else
						{
							e++;
						}
					}
				}
				else
				{
					tFCDA fCDA = new tFCDA();
					fCDA.ldInst = this.ldInst;
					fCDA.prefix = this.prefix;
					fCDA.lnClass = this.lnClass;
					fCDA.lnInst = this.lnInst;
					fCDA.doName = doName;					
					fCDA.daName = dOType.DA[d].name;
					if(this.tLDevice!=null)
					{
						ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
					}
					ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);					
				}
			}
		}
		
		/// <summary>
		/// This method creates the FCDA for the DA of the SDO data.
		/// </summary>
		/// <param name="dataTypeTemplates">
		/// DataTypeTemplates Node of the SCL project. This node is used to create and assign the information 
		/// to the Logical Node.
		/// </param>
		/// <param name="dOType">
		/// DA information where their names will be gotten and are necessaries for the creation of the FCDAs.
		/// </param>
		/// <param name="doName">
		/// DO name that contains the DA used to create the FCDA.
		/// </param>
		/// <param name="daNameParent">
		/// SDO name that contains the DA used to create the FCDA.
		/// </param>
		private void InsertDaNameParent(tDataTypeTemplates dataTypeTemplates, tDOType dOType, string doName, string daNameParent)
		{
			// The variable "d" is the index of the DA (Don't change this class!!)
			for(int d = 0; d < dOType.DA.Length; d++)			
			{
				if(dOType.DA[d].bTypeEnum == tBasicTypeEnum.Struct)
				{					
					// The variable "e" is the index of the DA (This class can be modified)
					for(int e = 0; e < dataTypeTemplates.DAType.Length; e++)
					{
						if(dOType.DA[d].type.Equals(dataTypeTemplates.DAType[e].id))
						{
							tFCDA fCDA = new tFCDA();
							fCDA.ldInst = this.ldInst;
							fCDA.prefix = this.prefix;
							fCDA.lnClass = this.lnClass;
							fCDA.lnInst = this.lnInst;
							fCDA.doName = doName;							
							fCDA.daName = daNameParent+"."+dOType.DA[d].name;
							if(this.tLDevice!=null)
							{
								ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
							}
							ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);
							this.InsertDaNameParent(dataTypeTemplates, ref e, doName, daNameParent+"."+dOType.DA[d].name);
							break;
						}
					}
				}
				else
				{
					tFCDA fCDA = new tFCDA();
					fCDA.ldInst = this.ldInst;
					fCDA.prefix = this.prefix;
					fCDA.lnClass = this.lnClass;
					fCDA.lnInst = this.lnInst;
					fCDA.doName = doName;					
					fCDA.daName = daNameParent+"."+dOType.DA[d].name;
					if(this.tLDevice!=null)
					{
						ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
					}
					ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);					
				}
			}
		}
		
		/// <summary>
		/// This method creates the FCDA of the BDA.
		/// </summary>
		/// <param name="dataTypeTemplates">
		/// DataTypeTemplates Node of the SCL project. This node is used to create and assign the information 
		/// to the Logical Node.
		/// </param>
		/// <param name="index">
		/// Position of the DAType array.
		/// </param>
		/// <param name="doName">
		/// DO name that contains the DA used to create the FCDA.
		/// </param>
		/// <param name="daNameParent">
		/// SDO name that contains the DA used to create the FCDA. 
		/// This name could contain the following structure: SDO.name+"."+DA.name (this one is related to 
		/// the DAType that is been used).
		/// </param>
		private void InsertDaNameParent(tDataTypeTemplates dataTypeTemplates, ref int index, string  doName, string daNameParent)
		{
			int indexTemp = index;
			// The variable "index2" is the index of the BDA (Don't change this class!!)
			for(int index2 = 0; dataTypeTemplates.DAType[indexTemp].BDA !=null && index2 < dataTypeTemplates.DAType[indexTemp].BDA.Length; index2++)
			{
				if(dataTypeTemplates.DAType[indexTemp].BDA[index2].bTypeEnum == tBasicTypeEnum.Struct)
				{
					// The variable "index" is the index for the DAType (This class can be modified)
					int i = 0;
					while(i < dataTypeTemplates.DAType.Length)
					{
						if(i < dataTypeTemplates.DAType.Length&&dataTypeTemplates.DAType[i].id == dataTypeTemplates.DAType[indexTemp].BDA[index2].type)
						{							
							tFCDA fCDA = new tFCDA();
							fCDA.ldInst = this.ldInst;
							fCDA.prefix = this.prefix;
							fCDA.lnClass = this.lnClass;
							fCDA.lnInst = this.lnInst;
							fCDA.doName = doName;							
							fCDA.daName = daNameParent+"."+dataTypeTemplates.DAType[indexTemp].BDA[index2].name;
							if(this.tLDevice!=null)
							{
								ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
							}
							ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);							
							this.InsertDaNameParent(dataTypeTemplates, ref i, doName, daNameParent+"."+dataTypeTemplates.DAType[indexTemp].BDA[index2].name);
							break;
						}
						i++;
					}					
				}
				else
				{
					tFCDA fCDA = new tFCDA();
					fCDA.ldInst = this.ldInst;
					fCDA.prefix = this.prefix;
					fCDA.lnClass = this.lnClass;
					fCDA.lnInst = this.lnInst;
					fCDA.doName = doName;					
					fCDA.daName = daNameParent+"."+dataTypeTemplates.DAType[indexTemp].BDA[index2].name;
					if(this.tLDevice!=null)
					{
						ObjectManagement.FindVariableAndSetValue(fCDA, this.tLDevice.GetType().Name, this.tLDevice);
					}
					ObjectManagement.AddObjectToArrayObjectOfParentObject(fCDA, dataSet);
				}
			}
		}
	}
}
