using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite soundOn1;
    public Sprite soundOn2;
    public Sprite soundOff1;
    public Sprite soundOff2;
    Transform s;
    public bool soundIsOn = false;
    bool sIsOn = true;
   
    
    
    
    
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        s=transform.Find("/Canvas/setting/Sound/s");
    }
   
    
    void OnClick()
    {
        if (sIsOn==true)
        {
            GetComponent<Image>().sprite = soundOff1;
            sIsOn = false;
            s.GetComponent<Image>().sprite = soundOff2;
        }
        else
        {
            GetComponent<Image>().sprite=soundOn1;
            sIsOn = true;
            s.GetComponent<Image>().sprite =soundOn2;
        }
    }

}
