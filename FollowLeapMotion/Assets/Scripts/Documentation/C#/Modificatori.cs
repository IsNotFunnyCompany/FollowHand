using UnityEngine;
using System.Collections;

public class Modificatori : MonoBehaviour {

	/*
	 * Modificatori di visibilità per le classi (l'intero sistema)
	 *              |
	 *              |_____ public    --> visibile da qualsiasi classe
	 *              |_____ private   --> visibile soltanto nella classe in cui è dichiarata
	 *              |_____ internal  --> visibile da tutte le classi appartenenti allo stesso assembly a cui appartiene la classe
	 */      
	
	/*
	 * Modificatori di visibilità per i metodi , essi sono quella cosa che dice le azioni che è in grado di fare una classe
	 *              |
	 *              |_____ public    --> visibile da qualsiasi classe
	 *              |_____ private   --> visibile soltanto nella classe in cui è dichiarata
	 *              |_____ internal  --> visibile da tutte le classi appartenenti allo stesso assembly a cui appartiene la classe
	 *              |_____ protected -->visibile nella classe in cui è dichiarato e nelle sue sotto-classi
	 *              |_____ protected internal  --> la combinazione tra i due
	 */
	
	
	/*
	 * VIRTUAL : un metodo 
	 * 
	 *  public virtual double Area(){}
	 * 
	 *           consente di essere sottoposto a override in una classe derivata  (qualsiasi classe che lo eredita)
	 */ 
	
	/*
	 * OVERRIDE = si usa per modificare l'implementazione virtuale o astratta di un metodo , una proprietà o un evento ereditato
	 * 
	 * http://msdn.microsoft.com/it-it/library/ebca9ah3.aspx
	 */
	
	void Start () {
	
		int number = numeroPersonaggi();
		Debug.Log("Personaggi "+ numeroPersonaggi());
		
	}
	
	
	void Update () {
	
	}
	
	public int numeroPersonaggi(){
	
		return 10;
		
	}
	
	public void insertType(int numberGlobal){
	
		
		
	}
	
}
