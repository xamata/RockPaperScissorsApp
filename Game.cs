using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using System.Runtime.CompilerServices;

namespace RockPaperScissors
{
    internal class Game
    {
        // Fields
        string GameName;
        string GameDescription;
        int Score;
        Random RandGenerator;


        public Game()
        {
            // Initializes anything game related
            Score = 0;
            RandGenerator = new Random();
            GameName = "Rock... Paper... Scissors!";
            GameDescription = "Rules:\n\t>Rock beats Scissors\n\t>Paper beats Rock\n\t>Scissors beats Paper" +
                "\nYou can choose between Rock, Paper, & Scissors.";
        }

        public void Start()
        {
            // Start playing the game with player's confirmation
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;

            Clear();
            Title = GameName;
            WriteLine($"=== {GameName} ===");
            WriteLine(GameDescription);

            // Player's input
            // Trim() and Lower() used to caputure more inputs of 'yes' 
            WriteLine("Are you ready to play? (yes/no)");
            string playerReady = ReadLine().Trim().ToLower();

            // Code to begin the game
            if (playerReady == "yes")
            {
                PlayRound();
            }

            // This code will end the game
            else if (playerReady == "no")
            {
                WriteLine("Come back when you're ready!");
                Stop();
            }

            // If choices other than yes/no entered, restart
            else
            {
                Clear();
                Start();
            }
        }

        public void PlayRound()
        {
            // Begins a round between player and computer
            Clear();

            // Computer's Choice
            string computerChoice;
            WriteLine("I'm also ready to play!");
            int randomChoice = RandGenerator.Next(0, 3);
            // Convert int computerChoice into string using conditionals
            if (randomChoice == 0) computerChoice = "rock";
            else if (randomChoice == 1) computerChoice = "paper";
            else computerChoice = "scissors";

            // Player's Choice
            WriteLine("Choose your weapon: rock/paper/scissors");
            string playerChoice = ReadLine().Trim().ToLower();

            // Branching Logic to determine winner
            if (playerChoice == "rock" || playerChoice == "paper" || playerChoice == "scissors")
            {
                // Delays the display of the countdown timer, 
                WriteLine("\nRock...");
                Thread.Sleep(500);
                WriteLine("Paper...");
                Thread.Sleep(500);
                WriteLine("Scissors...");
                Thread.Sleep(500);

                // Outputs computer's choice with ASCII Text Art
                ForegroundColor = ConsoleColor.Magenta;
                switch (computerChoice)
                {
                    case "rock":
                        WriteLine(@"                                     .***,,,,...,,,,.                           
                                ,****,,,,,,,,,,,.,,,,...,.....,,,,,,,,,,,             
            ,*****,           ******,,,,,,,,,,,,,..,..............,,...,,.,,......          
            ,,,,,*,,*****,,,,****,,,,,,,,,,,,,..,,.,............,,.....,,,,,,......         
            ,,,,,,,,***,*,*,,*,,,,,,,,,,,,,,,,............,,,,,,,,,,,,,,,/*,,,...,,         
            ,,,,,,,,,*,*,***,*,,,,,,,,,,,,,,,.......,.,,,,,**/***/*****/(/**,,,,..,,,       
            ,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,.,..,.,,,,,,/*//**,****/((###(%(/**,,,.,.,,,,     
            ,,,,,,,,,,,,,,,,,,,,,,,,,,,,.,,,,,,,,,,,.**,,,**/***,,,,,,,,,*#(/***,,,,.,..,   
            ,,,,,,,,,,,,,,,,,,.,,,.,,,,,,,,,.,,****/#(/*****//***,,........,,//*****,,,,,,, 
            ,,,,,,,,,,,.,,,,,,,,,.,..,,,,,,,,.***/((///**##(//***,,....,.....,,,*(//****,*. 
            ,,,,,,,,,,,,,,,,.,..,,,,,,,,,,*/,//****///**,,,,,,(/*,,,........,,...,,,        
            ,,,,,,,,,,,,,.........,,,/ ,*//*(%#((/////***,.,......,,/**,,.....,,,..,        
            ,,,,,,,,,,,............,(.*******/**/#(///**,,,,,....... .....,**,,,,           
            ,**,,,,,,.,,............*////***/***,,,,,(/**,,,..,....,...,.....,              
            ***,,,,,,.,..............,(/////*****,,,,,,,**/*,,,......,..,..,..              
            /***,,,,,,.,.............,/*#%%(//****,,,,,,.....,,*/,.....,,....               
            //****,,,,,.............,(////(//**,*/**,,,,,.....,,,,..,,,,,,,                 
            .//**,,,,,.,,......,.,.(/////**,.....,(*,,,,,.,...,,...                       
            ****,,,,,,,,....,,**(//*/*,,,........**,,,,,......,                       
                *****,,,,,,,..,,*/(#/,,,,,.........//**,,,,,,                         
                    ****,,,,,,,,,,/(((***,,,,,.....,                                  
                        ,****,,,,,/**//((/***,,,,,,                                   
                            .**,(******//***,,,                                      ");
                        WriteLine("I chose rock!");
                        break;
                    case "paper":
                        WriteLine(@"                                          ,.,,,,                                
                                        .,,,,.,,,,,*/                                
                            .,,,,,,,,,,,,,,,,,,,,,,**,                                 
                        ,*,,,,,,,,,,******/(////((                                    
                    ,*,,,,,,,,,,,***/(((//#/.                                        
                    ***,,,,,,,,,,,*/%%(.                                               
                ,****,,,,,..,,,,,,,,,,,,,,,,,,,,,,,,,,,,,..,,,**,,,,,,,***,****,,*    
            ,//***,,,,,,.,,,,,,,,,,,,,,,,,.........,,,,,,,,**//******//***/****/    
            .#(///**,,,,,,,,,,,**,,,,,,,,,,*,,,.....,,*//*****/((((((//(####(/,       
            /////((%((///***,,,,,,,,****,,,,,,,*,.,,,,,,,,,**                               
            //////((#(////*************,,,,,***,,*,,,********,,,,,,,,****,                  
            ///////((#(////***************,,,,,,**,,***,,,,,,,***,,,,**/****,***********    
            //////(##(((///////////(**,,*,,,,,,,,,,,,,,,,,,,,*////****////*****/////*******.
            (/((((((###((//////*/*/**,*,,,,,,,,,,,,,.,,,,,,,,***,,          ''##((((((////.
            (((((///(((((///*/****,,,,,,,,,,,,..,,,.,,,,,,,,*,,,,,,,,**,,,,,            
            (((((((((((((////*********,,,,,,,,,,,,,.,,.,,,,,**********/*******************  
            ##(((((((#(((////////***********,****,,,,,,,**.         ..*///////(((/(///////  
            ####(###(##(((((((//////////*****************,,,,,*,                            
            ###(,               ,/((((((/////((/////////***********,**.                     
            ,                                            ,///////*////****,***.             
                                                            /(((/(/(////(             ");
                        WriteLine("I chose paper!");
                        break;
                    case "scissors":
                        WriteLine(@"                                                      .,((((((((((((/(///***/   
                                    ,(#(((//(((((((((((((((((#(((////**////**/*//***   
            .      ..,,,*//((###########((///((/**/////////*//////**/**********/**///*      
            #################(##((((((((((/////***************/*/*********,                 
            #####(((((((((((((((((((((((((//////*************,,,,*,                         
            ((((((((((((((((#(((((((((((((((((((/////,*,,,,                                 
            ((((((((((((((((((((((((((((((((((//////////*.                                  
            (((((((((((//(//////////////////(********///////*.                              
            /(/(((((((////(/((((//////////////////************////(/**.                     
            ////(/((/(////(((((///////////***//////////////*/**/(/(//*******,               
            */////////////(((((((//////////****////*/,   /#((////(//******,,,**/////*.      
            /////////////////((((((((((//****************.    .///////*********/***,*/////* 
            (((((///////////*////((####((/////////*****/**.             ,/((/////****,,,..,*
            ###((/(////////////**////((/////#(//*****//,                       ,(//*/(//* 
            (##(//////////////((/////////**//*                                        
                    .*((((/((((//////*//////*                                         ");
                        WriteLine("I chose scissors!");
                        break;
                    default:
                        WriteLine("Your game is out of whack!");
                        break;
                }

                // The win, lose, tie branching logic
                if (playerChoice == "rock" && computerChoice == "scissors" ||
                    playerChoice == "paper" && computerChoice == "rock" ||
                    playerChoice == "scissors" && computerChoice == "paper")
                {
                    Win();
                }
                else if (playerChoice == "rock" && computerChoice == "paper" ||
                    playerChoice == "paper" && computerChoice == "scissors" ||
                    playerChoice == "scissors" && computerChoice == "rock")
                {
                    Lose();
                }
                else if (playerChoice == "rock" && computerChoice == "rock" ||
                    playerChoice == "paper" && computerChoice == "paper" ||
                    playerChoice == "scissors" && computerChoice == "scissors")
                {
                    Tie();
                }
            }

            // Invalid entries get reset
            else { PlayRound(); }

            // As each round ends, ask player if they want to play again
            AnotherRound();
        }

        public void Win()
        {
            // Increases the score of the player and let's them know they've won
            ForegroundColor = ConsoleColor.Green;
            Score++;
            WriteLine("You win!");
            ShowScore();
        }

        public void Lose()
        {
            // Let's them know they've lost
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("You lose.");
            ShowScore();
        }
        public void Tie()
        {
            // Let the player know they tied with computer
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("You tie...");
            ShowScore();

        }

        public void AnotherRound()
        {
            // Asks the player if they want to play again
            ForegroundColor = ConsoleColor.Black;
            WriteLine("Would you like to play again? (yes/no)");
            string playAgain = ReadLine().Trim().ToLower();
            if (playAgain == "yes")
            {
                PlayRound();
            }
            else if (playAgain == "no")
            {
                Stop();
            }

            else { AnotherRound(); }
        }

        public void ShowScore()
        {
            // Shows the player their current score 
            ConsoleColor prevColor = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"Your Score is {Score}.");
            ForegroundColor = prevColor;
        }

        public void Stop()
        {
            // Shows there player's total score and a goodbye message
            WriteLine("Thanks for playing!");
            WriteLine($"Your final score was {Score}!");
            WriteLine("Press any key to exit...");
            ReadKey();
            Environment.Exit(0);

        }
    }
}