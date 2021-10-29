# Infrastructure Layer

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on.
These classes should be based on interfaces defined within the application layer.

add-migration "Initial-Identity" -Context IdentityContext
update-database -Context IdentityContext

add-migration "Initial-DataContact" -Context ApplicationDbContext
update-database -Context ApplicationDbContext 