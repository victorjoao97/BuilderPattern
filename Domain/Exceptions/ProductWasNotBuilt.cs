namespace Domain.Exceptions
{
    public class ProductWasNotBuilt : Exception
    {
        public ProductWasNotBuilt(string message) : base($"Product was not built{(!string.IsNullOrEmpty(message) ? "\n" : null)}{message}")
        {
        }
    }
}
