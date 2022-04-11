using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public struct MudData
{
    public int ID;
    public int waterLevel;
}

public class MudController : MonoBehaviour
{
    public MudData data = new MudData();
    private MudData OldData = new MudData();
    
    private float timer = 0.0f;

    private PlantController[] Planted = new PlantController [16];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debugData();

        timer += Time.deltaTime;

        if(timer > 2){
            timer = 0;
            if(data.waterLevel > 0) data.waterLevel--;
        }        
    }


    /*********** PRIVATE FUNCTIONS ******************/
    private void debugData(){
        if(!OldData.Equals(data)){
            Debug.Log(data.ID + " " + data.waterLevel);
            OldData = data;
        }
    }
}
