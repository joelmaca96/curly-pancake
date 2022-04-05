using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Translationspeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckTranslation();

        CheckZoom();
    }

    void CheckTranslation(){
        //Movimiento frontal
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(0,Translationspeed*Time.deltaTime,Translationspeed*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(0,-Translationspeed*Time.deltaTime,-Translationspeed*Time.deltaTime);
        }

        //Movimiento lateral
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Translationspeed*Time.deltaTime,0,0);
        }

        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(-Translationspeed*Time.deltaTime,0,0);
        }
    }

    void CheckZoom(){
        //Zoom in
        if(Input.GetKey(KeyCode.KeypadPlus)){
            transform.Translate(0,0,Translationspeed*Time.deltaTime);
        }

        //Zoom out
        else if(Input.GetKey(KeyCode.KeypadMinus)){
            transform.Translate(0,0,-Translationspeed*Time.deltaTime);
        }
    }
}
