using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    Image img; //Accede a la imagen para activar/desactivar el Raycast, y evitar que los botones del fondo se activen al tocarlos

    void Awake () {
        img = GetComponent<Image> ();
    }

    public void fadeOn () {
        img.raycastTarget = true;
    }

    public void fadeOff () {
        img.raycastTarget = false;
    }
    

}
