namespace Domain.Entities
{
    public class Product:IBaseModel
    {
        #region Scalar Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        #endregion
        
        #region Navigation Properties
        public virtual Category Category { get; set; }
        #endregion
    }
}