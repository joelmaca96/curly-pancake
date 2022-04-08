using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public bool ItemOver = false;
    public Material OriginalMaterial;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //comprobar si estamos apuntando con el raton
        if(ItemOver){
            
            this.GetComponent<Renderer>().material.color = Color.grey;
        }
        else{
            this.GetComponent<Renderer>().material = OriginalMaterial;
        }
        ItemOver = false;
        
    }

    public void SetOver(bool value){
        ItemOver = value;
    }
    
}
