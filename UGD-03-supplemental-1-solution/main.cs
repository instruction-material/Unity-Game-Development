using System;

class Program {
  public static void Main (string[] args) {

    //Print "Score:"
    Console.WriteLine("Score:");

    //Create an integer variable called score and print it
    int score = 0;
    Console.WriteLine(score);

    //Use an if statement to tell the user that they have no points if the score is zero
    if(score == 0)
    {
      Console.WriteLine("You have no points");
    }

    //Use a while loop to increase the score 10 times and print it each time
    while(score < 10)
    {
      Console.WriteLine(score);
      score++;
    }

    //Ask the user for a string variable to track your player's name
    string playerName = "Mario Steve Fortnite";

    //Use a for loop to print out each letter of your player's name
    for(int i = 0; i < playerName.Length; i++)
    {
      Console.WriteLine(playerName[i]);
    }
    
  }
}

