using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class damagetext : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    float Timer = 1;
    void Start()
    {
        textMeshProUGUI=gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        Timer -= Time.fixedDeltaTime;
        if (Timer < 0)
            Destroy(gameObject);
    }
    void Update()
    {
        textMeshProUGUI.fontSize -= 0.01f;
    }
}
