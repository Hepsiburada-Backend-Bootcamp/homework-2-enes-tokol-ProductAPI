using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category:IBaseModel
    {
        #region Scalar Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion
        
        #region Navigation Properties
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}