using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace helpers
{
    
    public class Click{
        /************** PRIVATE FUNCTIONS *****************/
        public (GameObject OverObjevct, bool Over) OnOverCheck(){
            RaycastHit hit = GetHit();
            GameObject item = hit.collider.gameObject;
            if(item != null){
                if(item.tag == "Selectable" || item.tag == "Drawable"){
                    return (item, true);  
                }
            }
            return (item,false);
        }

        public (RaycastHit hit, bool Clicked) OnClickCheck(){
            RaycastHit hitleido = new RaycastHit();
            if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) ){
                hitleido = GetHit();
                return (hitleido, true);
            }
            return (hitleido, false);
        }


        /************** PRIVATE FUNCTIONS *****************/
        private RaycastHit GetHit(){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit;   
        }

    }
}
