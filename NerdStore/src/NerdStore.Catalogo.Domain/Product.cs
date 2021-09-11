using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int Quantity { get; private set; }
        public string ImageUrl { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Dimensions Dimensions { get; private set; }

        public Product(string name, string description, bool active, decimal price, Guid categoryId, string imageUrl, Dimensions dimensions, DateTime createdAt)
        {
            Name = name.Trim();
            Description = description.Trim();
            Active = active;
            Price = price;
            CreatedAt = createdAt;
            ImageUrl = imageUrl.Trim();
            CategoryId = categoryId;
            Dimensions = dimensions;

            Validate();
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;
        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeDescription(string desc)
        {
            AssertionConcern.AssertArgumentEmpty(desc, "Product's Description shall not be empty");
            Description = desc;
        }

        public void DebitStock(int quatity)
        {
            if (quatity < 0)
                quatity *= -1;

            if (!CheckStock(quatity))
                throw new DomainException("Insuficient Stock");

            Quantity -= quatity;
        }

        public void CreditStock(int quantity)
        {
            Quantity += quantity;
        }

        public bool CheckStock(int quantity)
        {
            return Quantity >= quantity;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentEmpty(Name, "Product's Name shall not be empty");
            AssertionConcern.AssertArgumentEmpty(Description, "Product's Description shall not be empty");
            AssertionConcern.AssertArgumentNotEquals(CategoryId, Guid.Empty, "Product's Id shall not be empty");
            AssertionConcern.AssertArgumentLessEqual(Price, 0, "Product's Price shall not be empty");
            AssertionConcern.AssertArgumentEmpty(ImageUrl, "Product's Image shall not be empty");
        }
    }
}
