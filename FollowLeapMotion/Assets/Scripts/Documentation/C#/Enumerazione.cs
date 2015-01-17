using UnityEngine;
using System.Collections;
using System.Linq;

	/*
	 * ENUMERAZIONI: un elenco di costanti 
	 * 
	 * 
	 *  Al primo enumeratore viene assegnato il valore 0 per poi continuare incrementando di 1 , 
	 *  ma li posso inizializzare per eseguire l'ovveride su un metodo predefinito
	 *  Di default i valori sono di tipo int per questo c'è la posizione ma mettendo il tipo dopo il nome 
	 *  posso scegliere il tipo
	 * 
	 *  Davanti a ogni enum si possono mettere i valori di visibilità , public,protected,private,new,internal
	 */

public class Enumerazione : MonoBehaviour {
	
	// Li posso visualizzare cosi 
	
	enum Uomini{
	
		simpleUomo,       
		normalUomo,     
		masterUomo     
		
	};
	
	//...oppure cosi...
	
	enum elfi{ elfoApprendista , elfoDon , elfoMaster , elfoRe , elfoRegina};
	
	// POSITION
	
	enum Zombi{
	
		simpleZombi,       // posizione 0
		normalZombi,       // posizione 1
		masterZombi        // posizione 2
		
	};
	
	// OVVERIDE 
	
	enum valoriLife{
		
		simpleLife = 1337,      
	    normalLife,      
		masterLife        
	
	};
	
	// SCELGO IL TIPO
	
	enum scelta : byte{ zero , primo , secondo ,terzo };
	
	// RANGE
	
	enum range : long{ Max = 2000L , Min = 10L};
	
	// ATTRIBUTO DI FLAG
	
	//[Flags]
	public enum OpzioniMacchina{
		
		ruote = 0x01,
		gomme = 0x02,
		luci  = 0x04,
	  tintura = 0x08
	
	};
	
	
	
	enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }; 
	
	
	enum MachineState
    {
       PowerOff = 0,
       Running = 5,
       Sleeping = 10,
       Hibernating = Sleeping + 5       // sto sommando
    }
	 
//_____________________________________________________________________________________|
//	    	                                                                           |
	void Start () {
		
		long ranges = (long)range.Max;
		int ricevo = (int)scelta.zero;
		byte ricevoByte = (byte)scelta.primo;
		
		
//		string s = Enum.GetName(typeof(Days), 4);
		
         //foreach (int i in Enum.GetValues(typeof(Days)))
		 //	  Debug.Log(i);
         //foreach (string str in Enum.GetNames(typeof(Days)))
         //   Debug.Log(str);
		
		
		Days day = Days.Wednesday;
		// si può cambiare inizializzazione successivamente
		day = Days.Friday;
		int days = (int)day;
		
		Months mount = Months.Dec;
		byte mounth = (byte)mount;
		
		// azione di BITWISE OR
		OpzioniMacchina opzioniMacchina = OpzioniMacchina.ruote | OpzioniMacchina.luci;
		
		Debug.Log("Mounth "+mounth);
		Debug.Log("Day "+days);
		
		// cerco di stamparlo in binario o decimale ma la stampa è SEMPRE in decimale
		
		Debug.Log("Binario " + opzioniMacchina);
		Debug.Log("Decimale " + (int)opzioniMacchina);
		
		
		Debug.Log("Ricevo = "+ ricevo + "Byte "+ricevoByte);      // risultato 0 , 0
		Debug.Log("Life "+(int)valoriLife.simpleLife);            // risultato 1337 
		Debug.Log("Range "+ranges);
	
	}
	
	void Update () {
	
	}
}
