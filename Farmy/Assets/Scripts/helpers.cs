using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Types
{
    public enum PlantType
    {
        Tomate,
        Lechuga
    }
    
}


namespace helpers
{
    
    public class Click{
        /************** PUBLIC FUNCTIONS *****************/
        public (GameObject OverObjevct, bool Over) OnOverCheck(){
            GameObject item =  GetHit().collider.gameObject;
            if(item != null){
                if(item.tag == "Selectable" || item.tag == "Drawable"){
                    return (item, true);  
                }
            }
            return (item,false);
        }

        public (RaycastHit hit, bool Clicked) OnClickCheck(){
            if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) ){
                return ( GetHit(), true);
            }
            return (new RaycastHit(), false);
        }


        /************** PRIVATE FUNCTIONS *****************/
        private RaycastHit GetHit(){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray, out hit);
            return hit;   
        }

    }
}
