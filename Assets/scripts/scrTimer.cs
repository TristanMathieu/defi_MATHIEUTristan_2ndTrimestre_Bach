using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrTimer : MonoBehaviour
{
    public static int nTimer;
    public static int nTimerMax;
    public GameObject self;
    public GameObject ecranGameOver;
    public GameObject txScore;

    private bool boolTimerOn;
    public static bool finJeu;

    // Start is called before the first frame update
    void Start()
    {
        finJeu = false;
        nTimerMax = 30;
        nTimer = nTimerMax;
        boolTimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        self.GetComponent<Text>().text = "Time left : " + nTimer;

        if (boolTimerOn && nTimer > 0 && captnSlav.jeuRun)
        {
            boolTimerOn = false;
            StartCoroutine(decompte());
        }

        if (nTimer <= 0 && captnSlav.jeuRun)
        {
            var position = ecranGameOver.GetComponent<RectTransform>().position;
            position.x = 500;
            ecranGameOver.GetComponent<RectTransform>().position = position;

            txScore.GetComponent<Text>().text = "Score : " + captnSlav.scoreTotal;
            captnSlav.jeuRun = false;
            captnSlav.shopActive = false;
        }
    }

    IEnumerator decompte()
    {
        nTimer -= 1;
        yield return new WaitForSeconds(1);
        boolTimerOn = true;
    }
}
