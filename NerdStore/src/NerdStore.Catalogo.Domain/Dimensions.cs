using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain
{
    public class Dimensions
    {
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public Dimensions(decimal height, decimal width, decimal depth)
        {
            AssertionConcern.AssertArgumentLessEqual(height, 0, "Height can not be equal or less than zero");
            AssertionConcern.AssertArgumentLessEqual(width, 0, "Width can not be equal or less than zero");
            AssertionConcern.AssertArgumentLessEqual(depth, 0, "Depth can not be equal or less than zero");

            Height = height;
            Width = width;
            Depth = depth;
        }

        public string Description()
        {
            return $"HxWxD : {Height} x {Width} x {Depth}";
        }

        public override string ToString()
        {
            return Description();
        }
    }
}
