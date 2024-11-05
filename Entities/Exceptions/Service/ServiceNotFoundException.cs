namespace Entities.Exceptions.Service;

public class ServiceNotFoundException : Exception
{
    public ServiceNotFoundException(Guid serviceId)
        :base ($"The service with id: {serviceId} doesn't exist in the database.")
    {
    }}
