using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSensor : MonoBehaviour
{

    public GameObject state;
    public GameObject demo;
    public int threshold;
    
    void OnMouseOver() {
        demo.GetComponent<DemoManager>().Set(threshold);
    }

    void OnMouseExit() {
        demo.GetComponent<DemoManager>().Reset();
    }
    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameStateManager");
        demo = GameObject.Find("Demo Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
