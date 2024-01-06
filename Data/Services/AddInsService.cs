
using Newtonsoft.Json;
using Cafe.Data.Model;
using Cafe.Data.Utils;

namespace Cafe.Data.Services
{
    public class AddInsServices
    {
        // Saves lists of hobby data Injected to a JSON file.
        public static void SaveAddInsToJson(List<AddIns> addIns)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.AddInsFilePath();

            // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(addIns, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }

        //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.
        public static void InjectSampleAddInsData()
        {
            // Gets the file path where hobby data will be stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.AddInsFilePath();

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample hobby data in a object of List<Hobby> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<AddIns> sampleAddIns = new List<AddIns>
            {
                new AddIns { Name = "Sugar" , Price = "100" },
                new AddIns { Name = "Lemon", Price= "150" },
                new AddIns { Name = "Milk" , Price= "210" },
                new AddIns { Name = "Coding" , Price= "110"},
                new AddIns { Name = "Dancing", Price= "120"},
  
            };
                SaveAddInsToJson(sampleAddIns); // Save the sample add ins data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
            }
        }

        // Retrieves hobby data from the JSON file.
        public static List<AddIns> RetrieveAddInsData()
        {
            // Gets the file path where hobby data is stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.AddInsFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Hobby objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<AddIns>();
                }
                return JsonConvert.DeserializeObject<List<AddIns>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<AddIns>();
            }
        }

        // Retrieves a specific hobby by its Id.
        public static AddIns GetAddInsById(Guid id)
        {
            List<AddIns> addins = RetrieveAddInsData(); // Retrieves the list of add ins and stores it in add ins object

            // Return the first add ins with the specified Id.
            return addins.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

        // Edits the name of a specific hobby.
        public static List<AddIns> EditAddIns(Guid id, string newName, string price)
        {
            // Retrieve the list of add ins.
            List<AddIns> addins = RetrieveAddInsData();
            // Find the add ins with the specified Id.
            AddIns editIns = addins.FirstOrDefault(x => x.Id == id);
            // If the add ins is not found, throw an exception.
            if (editIns == null)
            {
                throw new Exception("Add Ins not found");
            }
            // Update the name and price of the add ins.
            editIns.Name = newName;
            editIns.Price = price;
            SaveAddInsToJson(addins); // Save the updated list of add ins to the JSON file by calling method SaveAddInsToJSon
            return addins;  // Return the updated list of add ins.
        }
    }
}
