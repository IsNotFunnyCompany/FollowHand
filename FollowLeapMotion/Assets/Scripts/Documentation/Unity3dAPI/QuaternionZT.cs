using UnityEngine;
using System.Collections;

/* 
 * I Quaternion a differenza dei Vector3 non rappresentano una posizione ma una rotazione ,
 * la rotazione di un qualsiasi oggetto . Questa classe statica non va a modificare i singoli 
 * assi di una rotazione ma da una rotazione ne fa avere un altra a tutti e 3 gli assi.
 */
public class QuaternionZT : MonoBehaviour {

	public Quaternion rotation = Quaternion.identity;

	void Start () {
	
	}
	
	void Update () {

        // Quaternion.identity dice che un oggetto NON ha rotazione , perchè è perfettamente 
        // alineato con gli assi del mondo

        transform.rotation = Quaternion.identity;
        Debug.Log("Quaternion.identity ->"+ transform.rotation);

        // Restituisce l'angolo di Eulero aspresso attraverso la rotazione di un oggetto .
        // E' una rotazione che ruota di euler.z gradi attorno all'asse z, di euler.x gradi 
        // attorno all'asse x e di euler.y gradi attorno all'asse y (in questo ordine).

        rotation.eulerAngles = new Vector3(0, 30, 0);
        Debug.Log("Quaternion Euler Angle -> "+rotation.eulerAngles.y);
        Debug.Log("Quaternion Euler Angle -> "+rotation.eulerAngles.x);
        Debug.Log("Quaternion Euler Angle -> "+rotation.eulerAngles.z);


	
	}
}
