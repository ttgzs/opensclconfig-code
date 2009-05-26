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
		
		/// <summary>
   		/// This method displays all data from the XML File 
   		/// </summary>   		
   		/// <param name="obj">
   		/// It contains the data of deserialization of the XML File 
   		/// Español: Es el objeto que se creo de la deserialización del archivo XML
   		/// </param>
   		private void ShowAll(OpenSCL.Object obj)
   		{
   			SCL config = obj.Configuration;
			System.Console.WriteLine("--------------------------------------------------------------------------------");
   			System.Console.WriteLine("\t\t\t\tXML File");
   			ShowBaseElement(config);
   			if(config.Header!=null)
   			{
   				System.Console.WriteLine("\n<<Header >>");
   				ShowHeader(config.Header);
   				ShowMessagePushButton();
   			}  			   			
   			if(config.Substation!=null&&config.Substation.Length!=0)
   			{
   				System.Console.WriteLine("\n\n<<Substation>>");
   				ShowSubstation(config.Substation);
   				ShowMessagePushButton();
   			}   				
   			if(config.Communication!=null)
   			{
   				System.Console.WriteLine("\n\n<<Communication>>");
   				ShowCommunication(config.Communication);
   				ShowMessagePushButton();
   			}   			
   			if(config.IED!=null&&config.IED.Length!=0)
   			{
   				System.Console.WriteLine("\n\n<<IEDs>>"); 
   				ShowDevices(config.IED);
   				ShowMessagePushButton();
   			}
   			if(config.DataTypeTemplates != null)
   			{
   				System.Console.WriteLine("\n\n<<DataTypeTemplates>>"); 
   				ShowDataTypeTemplates(config.DataTypeTemplates);
   				ShowMessagePushButton();
   			}
   		}
   		
   		/// <summary>
   		/// This method Show a message about press a key
   		/// </summary>
   		private void ShowMessagePushButton()
   		{
   			System.Console.Write("\nPress any key to continue. . . ");
			System.Console.ReadKey(true);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tHeader's class. This class contains
   		/// the header of the SCL File.
   		/// </summary>
   		/// <param name="Header">
   		/// Values of tHeader's class that will be displayed
   		/// </param>
   		private void ShowHeader(tHeader Header)
   		{ 			
   			System.Console.WriteLine(" id = {0} \n version = {1} \n revision = {2} \n toolID = {3} \n " +
                              "nameStructure = {4} ", Header.id, Header.version, Header.revision, 
                              Header.toolID, Header.nameStructure);          			         	
            if(Header.Text!=null)
            {
            	ShowText(Header.Text);
            }
            if(Header.History!=null && Header.History.Length!=0)
            	ShowHistory(Header.History);    
   		}
   		
   		/// <summary>
   		/// This method displays the values of tHitem's class. This class 
   		/// contains the history of the XML File.
   		/// </summary>
   		/// <param name="History">
   		/// Values of tHitem's class that will be displayed
   		/// </param>
   		private void ShowHistory(tHitem[] History)
   		{            	
            System.Console.WriteLine("\n<History (Historial)>");
            	for(int x=0; x < History.Length; x++)
            	{
            	  System.Console.WriteLine("\t<Hitem> \n\t\t # {0} version = {1} revisión = {2} when = {3} " +
                        "who = {4} what = {5} why = {6}", x+1, History[x].version, History[x].revision, 
                        History[x].when, History[x].who, History[x].what, History[x].why);            
            		ShowAnyContentFromOtherNamespace(History[x]);
            	} 
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubstation's class. This class 
   		/// contains some information about the substation, it's getting from the 
   		/// XML File.
   		/// </summary>
   		/// <param name="Substations">
   		/// Values of tSubstation's class that will be displayed
   		/// </param>
   		private void ShowSubstation(tSubstation[] Substations)
   		{   		
   			System.Console.WriteLine("<Substation>");
   			for(int x=0; x < Substations.Length; x++)
   			{  	   				   				   				
   				if(Substations[x].VoltageLevel!=null && Substations[x].VoltageLevel.Length!=0)
   					ShowVoltageLevel(Substations[x].VoltageLevel);   
   				if(Substations[x].Function!=null && Substations[x].Function.Length!=0)
   					ShowFunction(Substations[x].Function);
   				ShowEquipmentContainer(Substations[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tEquipmentContainer's class. 
   		/// </summary>
   		/// <param name="EquipmentContainer">
   		/// Values of tEquipmentContainer's class that will be displayed
   		/// </param>
   		private void ShowEquipmentContainer(tEquipmentContainer EquipmentContainer)
   		{   
   			System.Console.WriteLine("->EquipmentContainer");   
   			if(EquipmentContainer.AnyAttr != null)
   				System.Console.WriteLine(" anyAtribute = {0}", EquipmentContainer.AnyAttr);   			
   			if(EquipmentContainer.PowerTransformer!=null && EquipmentContainer.PowerTransformer.Length != 0)
   				ShowPowerTransformer(EquipmentContainer.PowerTransformer);
   			if(EquipmentContainer.GeneralEquipment!=null && EquipmentContainer.GeneralEquipment.Length != 0)
   				ShowGeneralEquipment(EquipmentContainer.GeneralEquipment);
   			ShowPowerSystemResource(EquipmentContainer);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPowerSystemResource's class.
   		/// </summary>
   		/// <param name="PowerSystemResource">
   		/// Values of tPowerSystemResource's class that will be displayed
   		/// </param>
   		private void ShowPowerSystemResource(tPowerSystemResource PowerSystemResource)
   		{   	
   			System.Console.WriteLine("->PowerSystemResource ");
   			ShowLNodeContainer(PowerSystemResource);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPowerTransformer's class.
   		/// </summary>
   		/// <param name="PowerTransformers">
   		/// Values of tPowerTransformer's class that will be displayed
   		/// </param>
   		private void ShowPowerTransformer(tPowerTransformer[] PowerTransformers)
   		{
   			System.Console.WriteLine("->PowerTransformer (Transformadores)");
   			for(int x=0; x < PowerTransformers.Length; x++)
   			{   				
   				System.Console.WriteLine("\ttype = {0} ", PowerTransformers[x].type);
   				if(PowerTransformers[x].TransformerWinding!=null&&PowerTransformers[x].TransformerWinding.Length!=0)
   					ShowTransformerWinding(PowerTransformers[x].TransformerWinding);
   				ShowEquipment(PowerTransformers[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tEquipment's class.
   		/// </summary>
   		/// <param name="Equipment">
   		/// Values of tEquipment's class that will be displayed
   		/// </param>
   		private void ShowEquipment(tEquipment Equipment)
   		{
   			System.Console.WriteLine("-> Equipment");
   			System.Console.WriteLine(" Equipment \n\t virtual = {0}", Equipment.@virtual);
   			ShowPowerSystemResource(Equipment);   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tTransformerWinding's class.
   		/// </summary>
   		/// <param name="TransformerWindings">
   		/// Values of tTransformerWinding's class that will be displayed
   		/// </param>
   		private void ShowTransformerWinding(tTransformerWinding[] TransformerWindings)
   		{
   			System.Console.WriteLine("<TransformerWinding >");
   			for(int x = 0; x < TransformerWindings.Length; x++)
   			{   				
   				System.Console.WriteLine("#{0} type = {1}",x, TransformerWindings[x].type);
   				if(TransformerWindings[x].AnyAttr != null)
   					System.Console.WriteLine("anyAttribute = {0}", TransformerWindings[x].AnyAttr);
   				if(TransformerWindings[x].TapChanger != null)
   				{
   					ShowTapChanger(TransformerWindings[x].TapChanger);
   					System.Console.WriteLine("\n\tTap Changer type = {0} ",TransformerWindings[x].TapChanger.type);
   				}   	  				
   				ShowAbstractConductingEquipment(TransformerWindings[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tTapChanger's class.
   		/// </summary>
   		/// <param name="TapChanger">
   		/// Values of tTapChanger's class that will be displayed
   		/// </param>
   		private void ShowTapChanger(tTapChanger TapChanger)
   		{   			
   			System.Console.WriteLine("<Tap Changer> \n\ttype = {0}, virtual = {1}",TapChanger.type, TapChanger.@virtual);    			
   			ShowPowerSystemResource(TapChanger);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAbstractConductingEquipment's 
   		/// class.
   		/// </summary>
   		/// <param name="AbstractConductingEquipment">
   		/// Values of tAbstractConductingEquipment's class that will be displayed
   		/// </param>
   		private void ShowAbstractConductingEquipment(tAbstractConductingEquipment AbstractConductingEquipment)
   		{   
   			System.Console.WriteLine("->AbstractConductingEquipment");
   			if(AbstractConductingEquipment.Terminal!=null && AbstractConductingEquipment.Terminal.Length!=0)
   			{
   				ShowTerminal(AbstractConductingEquipment.Terminal);
   			}
   			if(AbstractConductingEquipment.SubEquipment!= null && AbstractConductingEquipment.SubEquipment.Length!=0)
   			{
   				ShowSubEquipment(AbstractConductingEquipment.SubEquipment);
   			}
   			ShowEquipment(AbstractConductingEquipment);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tTerminal's class.
   		/// </summary>
   		/// <param name="Terminals">
   		/// Values of tTerminal's class that will be displayed
   		/// </param>
   		private void ShowTerminal(tTerminal[] Terminals)
   		{
   			System.Console.WriteLine("<Terminal >");
   			for(int x = 0; x < Terminals.Length; x++)
   			{   				
   				System.Console.WriteLine(" #{0} name = {1}  connectivityNode = {2} substationName = {3} voltageLevelName = {4} bayName = {5} cNodeName = {6}",x, Terminals[x].name, Terminals[x].connectivityNode, Terminals[x].substationName, Terminals[x].voltageLevelName, Terminals[x].bayName, Terminals[x].cNodeName);
   				ShowUnNaming(Terminals[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubEquipment's class.
   		/// </summary>
   		/// <param name="SubEquipments">
   		/// Values of tSubEquipment's class that will be displayed
   		/// </param>
   		private void ShowSubEquipment(tSubEquipment[] SubEquipments)
   		{
   			System.Console.WriteLine("<SubEquipment >");
   			for(int x = 0; x < SubEquipments.Length; x++)
   			{   				
   				System.Console.WriteLine("#{0} Phase = {1}",x, SubEquipments[x].phase);
   				ShowPowerSystemResource(SubEquipments[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGeneralEquipment's class.
   		/// </summary>
   		/// <param name="GeneralEquipments">
   		/// Values of tGeneralEquipment's class that will be displayed
   		/// </param>
   		private void ShowGeneralEquipment(tGeneralEquipment[] GeneralEquipments)
   		{
   			
   			System.Console.WriteLine("<GeneralEquipment> ");
   			for(int x = 0; x < GeneralEquipments.Length; x++)
   			{   				
   				System.Console.WriteLine(" #{0} type = {1}",x, GeneralEquipments[x].type);
   				ShowEquipment(GeneralEquipments[x]);
   			}
   		}
   				
   		/// <summary>
   		/// This method displays the values of tVoltageLevel's class.
   		/// </summary>
   		/// <param name="VoltageLevels">
   		/// Values of tVoltageLevel's class that will be displayed
   		/// </param>
   		private void ShowVoltageLevel(tVoltageLevel[] VoltageLevels)
   		{
   			System.Console.WriteLine("<VoltageLevel >");
   			for(int x = 0; x < VoltageLevels.Length; x++)
   			{   				
   				if(VoltageLevels[x].Voltage != null)
   					ShowVoltage(VoltageLevels[x].Voltage); 
   				if(VoltageLevels[x].Bay!=null && VoltageLevels[x].Bay.Length != 0)
   					ShowBay(VoltageLevels[x].Bay);
   				ShowEquipmentContainer(VoltageLevels[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tVoltage's class.
   		/// </summary>
   		/// <param name="Voltage">
   		/// Values of tVoltage's class that will be displayed
   		/// </param>
   		private void ShowVoltage(tVoltage Voltage)
   		{
   			System.Console.WriteLine("<Voltage>");
   			ShowValueWithUnit(Voltage);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tValueWithUnit's class. 
   		/// </summary>
   		/// <param name="ValueWithUnit">
   		/// Values of tValueWithUnit's class that will be displayed.
   		/// </param>
   		private void ShowValueWithUnit(tValueWithUnit ValueWithUnit)
   		{
   			System.Console.WriteLine("\t->ValueWithUnit");
   			System.Console.WriteLine("\tunit = {0}, multiplier = {1}", ValueWithUnit.unit, ValueWithUnit.multiplier);  
   		}
   		
   		/// <summary>
   		/// This method displays the values of tBay's class. 
   		/// </summary>
   		/// <param name="Bays">
   		/// Values of tBay's class that will be displayed.
   		/// </param>
   		private void ShowBay(tBay[] Bays)
   		{
   			System.Console.WriteLine("Bay ");
   			for(int x = 0; x < Bays.Length; x++)
   			{   	  				   				
   				if(Bays[x].ConductingEquipment !=null && Bays[x].ConductingEquipment.Length != 0)
   					ShowConductingEquipment(Bays[x].ConductingEquipment);
   				if(Bays[x].ConnectivityNode!=null && Bays[x].ConnectivityNode.Length != 0)
   					ShowConnectivityNode(Bays[x].ConnectivityNode);
   				ShowEquipmentContainer(Bays[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tConductingEquipment's class.
   		/// </summary>
   		/// <param name="EquiposConductores">
   		/// Values of tConductingEquipment's class that will be displayed.
   		/// </param>
   		private void ShowConductingEquipment(tConductingEquipment[] EquiposConductores)
   		{
   			System.Console.WriteLine("<ConductingEquipment> ");
   			for(int x = 0; x < EquiposConductores.Length; x++)
   			{   				   				
   				System.Console.WriteLine("#{0} type = {1} ", x, EquiposConductores[x].type);   				   				 			
   				ShowAbstractConductingEquipment(EquiposConductores[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tConnectivityNode's class.
   		/// </summary>
   		/// <param name="NodosConectividad">
   		/// Values of tConnectivityNode's class that will be displayed.
   		/// </param>
   		private void ShowConnectivityNode(tConnectivityNode[] NodosConectividad)
   		{
   			System.Console.WriteLine("<ConnectivityNode> ");
   			for(int x = 0; x < NodosConectividad.Length; x++)
   			{   				   				
   				System.Console.WriteLine(" #{0} pathName = {1} name = {2} desc = {3}", x, NodosConectividad[x].pathName, NodosConectividad[x].name, NodosConectividad[x].desc);   			
   				ShowLNodeContainer(NodosConectividad[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLNodeContainer's class.
   		/// </summary>
   		/// <param name="NodesContainer">
   		/// Values of tLNodeContainer's class that will be displayed.
   		/// </param>
   		private void ShowLNodeContainer(tLNodeContainer NodesContainer)
   		{
   			System.Console.WriteLine("->NodeContainer ");   			
   			if(NodesContainer.LNode!=null && NodesContainer.LNode.Length!=0)
   			{
   				ShowLNode(NodesContainer.LNode);
   			}   			
   			ShowNaming(NodesContainer);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tNaming's class.
   		/// </summary>
   		/// <param name="Naming">
   		///  Values of tNaming's class that will be displayed.
   		/// </param>
   		private void ShowNaming(tNaming Naming)
   		{     			
   			System.Console.WriteLine("->Naming");   			
   			System.Console.WriteLine("name = {0} desc = {1}", Naming.name, Naming.desc);   			
   			ShowBaseElement(Naming);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLNode's class.
   		/// </summary>
   		/// <param name="LNodes">
   		/// Values of tLNode's class that will be displayed.
   		/// </param>
   		private void ShowLNode(tLNode[] LNodes)
   		{
   			System.Console.WriteLine("<LNode >");
   			for(int x = 0; x < LNodes.Length; x++)
   			{   			   				
   				System.Console.WriteLine("  #{0} desc = {1} InInst = {2} InClass = {3} iedName = {4} IdInst = {5} prefix = {6} InType = {7} ", x, LNodes[x].desc, LNodes[x].lnInst, LNodes[x].lnClass, LNodes[x].iedName, LNodes[x].ldInst, LNodes[x].prefix, LNodes[x].lnType);  			 				
   				ShowUnNaming(LNodes[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tUnNaming's class.
   		/// </summary>
   		/// <param name="UnNaming">
   		/// Values of tUnNaming's class that will be displayed.
   		/// </param>
   		private void ShowUnNaming(tUnNaming UnNaming)
   		{   			
   			System.Console.WriteLine("->UnNaming \n\tdesc= {0} ", UnNaming.desc);
   			if(UnNaming.AnyAttr != null)
   				System.Console.WriteLine("\tanyAttribute = {0}", UnNaming.AnyAttr);
   			ShowBaseElement(UnNaming);  		
   		}
   		
   		/// <summary>
   		/// This method displays the values of tFunction's class.
   		/// </summary>
   		/// <param name="Function">
   		/// Values of tFunction's class that will be displayed.
   		/// </param>
   		private void ShowFunction(tFunction[] Function)
   		{
   		 	System.Console.WriteLine("<Function>)");
   			for(int x = 0; x < Function.Length; x++)
   			{      				
   				if(Function[x].SubFunction != null && Function[x].SubFunction.Length !=0 )
	   				ShowSubFunction(Function[x].SubFunction);
   				if(Function[x].GeneralEquipment != null && Function[x].GeneralEquipment.Length !=0 )
   					ShowGeneralEquipment(Function[x].GeneralEquipment);
   				ShowPowerSystemResource(Function[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubFunction's class.
   		/// </summary>
   		/// <param name="SubFunctions">
   		/// Values of tSubFunction's class that will be displayed.
   		/// </param>
   		private void ShowSubFunction(tSubFunction[] SubFunctions)
   		{
   			System.Console.WriteLine("<SubFunction>");
   			for(int x = 0; x < SubFunctions.Length; x++)
   			{   				
   				if(SubFunctions[x].GeneralEquipment != null && SubFunctions[x].GeneralEquipment.Length !=0 )
   					ShowGeneralEquipment(SubFunctions[x].GeneralEquipment);
   				ShowPowerSystemResource(SubFunctions[x]);
   			}   			
   		}   		
   		
   		/// <summary>
   		/// This method displays the values of tCommunication's class.
   		/// </summary>
   		/// <param name="Communication">
   		/// Values of tCommunication's class that will be displayed.
   		/// </param>
   		private void ShowCommunication(tCommunication Communication)
   		{   			
   			ShowUnNaming(Communication);
   			ShowSubNetwork(Communication.SubNetwork);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubNetwork's class.
   		/// </summary>
   		/// <param name="SubNetworks">
   		/// Values of tSubNetwork's class that will be displayed.
   		/// </param>
   		private void ShowSubNetwork(tSubNetwork[] SubNetworks)
   		{
   			System.Console.WriteLine("<SubNetwork> ");   			
   			for(int x=0; x < SubNetworks.Length; x++)
   			{  				   				
   				if(SubNetworks[x].BitRate!=null)   				
   					ShowBitRateInMbPerSec(SubNetworks[x].BitRate);
   				if(SubNetworks[x].ConnectedAP != null && SubNetworks[x].ConnectedAP.Length != 0)
   					ShowConnectedAP(SubNetworks[x].ConnectedAP);
   				ShowNaming(SubNetworks[x]);
   			}  			
   		}
   		  		
   		/// <summary>
   		/// This method displays the values of tBitRateInMbPerSec's class.
   		/// </summary>
   		/// <param name="BitRateInMbPerSec">
   		/// Values of tBitRateInMbPerSec's class that will be displayed.
   		/// </param>
   		public void ShowBitRateInMbPerSec(tBitRateInMbPerSec BitRateInMbPerSec)
   		{
   			System.Console.WriteLine("->BitRateInMbPerSec");
   			ShowValueWithUnit(BitRateInMbPerSec);
   		}  		
   		   		
   		/// <summary>
   		/// This method displays the values of tConnectedAP's class.
   		/// </summary>
   		/// <param name="ConexionAP">
   		/// Values of tConnectedAP's class that will be displayed.
   		/// </param>
   		private void ShowConnectedAP(tConnectedAP[] ConexionAP)
   		{
   			System.Console.WriteLine("<ConnectedAP> ");
   			for(int x = 0;  x < ConexionAP.Length; x++)
   				{   					
	   				System.Console.WriteLine("\n iedName = {0} \n apName = {1}", ConexionAP[x].iedName, ConexionAP[x].apName);
	   				if(ConexionAP[x].Address != null && ConexionAP[x].Address.Length !=0 )
	   					ShowAddress(ConexionAP[x].Address); 
	   				if(ConexionAP[x].GSE != null && ConexionAP[x].GSE.Length != 0)
	   					ShowGSE(ConexionAP[x].GSE);
	   				if(ConexionAP[x].SMV != null && ConexionAP[x].SMV.Length != 0 )	   				
	   					ShowSMV(ConexionAP[x].SMV );
	   				if(ConexionAP[x].PhysConn != null && ConexionAP[x].PhysConn.Length != 0)
	   					ShowPhysConn(ConexionAP[x].PhysConn);
	   				ShowUnNaming(ConexionAP[x]);
   				}  			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tP's class.
   		/// </summary>
   		/// <param name="Address">
   		/// Values of tP's class that will be displayed.
   		/// </param>
   		private void ShowAddress(tP[] Address)
   		{
   			System.Console.WriteLine("<Address >");
   			for(int x = 0;  x < Address.Length; x++)
   			{
   				System.Console.WriteLine(" #{0} type = {1}", x, Address[x].type);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGSE's class.
   		/// </summary>
   		/// <param name="GSEs">
   		/// Values of tGSE's class that will be displayed.
   		/// </param>
   		private void ShowGSE(tGSE[] GSEs)
   		{
   			System.Console.WriteLine("<GSE>");
   			for(int x = 0;  x < GSEs.Length; x++)
   			{   				
   				if(GSEs[x].MinTime != null)
   					ShowDurationInMilliSec(GSEs[x].MinTime);
   				if(GSEs[x].MaxTime != null)   	
   					ShowDurationInMilliSec(GSEs[x].MaxTime);
   				ShowControlBlock(GSEs[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDurationInMilliSec's class.
   		/// </summary>
   		/// <param name="DurationInMilliSec">
   		/// Values of tDurationInMilliSec's class that will be displayed.
   		/// </param>
   		public void ShowDurationInMilliSec(tDurationInMilliSec DurationInMilliSec)
   		{   
   			System.Console.WriteLine("<DurationInMilliSec>");
   			System.Console.WriteLine(" MinTime unit = {0} multiplier = {1}", DurationInMilliSec.unit, DurationInMilliSec.multiplier);
   			ShowValueWithUnit(DurationInMilliSec);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tControlBlock's class.
   		/// </summary>
   		/// <param name="ControlBlock">
   		/// Values of tControlBlock's class that will be displayed.
   		/// </param>
   		public void ShowControlBlock(tControlBlock ControlBlock)
   		{   			
   			System.Console.WriteLine("->ControlBlock");
   			System.Console.WriteLine(" IdInst = {0} cbName = {1}", ControlBlock.ldInst, ControlBlock.cbName);
   			if(ControlBlock.Address!=null && ControlBlock.Address.Length != 0)
   			{
   				ShowAddress(ControlBlock.Address);
   			}
   			ShowUnNaming(ControlBlock);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSMV's class.
   		/// </summary>
   		/// <param name="SMVs">
   		/// Values of tSMV's class that will be displayed.
   		/// </param>
   		private void ShowSMV(tSMV[] SMVs)
   		{
   			System.Console.WriteLine("<SMV>");
   			for(int x = 0; x < SMVs.Length; x++)
   			{
   				ShowControlBlock(SMVs[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPhysConn's class.
   		/// </summary>
   		/// <param name="ConexionesFisicas">
   		/// Values of tPhysConn's class that will be displayed.
   		/// </param>
   		private void ShowPhysConn(tPhysConn[] ConexionesFisicas)
   		{
   			System.Console.WriteLine("<PhysConn> ");
   			for(int x = 0; x < ConexionesFisicas.Length; x++)
   			{
   				ShowP(ConexionesFisicas[x].P);
   			}
   		}
   		  
   		/// <summary>
   		/// This method displays the values of tP's class.
   		/// </summary>
   		/// <param name="P">
   		/// Values of tP's class that will be displayed.
   		/// </param>
   		private void ShowP(tP[] P)
   		{
	   		System.Console.WriteLine("<P>");
	   		for(int x = 0; x < P.Length; x++)
	   		{	
	   			System.Console.WriteLine(" P = {0} ", P[x].type);
	   		}
   		}
   		   		  
   		/// <summary>
   		/// This method displays the values of tIED's class.
   		/// </summary>
   		/// <param name="IEDs">
   		/// Values of tIED's class that will be displayed.
   		/// </param>
   		private void ShowDevices(tIED[] IEDs)
   		{   			
   			for(int x = 0; x < IEDs.Length; x++)
   			{   				
   				System.Console.WriteLine("\n <IED> {0} \n type = {1} \n manufacturer = {2} \n configVersion = {3}", x, IEDs[x].type, IEDs[x].manufacturer, IEDs[x].configVersion);    				
   				System.Console.WriteLine("\n NOTE: Attibutes of type boolean should be created for class tServiceYesNo ");
   				ShowServices(IEDs[x].Services);   				
   				if(IEDs[x].AccessPoint!=null&&IEDs[x].AccessPoint.Length!=0)
   					ShowAccesPoints(IEDs[x].AccessPoint); 
   				ShowNaming(IEDs[x]);
   			}   			
   		}
   		 
   		/// <summary>
   		/// This method displays the values of tServices's class.
   		/// </summary>
   		/// <param name="Services">
   		/// Values of tServices's class that will be displayed.
   		/// </param>
   		public void ShowServices(tServices Services)
   		{
   			System.Console.WriteLine("\n <Services> \n DynaAssociation = {0} ",Services.DynAssociation);
   			if(Services.SettingGroups != null)
   				System.Console.WriteLine("\n SettingGroups \n\t SGEdit = {0} \n\t ConfSG = {1}",Services.SettingGroups.SGEdit, Services.SettingGroups.ConfSG);
   			System.Console.WriteLine("\n GetDirectory = {0} \n GetDataObjectDefinition = {1} \n DataObjectDirectory = {2} \n SetDataSetValue = {3}",Services.GetDirectory, Services.GetDataObjectDefinition, Services.GetDataSetValue, Services.SetDataSetValue);
   			System.Console.WriteLine("\n DataSetDirectory = {0} \n",Services.DataSetDirectory);   				
   			if(Services.ConfDataSet != null)
   				System.Console.WriteLine(" ConfDataSet \n\t max = {0} maxAttributes = {1} \n\t modify = {2} ", Services.ConfDataSet.max, Services.ConfDataSet.maxAttributes, Services.ConfDataSet.modify);
   			if(Services.DynDataSet != null)
   				System.Console.WriteLine("\n DyDataSet \n\t max = {0} \n\t maxAttributes = {1}", Services.DynDataSet.max, Services.DynDataSet.maxAttributes);
   			System.Console.WriteLine("\n ReadWrite = {0} \n TimerActivatedControl = {1}", Services.ReadWrite, Services.TimerActivatedControl);
   			if(Services.ConfReportControl != null)
   				System.Console.WriteLine("\n ConfReportControl max = {0} ",Services.ConfReportControl.max);
   			System.Console.WriteLine("\n GetCBValues = {0} \n ",Services.GetCBValues);
   			if(Services.ConfLogControl != null)
   				System.Console.WriteLine("\n ConfLogControl max = {0} ",  Services.ConfLogControl.max);
   			if(Services.ReportSettings != null)
   			{
   				System.Console.WriteLine("\n ReportSettings\n\t  cbName = {0} \n\t datSet = {1} \n\t  rptID = {2} \n\t optFields = {3} \n\t bufTime = {4} " +
   					"\n\t trgOps = {5} \n\t  intgPd = {6}", Services.ReportSettings.cbName, Services.ReportSettings.datSet, Services.ReportSettings.rptID, Services.ReportSettings.optFields, Services.ReportSettings.bufTime, Services.ReportSettings.trgOps, Services.ReportSettings.intgPd);
   			}
   			if(Services.LogSettings != null)
   				System.Console.WriteLine("\n LogSettings \n\t cbName = {0} \n\t datSet = {1} \n\t logEna = {2} \n\t  trgOps = {3} \n\t  intgPd = {4} ", Services.LogSettings.cbName, Services.LogSettings.datSet, Services.LogSettings.logEna, Services.LogSettings.trgOps, Services.LogSettings.intgPd);
   					                                    
   			if(Services.GSESettings != null)	
   				System.Console.WriteLine("\n GSESettings \n\t cbName = {0} \n\t datSet = {1} \n\tappID = {2} \n\t dataLabel = {3} \n ", Services.GSESettings.cbName, Services.GSESettings.datSet, Services.GSESettings.appID, Services.GSESettings.dataLabel);
   			if(Services.SMVSettings != null)
   				System.Console.WriteLine("SMVSettings \n\t cbName = {0}\n\t datSet = {1} \n\t svID = {2}\n\t optFields = {3}\n\t smpRate = {4} \n ", Services.SMVSettings.cbName, Services.SMVSettings.datSet, Services.SMVSettings.svID, Services.SMVSettings.optFields, Services.SMVSettings.smpRate);
   			System.Console.WriteLine("GSEDir = {0} \n ", Services.GSEDir);
   			if(Services.GOOSE != null)
   				System.Console.WriteLine("GOOSE \n\t max = {0}\n\t client = {1}", Services.GOOSE.max, Services.GOOSE.client);
   			if(Services.GSSE != null)
   				System.Console.WriteLine("\n GSSE \n\t max = {0} \n\t client = {1}", Services.GSSE.max, Services.GSSE.client);
   			if(Services.ConfLNs != null)
   				System.Console.WriteLine("\n ConfLNs \n\t fixPrefix = {0} fixLnInst =  {1}", Services.ConfLNs.fixPrefix, Services.ConfLNs.fixLnInst);   				
   				
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAccessPoint's class.
   		/// </summary>
   		/// <param name="AccessPoint">
   		/// Values of tAccessPoint's class that will be displayed.
   		/// </param>
   		private void ShowAccesPoints(tAccessPoint[] AccessPoint)
   		{
   			System.Console.WriteLine("\n <AccessPoint>");
   			for(int x = 0; x < AccessPoint.Length; x++)
   			{   				
   				System.Console.WriteLine("\t{0}.- router = {1} clock = {2}", x, AccessPoint[x].router, AccessPoint[x].clock);
   				if(AccessPoint[x].Items != null && AccessPoint[x].Items.Length != 0)
   					ShowUnNamigServerLN(AccessPoint[x].Items); 
   				ShowNaming(AccessPoint[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tUnNaming's class.
   		/// </summary>
   		/// <param name="Items">
   		/// Values of tUnNaming's class that will be displayed.
   		/// </param>
   		private void ShowUnNamigServerLN(tUnNaming[] Items)   		
		{
   			for(int x = 0; x < Items.Length; x++)
   			{   				
   				System.Console.WriteLine("\n Server = {0}", x);   			
   			    //An object "Type" is obtained to determine what kind of element 
   			    //is, tServer or tLN   			   
   				Type vtype = (Items[x]).GetType();   			
   				if(vtype.Name.Equals("tServer"))
   				{   									
   					// The "tServer" class is obtained from "tUnNaming" class 
   					// using polymorphism
   					tUnNaming  Item = Items[x];
   					tServer Servidor = (tServer) Item;
   					ShowServer(Servidor);	
   				}
   				else if(vtype.Name.Equals("tLN"))
   				{
   					tUnNaming  Item = Items[x];
   					tLN LN = (tLN ) Item;
   					ShowLN(LN);
   				}
   				else{
					System.Console.WriteLine("\tVerify the conditions of the method ShowUnNamig");
   				}
   			}  			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tServer's class.
   		/// </summary>
   		/// <param name="Server">
   		/// Values of tServer's class that will be displayed.
   		/// </param>
   		private void ShowServer(tServer Server)
   		{
   			System.Console.WriteLine("<Server>");   					
   			if(Server.Authentication != null)
   				ShowAuthentication(Server.Authentication);   			
   			if(Server.LDevice != null && Server.LDevice.Length != 0)
   				ShowLDevice(Server.LDevice); 
   			if(Server.Association != null && Server.Association.Length != 0)
   				ShowAssociation(Server.Association);   			
   			ShowUnNaming(Server);   	
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAssociation's class.
   		/// </summary>
   		/// <param name="Association">
   		/// Values of tAssociation's class that will be displayed.
   		/// </param>
   		public void ShowAssociation(tAssociation[] Association)
   		{
   			System.Console.WriteLine("<Association>");
   			System.Console.WriteLine(" Verify if the attributes iedName and ldInst are Showed in the class tAssociation");
   			for(int x=0; x < Association.Length; x++)
   			{
   				System.Console.WriteLine("	\t kind = {0}, associationID = {1}, iedName = {2}, ldInst = {3}, prefix = {4}, lnClass = {5}, lnInst = {6}", Association[x].kind,
   				                  Association[x].associationID, Association[x].iedName, Association[x].lnInst,  Association[x].prefix, Association[x].lnClass, Association[x].lnInst);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tServerAuthentication's class.
   		/// </summary>
   		/// <param name="ServerAuthentication">
   		/// Values of tServerAuthentication's class that will be displayed.
   		/// </param>
   		public void ShowAuthentication(tServerAuthentication ServerAuthentication)
   		{
   			System.Console.WriteLine("<Authentication>");
   			System.Console.WriteLine("\tnone = {0} password {1} weak = {2} strong = {3} certificate = {4}", ServerAuthentication.none, ServerAuthentication.password, ServerAuthentication.weak, ServerAuthentication.strong, ServerAuthentication.certificate);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLN's class.
   		/// </summary>
   		/// <param name="LN">
   		/// Values of tLN's class that will be displayed.
   		/// </param>
   		private void ShowLN(tLN LN)
   		{
   			System.Console.WriteLine("<LN>");
   			System.Console.WriteLine(" lnClass = {0}, inst = {1}, prefix = {2}",LN.lnClass, LN.inst, LN.prefix);
   			ShowAnyLN(LN);
   		}   		
   		
  		/// <summary>
   		/// This method displays the values of tAnyLN's class.
   		/// </summary>
   		/// <param name="AnyLN">
   		/// Values of tAnyLN's class that will be displayed.
   		/// </param>
   		private void ShowAnyLN(tAnyLN AnyLN)
   		{  	   			
   			System.Console.WriteLine("-> AnyLN");
   			System.Console.WriteLine("	lnType = {0}", AnyLN.lnType);
   			if(AnyLN.DataSet != null && AnyLN.DataSet.Length != 0)
   				ShowDateSet(AnyLN.DataSet);
   			if(AnyLN.ReportControl != null && AnyLN.ReportControl.Length != 0)
   				ShowReportControl(AnyLN.ReportControl);
   			if(AnyLN.LogControl != null && AnyLN.LogControl.Length != 0)
   				ShowLogControl(AnyLN.LogControl);
   			if(AnyLN.DOI != null && AnyLN.DOI.Length != 0)
   				ShowDOI(AnyLN.DOI);   
   			if(AnyLN.Inputs != null)
   				ShowInputs(AnyLN.Inputs);
   			ShowUnNaming(AnyLN);
   		}   				
   		
   		/// <summary>
   		/// This method displays the values of tInputs's class.
   		/// </summary>
   		/// <param name="Inputs">
   		/// Values of tInputs's class that will be displayed.
   		/// </param>
   		private void ShowInputs(tInputs Inputs)
   		{  			   			
   			System.Console.WriteLine("<Inputs> ");   			
   			if(Inputs.ExtRef != null && Inputs.ExtRef.Length != 0)
   				ShowExtRef(Inputs.ExtRef);
   			ShowUnNaming(Inputs);
   			
   		}

   		/// <summary>
   		/// This method displays the values of tExtRef's class.
   		/// </summary>
   		/// <param name="ExtRefs">
   		/// Values of tExtRef's class that will be displayed.
   		/// </param>
   		public void ShowExtRef(tExtRef[] ExtRefs)
   		{
   			System.Console.WriteLine("<ExtRefs>");
   			for(int x = 0 ; x < ExtRefs.Length; x++)
   			{   		   				   				
   				System.Console.WriteLine(" #{0} iedName = {1} ldInst = {2} prefix = {3} lnClass = {4} lnInst = {5} doName = {6} daName = {7} intAddr = {8}",x, ExtRefs[x].iedName, ExtRefs[x].ldInst, ExtRefs[x].prefix, ExtRefs[x].lnClass, ExtRefs[x].lnInst, ExtRefs[x].doName, ExtRefs[x].daName, ExtRefs[x].intAddr);   				
   			}   			
   		}
   		  		
   		/// <summary>
   		/// This method displays the values of tDOI's class.
   		/// </summary>
   		/// <param name="DOIs">
   		/// Values of tDOI's class that will be displayed.
   		/// </param>
   		private void ShowDOI(tDOI[] DOIs)
   		{  			   			
   			System.Console.WriteLine("<DOI> ");
   			for(int x = 0 ; x < DOIs.Length; x++)
   			{     				
   				System.Console.WriteLine(" #{0} name = {1} ix = {2} accessControl = {3}",x, DOIs[x].name, DOIs[x].ix, DOIs[x].accessControl);   				
   				if(DOIs[x].Items != null && DOIs[x].Items.Length != 0)
   					ShowUnNamigSDI_DAI(DOIs[x].Items);
   				ShowUnNaming(DOIs[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDOI's class.
   		/// </summary>
   		/// <param name="Items">
   		/// Values of tSDI and/or tDAI classes.
   		/// </param>
   		private void ShowUnNamigSDI_DAI( tUnNaming[] Items)   		
		{
   			for(int x = 0; x < Items.Length; x++)
   			{   				
   				
   				System.Console.WriteLine("\n Server = {0}", x);   			
   			    //An object "Type" is obtained to determine what kind of element is tSDI or tDAI   				
   				Type vtype = (Items[x]).GetType();   			
   				if(vtype.Name.Equals("tSDI"))
   				{   					
   					// The "tServer" class is obtained from "tUnNaming" class using polymorphism   					   					
   					tUnNaming  Item = Items[x];
   					tSDI SDI = (tSDI) Item;
   					ShowSDI(SDI); 				
   				}
   				else if(vtype.Name.Equals("tDAI"))
   				{
   					tUnNaming  Item = Items[x];
   					tDAI DAI= (tDAI) Item;
   					ShowDAI(DAI); 
   				}
   				else{
					System.Console.WriteLine("\t Error!!! Verify the conditions of the method ShowUnNaming");
   				}
   			}  			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSDI's class.
   		/// </summary>
   		/// <param name="SDI">
   		/// Values of tSDI's class that will be displayed.
   		/// </param>
   		private void ShowSDI(tSDI SDI)
   		{  			 
   			System.Console.WriteLine("<SDI>");
   			System.Console.WriteLine(" name = {1}, ix = {2} ixSpecified", SDI.desc, SDI.name, SDI.ix, SDI.ixSpecified);
   			ShowUnNamigSDI_DAI(SDI.Items);
   			ShowUnNaming(SDI);
   		}   		
   			
   		/// <summary>
   		/// This method displays the values of tDAI's class.
   		/// </summary>
   		/// <param name="DAI">
   		/// Values of tDAI's class that will be displayed.
   		/// </param>
   		private void ShowDAI(tDAI DAI)
   		{  			 
   			System.Console.WriteLine("<DAI>");
   			System.Console.WriteLine(" name = {0}, sAddr = {1}, valKind = {2} ix = {3} ixSpecified = {4}", DAI.name, DAI.sAddr, DAI.valKind, DAI.ix, DAI.ixSpecified);
   			if(DAI.Val != null && DAI.Val.Length != 0)
   				ShowVal(DAI.Val);
   			ShowUnNaming(DAI);   					
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tVal's class.
   		/// </summary>
   		/// <param name="Val">
   		/// Values of tVal's class that will be displayed.
   		/// </param>
   		private void ShowVal(tVal[] Val)
   		{  		   			
   			for(int x = 0; x < Val.Length; x++)
   			{
   				System.Console.WriteLine("<Val>");
   				System.Console.WriteLine(" sGroup = {0}",Val);
   			}
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tLogControl's class.
   		/// </summary>
   		/// <param name="LogControl">
   		/// Values of tLogControl's class that will be displayed.
   		/// </param>
   		private void ShowLogControl(tLogControl[] LogControl)
   		{  			   			
   			System.Console.WriteLine("<LogControl>");
   			for(int x = 0 ; x < LogControl.Length; x++)
   			{
   				ShowControlWithTriggerOpt(LogControl[x]);
   				System.Console.WriteLine("\t#{0} logName = {1} logEna = {2} reasonCode = {3}",x, LogControl[x].logName, LogControl[x].logEna, LogControl[x].reasonCode);
   			}   			
   		}   		
   		 		
   		/// <summary>
   		/// This method displays the values of tControlWithTriggerOpt's class.
   		/// </summary>
   		/// <param name="ControlWithTriggerOpt">
   		/// Values of tControlWithTriggerOpt's class that will be displayed.
   		/// </param>
   		private void ShowControlWithTriggerOpt(tControlWithTriggerOpt ControlWithTriggerOpt)
   		{  			   			
   			System.Console.WriteLine("<ControlWithTriggerOpts>");
   			System.Console.WriteLine(" intgPd = {0}",ControlWithTriggerOpt);	   			
   			if(ControlWithTriggerOpt.TrgOps != null)
   			{
   				ShowTrgOps(ControlWithTriggerOpt.TrgOps);
   			}
   			ShowcControl(ControlWithTriggerOpt);
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tControl's class.
   		/// </summary>
   		/// <param name="Control">
   		/// Values of tControl's class that will be displayed.
   		/// </param>
   		private void ShowcControl(tControl Control)
   		{  			   			
   			System.Console.WriteLine("->Control");
   			System.Console.WriteLine("Control datSet = {0}", Control.datSet);	
   			ShowNaming(Control);
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tTrgOps's class.
   		/// </summary>
   		/// <param name="TrgOps">
   		/// Values of tTrgOps's class that will be displayed.
   		/// </param>
   		private void ShowTrgOps(tTrgOps TrgOps)
   		{  		   	
   			System.Console.WriteLine("<TrgOps>");
   			System.Console.WriteLine(" dchg = {0} qchg = {1} dupd = {2} period = {3}", TrgOps.dchg, TrgOps.qchg, TrgOps.dchg, TrgOps.period);	   			
   		}   		
   		
   		/// <summary>
   		/// This method displays the values of tDataSet's class.
   		/// </summary>
   		/// <param name="DataSet">
   		/// Values of tDataSet's class that will be displayed.
   		/// </param>
   		private void ShowDateSet(tDataSet[] DataSet)
   		{  			   		
   			System.Console.WriteLine("<DataSet>");
   			for(int x = 0; x < DataSet.Length; x++)
   			{     				
   				if(DataSet[x].FCDA != null && DataSet[x].FCDA.Length != 0)
   					ShowFCDA(DataSet[x].FCDA); 		
   				ShowNaming(DataSet[x]);   				
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tReportControl's class.
   		/// </summary>
   		/// <param name="ReportControl">
   		/// Values of tReportControl's class that will be displayed.
   		/// </param>
   		private void ShowReportControl(tReportControl[] ReportControl)
   		{  			   
   			System.Console.WriteLine("<ReportControl>");
   			for(int x = 0; x < ReportControl.Length; x++)
   			{   				   				
   				System.Console.WriteLine(" #{0} rptID = {1}, confRev = {2}, buffered = {3}, bufTime = {4}",x, ReportControl[x].rptID, ReportControl[x].confRev, ReportControl[x].buffered, ReportControl[x].bufTime);
   				if(ReportControl[x].OptFields != null)
   					ShowOptFields(ReportControl[x].OptFields); 
   				if(ReportControl[x].RptEnabled != null)
   					ShowRptEnabled(ReportControl[x].RptEnabled);
   				ShowControlWithTriggerOpt(ReportControl[x]);
   			}
   		}   		
   		
   		/// <summary>
   		/// This method displays the values of tRptEnabled's class.
   		/// </summary>
   		/// <param name="RptEnabled">
   		/// Values of tRptEnabled's class that will be displayed.
   		/// </param>
   		private void ShowRptEnabled(tRptEnabled RptEnabled)
   		{  	
   			System.Console.WriteLine("<RptEnabled> \n max = {0} ",RptEnabled.max);
   			if(RptEnabled.ClientLN != null)
   				ShowClientLN(RptEnabled.ClientLN);
   			ShowUnNaming(RptEnabled); 
   		}
   		
   		/// <summary>
   		/// This method displays the values of tClientLN's class.
   		/// </summary>
   		/// <param name="ClientLN">
   		/// Values of tClientLN's class that will be displayed.
   		/// </param>
   		private void ShowClientLN(tClientLN[] ClientLN)
   		{  		
   			System.Console.WriteLine("<ClientLN>");
   			for(int x = 0; x < ClientLN.Length; x++)
   			{   				
   				//System.Console.WriteLine("\tClientLN \n #{0} iedName =  ldInst =  prefix = {1} lnClass = {2} lnInst = {3}",x, ClientLN[x].prefix, ClientLN[x].lnClass, ClientLN[x].lnInst);
   				System.Console.WriteLine(" ClientLN \n #{0} iedName ={1}  ldInst = {2}  prefix = {3} lnClass = {4} lnInst = {5}",x, ClientLN[x].iedName, ClientLN[x].ldInst, ClientLN[x].prefix, ClientLN[x].lnClass, ClientLN[x].lnInst);
   			}   				
   		}
   		
   		/// <summary>
   		/// This method displays the values of tReportControlOptFields's class.
   		/// </summary>
   		/// <param name="OptFields">
   		/// Values of tReportControlOptFields's class that will be displayed.
   		/// </param>
   		private void ShowOptFields(tReportControlOptFields OptFields)
   		{  			   			   					
   			System.Console.WriteLine("<OptFields> \n seqNum = {0}, timeStamp = {1}, dataSet = {2}, reasonCode = {3} dataRef = {4} entryID = {5} configRef = {6}", OptFields.seqNum, OptFields.timeStamp, OptFields.dataSet, OptFields.reasonCode, OptFields.dataRef, OptFields.entryID, OptFields.configRef);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tFCDA's class.
   		/// </summary>
   		/// <param name="FCDA">
   		/// Values of tFCDA's class that will be displayed.
   		/// </param>
   		private void ShowFCDA(tFCDA[] FCDA)
   		{
   			System.Console.WriteLine("<FCDA>");
   			for(int x = 0; x < FCDA.Length; x++)
   			{
   				System.Console.WriteLine(" #{0} ldInst = {1} prefix = {2} lnClass = {3} lnInst = {4} doName = {5} daName = {6} fc = {7}",x, FCDA[x].ldInst, FCDA[x].prefix, FCDA[x].lnClass, FCDA[x].lnInst, FCDA[x].doName, FCDA[x].daName, FCDA[x].fc);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLDevice's class.
   		/// </summary>
   		/// <param name="LDevices">
   		/// Values of tLDevice's class that will be displayed.
   		/// </param>
   		private void ShowLDevice(tLDevice[] LDevices)
   		{
   			System.Console.WriteLine("<LDevice>");
   			for(int x = 0; x < LDevices.Length; x++)
   			{   				
   				System.Console.WriteLine("\t tDevice \n\t\t #{0} desc = {1} inst = {2} IdName = {3}",x, LDevices[x].desc, LDevices[x].inst, LDevices[x].ldName);
   				if(LDevices[x].LN0 != null )
   					ShowLN0Type(LDevices[x].LN0);
   				if(LDevices[x].LN != null && LDevices[x].LN.Length != 0)
   					ShowLNs(LDevices[x].LN);
   				if(LDevices[x].AccessControl != null)
   					ShowAccessControl(LDevices[x].AccessControl);
   				ShowUnNaming(LDevices[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAccessControl's class.
   		/// </summary>
   		/// <param name="AccessControl">
   		/// Values of tAccessControl's class that will be displayed.
   		/// </param>
   		public void ShowAccessControl(tAccessControl AccessControl)
   		{   
   			System.Console.WriteLine("<AccessControl>");   			
   			ShowAnyContentFromOtherNamespace(AccessControl);
   		}
   		
   		/// <summary>
   		/// This method displays the values of LN0's class.
   		/// Note: According to XSD File, the class should be called 
   		/// LN0Type but it's called LN0
   		/// </summary>
   		/// <param name="LNs">
   		/// Values of LN0's class that will be displayed.
   		/// </param>
   		public void ShowLNs(tLN[] LNs)
   		{
   			for(int x = 0; x <LNs.Length; x++)
   			{
   				ShowLN(LNs[x]);
   			}
   		}
   		  		
   		/// <summary>
   		/// This method displays the values of LN0's class.
   		/// Note: According to XSD File, the class should be called 
   		/// LN0Type but it's called LN0
   		/// </summary>
   		/// <param name="LN0">
   		/// Values of LN0's class that will be displayed.
   		/// </param>
   		public void ShowLN0Type(LN0 LN0)
   		{
   			System.Console.WriteLine("\tLN0 (LNodeType)");
   			if(LN0.AnyAttr != null)
   				System.Console.WriteLine("\t anyAttribute = {0}",LN0.AnyAttr);
   			ShowLN0(LN0);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLN0's class.
   		/// </summary>
   		/// <param name="Ln0">
   		/// Values of tLN0's class that will be displayed.
   		/// </param>
   		public void ShowLN0(tLN0 Ln0)
   		{
   			System.Console.WriteLine("-> Ln0");
   			System.Console.WriteLine(" InClass = {0} inst = {1}", Ln0.lnClass, Ln0.inst);
   			if(Ln0.GSEControl != null && Ln0.GSEControl.Length != 0)
   				ShowGSEControl(Ln0.GSEControl);
   			if(Ln0.SampledValueControl != null && Ln0.SampledValueControl.Length != 0)
   				ShowSampledValueControl(Ln0.SampledValueControl);
   			if(Ln0.SettingControl != null)
   				ShowSettingControl(Ln0.SettingControl);
   			if(Ln0.SCLControl != null)
   				ShowSCLControl(Ln0.SCLControl); 
   			if(Ln0.Log != null)
   				ShowLog(Ln0.Log);
   			ShowAnyLN(Ln0);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLog's class.
   		/// </summary>
   		/// <param name="Log">
   		/// Values of tLog's class that will be displayed.
   		/// </param>
   		public void ShowLog(tLog Log)
   		{
   			System.Console.WriteLine("<Log>");    			
   			ShowAnyContentFromOtherNamespace(Log);
   		}
   		   		   		
   		/// <summary>
   		/// This method displays the values of tSCLControl's class.
   		/// </summary>
   		/// <param name="SCLControl">
   		/// Values of tSCLControl's class that will be displayed.
   		/// </param>
   		public void ShowSCLControl(tSCLControl SCLControl)
   		{   			
   			System.Console.WriteLine("<SCLControl>");
   			ShowUnNaming(SCLControl);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSettingControl's class.
   		/// </summary>
   		/// <param name="SettingControl">
   		/// Values of tSettingControl's class that will be displayed.
   		/// </param>
   		public void ShowSettingControl(tSettingControl SettingControl)
   		{
   			System.Console.WriteLine("<SettingControl>");   			
   			System.Console.WriteLine(" numOfSGs = {0}, actSG = {1}", SettingControl.numOfSGs, SettingControl.actSG);
   			ShowUnNaming(SettingControl);
   		}
   		
    	/// <summary>
   		/// This method displays the values of tSampledValueControl's class.
   		/// </summary>
   		/// <param name="SampledValueControl">
   		/// Values of tSampledValueControl's class that will be displayed.
   		/// </param>
   		public void ShowSampledValueControl(tSampledValueControl[] SampledValueControl)
   		{   			
   			System.Console.WriteLine("SampledValueControl");
   			for(int x = 0; x < SampledValueControl.Length; x++)
   			{   				
   				System.Console.WriteLine("smvID = {0} multicast = {1} smpRate = {2} nofASDU = {3}", SampledValueControl[x].smvID, SampledValueControl[x].multicast, SampledValueControl[x].smpRate, SampledValueControl[x].nofASDU);
   				if(SampledValueControl[x].SmvOpts != null)
   					ShowSmvOpts(SampledValueControl[x].SmvOpts);
   				ShowControlWithIEDName(SampledValueControl[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSampledValueControlSmvOpts's class.
   		/// </summary>
   		/// <param name="SmvOpts">
   		/// Values of tSampledValueControlSmvOpts's class that will be displayed.
   		/// </param>
   		public void ShowSmvOpts(tSampledValueControlSmvOpts SmvOpts)
   		{
   			System.Console.WriteLine("<SmvOpts>");
   			System.Console.WriteLine(" refreshTime = {0}, sampleSynchronized = {1}, sampleRate = {2}, security = {3}, dataRef = {4}", SmvOpts.refreshTime, SmvOpts.sampleSynchronized, SmvOpts.sampleRate, SmvOpts.security, SmvOpts.dataRef);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGSEControl's class.
   		/// </summary>
   		/// <param name="GSEControl">
   		/// Values of tGSEControl's class that will be displayed.
   		/// </param>
   		public void ShowGSEControl(tGSEControl[] GSEControl)
   		{
   			System.Console.WriteLine("<GSEControl>");
   			for(int x = 0; x < GSEControl.Length; x++)
   			{   				   				
   				System.Console.WriteLine("appID = {0}", GSEControl[x].appID);
   				//if(GSEControl[x].type != null)
				ShowGSEControlTypeEnum(GSEControl[x].type);
				ShowControlWithIEDName(GSEControl[x]);
   			}   				
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGSEControlTypeEnum's class.
   		/// </summary>
   		/// <param name="GSEControlTypeEnum">
   		/// Values of tGSEControlTypeEnum's class that will be displayed.
   		/// </param>
   		public void ShowGSEControlTypeEnum(tGSEControlTypeEnum GSEControlTypeEnum)
   		{  			
   			System.Console.WriteLine("<GSEControlTypeEnum> \n\t",GSEControlTypeEnum);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tControlWithIEDName's class.
   		/// </summary>
   		/// <param name="ControlWithIEDName">
   		/// Values of tControlWithIEDName's class that will be displayed.
   		/// </param>
   		public void ShowControlWithIEDName(tControlWithIEDName ControlWithIEDName)
   		{
   			System.Console.WriteLine("->ControlWithIEDName");
   			System.Console.WriteLine("confRev = {0}", ControlWithIEDName.confRev);				   				
   			if(ControlWithIEDName.IEDName != null && ControlWithIEDName.IEDName.Length != 0)
   				ShowIEDName(ControlWithIEDName.IEDName);
   			ShowControl(ControlWithIEDName);
   		}
   		
   		/// <summary>
   		/// This method displays the values of IEDName's strings.
   		/// </summary>
   		/// <param name="IEDNames">
   		/// Values of String's class for IEDName
   		/// </param>
   		public void ShowIEDName(String[] IEDNames)
   		{
   			System.Console.WriteLine("IEDNames");
   			for(int x = 0; x < IEDNames.Length; x++)
   			{   				
   				System.Console.WriteLine("#{0} IEDame = {1}", x, IEDNames[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tControl's class.
   		/// </summary>
   		/// <param name="Control">
   		/// Values of tControl's class that will be displayed.
   		/// </param>
   		public void ShowControl(tControl Control)
   		{   			
   			System.Console.WriteLine("-> Control \n\t datSet = {0}", Control.datSet);
   			ShowNaming(Control);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDataTypeTemplates's class.
   		/// </summary>
   		/// <param name="DataTypeTemplates">
   		/// Values of tDataTypeTemplates's class that will be displayed.
   		/// </param>
  		private void ShowDataTypeTemplates(tDataTypeTemplates DataTypeTemplates)
  		{  		  			
  			System.Console.WriteLine("<DataTypeTemplates>");
  			if(DataTypeTemplates.LNodeType != null && DataTypeTemplates.LNodeType.Length != 0)
  				ShowLNodeType(DataTypeTemplates.LNodeType);
  			if(DataTypeTemplates.DOType != null && DataTypeTemplates.DOType.Length != 0)
  				ShowDOType(DataTypeTemplates.DOType);
  			if(DataTypeTemplates.DAType != null && DataTypeTemplates.DAType.Length != 0)
  				ShowDAType(DataTypeTemplates.DAType);			
  			if(DataTypeTemplates.EnumType != null && DataTypeTemplates.EnumType.Length != 0)
  				ShowEnumType(DataTypeTemplates.EnumType);
  		}
  		 
   		/// <summary>
   		/// This method displays the values of tDOType's class.
   		/// </summary>
   		/// <param name="DOType">
   		/// Values of tDOType's class that will be displayed.
   		/// </param>
   		private void ShowDOType(tDOType[] DOType)
  		{  		
   			for(int x = 0; x < DOType.Length; x++)
   			{   				
   				System.Console.WriteLine("DOType (Tipo DO)");	  				
  				System.Console.WriteLine("iedType = {0} cdc = {1}", DOType[x].iedType, DOType[x].cdc);
  				if(DOType[x].Items != null && DOType[x].Items.Length != 0)
  					ShowtBaseElementSDODA(DOType[x].Items);
  				ShowIDNaming(DOType[x]);
   			}
  		}
  		   		
   		/// <summary>
   		/// This method displays the values of tDOType's class.
   		/// </summary>
   		/// <param name="Items">
   		/// Values of tDOType's class that will be displayed.
   		/// </param>
   		private void ShowtBaseElementSDODA(tBaseElement[] Items)
  		{  		
   			for(int x = 0; x < Items.Length; x++)
   			{   				   				   			
   			    //An object "Type" is obtained to determine what kind of element is, 
   			    //tSDI or tDAI   				
   				Type vtype = (Items[x]).GetType();   			
   				if(vtype.Name.Equals("tSDO"))
   				{   					
   					//The "tSDO" class is obtained using polymorphism
   					tSDO SDO = (tSDO) Items[x];
   					ShowSDO(SDO);
   					
   				}
   				else if(vtype.Name.Equals("tDA"))
   				{
   					//The "tDA" class is obtained using polymorphism
   					tDA DA= (tDA) Items[x];
   					ShowDA(DA);
   				}
   				else{
					System.Console.WriteLine("\tVerifiy the conditions of the method ShowtBaseElementSDODA");
   				}
   			}  	
  		}
  		
   		/// <summary>
   		/// This method displays the values of tSDO's class.
   		/// </summary>
   		/// <param name="SDO">
   		/// Values of tSDO's class that will be displayed.
   		/// </param>
   		private void ShowSDO(tSDO SDO)
  		{  		
   			System.Console.WriteLine("<SDO>");   			
   			System.Console.WriteLine("SDO type = {0}", SDO.type);	  				
   			ShowNaming(SDO);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDA's class.
   		/// </summary>
   		/// <param name="DA">
   		/// Values of tDA's class that will be displayed.
   		/// </param>
   		private void ShowDA(tDA DA)
  		{  		
   			System.Console.WriteLine("<DA>");   			
   			System.Console.WriteLine(" dchg = {0} qchg = {1} dupd = {2} fc = {3}", DA.dchg, DA.qchg, DA.dupd, DA.fc);	  				
   			ShowAbstractDataAttribute(DA);
   		}
   		   		
   		/// <summary>
   		/// This method displays the values of tAbstractDataAttribute's class.
   		/// </summary>
   		/// <param name="AtributoDatoAbstracto">
   		/// Values of tAbstractDataAttribute's class that will be displayed.
   		/// </param>
   		private void ShowAbstractDataAttribute(tAbstractDataAttribute AtributoDatoAbstracto)
  		{  	   			
   			System.Console.WriteLine("-> AbstractDataAttribute");
   			System.Console.WriteLine(" name = {0} sAddr = {1} bType = {2} valKind = {3} type = {4} count = {5}", AtributoDatoAbstracto.name, AtributoDatoAbstracto.sAddr, AtributoDatoAbstracto.bType, AtributoDatoAbstracto.valKind, AtributoDatoAbstracto.type, AtributoDatoAbstracto.count);	  				
   			if(AtributoDatoAbstracto.Val != null && AtributoDatoAbstracto.Val.Length != 0)
   				ShowVal(AtributoDatoAbstracto.Val);
   			ShowUnNaming(AtributoDatoAbstracto);
   		}
   			
   		/// <summary>
   		/// This method displays the values of tLNodeType's class.
   		/// </summary>
   		/// <param name="NodeType">
   		/// Values of tLNodeType's class that will be displayed.
   		/// </param>
   		private void ShowLNodeType(tLNodeType[] NodeType)
  		{  	  			
   			for(int x = 0; x < NodeType.Length; x++)
   			{
   				System.Console.WriteLine("<NodeType> ");	   			
  				System.Console.WriteLine("iedType = {0} lnClass = {1}", NodeType[x].iedType, NodeType[x].lnClass);
  				if(NodeType[x].DO != null && NodeType[x].DO.Length != 0)
  					ShowDO(NodeType[x].DO);
  				ShowIDNaming(NodeType[x]); 
   			}
  		}  		
  		
   		/// <summary>
   		/// This method displays the values of tDO's class.
   		/// </summary>
   		/// <param name="DOs">
   		/// Values of tDO's class that will be displayed.
   		/// </param>
   		private void ShowDO(tDO[] DOs)
  		{  		
   			System.Console.WriteLine("<DO>");	   				
   			for(int x = 0; x < DOs.Length; x++)
   			{   				
   				System.Console.WriteLine(" #{0} name = {1}, type = {2}, accessControl = {3}, transient = {4}", x, DOs[x].name, DOs[x].type, DOs[x].accessControl, DOs[x].transient);
   				ShowUnNaming(DOs[x]);
   			}
  		}  		
   		
   		/// <summary>
   		/// This method displays the values of tIDNaming's class.
   		/// </summary>
   		/// <param name="IDNaming">
   		/// Values of tIDNaming's class that will be displayed.
   		/// </param>
   		private void ShowIDNaming(tIDNaming IDNaming)
  		{ 
   			System.Console.WriteLine("->IDNaming");
   			System.Console.WriteLine(" tid = {0}, desc = {1}", IDNaming.id, IDNaming.desc);	   			
   			ShowBaseElement(IDNaming);
  		}  		
   		   		
   		/// <summary>
   		/// This method displays the values of tDAType's class.
   		/// </summary>
   		/// <param name="DATypes">
   		/// Values of tDAType's class that will be displayed.
   		/// </param>
   		private void ShowDAType(tDAType[] DATypes)
  		{  	  			
   			System.Console.WriteLine("<DATypes>");
   			for(int x = 0; x < DATypes.Length; x++)
   			{   				
   				System.Console.WriteLine("iedType = {0}", DATypes[x].iedType);
   				ShowBDA(DATypes[x].BDA);
   				ShowIDNaming(DATypes[x]);
   			}   				
  		}
   		
   		/// <summary>
   		/// This method displays the values of tBDA's class.
   		/// </summary>
   		/// <param name="BDAs">
   		/// Values of tBDA's class that will be displayed.
   		/// </param>
   		private void ShowBDA(tBDA[] BDAs)
  		{  	  			
   			System.Console.WriteLine("BDA");
   			for(int x = 0; x < BDAs.Length; x++)
   			{   				
   				ShowAbstractDataAttribute(BDAs[x]);
   			}   				
  		}
   		
   		/// <summary>
   		/// This method displays the values of tEnumType's class.
   		/// </summary>
   		/// <param name="EnumTypes">
   		/// Values of tEnumType's class that will be displayed.
   		/// </param>
   		private void ShowEnumType(tEnumType[] EnumTypes)
  		{  	  	
   			System.Console.WriteLine("<EnumType>");
   			for(int x = 0; x < EnumTypes.Length; x++)
   			{      				
   				if(EnumTypes[x].EnumVal != null && EnumTypes[x].EnumVal.Length != 0)
   					ShowEnumVal(EnumTypes[x].EnumVal);
   				ShowIDNaming(EnumTypes[x]);
   			}   				
  		}
   			   		
   		/// <summary>
   		/// This method displays the values of tEnumVal's class.
   		/// </summary>
   		/// <param name="EnumVals">
   		/// Values of tEnumVal's class that will be displayed.
   		/// </param>
   		private void ShowEnumVal(tEnumVal[] EnumVals)
  		{  	  	
   			System.Console.WriteLine("<EnumVal>");
   			for(int x = 0; x < EnumVals.Length; x++)
   			{   				
   				System.Console.WriteLine("ord = {0}", EnumVals[x].ord);  				
   			}   				
  		}
   		   		
   		/// <summary>
   		/// This method displays the values of tBaseElement's class.
   		/// </summary>
   		/// <param name="BaseElement">
   		/// Values of tBaseElement's class that will be displayed.
   		/// </param>
   		private void ShowBaseElement(tBaseElement BaseElement)
  		{  	  	
   			System.Console.WriteLine("->BaseElement");
   			if(BaseElement.Any != null)
   				System.Console.WriteLine("Any = {0}",BaseElement.Any);
   			if(BaseElement.Text != null)
   				ShowText(BaseElement.Text);
   			if(BaseElement.Private != null && BaseElement.Private.Length != 0)
   				ShowPrivate(BaseElement.Private);
  		}
   		
   		/// <summary>
   		/// This method displays the values of tText's class.
   		/// </summary>
   		/// <param name="Text">
   		/// Values of tText's class that will be displayed.
   		/// </param>
   		private void ShowText(tText Text)
  		{  	  	  			   			
   			System.Console.WriteLine("\n<Text>");
   			System.Console.WriteLine("\tsource = {0} anyAttribute = {1}", Text.source, Text.AnyAttr);
   			ShowAnyContentFromOtherNamespace(Text);
  		}
   		
   		/// <summary>
   		/// This method displays the values of tAnyContentFromOtherNamespace's class.
   		/// </summary>
   		/// <param name="AnyContentFromOtherNamespace">
   		/// Values of tAnyContentFromOtherNamespace's class that will be displayed.
   		/// </param>
   		private void ShowAnyContentFromOtherNamespace(tAnyContentFromOtherNamespace AnyContentFromOtherNamespace)
   		{		
   			System.Console.WriteLine("->AnyContentFromOtherNamespace");
   			for(int x = 0; AnyContentFromOtherNamespace.AnyAttr !=null && x < AnyContentFromOtherNamespace.AnyAttr.Length; x++)
   			{
   				System.Console.WriteLine("\tAnyAttribute = {0}", AnyContentFromOtherNamespace.AnyAttr[x].Value);
   			}
   			
   			for(int x = 0; AnyContentFromOtherNamespace.Any !=null && x < AnyContentFromOtherNamespace.Any.Length; x++)
   			{
   				System.Console.WriteLine("\tAny = {0}", AnyContentFromOtherNamespace.Any[x].Value);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPrivate's class.
   		/// </summary>
   		/// <param name="Privates">
   		/// Values of tPrivate's class that will be displayed.
   		/// </param>
   		private void ShowPrivate(tPrivate[] Privates)
  		{  	  	   			
   			for(int x =0; x < Privates.Length; x++)
   			{
   				System.Console.WriteLine("<Private>");   				
   				System.Console.WriteLine("\ttype = {0} source = {1}", Privates[x].type, Privates[x].source);
   				ShowAnyContentFromOtherNamespace(Privates[x]);
   			}
   				
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
				string first_parameter = null;
				System.Console.Write("command: ");
				string command_all = System.Console.ReadLine();
				string[] command_split = command_all.Split (separator, StringSplitOptions.None);
				string command = command_split[0];
				if(command_split.Length > 1) {
					first_parameter = command_split[1];
				}
				
				switch (command) {
					case "open":
					{
						System.Console.WriteLine("Write path to file type SCD, CID or ICD:");
						string FileName = System.Console.ReadLine();
						app.sclObject = new IED (FileName);
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
						if (first_parameter.Equals("ied")) {
							System.Console.WriteLine("Creating a Generic Configured IED Description (CID)...");
							// FIXME: This command doesn't work becouse object not initialized
							IED ied = new IED();
							System.Console.WriteLine("Write path to file for New GENERIC IED Configuration");
							System.Console.WriteLine("At the end of the filename will be added '.cid' extension");
							string FileName = System.Console.ReadLine();
							ied.Write(FileName+".cid");
							System.Console.WriteLine ("New Generic CID created with config version number: "+ied.configVersion);
						}
						
						if (first_parameter.Equals("substation")) {
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
						System.Console.WriteLine("Write path to file type CID or ICD:");
						string FileName = System.Console.ReadLine();
						IED ied = new IED(FileName);
						app.ShowAll(ied);
						break;
					}				
					case "exit":
					{
						run = false;
						break;
					}
					case "show":
					{
						if(first_parameter.Equals("header")) {
							app.ShowHeader(app.sclObject.Configuration.Header);
						}
						if(first_parameter.Equals("communication")) {
							app.ShowCommunication(app.sclObject.Configuration.Communication);
						}
						if(first_parameter.Equals("devices")) {
							app.ShowDevices(app.sclObject.Configuration.IED);
						}
						break;
					}
				}
			}
		}
	}
}
