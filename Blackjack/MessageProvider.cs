using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class MessageProvider : IMessageProvider
    {
        public static string M_WelcomeMessage = @"Welcome to...

              __                                               
        _..-''--'----_.                                        
      ,''.-''| .---/ _`-._                                     
    ,' \ \  ;| | ,/ / `-._`-.                     ___  __         __     _          __                  
  ,' ,',\ \( | |// /,-._  / /                    / _ )/ /__ _____/ /__  (_)__ _____/ /__                
  ;.`. `,\ \`| |/ / |   )/ /                    / _  / / _ `/ __/  '_/ / / _ `/ __/  '_/                
 / /`_`.\_\ \| /_.-.'-''/ /                    /____/_/\_,_/\__/_/\_\_/ /\_,_/\__/_/\_\                 
/ /_|_:.`. \ |;'`..')  / /                                         |___/                                
`-._`-._`.`.;`.\  ,'  / /                                      
    `-._`.`/    ,'-._/ /                                       
      : `-/     \`-.._/                                        
      |  :      ;._ (                                          
      :  |      \  ` \                                         
       \         \   |                                         
        :        :   ;                                         
        |           /                                          
        ;         ,'                                           
       /         /                                             
      /         /                                              
               /             Credit for the hand art - Chris Ferguson (found on Google)   

";
        public static string M_RulesMessage = 
@"****  Blackjack pays 3 to 2.                 ****
****  Dealer draws to 16, must stand on 17.  ****";
        public static string M_PromptPlayerName = "Please enter a player name: ";
        public static string M_BetPrompt = "Make your best bet! :";
        public static string M_PlayerActionPrompt = " Do you want to 'Hit' or 'Stand'? :\t\t\t\t\t\t\t\t";
        public static string M_BankString = "Bank";
        public static string M_PlayerWon = @"

   #                                                                                                                            
  # #   #    #  ####  ##### #    # ###### #####     #    # # #    #           #####  ####   ####     ######   ##    ####  #   # 
 #   #  ##   # #    #   #   #    # #      #    #    #    # # ##   #             #   #    # #    #    #       #  #  #       # #  
#     # # #  # #    #   #   ###### #####  #    #    #    # # # #  #             #   #    # #    #    #####  #    #  ####    #   
####### #  # # #    #   #   #    # #      #####     # ## # # #  # #             #   #    # #    #    #      ######      #   #   
#     # #   ## #    #   #   #    # #      #   #     ##  ## # #   ##    ###      #   #    # #    #    #      #    # #    #   #   
#     # #    #  ####    #   #    # ###### #    #    #    # # #    #    ###      #    ####   ####     ###### #    #  ####    #  
                                                                        #
                                                                       #
";
        public static string M_PlayerLost = @"

###                         ###                                                         ###                                           
 #      ####    ##   #    # ### #####    #####  ###### #      # ###### #    # ######     #     #       ####   ####  #####             
 #     #    #  #  #  ##   #  #    #      #    # #      #      # #      #    # #          #     #      #    # #        #               
 #     #      #    # # #  # #     #      #####  #####  #      # #####  #    # #####      #     #      #    #  ####    #               
 #     #      ###### #  # #       #      #    # #      #      # #      #    # #          #     #      #    #      #   #    
 #     #    # #    # #   ##       #      #    # #      #      # #       #  #  #          #     #      #    # #    #   #   ### ### ### 
###     ####  #    # #    #       #      #####  ###### ###### # ######   ##   ######    ###    ######  ####   ####    #   ### ### ### 


";
        public static string M_PlayerDraw = @"



                                           A Draw is okay, that's okay.


";
        public static string M_QuitMessage = @"

   _____              __  __               _____                          ______              __                   
  / ___/___  ___      \ \/ /___  __  __   / ___/____  ____ _________     / ____/___ _      __/ /_  ____  __  __    
  \__ \/ _ \/ _ \      \  / __ \/ / / /   \__ \/ __ \/ __ `/ ___/ _ \   / /   / __ \ | /| / / __ \/ __ \/ / / /    
 ___/ /  __/  __/      / / /_/ / /_/ /   ___/ / /_/ / /_/ / /__/  __/  / /___/ /_/ / |/ |/ / /_/ / /_/ / /_/ /   
/____/\___/\___/      /_/\____/\__,_/   /____/ .___/\__,_/\___/\___/   \____/\____/|__/|__/_.___/\____/\__, / (_) (_) (_)
                                            /_/                                                       /____/       




";

        /// <summary>
        /// A welcome message
        /// </summary>
        public string Welcome { get; set; }

        /// <summary>
        /// The rules of the game
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// The one and only constructor
        /// <param name="welcome"> The welcome message</param>
        /// <param name="rules"> The rules of the game</param>
        /// </summary>
        public MessageProvider(string welcome, string rules)
        {
            this.Welcome = welcome;
            this.Rules = rules;
            ConsoleInputAndOutputProvider consoleOutputProvider = new ConsoleInputAndOutputProvider();
        }

        /// <summary>
        /// Prints a welcome message to the console
        /// <param name="welcome"> The welcome message that is printed at the beginning of the game</param>
        /// </summary>
        public void printWelcome(string welcome)
        {
            ConsoleInputAndOutputProvider consoleOutputProvider = new ConsoleInputAndOutputProvider();
            //call the console output provider's writeLine method and pass in the welcome; this outputs the rules to the console
            consoleOutputProvider.WriteLine(welcome);
        }

        /// <summary>
        /// Prints a welcome message to the console
        /// </summary>
        public void printWelcome()
        {
            ConsoleInputAndOutputProvider consoleOutputProvider = new ConsoleInputAndOutputProvider();
            //call the console output provider's writeLine method and pass in the welcome; this outputs the rules to the console
            consoleOutputProvider.WriteLine(this.Welcome);
        }

        /// <summary>
        /// Prints the rules to the console
        /// <param name="rules"> The rules of the game, to be printed to the console by this method
        /// </summary>
        public void printRules(string rules)
        {
            ConsoleInputAndOutputProvider consoleOutputProvider = new ConsoleInputAndOutputProvider();
            //call the console output provider's writeLine method and pass in the rules; this outputs the rules to the console
            consoleOutputProvider.WriteLine(rules);
        }

        /// <summary>
        /// Prints the rules to the console
        /// </summary>
        public void printRules()
        {
            ConsoleInputAndOutputProvider consoleOutputProvider = new ConsoleInputAndOutputProvider();
            //call the console output provider's writeLine method and pass in the rules; this outputs the rules to the console
            consoleOutputProvider.WriteLine(this.Rules);
        }
    }
}
