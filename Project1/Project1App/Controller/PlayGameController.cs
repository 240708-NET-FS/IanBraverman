using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;
using Project1App.Controller;

namespace Project1App.Controller;

public class PlayGameController
{

    private PlayerItemsService playerItemsService;

    private PlayerService playerService;

    public PlayGameController(PlayerItemsService playeritemservice, PlayerService playerservice)
    {
        playerItemsService = playeritemservice;
        playerService = playerservice;
    }



    public void PlayRoomOne()
    {
        bool stillInRoom = true;
        Console.WriteLine("Why does my head hurt so bad? You slowly open your eyes and you are definitly not in kansas anymore.");
        Console.WriteLine("You look around and see that you are locked in a cold, medieval dungeon cell.");
        Console.WriteLine("There is only one window, the walls are made of stone, and there is a big iron gate leading to the hallway; the only way out.");
        Console.WriteLine("You are in beat up tattered clothing. You check your pockets, and all of your belongings are gone.");
        Console.WriteLine("Where am I?");
        while (stillInRoom == true)
        {
            Console.WriteLine("Please pick one of the following options: ");
            Console.WriteLine("1: Look around the room for any clues or items that might help you");
            Console.WriteLine("2: Yell for help");
            Console.WriteLine("3: Try and escape through the gate");

            string playerInput = Console.ReadLine();



            switch (playerInput)
            {
                case "1":
                case "One":
                case "one":
                    Console.WriteLine("You look around the room and find a mysterious key...");
                    Console.WriteLine("I wonder what it opens?");
                    Console.WriteLine("You add the key to your inventory?");
                    //make dungeon key 1 in their playeritems
                    var updatesKey = new Dictionary<string, object>
                    {
                        {"DungeonKey", 1},
                    };
                    playerItemsService.UpdateFields(updatesKey);
                    //this also gets current players playeritems and sets playeritems after being updated again
                    break;
                case "2":
                case "Two":
                case "two":
                    Console.WriteLine("You scream out for anyone that may hear you. 'HELP! HELP! HELP!'");
                    Console.WriteLine("An angry guard comes to the door. 'What the heck are you yelling about?!'");
                    Console.WriteLine("The guard opens the cell door, enters the room, punches you in the mouth, leaves the room, locks the door, and walks back to wherever he came from");
                    //player loses 1 life
                    Console.WriteLine($"Your health goes from from {State.currentPlayer.Health} to {State.currentPlayer.Health - 1}");
                    var updatesLife = new Dictionary<string, object>
                    {
                        {"Health", State.currentPlayer.Health - 1}
                    };
                    //this also gets the loggedinplayer again and sets loggedinplayer after being updated
                    playerService.UpdateFields(updatesLife);
                    if (State.currentPlayer.Health == 0)
                    {
                        Console.WriteLine("Oh no! You are out of health. You are dead.");
                        var updatesPlayer = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 0},
                            {"Health", 5},
                        };
                        playerService.UpdateFields(updatesPlayer);
                        var resetsPlayerItems = new Dictionary<string, object>
                        {
                            {"Sword", 0 },
                            {"Shield", 0 },
                            {"Armor", 0 },
                            {"Helmet", 0 },
                            {"DungeonKey", 0 },
                        };
                        playerItemsService.UpdateFields(resetsPlayerItems);
                        stillInRoom = false;
                    };

                    break;
                case "3":
                case "Three":
                case "three":
                    //if the player has the key
                    if (State.playerItems.DungeonKey == 1)
                    {
                        Console.WriteLine("You go up to the heavy gate, and think, 'maybe this key will unlock the door!'");
                        Console.WriteLine("You put the key into the gate, and it opens!");
                        Console.WriteLine("You leave the room, and enter the hallway...");
                        //they escape, while loop is now false
                        var updatesRoom = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 2},
                        };
                        playerService.UpdateFields(updatesRoom);
                        stillInRoom = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You go up to the heavy gate, and try to open the door.");
                        Console.WriteLine("The door requires a key");
                        break;
                    }
                default:
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                    break;

            }

            //if the players health is 0, then it says game over, and sets current room to 0, and health back to 5
            //make it that current room is now 2
        }

    }

    public void PlayRoomTwo()
    {
        bool stillInRoom = true;
        Console.WriteLine("As you step out of your dungeon cell, you find yourself in a cold, damp, and dark hallway. You start to look around and see locked room after room, all filled with prisoners.");
        Console.WriteLine("Your cell is at the end of the hallway. The hallway seems to stretch on forever.");
        Console.WriteLine("There are two cells with open doors.");
        Console.WriteLine("How did I get here?");

        //when you pick choice one, there are 3 prisoner cell options for when you open them
        int prisonerCellNumber = 1;


        while (stillInRoom == true)
        {
            Console.WriteLine("Please pick one of the following options: ");
            Console.WriteLine("1: Use your dungeon key to unlock one of your fellow prisoners cells. Maybe they can help you escape?");
            Console.WriteLine("2: Check what is inside the first opened cell");
            Console.WriteLine("3: Check what is inside the second opened cell");
            Console.WriteLine("4: Walk down the hallway and see what awaits you...");

            string playerInput = Console.ReadLine();



            switch (playerInput)
            {
                case "1":
                case "One":
                case "one":
                    if (prisonerCellNumber == 1)
                    {
                        Console.WriteLine("You walk up to one of the other prisoners cells, and he looks at you with hopeful, sunken eyes.");
                        Console.WriteLine("He is also in tattered clothing, and looks like he hasnt eaten in weeks.");
                        Console.WriteLine("You take out your dungeon key, and unlock his cell.");
                        Console.WriteLine("The prisoner immediately runs out of his cell, pushes you aside, and runs down the hallway.");
                        Console.WriteLine("You are knocked against the wall hitting your head badly; you lose one health.");
                        Console.WriteLine("There are still other prisoners... Maybe the next one will go better?");
                        Console.WriteLine($"Your health goes from from {State.currentPlayer.Health} to {State.currentPlayer.Health - 1}");

                        var updatesLife2 = new Dictionary<string, object>
                        {
                            {"Health", State.currentPlayer.Health - 1}
                        };
                        //this also gets the loggedinplayer again and sets loggedinplayer after being updated
                        playerService.UpdateFields(updatesLife2);

                        if (State.currentPlayer.Health == 0)
                        {
                            Console.WriteLine("Oh no! You are out of health. You are dead.");
                            var updatesPlayer = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 0},
                            {"Health", 5},
                        };
                            playerService.UpdateFields(updatesPlayer);
                            var resetsPlayerItems = new Dictionary<string, object>
                        {
                            {"Sword", 0 },
                            {"Shield", 0 },
                            {"Armor", 0 },
                            {"Helmet", 0 },
                            {"DungeonKey", 0 },
                        };
                            playerItemsService.UpdateFields(resetsPlayerItems);
                            stillInRoom = false;
                        };
                        //prisoner cell number becomes 2
                        prisonerCellNumber++;
                        break;
                    }
                    else if (prisonerCellNumber == 2)
                    {
                        Console.WriteLine("Well, the first prisoner cell didnt go very well, but you decide to try and open another prisoners cell. Maybe this one will be more helpful?");
                        Console.WriteLine("You walk up to the second prisoners cell, and he also looks very decrepit. He is an older man, but he has a friendly smile.");
                        Console.WriteLine("You take out your dungeon key, and unlock his cell.");
                        Console.WriteLine("The prisoner quietly says, 'Thank you so much, I have been in that cell for 10 years'");
                        Console.WriteLine("'I was locked away for stealing a loaf of bread to help my family. We were starving. I hope when I leave this place, I will still have a family to go back to.'");
                        Console.WriteLine("'Take this, I am forever grateful.");
                        Console.WriteLine("The prisoner gives you a small shield. 'This shield will hopefully protect you when you try to escape this horrible place.'");
                        Console.WriteLine("Now when you are in a fight, you will have additional defense and hopefully be protected from damage");
                        Console.WriteLine("The prisoner gives you a nod, then walks down the hallway. Hopefully he gets back to his family.");
                        Console.WriteLine("You now have shield in your inventory.");
                        //prisoner cell number becomes 3
                        prisonerCellNumber++;
                        var updatesShield = new Dictionary<string, object>
                    {
                        {"Shield", 1},
                    };
                        playerItemsService.UpdateFields(updatesShield);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You decide to walk up to another prisoner cell. Maybe this prisoner cell will also have a friendly person who is willing to help.");
                        Console.WriteLine("You walk up to the hird prisoner cell, and inside is a strong burly man who looks to be in his late 30s.");
                        Console.WriteLine("You take out your dungeon key, and unlock his cell.");
                        Console.WriteLine("The man bursts out a deep, ugly laugh");
                        Console.WriteLine("His mouth curls into a creepy, evil smile. His beady red eyes stare at you intently.");
                        Console.WriteLine("'You decided to open up the wrong door' He says to you.");
                        Console.WriteLine("You try to run away from him, but he is faster than he looks. He grabs you by the arms, lifts you above his head, then slams you against the ground.");
                        Console.WriteLine("In your fleeting last moments of consciousness, he says 'so long idiot', steals your sword from you, and leaves down the hallway");


                        var updatesLife3 = new Dictionary<string, object>
                        {
                            {"Health", 0},
                        };
                        //this also gets the loggedinplayer again and sets loggedinplayer after being updated
                        playerService.UpdateFields(updatesLife3);
                        //it will be 0 because you are now dead
                        if (State.currentPlayer.Health == 0)
                        {
                            Console.WriteLine("Oh no! You are out of health. You are dead.");
                            var updatesPlayer = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 0},
                            {"Health", 5},
                        };
                            playerService.UpdateFields(updatesPlayer);
                            var resetsPlayerItems = new Dictionary<string, object>
                        {
                            {"Sword", 0 },
                            {"Shield", 0 },
                            {"Armor", 0 },
                            {"Helmet", 0 },
                            {"DungeonKey", 0 },
                        };
                            playerItemsService.UpdateFields(resetsPlayerItems);
                            stillInRoom = false;
                        };
                    }
                    break;
                case "2":
                case "Two":
                case "two":
                    Console.WriteLine("You walk up to the first unlocked cell, see if there is something useful inside.");
                    Console.WriteLine("You look around, lifting up the straw bed, looking on the wooden bedside table.");
                    Console.WriteLine("You lift up the bed blanket, and a huge rat jumps at you, biting and clawing your face.");
                    Console.WriteLine("You stumble out of the room, dazed and in pain. But, you lived.");
                    //player loses 1 life
                    Console.WriteLine($"Your health goes from from {State.currentPlayer.Health} to {State.currentPlayer.Health - 1}");
                    var updatesLife = new Dictionary<string, object>
                    {
                        {"Health", State.currentPlayer.Health - 1}
                    };
                    //this also gets the loggedinplayer again and sets loggedinplayer after being updated
                    playerService.UpdateFields(updatesLife);
                    if (State.currentPlayer.Health == 0)
                    {
                        Console.WriteLine("Oh no! You are out of health. You are dead.");
                        var updatesPlayer = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 0},
                            {"Health", 5},
                        };
                        playerService.UpdateFields(updatesPlayer);
                        var resetsPlayerItems = new Dictionary<string, object>
                        {
                            {"Sword", 0 },
                            {"Shield", 0 },
                            {"Armor", 0 },
                            {"Helmet", 0 },
                            {"DungeonKey", 0 },
                        };
                        playerItemsService.UpdateFields(resetsPlayerItems);
                        stillInRoom = false;
                    };

                    break;
                case "3":
                case "Three":
                case "three":
                    Console.WriteLine("You walk up to the second unlockedcell . Maybe this cell will have something useful for you.");
                    Console.WriteLine("You look around, checking the bed, under the furniture.");
                    Console.WriteLine("In the corner of the room you find a beat up, rusty sword!");
                    Console.WriteLine("'This will come in handy!'");
                    Console.WriteLine("You add the sword to your inventory.");
                    Console.WriteLine("Now when you are in a fight, you will have additional attack and hopefully deal more damage to opponents.");
                    Console.WriteLine("You now have sword in your inventory");

                    var updatesSword = new Dictionary<string, object>
                    {
                        {"Sword", 1},
                    };
                    playerItemsService.UpdateFields(updatesSword);
                    break;
                case "4":
                case "Four":
                case "four":
                    Console.WriteLine("You walk down the dark hallway, and at the end of the hallway find a large wooden door.");
                    Console.WriteLine("Do you choose to go through it, or stay in the hallway? Enter Yes Or No: ");
                    string hallwayInput = Console.ReadLine();
                    switch (hallwayInput)
                    {
                        case "y":
                        case "Y":
                        case "Yes":
                        case "yes":
                            Console.WriteLine("You take out your dungeon key, open up the wooden door, and go through it.");
                            Console.WriteLine("Hopefully nothing dangerous awaits you on the other side...");
                            var updatesRoom = new Dictionary<string, object>
                            {
                                {"CurrentRoom", 3},
                            };
                            playerService.UpdateFields(updatesRoom);
                            stillInRoom = false;
                            break;
                        case "N":
                        case "n":
                        case "No":
                        case "no":
                            Console.WriteLine("You go back to the beginning of the hallway.");
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                    break;
            }

            //if the players health is 0, then it says game over, and sets current room to 0, and health back to 5
            //make it that current room is now 2
        }


    }

    public void PlayRoomThree()
    {
        bool stillInRoom = true;
        bool inBattle = true;
        Console.WriteLine("You walk through the large wooden door, and on the other side enter into a large circular room");
        Console.WriteLine("The walls and floor are solid stone, and on the other side of the room is another large wooden door.");
        Console.WriteLine("'Maybe that's the exit?'");
        Console.WriteLine("However, the path to this door is not clear. Guarding the exit stands a dungeon guard.");
        Console.WriteLine("An enormous beast of a man, at least 6 feet tall, weilding a long sword.");
        Console.WriteLine("'Hey! You! What are you doing out of your cell?!'");
        Console.WriteLine("He storms toward you, anger in his face. Time to fight.");
        Console.WriteLine("");
        Console.WriteLine("In a fight, you will take turns with your opponent swinging blows.");
        Console.WriteLine("The more armor and protection you have, the better chance you have to win the fight.");
        //when a player attacks the other, they roll a d20. if the roll is above 15, they hit the opponent.
        int dieRollAdditionalAttack = 0;
        //die roll additional attack adds to the die roll, making it more likely to hit opponent.
        int dieRollAdditionalProtection = 0;
        //die roll additional defense subtracts from the die roll, making it less likely to be hit. 
        // having sword adds 3 to die roll additional attack
        if (State.playerItems.Sword == 1)
        {
            dieRollAdditionalAttack = dieRollAdditionalAttack + 3;
        }
        //having shield adds 3 to die roll additional defense.
        if (State.playerItems.Shield == 3)
        {
            dieRollAdditionalProtection = dieRollAdditionalProtection + 3;
        }



        while (stillInRoom == true)
        {
            Console.WriteLine("The fight begins!");
            int enemyGuardHealth = 3;
            while (inBattle == true)
            {
                //first enemy attacks you
                int enemyAttackRoll = playerService.Rolld20Attack(0);
                int enemyAttackRollMinusDefense = enemyAttackRoll - dieRollAdditionalProtection;
                //if the enemy minus defense buff rolls above 12, they hit player, and player loses 1 life
                if (enemyAttackRollMinusDefense > 12)
                {
                    Console.WriteLine("The guard swings his big sword at you, and it connects! You lose one health");
                    Console.WriteLine($"Your health goes from from {State.currentPlayer.Health} to {State.currentPlayer.Health - 1}");
                    Console.WriteLine("");
                    var updatesLife = new Dictionary<string, object>
                    {
                        {"Health", State.currentPlayer.Health - 1}
                    };
                    //this also gets the loggedinplayer again and sets loggedinplayer after being updated
                    playerService.UpdateFields(updatesLife);
                    if (State.currentPlayer.Health == 0)
                    {
                        Console.WriteLine("Oh no! You are out of health. You are dead. If only you had some equipment to better your odds...");
                        var updatesPlayer = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 0},
                            {"Health", 5},
                        };
                        playerService.UpdateFields(updatesPlayer);
                        var resetsPlayerItems = new Dictionary<string, object>
                        {
                            {"Sword", 0 },
                            {"Shield", 0 },
                            {"Armor", 0 },
                            {"Helmet", 0 },
                            {"DungeonKey", 0 },
                        };
                        playerItemsService.UpdateFields(resetsPlayerItems);
                        stillInRoom = false;
                        inBattle = false;
                        break;
                    };
                }
                else
                {
                    Console.WriteLine("The guard swings his big sword at you, but he misses!");
                    Console.WriteLine("");
                }
                // if player already dead, end battle.
                if (!inBattle) break;

                int playerAttackRoll = playerService.Rolld20Attack(dieRollAdditionalAttack);
                if (playerAttackRoll > 12)
                {
                    if (State.playerItems.Sword == 1)
                    {
                        Console.WriteLine("You swing your sword back at him, and it connects!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("You throw a punch at him, and it connects!");
                        Console.WriteLine("");
                    }
                    Console.WriteLine($"The guard's health goes down from {enemyGuardHealth} to {enemyGuardHealth - 1}.");
                    Console.WriteLine("");
                    enemyGuardHealth = enemyGuardHealth - 1;
                    if (enemyGuardHealth == 0)
                    {
                        Console.WriteLine("The guard falls down, defeated. He has been slain!");
                        inBattle = false;
                        break;
                    }
                }
                else
                {

                    if (State.playerItems.Sword == 1)
                    {
                        Console.WriteLine("You swing your sword back at him, and but it misses!");
                    }
                    else
                    {
                        Console.WriteLine("You throw a punch at him, but it misses!");
                    }
                }

            }
            //basically if you died
            if (!stillInRoom) break;

            Console.WriteLine("Now, with the guard slain, nobody can stop you from escaping!");
            Console.WriteLine("You walk over to the wooden door on the other side of the room, open it, and step out.");
            var updatesRoom = new Dictionary<string, object>
                {
                    {"CurrentRoom", 4},
                };
            playerService.UpdateFields(updatesRoom);
            stillInRoom = false;
            break;

        }

    }
}