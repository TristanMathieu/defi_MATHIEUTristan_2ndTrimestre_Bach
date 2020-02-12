using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class captnSlav : MonoBehaviour
{
    public InputField inputUser;
    public GameObject imgCaptnSlav;
    public GameObject imgTunk;
    public GameObject txDisplayStep;
    public GameObject imgShop;
    public GameObject imgIntro;

    public static int nNbStep;
    public static int lenghtCase;
    public static int gainRouble;
    public static int scoreTotal;

    public static bool boolStepTwo;
    public static bool boolStepThree;
    public static bool jeuRun;
    public static bool shopActive;
    public static bool intro;

    // Start is called before the first frame update
    void Start()
    {
        lenghtCase = 80;
        nNbStep = 1;
        gainRouble = 10;
        boolStepTwo = false;
        boolStepThree = false;
        jeuRun = false;
        intro = true;
    }

    // Update is called once per frame
    void Update()
    {
        var position = imgCaptnSlav.GetComponent<RectTransform>().position;
        txDisplayStep.GetComponent<Text>().text = "Steps : " + nNbStep;

        if (inputUser.text == "ok" && intro)
        {
            var positionIntro = imgIntro.GetComponent<RectTransform>().position;
            positionIntro.x += 3000;
            imgIntro.GetComponent<RectTransform>().position = positionIntro;
            inputUser.text = "";
            jeuRun = true;
            intro = false;
        }

        if (jeuRun)
        { 
            
            if (inputUser.text == "left")
            {
                if (position.x + lenghtCase * nNbStep < 1069 - 40)
                {
                    position.x += lenghtCase * nNbStep;
                    imgCaptnSlav.GetComponent<RectTransform>().position = position;
                }
                inputUser.text = "";
            }

            if (inputUser.text == "right")
            {
                if (position.x + lenghtCase * (-nNbStep) > 0 + 40)
                {
                    position.x -= lenghtCase * nNbStep;
                    imgCaptnSlav.GetComponent<RectTransform>().position = position;
                }
                inputUser.text = "";
            }

            if (inputUser.text == "down")
            {
                if (position.y + lenghtCase * (-nNbStep) > 0 + 40)
                {
                    position.y -= lenghtCase * nNbStep;
                    imgCaptnSlav.GetComponent<RectTransform>().position = position;
                }
                inputUser.text = "";
            }

            if (inputUser.text == "up")
            {
                if (position.y + lenghtCase * nNbStep < 601 - 40)
                {
                    position.y += lenghtCase * nNbStep;
                    imgCaptnSlav.GetComponent<RectTransform>().position = position;
                }
                inputUser.text = "";
            }

            if (inputUser.text == "one")
            {
                nNbStep = 1;
                inputUser.text = "";
            }

            if (inputUser.text == "two" && boolStepTwo)
            {
                nNbStep = 2;
                inputUser.text = "";
            }

            if (inputUser.text == "three" && boolStepThree)
            {
                nNbStep = 3;
                inputUser.text = "";
            }

            if (inputUser.text == "shop")
            {
                shopActive = true;
                jeuRun = false;
                inputUser.text = "";

                var positionShop = imgShop.GetComponent<RectTransform>().position;
                positionShop.x = 500;
                imgShop.GetComponent<RectTransform>().position = positionShop;
            }
        }

        if (shopActive)
        {
            if (inputUser.text == "buy two" && roubles.nbRouble >= 50 && boolStepTwo == false)
            {
                roubles.nbRouble -= 50;
                boolStepTwo = true;
                inputUser.text = "";
            }

            if (inputUser.text == "buy three" && roubles.nbRouble >= 100 && boolStepThree == false)
            {
                roubles.nbRouble -= 100;
                boolStepThree = true;
                inputUser.text = "";
            }

            if (inputUser.text == "buy time" && roubles.nbRouble >= 50)
            {
                roubles.nbRouble -= 50;
                scrTimer.nTimerMax++;
                inputUser.text = "";
            }
        }

        if (inputUser.text == "leave" && scrTimer.finJeu == false)
        {
            jeuRun = true;

            var positionShop = imgShop.GetComponent<RectTransform>().position;
            positionShop.x = 2500;
            imgShop.GetComponent<RectTransform>().position = positionShop;
            inputUser.text = "";
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        roubles.nbRouble += gainRouble;
        var position = imgTunk.GetComponent<RectTransform>().position;
        position.x += 1500;
        imgTunk.GetComponent<RectTransform>().position = position;
        scoreTotal++;
        scrTimer.nTimer = scrTimer.nTimerMax - (scoreTotal*(scoreTotal/2));

        position.x = ((int)Random.Range(1, 12) * 80)+29;
        position.y = ((int)Random.Range(1, 6) * 80)+1;


        imgTunk.GetComponent<RectTransform>().position = position;


    }

}