# Infrastructure Layer

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on.
These classes should be based on interfaces defined within the application layer.
Follow instruction https://nishanc.medium.com/clean-architecture-net-core-part-2-implementation-7376896390c5
To separate the Database Context
add-migration "Initial-Identity" -Context IdentityContext
update-database -Context IdentityContext

add-migration "Initial-DataContact" -Context ApplicationDbContext
update-database -Context ApplicationDbContext 