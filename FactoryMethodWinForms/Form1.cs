using System;
using System.Windows.Forms;

namespace FactoryMethodWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            ProductFactory factoryA = new ConcreteProductAFactory();
            IProduct productA = factoryA.CreateProduct();
            labelResult.Text = productA.GetName();
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            ProductFactory factoryB = new ConcreteProductBFactory();
            IProduct productB = factoryB.CreateProduct();
            labelResult.Text = productB.GetName();
        }
    }
}
