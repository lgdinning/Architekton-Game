using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndicatorManager : MonoBehaviour
{
    public GameObject state;
    public GameObject demo;
    public int threshold;
    public Color active;
    private Color inactive;



    
    // Start is called before the first frame update
    void Start()
    {
        inactive = new Color(125, 102, 102);
    }

    // Update is called once per frame
    void Update()
    {
        if (state.GetComponent<GameState>().gold >= threshold) {
            this.GetComponent<Image>().color = active;
        } else {
            this.GetComponent<Image>().color = inactive;
        }
    }
}
