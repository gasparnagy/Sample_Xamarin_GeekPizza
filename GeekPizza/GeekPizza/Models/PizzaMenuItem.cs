namespace GeekPizza.Models
{
    public class PizzaMenuItem : BaseDataObject
    {
        string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        string _ingredients = string.Empty;
        public string Ingredients
        {
            get => _ingredients;
            set => SetProperty(ref _ingredients, value);
        }
    }
}
