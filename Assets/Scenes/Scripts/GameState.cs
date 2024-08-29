using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameState : MonoBehaviour
{
    public int level;
    public double timer;
    public int gold;
    public int favour;
    public int goldRate;
    public int favourRate;
    public TMP_Text timeLabel;
    public TMP_Text goldLabel;
    public TMP_Text favourLabel;
    private int[] levelScore = new int[5] {3000, 5000, 6000, 7500, 8500}; //{0,0,0,0,0};
    public bool playing;
    public GameObject gridManager;
    public GameObject dialogManager;

    public void AddRate(int income) {
        goldRate += income;
    }

    private void AddGold() {
        gold += goldRate;
    }

    public void AddFavour(int f) {
        favour += f;
    }

    public void AddFavourRate(int reputation) {
        favourRate += reputation;
    }
    private void AccumFavour() {
        favour += favourRate;
    }

    public bool ValidateGold(int size) {
        if (timer >= 0) {
            switch (size) {
                case 1:
                    if (gold >= 300) {
                        gold -= 300;
                        playing = true;
                        return true;
                    }
                    return false;
                case 2:
                    if (gold >= 650) {
                        gold -= 650;
                        playing = true;
                        return true;
                    }
                    return false;
                case 3:
                    if (gold >= 1500) {
                        gold -= 1500;
                        return true;
                    }
                    return false;
                case 4:
                    if (gold >= 1200) {
                        gold -= 1200;
                        return true;
                    }
                    return false;
                case 5:
                    if (gold >= 2400) {
                        gold -= 2400;
                        return true;
                    }
                    return false;
                case 9:
                    if (gold >= 5500) {
                        gold -= 5500;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        return false;
    }

    public void Reset() {
        playing = false;
        gold = 950;
        goldRate = 0;
        timer = 60;
        favour = 0;
        favourRate = 0;
        gridManager.GetComponent<GridManager>().Reset();
        InvokeRepeating("AddGold", 0, 1);
        InvokeRepeating("AccumFavour", 0, 1);
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //Screen.SetResolution(1600, 900, false);
        if (playing) {
            timer -= Time.deltaTime;
        }
        if (timer >= 0) {
            timeLabel.text = (Math.Round(timer, 0) + "");
            goldLabel.text = (gold + "");
            favourLabel.text = ("Favour: " + favour + " / " + levelScore[level]);
        } else if (playing) {
            if (favour >= levelScore[level]) {
                if (level >= 4) {
                    level = 0;
                } else {
                    level += 1;
                }
                favour = 0;
                dialogManager.GetComponent<DialogueManager>().ToggleConvo();
            } else {
                dialogManager.GetComponent<DialogueManager>().FailedRound();
            }
        // if (favour >= levelScore[level]) {
        //     favourLabel.text = "";
        //     if (playing) {
        //         level += 1;
        //         favour = 0;
        //         dialogManager.GetComponent<DialogueManager>().ToggleConvo();
        //     }
        // } else {
        //     if (playing) {
        //         dialogManager.GetComponent<DialogueManager>().FailedRound();
        //     }
        // }
            favourLabel.text = "";
            CancelInvoke();
            playing = false;
        }
    }
}
