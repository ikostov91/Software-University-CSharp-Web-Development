using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "wubbalubbadubdub")
                {
                    break;
                }

                string[] currentPokemonEvolution = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (currentPokemonEvolution.Length == 1)
                {
                    PrintCurrentPokemonEvolutions(currentPokemonEvolution[0], pokemons);
                    continue;
                }

                string name = currentPokemonEvolution[0];
                string evolution = currentPokemonEvolution[1];
                int index = int.Parse(currentPokemonEvolution[2]);

                AddPokemonInfo(name, evolution, index, pokemons);
            }

            PrintAllPokemonsAndEvolutions(pokemons);
        }

        private static void AddPokemonInfo(string name, string evolution, int index, List<Pokemon> pokemons)
        {
            if (!pokemons.Exists(p => p.Name == name))
            {
                Pokemon newPokemon = new Pokemon
                {
                    Name = name,
                    Evolutions = new List<Evolution>()
                };
                pokemons.Add(newPokemon);
            }

            Evolution currentEvolution = new Evolution
            {
                EvolutionType = evolution,
                EvolutionIndex = index
            };

            Pokemon currentPokemon = pokemons.Where(p => p.Name == name).First();
            currentPokemon.Evolutions.Add(currentEvolution);
        }

        private static void PrintAllPokemonsAndEvolutions(List<Pokemon> pokemons)
        {
            foreach (Pokemon pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Name}");

                foreach (var evolutionIndex in pokemon.Evolutions.OrderByDescending(x => x.EvolutionIndex))
                {
                    Console.WriteLine($"{evolutionIndex.EvolutionType} <-> {evolutionIndex.EvolutionIndex}");
                }
            }
        }

        private static void PrintCurrentPokemonEvolutions(string name, List<Pokemon> pokemons)
        {
            if (pokemons.Exists(x => x.Name == name))
            {
                Pokemon pokemon = pokemons.Where(x => x.Name == name).First();

                Console.WriteLine($"# {pokemon.Name}");

                foreach (var evolution in pokemon.Evolutions)
                {
                    Console.WriteLine($"{evolution.EvolutionType} <-> {evolution.EvolutionIndex}");
                }
            }
        }

        class Pokemon
        {
            public string Name { get; set; }
            public List<Evolution> Evolutions { get; set; }
        }

        class Evolution
        {
            public string EvolutionType { get; set; }
            public int EvolutionIndex { get; set; }
        }
    }
}
