using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yeahButton : MonoBehaviour
{
    
    public Sprite yeahOn1;
    public Sprite yeahOn2;
    public Sprite yeahOff1;
    public Sprite yeahOff2;
    Transform y;
    public bool yeahIsOn = false;
    bool yIsOn = true;
    
    
    
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        
        y = transform.Find("/Canvas/setting/Sound/y");
       
    }
    
    
    
    void OnClick()
    {
        if (yIsOn == true)
        {
            GetComponent<Image>().sprite = yeahOff1;
            yIsOn = false;
            y.GetComponent<Image>().sprite = yeahOff2;
        }                   
        else                
        {
            GetComponent<Image>().sprite = yeahOn1;
            yIsOn = true;
            y.GetComponent<Image>().sprite = yeahOn2;
        }
    }
}
