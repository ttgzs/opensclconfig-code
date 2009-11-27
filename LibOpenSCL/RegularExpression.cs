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
using System.Text.RegularExpressions;

namespace OpenSCL
{
	/// <summary>
	/// This class includes the methods to validate attributes using regular expressions. 
	/// </summary>
	public class RegularExpression
	{
		public RegularExpression()
		{
		}
		
		/// <summary>
		/// This method verifies if the attribute value is a number.
		/// </summary>
		/// <param name="numberPossible">
		/// Value of the attribute.
		/// </param>
		/// <returns>
		/// It returns a true value if the attribute value is a number, otherwise it returns a false.
		/// </returns>
		public bool IsNumber(string numberPossible)   
        {   
            return Regex.IsMatch(numberPossible, @"^\d+$");   
        }  														
		
		/// <summary>
		/// This method verifies if the attribute value has a character.
		/// </summary>
		/// <param name="wordcharacterPossible">
		/// Value of the attribute.
		/// </param>
		/// <returns>
		///  It returns a true value if the attribute value has at leas one character, otherwise it returns a false.
		/// </returns>
		public bool IsWordCharacter(string wordcharacterPossible)
		{
			return Regex.IsMatch(wordcharacterPossible, @"[\p{L}]");
		}
	}		
}
