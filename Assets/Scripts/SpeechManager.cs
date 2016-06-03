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
        keywords.Add("right", () =>
        {
            
            gameObject.GetComponent<Movementbehavior>().turnR = true;
        });
        //Adding the "left" keyword to the dictionary
        keywords.Add("left", () =>
        {
            
            gameObject.GetComponent<Movementbehavior>().turnL = true;
        });

        // adding keyword "play game" to start the game
        keywords.Add("play game", () =>
        {
            gameObject.GetComponent<NetworkPlayer>().start = true;

        }
        );

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