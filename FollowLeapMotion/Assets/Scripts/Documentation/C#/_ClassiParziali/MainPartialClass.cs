using UnityEngine;
using System.Collections;

public class MainPartialClass : MonoBehaviour {
	
	/*
	 * Se dopo il modificatore di visibilità ci metto partial posso dividere una classe in più parti
	 * quando si compilerà sarà come aver scritto una sola classe ma attenzione a non suddividere troppo
	 * la classe altrimenti si potrebbe rischiare di avere un sistema chaotico.
	 * 
	 * IDEA: utilizzando l'overloading (scrivo un metodo con lo stesso nome ma con diverso tipo o numero di parametri)
	 * posso creare pezzi di classe per tipo 
	 */
	
	private PrimaParte primaParte;
	
	void Start () {
	
		primaParte = new PrimaParte();
		
		primaParte.primaParte();
		primaParte.secondaParte();
		primaParte.terzaParte();
		
	}
	
	void Update () {
	
	}
}
