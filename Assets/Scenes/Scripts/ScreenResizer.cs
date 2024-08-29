using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenResizer : MonoBehaviour
{
    
    public int w = Screen.height;
    public int l = Screen.width;
    public int lastL = Screen.width;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != lastL) {
            Screen.SetResolution(Screen.width, (int)Math.Round(Screen.width / 2.268), FullScreenMode.Windowed);
        }
    }
}
