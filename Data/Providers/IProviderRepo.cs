using RiskTrack.Models;

namespace RiskTrack.Data{
    public interface IProviderRepo{
        IEnumerable<Provider> GetAllProviders();
        IEnumerable<Provider> GetProvidersByUserId(int id);
        Provider GetProviderById(int id);

        void CreateProvider(Provider provider);
        void UpdateProvider(Provider provider);
        void DeleteProvider(Provider provider);
        bool SaveChanges();
    }
}