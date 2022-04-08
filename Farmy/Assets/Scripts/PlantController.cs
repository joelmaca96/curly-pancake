using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct PlantData
{
    int ID = 0;
    int type = 0;
    int health = 0;
    int growth = 0;
}

public class PlantController : MonoBehaviour
{
    private bool ItemOver = false, ItemClicked = false;
    public Material OriginalMaterial;
    public PlantData data;

    void Update()
    {
        CheckOver();
    }

    public void SetOver(bool value){
        ItemOver = value;
    }

    public void SetClicked(bool value){
        ItemClicked = value;
    }


    /************** PRIVATE FUNCTIONS *****************/
    private void CheckOver(){
        //comprobar si estamos apuntando con el raton
        if(ItemOver){
            this.GetComponent<Renderer>().material.color = Color.grey;
        }
        else{
            this.GetComponent<Renderer>().material = OriginalMaterial;
        }
        ItemOver = false;
    }
    
}
