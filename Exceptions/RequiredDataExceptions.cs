namespace OrderService.Exceptions;

public class RequiredDataExceptions : Exception
{
    public RequiredDataExceptions(string message) : base(message)
    {
    }
}

public class OrderNotFoundException : RequiredDataExceptions
{
    public OrderNotFoundException(string message) : base(message)
    {
    }
}

public class OrderExistException : RequiredDataExceptions
{
    public OrderExistException(string message) : base(message)
    {
    }
}

public class ProductNotFoundException : RequiredDataExceptions
{
    public ProductNotFoundException(string message) : base(message) { }
}

public class ZeroQuantityException : RequiredDataExceptions
{
    public ZeroQuantityException(string message) : base(message) { }
}

public class NegativeOrZeroQuantityException : RequiredDataExceptions
{
    public NegativeOrZeroQuantityException(string message) : base(message) { }
}

public class OrderDeletionException : RequiredDataExceptions
{
    public OrderDeletionException(string message) : base(message) { }
}
public class InvalidStatusException : RequiredDataExceptions
{
    public InvalidStatusException(string message) : base(message) { }
}