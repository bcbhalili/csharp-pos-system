using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSConsoleApp
{
    internal class Coffee
    {
        // MEMBERS
        private string flavor;
        private double price;
        private string description;
        private int quantity = 0;

        // CONSTRUCTORS
        public Coffee() 
        {
            this.flavor = "Default Flavor";
            this.price = 0.00;
            this.description = "Default Description";
        }     
        // Modified Constructors
        public Coffee(string flavor, double price)
        {
            this.flavor = flavor;
            this.price = price;
        }
        public Coffee(string flavor, double price, string description) 
        {
            this.flavor = flavor;
            this.price = price;
            this.description = description;
        }

        // METHODS - NEW IMPLEMENTATION
        public string Flavor
        {
            get { return this.flavor; }
            set { this.flavor = value; }
        }
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        // Feature Function/s
        public double CalculateBreakdownAmount()
        {
            return this.price * this.quantity;
        }
    }
}
