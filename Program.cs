using System;

class RPGGame
{
    static void Main()
    {
        string playerName;

        Console.WriteLine("Welcome adventurer!");
        Console.WriteLine("Enter your character's name: ");
        playerName = Console.ReadLine();

        Console.WriteLine("Choose your class:");
        Console.WriteLine("1. Warrior - 120 HP, 20-30 damage");
        Console.WriteLine("2. Archer - 100 HP, 25-35 damage");
        Console.WriteLine("3. Spearman - 130 HP, 15-25 damage");

        Console.Write("Enter your choice (1-3): ");
        string classChoice = Console.ReadLine();

        int playerHealth;
        int minPlayerAttack;
        int maxPlayerAttack;

        switch (classChoice)
        {
            case "1":
                playerHealth = 120;
                minPlayerAttack = 20;
                maxPlayerAttack = 30;
                break;
            case "2":
                playerHealth = 100;
                minPlayerAttack = 25;
                maxPlayerAttack = 35;
                break;
            case "3":
                playerHealth = 130;
                minPlayerAttack = 15;
                maxPlayerAttack = 25;
                break;
            default:
                classChoice = "1";
                Console.WriteLine("Invalid choice. Defaulting to Warrior class.");
                playerHealth = 120;
                minPlayerAttack = 20;
                maxPlayerAttack = 30;
                break;
        }

        int playerMaxHealth = playerHealth;

        Console.WriteLine("Character creation successful!");

        // Enemy selection
        Console.WriteLine("\nChoose your enemy:");
        Console.WriteLine("1. Bandit - Moderate health and attack");
        Console.WriteLine("2. Outlaw - High health and low attack");
        Console.WriteLine("3. Deserter - Moderate health and high attack");

        Console.Write("Enter your choice (1-3): ");
        string enemyChoice = Console.ReadLine();

        int enemyHealth;
        int minEnemyAttack;
        int maxEnemyAttack;

        switch (enemyChoice)
        {
            case "1":
                enemyHealth = 80;
                minEnemyAttack = 15;
                maxEnemyAttack = 25;
                break;
            case "2":
                enemyHealth = 150;
                minEnemyAttack = 10;
                maxEnemyAttack = 20;
                break;
            case "3":
                enemyHealth = 100;
                minEnemyAttack = 25;
                maxEnemyAttack = 35;
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to Bandit.");
                enemyHealth = 80;
                minEnemyAttack = 15;
                maxEnemyAttack = 25;
                break;
        }
        
        int potions = 3;

        Console.WriteLine($"\nWelcome, {playerName} the {(classChoice == "1" ? "Warrior" : (classChoice == "2" ? "Archer" : "Spearman"))}! Let's start your adventure.");
        Console.WriteLine("\nA fierce enemy approaches!");

        Random random = new();

        while (playerHealth > 0 && enemyHealth > 0)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Drink health potion");
            Console.WriteLine("3. Run");

            Console.Write("Choose your action: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Player attacks the enemy
                    int playerDamageDealt = random.Next(minPlayerAttack, maxPlayerAttack + 1);
                    enemyHealth -= playerDamageDealt;
                    Console.WriteLine($"You attack the enemy for {playerDamageDealt} damage. Enemy's health: {enemyHealth}");

                    // Enemy's turn to attack
                    if (enemyHealth > 0)
                    {
                        int enemyDamageDealt = random.Next(minEnemyAttack, maxEnemyAttack + 1);
                        playerHealth -= enemyDamageDealt;
                        Console.WriteLine($"The enemy attacks you for {enemyDamageDealt} damage. Your health: {playerHealth}");
                    }
                    break;
                case "2":
                    // Player drinks a health potion
                    if (potions > 0)
                    {
                        playerHealth += 30;
                        if (playerHealth > playerMaxHealth) // Limit player health
                        {
                            playerHealth = playerMaxHealth;
                        }
                        potions--;
                        Console.WriteLine($"You drink a health potion. Your health is now {playerHealth}. Potions left: {potions}");
                    }
                    else
                    {
                        Console.WriteLine("No potions left!");
                    }
                    break;
                case "3":
                    Console.WriteLine("You run away from the enemy. Coward!");
                    playerHealth = 0;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Choose a valid option.");
                    break;
            }
        }

        // Game result
        if (playerHealth <= 0)
        {
            Console.WriteLine("Game Over! You were defeated.");
        }
        else if (enemyHealth <= 0)
        {
            Console.WriteLine("Congratulations! You defeated the enemy and emerged victorious!");
        }
    }
}