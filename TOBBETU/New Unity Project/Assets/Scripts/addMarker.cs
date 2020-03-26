﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class addMarker : MonoBehaviour
{

    public GameObject marker;
	public GameObject obj;
	private Transform pos;
    private float control;
    public float clickDelta = 0.35f;  // Max between two click to be considered a double click
    private bool click = false;
    private float clickTime;
    
 
     void Update()
    {
     
        string name1="";
        string name2="";
        float doubleClickStart = 0;
        if(Input.GetMouseButtonDown(0) ){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
             if(Physics.Raycast(ray, out hitInfo)){
                var rig = hitInfo.collider.GetComponent<Rigidbody>();
                if (click && Time.time > (clickTime + clickDelta)){         
                    click = false;
                   
                       if(hitInfo.transform.gameObject.tag=="Lot"){
                            name1=hitInfo.transform.gameObject.name;
                           
                            Destroy(obj);
                            pos = hitInfo.collider.gameObject.transform;
                            if(pos != null){
                                obj = Instantiate(marker,pos.position + new Vector3(0,(float)0.40,0),pos.rotation);
                                control=1;
                                
                            }
                       }
                    doubleClickStart = Time.time;  

               
                }else{
                
                     if(click && Time.time <= (clickTime + clickDelta)) {
                             control=2;
                            
                            name2=hitInfo.transform.gameObject.name;
                            Debug.Log("secilen");
                            Debug.Log(name1);
                            Debug.Log("ikinci");
                            Debug.Log(name2);
                         if(name2.Equals(name1)){
                             Destroy(obj);
                         }
                            
                            click = false;
                        }else {
                            click = true;
                            clickTime = Time.time;
                        }
                }           
                        
                       
       
                   
            
        } 
                
             

        }
       
           

    }

 /*void OnDoubleClick()
 {
     Debug.Log("Double Clicked!");
     Destroy(obj);
 }
 void check(){
     if ((Time.time - doubleClickStart) < 0.3f){
        this.OnDoubleClick();
        doubleClickStart = -1;
     }else{
        doubleClickStart = Time.time;
        }
 }*/

}

