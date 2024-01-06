

using Cafe.Data.Model;
using Cafe.Data.Utils;
using MudBlazor;
using Newtonsoft.Json;

namespace Cafe.Data.Services
{
    public class PaymentService
    {
        public static void SaveFormDataInJson(Payments payment)
        {
            string filePath = FormUtils.PaymentFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<Payments> paymentList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    paymentList = new List<Payments>();
                }
                else
                {
                    paymentList = JsonConvert.DeserializeObject<List<Payments>>(existingJsonData);
                }
                // Add the current form to the list.
                paymentList.Add(payment);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string formJsonData = JsonConvert.SerializeObject(paymentList, Formatting.Indented);

                // Write the JSON data back to the file.
                File.WriteAllText(filePath, formJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
            }
        }

        // Retrieves form data from the JSON file.
        public static List<Payments> RetrieveFormData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.PaymentFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Payments>();
                }
                return JsonConvert.DeserializeObject<List<Payments>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
                return new List<Payments>();
            }
        }
    }
}