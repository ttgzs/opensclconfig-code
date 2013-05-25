//
//  Utility.cs
//
//  Authors:
//       Danil Espinosa Ortiz
//       esodan <${AuthorEmail}>
//
//  Copyright (c) 2009 Comision Federal de Electricidad
//  Copyright (c) 2013 esodan
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using IEC61850.SCL;

namespace OpenSCL
{
	public class Utility
	{
		public static void AddItemToArray (object item, System.Array array)
		{
			int arraySize = array.GetLength (0);
   			Array tempArray = Array.CreateInstance (item.GetType (), arraySize + 1);
   			array.CopyTo (tempArray, 0);
   			array = tempArray;
   			array.SetValue (item, arraySize);
		}

		public static string GetSCLName (object obj)
		{
			if (obj is tControlBlock)
				return ((tControlBlock) obj).cbName;

			if((obj is tNaming))
				return ((tNaming) obj).name;

			if (obj is tLDevice)
				if (((tLDevice) obj).inst != null)
					return ((tLDevice) obj).inst;
				else
					return "NoInstanceLogicalDevice";

			if (obj is tIDNaming)
					return ((tIDNaming) obj).id;

			if (obj is tAnyLN)
				return ((tLN) obj).prefix + ((tLN) obj).lnClass + ((tLN) obj).inst;
			
			return obj.GetType ().Name;
		}
	}
}