using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationController : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Mud;
    private Camera cam;
    private int MudNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public bool OnOverCheck(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject item = hit.collider.gameObject;
            if(item.tag == "Selectable"){
                if(item.GetComponent<PlantController>()){
                    item.GetComponent<PlantController>().SetOver(true);
                }   
            }
        }
        return false;
    }

    public Vector3 OnClickCheck(){
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) ){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.point;
            }           
        }
        return Vector3.zero;
    }

    public void MudSpawn(Vector3 SpawnPoint){

        //Crear el objeto
        GameObject NewMud = Instantiate(Mud, SpawnPoint, Quaternion.Euler(0f, 90f, 0f),Parent.transform);
        NewMud.name = "Mud_" + MudNumber++.ToString();

        //Hacer que se vea el objeto
        NewMud.GetComponentInChildren<MeshRenderer>().enabled = true;
    }
}
