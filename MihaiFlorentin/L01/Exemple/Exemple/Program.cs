using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Cart;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfProducts = ReadlistOfProducts().ToArray();
            UnvalidatedCart unvalidatedProducts = new(listOfProducts);
            ICart result = ValidateCart(unvalidatedProducts);
            result.Match(
                whenUnvalidatedCart: unvalidatedResult => unvalidatedProducts,
                whenPaidCart: PaidResult => PaidResult,
                whenEmptyCart: emptyResult => emptyResult,
                whenValidatedCart: validatedResult => PaidCart(validatedResult)
            );

            Console.WriteLine("Hello World!");
        }

        private static List<UnvalidatedShoppingCart> ReadlistOfProducts()
        {
            List <UnvalidatedShoppingCart> listOfProducts = new();
            do
            {
                //read registration number and quantity and create a list of greads
                var registrationNumber = ReadValue("Registration Number: ");
                if (string.IsNullOrEmpty(registrationNumber))
                {
                    break;
                }

                var quantity = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                listOfProducts.Add(new (registrationNumber, quantity));
            } while (true);
            return listOfProducts;
        }

        private static ICart ValidateCart(UnvalidatedCart unvalidatedProducts) =>
            random.Next(100) > 50 ?
            new EmptyCart(new List<UnvalidatedShoppingCart>(), "Random errror")
            : new ValidatedCart(new List<ValidatedShoppingCart>());

        private static ICart PaidCart(ValidatedCart validCart) =>
            new PaidCart(new List<ValidatedShoppingCart>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
