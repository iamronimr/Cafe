using Cafe.Data.Model;
using Cafe.Data.Utils;
using Newtonsoft.Json;

namespace Cafe.Data.Services
{
    public class CustomerService
    {
        public static void SaveFormDataInJson(Customer customer)
        {
            string filePath = FormUtils.CustomerFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<Customer> customerList; // object of list of payment
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    customerList = new List<Customer>();
                }
                else
                {
                    customerList = JsonConvert.DeserializeObject<List<Customer>>(existingJsonData);
                }
                // Add the current form to the list.
                customerList.Add(customer);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string formJsonData = JsonConvert.SerializeObject(customerList, Formatting.Indented);

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
        public static List<Customer> RetrieveFormData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.CustomerFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Customer>();
                }
                return JsonConvert.DeserializeObject<List<Customer>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
                return new List<Customer>();
            }
        }

        public Customer GetCustomerByContact(string contact)
        {
            List<Customer> customers = RetrieveFormData();
            // Find the customer with the specified contact
            Customer customer = customers.FirstOrDefault(c => c.Contact == contact);

            return customer;
        }
    }
}
