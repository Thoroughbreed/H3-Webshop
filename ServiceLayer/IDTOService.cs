using ServiceLayer.DTO;

namespace ServiceLayer
{
    public interface IDTOService
    {
        public void UpdateFromDTO(ProductDTO product);
        public void UpdateFromDTO(CustomerDTO customer);
    }
}
