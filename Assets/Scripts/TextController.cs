using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextController : MonoBehaviour
{
    public Text mytext;
    void Start()
    {

        StartCoroutine(Instructions());

        //other code to begin moving a game object
    }

    IEnumerator Instructions()
    {
        while (true)
        {
            mytext.text = "GAME OVER";
            mytext.resizeTextMaxSize = 100;
            yield return new WaitForSecondsRealtime(2);
            mytext.text = "Click on the space\n\n( not the space button )";
            mytext.resizeTextMaxSize = 60;
            yield return new WaitForSecondsRealtime(2);
        }
        
    }
}
