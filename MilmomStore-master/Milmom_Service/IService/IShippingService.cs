namespace Milmom_Service.IService;

public interface IShippingService
{
    public Task<string> GetShippingFee(string apiUrl, string token, string shopId);
}
