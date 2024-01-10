using Cafe.Data.Model;
using Cafe.Data.Utils;
using MudBlazor;
using Newtonsoft.Json;

namespace Cafe.Data.Services
{
    public class OrderService
    {
        public static void SaveFormDataInJson(Order order)
        {
            string filePath = FormUtils.ApplicationFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<Order> orderList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    orderList = new List<Order>();
                }
                else
                {
                    orderList = JsonConvert.DeserializeObject<List<Order>>(existingJsonData);
                }
                // Add the current form to the list.
                orderList.Add(order);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string formJsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

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
        public static List<Order> RetrieveFormData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.ApplicationFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Order>();
                }
                return JsonConvert.DeserializeObject<List<Order>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
                return new List<Order>();
            }
        }
        public static Order GetOrderById(Guid id)
        {
            List<Order> orders = RetrieveFormData();

            // Return the order with the specified Id.
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public static decimal GetTotalPriceById(Guid id)
        {
            // Get the order by ID.
            Order order = GetOrderById(id);

            // If the order is found, calculate and return the total price.
            if (order != null)
            {
                // Calculate total price based on your data model and logic.
                decimal totalPrice = order.TotalPrice;

                return totalPrice;
            }

            // Return 0 if the order is not found.
            return 0;
        }

        public static void UpdateFormDataInJson(Order order)
        {
            string filePath = FormUtils.ApplicationFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<Order> orderList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    orderList = new List<Order>();
                }
                else
                {
                    orderList = JsonConvert.DeserializeObject<List<Order>>(existingJsonData);
                    // Check if an order with the same Id already exists in the list
                    var existingOrder = orderList.FirstOrDefault(o => o.Id == order.Id);

                    if (existingOrder != null)
                    {
                        // If the order exists, update its properties
                        existingOrder.IsPayed = order.IsPayed;
                        existingOrder.TotalPrice = order.TotalPrice;
                        existingOrder.AddIns = order.AddIns; // Assuming AddIns is a list property
                    }
                    else
                    {
                        // If the order doesn't exist, add the new order to the list
                        orderList.Add(order);
                    }
                }


                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string formJsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

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
    }
}