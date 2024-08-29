using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text words;
    public GameObject state;
    public GameObject gridM;
    public GameObject godImage;
    public GameObject godImage1;
    public GameObject godImage2;
    public bool failed = false;
    public List<List<List<string>>> godScripts = new List<List<List<string>>>();
    public List<List<string>> zeusScript = new List<List<string>>();
    public List<List<string>> aphroditeScript = new List<List<string>>();
    public List<List<string>> currGodScript = new List<List<string>>();
    [System.NonSerialized] public string failMessage = "It appears your architecture has gone unnoticed by the gods.";
    
    [System.NonSerialized] public List<string> zeus1 = new List<string>() {"It appears your architecture has attracted divine attention. Press space to be beheld.", 
    "IT IS I, ZEUS!",
    "THE FLASH THAT LIGHTS THE SKY.",
    "THE THUNDER THAT SHAKES THE GROUND.",
    "Do applaud.",
    "Yes thank you, that’s adequate.",
    "Well I’ve seen your city.",
    "Lovely city, really.",
    "A couple notes.",
    "First, perhaps more cattle sacrifices? I do enjoy a good cattle sacrifice.",
    "And second, I’m thinking a statue of an eagle.",
    "But I must be off. Important Olympus business I assure you.",
    "Keep up the whole… whatever it is you’re doing down here."};
    [System.NonSerialized] public List<string> zeus2 = new List<string>() {"IT IS I, ZEUS!",
    "THE FLASH THAT LIGHTS THE SKY.",
    "THE THUNDER THAT SHAKES THE GROUND.",
    "Oh. Yes it’s you again." ,
    "Still alive I see.",
    "That’s good. That’s good.",
    "You’re doing well for a mortal.",
    "Two cities now in my honour.",
    "That’s cool.",
    "...",
    "Well, good chat. I’ve got to go. Olympus stuff. You know the drill.",
    "Your whole city thing is really coming along. Keep up the, uh, cities."};
    [System.NonSerialized] public List<string> zeus3 = new List<string>() {"It is I, Zeus.",
    "Flash- sky.",
    "Thunder, ground.",
    "You know the whole thing.",
    "Yes I’m doing alright.",
    "It’s just like…",
    "Do you ever feel like you’re just into cattle sacrifice because you’re supposed to be?",
    "I mean everyone always speaks my name before killing a cow.",
    "Like am I the god of dead cows now?",
    "Like why can’t they ever invoke my name before watching a sunset?",
    "Thanks for listening, I guess.",
    "Don’t tell anyone I said this.",
    "I’ll smite you.",
    "And I noticed the eagle statue you put up this time.",
    "It’s nice."};
    [System.NonSerialized] public List<string> zeus4 = new List<string>() {"Mortal, I was watching down from upon high the other day.",
    "I saw a bunch of you, uh, things sitting around a bonfire making merry.",
    "And it just looked so normal.",
    "It’s like, I feel like it was just yesterday that Prometheus stole my fire and gave it to you all.",
    "But in a way it feels like it’s always been there too you know?",
    "I just think about Prometheus getting his liver eaten by a giant eagle every day.",
    "And I just don’t feel like the same Zeus that sentenced him to it for eternity.",
    "Like maybe two months of giant eagle would have been appropriate.",
    "But eternity? I just can’t work up the same anger I used to.",
    "I haven’t even talked about your new city yet.",
    "This one’s quite grand, even I must admit.",
    "...",
    "Maybe I’ll start giving Prometheus weekends off."};
    [System.NonSerialized] public List<string> zeus5 = new List<string>() {"Greetings mortal.",
    "I got lunch with Prometheus this weekend.",
    "I ended up giving him weekends off.",
    "I would have liked a bit more gratitude from him-",
    "but once we got to talking, he wasn't so disgracious.",
    "Nearly drank me under the table actually.",
    "Who knew regrowing your liver every day would give you such a tolerance.",
    "Perhaps it's not such a bad thing for humans to have fire.",
    "You're not all so crude.",
    "I mean look around us.",
    "This makes five cities in my honour now.",
    "You've improved.",
    "And might I say, the statue of me in this one is really quite flattering.",
    "You've earned my blessing. And my favour.",
    "If you ever need anyone smited, let me know."
    };

    [System.NonSerialized] public List<string> aph1 = new List<string>() {"It appears your architecture has attracted divine attention. Press space to be beheld.",
    "Oh so are you the one who built me this magnificent city?",
    "It is SO cute.",
    "I mean SO cute.",
    "If you put as much work into your outfit as you did into your architecture,",
    "I bet you would be SUCH a looker.",
    "Oh my god.",
    "I just had a GREAT idea.",
    "You were SO sweet to build this city in my honour.",
    "And I'm Aphrodite, the goddess of love!",
    "So I can like, TOTALLY make you dateable!",
    "I mean I wouldn't date you myself.",
    "Because like, could you imagine?",
    "But I can TOTALLY help you out.",
    "Next time I see you I'll give you SO many tips."};
    [System.NonSerialized] public List<string> aph2 = new List<string>() {"Oh my god hii!",
    "Thanks for the city!",
    "It's like, JUST as cute as the last one.",
    "I don't even care what the other gods say about you mortals.",
    "Personally, i LOVE your quaint sensibilities.",
    "But I owe you some dating tips don't I!",
    "So there was this one girl, Atalanta.",
    "And she was like REALLY fast.",
    "And Hippomenes was like super into her.",
    "But Atalanta was all: 'I'll only date me if you beat me in a race.'",
    "And then Hippomenes was all: 'Ya ok!'",
    "But it like totally wasn't 'ya ok'.",
    "Atalanta was like totally beating him.",
    "But then I showed up and I was like 'nuh uh'.",
    "I knew Atalanta should like totally get into the dating game.",
    "So I distracted her with some REALLY cute golden apples.",
    "And Hippomenes ended up winning!",
    "So like, maybe if you can run really fast you'll have more luck!",
    "I mean I helped there too.",
    "But if I weren't there, Hippomenes would have had to run like REALLY fast.",
    "So maybe try that.",
    "Alright well I've gotta go! I'll see you later!"
    };
    [System.NonSerialized] public List<string> aph3 = new List<string>() {"Another beautiful city!",
    "You know you're pretty good at that for a mortal!",
    "I've gotta say I have been LOVING all this attention.",
    "Ares has been like, SO wrapped up in the Trojan war lately.",
    "So we've barely gotten to go out.",
    "My husband Hephaestus is around but he's kind of gross. ):",
    "I was flirting with this guy Adonis for a little bit.",
    "Total dreamboat.",
    "But he got gored by a wild boar.",
    "I mean I got Zeus to bring him back to life.",
    "But the whole thing kind of gave me the ick.",
    "Love is so difficult.",
    "But if it's hard for me, it should totally be hard for you too!",
    "So it's to be expected!",
    "Alright it was SO nice catching up! See you later!"
    };
    [System.NonSerialized] public List<string> aph4 = new List<string>() {"Oh my god you are NOT going to believe this.",
    "So I FINALLY got Ares to step away from the war for a second.",
    "And he was all 'If you didn't want me to be so busy you shouldn't have started the Trojan War'.",
    "And like MAYBE I started it a little.",
    "But like, the AUDACITY of this man.",
    "But whatever, he's cute. We can still salvage this night.",
    "So we're out at dinner, we just finished our appetizers.",
    "When this GIANT. NET. comes down from the ceiling and traps us.",
    "So out comes Hephaestus and he's all:",
    "I can't believe you were messing around behind my back.",
    "And like ya maybe I was but at least I'm not running around trapping people in nets.",
    "I don't even know who told him.",
    "I bet it was Athena.",
    "She's just jealous because Paris said I was prettier than her.",
    "Do you know Paris? Total sweetie.",
    "I should introduce you guys some time after the war is over.",
    "Ugh. I just don't know why all the bad things have to happen to the pretty girls.",
    "I just feel like such a mess.",
    "But being here and seeing you makes me feel much more put together!",
    "So thanks again for the city. I could totally use it after the week I've had.",
    };
    [System.NonSerialized] public List<string> aph5 = new List<string>() {"Do you know what?",
    "I've realized something since we last spoke.",
    "I've realized that I'm perfect!",
    "And you're perfect too!",
    "In your own way.",
    "I mean, if I'M having love problems and I'm the goddess of love,",
    "Maybe I'm not a mess. Maybe love's a mess!",
    "So as helpful as all my tips and stories have been, maybe you just need to jump in!",
    "Be a little bit messy and you can be just like me!",
    "Well not JUST like me but you get what I mean.",
    "All these cities you've built for me have really helped my self-esteem.",
    "Who knew devout worship could do that for a person.",
    "But I appreciate it. You have my blessing, and all my favour!",
    "I'll be seeing you around!"
    };


    public List<List<string>> completeScript = new List<List<string>>();
    public List<string> gameComplete = new List<string>() {"It appears as though you've completed your quest",
    "and gained the blessing of every god!",
    "Congratulations!",
    "Feel free to continue building cities just for fun!"};

    //Keeps track of which dialogue chapter or line should be playing.
    public int chapTrak;
    public int lineTrak;

    private List<string> lines = new List<string>();

    private bool currentlyWriting = false;
    public bool inConvo = false;

    public void PickGod() {
        if (godScripts.Count > 0) {
            int rand = Random.Range(0,godScripts.Count);
            currGodScript = godScripts[rand];
            godScripts.RemoveAt(rand);
        } else {
            currGodScript = completeScript;
        }
        if (currGodScript == zeusScript) {
            godImage = godImage1;
        } else {
            godImage = godImage2;
        }
    }

    public void FailedRound() {
        if (!inConvo) {
            currentlyWriting = true;
            StartCoroutine(FailureWriter());
        }
        inConvo = !inConvo;
    }

    public void ToggleConvo() {
        if (!inConvo) {
            godImage.SetActive(true);
            currentlyWriting = true;
            StartCoroutine(MessageWriter());
        }
        inConvo = !inConvo;
    }

    // Start is called before the first frame update
    void Start()
    {
        godImage.SetActive(false);
        chapTrak = 0;
        lineTrak = 0;
        zeusScript.Add(zeus1);
        zeusScript.Add(zeus2);
        zeusScript.Add(zeus3);
        zeusScript.Add(zeus4);
        zeusScript.Add(zeus5);
        aphroditeScript.Add(aph1);
        aphroditeScript.Add(aph2);
        aphroditeScript.Add(aph3);
        aphroditeScript.Add(aph4);
        aphroditeScript.Add(aph5);
        godScripts.Add(zeusScript);
        godScripts.Add(aphroditeScript);
        completeScript.Add(gameComplete);
        Debug.Log(godScripts.Count);
        
        PickGod();
    }

    IEnumerator FailureWriter() {
        string placeholder = "";
        foreach (char i in failMessage) {
            words.text = placeholder += i;
            if (currentlyWriting == true) {
                yield return new WaitForSeconds(0.02f);
            }
        }
        currentlyWriting = false;
        ToggleConvo();
        failed = true;
    }

    IEnumerator MessageWriter() {
        string placeholder = "";
        foreach (char i in currGodScript[chapTrak][lineTrak]) {
            words.text = placeholder += i;
            if (currentlyWriting == true) {
                yield return new WaitForSeconds(0.02f);
            }
        }
        lineTrak += 1;
        currentlyWriting = false;
        if (lineTrak >= currGodScript[chapTrak].Count) {
            ToggleConvo();
        }
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(godScripts.Count);
        if (Input.GetKeyDown("space")) {
            if (currentlyWriting) {
                currentlyWriting = false;
            } else {
                if (inConvo) {
                    currentlyWriting = true;
                    StartCoroutine(MessageWriter());
                }
            }
            if (lineTrak >= currGodScript[chapTrak].Count || failed) {
                if (!failed) {
                    chapTrak += 1;
                }
                if (chapTrak >= currGodScript.Count) {
                    godImage.SetActive(false);
                    PickGod();
                    chapTrak = 0;
                }
                lineTrak = 0;
                failed = false;
                godImage.SetActive(false);
                words.text = "";
                gridM.GetComponent<GridManager>().Reset();
                gridM.GetComponent<GridManager>().ToggleActive();
                state.GetComponent<GameState>().Reset();
            }
        }    
    }
}
