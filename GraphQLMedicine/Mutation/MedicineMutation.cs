// GraphQL/MedicineMutation.cs
using GraphQLPOC.Model;
using GraphQLPOC.Repository;

namespace MedicineGraphQL.GraphQL
{
    public class MedicineMutation
    {
        // CREATE - Add new medicine
        public async Task<Medicine> AddMedicine(
            MedicineInput input,
            IMedicineRepository repository)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new GraphQLException("Medicine name is required.");

            if (input.Price <= 0)
                throw new GraphQLException("Medicine price must be greater than 0.");

            if (input.Quantity < 0)
                throw new GraphQLException("Medicine quantity cannot be negative.");

            //if (input.ExpiryDate <= DateTime.Now)
            //    throw new GraphQLException("Medicine expiry date must be in the future.");

            return await repository.CreateAsync(input);
        }

        // UPDATE - Update existing medicine
        public async Task<Medicine?> UpdateMedicine(
            int id,
            MedicineUpdateInput input,
            [Service] IMedicineRepository repository)
        {
            // Basic validation for non-null values
            if (input.Price.HasValue && input.Price <= 0)
                throw new GraphQLException("Medicine price must be greater than 0.");

            if (input.Quantity.HasValue && input.Quantity < 0)
                throw new GraphQLException("Medicine quantity cannot be negative.");

            var result = await repository.UpdateAsync(id, input);
            if (result == null)
                throw new GraphQLException($"Medicine with ID {id} not found.");

            return result;
        }

        // DELETE - Delete medicine
        public async Task<bool> DeleteMedicine(
            int id,
            [Service] IMedicineRepository repository)
        {
            var result = await repository.DeleteAsync(id);
            if (!result)
                throw new GraphQLException($"Medicine with ID {id} not found.");

            return result;
        }
    }
}
