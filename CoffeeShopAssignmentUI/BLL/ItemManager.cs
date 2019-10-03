using CoffeeShopAssignmentUI.Model;
using CoffeeShopAssignmentUI.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopAssignmentUI.BLL
{
    
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public bool Add(Item item)
        {
            return _itemRepository.Add(item);

        }
        public bool IsNameExists(Item item)
        {
            return _itemRepository.IsNameExists(item);
        }
        public DataTable Display()
        {
            return _itemRepository.Display();
        }
        public bool Delete(Item item)
        {
            return _itemRepository.Delete(item);
        }
        
        
        public bool Update(Item item)
        {
            return _itemRepository.Update(item);
        }
        public DataTable Search(Item item)
        {
            return _itemRepository.Search(item);
        }
        public DataTable ItemCombobox()
        {
            return _itemRepository.ItemCombobox();
        }

    }
}
