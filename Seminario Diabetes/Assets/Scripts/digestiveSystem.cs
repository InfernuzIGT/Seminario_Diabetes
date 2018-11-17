using UnityEngine;

public class DigestiveSystem : MonoBehaviour {

    float rotSpeed; //Velocidad de rotacion para el modelo
    Rigidbody rBody; //Rigidbody utilizado para rotar el modelo
    

	void Awake () {
        rBody = GetComponent<Rigidbody> ();
        rotSpeed = 25;
    }
	
    //Al hacer drag, rota el modelo con friccion
    private void OnMouseDrag () {
        float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        rBody.AddTorque (transform.up * -rotX, ForceMode.VelocityChange);

    }



}
