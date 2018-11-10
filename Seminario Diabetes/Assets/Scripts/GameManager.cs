using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header ("Variables")]
    [Range (0f, 100f)] public float varGlucose;
    [Range (0f, 100f)] public float varInsuline;
    [Range (0f, 100f)] public float varSugar;

    [Header ("Barra Informacion")]
    public Text txtGlucose;
    public Text txtInsuline;
    public Text txtSugar;



    void Awake () {
		
	}
	
	void Start () {
        txtGlucose.text = ((int)varGlucose).ToString ();
        txtInsuline.text = ((int)varInsuline).ToString ();
        txtSugar.text = ((int)varSugar).ToString ();
    }
	
	


    //END
}
