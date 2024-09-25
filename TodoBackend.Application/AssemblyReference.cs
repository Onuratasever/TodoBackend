using System.Reflection;

namespace TodoBackend.Application;

public static class AssemblyReference
{
    public static readonly Assembly Application = typeof(AssemblyReference).Assembly;
}