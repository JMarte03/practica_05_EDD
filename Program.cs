using System;
using System.Collections.Generic;

class SocialNetwork
{
    private int[,] adjacencyMatrix;
    private int numberOfPeople;

    public SocialNetwork(int size)
    {
        numberOfPeople = size;
        adjacencyMatrix = new int[size, size];
    }

    // Función para agregar una conexión de amistad
    public void AddFriendship(int person1, int person2)
    {
        if (person1 < numberOfPeople && person2 < numberOfPeople)
        {
            adjacencyMatrix[person1, person2] = 1;
            adjacencyMatrix[person2, person1] = 1;
        }
        else
        {
            Console.WriteLine("Persona no válida");
        }
    }

    // Función para eliminar una conexión de amistad
    public void RemoveFriendship(int person1, int person2)
    {
        if (person1 < numberOfPeople && person2 < numberOfPeople)
        {
            adjacencyMatrix[person1, person2] = 0;
            adjacencyMatrix[person2, person1] = 0;
        }
        else
        {
            Console.WriteLine("Persona no válida");
        }
    }

    // Función para encontrar amigos en común
    public List<int> FindCommonFriends(int person1, int person2)
    {
        List<int> commonFriends = new List<int>();

        if (person1 < numberOfPeople && person2 < numberOfPeople)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                if (adjacencyMatrix[person1, i] == 1 && adjacencyMatrix[person2, i] == 1)
                {
                    commonFriends.Add(i);
                }
            }
        }
        else
        {
            Console.WriteLine("Persona no válida");
        }

        return commonFriends;
    }

    // Función para imprimir la matriz de adyacencia
    public void PrintAdjacencyMatrix()
    {
        for (int i = 0; i < numberOfPeople; i++)
        {
            for (int j = 0; j < numberOfPeople; j++)
            {
                Console.Write(adjacencyMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int numberOfPeople = 5;
        SocialNetwork network = new SocialNetwork(numberOfPeople);

        // Agregar algunas conexiones de amistad
        network.AddFriendship(0, 1);
        network.AddFriendship(0, 2);
        network.AddFriendship(1, 2);
        network.AddFriendship(1, 3);
        network.AddFriendship(2, 4);

        // Imprimir la matriz de adyacencia
        Console.WriteLine("Matriz de adyacencia:");
        network.PrintAdjacencyMatrix();

        // Encontrar y mostrar amigos en común
        int person1 = 0;
        int person2 = 1;

        List<int> commonFriends = network.FindCommonFriends(person1, person2);
        Console.WriteLine($"\nAmigos en común entre la persona {person1} y la persona {person2}:");
        foreach (int friend in commonFriends)
        {
            Console.WriteLine(friend);
        }
    }
}
