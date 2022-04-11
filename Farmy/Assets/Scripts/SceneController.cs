using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helpers;
public class SceneController : MonoBehaviour
{
    private CreationController CreationController;
    private GlobalGrid Mudgrid, PlantGrid;
    
    private Click Click= new Click();
    private void Start()
    {
        Mudgrid = new GlobalGrid(10,10,4f);
        PlantGrid = new GlobalGrid(40,40,1f);

        CreationController = this.GetComponent<CreationController>() as CreationController;
    }

    void Update(){

         //Si se ha clickado sobre un objeto del mundo
        (RaycastHit hit, bool Clicked) = Click.OnClickCheck();
        if(Clicked){
            GameObject item = hit.collider.gameObject;

            if(item.tag == "world"){
                 //si se ha pulsado, comprobar si está dentro de la rejilla y si es el mundo
                //Y si no hay nada de antes
                Vector3 CreationPose = Mudgrid.AdaptToGrid(hit.point);
                
                if(CreationPose != Vector3.zero){

                    //Crear el barro si no hay nada
                    //Comprobar si hay algo de antes
                    if(Mudgrid.GetGridArrayValue(CreationPose) == 0){
                        CreationController.MudSpawn(CreationPose);
                        Mudgrid.SetGridArrayValue(CreationPose, 1);
                    }
                }
            }
        }

        //Si tenemos el raton sobre un objeto seleccionable
        (GameObject OverITem, bool Over) = Click.OnOverCheck();
        if(Over){
            OverITem.GetComponent<PlantController>().SetOver(true);
        }

    }

}
