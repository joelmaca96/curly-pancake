using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private CreationController CreationController;
    private GlobalGrid Mudgrid, PlantGrid;
    // Start is called before the first frame update
    private void Start()
    {
        Mudgrid = new GlobalGrid(10,10,4f);
        PlantGrid = new GlobalGrid(40,40,1f);

        CreationController = this.GetComponent<CreationController>() as CreationController;
    }

    void Update(){

        //Comprobar si estamos apuntando a un objeto seleccionable
        if(CreationController.OnOverCheck()){

        }

        //Sino, comprobar si estamos creando algo nuevo
        else{
            //Comprobar si se ha pulsado
            Vector3 ClickPose = CreationController.OnClickCheck();
            
            if(Vector3.zero != ClickPose){
                //si se ha pulsado, comprobar si está dentro de la rejilla
                //Y si no hay nada de antes
                Vector3 CreationPose = Mudgrid.AdaptToGrid(ClickPose);
                
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
    }

}
