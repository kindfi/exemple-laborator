using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    [AsChoice]
    public static partial class Cart
    {
        public interface ICart { }

        public record UnvalidatedCart(IReadOnlyCollection<UnvalidatedShoppingCart> ProductsList) : ICart;

        public record EmptyCart(IReadOnlyCollection<UnvalidatedShoppingCart> ProductsList, string reason) : ICart;

        public record ValidatedCart(IReadOnlyCollection<ValidatedShoppingCart> ProductsList) : ICart;

        public record PaidCart(IReadOnlyCollection<ValidatedShoppingCart> ProductsList, DateTime PaidDate) : ICart;
    }
}
