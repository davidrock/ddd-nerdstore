using System;
using System.Collections.Generic;
using System.Text;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }
    }
}
