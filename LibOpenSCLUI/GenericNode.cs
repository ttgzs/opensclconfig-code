//
//  GenericNode.cs
//
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//
//  Copyright (c) 2013 Daniel Espinosa
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
using System.Windows.Forms;

namespace OpenSCL.UI
{
	public class GenericNode : TreeNode
	{
		private int _index;
		private object _reference;
		private string name;

		public new int Index { 
			get { return _index; }
			set {
				_index = value;
				update_name ();
			}
		}

		public new string Name { 
			get { return name; }
			set {
				name = value;
				update_name ();
			}
		}

		public new object Tag { 
			get { return _reference; }
			set {
				_reference = value;
				update_name ();
			}
		}

		public GenericNode ()
		{
			name = "";
			_index = -1;
			update_name ();
		}

		public void AddArray (Array obj)
		{
			for (int i = 0; i < obj.Length; i++) {
				var n = new GenericNode ();
				Index = i;
				n.Tag = obj;
				this.Nodes.Add (n);
			}
		}

		private void update_name ()
		{
			string sufix = "";
			if (name == "")
				name = this.GetType ().BaseType.ToString ();
			if (_index >= 0)
				sufix = _index.ToString ();
			if (_reference != null && name == "")
				name = _reference.GetType ().ToString ();

			name += sufix;
			this.Text = name;
		}

		public delegate void UpdatedHander (object sender, string what);
		public event UpdatedHander Updated;

		public void OnUpdated (string what)
		{
			if (Updated != null)
				Updated (this, what);
		}
	}
}

