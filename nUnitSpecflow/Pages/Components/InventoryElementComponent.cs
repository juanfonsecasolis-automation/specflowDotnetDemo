using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal class InventoryElementComponent : BaseComponent
    {
        public string Name => _nameLabel.Text;
        public string Price => _priceLabel.Text;
        LabelComponent _nameLabel;
        LabelComponent _priceLabel;

        public InventoryElementComponent(By locator, MyDriverManager myDriverManager) 
            : base(locator, myDriverManager)
        {
            _nameLabel = new LabelComponent(By.ClassName("inventory_item_name"), _locator, myDriverManager);
            _priceLabel = new LabelComponent(By.ClassName("inventory_item_price"), _locator, myDriverManager);
        }
    }
}
