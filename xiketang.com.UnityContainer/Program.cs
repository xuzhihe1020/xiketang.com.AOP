using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//引入命名空间
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace xiketang.com.UnityContainer.Teach
{
    class Program
    {
        static void Main(string[] args)
        {
            //【得到容器】
            IUnityContainer container = new Unity.UnityContainer();

            //【注册对象】
            container.RegisterType<IOrderService, OrderService>();

            //【注入功能】  Interception：拦截器
            container.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<IOrderService>(new InterfaceInterceptor());

            //【创建对象】
            IOrderService orderService = container.Resolve<IOrderService>();

            //【业务调用】
            CourseOrder order = new CourseOrder
            {
                CourseId = 1001,
                CourseName = ".NET高级VIP课程",
                CoursePrice = 3500,
                SchoolId = 502102,
                StudentId = 293400
            };
            orderService.SubmitOrder(order);

            Console.Read();
        }
    }
}
