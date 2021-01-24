using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeHolderAccess : MonoBehaviour
{
    GameObject[] shapes;
    MeshRenderer currentShape;
    
    float rotationAmount = 1;
    float prevX = 0, prevY = 0, prevZ = 0, prevP = 0;

    public int mode = 0;
    public int modeAxis = 0;

    TMPro.TMP_InputField _inputFloat;

    Slider xSlider;
    Slider ySlider;
    Slider zSlider;

    Slider pSlider;

    RectTransform _modeMenu;

    RectTransform _autoRotateButton;
    Vector3 modePosition;
    Vector3 autoButtonPosition;

    void Start()
    {
        shapes = GameObject.FindGameObjectsWithTag("Shapes");
        currentShape = shapes[0].GetComponent<MeshRenderer>();
        currentShape.enabled = true; 

         _modeMenu = GameObject.Find("ModeMenu").GetComponent<RectTransform>();
         modePosition = _modeMenu.transform.position;

         _autoRotateButton = GameObject.Find("AutoRotate").GetComponent<RectTransform>();
         autoButtonPosition = _autoRotateButton.transform.position;

        _inputFloat = GameObject.Find("DegreeInput").GetComponent<TMPro.TMP_InputField>();
        if(_inputFloat == null) 
            Debug.Log("Not found");
        
        xSlider = GameObject.Find("RotationX").GetComponent<Slider>();
        ySlider = GameObject.Find("RotationY").GetComponent<Slider>();
        zSlider = GameObject.Find("RotationZ").GetComponent<Slider>();
        pSlider = GameObject.Find("PositionZ").GetComponent<Slider>();
    }
            
    public void ChangeShape(int select){
        //Disable mesh on current shape
        currentShape.enabled = false;

        //Rotate shape holder back to default
        ResetRotation();

        //Change current shape to selected shape and display
        currentShape =shapes[select%shapes.Length].GetComponent<MeshRenderer>();
        currentShape.enabled = true;
    }

    public void RotateShape(int axis){
        if(mode == 1)
            axis = modeAxis;

        switch(axis){
            case 1:
                this.transform.Rotate(((xSlider.value > 0 && xSlider.value > prevX) || (xSlider.value < 0 && xSlider.value > prevX) )? rotationAmount : -rotationAmount,0.0f,0.0f,Space.Self);
                prevX = xSlider.value;
                break;
            case 2:
                this.transform.Rotate(0.0f,((ySlider.value > 0 && ySlider.value > prevY) || (ySlider.value < 0 && ySlider.value > prevY))? rotationAmount : -rotationAmount,0.0f,Space.Self);
                prevY = ySlider.value;
                break;
            case 3:
                this.transform.Rotate(0.0f,0.0f,((zSlider.value > 0 && zSlider.value > prevZ) || (zSlider.value < 0 && zSlider.value > prevZ))? rotationAmount : -rotationAmount,Space.Self);
                prevZ = zSlider.value;
                break;
            case 4:
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,((pSlider.value > 0 && pSlider.value > prevP) || (pSlider.value < 0 && pSlider.value > prevP)) ? this.transform.position.z + 0.125f : this.transform.position.z -0.125f); 
                prevP = pSlider.value;
                /*
                if(transform.position.z < 4.5)
                    this.transform.position = new Vector3(this.transform.position.x ,this.transform.position.y, 4.5f);
                    */
                break;
                    }
        
    }


    public void ResetRotation(){
        this.transform.rotation = Quaternion.identity;
        //Coroutine resets the rotation again to ensure rotation is 0
        StartCoroutine(WaitResetRotation());
        //Reset z position of shape
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);

        xSlider.value = 0;
        ySlider.value = 0;
        zSlider.value = 0;
        pSlider.value = 0;
    }

    private IEnumerator WaitResetRotation(){
        yield return new WaitForSeconds(0.001f);

        this.transform.rotation = Quaternion.identity;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
    }

    public void ChangeRotateAmount(){
        rotationAmount = float.Parse(_inputFloat.text);
    }


    public void OpenModeMenu(int open){
        if(open == 1){
            _modeMenu.transform.position = new Vector3(modePosition.x, 66 ,modePosition.z);
             _autoRotateButton.transform.position = new Vector3(autoButtonPosition.x, 200, autoButtonPosition.z);
        }else{
            _modeMenu.transform.position = new Vector3(modePosition.x, -1000 ,modePosition.z);
        }
        
         
    }
    public void SetMode(int _mode){

        switch(_mode){
            case 1:
            modeAxis = 1;
            break;
            case 2:
            modeAxis = 2;
            break;
            case 3:
            modeAxis = 3;
            break;
        }

        mode = 1;
        _autoRotateButton.transform.position = new Vector3(autoButtonPosition.x, 200, autoButtonPosition.z);
        _modeMenu.transform.position = new Vector3(modePosition.x,-1000 ,modePosition.z);

    }
}
