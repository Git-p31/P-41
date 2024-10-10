using System;
using System.Windows.Forms;
using System.Collections.Generic;



namespace PizzaBuilderApp
{
    // Класс продукта
    class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public void ShowPizza()
        {
            MessageBox.Show($"Пицца с тестом: {Dough}, соусом: {Sauce}, начинками: {string.Join(", ", Toppings)}", "Собранная пицца");
        }
    }

    // Интерфейс строителя
    interface IPizzaBuilder
    {
        void SetDough();
        void SetSauce();
        void SetToppings();
        Pizza GetPizza();
    }

    // Конкретный строитель для Маргариты
    class MargheritaPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void SetDough() => _pizza.Dough = "Тонкое тесто";
        public void SetSauce() => _pizza.Sauce = "Томатный соус";
        public void SetToppings() => _pizza.Toppings.AddRange(new List<string> { "Сыр Моцарелла", "Базилик" });

        public Pizza GetPizza() => _pizza;
    }

    // Конкретный строитель для Пепперони
    class PepperoniPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void SetDough() => _pizza.Dough = "Толстое тесто";
        public void SetSauce() => _pizza.Sauce = "Соус BBQ";
        public void SetToppings() => _pizza.Toppings.AddRange(new List<string> { "Сыр Чеддер", "Пепперони" });

        public Pizza GetPizza() => _pizza;
    }

    // Директор, управляющий строителем
    class PizzaDirector
    {
        private IPizzaBuilder _pizzaBuilder;

        public void SetPizzaBuilder(IPizzaBuilder pizzaBuilder)
        {
            _pizzaBuilder = pizzaBuilder;
        }

        public void ConstructPizza()
        {
            _pizzaBuilder.SetDough();
            _pizzaBuilder.SetSauce();
            _pizzaBuilder.SetToppings();
        }

        public Pizza GetPizza() => _pizzaBuilder.GetPizza();
    }

    // Класс формы приложения
    public class PizzaForm : Form
    {
        private ComboBox pizzaTypeComboBox;
        private Button buildButton;
        private TextBox outputTextBox;

        public PizzaForm()
        {
            // Настройка формы
            this.Text = "Пицца Строитель";
            this.Width = 400;
            this.Height = 350;

            // Элементы управления
            pizzaTypeComboBox = new ComboBox { Left = 50, Top = 20, Width = 280 };
            pizzaTypeComboBox.Items.AddRange(new string[] { "Маргарита", "Пепперони" });
            pizzaTypeComboBox.SelectedIndex = 0;

            buildButton = new Button { Left = 50, Top = 60, Width = 280, Text = "Собрать пиццу" };
            buildButton.Click += BuildButton_Click;

            outputTextBox = new TextBox { Left = 50, Top = 100, Width = 280, Height = 180, Multiline = true, ReadOnly = true };

            // Добавление элементов на форму
            Controls.Add(pizzaTypeComboBox);
            Controls.Add(buildButton);
            Controls.Add(outputTextBox);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            string pizzaType = pizzaTypeComboBox.SelectedItem?.ToString();
            if (pizzaType == null)
            {
                outputTextBox.Text = "Пожалуйста, выберите тип пиццы.";
                return;
            }

            PizzaDirector director = new PizzaDirector();
            IPizzaBuilder pizzaBuilder = null;

            switch (pizzaType)
            {
                case "Маргарита":
                    pizzaBuilder = new MargheritaPizzaBuilder();
                    break;
                case "Пепперони":
                    pizzaBuilder = new PepperoniPizzaBuilder();
                    break;
                default:
                    outputTextBox.Text = "Неизвестный тип пиццы.";
                    return;
            }

            director.SetPizzaBuilder(pizzaBuilder);
            outputTextBox.Text = "Начинаем сборку пиццы...\r\n";

            // Показываем пошаговое выполнение паттерна
            outputTextBox.AppendText("1. Замешиваем тесто...\r\n");
            pizzaBuilder.SetDough();

            outputTextBox.AppendText("2. Добавляем соус...\r\n");
            pizzaBuilder.SetSauce();

            outputTextBox.AppendText("3. Добавляем начинки...\r\n");
            pizzaBuilder.SetToppings();

            outputTextBox.AppendText("4. Завершаем сборку пиццы.\r\n");

            Pizza pizza = director.GetPizza();
            outputTextBox.AppendText($"Пицца собрана: {pizza.Dough} тесто, {pizza.Sauce} соус, начинки: {string.Join(", ", pizza.Toppings)}.");
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new PizzaForm());
        }
    }
}
