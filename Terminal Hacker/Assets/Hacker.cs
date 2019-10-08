using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
    string password;
    string[] levelOnePassword  = {"books", "aisle", "shelf", "password", "font", "borrow" };
    string[] levelTwoPassword = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};


    enum Screen { MainMenu, WaitingForPwd, Win}

    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    private void MainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        //Terminal.WriteLine("Hello " + greetings);
        Terminal.WriteLine("What would you like to do?\nPress 1 for local Libray \nPress 2 for local Police \n Enter your selection: ");
    }

    private void OnUserInput(string input)
    {
        if(input == "Menu" || input == "menu")
        {
            MainMenu();
        }else if(currentScreen == Screen.MainMenu)
        {
            ChooseOptions(input);
        }
        else if (currentScreen == Screen.WaitingForPwd)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if(input == password)
        {
            WinDisplay();
        }
        else
        {
            StartGame();
        }
    }

    private void WinDisplay()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
         __________
        /         //
       /         //
      /         //
     /_________//
    (_________(/
");
                break;
            case 2:
                Terminal.WriteLine(@"
         ___
        /0  \_________
        \___/     | |
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    private void ChooseOptions(string input)
    {
        bool validNumber = (input == "1" || input == "2");
        if (validNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            print("Invalid input value");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.WaitingForPwd;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = levelOnePassword[Random.Range(0, levelOnePassword.Length)];
                break;
            case 2:
                password = levelTwoPassword[Random.Range(0, levelTwoPassword.Length)];
                break;
            default:
                Debug.LogError("Invalid Input");
                break;
        }
        Terminal.WriteLine("Enter password: " + password.Anagram());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
