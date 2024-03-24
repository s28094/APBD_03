namespace DefaultNamespace;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Creating Containers
            Console.WriteLine("Creating Containers...");
            var liquidContainer1 = new LiquidContainer(200, 100, 150, 5000, isHazardous: true);
            var liquidContainer2 = new LiquidContainer(220, 110, 160, 4800, isHazardous: false);
            var gasContainer1 = new GasContainer(180, 80, 120, 3000, pressure: 2.5);
            var refrigeratedContainer1 = new RefrigeratedContainer(220, 120, 170, 4000, "Bananas", requiredTemperature: 13.3);
            var refrigeratedContainer2 = new RefrigeratedContainer(210, 130, 180, 4500, "Fish", requiredTemperature: 2.0);

            // Printing Container Information After Creation
            Console.WriteLine("\nPrinting Container Information After Creation...");
            PrintContainerInfo(liquidContainer1);
            PrintContainerInfo(liquidContainer2);
            PrintContainerInfo(gasContainer1);
            PrintContainerInfo(refrigeratedContainer1);
            PrintContainerInfo(refrigeratedContainer2);

            // Creating a List of Containers
            var containers = new List<Container> { liquidContainer1, liquidContainer2, gasContainer1, refrigeratedContainer1, refrigeratedContainer2 };

            // Loading Cargo into Containers
            Console.WriteLine("\nLoading Cargo into Containers...");
            liquidContainer1.LoadCargo(1);
            liquidContainer2.LoadCargo(1);
            gasContainer1.LoadCargo(1);
            refrigeratedContainer1.LoadCargo(1);
            refrigeratedContainer2.LoadCargo(1);

            // Printing Container Information After Loading Cargo
            Console.WriteLine("\nPrinting Container Information After Loading Cargo...");
            PrintContainerInfo(liquidContainer1);
            PrintContainerInfo(liquidContainer2);
            PrintContainerInfo(gasContainer1);
            PrintContainerInfo(refrigeratedContainer1);
            PrintContainerInfo(refrigeratedContainer2);

            // Creating Ship1 and Ship2
            var ship1 = new ContainerShip("Ship1", 30, 100, 5000);
            var ship2 = new ContainerShip("Ship2", 25, 80, 4000);

            // Loading Containers onto Ship1
            Console.WriteLine("\nLoading Containers onto Ship1...");
            ship1.LoadContainer(liquidContainer1);
            ship1.LoadContainer(liquidContainer2);
            ship1.LoadContainer(gasContainer1);
            ship1.LoadContainer(refrigeratedContainer1);
            ship1.LoadContainer(refrigeratedContainer2);

            // Printing Ship1 Information
            Console.WriteLine("\nPrinting Ship1 Information...");
            ship1.PrintShipInfo();

            // Loading Containers onto Ship2
            Console.WriteLine("\nLoading Containers onto Ship2...");
            ship2.LoadContainer(refrigeratedContainer1);
            ship2.LoadContainer(refrigeratedContainer2);

            // Printing Ship2 Information
            Console.WriteLine("\nPrinting Ship2 Information...");
            ship2.PrintShipInfo();

            // Removing a Container from Ship1
            Console.WriteLine("\nRemoving a Container from Ship1...");
            ship1.RemoveContainer(gasContainer1);

            // Printing Ship1 Information After Removal
            Console.WriteLine("\nPrinting Ship1 Information After Removing a Container...");
            ship1.PrintShipInfo();

            // Unloading a Container from Ship2
            Console.WriteLine("\nUnloading a Container from Ship2...");
            ship2.UnloadContainer(refrigeratedContainer1);

            // Printing Ship2 Information After Unloading
            Console.WriteLine("\nPrinting Ship2 Information After Unloading a Container...");
            ship2.PrintShipInfo();

            // Replacing a Container on Ship1
            Console.WriteLine("\nReplacing a Container on Ship1...");
            var newLiquidContainer = new LiquidContainer(205, 115, 155, 4900, isHazardous: true);
            ship1.ReplaceContainer(liquidContainer2, newLiquidContainer);

            // Printing Ship1 Information After Replacement
            Console.WriteLine("\nPrinting Ship1 Information After Replacing a Container...");
            ship1.PrintShipInfo();

            // Transferring a Container from Ship1 to Ship2
            Console.WriteLine("\nTransferring a Container from Ship1 to Ship2...");
            ship1.TransferContainer(newLiquidContainer, ship2);

            // Printing Ship1 and Ship2 Information After Transfer
            Console.WriteLine("\nPrinting Ship1 Information After Transferring a Container...");
            ship1.PrintShipInfo();

            Console.WriteLine("\nPrinting Ship2 Information After Transferring a Container...");
            ship2.PrintShipInfo();

            // Final Container Information
            Console.WriteLine("\nFinal Container Information:");
            PrintContainerInfo(liquidContainer1);
            PrintContainerInfo(newLiquidContainer);
            PrintContainerInfo(gasContainer1);
            PrintContainerInfo(refrigeratedContainer1);
            PrintContainerInfo(refrigeratedContainer2);

            // Final Ship Information
            Console.WriteLine("\nFinal Ship1 Information:");
            ship1.PrintShipInfo();

            Console.WriteLine("\nFinal Ship2 Information:");
            ship2.PrintShipInfo();
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Overfill Exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    static void PrintContainerInfo(Container container) 
    {
        Console.WriteLine($"Container Number: {container.SerialNumber}");
        Console.WriteLine($"Cargo Mass: {container.MassOfCargo} kg");
        Console.WriteLine($"Height: {container.Height} cm");
        Console.WriteLine($"Tare Weight: {container.TareWeight} kg");
        Console.WriteLine($"Depth: {container.Depth} cm");
        Console.WriteLine($"Maximum Payload: {container.MaximumPayload} kg");

        if (container is LiquidContainer liquidContainer)
        {
            Console.WriteLine($"Type: Liquid Container");
            Console.WriteLine($"Is Hazardous: {liquidContainer.IsHazardous}");
        }
        else if (container is GasContainer gasContainer)
        {
            Console.WriteLine($"Type: Gas Container");
            Console.WriteLine($"Pressure: {gasContainer.Pressure} atm");
        }
        else if (container is RefrigeratedContainer refrigeratedContainer)
        {
            Console.WriteLine($"Type: Refrigerated Container");
            Console.WriteLine($"Product Type: {refrigeratedContainer.ProductType}");
            Console.WriteLine($"Required Temperature: {refrigeratedContainer.RequiredTemperature} °C");
        }

        Console.WriteLine();
    }
}