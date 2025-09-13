**GraphQL vs RESTful API in .NET and Angular Applications**
Understanding the Core Differences
GraphQL is a query language and runtime for APIs that allows clients to request exactly the data they need. REST is an architectural style that uses standard HTTP methods and multiple endpoints to manage resources.
The fundamental difference lies in how data is fetched: REST requires multiple requests to different endpoints, while GraphQL uses a single endpoint where clients specify exactly what data they want.

**Data Fetching Efficiency**
GraphQL eliminates over-fetching and under-fetching issues common in REST APIs. In Angular applications, this means
// Single request gets exactly what the UI needs
query GetMedicineInventory {
  medicines {
    id
    name
    quantity
    mrp
    company {
      name
    }
    purchases(last: 5) {
      date
      quantity
      discount
    }
  }
}

**REST Approach**
// Multiple requests required
GET /api/medicines                    // All medicine data
GET /api/companies/{companyId}        // Company details for each medicine
GET /api/purchases?medicineId={id}    // Purchase history for each medicine


**.NET Implementation Considerations**
For .NET applications, GraphQL can be implemented using:
1. HotChocolate - Popular .NET GraphQL server
2. GraphQL.NET - Another robust option

**HotChocolate - Popular .NET GraphQL server : **Most recommended way to support the core dot net. I've used the Mutation (Create/update/delete) and queries(Get) to perform the CRUD operations.



Reference
┌─────────────────────────────────────────────────────────┐
│                    Hot Chocolate Platform               │
├─────────────────────────────────────────────────────────┤
│  Banana Cake Pop IDE  │  Strawberry Shake Client       │
├─────────────────────────────────────────────────────────┤
│              Hot Chocolate Server Core                  │
├─────────────────────────────────────────────────────────┤
│  Schema Builder │ Execution Engine │ Subscription Engine│
├─────────────────────────────────────────────────────────┤
│     ASP.NET Core Middleware │ Dependency Injection      │
├─────────────────────────────────────────────────────────┤
│  EF Core │ Redis │ MongoDB │ SQL Kata │ Custom Providers│
└─────────────────────────────────────────────────────────┘
