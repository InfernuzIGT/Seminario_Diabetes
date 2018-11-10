using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digestiveSystem : MonoBehaviour {

    public float rotSpeed; //Velocidad de rotacion para el modelo
    Rigidbody rBody;

	void Awake () {
        rBody = GetComponent<Rigidbody> ();
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnMouseDrag () {
        //float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        //transform.Rotate (Vector3.up, -rotX);

        float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        rBody.AddTorque (transform.up * -rotX, ForceMode.VelocityChange);

    }



}
