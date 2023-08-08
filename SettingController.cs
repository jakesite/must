using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public GameObject soundButton;
    public GameObject yeahButton;
    SoundButton s;
    yeahButton y;

    void Start()
    {
        s=soundButton.GetComponent<SoundButton>();
        y=yeahButton.GetComponent<yeahButton>();
        Button settingBtn=GetComponent<Button>();
        settingBtn.onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        
    }
    void OnButtonClick()
    {
        if(s.soundIsOn==false)
        {
            soundButton.SetActive(true);
            s.soundIsOn = true;
        }
            
            
        else
        {
            soundButton.SetActive(false);
            s.soundIsOn = false;
        }
        if (y.yeahIsOn == false)
        {
            yeahButton.SetActive(true);
            y.yeahIsOn = true;
        }
        else
        {
            yeahButton.SetActive(false);
            y.yeahIsOn = false;
        }

            
            

    }
    
}
