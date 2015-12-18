using UnityEngine;
using System.Collections;

public class FairyController : MonoBehaviour {

	private float verticalSpeed=0.5f;
	private float horizontalSpeed=0.5f;
	private int estado; // 0 en reposo // 1 corriendo // 2 saltando // 3 disparando
	private float t=0;
	private float timesPerSecond=3;
	private float umbral=0;
	public GameObject disparo;
	
	private int runIndex=0;
	private int jumpIndex=0;
	
	public Sprite reposo;
	public Sprite[] corriendo;
	public Sprite[] saltando;
	
	
	public int tick;
	
	private int skipRun=8;
	private int skipJump=13;
	private int skipShoot=2;
	// Use this for initialization
	void Start () {
		umbral = 1f / timesPerSecond;
	}
	
	// Update is called once per frame
	void Update () {
		tick++;
		
		if (tick >2000)
			tick = 0;
		

		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.rigidbody2D.velocity += new Vector2 (horizontalSpeed,0 );
			estado = 1;
			
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.rigidbody2D.velocity -= new Vector2 (horizontalSpeed, 0);
			estado = 1;
		}

		else if(Input.GetKey(KeyCode.UpArrow)){
			gameObject.rigidbody2D.velocity  +=new Vector2(0,verticalSpeed);
			estado=2;
		}
			//if(Input.GetKey(KeyCode.DownArrow)){
				//gameObject.rigidbody2D.velocity  +=new Vector2(verticalSpeed,0);
				//estado=2;
			//}
			
		 else {
			estado=0;
		}
		
		if (estado == 0) {
			gameObject.GetComponent<SpriteRenderer>().sprite=reposo;
			
		}

		
		if (estado == 1 && (tick % skipRun==0)){
			gameObject.GetComponent<SpriteRenderer>().sprite=corriendo[runIndex];
			
			runIndex++;
			if (runIndex>4){
				runIndex=0;
			}
			
		}
		if(estado == 2 &&(tick % skipJump==0)){
			gameObject.GetComponent<SpriteRenderer>().sprite=saltando[jumpIndex];
			jumpIndex++;
			if(jumpIndex>2){
				jumpIndex=0;
			}
		}
		
		
	}
	
}
