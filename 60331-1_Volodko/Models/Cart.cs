using _60331_1_Volodko.DAL;
using System.Collections.Generic;
using System.Linq;

namespace _60331_1_Volodko.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> cartItems;

        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="car">объект для добавления</param> 
        public void AddItem(Car car)
        {
            if (cartItems.ContainsKey(car.CarId))
                cartItems[car.CarId].Quantity += 1;
            else cartItems.Add(car.CarId, new CartItem { Car = car, Quantity = 1 });
        } 
        
        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="car">Объект для удаления</param> 
        public void RemoveItem(Car car)
        {
            if (cartItems[car.CarId].Quantity == 1)
                cartItems.Remove(car.CarId);
            else cartItems[car.CarId].Quantity -= 1;
        } 
        /// <summary>
        /// Очистить корзину 
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }
        
        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            return cartItems.Values.Sum(i => i.Car.Cost * i.Quantity);
        }
        
        /// <summary>
        /// Получение содержимого корзины
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }               
    }
}