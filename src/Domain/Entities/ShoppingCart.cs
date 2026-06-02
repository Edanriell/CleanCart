namespace Domain.Entities;

public class ShoppingCart(Guid customerId)
{
    // Keep the mutable list private
    private readonly List<ShoppingCartItem> _items = new();
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; } = customerId;

    // Preserve encapsulation via a read-only view
    public IReadOnlyCollection<ShoppingCartItem> Items => _items.AsReadOnly();

    public void AddItem(Guid productId, string productName, decimal productPrice, int quantity)
    {
        var existingItem = _items.SingleOrDefault(i => i.ProductId == productId);

        if (existingItem is not null)
            existingItem.Quantity += quantity;
        else
            _items.Add(new ShoppingCartItem(productId, productName, productPrice, quantity));
    }
}