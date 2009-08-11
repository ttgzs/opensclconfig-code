// LibOpenSCLUI
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// PropertyGrid personalized.
	/// </summary>
	/// <remarks>
	/// This class overrides the standard PropertyGrid provided by Microsoft.
	/// It also allows to hide or filter the properties of the SelectedObject displayed by the PropertyGrid.
	/// </remarks>
	public partial class FilteredPropertyGrid : PropertyGrid
	{
	    /// <summary>
	    /// It contains a reference to the collection of properties to show in the parent PropertyGrid.
	    /// </summary>
	    /// <remarks>
	    /// By default, m_PropertyDescriptors contains all the properties of the object. 
	    /// </remarks>
	    List<PropertyDescriptor> m_PropertyDescriptors = new List<PropertyDescriptor>();
	    
	    /// <summary>
	    /// It contains a reference to the array of properties to display in the PropertyGrid.
	    /// </summary>
	    private AttributeCollection m_HiddenAttributes = null, m_BrowsableAttributes = null;
	    
	    /// <summary>
	    /// It contains references to the arrays of properties or categories to hide.
	    /// </summary>
	    private string[] m_BrowsableProperties = null, m_HiddenProperties = null;
	   
	    /// <summary>
	    /// It contains a reference to the wrapper that contains the object to be displayed into the PropertyGrid.
	    /// </summary>
	    private ObjectWrapper m_Wrapper = null;
	
	    /// <summary>
	    /// Constructor of PropertyGrid
	    /// </summary>
	    public FilteredPropertyGrid()
	    {
	        base.SelectedObject = m_Wrapper;
	    }
	    
	    /// <summary>
	    /// Getting or setting the categories to hide.
	    /// </summary>
	    public AttributeCollection HiddenAttributes
	    {
	        get 
	        { 
	        	return m_HiddenAttributes; 
	        }
	        set
	        {
	            if (value != m_HiddenAttributes)
	            {
	                m_HiddenAttributes = value;
	                m_BrowsableAttributes = null;
	                RefreshProperties();
	            }
	        }
	    }
	    
	    /// <summary>
	    /// Getting or setting the properties to show.
	    /// </summary>
	    /// <exception cref="ArgumentException">
	    /// if one or several properties doesn't exist.
	    /// </exception>
	    public string[] BrowsableProperties
	    {
	        get 
	        { 
	        	return m_BrowsableProperties; 
	        }
	        set
	        {
	            if (value != m_BrowsableProperties)
	            {
	                m_BrowsableProperties = value;                    
	                RefreshProperties();
	            }
	        }
	    }
	
	    /// <summary>
	    /// Getting or setting the properties to hide.
	    /// </summary>
	    public string[] HiddenProperties
	    {
	        get 
	        { 
	        	return m_HiddenProperties; 
	        }
	        set
	        {
	            if (value != m_HiddenProperties)
	            {                    
	                m_HiddenProperties = value;
	                RefreshProperties();
	            }
	        }
	    }
	
	    /// <summary>
	    /// Overwriting the PropertyGrid.SelectedObject property.
	    /// </summary>
	    /// <remarks>
	    /// The object passed to the base PropertyGrid is the wrapper.
	    /// </remarks>
	    public new object SelectedObject
	    {
	        get 
	        { 
	        	return m_Wrapper != null ? ((ObjectWrapper)base.SelectedObject).SelectedObject : null; 
	        }
	        set
	        {
	            // It sets the new object to the wrapper and creates one if it's necessary.
	            if (m_Wrapper == null)
	            {
	                m_Wrapper = new ObjectWrapper(value);
	                RefreshProperties();
	            }
	            else 
	            {
	            	if (m_Wrapper.SelectedObject != value)
	            	{
	                	bool needrefresh = value.GetType() != m_Wrapper.SelectedObject.GetType();
	                	m_Wrapper.SelectedObject = value;
	                	if (needrefresh) 
	                	{
	                		RefreshProperties();
	                	}
	            	}
	            }
	            // It sets the list of properties to the wrapper.
	            m_Wrapper.PropertyDescriptors = m_PropertyDescriptors;
	            // Linking the wrapper to the parent PropertyGrid.
	            base.SelectedObject = m_Wrapper;
	        }
	    }
	
	    /// <summary>
	    /// Building the list of the properties to be displayed in the PropertyGrid, 
	    /// following the filters defined as Browsable or Hidden properties.
	    /// </summary>
	    private void RefreshProperties()
	    {
	        if (m_Wrapper == null) 
	        {
	        	return;
	        }
	        m_PropertyDescriptors.Clear();
	        if (m_BrowsableAttributes != null && m_BrowsableAttributes.Count > 0)
	        {
	            foreach (Attribute attribute in m_BrowsableAttributes) 
	            {
	            	ShowAttribute(attribute);
	            }
	        }
	        else
	        {
	            PropertyDescriptorCollection originalpropertydescriptors = TypeDescriptor.GetProperties(m_Wrapper.SelectedObject);
	            foreach (PropertyDescriptor propertydescriptor in originalpropertydescriptors) 
	            {
	            	m_PropertyDescriptors.Add(propertydescriptor);
	            }	            
	            if (m_HiddenAttributes != null) 
	            {
	            	foreach (Attribute attribute in m_HiddenAttributes) 
	            	{
	            		HideAttribute(attribute);
	            	}
	            }
	        }
	        PropertyDescriptorCollection allproperties = TypeDescriptor.GetProperties(m_Wrapper.SelectedObject);
	        if (m_HiddenProperties != null && m_HiddenProperties.Length > 0)
	        {
	            foreach (string propertyname in m_HiddenProperties)
	            {
	                try
	                {
	                    PropertyDescriptor property = allproperties[propertyname];
	                    HideProperty(property);
	                }
	                catch (Exception ex)
	                {
	                    throw new ArgumentException(ex.Message);
	                }
	            }
	        }	        
	        if (m_BrowsableProperties != null && m_BrowsableProperties.Length > 0)
	        {
	            foreach (string propertyname in m_BrowsableProperties)
	            {
	                try
	                {
	                    ShowProperty(allproperties[propertyname]);
	                }
	                catch (Exception)
	                {
	                    throw new ArgumentException("Property not found", propertyname);
	                }
	            }
	        }
	    }
	    
	    /// <summary>
	    /// This method allows to hide a set of properties to the parent PropertyGrid.
	    /// </summary>
	    /// <param name="propertyname">
	    /// Set of attributes that filter the original collection of properties.
	    /// </param>
	    /// <remarks>
	    /// For better performance, include the BrowsableAttribute with true value.
	    /// </remarks>
	    private void HideAttribute(Attribute attribute)
	    {
	        PropertyDescriptorCollection filteredoriginalpropertydescriptors = TypeDescriptor.GetProperties(m_Wrapper.SelectedObject, new Attribute[] { attribute });
	        if (filteredoriginalpropertydescriptors == null || filteredoriginalpropertydescriptors.Count == 0) 
	        {
	        	throw new ArgumentException("Attribute not found", attribute.ToString());
	        }
	        foreach (PropertyDescriptor propertydescriptor in filteredoriginalpropertydescriptors) 
	        {
	        	HideProperty(propertydescriptor);
	        }
	    }
	    
	    /// <summary>
	    /// This method adds all the properties that match an attribute to the list of properties to be displayed in the PropertyGrid.
	    /// </summary>
	    /// <param name="property">
	    /// The attribute to be added.
	    /// </param>
	    private void ShowAttribute(Attribute attribute)
	    {
	        PropertyDescriptorCollection filteredoriginalpropertydescriptors = TypeDescriptor.GetProperties(m_Wrapper.SelectedObject, new Attribute[] { attribute });
	        if (filteredoriginalpropertydescriptors == null || filteredoriginalpropertydescriptors.Count == 0) 
	        {
	        	throw new ArgumentException("Attribute not found", attribute.ToString());
	        }
	        foreach (PropertyDescriptor propertydescriptor in filteredoriginalpropertydescriptors) 
	        {
	        	ShowProperty(propertydescriptor);
	        }
	    }
	    
	    /// <summary>
	    /// This method adds a property to the list of properties to be displayed in the PropertyGrid.
	    /// </summary>
	    /// <param name="property">
	    /// The property to be added.
	    /// </param>
	    private void ShowProperty(PropertyDescriptor property)
	    {
	        if (!m_PropertyDescriptors.Contains(property)) 
	        {
	        	m_PropertyDescriptors.Add(property);
	        }
	    }
	    /// <summary>
	    /// ]This method allows to hide a property to the parent PropertyGrid.
	    /// </summary>
	    /// <param name="propertyname">
	    /// The name of the property to be hidden.
	    /// </param>
	    private void HideProperty(PropertyDescriptor property)
	    {
	        if (m_PropertyDescriptors.Contains(property)) 
	        {
	        	m_PropertyDescriptors.Remove(property);
	        }
	    }
	    
		/// <summary>
		/// This method updates the attributes of the propertyGrid when a Node of the tree is selected.
		/// </summary>
		/// <returns>
		/// The object that contains the information of the node selected.
		/// </returns>
		public object UpdatePropertyGrid(TreeNode NodetreeViewFile)
		{
			TreeNode TreeNodeObject;
	    	object ObjectDataTypeConverter;
	    	Utils dataTypeConverter;
	        TreeNodeObject = new TreeNode();
	        ObjectDataTypeConverter = new object();
	        dataTypeConverter = new Utils();
	 		TreeNodeObject = NodetreeViewFile;
			if (TreeNodeObject.Tag == null | TreeNodeObject.Tag is Array | TreeNodeObject.Tag is tDataTypeTemplates | TreeNodeObject.Tag is SCL | TreeNodeObject.Name == "tServiceYesNo")
	        {
	            NextNodeDisplayName nameNextNode = new NextNodeDisplayName();
	            if (TreeNodeObject.FirstNode != null)
	            {
	                nameNextNode.Name = TreeNodeObject.FirstNode.Text;
	            }
	            else
	            {
	                nameNextNode.FinishNode = TreeNodeObject.Text;
	            }
	            return nameNextNode;
	        }
	        else
	        {
	            ObjectDataTypeConverter = dataTypeConverter.DataTypeConverterProcess(TreeNodeObject, TreeNodeObject.Tag);
	            return ObjectDataTypeConverter;
	        }
		}		
			
		/// <summary>
		/// This method hiddes some properties of the PropertyGrid according to this list.
		/// </summary>
		/// <returns>
		/// Property to hide.
		/// </returns>
	    public string[] PropertiestoHide()
	    {
	        string[] hideProperties = 
	        {
	            "Any",
	            "AnyAttr",
	            "AccessPoint",
	            "ConnectedAP",
	            "Address",
	            "LN",
	            "EnumVal",
	            "GSE",
	            "PhysCom",
	            "SMV",
	            "IED",
	            "Private",
	            "DAType",
	            "DOType",
	            "EnumType",
	            "LNodeType",
	            "Substation",
	            "History",
	            "SubNetwork",
	            "LDevice",
	            "DO",
	            "Val",
	            "DataSet",
	            "DOI",
	            "GSEControl",
	            "tReportControl",
	            "IEDName",
	            "FCDA",
	            "ClientLn",
	            "VoltageLevel",
	            "Bay",
	            "GeneralEquipment",
	            "LNode",
	            "PowerTransformer",
	            "ConductingEquipment",
	            "ConnectivityNode",
	            "PhysConn",
	            "BDA",
	            "Text",
	            "Function",
	            "Server",
	            "Association",
	            "Authentication",
	            "LN0",
	            "Inputs",
	            "Log",
	            "LogControl",
	            "ReportControl",
	            "SampledValueControl",
	            "SCLControl",
	            "SettingControl",
	            "DA",
	            "SDO",
	            "Services",
	            "AccessControl",
	            "DAI",
	            "SDI",
	            "Voltage",
	            "OptFields",
	            "RptEnabled",
	            "TrgOps",
	            "ClientLN",
	            "MinTime",
	            "MaxTime"
	         };
	        return hideProperties;
	    }
	}    
}

