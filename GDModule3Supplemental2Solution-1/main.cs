using System;

class Program {
  public static void Main (string[] args) {

    //Print out your welcome message with your welcome method
    printWelcome();

    //Make an array of high scores for your game
    int[] scores = new int[]{86,89,92,94,98,98,99};
    Console.WriteLine("High Scores:");
    //Use your method to print out every high score
    printScoreList(scores);

    //Ask the user for the player's name and then print it
    Console.WriteLine("What is your player's name?");
    string playerName = Console.ReadLine();
    Console.WriteLine("Original player name: " + playerName);
  
    //Use your method to level up your player's name and then print it again
    playerName = levelUp(playerName);
    Console.WriteLine("Leveled up: " + playerName);

  }

  //Make a method that prints out a welcome message
  public static void printWelcome(){
    Console.WriteLine("Welcome to my game! I hope you have a lot of fun!");
  }

  //Make a method that prints out every score in an integer array of high scores
  public static void printScoreList(int[] scores)
  {
      for(int i = 0; i < scores.Length;i++) 
      {
        Console.WriteLine(scores[i]);
      }
  }

  //Make a method that takes in a string and returns a leveled up version of the name 
  public static string levelUp(string name){
    string newName = "Super Mega " + name + " Prime";
    return newName;
  }
}

