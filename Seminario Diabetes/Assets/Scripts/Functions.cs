using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Functions : MonoBehaviour
{
    //Patron Singleton
    private static Functions _instance;
    public static Functions Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("Functions");
                go.AddComponent<Functions>();
                go.transform.parent = GameObject.Find("Functions Manager").transform;
            }

            return _instance;
        }

    }


    private void Awake()
    {
        _instance = this;
    }


    //----------------------------------------------------------------------------------------------+
    //                                         Campos                                               |
    //----------------------------------------------------------------------------------------------+

        public float betaCells  = 1;
        public float alphaCells = 1;

    //----------------------------------------------------------------------------------------------+
    //                                        Propiedades                                           |
    //----------------------------------------------------------------------------------------------+

    //Defino a Insuline como una propiedad con logica que devuelve el campo insuline
    private float insuline;
    public float Insuline
    {
        get
        {
            return insuline;
        }
        set
        {
            if (value > 60 && value < 140)
            {
                insuline = value;
            }
            else if (value < 60)
            {
                insuline = 60;
            }
            else if(value >180)
            {
                insuline = 160;
            }
        }

    }

    //Defino a Glucose como una propiedad con logica que devuelve el campo glucose
    private float glucose;
    public float Glucose
    {
        get
        {
            return glucose;
        }
        set
        {
            if (value > 82 && value < 180)
            {
                glucose = value;
            }
            else if(value < 82)
            {
                glucose = 82;
            }
            else if(value > 180)
            {
                glucose = 180;
            }
        }

    }

    private float glucagon;
    public float Glucagon
    {
        get
        {
            return glucagon;
        }
        set
        {
            if (value > 82 && value < 180)
            {
                glucagon = value;
            }
            else if (value < 82)
            {
                glucagon = 82;
            }
            else if (value > 180)
            {
                glucagon = 180;
            }
        }

    }

    private float factResInsuline;
    public float FactResInsuline
    {
        get
        {
            return factResInsuline;
        }
        set
        {
            if (value >= 0 && value <= 1)
            {
                factResInsuline = value;
            }
            else if (value < 0)
            {
                factResInsuline = 0;
            }
            else if (value > 1)
            {
                factResInsuline = 1;
            }
        }

    }


    //----------------------------------------------------------------------------------------------+
    //                                         Metodos                                              |
    //----------------------------------------------------------------------------------------------+



    public void InsulineGlucose()
    {
        Glucose = Insuline / Glucose; 
    }

    

}
