// GraphQL/MedicineQuery.cs
using GraphQLPOC.Model;
using GraphQLPOC.Repository;
using HotChocolate;

namespace MedicineGraphQL.GraphQL
{
    public class MedicineQuery
    {
        // READ - Get all medicines
        public async Task<IEnumerable<Medicine>> GetMedicines(
            [Service] IMedicineRepository repository)
        {
            return await repository.GetAllAsync();
        }

        // READ - Get medicine by ID
        public async Task<Medicine?> GetMedicine(
            int id,
            [Service] IMedicineRepository repository)
        {
            return await repository.GetByIdAsync(id);
        }

        // READ - Get medicines with filtering support
        //[UseFiltering]
        //[UseSorting]
        public async Task<IEnumerable<Medicine>> GetMedicinesAdvanced(
            [Service] IMedicineRepository repository)
        {
            return await repository.GetAllAsync();
        }
    }
}
