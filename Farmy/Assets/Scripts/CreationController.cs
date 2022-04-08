using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationController : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Mud;
    private int MudNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool OnOverCheck(){
        RaycastHit hit = GetHit();
        GameObject item = hit.collider.gameObject;
        if(ClickedItem != null){
            if(item.tag == "Selectable"){
                item.GetComponent<PlantController>().SetOver(true);
                return true;  
            }
            
        }
        return false;
    }

    public Vector3 OnClickCheck(){
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) ){
            RaycastHit hit = GetHit();
            GameObject item = hit.collider.gameObject;
            if(ClickedItem != null){
                if(ClickedItem.tag == "Selectable"){
                    ClickedItem.GetComponent<PlantController>().SetClicked(true);
                }
            }
            return ClickedItem.;
        }
        return Vector3.zero;
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

    /************** PRIVATE FUNCTIONS *****************/
    private RaycastHit GetHit(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit;
        }
        return null;       
    }
}
