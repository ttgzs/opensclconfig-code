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
using LibOpenSCL;

namespace OpenSCL
{
	class ConsoleSCL
	{		
   		/// <summary>
   		/// This method is used to deserialize a XML file.
   		/// </summary>
   		/// <param name="XMLFileName">
   		/// Name of XML file to deserialize
   		/// </param>
   		/// <returns>
   		/// XMLobject contains information of all SCL the classes according to 
   		/// XML File
   		/// </returns>
   		private SCL deserialize(string XMLFileName)
		{			 
			XmlSerializer serializer = new XmlSerializer(typeof(SCL));
    	    serializer.UnknownNode+= new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute+= new XmlAttributeEventHandler(serializer_UnknownAttribute);        
        	FileStream fs = new FileStream(XMLFileName, FileMode.Open);
            SCL XMLobject =(SCL) serializer.Deserialize(fs);        
            showXmlDeserializado(XMLobject);
            return XMLobject;
		}
   		
   		/// <summary>
   		/// This method displays all data from the XML File 
   		/// </summary>   		
   		/// <param name="XMLobject">
   		/// It contains the data of deserialization of the XML File 
   		/// Español: Es el objeto que se creo de la deserialización del archivo XML
   		/// </param>
   		private void showXmlDeserializado(SCL XMLobject)
   		{
   			Console.WriteLine("--------------------------------------------------------------------------------");
   			Console.WriteLine("\t\t\t\tXML File");
   			showBaseElement(XMLobject);
   			if(XMLobject.Header!=null)
   			{
   				Console.WriteLine("\n<<Header >>");
   				ShowHeader(XMLobject.Header);
   				showMessagePushButton();
   			}  			   			
   			if(XMLobject.Substation!=null&&XMLobject.Substation.Length!=0)
   			{
   				Console.WriteLine("\n\n<<Substation>>");
   				ShowSubstation(XMLobject.Substation);
   				showMessagePushButton();
   			}   				
   			if(XMLobject.Communication!=null)
   			{
   				Console.WriteLine("\n\n<<Communication>>");
   				showCommunication(XMLobject.Communication);
   				showMessagePushButton();
   			}   			
   			if(XMLobject.IED!=null&&XMLobject.IED.Length!=0)
   			{
   				Console.WriteLine("\n\n<<IEDs>>"); 
   				showIED(XMLobject.IED);
   				showMessagePushButton();
   			}
   			if(XMLobject.DataTypeTemplates != null)
   			{
   				Console.WriteLine("\n\n<<DataTypeTemplates>>"); 
   				showDataTypeTemplates(XMLobject.DataTypeTemplates);
   				showMessagePushButton();
   			}
   		}
   		
   		/// <summary>
   		/// This method show a message about press a key
   		/// </summary>
   		private void showMessagePushButton()
   		{
   			Console.Write("\nPress any key to continue. . . ");
			Console.ReadKey(true);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tHeader's class. This class contains
   		/// the header of the XML File.
   		/// </summary>
   		/// <param name="Header">
   		/// Values of tHeader's class that will be displayed
   		/// </param>
   		private void ShowHeader(tHeader Header)
   		{ 			
   			Console.WriteLine(" id = {0} \n version = {1} \n revision = {2} \n toolID = {3} \n " +
                              "nameStructure = {4} ", Header.id, Header.version, Header.revision, 
                              Header.toolID, Header.nameStructure);          			         	
            if(Header.Text!=null)
            {
            	showText(Header.Text);
            }               
            showMessagePushButton();               
            if(Header.History!=null && Header.History.Length!=0)
            	showHistory(Header.History);    
   		}
   		
   		/// <summary>
   		/// This method displays the values of tHitem's class. This class 
   		/// contains the history of the XML File.
   		/// </summary>
   		/// <param name="History">
   		/// Values of tHitem's class that will be displayed
   		/// </param>
   		private void showHistory(tHitem[] History)
   		{            	
            Console.WriteLine("\n<History (Historial)>");
            	for(int x=0; x < History.Length; x++)
            	{
            	  Console.WriteLine("\t<Hitem> \n\t\t # {0} version = {1} revisión = {2} when = {3} " +
                        "who = {4} what = {5} why = {6}", x+1, History[x].version, History[x].revision, 
                        History[x].when, History[x].who, History[x].what, History[x].why);            
            		showAnyContentFromOtherNamespace(History[x]);
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
   			Console.WriteLine("<Substation>");
   			for(int x=0; x < Substations.Length; x++)
   			{  	   				   				   				
   				if(Substations[x].VoltageLevel!=null && Substations[x].VoltageLevel.Length!=0)
   					showVoltageLevel(Substations[x].VoltageLevel);   
   				if(Substations[x].Function!=null && Substations[x].Function.Length!=0)
   					showFunction(Substations[x].Function);
   				showEquipmentContainer(Substations[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tEquipmentContainer's class. 
   		/// </summary>
   		/// <param name="EquipmentContainer">
   		/// Values of tEquipmentContainer's class that will be displayed
   		/// </param>
   		private void showEquipmentContainer(tEquipmentContainer EquipmentContainer)
   		{   
   			Console.WriteLine("->EquipmentContainer");   
   			if(EquipmentContainer.AnyAttr != null)
   				Console.WriteLine(" anyAtribute = {0}", EquipmentContainer.AnyAttr);   			
   			if(EquipmentContainer.PowerTransformer!=null && EquipmentContainer.PowerTransformer.Length != 0)
   				showPowerTransformer(EquipmentContainer.PowerTransformer);
   			if(EquipmentContainer.GeneralEquipment!=null && EquipmentContainer.GeneralEquipment.Length != 0)
   				showGeneralEquipment(EquipmentContainer.GeneralEquipment);
   			showPowerSystemResource(EquipmentContainer);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPowerSystemResource's class.
   		/// </summary>
   		/// <param name="PowerSystemResource">
   		/// Values of tPowerSystemResource's class that will be displayed
   		/// </param>
   		private void showPowerSystemResource(tPowerSystemResource PowerSystemResource)
   		{   	
   			Console.WriteLine("->PowerSystemResource ");
   			showLNodeContainer(PowerSystemResource);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPowerTransformer's class.
   		/// </summary>
   		/// <param name="PowerTransformers">
   		/// Values of tPowerTransformer's class that will be displayed
   		/// </param>
   		private void showPowerTransformer(tPowerTransformer[] PowerTransformers)
   		{
   			Console.WriteLine("->PowerTransformer (Transformadores)");
   			for(int x=0; x < PowerTransformers.Length; x++)
   			{   				
   				Console.WriteLine("\ttype = {0} ", PowerTransformers[x].type);
   				if(PowerTransformers[x].TransformerWinding!=null&&PowerTransformers[x].TransformerWinding.Length!=0)
   					showTransformerWinding(PowerTransformers[x].TransformerWinding);
   				showEquipment(PowerTransformers[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tEquipment's class.
   		/// </summary>
   		/// <param name="Equipment">
   		/// Values of tEquipment's class that will be displayed
   		/// </param>
   		private void showEquipment(tEquipment Equipment)
   		{
   			Console.WriteLine("-> Equipment");
   			Console.WriteLine(" Equipment \n\t virtual = {0}", Equipment.@virtual);
   			showPowerSystemResource(Equipment);   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tTransformerWinding's class.
   		/// </summary>
   		/// <param name="TransformerWindings">
   		/// Values of tTransformerWinding's class that will be displayed
   		/// </param>
   		private void showTransformerWinding(tTransformerWinding[] TransformerWindings)
   		{
   			Console.WriteLine("<TransformerWinding >");
   			for(int x = 0; x < TransformerWindings.Length; x++)
   			{   				
   				Console.WriteLine("#{0} type = {1}",x, TransformerWindings[x].type);
   				if(TransformerWindings[x].AnyAttr != null)
   					Console.WriteLine("anyAttribute = {0}", TransformerWindings[x].AnyAttr);
   				if(TransformerWindings[x].TapChanger != null)
   				{
   					showTapChanger(TransformerWindings[x].TapChanger);
   					Console.WriteLine("\n\tTap Changer type = {0} ",TransformerWindings[x].TapChanger.type);
   				}   	  				
   				showAbstractConductingEquipment(TransformerWindings[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tTapChanger's class.
   		/// </summary>
   		/// <param name="TapChanger">
   		/// Values of tTapChanger's class that will be displayed
   		/// </param>
   		private void showTapChanger(tTapChanger TapChanger)
   		{   			
   			Console.WriteLine("<Tap Changer> \n\ttype = {0}, virtual = {1}",TapChanger.type, TapChanger.@virtual);    			
   			showPowerSystemResource(TapChanger);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAbstractConductingEquipment's 
   		/// class.
   		/// </summary>
   		/// <param name="AbstractConductingEquipment">
   		/// Values of tAbstractConductingEquipment's class that will be displayed
   		/// </param>
   		private void showAbstractConductingEquipment(tAbstractConductingEquipment AbstractConductingEquipment)
   		{   
   			Console.WriteLine("->AbstractConductingEquipment");
   			if(AbstractConductingEquipment.Terminal!=null && AbstractConductingEquipment.Terminal.Length!=0)
   			{
   				showTerminal(AbstractConductingEquipment.Terminal);
   			}
   			if(AbstractConductingEquipment.SubEquipment!= null && AbstractConductingEquipment.SubEquipment.Length!=0)
   			{
   				showSubEquipment(AbstractConductingEquipment.SubEquipment);
   			}
   			showEquipment(AbstractConductingEquipment);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tTerminal's class.
   		/// </summary>
   		/// <param name="Terminals">
   		/// Values of tTerminal's class that will be displayed
   		/// </param>
   		private void showTerminal(tTerminal[] Terminals)
   		{
   			Console.WriteLine("<Terminal >");
   			for(int x = 0; x < Terminals.Length; x++)
   			{   				
   				Console.WriteLine(" #{0} name = {1}  connectivityNode = {2} substationName = {3} voltageLevelName = {4} bayName = {5} cNodeName = {6}",x, Terminals[x].name, Terminals[x].connectivityNode, Terminals[x].substationName, Terminals[x].voltageLevelName, Terminals[x].bayName, Terminals[x].cNodeName);
   				showUnNaming(Terminals[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubEquipment's class.
   		/// </summary>
   		/// <param name="SubEquipments">
   		/// Values of tSubEquipment's class that will be displayed
   		/// </param>
   		private void showSubEquipment(tSubEquipment[] SubEquipments)
   		{
   			Console.WriteLine("<SubEquipment >");
   			for(int x = 0; x < SubEquipments.Length; x++)
   			{   				
   				Console.WriteLine("#{0} Phase = {1}",x, SubEquipments[x].phase);
   				showPowerSystemResource(SubEquipments[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGeneralEquipment's class.
   		/// </summary>
   		/// <param name="GeneralEquipments">
   		/// Values of tGeneralEquipment's class that will be displayed
   		/// </param>
   		private void showGeneralEquipment(tGeneralEquipment[] GeneralEquipments)
   		{
   			
   			Console.WriteLine("<GeneralEquipment> ");
   			for(int x = 0; x < GeneralEquipments.Length; x++)
   			{   				
   				Console.WriteLine(" #{0} type = {1}",x, GeneralEquipments[x].type);
   				showEquipment(GeneralEquipments[x]);
   			}
   		}
   				
   		/// <summary>
   		/// This method displays the values of tVoltageLevel's class.
   		/// </summary>
   		/// <param name="VoltageLevels">
   		/// Values of tVoltageLevel's class that will be displayed
   		/// </param>
   		private void showVoltageLevel(tVoltageLevel[] VoltageLevels)
   		{
   			Console.WriteLine("<VoltageLevel >");
   			for(int x = 0; x < VoltageLevels.Length; x++)
   			{   				
   				if(VoltageLevels[x].Voltage != null)
   					showVoltage(VoltageLevels[x].Voltage); 
   				if(VoltageLevels[x].Bay!=null && VoltageLevels[x].Bay.Length != 0)
   					showBay(VoltageLevels[x].Bay);
   				showEquipmentContainer(VoltageLevels[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tVoltage's class.
   		/// </summary>
   		/// <param name="Voltage">
   		/// Values of tVoltage's class that will be displayed
   		/// </param>
   		private void showVoltage(tVoltage Voltage)
   		{
   			Console.WriteLine("<Voltage>");
   			showValueWithUnit(Voltage);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tValueWithUnit's class. 
   		/// </summary>
   		/// <param name="ValueWithUnit">
   		/// Values of tValueWithUnit's class that will be displayed.
   		/// </param>
   		private void showValueWithUnit(tValueWithUnit ValueWithUnit)
   		{
   			Console.WriteLine("\t->ValueWithUnit");
   			Console.WriteLine("\tunit = {0}, multiplier = {1}", ValueWithUnit.unit, ValueWithUnit.multiplier);  
   		}
   		
   		/// <summary>
   		/// This method displays the values of tBay's class. 
   		/// </summary>
   		/// <param name="Bays">
   		/// Values of tBay's class that will be displayed.
   		/// </param>
   		private void showBay(tBay[] Bays)
   		{
   			Console.WriteLine("Bay ");
   			for(int x = 0; x < Bays.Length; x++)
   			{   	  				   				
   				if(Bays[x].ConductingEquipment !=null && Bays[x].ConductingEquipment.Length != 0)
   					showConductingEquipment(Bays[x].ConductingEquipment);
   				if(Bays[x].ConnectivityNode!=null && Bays[x].ConnectivityNode.Length != 0)
   					showConnectivityNode(Bays[x].ConnectivityNode);
   				showEquipmentContainer(Bays[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tConductingEquipment's class.
   		/// </summary>
   		/// <param name="EquiposConductores">
   		/// Values of tConductingEquipment's class that will be displayed.
   		/// </param>
   		private void showConductingEquipment(tConductingEquipment[] EquiposConductores)
   		{
   			Console.WriteLine("<ConductingEquipment> ");
   			for(int x = 0; x < EquiposConductores.Length; x++)
   			{   				   				
   				Console.WriteLine("#{0} type = {1} ", x, EquiposConductores[x].type);   				   				 			
   				showAbstractConductingEquipment(EquiposConductores[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tConnectivityNode's class.
   		/// </summary>
   		/// <param name="NodosConectividad">
   		/// Values of tConnectivityNode's class that will be displayed.
   		/// </param>
   		private void showConnectivityNode(tConnectivityNode[] NodosConectividad)
   		{
   			Console.WriteLine("<ConnectivityNode> ");
   			for(int x = 0; x < NodosConectividad.Length; x++)
   			{   				   				
   				Console.WriteLine(" #{0} pathName = {1} name = {2} desc = {3}", x, NodosConectividad[x].pathName, NodosConectividad[x].name, NodosConectividad[x].desc);   			
   				showLNodeContainer(NodosConectividad[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLNodeContainer's class.
   		/// </summary>
   		/// <param name="NodesContainer">
   		/// Values of tLNodeContainer's class that will be displayed.
   		/// </param>
   		private void showLNodeContainer(tLNodeContainer NodesContainer)
   		{
   			Console.WriteLine("->NodeContainer ");   			
   			if(NodesContainer.LNode!=null && NodesContainer.LNode.Length!=0)
   			{
   				showLNode(NodesContainer.LNode);
   			}   			
   			showNaming(NodesContainer);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tNaming's class.
   		/// </summary>
   		/// <param name="Naming">
   		///  Values of tNaming's class that will be displayed.
   		/// </param>
   		private void showNaming(tNaming Naming)
   		{     			
   			Console.WriteLine("->Naming");   			
   			Console.WriteLine("name = {0} desc = {1}", Naming.name, Naming.desc);   			
   			showBaseElement(Naming);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLNode's class.
   		/// </summary>
   		/// <param name="LNodes">
   		/// Values of tLNode's class that will be displayed.
   		/// </param>
   		private void showLNode(tLNode[] LNodes)
   		{
   			Console.WriteLine("<LNode >");
   			for(int x = 0; x < LNodes.Length; x++)
   			{   			   				
   				Console.WriteLine("  #{0} desc = {1} InInst = {2} InClass = {3} iedName = {4} IdInst = {5} prefix = {6} InType = {7} ", x, LNodes[x].desc, LNodes[x].lnInst, LNodes[x].lnClass, LNodes[x].iedName, LNodes[x].ldInst, LNodes[x].prefix, LNodes[x].lnType);  			 				
   				showUnNaming(LNodes[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tUnNaming's class.
   		/// </summary>
   		/// <param name="UnNaming">
   		/// Values of tUnNaming's class that will be displayed.
   		/// </param>
   		private void showUnNaming(tUnNaming UnNaming)
   		{   			
   			Console.WriteLine("->UnNaming \n\tdesc= {0} ", UnNaming.desc);
   			if(UnNaming.AnyAttr != null)
   				Console.WriteLine("\tanyAttribute = {0}", UnNaming.AnyAttr);
   			showBaseElement(UnNaming);  		
   		}
   		
   		/// <summary>
   		/// This method displays the values of tFunction's class.
   		/// </summary>
   		/// <param name="Function">
   		/// Values of tFunction's class that will be displayed.
   		/// </param>
   		private void showFunction(tFunction[] Function)
   		{
   		 	Console.WriteLine("<Function>)");
   			for(int x = 0; x < Function.Length; x++)
   			{      				
   				if(Function[x].SubFunction != null && Function[x].SubFunction.Length !=0 )
	   				showSubFunction(Function[x].SubFunction);
   				if(Function[x].GeneralEquipment != null && Function[x].GeneralEquipment.Length !=0 )
   					showGeneralEquipment(Function[x].GeneralEquipment);
   				showPowerSystemResource(Function[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubFunction's class.
   		/// </summary>
   		/// <param name="SubFunctions">
   		/// Values of tSubFunction's class that will be displayed.
   		/// </param>
   		private void showSubFunction(tSubFunction[] SubFunctions)
   		{
   			Console.WriteLine("<SubFunction>");
   			for(int x = 0; x < SubFunctions.Length; x++)
   			{   				
   				if(SubFunctions[x].GeneralEquipment != null && SubFunctions[x].GeneralEquipment.Length !=0 )
   					showGeneralEquipment(SubFunctions[x].GeneralEquipment);
   				showPowerSystemResource(SubFunctions[x]);
   			}   			
   		}   		
   		
   		/// <summary>
   		/// This method displays the values of tCommunication's class.
   		/// </summary>
   		/// <param name="Communication">
   		/// Values of tCommunication's class that will be displayed.
   		/// </param>
   		private void showCommunication(tCommunication Communication)
   		{   			
   			showUnNaming(Communication);
   			showSubNetwork(Communication.SubNetwork);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSubNetwork's class.
   		/// </summary>
   		/// <param name="SubNetworks">
   		/// Values of tSubNetwork's class that will be displayed.
   		/// </param>
   		private void showSubNetwork(tSubNetwork[] SubNetworks)
   		{
   			Console.WriteLine("<SubNetwork> ");   			
   			for(int x=0; x < SubNetworks.Length; x++)
   			{  				   				
   				if(SubNetworks[x].BitRate!=null)   				
   					showBitRateInMbPerSec(SubNetworks[x].BitRate);
   				if(SubNetworks[x].ConnectedAP != null && SubNetworks[x].ConnectedAP.Length != 0)
   					showConnectedAP(SubNetworks[x].ConnectedAP);
   				showNaming(SubNetworks[x]);
   			}  			
   		}
   		  		
   		/// <summary>
   		/// This method displays the values of tBitRateInMbPerSec's class.
   		/// </summary>
   		/// <param name="BitRateInMbPerSec">
   		/// Values of tBitRateInMbPerSec's class that will be displayed.
   		/// </param>
   		public void showBitRateInMbPerSec(tBitRateInMbPerSec BitRateInMbPerSec)
   		{
   			Console.WriteLine("->BitRateInMbPerSec");
   			showValueWithUnit(BitRateInMbPerSec);
   		}  		
   		   		
   		/// <summary>
   		/// This method displays the values of tConnectedAP's class.
   		/// </summary>
   		/// <param name="ConexionAP">
   		/// Values of tConnectedAP's class that will be displayed.
   		/// </param>
   		private void showConnectedAP(tConnectedAP[] ConexionAP)
   		{
   			Console.WriteLine("<ConnectedAP> ");
   			for(int x = 0;  x < ConexionAP.Length; x++)
   				{   					
	   				Console.WriteLine("\n iedName = {0} \n apName = {1}", ConexionAP[x].iedName, ConexionAP[x].apName);
	   				if(ConexionAP[x].Address != null && ConexionAP[x].Address.Length !=0 )
	   					showAddress(ConexionAP[x].Address); 
	   				if(ConexionAP[x].GSE != null && ConexionAP[x].GSE.Length != 0)
	   					showGSE(ConexionAP[x].GSE);
	   				if(ConexionAP[x].SMV != null && ConexionAP[x].SMV.Length != 0 )	   				
	   					showSMV(ConexionAP[x].SMV );
	   				if(ConexionAP[x].PhysConn != null && ConexionAP[x].PhysConn.Length != 0)
	   					showPhysConn(ConexionAP[x].PhysConn);
	   				showUnNaming(ConexionAP[x]);
   				}  			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tP's class.
   		/// </summary>
   		/// <param name="Address">
   		/// Values of tP's class that will be displayed.
   		/// </param>
   		private void showAddress(tP[] Address)
   		{
   			Console.WriteLine("<Address >");
   			for(int x = 0;  x < Address.Length; x++)
   			{
   				Console.WriteLine(" #{0} type = {1}", x, Address[x].type);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGSE's class.
   		/// </summary>
   		/// <param name="GSEs">
   		/// Values of tGSE's class that will be displayed.
   		/// </param>
   		private void showGSE(tGSE[] GSEs)
   		{
   			Console.WriteLine("<GSE>");
   			for(int x = 0;  x < GSEs.Length; x++)
   			{   				
   				if(GSEs[x].MinTime != null)
   					showDurationInMilliSec(GSEs[x].MinTime);
   				if(GSEs[x].MaxTime != null)   	
   					showDurationInMilliSec(GSEs[x].MaxTime);
   				showControlBlock(GSEs[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDurationInMilliSec's class.
   		/// </summary>
   		/// <param name="DurationInMilliSec">
   		/// Values of tDurationInMilliSec's class that will be displayed.
   		/// </param>
   		public void showDurationInMilliSec(tDurationInMilliSec DurationInMilliSec)
   		{   
   			Console.WriteLine("<DurationInMilliSec>");
   			Console.WriteLine(" MinTime unit = {0} multiplier = {1}", DurationInMilliSec.unit, DurationInMilliSec.multiplier);
   			showValueWithUnit(DurationInMilliSec);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tControlBlock's class.
   		/// </summary>
   		/// <param name="ControlBlock">
   		/// Values of tControlBlock's class that will be displayed.
   		/// </param>
   		public void showControlBlock(tControlBlock ControlBlock)
   		{   			
   			Console.WriteLine("->ControlBlock");
   			Console.WriteLine(" IdInst = {0} cbName = {1}", ControlBlock.ldInst, ControlBlock.cbName);
   			if(ControlBlock.Address!=null && ControlBlock.Address.Length != 0)
   			{
   				showAddress(ControlBlock.Address);
   			}
   			showUnNaming(ControlBlock);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSMV's class.
   		/// </summary>
   		/// <param name="SMVs">
   		/// Values of tSMV's class that will be displayed.
   		/// </param>
   		private void showSMV(tSMV[] SMVs)
   		{
   			Console.WriteLine("<SMV>");
   			for(int x = 0; x < SMVs.Length; x++)
   			{
   				showControlBlock(SMVs[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPhysConn's class.
   		/// </summary>
   		/// <param name="ConexionesFisicas">
   		/// Values of tPhysConn's class that will be displayed.
   		/// </param>
   		private void showPhysConn(tPhysConn[] ConexionesFisicas)
   		{
   			Console.WriteLine("<PhysConn> ");
   			for(int x = 0; x < ConexionesFisicas.Length; x++)
   			{
   				showP(ConexionesFisicas[x].P);
   			}
   		}
   		  
   		/// <summary>
   		/// This method displays the values of tP's class.
   		/// </summary>
   		/// <param name="P">
   		/// Values of tP's class that will be displayed.
   		/// </param>
   		private void showP(tP[] P)
   		{
	   		Console.WriteLine("<P>");
	   		for(int x = 0; x < P.Length; x++)
	   		{	
	   			Console.WriteLine(" P = {0} ", P[x].type);
	   		}
   		}
   		   		  
   		/// <summary>
   		/// This method displays the values of tIED's class.
   		/// </summary>
   		/// <param name="IEDs">
   		/// Values of tIED's class that will be displayed.
   		/// </param>
   		private void showIED(tIED[] IEDs)
   		{   			
   			for(int x = 0; x < IEDs.Length; x++)
   			{   				
   				Console.WriteLine("\n <IED> {0} \n type = {1} \n manufacturer = {2} \n configVersion = {3}", x, IEDs[x].type, IEDs[x].manufacturer, IEDs[x].configVersion);    				
   				Console.WriteLine("\n NOTE: Attibutes of type boolean should be created for class tServiceYesNo ");     		  				
   				showServices(IEDs[x].Services);   				
   				if(IEDs[x].AccessPoint!=null&&IEDs[x].AccessPoint.Length!=0)
   					showAccesPoints(IEDs[x].AccessPoint); 
   				showNaming(IEDs[x]);
   			}   			
   		}
   		 
   		/// <summary>
   		/// This method displays the values of tServices's class.
   		/// </summary>
   		/// <param name="Services">
   		/// Values of tServices's class that will be displayed.
   		/// </param>
   		public void showServices(tServices Services)
   		{
   			Console.WriteLine("\n <Services> \n DynaAssociation = {0} ",Services.DynAssociation);
   			if(Services.SettingGroups != null)
   				Console.WriteLine("\n SettingGroups \n\t SGEdit = {0} \n\t ConfSG = {1}",Services.SettingGroups.SGEdit, Services.SettingGroups.ConfSG);
   			Console.WriteLine("\n GetDirectory = {0} \n GetDataObjectDefinition = {1} \n DataObjectDirectory = {2} \n SetDataSetValue = {3}",Services.GetDirectory, Services.GetDataObjectDefinition, Services.GetDataSetValue, Services.SetDataSetValue);
   			Console.WriteLine("\n DataSetDirectory = {0} \n",Services.DataSetDirectory);   				
   			if(Services.ConfDataSet != null)
   				Console.WriteLine(" ConfDataSet \n\t max = {0} maxAttributes = {1} \n\t modify = {2} ", Services.ConfDataSet.max, Services.ConfDataSet.maxAttributes, Services.ConfDataSet.modify);
   			if(Services.DynDataSet != null)
   				Console.WriteLine("\n DyDataSet \n\t max = {0} \n\t maxAttributes = {1}", Services.DynDataSet.max, Services.DynDataSet.maxAttributes);
   			Console.WriteLine("\n ReadWrite = {0} \n TimerActivatedControl = {1}", Services.ReadWrite, Services.TimerActivatedControl);
   			if(Services.ConfReportControl != null)
   				Console.WriteLine("\n ConfReportControl max = {0} ",Services.ConfReportControl.max);
   			Console.WriteLine("\n GetCBValues = {0} \n ",Services.GetCBValues);
   			if(Services.ConfLogControl != null)
   				Console.WriteLine("\n ConfLogControl max = {0} ",  Services.ConfLogControl.max);
   			if(Services.ReportSettings != null)
   			{
   				Console.WriteLine("\n ReportSettings\n\t  cbName = {0} \n\t datSet = {1} \n\t  rptID = {2} \n\t optFields = {3} \n\t bufTime = {4} " +
   					"\n\t trgOps = {5} \n\t  intgPd = {6}", Services.ReportSettings.cbName, Services.ReportSettings.datSet, Services.ReportSettings.rptID, Services.ReportSettings.optFields, Services.ReportSettings.bufTime, Services.ReportSettings.trgOps, Services.ReportSettings.intgPd);
   			}
   			if(Services.LogSettings != null)
   				Console.WriteLine("\n LogSettings \n\t cbName = {0} \n\t datSet = {1} \n\t logEna = {2} \n\t  trgOps = {3} \n\t  intgPd = {4} ", Services.LogSettings.cbName, Services.LogSettings.datSet, Services.LogSettings.logEna, Services.LogSettings.trgOps, Services.LogSettings.intgPd);
   					                                    
   			if(Services.GSESettings != null)	
   				Console.WriteLine("\n GSESettings \n\t cbName = {0} \n\t datSet = {1} \n\tappID = {2} \n\t dataLabel = {3} \n ", Services.GSESettings.cbName, Services.GSESettings.datSet, Services.GSESettings.appID, Services.GSESettings.dataLabel);
   			if(Services.SMVSettings != null)
   				Console.WriteLine("SMVSettings \n\t cbName = {0}\n\t datSet = {1} \n\t svID = {2}\n\t optFields = {3}\n\t smpRate = {4} \n ", Services.SMVSettings.cbName, Services.SMVSettings.datSet, Services.SMVSettings.svID, Services.SMVSettings.optFields, Services.SMVSettings.smpRate);
   			Console.WriteLine("GSEDir = {0} \n ", Services.GSEDir);
   			if(Services.GOOSE != null)
   				Console.WriteLine("GOOSE \n\t max = {0}\n\t client = {1}", Services.GOOSE.max, Services.GOOSE.client);
   			if(Services.GSSE != null)
   				Console.WriteLine("\n GSSE \n\t max = {0} \n\t client = {1}", Services.GSSE.max, Services.GSSE.client);
   			if(Services.ConfLNs != null)
   				Console.WriteLine("\n ConfLNs \n\t fixPrefix = {0} fixLnInst =  {1}", Services.ConfLNs.fixPrefix, Services.ConfLNs.fixLnInst);   				
   				
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAccessPoint's class.
   		/// </summary>
   		/// <param name="AccessPoint">
   		/// Values of tAccessPoint's class that will be displayed.
   		/// </param>
   		private void showAccesPoints(tAccessPoint[] AccessPoint)
   		{
   			Console.WriteLine("\n <AccessPoint>");
   			for(int x = 0; x < AccessPoint.Length; x++)
   			{   				
   				Console.WriteLine("\t{0}.- router = {1} clock = {2}", x, AccessPoint[x].router, AccessPoint[x].clock);
   				if(AccessPoint[x].Items != null && AccessPoint[x].Items.Length != 0)
   					showUnNamigServerLN(AccessPoint[x].Items); 
   				showNaming(AccessPoint[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tUnNaming's class.
   		/// </summary>
   		/// <param name="Items">
   		/// Values of tUnNaming's class that will be displayed.
   		/// </param>
   		private void showUnNamigServerLN(tUnNaming[] Items)   		
		{
   			for(int x = 0; x < Items.Length; x++)
   			{   				
   				Console.WriteLine("\n Server = {0}", x);   			
   			    //An object "Type" is obtained to determine what kind of element 
   			    //is, tServer or tLN   			   
   				Type vtype = (Items[x]).GetType();   			
   				if(vtype.Name.Equals("tServer"))
   				{   									
   					// The "tServer" class is obtained from "tUnNaming" class 
   					// using polymorphism
   					tUnNaming  Item = Items[x];
   					tServer Servidor = (tServer) Item;
   					showServer(Servidor);	
   				}
   				else if(vtype.Name.Equals("tLN"))
   				{
   					tUnNaming  Item = Items[x];
   					tLN LN = (tLN ) Item;
   					showLN(LN);
   				}
   				else{
					Console.WriteLine("\tVerify the conditions of the method showUnNamig");
   				}
   			}  			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tServer's class.
   		/// </summary>
   		/// <param name="Server">
   		/// Values of tServer's class that will be displayed.
   		/// </param>
   		private void showServer(tServer Server)
   		{
   			Console.WriteLine("<Server>");   					
   			if(Server.Authentication != null)
   				showAuthentication(Server.Authentication);   			
   			if(Server.LDevice != null && Server.LDevice.Length != 0)
   				showLDevice(Server.LDevice); 
   			if(Server.Association != null && Server.Association.Length != 0)
   				showAssociation(Server.Association);   			
   			showUnNaming(Server);   	
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAssociation's class.
   		/// </summary>
   		/// <param name="Association">
   		/// Values of tAssociation's class that will be displayed.
   		/// </param>
   		public void showAssociation(tAssociation[] Association)
   		{
   			Console.WriteLine("<Association>");
   			Console.WriteLine(" Verify if the attributes iedName and ldInst are showed in the class tAssociation");
   			for(int x=0; x < Association.Length; x++)
   			{
   				Console.WriteLine("	\t kind = {0}, associationID = {1}, iedName = {2}, ldInst = {3}, prefix = {4}, lnClass = {5}, lnInst = {6}", Association[x].kind,
   				                  Association[x].associationID, Association[x].iedName, Association[x].lnInst,  Association[x].prefix, Association[x].lnClass, Association[x].lnInst);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tServerAuthentication's class.
   		/// </summary>
   		/// <param name="ServerAuthentication">
   		/// Values of tServerAuthentication's class that will be displayed.
   		/// </param>
   		public void showAuthentication(tServerAuthentication ServerAuthentication)
   		{
   			Console.WriteLine("<Authentication>");
   			Console.WriteLine("\tnone = {0} password {1} weak = {2} strong = {3} certificate = {4}", ServerAuthentication.none, ServerAuthentication.password, ServerAuthentication.weak, ServerAuthentication.strong, ServerAuthentication.certificate);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLN's class.
   		/// </summary>
   		/// <param name="LN">
   		/// Values of tLN's class that will be displayed.
   		/// </param>
   		private void showLN(tLN LN)
   		{
   			Console.WriteLine("<LN>");
   			Console.WriteLine(" lnClass = {0}, inst = {1}, prefix = {2}",LN.lnClass, LN.inst, LN.prefix);
   			showAnyLN(LN);
   		}   		
   		
  		/// <summary>
   		/// This method displays the values of tAnyLN's class.
   		/// </summary>
   		/// <param name="AnyLN">
   		/// Values of tAnyLN's class that will be displayed.
   		/// </param>
   		private void showAnyLN(tAnyLN AnyLN)
   		{  	   			
   			Console.WriteLine("-> AnyLN");
   			Console.WriteLine("	lnType = {0}", AnyLN.lnType);
   			if(AnyLN.DataSet != null && AnyLN.DataSet.Length != 0)
   				showDateSet(AnyLN.DataSet);
   			if(AnyLN.ReportControl != null && AnyLN.ReportControl.Length != 0)
   				showReportControl(AnyLN.ReportControl);
   			if(AnyLN.LogControl != null && AnyLN.LogControl.Length != 0)
   				showLogControl(AnyLN.LogControl);
   			if(AnyLN.DOI != null && AnyLN.DOI.Length != 0)
   				showDOI(AnyLN.DOI);   
   			if(AnyLN.Inputs != null)
   				showInputs(AnyLN.Inputs);
   			showUnNaming(AnyLN);
   		}   				
   		
   		/// <summary>
   		/// This method displays the values of tInputs's class.
   		/// </summary>
   		/// <param name="Inputs">
   		/// Values of tInputs's class that will be displayed.
   		/// </param>
   		private void showInputs(tInputs Inputs)
   		{  			   			
   			Console.WriteLine("<Inputs> ");   			
   			if(Inputs.ExtRef != null && Inputs.ExtRef.Length != 0)
   				showExtRef(Inputs.ExtRef);
   			showUnNaming(Inputs);
   			
   		}

   		/// <summary>
   		/// This method displays the values of tExtRef's class.
   		/// </summary>
   		/// <param name="ExtRefs">
   		/// Values of tExtRef's class that will be displayed.
   		/// </param>
   		public void showExtRef(tExtRef[] ExtRefs)
   		{
   			Console.WriteLine("<ExtRefs>");
   			for(int x = 0 ; x < ExtRefs.Length; x++)
   			{   		   				   				
   				Console.WriteLine(" #{0} iedName = {1} ldInst = {2} prefix = {3} lnClass = {4} lnInst = {5} doName = {6} daName = {7} intAddr = {8}",x, ExtRefs[x].iedName, ExtRefs[x].ldInst, ExtRefs[x].prefix, ExtRefs[x].lnClass, ExtRefs[x].lnInst, ExtRefs[x].doName, ExtRefs[x].daName, ExtRefs[x].intAddr);   				
   			}   			
   		}
   		  		
   		/// <summary>
   		/// This method displays the values of tDOI's class.
   		/// </summary>
   		/// <param name="DOIs">
   		/// Values of tDOI's class that will be displayed.
   		/// </param>
   		private void showDOI(tDOI[] DOIs)
   		{  			   			
   			Console.WriteLine("<DOI> ");
   			for(int x = 0 ; x < DOIs.Length; x++)
   			{     				
   				Console.WriteLine(" #{0} name = {1} ix = {2} accessControl = {3}",x, DOIs[x].name, DOIs[x].ix, DOIs[x].accessControl);   				
   				if(DOIs[x].Items != null && DOIs[x].Items.Length != 0)
   					showUnNamigSDI_DAI(DOIs[x].Items);
   				showUnNaming(DOIs[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDOI's class.
   		/// </summary>
   		/// <param name="Items">
   		/// Values of tSDI and/or tDAI classes.
   		/// </param>
   		private void showUnNamigSDI_DAI( tUnNaming[] Items)   		
		{
   			for(int x = 0; x < Items.Length; x++)
   			{   				
   				
   				Console.WriteLine("\n Server = {0}", x);   			
   			    //An object "Type" is obtained to determine what kind of element is tSDI or tDAI   				
   				Type vtype = (Items[x]).GetType();   			
   				if(vtype.Name.Equals("tSDI"))
   				{   					
   					// The "tServer" class is obtained from "tUnNaming" class using polymorphism   					   					
   					tUnNaming  Item = Items[x];
   					tSDI SDI = (tSDI) Item;
   					showSDI(SDI); 				
   				}
   				else if(vtype.Name.Equals("tDAI"))
   				{
   					tUnNaming  Item = Items[x];
   					tDAI DAI= (tDAI) Item;
   					showDAI(DAI); 
   				}
   				else{
					Console.WriteLine("\t Error!!! Verify the conditions of the method showUnNaming");
   				}
   			}  			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSDI's class.
   		/// </summary>
   		/// <param name="SDI">
   		/// Values of tSDI's class that will be displayed.
   		/// </param>
   		private void showSDI(tSDI SDI)
   		{  			 
   			Console.WriteLine("<SDI>");
   			Console.WriteLine(" name = {1}, ix = {2} ixSpecified", SDI.desc, SDI.name, SDI.ix, SDI.ixSpecified);
   			showUnNamigSDI_DAI(SDI.Items);
   			showUnNaming(SDI);
   		}   		
   			
   		/// <summary>
   		/// This method displays the values of tDAI's class.
   		/// </summary>
   		/// <param name="DAI">
   		/// Values of tDAI's class that will be displayed.
   		/// </param>
   		private void showDAI(tDAI DAI)
   		{  			 
   			Console.WriteLine("<DAI>");
   			Console.WriteLine(" name = {0}, sAddr = {1}, valKind = {2} ix = {3} ixSpecified = {4}", DAI.name, DAI.sAddr, DAI.valKind, DAI.ix, DAI.ixSpecified);
   			if(DAI.Val != null && DAI.Val.Length != 0)
   				showVal(DAI.Val);
   			showUnNaming(DAI);   					
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tVal's class.
   		/// </summary>
   		/// <param name="Val">
   		/// Values of tVal's class that will be displayed.
   		/// </param>
   		private void showVal(tVal[] Val)
   		{  		   			
   			for(int x = 0; x < Val.Length; x++)
   			{
   				Console.WriteLine("<Val>");
   				Console.WriteLine(" sGroup = {0}",Val);
   			}
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tLogControl's class.
   		/// </summary>
   		/// <param name="LogControl">
   		/// Values of tLogControl's class that will be displayed.
   		/// </param>
   		private void showLogControl(tLogControl[] LogControl)
   		{  			   			
   			Console.WriteLine("<LogControl>");
   			for(int x = 0 ; x < LogControl.Length; x++)
   			{
   				showControlWithTriggerOpt(LogControl[x]);
   				Console.WriteLine("\t#{0} logName = {1} logEna = {2} reasonCode = {3}",x, LogControl[x].logName, LogControl[x].logEna, LogControl[x].reasonCode);
   			}   			
   		}   		
   		 		
   		/// <summary>
   		/// This method displays the values of tControlWithTriggerOpt's class.
   		/// </summary>
   		/// <param name="ControlWithTriggerOpt">
   		/// Values of tControlWithTriggerOpt's class that will be displayed.
   		/// </param>
   		private void showControlWithTriggerOpt(tControlWithTriggerOpt ControlWithTriggerOpt)
   		{  			   			
   			Console.WriteLine("<ControlWithTriggerOpts>");
   			Console.WriteLine(" intgPd = {0}",ControlWithTriggerOpt);	   			
   			if(ControlWithTriggerOpt.TrgOps != null)
   			{
   				showTrgOps(ControlWithTriggerOpt.TrgOps);
   			}
   			showcControl(ControlWithTriggerOpt);
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tControl's class.
   		/// </summary>
   		/// <param name="Control">
   		/// Values of tControl's class that will be displayed.
   		/// </param>
   		private void showcControl(tControl Control)
   		{  			   			
   			Console.WriteLine("->Control");
   			Console.WriteLine("Control datSet = {0}", Control.datSet);	
   			showNaming(Control);
   		}   
   		
   		/// <summary>
   		/// This method displays the values of tTrgOps's class.
   		/// </summary>
   		/// <param name="TrgOps">
   		/// Values of tTrgOps's class that will be displayed.
   		/// </param>
   		private void showTrgOps(tTrgOps TrgOps)
   		{  		   	
   			Console.WriteLine("<TrgOps>");
   			Console.WriteLine(" dchg = {0} qchg = {1} dupd = {2} period = {3}", TrgOps.dchg, TrgOps.qchg, TrgOps.dchg, TrgOps.period);	   			
   		}   		
   		
   		/// <summary>
   		/// This method displays the values of tDataSet's class.
   		/// </summary>
   		/// <param name="DataSet">
   		/// Values of tDataSet's class that will be displayed.
   		/// </param>
   		private void showDateSet(tDataSet[] DataSet)
   		{  			   		
   			Console.WriteLine("<DataSet>");
   			for(int x = 0; x < DataSet.Length; x++)
   			{     				
   				if(DataSet[x].FCDA != null && DataSet[x].FCDA.Length != 0)
   					showFCDA(DataSet[x].FCDA); 		
   				showNaming(DataSet[x]);   				
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tReportControl's class.
   		/// </summary>
   		/// <param name="ReportControl">
   		/// Values of tReportControl's class that will be displayed.
   		/// </param>
   		private void showReportControl(tReportControl[] ReportControl)
   		{  			   
   			Console.WriteLine("<ReportControl>");
   			for(int x = 0; x < ReportControl.Length; x++)
   			{   				   				
   				Console.WriteLine(" #{0} rptID = {1}, confRev = {2}, buffered = {3}, bufTime = {4}",x, ReportControl[x].rptID, ReportControl[x].confRev, ReportControl[x].buffered, ReportControl[x].bufTime);
   				if(ReportControl[x].OptFields != null)
   					showOptFields(ReportControl[x].OptFields); 
   				if(ReportControl[x].RptEnabled != null)
   					showRptEnabled(ReportControl[x].RptEnabled);
   				showControlWithTriggerOpt(ReportControl[x]);
   			}
   		}   		
   		
   		/// <summary>
   		/// This method displays the values of tRptEnabled's class.
   		/// </summary>
   		/// <param name="RptEnabled">
   		/// Values of tRptEnabled's class that will be displayed.
   		/// </param>
   		private void showRptEnabled(tRptEnabled RptEnabled)
   		{  	
   			Console.WriteLine("<RptEnabled> \n max = {0} ",RptEnabled.max);
   			if(RptEnabled.ClientLN != null)
   				showClientLN(RptEnabled.ClientLN);
   			showUnNaming(RptEnabled); 
   		}
   		
   		/// <summary>
   		/// This method displays the values of tClientLN's class.
   		/// </summary>
   		/// <param name="ClientLN">
   		/// Values of tClientLN's class that will be displayed.
   		/// </param>
   		private void showClientLN(tClientLN[] ClientLN)
   		{  		
   			Console.WriteLine("<ClientLN>");
   			for(int x = 0; x < ClientLN.Length; x++)
   			{   				
   				//Console.WriteLine("\tClientLN \n #{0} iedName =  ldInst =  prefix = {1} lnClass = {2} lnInst = {3}",x, ClientLN[x].prefix, ClientLN[x].lnClass, ClientLN[x].lnInst);
   				Console.WriteLine(" ClientLN \n #{0} iedName ={1}  ldInst = {2}  prefix = {3} lnClass = {4} lnInst = {5}",x, ClientLN[x].iedName, ClientLN[x].ldInst, ClientLN[x].prefix, ClientLN[x].lnClass, ClientLN[x].lnInst);
   			}   				
   		}
   		
   		/// <summary>
   		/// This method displays the values of tReportControlOptFields's class.
   		/// </summary>
   		/// <param name="OptFields">
   		/// Values of tReportControlOptFields's class that will be displayed.
   		/// </param>
   		private void showOptFields(tReportControlOptFields OptFields)
   		{  			   			   					
   			Console.WriteLine("<OptFields> \n seqNum = {0}, timeStamp = {1}, dataSet = {2}, reasonCode = {3} dataRef = {4} entryID = {5} configRef = {6}", OptFields.seqNum, OptFields.timeStamp, OptFields.dataSet, OptFields.reasonCode, OptFields.dataRef, OptFields.entryID, OptFields.configRef);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tFCDA's class.
   		/// </summary>
   		/// <param name="FCDA">
   		/// Values of tFCDA's class that will be displayed.
   		/// </param>
   		private void showFCDA(tFCDA[] FCDA)
   		{
   			Console.WriteLine("<FCDA>");
   			for(int x = 0; x < FCDA.Length; x++)
   			{
   				Console.WriteLine(" #{0} ldInst = {1} prefix = {2} lnClass = {3} lnInst = {4} doName = {5} daName = {6} fc = {7}",x, FCDA[x].ldInst, FCDA[x].prefix, FCDA[x].lnClass, FCDA[x].lnInst, FCDA[x].doName, FCDA[x].daName, FCDA[x].fc);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLDevice's class.
   		/// </summary>
   		/// <param name="LDevices">
   		/// Values of tLDevice's class that will be displayed.
   		/// </param>
   		private void showLDevice(tLDevice[] LDevices)
   		{
   			Console.WriteLine("<LDevice>");
   			for(int x = 0; x < LDevices.Length; x++)
   			{   				
   				Console.WriteLine("\t tDevice \n\t\t #{0} desc = {1} inst = {2} IdName = {3}",x, LDevices[x].desc, LDevices[x].inst, LDevices[x].ldName);
   				if(LDevices[x].LN0 != null )
   					showLN0Type(LDevices[x].LN0);
   				if(LDevices[x].LN != null && LDevices[x].LN.Length != 0)
   					showLNs(LDevices[x].LN);
   				if(LDevices[x].AccessControl != null)
   					showAccessControl(LDevices[x].AccessControl);
   				showUnNaming(LDevices[x]);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tAccessControl's class.
   		/// </summary>
   		/// <param name="AccessControl">
   		/// Values of tAccessControl's class that will be displayed.
   		/// </param>
   		public void showAccessControl(tAccessControl AccessControl)
   		{   
   			Console.WriteLine("<AccessControl>");   			
   			showAnyContentFromOtherNamespace(AccessControl);
   		}
   		
   		/// <summary>
   		/// This method displays the values of LN0's class.
   		/// Note: According to XSD File, the class should be called 
   		/// LN0Type but it's called LN0
   		/// </summary>
   		/// <param name="LNs">
   		/// Values of LN0's class that will be displayed.
   		/// </param>
   		public void showLNs(tLN[] LNs)
   		{
   			for(int x = 0; x <LNs.Length; x++)
   			{
   				showLN(LNs[x]);
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
   		public void showLN0Type(LN0 LN0)
   		{
   			Console.WriteLine("\tLN0 (LNodeType)");
   			if(LN0.AnyAttr != null)
   				Console.WriteLine("\t anyAttribute = {0}",LN0.AnyAttr);
   			showLN0(LN0);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLN0's class.
   		/// </summary>
   		/// <param name="Ln0">
   		/// Values of tLN0's class that will be displayed.
   		/// </param>
   		public void showLN0(tLN0 Ln0)
   		{
   			Console.WriteLine("-> Ln0");
   			Console.WriteLine(" InClass = {0} inst = {1}", Ln0.lnClass, Ln0.inst);
   			if(Ln0.GSEControl != null && Ln0.GSEControl.Length != 0)
   				showGSEControl(Ln0.GSEControl);
   			if(Ln0.SampledValueControl != null && Ln0.SampledValueControl.Length != 0)
   				showSampledValueControl(Ln0.SampledValueControl);
   			if(Ln0.SettingControl != null)
   				showSettingControl(Ln0.SettingControl);
   			if(Ln0.SCLControl != null)
   				showSCLControl(Ln0.SCLControl); 
   			if(Ln0.Log != null)
   				showLog(Ln0.Log);
   			showAnyLN(Ln0);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tLog's class.
   		/// </summary>
   		/// <param name="Log">
   		/// Values of tLog's class that will be displayed.
   		/// </param>
   		public void showLog(tLog Log)
   		{
   			Console.WriteLine("<Log>");    			
   			showAnyContentFromOtherNamespace(Log);
   		}
   		   		   		
   		/// <summary>
   		/// This method displays the values of tSCLControl's class.
   		/// </summary>
   		/// <param name="SCLControl">
   		/// Values of tSCLControl's class that will be displayed.
   		/// </param>
   		public void showSCLControl(tSCLControl SCLControl)
   		{   			
   			Console.WriteLine("<SCLControl>");
   			showUnNaming(SCLControl);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSettingControl's class.
   		/// </summary>
   		/// <param name="SettingControl">
   		/// Values of tSettingControl's class that will be displayed.
   		/// </param>
   		public void showSettingControl(tSettingControl SettingControl)
   		{
   			Console.WriteLine("<SettingControl>");   			
   			Console.WriteLine(" numOfSGs = {0}, actSG = {1}", SettingControl.numOfSGs, SettingControl.actSG);
   			showUnNaming(SettingControl);
   		}
   		
    	/// <summary>
   		/// This method displays the values of tSampledValueControl's class.
   		/// </summary>
   		/// <param name="SampledValueControl">
   		/// Values of tSampledValueControl's class that will be displayed.
   		/// </param>
   		public void showSampledValueControl(tSampledValueControl[] SampledValueControl)
   		{   			
   			Console.WriteLine("SampledValueControl");
   			for(int x = 0; x < SampledValueControl.Length; x++)
   			{   				
   				Console.WriteLine("smvID = {0} multicast = {1} smpRate = {2} nofASDU = {3}", SampledValueControl[x].smvID, SampledValueControl[x].multicast, SampledValueControl[x].smpRate, SampledValueControl[x].nofASDU);
   				if(SampledValueControl[x].SmvOpts != null)
   					showSmvOpts(SampledValueControl[x].SmvOpts);
   				showControlWithIEDName(SampledValueControl[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tSampledValueControlSmvOpts's class.
   		/// </summary>
   		/// <param name="SmvOpts">
   		/// Values of tSampledValueControlSmvOpts's class that will be displayed.
   		/// </param>
   		public void showSmvOpts(tSampledValueControlSmvOpts SmvOpts)
   		{
   			Console.WriteLine("<SmvOpts>");
   			Console.WriteLine(" refreshTime = {0}, sampleSynchronized = {1}, sampleRate = {2}, security = {3}, dataRef = {4}", SmvOpts.refreshTime, SmvOpts.sampleSynchronized, SmvOpts.sampleRate, SmvOpts.security, SmvOpts.dataRef);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGSEControl's class.
   		/// </summary>
   		/// <param name="GSEControl">
   		/// Values of tGSEControl's class that will be displayed.
   		/// </param>
   		public void showGSEControl(tGSEControl[] GSEControl)
   		{
   			Console.WriteLine("<GSEControl>");
   			for(int x = 0; x < GSEControl.Length; x++)
   			{   				   				
   				Console.WriteLine("appID = {0}", GSEControl[x].appID);
   				//if(GSEControl[x].type != null)
				showGSEControlTypeEnum(GSEControl[x].type);
				showControlWithIEDName(GSEControl[x]);
   			}   				
   		}
   		
   		/// <summary>
   		/// This method displays the values of tGSEControlTypeEnum's class.
   		/// </summary>
   		/// <param name="GSEControlTypeEnum">
   		/// Values of tGSEControlTypeEnum's class that will be displayed.
   		/// </param>
   		public void showGSEControlTypeEnum(tGSEControlTypeEnum GSEControlTypeEnum)
   		{  			
   			Console.WriteLine("<GSEControlTypeEnum> \n\t",GSEControlTypeEnum);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tControlWithIEDName's class.
   		/// </summary>
   		/// <param name="ControlWithIEDName">
   		/// Values of tControlWithIEDName's class that will be displayed.
   		/// </param>
   		public void showControlWithIEDName(tControlWithIEDName ControlWithIEDName)
   		{
   			Console.WriteLine("->ControlWithIEDName");
   			Console.WriteLine("confRev = {0}", ControlWithIEDName.confRev);				   				
   			if(ControlWithIEDName.IEDName != null && ControlWithIEDName.IEDName.Length != 0)
   				showIEDName(ControlWithIEDName.IEDName);
   			showControl(ControlWithIEDName);
   		}
   		
   		/// <summary>
   		/// This method displays the values of IEDName's strings.
   		/// </summary>
   		/// <param name="IEDNames">
   		/// Values of String's class for IEDName
   		/// </param>
   		public void showIEDName(String[] IEDNames)
   		{
   			Console.WriteLine("IEDNames");
   			for(int x = 0; x < IEDNames.Length; x++)
   			{   				
   				Console.WriteLine("#{0} IEDame = {1}", x, IEDNames[x]);
   			}   			
   		}
   		
   		/// <summary>
   		/// This method displays the values of tControl's class.
   		/// </summary>
   		/// <param name="Control">
   		/// Values of tControl's class that will be displayed.
   		/// </param>
   		public void showControl(tControl Control)
   		{   			
   			Console.WriteLine("-> Control \n\t datSet = {0}", Control.datSet);
   			showNaming(Control);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDataTypeTemplates's class.
   		/// </summary>
   		/// <param name="DataTypeTemplates">
   		/// Values of tDataTypeTemplates's class that will be displayed.
   		/// </param>
  		private void showDataTypeTemplates(tDataTypeTemplates DataTypeTemplates)
  		{  		  			
  			Console.WriteLine("<DataTypeTemplates>");
  			if(DataTypeTemplates.LNodeType != null && DataTypeTemplates.LNodeType.Length != 0)
  				showLNodeType(DataTypeTemplates.LNodeType);
  			if(DataTypeTemplates.DOType != null && DataTypeTemplates.DOType.Length != 0)
  				showDOType(DataTypeTemplates.DOType);
  			if(DataTypeTemplates.DAType != null && DataTypeTemplates.DAType.Length != 0)
  				showDAType(DataTypeTemplates.DAType);			
  			if(DataTypeTemplates.EnumType != null && DataTypeTemplates.EnumType.Length != 0)
  				showEnumType(DataTypeTemplates.EnumType);
  		}
  		 
   		/// <summary>
   		/// This method displays the values of tDOType's class.
   		/// </summary>
   		/// <param name="DOType">
   		/// Values of tDOType's class that will be displayed.
   		/// </param>
   		private void showDOType(tDOType[] DOType)
  		{  		
   			for(int x = 0; x < DOType.Length; x++)
   			{   				
   				Console.WriteLine("DOType (Tipo DO)");	  				
  				Console.WriteLine("iedType = {0} cdc = {1}", DOType[x].iedType, DOType[x].cdc);
  				if(DOType[x].Items != null && DOType[x].Items.Length != 0)
  					showtBaseElementSDODA(DOType[x].Items);
  				showIDNaming(DOType[x]);
   			}
  		}
  		   		
   		/// <summary>
   		/// This method displays the values of tDOType's class.
   		/// </summary>
   		/// <param name="Items">
   		/// Values of tDOType's class that will be displayed.
   		/// </param>
   		private void showtBaseElementSDODA(tBaseElement[] Items)
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
   					showSDO(SDO);
   					
   				}
   				else if(vtype.Name.Equals("tDA"))
   				{
   					//The "tDA" class is obtained using polymorphism
   					tDA DA= (tDA) Items[x];
   					showDA(DA);
   				}
   				else{
					Console.WriteLine("\tVerifiy the conditions of the method showtBaseElementSDODA");
   				}
   			}  	
  		}
  		
   		/// <summary>
   		/// This method displays the values of tSDO's class.
   		/// </summary>
   		/// <param name="SDO">
   		/// Values of tSDO's class that will be displayed.
   		/// </param>
   		private void showSDO(tSDO SDO)
  		{  		
   			Console.WriteLine("<SDO>");   			
   			Console.WriteLine("SDO type = {0}", SDO.type);	  				
   			showNaming(SDO);
   		}
   		
   		/// <summary>
   		/// This method displays the values of tDA's class.
   		/// </summary>
   		/// <param name="DA">
   		/// Values of tDA's class that will be displayed.
   		/// </param>
   		private void showDA(tDA DA)
  		{  		
   			Console.WriteLine("<DA>");   			
   			Console.WriteLine(" dchg = {0} qchg = {1} dupd = {2} fc = {3}", DA.dchg, DA.qchg, DA.dupd, DA.fc);	  				
   			showAbstractDataAttribute(DA);
   		}
   		   		
   		/// <summary>
   		/// This method displays the values of tAbstractDataAttribute's class.
   		/// </summary>
   		/// <param name="AtributoDatoAbstracto">
   		/// Values of tAbstractDataAttribute's class that will be displayed.
   		/// </param>
   		private void showAbstractDataAttribute(tAbstractDataAttribute AtributoDatoAbstracto)
  		{  	   			
   			Console.WriteLine("-> AbstractDataAttribute");
   			Console.WriteLine(" name = {0} sAddr = {1} bType = {2} valKind = {3} type = {4} count = {5}", AtributoDatoAbstracto.name, AtributoDatoAbstracto.sAddr, AtributoDatoAbstracto.bType, AtributoDatoAbstracto.valKind, AtributoDatoAbstracto.type, AtributoDatoAbstracto.count);	  				
   			if(AtributoDatoAbstracto.Val != null && AtributoDatoAbstracto.Val.Length != 0)
   				showVal(AtributoDatoAbstracto.Val);
   			showUnNaming(AtributoDatoAbstracto);
   		}
   			
   		/// <summary>
   		/// This method displays the values of tLNodeType's class.
   		/// </summary>
   		/// <param name="NodeType">
   		/// Values of tLNodeType's class that will be displayed.
   		/// </param>
   		private void showLNodeType(tLNodeType[] NodeType)
  		{  	  			
   			for(int x = 0; x < NodeType.Length; x++)
   			{
   				Console.WriteLine("<NodeType> ");	   			
  				Console.WriteLine("iedType = {0} lnClass = {1}", NodeType[x].iedType, NodeType[x].lnClass);
  				if(NodeType[x].DO != null && NodeType[x].DO.Length != 0)
  					showDO(NodeType[x].DO);
  				showIDNaming(NodeType[x]); 
   			}
  		}  		
  		
   		/// <summary>
   		/// This method displays the values of tDO's class.
   		/// </summary>
   		/// <param name="DOs">
   		/// Values of tDO's class that will be displayed.
   		/// </param>
   		private void showDO(tDO[] DOs)
  		{  		
   			Console.WriteLine("<DO>");	   				
   			for(int x = 0; x < DOs.Length; x++)
   			{   				
   				Console.WriteLine(" #{0} name = {1}, type = {2}, accessControl = {3}, transient = {4}", x, DOs[x].name, DOs[x].type, DOs[x].accessControl, DOs[x].transient);
   				showUnNaming(DOs[x]);
   			}
  		}  		
   		
   		/// <summary>
   		/// This method displays the values of tIDNaming's class.
   		/// </summary>
   		/// <param name="IDNaming">
   		/// Values of tIDNaming's class that will be displayed.
   		/// </param>
   		private void showIDNaming(tIDNaming IDNaming)
  		{ 
   			Console.WriteLine("->IDNaming");
   			Console.WriteLine(" tid = {0}, desc = {1}", IDNaming.id, IDNaming.desc);	   			
   			showBaseElement(IDNaming);
  		}  		
   		   		
   		/// <summary>
   		/// This method displays the values of tDAType's class.
   		/// </summary>
   		/// <param name="DATypes">
   		/// Values of tDAType's class that will be displayed.
   		/// </param>
   		private void showDAType(tDAType[] DATypes)
  		{  	  			
   			Console.WriteLine("<DATypes>");
   			for(int x = 0; x < DATypes.Length; x++)
   			{   				
   				Console.WriteLine("iedType = {0}", DATypes[x].iedType);
   				showBDA(DATypes[x].BDA);
   				showIDNaming(DATypes[x]);
   			}   				
  		}
   		
   		/// <summary>
   		/// This method displays the values of tBDA's class.
   		/// </summary>
   		/// <param name="BDAs">
   		/// Values of tBDA's class that will be displayed.
   		/// </param>
   		private void showBDA(tBDA[] BDAs)
  		{  	  			
   			Console.WriteLine("BDA");
   			for(int x = 0; x < BDAs.Length; x++)
   			{   				
   				showAbstractDataAttribute(BDAs[x]);
   			}   				
  		}
   		
   		/// <summary>
   		/// This method displays the values of tEnumType's class.
   		/// </summary>
   		/// <param name="EnumTypes">
   		/// Values of tEnumType's class that will be displayed.
   		/// </param>
   		private void showEnumType(tEnumType[] EnumTypes)
  		{  	  	
   			Console.WriteLine("<EnumType>");
   			for(int x = 0; x < EnumTypes.Length; x++)
   			{      				
   				if(EnumTypes[x].EnumVal != null && EnumTypes[x].EnumVal.Length != 0)
   					showEnumVal(EnumTypes[x].EnumVal);
   				showIDNaming(EnumTypes[x]);
   			}   				
  		}
   			   		
   		/// <summary>
   		/// This method displays the values of tEnumVal's class.
   		/// </summary>
   		/// <param name="EnumVals">
   		/// Values of tEnumVal's class that will be displayed.
   		/// </param>
   		private void showEnumVal(tEnumVal[] EnumVals)
  		{  	  	
   			Console.WriteLine("<EnumVal>");
   			for(int x = 0; x < EnumVals.Length; x++)
   			{   				
   				Console.WriteLine("ord = {0}", EnumVals[x].ord);  				
   			}   				
  		}
   		   		
   		/// <summary>
   		/// This method displays the values of tBaseElement's class.
   		/// </summary>
   		/// <param name="BaseElement">
   		/// Values of tBaseElement's class that will be displayed.
   		/// </param>
   		private void showBaseElement(tBaseElement BaseElement)
  		{  	  	
   			Console.WriteLine("->BaseElement");
   			if(BaseElement.Any != null)
   				Console.WriteLine("Any = {0}",BaseElement.Any);
   			if(BaseElement.Text != null)
   				showText(BaseElement.Text);
   			if(BaseElement.Private != null && BaseElement.Private.Length != 0)
   				showPrivate(BaseElement.Private);
  		}
   		
   		/// <summary>
   		/// This method displays the values of tText's class.
   		/// </summary>
   		/// <param name="Text">
   		/// Values of tText's class that will be displayed.
   		/// </param>
   		private void showText(tText Text)
  		{  	  	  			   			
   			Console.WriteLine("\n<Text>");
   			Console.WriteLine("\tsource = {0} anyAttribute = {1}", Text.source, Text.AnyAttr);
   			showAnyContentFromOtherNamespace(Text);
  		}
   		
   		/// <summary>
   		/// This method displays the values of tAnyContentFromOtherNamespace's class.
   		/// </summary>
   		/// <param name="AnyContentFromOtherNamespace">
   		/// Values of tAnyContentFromOtherNamespace's class that will be displayed.
   		/// </param>
   		private void showAnyContentFromOtherNamespace(tAnyContentFromOtherNamespace AnyContentFromOtherNamespace)
   		{		
   			Console.WriteLine("->AnyContentFromOtherNamespace");
   			for(int x = 0; AnyContentFromOtherNamespace.AnyAttr !=null && x < AnyContentFromOtherNamespace.AnyAttr.Length; x++)
   			{
   				Console.WriteLine("\tAnyAttribute = {0}", AnyContentFromOtherNamespace.AnyAttr[x].Value);
   			}
   			
   			for(int x = 0; AnyContentFromOtherNamespace.Any !=null && x < AnyContentFromOtherNamespace.Any.Length; x++)
   			{
   				Console.WriteLine("\tAny = {0}", AnyContentFromOtherNamespace.Any[x].Value);
   			}
   		}
   		
   		/// <summary>
   		/// This method displays the values of tPrivate's class.
   		/// </summary>
   		/// <param name="Privates">
   		/// Values of tPrivate's class that will be displayed.
   		/// </param>
   		private void showPrivate(tPrivate[] Privates)
  		{  	  	   			
   			for(int x =0; x < Privates.Length; x++)
   			{
   				Console.WriteLine("<Private>");   				
   				Console.WriteLine("\ttype = {0} source = {1}", Privates[x].type, Privates[x].source);
   				showAnyContentFromOtherNamespace(Privates[x]);
   			}
   				
  		}
   		
   		/// <summary>
   		/// This method serialize an SCL object to specific XML File 
   		/// </summary>
   		/// <param name="XMLobject">
   		/// Information contained on the SCL Objects 
   		/// </param>
   		/// <param name="XMLFileName">
   		/// Name of an XML File where the information of XMLObject will be stored
   		/// </param>
   		private void serializar(SCL XMLobject, string XMLFileName)
		 {               	
        	//Creates an instance of XmlSerializer class      	
        	XmlSerializer serializer = 	new XmlSerializer(typeof(SCL));
        	TextWriter writer = new StreamWriter(XMLFileName);       	
        	// Specifies the types of object to serialize.       	
        	serializer.Serialize(writer, XMLobject);
        	writer.Close();        	
   		}
   		
   		/// <summary>
   		/// Starts of the application
   		/// </summary>
   		/// <param name="args">
   		/// 
   		/// </param>
		public static void Main(string[] args)			
		{
			string FileName;
			ConsoleSCL aplicacion = new ConsoleSCL();
			Console.WriteLine("Teclee la ruta y nombre del archivo");
			FileName = Console.ReadLine();
//			SCL XMLobject = aplicacion.deserialize("C:\\Proyecto\\IEC61850-Station.xml");						
			SCL XMLobject = aplicacion.deserialize(FileName);									
//			aplicacion.serializar(XMLobject,"C:\\Proyecto\\SerializacionIEC61850-Station.xml");
			aplicacion.serializar(XMLobject,FileName+"nuevo");			
		}
				
		/// <summary>
		/// This method identifies an unknown XML node during a deserialization
		/// </summary>
		/// <param name="sender">
		// Unknown XML node
		/// </param>
		/// <param name="e">
		/// Kind of event happened
		/// </param>
		protected void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
    	{
	        Console.WriteLine("Unknown Node: " +   e.Name + "\t" + e.Text);
	    }

		/// <summary>
		/// This method is called when XmlSerializer detects an unknown XML 
		/// attribute during a deserialization
		/// </summary>
		/// <param name="sender">
		/// Unknown XML attribute
		/// </param>
		/// <param name="e">
		/// Kind of event happened
		/// </param>
   		protected void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
    	{
        	System.Xml.XmlAttribute attr = e.Attr;
        	Console.WriteLine("Unknown attribute: " + 
        	attr.Name + "='" + attr.Value + "'");
    	}
	}
}
