using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    int menuState = 1;
    RectTransform _menu;
    RectTransform _rotationMenu;
    Vector3 menuPosition;
    Vector3 rotateMenuPosition;

    
    void Start(){
        _menu = this.gameObject.GetComponent<RectTransform>();
        _rotationMenu = GameObject.Find("RotationMenu").GetComponent<RectTransform>();

        menuPosition = _menu.position;
        rotateMenuPosition = _rotationMenu.position;
    }
    public void OpenMenu(){
        menuState++;

        _menu.position = new Vector3(menuPosition.x, (menuState % 2 == 0)? 66 : -38, menuPosition.z);
            
    }

    public void OpenRotationMenu(int state){
            _rotationMenu.position = new Vector3(menuPosition.x, (state % 2 == 0)? 33 : -1000, menuPosition.z);
    }

    public void QuitApp(){
        Application.Quit();
    }
}
