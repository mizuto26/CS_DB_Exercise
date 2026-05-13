namespace CS_DB_Exercise.Domains.Exceptions;

public class DomainException : Exception
{
    public DomainException() { }
    public DomainException(string? message) : base(message) { }
}