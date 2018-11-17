using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {

    [Header ("Quiz")]
    public Text txtTitle;
    public Text txtCounter;
    public Text txtOption1;
    public Text txtOption2;
    public Text txtOption3;
    public Text txtOption4;
    public Button btnOption1;
    public Button btnOption2;
    public Button btnOption3;
    public Button btnOption4;
    public Image imgOption1;
    public Image imgOption2;
    public Image imgOption3;
    public Image imgOption4;
    public int maxQuestions; //Cantidad de preguntas totales a colocar en el juego (10)
    int counter; //Contador de preguntas
    int random1, random2, random3; //Randoms para seleccionar de manera aleatorias las preguntas falsas.
    int answersTrue; //Valor entero que representa la respuesta correcta.
    List<string> listQuestions = new List<string> (); //Lista que almacena las preguntas
    List<string> arrayQuestions = new List<string> { //Composicion: PREGUNTA_RespuestaCorrecta_OtrasRespuestasFalsas
        "¿Cuántas carreras se dictan actualmente?_18_26_22_12_14_10",
        "¿Dónde funciona el Laboratorio Audiovisual?_1er Piso_Planta Baja_6to Piso_Biblioteca_7mo Piso_2do Piso",
        "¿Dónde funciona el aula Telemática (para Modalidad Distancia)?_7mo Piso_Planta Baja_6to Piso_Biblioteca_1er Piso_2do Piso",
        "IES está presente en.._Facebook, Instagram, Twitter y Linkedin_Instagram, Facebook y Snapchat_Twitter, Instagram, Facebook y Snapchat_Linkedin, Instagram y Twitter_Instagram y Facebook_Facebook y Twitter",
        "¿Cuál es la carrera más antigua?_Informática_Marketing_Publicidad_Videojuegos_Recursos Humanos_Relaciones Públicas",
        "¿Cómo se llama el guardia de la tarde?_Alejandro_Juan_Mauricio_Pablo_Rodrigo_Ricardo",
        "¿Cómo se llama el guardia de la mañana?_Pablo_Juan_Mauricio_Alejandro_Rodrigo_Ricardo",
        "Las siglas \"TID\" significan.._Texto Interactivo Digital_Texto Interactivo Didáctico_Temario Interactivo Digital_Temario Interdisciplinario Digital_Texto Interdisciplinario Didáctico_Temario Interactivo Didáctico",
        "Las siglas \"DOA\" significan.._Departamento de Orientación al Alumno_Dirección de Orientacion al Alumno_Departamento de Orientación y Ayuda_Dirección para Organización y Asesoramiento_Dirección para Orientación y Ayuda_Departamento para Organización y Asesoramiento",
        "¿Cuánto duran los cursos online IES GROW?_2 y 4 meses_2 meses_3 meses_4 meses_1 y 3 meses_3 y 5 meses"
    };
    Color colorNormal = new Color32 (11, 145, 167, 255);
    Color colorTrue = new Color32 (92, 169, 95, 255);
    Color colorFalse = new Color32 (174, 99, 99, 255);
    int answersChoosed; //Almacena el valor entero que representa la respuesta elegida.
    int answersCorrect, answersIncorrect; //Contador de respuesta correcta/incorrecta
    string[] questions;
    string[] answers_true;
    string[] answers_false_1;
    string[] answers_false_2;
    string[] answers_false_3;



    void Awake () {
        questions = new string[arrayQuestions.Count];
        answers_true = new string[arrayQuestions.Count];
        answers_false_1 = new string[arrayQuestions.Count];
        answers_false_2 = new string[arrayQuestions.Count];
        answers_false_3 = new string[arrayQuestions.Count];
        counter = 0;
        answersTrue = 0;
        generateRandoms ();
    }
	
	void Start () {
        startQuiz (); //Setea de entrada el Quiz
    }

    void startQuiz () {
        listQuestions.AddRange (arrayQuestions); //Paso toda la lista original a una local para no borrar el contenido de la original
        if (maxQuestions > arrayQuestions.Count) { //Si las preguntas a utilizar superan el tamaño de la lista, la cantidad de preguntas se igualan al tamaño de la lista
            maxQuestions = arrayQuestions.Count;
            print ("FIX - Preguntas a utilizar seteada a " + maxQuestions.ToString ());
        }
        for (int i = 0; i < maxQuestions; i++) {
            int random = Random.Range (0, listQuestions.Count); //Selecciona preguntar aleatoriamente
            string[] tempArray = listQuestions[random].Split ('_'); //Separa el String
            questions[i] = tempArray[0]; //Pregunta
            answers_true[i] = tempArray[1]; //Respuesta correcta
            answers_false_1[i] = tempArray[random1]; //Respuesta incorrecta aleatoria 1
            answers_false_2[i] = tempArray[random2]; //Respuesta incorrecta aleatoria 2
            answers_false_3[i] = tempArray[random3]; //Respuesta incorrecta aleatoria 3
            listQuestions.RemoveAt (random); //Remueve el string usado para que no se repita
            tempArray = null;
        }
        listQuestions.Clear ();

        txtCounter.text = (counter + 1).ToString () + "/" + maxQuestions.ToString (); //Indicador de pregunta actual y totales
        txtTitle.text = questions[counter]; //Pregunta
        generateRandomGame (); //Se setea un random para colocar las respuestas en los botones de manera aleatorio, y marcar cual es la correcta
    }

    //Genera valores random, que no se repiten, para elegir al azar 3 respuestas falsas
    void generateRandoms () {
        string[] totalQuestions = arrayQuestions[0].Split ('_');
        random1 = Random.Range (2, totalQuestions.Length);
        random2 = Random.Range (2, totalQuestions.Length);
        while (random2 == random1) {
            random2 = Random.Range (2, totalQuestions.Length);
        }
        random3 = Random.Range (2, totalQuestions.Length);
        while (random3 == random1 && random3 == random2) {
            random3 = Random.Range (2, totalQuestions.Length);
        }
    }

    //Se setea un random para colocar las respuestas en los botones de manera aleatorio, y marcar cual es la correcta
    void generateRandomGame () {
        int randomAnswers = Random.Range (0, 24);
        switch (randomAnswers) {
            case 0:
                txtOption1.text = answers_true[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 1;
                break;
            case 1:
                txtOption1.text = answers_true[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_false_3[counter];
                txtOption4.text = answers_false_2[counter];
                answersTrue = 1;
                break;
            case 2:
                txtOption1.text = answers_true[counter];
                txtOption2.text = answers_false_2[counter];
                txtOption3.text = answers_false_1[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 1;
                break;
            case 3:
                txtOption1.text = answers_true[counter];
                txtOption2.text = answers_false_2[counter];
                txtOption3.text = answers_false_3[counter];
                txtOption4.text = answers_false_1[counter];
                answersTrue = 1;
                break;
            case 4:
                txtOption1.text = answers_true[counter];
                txtOption2.text = answers_false_3[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_false_1[counter];
                answersTrue = 1;
                break;
            case 5:
                txtOption1.text = answers_true[counter];
                txtOption2.text = answers_false_3[counter];
                txtOption3.text = answers_false_1[counter];
                txtOption4.text = answers_false_2[counter];
                answersTrue = 1;
                break;

            case 6:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_true[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 2;
                break;
            case 7:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_true[counter];
                txtOption3.text = answers_false_3[counter];
                txtOption4.text = answers_false_2[counter];
                answersTrue = 2;
                break;
            case 8:
                txtOption1.text = answers_false_2[counter];
                txtOption2.text = answers_true[counter];
                txtOption3.text = answers_false_1[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 2;
                break;
            case 9:
                txtOption1.text = answers_false_2[counter];
                txtOption2.text = answers_true[counter];
                txtOption3.text = answers_false_3[counter];
                txtOption4.text = answers_false_1[counter];
                answersTrue = 2;
                break;
            case 10:
                txtOption1.text = answers_false_3[counter];
                txtOption2.text = answers_true[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_false_1[counter];
                answersTrue = 2;
                break;
            case 11:
                txtOption1.text = answers_false_3[counter];
                txtOption2.text = answers_true[counter];
                txtOption3.text = answers_false_1[counter];
                txtOption4.text = answers_false_2[counter];
                answersTrue = 2;
                break;
            case 12:
                txtOption1.text = answers_false_2[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_true[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 3;
                break;
            case 13:
                txtOption1.text = answers_false_2[counter];
                txtOption2.text = answers_false_3[counter];
                txtOption3.text = answers_true[counter];
                txtOption4.text = answers_false_1[counter];
                answersTrue = 3;
                break;
            case 14:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_false_2[counter];
                txtOption3.text = answers_true[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 3;
                break;
            case 15:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_false_3[counter];
                txtOption3.text = answers_true[counter];
                txtOption4.text = answers_false_2[counter];
                answersTrue = 3;
                break;
            case 16:
                txtOption1.text = answers_false_3[counter];
                txtOption2.text = answers_false_2[counter];
                txtOption3.text = answers_true[counter];
                txtOption4.text = answers_false_1[counter];
                answersTrue = 3;
                break;
            case 17:
                txtOption1.text = answers_false_3[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_true[counter];
                txtOption4.text = answers_false_2[counter];
                answersTrue = 3;
                break;
            case 18:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_false_3[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_true[counter];
                answersTrue = 4;
                break;
            case 19:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_false_2[counter];
                txtOption3.text = answers_false_3[counter];
                txtOption4.text = answers_true[counter];
                answersTrue = 4;
                break;
            case 20:
                txtOption1.text = answers_false_2[counter];
                txtOption2.text = answers_false_3[counter];
                txtOption3.text = answers_false_1[counter];
                txtOption4.text = answers_true[counter];
                answersTrue = 4;
                break;
            case 21:
                txtOption1.text = answers_false_2[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_false_3[counter];
                txtOption4.text = answers_true[counter];
                answersTrue = 4;
                break;
            case 22:
                txtOption1.text = answers_false_3[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_true[counter];
                answersTrue = 4;
                break;
            case 23:
                txtOption1.text = answers_false_3[counter];
                txtOption2.text = answers_false_2[counter];
                txtOption3.text = answers_false_1[counter];
                txtOption4.text = answers_true[counter];
                answersTrue = 4;
                break;

            default:
                txtOption1.text = answers_false_1[counter];
                txtOption2.text = answers_false_1[counter];
                txtOption3.text = answers_false_2[counter];
                txtOption4.text = answers_false_3[counter];
                answersTrue = 1;
                print ("ERROR en el random");
                break;
        }
    }

    //Al tocar una respuesta, se ejecuta esta funcion
    public void selectOption (int _option) {
        if (_option == answersTrue) {
            answersCorrect++; //VERDADERO
        } else {
            answersIncorrect++; //FALSO
        }

        if (counter < maxQuestions - 1) {
            counter++;
        } else {
            counter++;
            btnOption1.interactable = btnOption2.interactable = btnOption3.interactable = btnOption4.interactable = false;
            txtTitle.text = "Fin de la partida";
            txtOption1.text = "-";
            txtOption2.text = "-";
            txtOption3.text = "-";
            txtOption4.text = "-";
            return;
        }

        txtCounter.text = (counter + 1).ToString () + "/" + maxQuestions.ToString (); //Indicador de pregunta actual y totales
        txtTitle.text = questions[counter]; //Pregunta
        generateRandomGame (); //Se setea un random para colocar las respuestas en los botones de manera aleatorio, y marcar cual es la correcta
    }




    //END
}
