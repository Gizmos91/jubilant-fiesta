using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace CoolWindowsApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void EncodeBase64_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Base64Input.Text);
            Base64Output.Text = Convert.ToBase64String(bytes);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void DecodeBase64_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            byte[] bytes = Convert.FromBase64String(Base64Input.Text);
            Base64Output.Text = Encoding.UTF8.GetString(bytes);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Invalid Base64 string: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ComputeHash_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(HashInput.Text);
            byte[] hashBytes = SHA256.HashData(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            HashOutput.Text = sb.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void FormatJson_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            using JsonDocument document = JsonDocument.Parse(JsonInput.Text);
            var options = new JsonSerializerOptions { WriteIndented = true };
            JsonOutput.Text = JsonSerializer.Serialize(document.RootElement, options);
        }
        catch (JsonException ex)
        {
            MessageBox.Show($"Invalid JSON: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}