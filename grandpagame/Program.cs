using System;

class Program
{
    static void Main()
    {
        char[,] tabuleiro = new char[3, 3];
        IniciarTabuleiro(tabuleiro);
        bool jogoAtivo = true;
        char jogadorAtual = 'X';
        while (jogoAtivo)
        {
            Console.WriteLine($"\nVez do jogador {jogadorAtual}");
            int linha, coluna;
            while (true)
            {
                MostrarTabuleiro(tabuleiro);
                
                Console.WriteLine("\nDigite o número da linha: (0-2)");
                int.TryParse(Console.ReadLine(), out linha);
                Console.WriteLine("\nDigite o número da linha: (0-2)");
                int.TryParse(Console.ReadLine(), out coluna);

                if (linha >= 0 && linha < 3 && coluna >= 0 && coluna < 3)
                {
                    if (tabuleiro[linha, coluna] == ' ')
                    {
                        // posição válida.
                        Console.WriteLine($"Posição escolhida [{linha}, {coluna}] é válida.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Coordenas já ocupada. Tente novamente.");
                    }
                } else
                {
                    Console.WriteLine("Coordenadas inválidas. Tente novamente.");
                }
            }
            tabuleiro[linha, coluna] = jogadorAtual;

            if (VerificarVitoria(tabuleiro, jogadorAtual))
            {
                Console.WriteLine($"\nParabéns, o jogador {jogadorAtual} ganhou!");
                jogoAtivo = false;
            }
            else if (VerificarEmpate(tabuleiro))
            {
                Console.WriteLine("\nEmpate!\nNão houve vencedor.");
                jogoAtivo = false;
            }
            else
            {
                jogadorAtual = (jogadorAtual == 'X') ? 'X' : 'O';
            }
        }
    }
    static void IniciarTabuleiro(char[,] tabuleiro)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tabuleiro[i, j] = ' ';
            }
        }
    }
    static void MostrarTabuleiro(char[,] tabuleiro)
    {
        Console.Clear();
        Console.WriteLine("\n   0   1   2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + tabuleiro[i, j] + " ");
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  ---+---+---");
        }
    }
    static bool VerificarVitoria(char[,] tabuleiro, char jogadorAtivo)
    {
        // linhas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == jogadorAtivo && tabuleiro[i, 1] == jogadorAtivo && tabuleiro[i, 2] == jogadorAtivo)
            {
                return true;
            }
        }
        // colunas
        for (int j = 0; j < 3; j++)
        {
            if (tabuleiro[0, j] == jogadorAtivo && tabuleiro[1, j] == jogadorAtivo && tabuleiro[j, 2] == jogadorAtivo)
            {
                return true;
            }
        }
        // diagonal \
        /*
           0 1 2
         0 x| |  
         1  |x|
         2  | |x

         */
        if (tabuleiro[0, 0] == jogadorAtivo && tabuleiro[1, 1] == jogadorAtivo && tabuleiro[2, 2] == jogadorAtivo)
        {
            return true;
        }
        // diagonal /
        /*
           0 1 2
         0  | |O  
         1  |O|
         2 O| | 

         */
        else if (tabuleiro[2, 0] == jogadorAtivo && tabuleiro[1, 1] == jogadorAtivo && tabuleiro[0, 2] == jogadorAtivo)
        {
            return true;
        }
            return false;
    }
    static bool VerificarEmpate(char[,] tabuleiro)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return false;
    }
}
