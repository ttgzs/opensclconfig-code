// 
//  tBasicType.cs
//  
//  Authors:
//       Comision Federal de Electricidad
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2009 Comision Federal de Electricidad
//  Copyright (c) 2010 Daniel Espinosa
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
using System.ComponentModel;

namespace IEC61850.SCL
{
	public class tBasicType
	{
		private string typeField;
		
		public tBasicType()
		{
			this.typeField = "BOOLEAN";
		}
		
		public tBasicTypeEnum bTypeEnum {
			get { return this.StringToEnum(this.typeField); }
			set { this.typeField = this.EnumToString(value); }
		}
		
		public string bType {
			get { return this.typeField; }
			set { this.typeField = value; }
		}
        
		public string EnumToString (tBasicTypeEnum t)
		{
			string text = "";
			switch (t) {
			
			case tBasicTypeEnum.BOOLEAN:
				text = "BOOLEAN";
				break;
			case tBasicTypeEnum.INT8:
				text = "INT8";
				break;				
			case tBasicTypeEnum.INT16:
				text = "INT16";
				break;				
			case tBasicTypeEnum.INT24:
				text = "INT24";
				break;			
			case tBasicTypeEnum.INT32:
				text = "INT32";
				break;			
			case tBasicTypeEnum.INT128:
				text = "INT128";
				break;			
			case tBasicTypeEnum.INT8U:
				text = "INT8U";
				break;				
			case tBasicTypeEnum.INT16U:
				text = "INT16U";
				break;				
			case tBasicTypeEnum.INT24U:
				text = "INT24U";
				break;				
			case tBasicTypeEnum.INT32U:
				text = "INT32U";
				break;				
			case tBasicTypeEnum.FLOAT32:
				text = "FLOAT32";
				break;				
			case tBasicTypeEnum.FLOAT64:
				text = "FLOAT64";
				break;				
			case tBasicTypeEnum.Enum:
				text = "Enum";
				break;				
			case tBasicTypeEnum.Dbpos:
				text = "Dbpos";
				break;				
			case tBasicTypeEnum.Tcmd:
				text = "Tcmd";
				break;				
			case tBasicTypeEnum.Quality:
				text = "Quality";
				break;				
			case tBasicTypeEnum.Timestamp:
				text = "Timestamp";
				break;				
			case tBasicTypeEnum.VisString32:
				text = "VisString32";
				break;				
			case tBasicTypeEnum.VisString64:
				text = "VisString64";
				break;
			case tBasicTypeEnum.VisString255:
				text = "VisString255";
				break;
			case tBasicTypeEnum.Octet64:
				text = "Octet64";
				break;
			case tBasicTypeEnum.Struct:
				text = "Struct";
				break;
			case tBasicTypeEnum.EntryTime:
				text = "EntryTime";
				break;
			case tBasicTypeEnum.Unicode255:
				text = "Unicode255";
				break;
			default:
				text = "Extension";
				break;
			}
			
			return text;
		}
		
		public tBasicTypeEnum StringToEnum (string t)
		{
			tBasicTypeEnum type;
			switch (t) {
			
			case "BOOLEAN":
				type = tBasicTypeEnum.BOOLEAN;
				break;
			
			case "INT8":
				type = tBasicTypeEnum.INT8;
				break;
				
			case "INT16":
				type = tBasicTypeEnum.INT16;
				break;
				
			case "INT24":
				type = tBasicTypeEnum.INT24;
				break;
			
			case "INT32":
				type = tBasicTypeEnum.INT32;
				break;
			
			case "INT128":
				type = tBasicTypeEnum.INT128;
				break;
			
			case "INT8U":
				type = tBasicTypeEnum.INT8U;
				break;
				
			case "INT16U":
				type = tBasicTypeEnum.INT16U;
				break;
				
			case "INT24U":
				type = tBasicTypeEnum.INT24U;
				break;
				
			case "INT32U":
				type = tBasicTypeEnum.INT32U;
				break;
				
			case "FLOAT32":
				type = tBasicTypeEnum.FLOAT32;
				break;
				
			case "FLOAT64":
				type = tBasicTypeEnum.FLOAT64;
				break;
				
			case "Enum":
				type = tBasicTypeEnum.Enum;
				break;
				
			case "Dbpos":
				type = tBasicTypeEnum.Dbpos;
				break;
				
			case "Tcmd":
				type = tBasicTypeEnum.Tcmd;
				break;
				
			case "Quality":
				type = tBasicTypeEnum.Quality;
				break;
				
			case "Timestamp":
				type = tBasicTypeEnum.Timestamp;
				break;
			case "VisString32":
				type = tBasicTypeEnum.VisString32;
				break;
				
			case "VisString64":
				type = tBasicTypeEnum.VisString64;
				break;
			case "VisString255":
				type = tBasicTypeEnum.VisString255;
				break;
			case "Octet64":
				type = tBasicTypeEnum.Octet64;
				break;
			case "Struct":
				type = tBasicTypeEnum.Struct;
				break;
			case "EntryTime":
				type = tBasicTypeEnum.EntryTime;
				break;
			case "Unicode255":
				type = tBasicTypeEnum.Unicode255;
				break;
			default:
				type = tBasicTypeEnum.Extension;
				break;
			}
			
			return type;
		}
	}
	
	
}

