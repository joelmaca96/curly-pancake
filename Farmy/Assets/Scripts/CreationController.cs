using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationController : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Mud;
    private int MudNumber = 0;
    
    

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
