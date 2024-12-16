using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;

using Unity.Interception.PolicyInjection.Policies;

namespace xiketang.com.UnityContainer.Teach
{
    #region 扩展的具体行为类

    //扩展通用的验证类
    public class DataValidateHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            CourseOrder order = input.Inputs[0] as CourseOrder;
            //实现校验过程
            if (order.StudentId.ToString().Length < 5)
            {
                return input.CreateExceptionMethodReturn(new Exception("StudentId学号不能小于5位！"));
            }
            if (order.CoursePrice < 0)
            {
                return input.CreateExceptionMethodReturn(new Exception("课程价格不能是负数！"));
            }
            Console.WriteLine("订单数据校验成功！");

            //跳转到下一个注入的行为，并返回结果
            return getNext()(input, getNext);
        }
    }

    //缓存数据
    public class CacheHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            CourseOrder order = input.Inputs[0] as CourseOrder;

            //在这里编写缓存写入的具体过程...


            Console.WriteLine("订单数据缓存成功！");

            //跳转到下一个注入的行为，并返回结果
            return getNext()(input, getNext);
        }
    }

    //日志添加
    public class WriteLogHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            CourseOrder order = input.Inputs[0] as CourseOrder;

            //在这里编写缓存写入的具体过程...


            Console.WriteLine("日志写入成功！");

            //跳转到下一个注入的行为，并返回结果
            return getNext()(input, getNext);
        }
    }

    #endregion

    #region 将行为封装为特性

    //public abstract class HandlerAttribute : Attribute
    //{
    //    protected HandlerAttribute();

    //    public int Order { get; set; }

    //    public abstract ICallHandler CreateHandler(IUnityContainer container);
    //}

    //返回类型是ICallHandler，而前面我们写的具体行为类，就是实现这个接口的，所以自己返回实现类的对象就行
    public class DataValidateHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new DataValidateHandler { Order = this.Order };
        }
    }
    public class CacheHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CacheHandler { Order = this.Order };
        }
    }
    public class WriteLogHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new WriteLogHandler { Order = this.Order };
        }
    }

    #endregion

}
