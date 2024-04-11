using System;
using System.IO;
using System.Linq;
using VISAALMIncomingAPI.WF;

class Program
{
    static void Main(string[] args)
    {
        var getCurrentDirectory = Directory.GetCurrentDirectory();
        // Find the index of the "bin" directory
        int binIndex = getCurrentDirectory.IndexOf("bin", StringComparison.OrdinalIgnoreCase);

        // Extract the directory path before the "bin" directory
        string jsonFilePath = getCurrentDirectory.Substring(0, binIndex);
        jsonFilePath = jsonFilePath.Replace('\\', '/');
        jsonFilePath += "/data.txt";
        int dataToAdd = 200; // Example data to add

        string filePath = jsonFilePath; // Path to your text file

        // Read existing content of the text file
        string existingContent = File.Exists(filePath) ? File.ReadAllText(filePath) : "";

        // Split the existing content by comma to get individual data
        string[] existingData = existingContent.Split(',');

        // Check if the dataToAdd is already present
        bool isDataPresent = existingData.Any(x => x.Trim() == dataToAdd.ToString());

        if (!isDataPresent)
        {
            // Append the new data to the file
            using (StreamWriter writer = File.AppendText(filePath))
            {
                // Append comma if existing content is not empty
                if (!string.IsNullOrEmpty(existingContent))
                {
                    writer.Write(",");
                }
                // Append new data
                writer.Write(dataToAdd);
            }

            Console.WriteLine($"Data {dataToAdd} added to the file.");
        }
        else
        {
            Console.WriteLine($"Data {dataToAdd} already exists in the file.");
        }
        var data2 = new List<VISAAMLIncomingRequestModel>()
        {
            new VISAAMLIncomingRequestModel
            {
                groupID = "1",
                updateReferenceID = "1",
                rejectCode = "1",
                rejectDesc = "1",

            }
        };
        var data = GetRequiredJobs();
        foreach (var (item1, item2) in data.Zip(data2, (x, y) => (x, y)))
        {
            Console.WriteLine($"Item1: {item1}, Item2: {item2}");
        }
        Console.WriteLine(data);
    }
    public static List<string> GetRequiredJobs()
    {
        var getCurrentDirectory = Directory.GetCurrentDirectory();
        string jsonFilePath = getCurrentDirectory.Replace("\\bin\\Debug\\net8.0", "");
        jsonFilePath = jsonFilePath.Replace('\\', '/');
        jsonFilePath += "/data.txt";
        string filePath = jsonFilePath;
        List<string> dataList = new List<string>();

        // Read the content of the text file
        string fileContent = File.ReadAllText(filePath);

        // Split the content by commas
        string[] data = fileContent.Split(',');

        // Add each substring to the list
        foreach (string item in data)
        {
            dataList.Add(item.Trim()); // Trim to remove leading/trailing whitespace
        }

        // Display the list
        foreach (string item in dataList)
        {
            Console.WriteLine(item);
        }
        return dataList;
    }
}
