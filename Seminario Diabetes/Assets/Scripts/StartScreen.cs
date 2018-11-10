using UnityEngine;

public class StartScreen : MonoBehaviour {

    public GameObject _GAME; //Pantalla del juego
    Animator anim;

    void Start () {
        anim = GetComponent<Animator> ();
        _GAME.SetActive (false);
    }

    public void startGame () {
        _GAME.SetActive (true);
        anim.SetTrigger ("start");
    }

    public void off () {
        gameObject.SetActive (false);
	}
	
}
