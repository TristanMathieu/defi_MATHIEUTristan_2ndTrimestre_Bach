using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roubles : MonoBehaviour
{
    public GameObject txDisplayerRouble;
    public static int nbRouble;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txDisplayerRouble.GetComponent<Text>().text = nbRouble + "₽";
    }
}
