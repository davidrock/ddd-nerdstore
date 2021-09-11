using System;
using NerdStore.Core.DomainObjects;
using Xunit;

namespace NerdStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Validate_ValidationsReturnExceptions()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Product(string.Empty, "Descrição", false, 100, Guid.NewGuid(), "image", new Dimensions(1, 1, 1), new DateTime())
            );

            Assert.Equal("Product's Name shall not be empty", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Nopme", string.Empty, false, 100, Guid.NewGuid(), "image", new Dimensions(1, 1, 1), new DateTime())
            );

            Assert.Equal("Product's Description shall not be empty", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Nopme", "Descriçao", false, 0, Guid.NewGuid(), "image", new Dimensions(1, 1, 1), new DateTime())
            );

            Assert.Equal("Product's Price shall not be empty", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Nopme", "Descriçao", false, 100, Guid.NewGuid(), string.Empty, new Dimensions(1, 1, 1), new DateTime())
            );

            Assert.Equal("Product's Image shall not be empty", ex.Message); 
            
            ex = Assert.Throws<DomainException>(() =>
                new Product("Nopme", "Descriçao", false, 100, Guid.Empty, string.Empty, new Dimensions(1, 1, 1), new DateTime())
            );

            Assert.Equal("Product's Id shall not be empty", ex.Message);


        }

    }
}
