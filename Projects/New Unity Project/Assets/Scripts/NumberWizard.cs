using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour
{
    int max;
    int min;
    int guess;
    

    // Use this for initialization
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        min = 1;
        max = 100000;
        
        guess = max / 2;

        max = max + 1; // So we can guess 1000 ;)
        print("Pick a number in your head...but don't tell me!");


        print("The highest number you can pick is " + (max - 1));
        print("The lowest number you can pick is " + min);

        print("After each guess, hit either:");
        print("-  UP arrow if value is higher.");
        print("-  DOWN arrow if value is lower.");
        print("-  RETURN if I've got it!");
        print("Right. Let's play!");

        TakeAGuess(guess);

    }

    void TakeAGuess(int guess)
    {
        print("Is the number higher or lower than " + guess + "?");                        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {

            min = guess;
            //print("UP Selected!");
            //print("So, the number is higher than " + guess +"...");
            guess = ((min + max) / 2);
            TakeAGuess(guess);
   
            
        }
        else if (Input.GetKeyDown("down"))
        {
            max = guess;
            //print("DOWN Selected!");
            //print("So, the number is lower than " + guess + "...");
            guess = ((min + max) / 2);
            TakeAGuess(guess);
        }
        else if (Input.GetKeyDown("return"))
        {
            max = guess;
            //print("RETURN Selected!");
            print("I guessed the number! It's " + guess + "!");
            print("Wanna play again?");
            StartGame();
        }

    }
}
