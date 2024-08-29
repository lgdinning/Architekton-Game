using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public bool active = true;
    public GameObject gameState;
    public int length, height;
    public GameObject tile;
    public float x, y;
    public GameObject[] grid;
    public List<int> building = new List<int>();
    public Material m1; //empty
    public Material m2; //ready
    public Material m3;
    public Material m4;
    public Material m5;
    public Material m6;
    public Material m7;
    public Material m8;
    public Material m9;
    
    public void ToggleActive() {
        active = !active;
    }

    // Start is called before the first frame update
    void Start() {
        int statAdd;
        grid = new GameObject[length * height];
        for (int i = 0; i < length * height; i++) {
            statAdd = 0;
            grid[i] = Instantiate(tile, new Vector3(x * (i%height), 0, y * (i/length)), tile.transform.rotation);
            LandBehaviour scrpt = grid[i].GetComponent<LandBehaviour>();
            grid[i].GetComponent<LandBehaviour>().id = i;
            if (Random.Range(1,11) < 8) {
                statAdd = 1;
            } 
            grid[i].GetComponent<LandBehaviour>().status = statAdd;
            switch (statAdd) {
                case 0:
                    grid[i].GetComponent<MeshRenderer>().material = m1;
                    break;
                case 1:
                    grid[i].GetComponent<MeshRenderer>().material = m2;
                    break;
            }
        }
    }

    public void Reset() {
        for (int i = 0; i < grid.Length; i++) {
            if (Random.Range(1,11) < 8) {
                grid[i].GetComponent<LandBehaviour>().status = 1;
                grid[i].GetComponent<MeshRenderer>().material = m2;
            } else {
                grid[i].GetComponent<LandBehaviour>().status = 0;
                grid[i].GetComponent<MeshRenderer>().material = m1;
            }
        }
    }

    bool validate(List<int> shape) {
        switch (shape.Count) {
            //Cover singleton shapes
            case 1:
                return true;
            //Cover shapes with 2 spaces
            case 2:
                if ((shape[1]) == (shape[0]+1)) {
                    return true;
                } else if ((shape[1]) == (shape[0]+length)) {
                    return true;
                } else {
                    return false;
                }
            //Cover shapes with 3 spaces
            case 3:
                if (shape[1] == (shape[0] + 1)) {
                    if (shape[2] == (shape[1] + 1)) {
                        return true;
                    }
                } else if (shape[1] == (shape[0] + length)) {
                    if (shape[2] == (shape[1] + length)) {
                        return true;
                    }
                }
                return false;
            //Cover shapes with 5 spaces
            case 4:
                if ((shape[1] == (shape[0] + 1)) && (shape[3] == (shape[2] + 1))) {
                    if (shape[2] == (shape[0] + length)) {
                        return true;
                    }
                }
                return false;
            case 5:
                int x = shape[1] - shape[0];
                if ((x == 1) || (x == length)) {
                    for (int i = 2; i < 4; i++) {
                        if (!(shape[i+1] == (shape[i] + x))) {
                            return false;
                        }
                    }
                    return true;
                } else {
                    return false;
                }
            case 9:
                if ((shape[6] == (shape[3]+length)) && (shape[3] == (shape[0]+length))) {
                    for (int i = 1; i < 3; i++) {
                        if (!((shape[i] == (shape[i-1]+1)) && (shape[i+3] == (shape[i+2]+1)) && (shape[i+6] == (shape[i+5]+1)))) {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            building.Sort();
            if (validate(building)) {
                if (gameState.GetComponent<GameState>().ValidateGold(building.Count)) {
                    switch (building.Count) {
                        case 1:
                            foreach (int i in building) {
                                grid[i].GetComponent<MeshRenderer>().material = m4;
                                grid[i].GetComponent<LandBehaviour>().status = 2;
                            }
                            gameState.GetComponent<GameState>().AddRate(25);
                            break;
                        case 2:
                            foreach (int i in building) {
                                grid[i].GetComponent<MeshRenderer>().material = m5;
                                grid[i].GetComponent<LandBehaviour>().status = 2;
                            }
                            gameState.GetComponent<GameState>().AddRate(55);
                            break;
                        case 3:
                            foreach (int i in building) {
                                grid[i].GetComponent<MeshRenderer>().material = m3;
                                grid[i].GetComponent<LandBehaviour>().status = 2;
                            }
                            gameState.GetComponent<GameState>().AddFavour(400);
                            gameState.GetComponent<GameState>().AddFavourRate(25);
                            break;
                        case 4:
                            foreach (int i in building) {
                                grid[i].GetComponent<MeshRenderer>().material = m7;
                                grid[i].GetComponent<LandBehaviour>().status = 2;
                            }
                            gameState.GetComponent<GameState>().AddRate(80);
                            gameState.GetComponent<GameState>().AddFavourRate(15);
                            break;
                        case 5:
                            foreach (int i in building) {
                                grid[i].GetComponent<MeshRenderer>().material = m6;
                                grid[i].GetComponent<LandBehaviour>().status = 2;
                            }
                            gameState.GetComponent<GameState>().AddFavour(2000);
                            break;
                        case 9:
                            foreach (int i in building) {
                                grid[i].GetComponent<MeshRenderer>().material = m8;
                                grid[i].GetComponent<LandBehaviour>().status = 2;
                            }
                            gameState.GetComponent<GameState>().AddFavour(4000);
                            break;
                    }      
                } else {
                    foreach (int i in building) {
                        grid[i].GetComponent<MeshRenderer>().material = m2;
                    }
                }
            } else {
                foreach (int i in building) {
                    grid[i].GetComponent<MeshRenderer>().material = m2;
                }
            }
            building.Clear();
            //Debug.Log(building.Count + "");
        }
    }
}
