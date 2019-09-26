﻿using System;
using System.Collections.Generic;
using System.Text;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
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

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, bool active, decimal price, Guid categoryId, string imageUrl, DateTime createdAt)
        {
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            CreatedAt = createdAt;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
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
            Description = desc;
        }

        public void DebitStock(int quatity)
        {
            if (quatity < 0) quatity *= -1;
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

        }
    }
}
