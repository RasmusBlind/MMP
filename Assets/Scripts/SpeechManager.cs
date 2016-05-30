using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech; //Using the Windows Speech Recognition API


public class SpeechManager : MonoBehaviour
{
    //Declare a keywordrecognizer from the keywordrecognizer class
    //Storing the recognizer and keyword
    KeywordRecognizer keywordRecognizer;
    //create a new dictionary (of strings) where the commands can be stored
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        //Adding "right" keyword to the dictionary
        keywords.Add("go right", () =>
        {
            // Setting the action of the "right" command - will make the object move right
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("VIRKER DET HER ENDELIG");
        });
        //Addid the "left" keyword to the dictionary
        keywords.Add("go left", () =>
        {
            // This action makes the object go in the left direction
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Venstre virker ogs");
        });

        // Tell the KeywordRecognizer about the keywords (what we want to recognize)
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }


    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        //if the keyword was recognized is in our dictionary - call that action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}