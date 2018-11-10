using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digestiveSystem : MonoBehaviour {

    float rotSpeed; //Velocidad de rotacion para el modelo
    Rigidbody rBody; //Rigidbody utilizado para rotar el modelo



	void Awake () {
        rBody = GetComponent<Rigidbody> ();
        rotSpeed = 100;
    }
	
	void Start () {
		
	}
	
    //Al hacer drag, rota el modelo con friccion
    private void OnMouseDrag () {
        float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        rBody.AddTorque (transform.up * -rotX, ForceMode.VelocityChange);

    }



}
