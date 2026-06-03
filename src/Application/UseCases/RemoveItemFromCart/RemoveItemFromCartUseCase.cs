using Application.Interfaces.Data;
using Application.Interfaces.UseCases;

namespace Application.UseCases.RemoveItemFromCart;

public class RemoveItemFromCartUseCase(IShoppingCartRepository shoppingCartRepository) : IRemoveItemFromCartUseCase
{
    public async Task RemoveItemFromCartAsync(RemoveItemFromCartInput input)
    {
        var cart = await shoppingCartRepository.GetByUserIdAsync(input.UserId);

        if (cart != null)
        {
            cart.RemoveItem(input.ProductId, input.Quantity);
            await shoppingCartRepository.SaveAsync(cart);
        }
    }
}