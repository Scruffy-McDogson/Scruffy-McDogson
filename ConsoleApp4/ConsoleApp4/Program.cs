using System;

namespace ConsoleApp4
{
    using static Console;
    class Program
    {
        static void Main(string[] args)
        {
            // Acceptable inputs are attack, att, Attack, heal, potion, and search

            bool tryagain = true;
            while (tryagain)
            {
                WriteLine("You enter a dungeon room.");
                string input;
                int HeroHP = 100;
                int diesize = 6;
                int result;
                string equip;
                bool sword = false;
                bool knife = false;
                bool ask = true;
                string preference = "null";
                tryagain = false;
                
                int potion = 0;


                result = Roll(100);
                int HPdisplay = Math.Max(result, 50);
                WriteLine("A Terrifying Monster Appeared. It has " + HPdisplay + "Health Points. On your turn you can do one of the following: attack(att), search, or heal/potion. Remember, searching can be risky but can be rewarding.");
                while (HPdisplay > 0 && HeroHP > 0)

                {
                    if (sword == true && knife == true && ask == true)
                    {

                        WriteLine("You are holding both a knife and a sword. Which would you like to use?");
                        input = ReadLine();
                        switch (input)
                        {
                            case ("sword"):
                                preference = "sword";
                                break;
                            case ("knife"):
                                preference = "knife";
                                break;
                        }
                        WriteLine("Would you like to be asked again?");
                        if (ReadLine() == "yes")
                        {
                            ask = true;
                        }
                        else
                        {
                            ask = false;
                        }
                    }

                    if (sword && !knife)
                    {
                        equip = "sword";
                        diesize = 16;
                    }
                    else if (!sword && knife)
                    {
                        equip = "knife";
                        diesize = 10;
                    }
                    else if (sword && knife && preference == "knife")
                    { equip = "knife"; }
                    else if (sword && knife && preference == "sword")
                    { equip = "sword"; }
                    else
                    {
                        equip = "nothing";
                        diesize = 6;
                    }

                    WriteLine("You have " + HeroHP + " HP remaining" + "          Healing Potions: " + potion + "         Equipment: " + equip);
                    WriteLine("the Monster has " + HPdisplay + " HP remaining.");

                    input = ReadLine();
                    switch (input)
                    {
                        case ("attack"):
                            result = Roll(diesize);
                            WriteLine("You Rolled " + result + "." + " The Monster lost HP and now has " + (HPdisplay - result));
                            HPdisplay = HPdisplay - result;
                            break;

                        case ("att"):
                            result = Roll(diesize);
                            WriteLine("You Rolled " + result + "." + " The Monster lost HP and now has " + (HPdisplay - result));
                            HPdisplay = HPdisplay - result;
                            break;

                        case ("Attack"):
                            result = Roll(diesize);
                            WriteLine("You Rolled " + result + "." + " The Monster lost HP and now has " + (HPdisplay - result));
                            HPdisplay = HPdisplay - result;
                            break;
                        case ("up2"):
                            diesize = (diesize + 2);
                            break;
                        case ("up10"):
                            diesize = (diesize + 10);
                            break;
                        case ("potion"):
                            if (potion > 0)
                            {
                                potion = potion - 1;
                                result = Roll(75);
                                HeroHP = Math.Min(HeroHP + result, 100);
                                WriteLine("You drank a potion and healed " + result +" HP.");
                            }
                            else
                            {
                                WriteLine("You reached into your satchel but could not find a healing potion.");
                            }
                            break;
                        case ("heal"):
                            if (potion > 0)
                            {
                                potion = potion - 1;
                                result = Roll(75);
                                HeroHP = Math.Min(HeroHP + result, 100);
                                WriteLine("You drank a potion and healed " + result + " HP.");
                            }
                            else
                            {
                                WriteLine("You reached into your satchel but could not find a healing potion.");
                            }
                            break;
                        case ("search"):
                            result = Roll(100) + 1;
                            if (result < 45)
                            {
                                WriteLine("You search the area but find nothing. Better luck next time.");
                            }
                            else if (result >= 45 && result < 75)
                            {
                                potion++;
                                WriteLine("You Found a potion! You now have " + potion + " potion(s)");
                            }
                            else if (result >= 75 && result < 90)
                            {
                                knife = true;
                                WriteLine("You found a knife!");
                            }
                            else if (result >= 90)
                            {
                                sword = true;
                                WriteLine("You found a sword!");
                            }
                            break;
                        default:
                            result = Roll(diesize);
                            WriteLine("You do nothing");
                            break;


                    }

                    result = Roll(100) + 1;
                    if (result < 30)
                    {
                        //Small Attack
                        result = Roll(8);
                        HeroHP = (HeroHP - result);
                        WriteLine("The monster punches you for " + result + " damage.");
                    }
                    else if (result >= 30 && result < 60)
                    {
                        //medium Attack
                        result = Roll(14);
                        HeroHP = (HeroHP - result);
                        WriteLine("The monster bites you for " + result + " damage.");

                    }
                    else if (result >= 60 && result < 85)
                    {
                        //strong Attack
                        result = Roll(20);
                        HeroHP = (HeroHP - result);
                        WriteLine("The monster mauls you for " + result + " damage.");

                    }
                    else if (result >= 85 && HPdisplay > 50)
                    {
                        //medium Attack
                        result = Roll(40);
                        HeroHP = (HeroHP - result);
                        WriteLine("The monster casted 'Death Storm' on you for " + result + " damage.");

                    }
                    else if (result >= 85 && HPdisplay < 50)
                    {
                        //medium Attack
                        result = Roll(20);
                        HPdisplay = (HPdisplay + result);
                        WriteLine("The monster casts regeneration and heals itself for " + result + " HP.");

                    }
                }



                if (HPdisplay <= 0)
                {
                    WriteLine("You have defeated the monster!");
                }
                else if (HeroHP <= 0)
                {
                    WriteLine("You have been defeated.");
                    
                }
                WriteLine("Would You Like to Play Again?");
                input = ReadLine();
                if (input == "yes")
                {
                    tryagain = true;
                }
                else
                {
                    tryagain = false;
                    WriteLine("Thanks for playing!");
                    ReadLine();
                }

            }
        }

        static int Roll(int die)
        {
            Random D6 = new Random();
            double num1 = D6.Next(die);
           num1 = Math.Round(num1 + 1);
            int num2 = Convert.ToInt32(num1);
            return num2;
            

        }
    }

}
