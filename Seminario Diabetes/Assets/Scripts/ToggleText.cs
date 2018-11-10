using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour {

    Text txtText; //Texto que cambiara de color
    public Material materialOn, materialOff; //Colores azul y gris, que cambiaran si el boton esta seleccionado o no
    Toggle _toggle; //Utilizado para dar color al boton seleccionado al comienzo de la escena

	void Awake () {
        txtText = GetComponent<Text> ();
        _toggle = GetComponentInParent<Toggle> ();
	}

    void Start () {
        onToggleChange (_toggle.isOn);
    }

    public void onToggleChange (bool isOn) {
        if (isOn) {
            txtText.material = materialOn;
        } else {
            txtText.material = materialOff;
        }
	}
}
