// OpenSCLConfigurator
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 3
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.


using System;
using System.IO;
using System.Xml.Serialization;
using OpenSCL;
using IEC61850.SCL;

namespace OpenSCL.Console
{
	class Application
	{		
   		private OpenSCL.Object sclObject;
		
		public Application ()
		{
			System.Console.WriteLine ("***********************************************************************");
			System.Console.WriteLine ("\nOpenSCLConfigurator Console Application\n");
			System.Console.WriteLine ("Copyright (C) 2009 Comisión Federal de Electricidad\n");
			System.Console.WriteLine ("This program is free software; you can redistribute it and/or");
			System.Console.WriteLine ("modify it under the terms of the GNU General Public License");
			System.Console.WriteLine ("as published by the Free Software Foundation; either version 3");
			System.Console.WriteLine ("of the License, or (at your option) any later version.\n");
			System.Console.WriteLine ("This program is distributed in the hope that it will be useful,");
			System.Console.WriteLine ("but WITHOUT ANY WARRANTY; without even the implied warranty of");
			System.Console.WriteLine ("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
			System.Console.WriteLine ("GNU General Public License for more details.\n");
			System.Console.WriteLine ("You should have received a copy of the GNU General Public License");
			System.Console.WriteLine ("along with this program; if not, write to the Free Software");
			System.Console.WriteLine ("Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.\n");
			System.Console.WriteLine ("***********************************************************************\n");
		}
		
				public Application (string[] args)
		{
			// FIXME: Allow to pass path to an ICD, CID or SCD file
		}
   		
		public void ShowIEDs ()
		{
			foreach (IEC61850.SCL.tIED i in sclObject.ConfiguredDevices) {
				string text = "\nIED: ";
				text += i.name;
				text += " Vendor: ";
				text += i.manufacturer;
				System.Console.WriteLine (text);
			}
		}
		
		private void PrintLDs (tLDevice[] lds, string ied)
		{
			foreach (tLDevice item in lds) {
				string text = ied;
				text += "/";
				//FIXME: Must use instance or LD's name?
				text += item.inst;
				text += "\n";
				System.Console.WriteLine (text);
			}
		}
		
		private void PrintAPLDs (tLDevice[] lds, string ied, string ap)
		{
			foreach (tLDevice item in lds) {
				string text = ied;
				text += "/";
				//FIXME: Must use instance or LD's name?
				text += ap;
				text += "/";
				text += item.inst;
				text += "\n";
				System.Console.WriteLine (text);
			}
		}
		
		private void PrintAPs (tAccessPoint[] aps, string ied)
		{
			foreach (tAccessPoint item in aps) {
				string text = ied;
				text += "/";
				//FIXME: Must use instance or LD's name?
				text += item.name;
				text += "\n";
				System.Console.WriteLine (text);
			}
		}
		
		private void ShowLogicalDevices (string ied)
		{
			IEC61850.SCL.tLDevice[] lds = sclObject.GetLD (ied);
			if (lds == null)
				System.Console.WriteLine("Error on getting AP LD on device\n");
			else
				this.PrintLDs(lds, ied);
		}
		
		private void ShowAPs (string ied)
		{
			int iedindex = sclObject.GetIED(ied);
			if (iedindex < 0)
			{
				System.Console.WriteLine("Error: IED doesn't exist\n");
			}
			else
			{
				IEC61850.SCL.tAccessPoint[] aps = sclObject.GetAP(iedindex);
				this.PrintAPs(aps, ied);
			}
		}
		
		private void ShowApLD (string ied, string ap)
		{
			System.Console.WriteLine("Showing LDs on Access Point:\n");
			IEC61850.SCL.tLDevice[] lds = sclObject.GetLD (ied, ap);
			this.PrintAPLDs(lds, ied, ap);
		}
		
   		/// <summary>
   		/// Starts of the application
   		/// </summary>
   		/// <param name="args">
   		/// 
   		/// </param>
		public static void Main(string[] args)			
		{
			bool run = true;
			
			Application app = new Application ();
			while (run) {
				char [] separator = { ' ' };
				System.Console.Write("command: ");
				string command_all = System.Console.ReadLine();
				string[] command = command_all.Split (separator, StringSplitOptions.None);
								
				switch (command[0]) {
					case "open":
					{
						System.Console.WriteLine("Write path to file type SCD, CID or ICD:");
						string FileName = System.Console.ReadLine();
						app.sclObject = new Object(FileName);
						
						if (app.sclObject.IsSCD())
						{
							string numied = "This is a SCD file. Configured IEDs: ";
							numied += app.sclObject.ConfiguredDevices.GetLength(0);
							numied += "\n";
							System.Console.WriteLine(numied);
						}
						else
						{
							System.Console.WriteLine("This is may be an ICD or CID file: Just ONE IED is configured");
						}
						string text = "Configuration Version: ";
						text += app.sclObject.ConfigurationVersion;
						text += "\n";
						text += "Configuration Revision: ";
						text += app.sclObject.ConfigurationRevision;
						text += "\n";
						System.Console.WriteLine(text);
						break;
					}
					case "save":
					{
						System.Console.WriteLine("Write path and file name to save:");
						string FileName = System.Console.ReadLine();
						app.sclObject.Serialize(FileName);
						break;
					}
					case "create": 
					{
						if (command[1].Equals("ied")) {
							System.Console.WriteLine("Creating a Generic Configured IED Description (CID)...");
							System.Console.WriteLine("Not Yet Implemented...");
							// FIXME: This command doesn't work becouse object not initialized
							/*Device ied = new Device();
							System.Console.WriteLine("Write path to file for New GENERIC IED Configuration");
							System.Console.WriteLine("At the end of the filename will be added '.cid' extension");
							string FileName = System.Console.ReadLine();
							ied.Write(FileName+".cid");
							System.Console.WriteLine ("New Generic CID created with config version number: "+ied.configVersion);*/
						}
						
						if (command[1].Equals("substation")) {
							System.Console.WriteLine("Creating a Generic Substation Configuration Description (SCD)...");
							System.Console.WriteLine("Not Implemented...");
						}
						break;
					}			
					case "help": 
					{
						System.Console.WriteLine("\nAccepted commands:\n");
						System.Console.WriteLine("open");
						System.Console.WriteLine("       Opens an IEC6850 SCL compliant file (ICD, CID or SCD)\n");
						System.Console.WriteLine("create [ied|substation]");
						System.Console.WriteLine("       Creates an Generic XML file type CID, if 'ied' is given, or SCD, if 'substation'\n");
						System.Console.WriteLine("exit");
						System.Console.WriteLine("       Quit from the application\n");
						break;
					}					
					case "test": 
					{
						System.Console.WriteLine("\nNot Implemented\n");
						break;
					}				
					case "exit":
					{
						run = false;
						break;
					}
					case "show":
					{
						if (command.GetLength(0) > 1)
						{
							if(command[1].Equals("header")) {
								System.Console.WriteLine("Not implemented\n");
								//app.ShowHeader(app.sclObject.Configuration.Header);
							}
							if(command[1].Equals("communications")) {
								System.Console.WriteLine("Not implemented\n");
								//app.ShowCommunication(app.sclObject.Configuration.Communication);
							}
							if(command[1].Equals("devices")) {
								app.ShowIEDs();
							}
							if(command[1].Equals("ied")) {
								if (command.GetLength(0) > 3) {
									if (command[3].Equals("ld"))
									{
										app.ShowLogicalDevices (command[2]);
									}
								
									if (command[3].Equals("ap"))
									{
										app.ShowAPs (command[2]);
									}
								
									if (command[3].Equals("apld"))
									{
										if (command.GetLength(0) > 4)
											app.ShowApLD (command[2], command[4]);
										else
											System.Console.WriteLine("Syntax Error: No AP name given\n");
									}
								}
								else
								{
									if (command.GetLength(0) > 2) {
										int numied = app.sclObject.GetIED (command[2]);
										if (numied >= 0) {
											string ied = "IED Number: ";
											ied += numied;
											System.Console.WriteLine(ied);
										}
										else
											System.Console.WriteLine ("The IED doesn't exist...");
									}
								}
								
							}
						}
						break;
					}
				case "":
					break;
				default:
					{
						System.Console.WriteLine("Syntax error...");
						break;
					}
				}
				//System.Console.WriteLine("Command not found or syntax error...");
			}
		}
	}
}