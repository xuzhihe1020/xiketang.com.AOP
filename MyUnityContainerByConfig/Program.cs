using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;

namespace MyUnityContainerByConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //【1】创建容器对象，并加载配置文件
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration("MyContainer");

            //【2】获取指定名称的配置节点，并获得节点的详细
            UnityConfigurationSection section =
                (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);

            //【3】根据指定的name字符串返回指定对象
            IOrderService orderService = container.Resolve<IOrderService>("MyOrderService2");

            //【4】核心业务调用
            List<CourseOrder> orderList = orderService.GetAllOrders();
            Console.WriteLine(orderList.Count);

            Console.Read();
        }
    }
}
