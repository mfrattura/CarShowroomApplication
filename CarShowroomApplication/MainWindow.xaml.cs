using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShowroomApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Data service = new Data();
        Vehicle selectedVehicle;

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void ShowCarButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshVehicles();
        }
        
        private void RefreshVehicles()
        {
            List<Vehicle> vehicles = service.GetVehicles();
            VehicleList.Items.Clear();
            foreach (Vehicle vehicle in vehicles)
            {
                VehicleList.Items.Add(vehicle);
            }
        }
        private void RefreshTextBoxes()
        {
            textBoxMake.Clear();
            textBoxModel.Clear();
            textBoxPrice.Clear();
            textBoxRegoNumber.Clear();
            textBoxYear.Clear();
        }
        private void UpdateImage(string imagePath)
        {
            Uri uri = new Uri($"Images/{imagePath}", UriKind.Relative);
            VehicleImage.Source = new BitmapImage(uri);
        }
        private void VehicleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedVehicle = (Vehicle)VehicleList.SelectedItem;
            if (selectedVehicle == null) return;
            textBoxRegoNumber.Text = selectedVehicle.RegistrationNumber;
            textBoxMake.Text = selectedVehicle.Make;
            textBoxModel.Text = selectedVehicle.Model;
            textBoxYear.Text = Convert.ToString(selectedVehicle.Year);
            textBoxPrice.Text = Convert.ToString(selectedVehicle.Price);
            UpdateImage((string)selectedVehicle.FilePath);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            selectedVehicle = (Vehicle)VehicleList.SelectedItem;
            if (selectedVehicle == null) return;
            selectedVehicle.RegistrationNumber = textBoxRegoNumber.Text;
            selectedVehicle.Make = textBoxMake.Text;
            selectedVehicle.Model = textBoxModel.Text;
            selectedVehicle.Price = Convert.ToDouble(textBoxPrice.Text);
            MessageBox.Show("Saved!");
            RefreshVehicles();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxMake.Text != "" && textBoxModel.Text != "" && textBoxPrice.Text != "" && textBoxYear.Text != "")
            {
                Vehicle newVehicle = new Vehicle(0, textBoxRegoNumber.Text, textBoxMake.Text, textBoxModel.Text, Convert.ToInt32(textBoxYear.Text), Convert.ToDouble(textBoxPrice.Text), "");
                service.AddVehicle(newVehicle);
                MessageBox.Show("Added!");
            }
            RefreshVehicles();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            selectedVehicle = (Vehicle)VehicleList.SelectedItem;
            if (selectedVehicle == null) return;
            service.RemoveVehicle(selectedVehicle);
            MessageBox.Show("Removed!");
            RefreshVehicles();
            RefreshTextBoxes();
        }
        private void ClearSearchResults()
        {
            VehicleList.Items.Clear();
            textBoxMaxPrice.Clear();
            textBoxMinimumPrice.Clear();
            textBoxSearch.Clear();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchInput = textBoxSearch.Text;
            List<Vehicle> vehicles = service.GetVehicles();
            List<Vehicle> searchResults = new List<Vehicle>();
            if (radioButtonKeyNo.IsChecked == true)
            {
                if (String.IsNullOrEmpty(searchInput))
                {
                    MessageBox.Show("Please enter valid input");
                    return;
                }
                int key = Convert.ToInt32(searchInput);
                if (key > 0 && key <= 20)
                {
                    Vehicle vehicleKey = service.RetrieveKey(key);
                    if (vehicleKey == null)
                    {
                        MessageBox.Show("This bay is Empty!");
                        return;
                    }
                    else
                    {
                        searchResults.Add(vehicleKey);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid key No.");
                    return;
                }
            }
            else if (radioButtonRegoNo.IsChecked == true)
            {
                if (String.IsNullOrEmpty(searchInput))
                {
                    MessageBox.Show("Please enter valid input");
                    return;
                }
                string regoInput = searchInput.ToUpper();
                if (regoInput.Length != 6)
                {
                    MessageBox.Show("Please enter a valid registration No.");
                }
                Vehicle vehicleRego = service.RetrieveRego(regoInput);
                if (vehicleRego != null && searchInput.ToUpper() == vehicleRego.RegistrationNumber)
                {
                    searchResults.Add(vehicleRego);
                }
            }
            else if (radioButtonPriceRange.IsChecked == true)
            {
                if (string.IsNullOrEmpty(textBoxMinimumPrice.Text) && string.IsNullOrEmpty(textBoxMaxPrice.Text))
                {
                    MessageBox.Show("Please enter valid input");
                    return;
                }
                double maxPrice;
                double minPrice;
                if (string.IsNullOrEmpty(textBoxMaxPrice.Text))
                {
                    maxPrice = double.MaxValue;
                }
                else
                {
                    maxPrice = Convert.ToDouble(textBoxMaxPrice.Text);
                }
                if (string.IsNullOrEmpty(textBoxMinimumPrice.Text))
                {
                    minPrice = 0.00;
                }
                else
                {
                    minPrice = Convert.ToDouble(textBoxMinimumPrice.Text);
                }
                List<Vehicle> priceResult = service.RetrievePrice(maxPrice, minPrice);
                foreach (Vehicle item in priceResult)
                {
                    VehicleList.Items.Add(item);
                }   
            }
            foreach (Vehicle v in searchResults)
            {
                VehicleList.Items.Add(v);
            }
            if (searchResults.Count == 0 && VehicleList.Items.Count == 0)
            {
                MessageBox.Show("No Results");
                return;
            }
            
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearSearchResults();
        }
    }
}

 