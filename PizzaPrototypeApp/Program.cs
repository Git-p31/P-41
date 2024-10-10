using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PizzaPrototypeApp
{
    // Абстрактный класс прототипа для пиццы
    public abstract class PizzaPrototype
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        // Абстрактный метод клонирования
        public abstract PizzaPrototype Clone();

        public override string ToString()
        {
            return $"Pizza with {Dough} dough, {Sauce} sauce, toppings: {string.Join(", ", Toppings)}";
        }
    }

    // Конкретная пицца Маргарита с возможностью клонирования
    public class MargheritaPizza : PizzaPrototype
    {
        public MargheritaPizza()
        {
            Dough = "Thin crust";
            Sauce = "Tomato";
            Toppings.Add("Mozzarella");
            Toppings.Add("Basil");
        }

        // Реализация метода клонирования
        public override PizzaPrototype Clone()
        {
            // Глубокое копирование
            MargheritaPizza clone = (MargheritaPizza)this.MemberwiseClone();
            clone.Toppings = new List<string>(this.Toppings); // Клонирование начинки
            return clone;
        }
    }

    // Конкретная пицца Пепперони с возможностью клонирования
    public class PepperoniPizza : PizzaPrototype
    {
        public PepperoniPizza()
        {
            Dough = "Thick crust";
            Sauce = "BBQ";
            Toppings.Add("Mozzarella");
            Toppings.Add("Pepperoni");
        }

        public override PizzaPrototype Clone()
        {
            PepperoniPizza clone = (PepperoniPizza)this.MemberwiseClone();
            clone.Toppings = new List<string>(this.Toppings);
            return clone;
        }
    }

    public class PizzaForm : Form
    {
        private ComboBox pizzaTypeComboBox;
        private Button buildButton;
        private Button cloneButton;
        private TextBox outputTextBox;
        private PizzaPrototype currentPizza;

        public PizzaForm()
        {
            // Настройка формы
            this.Text = "Pizza Prototype";
            this.Width = 400;
            this.Height = 400;

            // Элементы управления
            pizzaTypeComboBox = new ComboBox { Left = 50, Top = 20, Width = 280 };
            pizzaTypeComboBox.Items.AddRange(new string[] { "Маргарита", "Пепперони" });
            pizzaTypeComboBox.SelectedIndex = 0;

            buildButton = new Button { Left = 50, Top = 60, Width = 280, Text = "Создать пиццу" };
            buildButton.Click += BuildButton_Click;

            cloneButton = new Button { Left = 50, Top = 100, Width = 280, Text = "Клонировать пиццу" };
            cloneButton.Click += CloneButton_Click;

            outputTextBox = new TextBox { Left = 50, Top = 140, Width = 280, Height = 200, Multiline = true, ReadOnly = true };

            // Добавление элементов на форму
            Controls.Add(pizzaTypeComboBox);
            Controls.Add(buildButton);
            Controls.Add(cloneButton);
            Controls.Add(outputTextBox);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            string pizzaType = pizzaTypeComboBox.SelectedItem.ToString();
            if (pizzaType == "Маргарита")
            {
                currentPizza = new MargheritaPizza();
            }
            else if (pizzaType == "Пепперони")
            {
                currentPizza = new PepperoniPizza();
            }

            outputTextBox.Text = $"Создана пицца: {currentPizza}\r\n";
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            if (currentPizza != null)
            {
                PizzaPrototype clonedPizza = currentPizza.Clone();
                outputTextBox.AppendText($"Клонированная пицца: {clonedPizza}\r\n");
            }
            else
            {
                outputTextBox.Text = "Сперва создайте пиццу.";
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new PizzaForm());
        }
    }
}
