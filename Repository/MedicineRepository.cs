namespace GraphQLPOC.Repository;

// Repositories/MedicineRepository.cs
using Microsoft.EntityFrameworkCore;
using GraphQLPOC.Data;
using GraphQLPOC.Model;

public class MedicineRepository : IMedicineRepository
{
    private readonly MedicineDbContext _context;

    public MedicineRepository(MedicineDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicine>> GetAllAsync()
    {
        return await _context.Medicines.ToListAsync();
    }

    public async Task<Medicine?> GetByIdAsync(int id)
    {
        return await _context.Medicines.FindAsync(id);
    }

    public async Task<Medicine> CreateAsync(MedicineInput input)
    {
        var medicine = new Medicine
        {
            Name = input.Name,
            Company = input.Company,
            Price = input.Price,
            Quantity = input.Quantity,
            ExpiryDate = input.ExpiryDate,
            CreatedDate = DateTime.UtcNow
        };

        _context.Medicines.Add(medicine);
        await _context.SaveChangesAsync();
        return medicine;
    }

    public async Task<Medicine?> UpdateAsync(int id, MedicineUpdateInput input)
    {
        var medicine = await _context.Medicines.FindAsync(id);
        if (medicine == null)
            return null;

        // Update only non-null values
        if (!string.IsNullOrEmpty(input.Name))
            medicine.Name = input.Name;

        if (!string.IsNullOrEmpty(input.Company))
            medicine.Company = input.Company;

        if (input.Price.HasValue)
            medicine.Price = input.Price.Value;

        if (input.Quantity.HasValue)
            medicine.Quantity = input.Quantity.Value;

        if (input.ExpiryDate.HasValue)
            medicine.ExpiryDate = input.ExpiryDate.Value;

        await _context.SaveChangesAsync();
        return medicine;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var medicine = await _context.Medicines.FindAsync(id);
        if (medicine == null)
            return false;

        _context.Medicines.Remove(medicine);
        await _context.SaveChangesAsync();
        return true;
    }
}

