using UnityEngine;
using System.Collections;
using System;

public enum DireccionH {Izquierda,Derecha}
public enum DireccionV {Arriba, Abajo}

public class PlataformaMovil : MonoBehaviour {
	public float VelocidadH =0.3F;
	public DireccionH SentidoH= DireccionH.Derecha;
	public float VelocidadV= 0.0F;
	public DireccionV SentidoV= DireccionV.Arriba;
	public float MaxRecorridoPingPong= 5.0F;


	private Transform PlatformTransform;
	private float WalkedDistanceH= 0.0F;
	private float WalkedDistanceV= 0.0F;
	private float ReferencePingPongHPosition;
	private float ReferencePingPongVPosition;
	private Vector3 InitialPlataformPosition;

	 
		// Use this for initialization
	void Start () {
	
		PlatformTransform = transform;

		InitialPlataformPosition = PlatformTransform.position;
		ReferencePingPongHPosition = Math.Abs (PlatformTransform.position.x);
		ReferencePingPongVPosition = Math.Abs (PlatformTransform.position.y);

	}


	
	// Update is called once per frame
	void Update () {
	
		WalkedDistanceH = Math.Abs (Math.Abs (PlatformTransform.position.x) - ReferencePingPongHPosition);
		WalkedDistanceV = Math.Abs (Math.Abs (PlatformTransform.position.y) - ReferencePingPongVPosition);

		if (MaxRecorridoPingPong != -1 && WalkedDistanceH >= MaxRecorridoPingPong) {
			if(SentidoH == DireccionH.Izquierda){
				SentidoH = DireccionH.Derecha;
			}
			else{
				SentidoH=DireccionH.Izquierda;
			}
			ReferencePingPongHPosition=Math.Abs(PlatformTransform.position.x);
		}
		if(MaxRecorridoPingPong != -1 && WalkedDistanceV >= MaxRecorridoPingPong){
			if (SentidoV == DireccionV.Arriba){
				SentidoV= DireccionV.Abajo;
			}
			else{
				SentidoV= DireccionV.Arriba;
			}
			ReferencePingPongVPosition = Math.Abs(PlatformTransform.position.y);
		}
		if (SentidoH == DireccionH.Izquierda) {
			VelocidadH = -Math.Abs (VelocidadH);
		} 
		else {
			VelocidadH= Math.Abs(VelocidadH);
		}
		if (SentidoV == DireccionV.Abajo) {
			VelocidadV = -Math.Abs (VelocidadV);
		}
		else {
			VelocidadV= Math.Abs(VelocidadV);
		}
		PlatformTransform.Translate(new Vector3(VelocidadH, VelocidadV, 0) * Time.deltaTime);
	}

	public void  OnTriggerStay2D (Collider2D other){
		other.transform.parent = transform;
	}
	public void OnTriggerExit2D(Collider2D other){
		other.transform.parent = null;
	}

}
