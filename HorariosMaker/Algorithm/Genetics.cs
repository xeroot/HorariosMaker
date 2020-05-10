using HorariosMaker.Entities;
using HorariosMaker.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorariosMaker.Algorithm
{
    public class Genetics
    {
        private static Random random = new Random();
        private Database Database;
        public double SleepSeconds { get; set; }
        private const double MIN_ACCEPTABLE_PERCENTAGE = 0.4;
        private const int MUTATION_PROBABILITY = 40;
        private int MaxGeneration = 0;

        public delegate void NewGenerationHandler(Individual[] population, int generation);
        public event NewGenerationHandler OnNewGeneration;

        public Genetics(Database database, int maxGeneration)
        {
            Database = database;
            MaxGeneration = maxGeneration;
        }

        public async Task<Individual> RunAsync(Individual[] population, Func<Individual, int> suitability)
        {
            InitialValidatation(population, suitability);
            var bestIndividual = population.First();
            var generation = 1;
            while (true)
            {
                // se envia unanotificacion a la UI en cada nueva generacion usando delegados
                NewGenerationEvent(population, generation);

                // identificar si existe un individuo los suficientemente apto para ser la solucion
                // en caso, retornar tal individuo
                foreach (var individual in population)
                    if (suitability(individual) == individual.GetAcceptableSuitability())
                        return individual;

                // se crea la nueva poblacion vacia
                var newPopulation = Enumerable.Empty<Individual>().ToList();
                var individualBySuit = new List<KeyValuePair<Individual, int>>();

                // validacion para quedarse solo con los mejores individuos antes de reproducirlos
                StayOnlyWithBetterIndividuals(population, suitability, ref bestIndividual, ref individualBySuit);
                if (MaxGeneration != 0 && generation >= MaxGeneration)
                    return bestIndividual;

                // bucle principal, recorrido de la poblacion
                for (int i = 0; i < population.Length; i++)
                {
                    // escojo a los padres
                    var firstIndividual = individualBySuit[i].Key;
                    var secondIndividual = i + 1 == individualBySuit.Count ?
                        individualBySuit.First().Key : individualBySuit[i + 1].Key;

                    // se reproducen los padres
                    var newIndividual = Reproduce(firstIndividual, secondIndividual);

                    // el hijo tiene una probabilidad de 40% de mutar
                    MutateIfPossible(newIndividual);

                    // se agrega el hijo a la nueva poblacion
                    newPopulation.Add(newIndividual);
                }

                // la poblacion anterior ahora es la nueva poblacion
                population = newPopulation.ToArray();

                generation++;

                await Task.Delay((int)(1000 * SleepSeconds));
            }
        }

        private void NewGenerationEvent(Individual[] population, int generation)
        {
            if (OnNewGeneration != null) OnNewGeneration(population, generation);
        }

        private void StayOnlyWithBetterIndividuals(Individual[] population, Func<Individual, int> suitability, ref Individual bestIndividual, ref List<KeyValuePair<Individual, int>> individualBySuit)
        {
            for (int i = 0; i < population.Length; i++)
            {
                var individual = population[i];
                var suitabilityValue = suitability(individual);
                individualBySuit.Add(new KeyValuePair<Individual, int>(individual, suitabilityValue));
            }
            individualBySuit = individualBySuit.OrderBy(x => x.Value).Reverse().ToList();

            if (suitability(individualBySuit.First().Key) > suitability(bestIndividual))
                bestIndividual = individualBySuit.First().Key;

            var minSuitAcceptable = MIN_ACCEPTABLE_PERCENTAGE * individualBySuit.First().Value;
            var lastAcceptablePos = 0;
            for (int i = 0; i < individualBySuit.Count; i++)
            {
                var newIndividual = individualBySuit[i];
                if (newIndividual.Value < minSuitAcceptable)
                    newIndividual = individualBySuit[random.Next(0, lastAcceptablePos + 1)];
                else lastAcceptablePos++;
            }
        }

        private void MutateIfPossible(Individual newIndividual)
        {
            if (random.Next(0, 100) < MUTATION_PROBABILITY)
            {
                var positionToSwap = random.Next(0, newIndividual.Size());
                newIndividual.SwapGen(positionToSwap, Database.GetRandomFromCategory(positionToSwap));
            }
        }

        private void InitialValidatation(Individual[] population, Func<Individual, int> suitability)
        {
            if (population == null || suitability == null) throw new NullReferenceException();
            if (population.Length < 2) throw new Exception("Initial population has to be more than 1");
            if (population.First().Size() < 3) throw new Exception("Each individual have to get more than 2 genes");
        }

        public Individual Reproduce(Individual firstIndividual, Individual secondIndividual)
        {
            return Reproduce(firstIndividual, secondIndividual, random.Next(1, firstIndividual.Size() - 1));
        }

        public Individual Reproduce(Individual firstIndividual, Individual secondIndividual,
            int atPosition)
        {
            var firstPart = firstIndividual.GetGenSlice(0, atPosition);
            var secondPart = secondIndividual.GetGenSlice(atPosition, secondIndividual.Size());
            return firstPart.AppendToEnd(secondPart);
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            // to-do
            return strBuilder.ToString();
        }


    }
}



/*
foreach (var _individual in population)
    if (suitability(_individual) == _individual.GetAcceptableSuitability())
        return _individual;

//Console.WriteLine("new try");

var newPopulation = Enumerable.Empty<Individual>().ToList();

var individualBySuit = new List<KeyValuePair<Individual, int>>();
foreach (var individual in population)
{
    var suitabilityValue = suitability(individual);
    individualBySuit.Add(new KeyValuePair<Individual, int>(individual, suitabilityValue));
}
individualBySuit = individualBySuit.OrderBy(x => x.Value).Reverse().ToList();
if (suitability(individualBySuit.First().Key) > suitability(bestIndividual))
    bestIndividual = individualBySuit.First().Key;
var minSuitAcceptable = 0.4 * individualBySuit.First().Value; // refactorizar
var lastAcceptablePos = 0;
for (int i = 0; i < individualBySuit.Count; i++)
{
    var newIndividual = individualBySuit[i];
    if (newIndividual.Value < minSuitAcceptable)
        newIndividual = individualBySuit[random.Next(0, lastAcceptablePos + 1)];
    else lastAcceptablePos++;
}
File.WriteAllText(Environment.CurrentDirectory + "\\test2.json", JsonConvert.SerializeObject(individualBySuit));

for (int i = 0; i < individualBySuit.Count; i++)
{
    var firstIndividual = individualBySuit[i].Key;
    var secondIndividual = i + 1 == individualBySuit.Count ?
        individualBySuit.First().Key : individualBySuit[i + 1].Key;
    var result = Mutate(firstIndividual, secondIndividual);
    newPopulation.Add(result);
}
File.WriteAllText(Environment.CurrentDirectory + "\\test3.json", JsonConvert.SerializeObject(newPopulation));

for (int i = 0; i < newPopulation.Count; i++)
{
    if (random.Next(0, 100) < 60)
    {
        var individual = newPopulation[i];
        var positionToSwap = random.Next(0, individual.Size());
        individual.SwapGen(positionToSwap, Database.GetRandomFromCategory(positionToSwap));
    }
}*/