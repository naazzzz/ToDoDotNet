namespace TODOList.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class RegisterService : Attribute
{
    public ServiceLifetime Lifetime { get; }

    public RegisterService(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }
}