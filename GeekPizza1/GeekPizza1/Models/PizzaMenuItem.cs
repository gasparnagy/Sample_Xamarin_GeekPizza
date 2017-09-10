namespace GeekPizza1.Models
{
    public class PizzaMenuItem : BaseDataObject
    {
        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string ingredients = string.Empty;
        public string Ingredients
        {
            get { return ingredients; }
            set { SetProperty(ref ingredients, value); }
        }
    }
}
