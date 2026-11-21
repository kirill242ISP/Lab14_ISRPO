public class Order
{
  public int Id { get; private set; }
  public int Quantity { get; private set; }
  public Product? TargetProduct { get; private set; }
  public bool IsCompleted { get; private set; }

  public Order(int id, int quantity)
  {
    Id = id;
    Quantity = quantity < 1 ? 1 : quantity;
    TargetProduct = null;
    IsCompleted = false;
  }

  public bool TryStart(Product product)
  {
    if (IsCompleted)
    {
      return false;
    }
    if (TargetProduct != null)
    {
      return false;
    }
    if (product.StockQuantity < Quantity)
    {
      return false;
    }

    TargetProduct = product;
    return true;
  }

  public bool TryFinish()
  {
    if (IsCompleted)
    {
      return false;
    }

    Product? product = TargetProduct;
    if (product == null)
    {
      return false;
    }
    if (product.StockQuantity < Quantity)
    {
      return false;
    }

    if (!product.Sell(Quantity))
    {
      return false;
    }

    IsCompleted = true;
    return true;
  }

  public string GetInfo()
  {
    string productText = TargetProduct != null ? TargetProduct.Name : "товар не выбран";
    string statusText = IsCompleted ? "да" : "нет";
    return $"Заказ №{Id} ({productText}, {Quantity} шт.): отгружен — {statusText}";
  }
}
