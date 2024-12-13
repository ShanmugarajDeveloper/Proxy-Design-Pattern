using System;
using System.Numerics;

// Subject interface
public interface ISubject
{
    void Request();
}

// RealSubject class
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling request.");
    }
}

// Proxy class (violated)
public class Proxy : ISubject
{
    private ISubject _realSubject;
    private bool _IsAccessHaving=false;
    public Proxy(bool isAccessHaving)
    {
        _IsAccessHaving = isAccessHaving;
    }

    // Violated: The proxy should be controlling access to the real subject, but here, 
    // the proxy simply delegates the request directly to the real subject without any additional logic.
    public void Request()
    {
        if (_IsAccessHaving)
        {
            // Proxy should control access or add some functionality, but it's bypassed here.
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            Console.WriteLine("Access Granted");
            _realSubject.Request();
          
        }
        else
        {
            Console.WriteLine("Access Denied");
        }
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        ISubject proxy = new Proxy(true);
        proxy.Request();  
        proxy = new Proxy(false);
        proxy.Request(); 
    }
}
