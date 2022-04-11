using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helpers;

public class Regadera : MonoBehaviour
{
    private Click click = new Click();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        (RaycastHit hit, bool Clicked) = click.OnClickCheck();

        if(Clicked){
            GameObject ClickedItem = hit.collider.gameObject;
            if(ClickedItem.tag == "Mud"){
                MudController Mud = ClickedItem.GetComponentInChildren<MudController>() as MudController;
                Mud.data.waterLevel = 100;
            }
        }
    }
}
