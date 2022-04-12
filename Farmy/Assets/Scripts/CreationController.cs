using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class CreationController
{
    public GameObject Parent;
    public GameObject Mud, Tomate, Lechuga;
    private int MudNumber = 0, TomateNumber = 0, LechugaNumber = 0;
    
    public void PlantSpawn(Vector3 SpawnPoint, PlantType tipo){
        
        GameObject NewPlant = new GameObject();

        //Crear el objeto correspondiente
        switch (tipo)
        {
            case PlantType.Lechuga:
                NewPlant = Instantiate(Lechuga, SpawnPoint, Quaternion.Euler(0f, 90f, 0f),Parent.transform);
                NewPlant.name = "Lechuga_" + LechugaNumber++.ToString();

                //Asignarle un ID
                NewPlant.GetComponentInChildren<MudController>().data.ID = LechugaNumber;
                break;
            
            case PlantType.Tomate:
                NewPlant = Instantiate(Tomate, SpawnPoint, Quaternion.Euler(0f, 90f, 0f),Parent.transform);
                NewPlant.name = "Tomate_" + TomateNumber++.ToString();

                //Asignarle un ID
                NewPlant.GetComponentInChildren<MudController>().data.ID = TomateNumber;
                break;


            default:
                Debug.LogError("PlantSpawn not defined plant received [ERROR]");
                return;
        }
        
        //Hacer que se vea el objeto
        NewPlant.GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    public void MudSpawn(Vector3 SpawnPoint){

        //Crear el objeto
        GameObject NewMud = Instantiate(Mud, SpawnPoint, Quaternion.Euler(0f, 90f, 0f),Parent.transform);
        NewMud.name = "Mud_" + MudNumber++.ToString();

        //Asignarle un ID
        NewMud.GetComponentInChildren<MudController>().data.ID = MudNumber;

        //Hacer que se vea el objeto
        NewMud.GetComponentInChildren<MeshRenderer>().enabled = true;
    }   
}
