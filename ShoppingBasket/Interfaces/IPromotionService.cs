using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Interfaces
{
    public interface IPromotionService
    {
        int CalculateTotal(Basket basket);
    }

}
