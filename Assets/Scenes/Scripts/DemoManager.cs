using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoManager : MonoBehaviour
{
    public GameObject demo1;
    public GameObject demo2h;
    public GameObject demo2v;
    public GameObject demo3h;
    public GameObject demo3v;
    public GameObject demo4;
    public GameObject demo5h;
    public GameObject demo5v;
    public GameObject demo9;
    public TMP_Text demoText;
    public TMP_Text rulesText;
    public TMP_Text nameText;

    public void Set(int threshold) {
        rulesText.text = "";
        switch (threshold) {
            case 300:
                nameText.text = "Stand";
                demoText.text = "Income";
                demo1.SetActive(true);
                break;
            case 650:
                nameText.text = "Store";
                demoText.text = "Income";
                demo2h.SetActive(true);
                demo2v.SetActive(true);
                break;
            case 1200:
                nameText.text = "Market";
                demoText.text = "Income and favour";
                demo4.SetActive(true);
                break;
            case 1500:
                nameText.text = "Sanctuary";
                demoText.text = "Favour over time";
                demo3h.SetActive(true);
                demo3v.SetActive(true);
                break;
            case 2400:
                nameText.text = "Tower";
                demoText.text = "Favour";
                demo5h.SetActive(true);
                demo5v.SetActive(true);
                break;
            case 5500:
                nameText.text = "Temple";
                demoText.text = "Favour";
                demo9.SetActive(true);
                break;

        }
    }

    public void Reset() {
        nameText.text = "";
        rulesText.text = "";
        demoText.text = "";
        demo1.SetActive(false);
        demo2h.SetActive(false);
        demo2v.SetActive(false);
        demo4.SetActive(false);
        demo3h.SetActive(false);
        demo3v.SetActive(false);
        demo5h.SetActive(false);
        demo5v.SetActive(false);
        demo9.SetActive(false);
    }

    public void DisplayRules() {
        rulesText.text = "Gain favour from the gods using your amazing city building skills! Click and drag to draw buildings onto the grid! Gain gold and receive favour. To see valid building shapes, hover over the numbered squares.";

    }

    public void HideRules() {
        rulesText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
