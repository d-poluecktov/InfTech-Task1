using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using ComplexCalc.Models;

namespace ComplexCalc
{
    public partial class MainWindow : Window
    {
        private TextBox realPartBox1;
        private TextBox imaginaryPartBox1;
        private TextBox realPartBox2;
        private TextBox imaginaryPartBox2;
        private TextBlock resultBlock;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            realPartBox1 = this.FindControl<TextBox>("RealPart1");
            imaginaryPartBox1 = this.FindControl<TextBox>("ImaginaryPart1");
            realPartBox2 = this.FindControl<TextBox>("RealPart2");
            imaginaryPartBox2 = this.FindControl<TextBox>("ImaginaryPart2");
            resultBlock = this.FindControl<TextBlock>("Result");
        }

        private ComplexNumber GetComplexNumber(TextBox realPartBox, TextBox imaginaryPartBox)
        {
            if (double.TryParse(realPartBox.Text, out double real) && double.TryParse(imaginaryPartBox.Text, out double imaginary))
            {
                return new ComplexNumber(real, imaginary);
            }
            else
            {
                throw new ArgumentException("Invalid complex number format.");
            }
        }

        private void Sum_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                ComplexNumber c1 = GetComplexNumber(realPartBox1, imaginaryPartBox1);
                ComplexNumber c2 = GetComplexNumber(realPartBox2, imaginaryPartBox2);
                resultBlock.Text = $"Sum: {c1 + c2}";
            }
            catch (ArgumentException ex)
            {
                resultBlock.Text = ex.Message;
            }
        }

        private void Difference_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                ComplexNumber c1 = GetComplexNumber(realPartBox1, imaginaryPartBox1);
                ComplexNumber c2 = GetComplexNumber(realPartBox2, imaginaryPartBox2);
                resultBlock.Text = $"Difference: {c1 - c2}";
            }
            catch (ArgumentException ex)
            {
                resultBlock.Text = ex.Message;
            }
        }

        private void Product_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                ComplexNumber c1 = GetComplexNumber(realPartBox1, imaginaryPartBox1);
                ComplexNumber c2 = GetComplexNumber(realPartBox2, imaginaryPartBox2);
                resultBlock.Text = $"Product: {c1 * c2}";
            }
            catch (ArgumentException ex)
            {
                resultBlock.Text = ex.Message;
            }
        }

        private void Quotient_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                ComplexNumber c1 = GetComplexNumber(realPartBox1, imaginaryPartBox1);
                ComplexNumber c2 = GetComplexNumber(realPartBox2, imaginaryPartBox2);
                resultBlock.Text = $"Quotient: {c1 / c2}";
            }
            catch (ArgumentException ex)
            {
                resultBlock.Text = ex.Message;
            }
        }

        private void Comparison_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                ComplexNumber c1 = GetComplexNumber(realPartBox1, imaginaryPartBox1);
                ComplexNumber c2 = GetComplexNumber(realPartBox2, imaginaryPartBox2);
                string comparisonResult = (c1 == c2) ? "Equal" : "Not Equal";
                resultBlock.Text = $"Comparison: {comparisonResult}";
            }
            catch (ArgumentException ex)
            {
                resultBlock.Text = ex.Message;
            }
        }
    }
}
