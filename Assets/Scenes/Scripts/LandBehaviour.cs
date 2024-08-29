using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBehaviour : MonoBehaviour
{
    private GameObject manager;
    public int id;
    public Material empty;
    public Material selecting;
    // public Material ready;
    // public Material stand;
    // public Material shop;
    // public Material market;
    // public Material sanctuary;
    // public Material tower;
    // public Material temple;

    //Status
    //0 means empty
    //1 means unbuilt
    //2 means built
    //3 means selected
    //4 - stand
    //5 - shop
    //6 - market
    //7 - sanctuary
    //8 - tower
    //9 - temple
    public int status;
    void OnMouseOver() {
        if (Input.GetMouseButton(0)) {
            if ((status == 1) && (!manager.GetComponent<GridManager>().building.Contains(id))){
                GetComponent<MeshRenderer>().material = selecting;
                manager.GetComponent<GridManager>().building.Add(id);

            } 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Grid Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
