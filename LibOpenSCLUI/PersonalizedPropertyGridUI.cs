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

namespace OpenSCL.UI
{
	/// <summary>
	/// This class is a wrapper. It contains the object the propertyGrid has to display.
	/// </summary>
    internal class ObjectWrapper : ICustomTypeDescriptor
    {
        /// <summary>
        /// It contains a reference to the selected objet that will linked to the parent PropertyGrid.
        /// </summary>
        private object m_SelectedObject = null;
        /// <summary>
        /// It contains a reference to the collection of properties to show in the parent PropertyGrid.
        /// </summary>
        /// <remarks>
        /// By default, m_PropertyDescriptors contains all the properties of the object. 
        /// </remarks>
        List<PropertyDescriptor> m_PropertyDescriptors = new List<PropertyDescriptor>();

        /// <summary>
        /// A Simple constructor.
        /// </summary>
        /// <param name="obj">
        /// A reference to the selected object that will linked to the parent PropertyGrid.
        /// </param>
        internal ObjectWrapper(object obj)
        {
            m_SelectedObject = obj;
        }

        /// <summary>
        /// Getting or setting a reference to the selected objet that will linked to the parent PropertyGrid.
        /// </summary>
        public object SelectedObject
        {
            get 
            {
        		return m_SelectedObject; 
        	}
            set 
            {
        		if (m_SelectedObject != value)
        		{
        			m_SelectedObject = value; 
        		}
            }
        }

        /// <summary>
        /// Getting or setting a reference to the collection of properties to show in the parent PropertyGrid.
        /// </summary>
        public List<PropertyDescriptor> PropertyDescriptors
        {
            get 
            { 
            	return m_PropertyDescriptors; 
            }
            set 
            {
            	m_PropertyDescriptors = value; 
            }
        }

        #region ICustomTypeDescriptor Members
        
        /// <summary>
        /// 
        /// </summary>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyDescriptorCollection GetProperties()
        {
            return new PropertyDescriptorCollection(m_PropertyDescriptors.ToArray(), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(m_SelectedObject, true);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(m_SelectedObject, true);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        ///
        /// </returns>
        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(m_SelectedObject, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(m_SelectedObject, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(m_SelectedObject, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(m_SelectedObject, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editorBaseType">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributes">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(m_SelectedObject, attributes, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(m_SelectedObject, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pd">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return m_SelectedObject;
        }
        #endregion
    }	
}

