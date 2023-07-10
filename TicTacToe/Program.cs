namespace TicTacToe;

internal static class Program
{
    static char[] plateau = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int joueur = new Random().Next(1, 3);
    static int choix;
    static StatutPartie StatutPartie = StatutPartie.EnCours;
    
    static void Main(string[] args)
    {
        Console.WriteLine($"Le joueur {joueur} commence !");
        
        do
        {
            Console.Clear();
            Console.WriteLine("Joueur1:X et Joueur2:O");
            Console.WriteLine("\n");
            if (joueur % 2 == 0)//checking the chance of the player
            {
                Console.WriteLine("Au joueur 2 de jouer");
            }
            else
            {
                Console.WriteLine("Au joueur 1 de jouer");
            }
            Console.WriteLine("\n");
            
            AfficherPlateau();
            
            choix = int.Parse(Console.ReadLine());
            
            // Si la case choisie n'est pas déjà jouée, on la joue et on incrémente l'utilisateur
            if (plateau[choix - 1] != 'X' && plateau[choix - 1] != 'O')
            {
                if (joueur % 2 == 0)
                {
                    plateau[choix - 1] = 'O';
                    joueur++;
                }
                else
                {
                    plateau[choix - 1] = 'X';
                    joueur++;
                }
            }
            else
                // Sinon on informe l'utilisateur
            {
                Console.WriteLine($"Désolé mais la case {choix} contient déjà un '{plateau[choix - 1]}' !");
                Console.WriteLine("");
                Console.WriteLine("Rechargement du plateau dans 2 secondes.....");
                Thread.Sleep(2000);
            }
            StatutPartie = VerifierVictoire();
        }
        while (StatutPartie == StatutPartie.EnCours);

        Console.Clear();
        
        AfficherPlateau();
        
        if (StatutPartie == StatutPartie.Vainqueur)
        {
            Console.WriteLine("Le joueur {0} a gagné ! Bravo !", (joueur % 2) + 1);
        }
        else
        {
            Console.WriteLine("Egalité !");
        }
        Console.ReadLine();
    }
    
    /// <summary>
    /// Affiche l'état du plateau
    /// </summary>
    private static void AfficherPlateau()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", plateau[0], plateau[1], plateau[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", plateau[3], plateau[4], plateau[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", plateau[6], plateau[7], plateau[8]);
        Console.WriteLine("     |     |      ");
    }
    
    /// <summary>
    /// Vérifie si un joueur a gagné ou non
    /// </summary>
    /// <returns></returns>
    private static StatutPartie VerifierVictoire()
    {
        #region Victoires en ligne
        
        // Ligne 1
        if (plateau[0] == plateau[1] && plateau[1] == plateau[2])
        {
            return StatutPartie.Vainqueur;
        }
        
        // Ligne 2
        if (plateau[3] == plateau[4] && plateau[4] == plateau[5])
        {
            return StatutPartie.Vainqueur;
        }
        
        // Ligne 3
        if (plateau[5] == plateau[6] && plateau[6] == plateau[7])
        {
            return StatutPartie.Vainqueur;
        }
        
        #endregion
        
        
        #region Victoires en colonne
        
        // Colonne 1
        if (plateau[0] == plateau[3] && plateau[3] == plateau[6])
        {
            return StatutPartie.Vainqueur;
        }
        
        // Colonne 2
        if (plateau[1] == plateau[4] && plateau[4] == plateau[7])
        {
            return StatutPartie.Vainqueur;
        }
        
        // Colonne 3
        if (plateau[2] == plateau[5] && plateau[5] == plateau[8])
        {
            return StatutPartie.Vainqueur;
        }
        #endregion
        
        
        #region Victoires en diagonale
        
        if (plateau[0] == plateau[4] && plateau[4] == plateau[8])
        {
            return StatutPartie.Vainqueur;
        }
        
        if (plateau[2] == plateau[4] && plateau[4] == plateau[6])
        {
            return StatutPartie.Vainqueur;
        }
        #endregion
        
        
        #region Vérification de l'égalité
        // If all the cells or values filled with X or O then any player has won the match
        if (plateau[0] != '1' && plateau[1] != '2' && plateau[2] != '3' && plateau[3] != '4' && plateau[4] != '5' && plateau[5] != '6' && plateau[6] != '7' && plateau[7] != '8' && plateau[8] != '9')
        {
            return StatutPartie.Egalite;
        }
        #endregion
        else
        {
            return StatutPartie.EnCours;
        }
    }
}

internal enum StatutPartie
{
    EnCours,
    Egalite,
    Vainqueur
}