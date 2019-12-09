namespace ApiHelperLibrary.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public override string ToString()
        {
            return TypeName;
        }
    }
}
