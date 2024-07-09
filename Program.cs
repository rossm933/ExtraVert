// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;

List<Plant> plants = new List<Plant>()
{ 
new Plant()
{
    Species = "Venus Fly Trap",
    LightNeeds = 3,
    AskingPrice = 22,
    City = "Nashville",
    Zip = 12345,
    Sold = false
},
new Plant()
{
 Species = "Sunflower",
 LightNeeds = 4,
 AskingPrice = 32,
 City = "Pittsburgh",
 Zip = 14034,
 Sold = false
},
new Plant()
{
 Species = "Tulips",
 LightNeeds = 2,
 AskingPrice = 15,
 City = "Chicago",
 Zip = 16033,
 Sold = false
},
new Plant()
{
 Species = "Basil",
 LightNeeds = 4,
 AskingPrice = 42,
 City = "Cincinnati",
 Zip = 34533,
 Sold = false
},
new Plant()
{
 Species = "Pitcher Plant",
 LightNeeds = 1,
 AskingPrice = 52,
 City = "Boston",
 Zip = 67785,
 Sold = false
}
};
Plant plantOfTheDay;

string greeting = @"Welcome to ExtraVert!";

Console.WriteLine(greeting);

    string choice = null;
    while (choice != "0")
    {
    Console.WriteLine(@"Choose an option: 
                      0. Exit
                      1. View All Plants
                      2. Add a Plant 
                      3. Adopt a Plant
                      4. Delist a Plant
                      5. Plant of the Day
                      6. Search by Light Needs
                      7. View Plant Statistics");

        choice = Console.ReadLine();

 if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
       ListPlants();
    }
    else if (choice == "2")
    {
       AddPlant();
    }
    else if (choice == "3")
    {
        AdoptPlant();
    }
    else if (choice == "4")
    {
        DelistPlant();
    }
    else if (choice == "5")
    {
        PlantOfTheDay();
    }
    else if (choice == "6")
    {
        SearchByLightNeeds();
    }
    else if (choice == "7")
    {
        ViewPlantStatistics();
    }
    else
    {
        Console.WriteLine("Please choose an existing option only!");
    }
}

    void ListPlants()
{
for (int i = 0; i < plants.Count; i++)
    {
        string soldStatusString = plants[i].Sold ? "was sold" : "is available";
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {soldStatusString} for {plants[i].AskingPrice} dollars.");
    }
}

void AddPlant()
{
    // OBTAINING USER INPUT
    Console.WriteLine("Please supply the plant species");
    string plantSpecies = Console.ReadLine();
    Console.WriteLine("Please supply the light needs of the plant on a scale from 1-5");
    int plantLightNeeds = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Please supply the asking price of the plant");
    decimal plantAskingPrice = Decimal.Parse(Console.ReadLine());
    Console.WriteLine("Please supply the city name of the plant");
    string plantCityName = Console.ReadLine();
    Console.WriteLine("Please supply the zip code");
    int plantZipCode = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Please supply the date this plant is available until.");
    Console.WriteLine("Year: ex. 2024");
    int plantYear = int.Parse(Console.ReadLine());
    Console.WriteLine("Month: ex. 01 - January.");
    int plantMonth = int.Parse(Console.ReadLine());
    Console.WriteLine("Day: ex. 1-31");
    int plantDay = int.Parse(Console.ReadLine());

    // Taking user input and appending it to new instance of proj
    try
    {
        Plant PlantToAdd = new Plant();
        PlantToAdd.Species = plantSpecies;
        PlantToAdd.LightNeeds = plantLightNeeds;
        PlantToAdd.AskingPrice = plantAskingPrice;
        PlantToAdd.City = plantCityName;
        PlantToAdd.Zip = plantZipCode;
        PlantToAdd.Sold = false;
        PlantToAdd.AvailableUntil = new DateTime(plantYear, plantMonth, plantDay);
        // Adding user created plant
        plants.Add(PlantToAdd);
    }
    catch
    {
        Console.WriteLine("Please pick a valid date!");
    }
}
void AdoptPlant()
{
    List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();

    Console.WriteLine("Select a plant using its number:\n");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }

    Console.WriteLine();
    int choice = Convert.ToInt32(Console.ReadLine());

    if (choice > 0 && choice <= availablePlants.Count)
    {
        Plant selectedPlant = availablePlants[choice - 1];
        selectedPlant.Sold = true;
        Console.WriteLine($"\n{selectedPlant.Species} has been purchased!");
    }
}

void DelistPlant()
{
    string choice = null;

    while (choice != "0")
    {
        try
        {
            // loop through products but create a ReadLine
            Console.WriteLine("0. Goodbye");
            for (int i = 0; i < plants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {plants[i].Species}");

            }
            choice = Console.ReadLine();
            plants.RemoveAt(Int32.Parse(choice) - 1);
        }
        catch
        {
            break;
        }

    }

}

void PlantOfTheDay()
{
    Random random = new Random();

    List<Plant> unsoldPlants = plants.Where(plant => !plant.Sold).ToList();

    if (unsoldPlants.Count > 0)
    {
        int randomPlantIndex = random.Next(0, unsoldPlants.Count);
        plantOfTheDay = unsoldPlants[randomPlantIndex];

        Console.WriteLine("\n\nPlant of the Day:\n");
        Console.WriteLine($"{plantOfTheDay.Species} is the Plant of the Day!");
        Console.WriteLine($"Light Needs: {plantOfTheDay.LightNeeds}");
        Console.WriteLine($"Asking Price: {plantOfTheDay.AskingPrice:C}");
        Console.WriteLine($"City: {plantOfTheDay.City}");
        Console.WriteLine($"ZIP Code: {plantOfTheDay.Zip}");
    }
    else
    {
        Console.WriteLine("\n\nPlant of the Day: No unsold plants available.");
    }
}

void SearchByLightNeeds()
{
    List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();

    int choice;
    Console.WriteLine("Enter the maximum Light Needs Rating (1-5): ");
    choice = Int16.Parse(Console.ReadLine());
    List<Plant> searchedPlant = availablePlants.Where(plant => plant.LightNeeds == choice).ToList();
    foreach (Plant plant in searchedPlant)
    {
        Console.WriteLine(plant.Species);
    }
}

void ViewPlantStatistics()
{
    string choice = null;
    while (choice != "0")
    {
        Console.WriteLine(@"Choose an option: 
                      0. Exit
                      1. View Plant with Lowest Price.
                      2. View Number of Plants Available.
                      3. View Plant with Highest Light Needs.
                      4. View Average Light Needs.
                      5. View Percentage of Plants Adopted.");

        choice = Console.ReadLine();

        if (choice == "0")
        {
            Console.WriteLine("Goodbye!");
        }
        else if (choice == "1")
        {
            LowestPrice();
        }
        else if (choice == "2")
        {
            NumberOfAvailablePlants();
        }
        else if (choice == "3")
        {
            HighestLightNeeds();
        }
        else if (choice == "4")
        {
            AverageLightNeeds();
        }
        else if (choice == "5")
        {
            PercentageOfPlantsAdopted();
        }
        else
        {
            Console.WriteLine("Please choose an existing option only!");
        }
    }
}

void LowestPrice()
{
    List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();
    string plantLowestPrice =
                availablePlants.Aggregate(availablePlants[0], (currLongest, next) =>
                currLongest.AskingPrice > next.AskingPrice ? next : currLongest,
                plant => plant.Species);
    Console.WriteLine($"The least expensive plant is {plantLowestPrice}");
}

void NumberOfAvailablePlants()
{
    List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();
    Console.WriteLine($"There are {availablePlants.Count} plants available.");
}

void HighestLightNeeds()
{
    List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();
    string plantHighestneeds = availablePlants.Aggregate(availablePlants[0], (currHighest, next) =>
                currHighest.LightNeeds < next.LightNeeds ? next : currHighest,
                plant => plant.Species);
    Console.WriteLine($"The plant with the highest light needs is {plantHighestneeds}");
}

void AverageLightNeeds()
{
    List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();
    int sumLightNeeds = availablePlants.Aggregate(0, (acc, curr) =>
               acc + curr.LightNeeds,
               sum => sum
           );
    Console.WriteLine($"The average light needs is {sumLightNeeds / availablePlants.Count}");
}

void PercentageOfPlantsAdopted()
{
    List<Plant> adoptedPlants = plants.Where(plant => plant.Sold == true).ToList();
    double percentPlantAdopted = Math.Round((double)adoptedPlants.Count / (double) plants.Count * 100);
    Console.WriteLine($"Percentage of Plants Adopted: {percentPlantAdopted}%");
}

string PlantDetails(Plant plant)
{
    string plantString = $"Species: {plant.Species}\n" +
                         $"Light Needs: {plant.LightNeeds}/10\n" +
                         $"Asking Price: {plant.AskingPrice:C}\n" +
                         $"City: {plant.City}\n" +
                         $"ZIP Code: {plant.Zip}\n" +
                         $"Sold: {(plant.Sold ? "Yes" : "No")}\n" +
                         $"Available Until: {plant.AvailableUntil}\n";

    return plantString;
}