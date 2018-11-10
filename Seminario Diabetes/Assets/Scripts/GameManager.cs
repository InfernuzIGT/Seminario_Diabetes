using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header ("Variables")]
    [Range (0f, 100f)] public float varGlucose; //Glucosa
    [Range (0f, 100f)] public float varInsuline; //Insulina
    [Range (0f, 100f)] public float varSugar; //Azucar

    [Header ("Barra Informacion")]
    public Text txtGlucose;
    public Text txtInsuline;
    public Text txtSugar;

    [Header ("Barra Lateral")]
    public Animator animSide; //Animator de la barra lateral
    public Animator animBackground; //Animator del fondo oscuro


    void Awake () {

	}
	
	void Start () {
        txtGlucose.text = ((int)varGlucose).ToString ();
        txtInsuline.text = ((int)varInsuline).ToString ();
        txtSugar.text = ((int)varSugar).ToString ();
    }

    //Activa/desactiva la barra lateral
    public void sideScreen (bool isActive) {
        animSide.SetBool ("isActive", isActive);
        animBackground.SetBool ("isActive", isActive);
    }
	
	


    //END
}
