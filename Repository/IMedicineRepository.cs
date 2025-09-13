using GraphQLPOC.Model;

namespace GraphQLPOC.Repository;
public interface IMedicineRepository
{
    Task<IEnumerable<Medicine>> GetAllAsync();
    Task<Medicine?> GetByIdAsync(int id);
    Task<Medicine> CreateAsync(MedicineInput input);
    Task<Medicine?> UpdateAsync(int id, MedicineUpdateInput input);
    Task<bool> DeleteAsync(int id);
}

