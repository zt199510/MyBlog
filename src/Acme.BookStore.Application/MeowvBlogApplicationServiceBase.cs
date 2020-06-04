using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Acme.BookStore
{
   public class MeowvBlogApplicationServiceBase: ApplicationService
    {
      
    }

    public class HelloWorldService : MeowvBlogApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
    public interface IHelloWorldService
    {
        string HelloWorld();
    }
}
