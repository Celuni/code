    public class CartLine
    {
            public int CartLineId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
    }
        public class ShoppingCart : List<CartLine>
        {
            public ShoppingCart()
            {
            }
        }
        public class ShoppingCartRepository
        {
            private ShoppingCart ShoppingCart = new ShoppingCart();
            public IEnumerable GetShoppingCart()
            {
                return ShoppingCart.ToList();
            }
            public virtual void AddItem(int productid, int quantity)
            {
                ShoppingCart.Add(new CartLine
                {
                    ProductId = productid,
                    Quantity = quantity
                });
            }
            public virtual void RemoveItem(int cartlineid)
            {
                ShoppingCart.RemoveAll(l => l.CartLineId == cartlineid);
            }
        }
