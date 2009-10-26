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
using System.Collections;
using System.Xml;
using IEC61850.SCL;

namespace OpenSCL
{
	/// <summary>
	/// Description of Private. 
	/// This class contains some methods to manipulate the information of a tPrivate object.
	/// </summary>
	public class Private
	{
		public Private()
		{
			
		}
				 
		/// <summary>
		/// This method modifies the values of an element node.
		/// </summary>
		/// <param name="indexElement">
		/// Position of the element that will be updated his values.
		/// </param>
		/// <param name="sCLPrivate">
		/// tPrivate object that has been edited.
		/// </param>
		/// <param name="prefix">
		/// New value of the prefix of the space of element node.
		/// </param>
		/// <param name="localName">
		/// New local name that will be set to the element node.
		/// </param>
		/// <param name="namespaceURI">
		/// New URI of name space that will be set to the element node.
		/// </param>
		/// <param name="valueElement">
		/// New value that will be set to the element node.</param>		
		public void ModifyElement(int indexElement, tPrivate sCLPrivate, string prefix, string localName, string namespaceURI, string valueElement)
		{
			XmlNode[] ObjXmlNode = sCLPrivate.Any;
			XmlDocument doc = new XmlDocument();
			XmlElementHierachy newElement = new XmlElementHierachy(prefix, localName, namespaceURI, doc);			
			if(!string.IsNullOrEmpty(valueElement))
			{
				newElement.InnerText = valueElement;
			}				
			for(int x = 0; sCLPrivate.Any[indexElement].Attributes!= null && x < sCLPrivate.Any[indexElement].Attributes.Count; x++)				
			{
				newElement.SetAttribute(sCLPrivate.Any[indexElement].Attributes[x].Name, sCLPrivate.Any[indexElement].Attributes[x].Value);
			}					
			ObjXmlNode[indexElement] = newElement;
			sCLPrivate.Any = ObjXmlNode;
		}
		
		/// <summary>
		/// This method modifies the values of an attribute node.
		/// </summary>
		/// <param name="indexElement">
		/// Element's position where an attribute will be modified.
		/// </param>
		/// <param name="indexAttribute">
		/// Attribute's position to edit.
		/// </param>
		/// <param name="sCLPrivate">
		/// tPrivate object that it is been modified.
		/// </param>
		/// <param name="name">
		/// New local name that will be set to the attribute.
		/// </param>
		/// <param name="value">
		/// New URI of the name space that will be set to the attribute.
		/// </param>
		public void ModifyAttribute(int indexElement, int indexAttribute, tPrivate sCLPrivate, string name, string value)
		{			
			if(!(sCLPrivate.Any[indexElement] is XmlElementHierachy))
			{
				XmlDocument doc = new XmlDocument();
				XmlElementHierachy newElement = new XmlElementHierachy(sCLPrivate.Any[indexElement].Prefix, sCLPrivate.Any[indexElement].LocalName, sCLPrivate.Any[indexElement].NamespaceURI, doc);
				for(int x = 0; sCLPrivate.Any[indexElement].Attributes!= null && x < sCLPrivate.Any[indexElement].Attributes.Count; x++)
				{
					newElement.SetAttribute(sCLPrivate.Any[indexElement].Attributes[x].Name, sCLPrivate.Any[indexElement].Attributes[x].Value);
				}
				sCLPrivate.Any[indexElement] = newElement;
			}			
			if(indexAttribute!=0)
			{
				(sCLPrivate.Any[indexElement] as XmlElementHierachy).SetAttribute(name, value);
				(sCLPrivate.Any[indexElement].Attributes).InsertAfter(sCLPrivate.Any[indexElement].Attributes[sCLPrivate.Any[indexElement].Attributes.Count-1],sCLPrivate.Any[indexElement].Attributes[indexAttribute-1]);				
			}
			else
			{
				(sCLPrivate.Any[indexElement] as XmlElementHierachy).SetAttribute(name, value);
				sCLPrivate.Any[indexElement].Attributes.Prepend(sCLPrivate.Any[indexElement].Attributes[sCLPrivate.Any[indexElement].Attributes.Count-1]);				
			}
		}
		
		/// <summary>
		/// This method adds an attribute to an element node.
		/// </summary>
		/// <param name="indexElement">
		/// Element's position where an attribute will be added.
		/// </param>
		/// <param name="sCLPrivate">
		/// tPrivate object that it is been edited.
		/// </param>
		/// <param name="name">
		/// Local name that will be assigned to the attribute.
		/// </param>
		/// <param name="value">
		/// URI of the name space that will be assigned to the attribute.
		/// </param>
		public void AddAttribute(int indexElement, tPrivate sCLPrivate, string name, string value)
		{
			if(!(sCLPrivate.Any[indexElement] is XmlElementHierachy))
			{
				XmlDocument doc = new XmlDocument();
				XmlElementHierachy newElement = new XmlElementHierachy(sCLPrivate.Any[indexElement].Prefix, sCLPrivate.Any[indexElement].LocalName, sCLPrivate.Any[indexElement].NamespaceURI, doc);
				for(int x = 0; sCLPrivate.Any[indexElement].Attributes!= null && x < sCLPrivate.Any[indexElement].Attributes.Count; x++)
				{
					newElement.SetAttribute(sCLPrivate.Any[indexElement].Attributes[x].Name, sCLPrivate.Any[indexElement].Attributes[x].Value);
				}
				sCLPrivate.Any[indexElement] = newElement;
			}			
			(sCLPrivate.Any[indexElement] as XmlElementHierachy).SetAttribute(name, value);
		}		
		
		/// <summary>
		/// This method adds an element node to the tPrivate object.
		/// </summary>
		/// <param name="sCLPrivate">
		/// tPrivate object that it's been edited.
		/// </param>
		/// <param name="prefix">
		/// New value of the space prefix of the element node.
		/// </param>
		/// <param name="localName">
		/// Local name that will be set to the element node.
		/// </param>
		/// <param name="namespaceURI">
		/// URI of the space name that will be set to the element node.
		/// </param>
		/// <param name="valueElement">
		/// Value that will be set to the element node.
		/// </param>		
		public void AddElement(tPrivate sCLPrivate, string prefix, string localName, string namespaceURI, string valueElement)
		{
			XmlNode[] ObjXmlNode = new XmlNode[1];
			XmlDocument doc = new XmlDocument();
			XmlElementHierachy newElement = new XmlElementHierachy(prefix, localName, namespaceURI, doc);
			if(!string.IsNullOrEmpty(valueElement))
			{
				newElement.InnerText = valueElement;
			}			
			ObjXmlNode[0] = newElement;			
			if(sCLPrivate.Any==null)
			{				
				sCLPrivate.Any = ObjXmlNode;
			}
			else
			{
				XmlNode[] ObjXmlNodeTemp = new XmlNode[sCLPrivate.Any.Length+1];
				sCLPrivate.Any.CopyTo(ObjXmlNodeTemp, 0);
				ObjXmlNodeTemp[sCLPrivate.Any.Length] = ObjXmlNode[0];
				sCLPrivate.Any = ObjXmlNodeTemp;
			}		
		}
		
		/// <summary>
		/// This method deletes an element of the tPrivate object that it's been edited.
		/// </summary>
		/// <param name="indexElement">
		/// Element's position where the tPrivate object will be deleted.
		/// </param>
		/// <param name="sCLPrivate">
		/// tPrivate object that it's been edited.
		/// </param>
		public void DeleteElement(int indexElement, tPrivate sCLPrivate)
		{		
			ArrayList arrayList = new ArrayList(sCLPrivate.Any);			
			arrayList.RemoveAt(indexElement);
			Array newArray = Array.CreateInstance(typeof(XmlNode), arrayList.Count);
			arrayList.CopyTo(newArray);
			sCLPrivate.Any = (XmlNode[]) newArray;				
		}
	}
	
	/// <summary>
	/// Custom class that inherits from XmlElement class. 
	/// </summary>
	/// <remarks>
	/// This class was created to access at his constructor and other methods that are defined as protected.
	/// </remarks>
	public class XmlElementHierachy : XmlElement
	{
		public XmlElementHierachy(string prefix, string localName, string namespaceURI, XmlDocument doc) : base (prefix, localName, namespaceURI, doc)
		{		
		}	
		
		/// <summary>
		/// This method sets the attribute's value using the specified name.
		/// </summary>
		/// <param name="name">
		/// Attribute's name that will be created or modified. 
		/// It shall be a complete name, If the name contains a character of two points, it is analized on the prefix components and local name.
		/// </param>
		/// <param name="value">
		/// Value that will be set to the attribute.
		/// </param>
		public void EstablishAttribute(string name, string value)
		{
			base.SetAttribute(name, value);
		}
	}
}