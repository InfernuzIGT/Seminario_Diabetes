using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header ("Variables")]
    [Range (0f, 100f)] public float varGlucose; //Glucosa
    [Range (0f, 200f)] public float varInsuline; //Insulina

    [Header ("Barra Informacion")]
    public Text txtGlucose;
    public Text txtInsuline;

    [Header ("Camara")]
    public GameObject _camera; //Camara
    public Transform[] cameraViews; //Posiciones de la camara
    [Range (0f, 10f)] public float transitionSpeed; //Velocidad de la transicion (2f)
    Transform cameraCurrentView;
    bool enableTransition, isMoving;

    [Header ("Modelo")]
    public Transform _model;
    public BoxCollider boxCollider; //Collider del modelo para activar/desactivar si se quiere dejar de rotar
    [Range (0f, 10f)] public float rotationSpeed; //Velocidad a la que rota el modelo para volver a su posicion inicial (4f)
    [Range (0f, 1f)] public float timeTurnOffRotation; //Tiempo que tarda en apagar la rotacion del modelo (1f)
    Quaternion modelRotY; //Almacena la rotacion inicial del modelo
    bool isRotating; //Si el modelo se tiene que rotar para volver a su rotacion inicial


    
    void Awake () {
        cameraCurrentView = _camera.transform;
        modelRotY = _model.localRotation;
    }

    void Start () {
        txtGlucose.text = ((int)varGlucose).ToString ();
        txtInsuline.text = ((int)varInsuline).ToString ();
        cameraCurrentView = cameraViews[0]; //Posicion default
        enableTransition = true;
        isMoving = true;
        StartCoroutine (cameraMovement ()); //Da comienzo a la corrutina que mueve la camara
    }

    /*void Update () {

        if (Input.GetKeyDown (KeyCode.Alpha1) && enableTransition) {
            cameraMove (0, true, false);
        }

        if (Input.GetKeyDown (KeyCode.Alpha2) && enableTransition) {
            cameraMove (1, false, true);
        }

        if (Input.GetKeyDown (KeyCode.Alpha3) && enableTransition) {
            cameraMove (2, false, true);
        }

        if (Input.GetKeyDown (KeyCode.Alpha4) && enableTransition) {
            cameraMove (3, false, true);
        }

        if (Input.GetKeyDown (KeyCode.Alpha5) && enableTransition) {
            cameraMove (4, false, true);
        }

    }*/

    
    //Mueve la camara de posicion
    IEnumerator cameraMovement () {
        while (isMoving) {
            _camera.transform.position = Vector3.Lerp (_camera.transform.position, cameraCurrentView.localPosition, Time.deltaTime * transitionSpeed);

            Vector3 currentAngle = new Vector3 (
             Mathf.LerpAngle (_camera.transform.rotation.eulerAngles.x, cameraCurrentView.transform.localRotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
             Mathf.LerpAngle (_camera.transform.rotation.eulerAngles.y, cameraCurrentView.transform.localRotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
             Mathf.LerpAngle (_camera.transform.rotation.eulerAngles.z, cameraCurrentView.transform.localRotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

            _camera.transform.eulerAngles = currentAngle;

            if (isRotating) {
                Vector3 currentAngleModel = new Vector3 (0, Mathf.LerpAngle (_model.transform.rotation.eulerAngles.y, modelRotY.eulerAngles.y, Time.deltaTime * rotationSpeed),0);
                _model.transform.eulerAngles = currentAngleModel;
            }

            yield return new WaitForSeconds (0.01f);
        }
        StopCoroutine (cameraMovement ());
    }

    //Mueve la camara a una posicion, la bloquea para que no se pueda mover mas hasta que finalize el movimiento, 
    //puede deshabilitar la rotacion del modelo por parte del usuario, y si esta desacomodada la rotacion, la setea a como estaba al comienzo de la escena
    void cameraMove (int _pos, bool _isBoxEnable, bool _isRotating) {
        enableTransition = false;
        cameraCurrentView = cameraViews[_pos]; //Posicion a la que ira la camara
        boxCollider.enabled = _isBoxEnable; //Si habilita o deshabilita el Box Collider para que se mueva el modelo
        isRotating = _isRotating; //Si rota el modelo para que se acomode a la posicion inicial para que la camaras funcionen correctamente
        Invoke ("modelTurnOffRotation", timeTurnOffRotation);
    }

    //Apaga el reseteo de la rotacion del modelo para volver a su posicion inicial
    void modelTurnOffRotation () {
        isRotating = false;
        enableTransition = true;
    }

    //Se ejecuta esta funcion con los botones de show/back Quiz
    public void quizShow (bool _isActive) {
        //animQuiz.SetBool ("isActive", _isActive);
        if (_isActive) {
            camerasPosition (1);
            //sideScreen (!_isActive);
        } else {
            camerasPosition (0);
        }
    }

    //Controla las posiciones de las camaras
    void camerasPosition (int _position) {
        if (_position == 0) {
            if (enableTransition) cameraMove (_position, true, false); //Camara normal
        } else {
            if (enableTransition) cameraMove (_position, false, true); //Camaras con zoom
        }
    }



    //END
}
