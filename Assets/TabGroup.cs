using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabGroup : MonoBehaviour
{
    public GameObject[] tabs;
    float tabLayoutHeight;
    int openCloseCount = 2;
    GameObject currentTab; 
    GameObject rotateModeButton;
    LayoutElement tabLayout;
    
   //Open the tab
    void Start(){
        for(int i=0;i<tabs.Length;i++){
            if(tabs[i].name == "shapeSelectTab")
                currentTab = tabs[i];
            
        }
        
        tabLayout = GameObject.Find("MenuPanel").GetComponent<LayoutElement>();
        tabLayoutHeight = tabLayout.preferredHeight;
        tabLayout.preferredHeight = 0;

        rotateModeButton = GameObject.Find("rotateModeButton");
        
    }
    public void SwapTabs(string _tab){
        //Open and close menu
        if(_tab == "closeOpen"){
            openCloseCount++;
            
            tabLayout.preferredHeight = (openCloseCount%2 == 0) ? 0 : tabLayoutHeight;
            return;
        }
        //Open according tab
        currentTab.SetActive(false);

        for(int i=0;i<tabs.Length;i++){
            if(tabs[i].name == _tab){
                currentTab = tabs[i];
                currentTab.SetActive(true);
            }else{
                tabs[i].SetActive(false);
            }

                
        }

    }
    


}
