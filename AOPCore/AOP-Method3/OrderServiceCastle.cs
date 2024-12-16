﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPCore
{
    /// <summary>
    /// 接口实现类：请大家在实现接口的时候，方法必须是virtual
    /// </summary>
    public class OrderServiceCastle : IOrderService
    {
        public virtual List<CourseOrder> GetAllOrders()
        {
            //在这里编写具体的查询业务...

            return new List<CourseOrder>
            {
                new CourseOrder {  CourseId=1000, CourseName=".NET高级进阶VIP课程0", CoursePrice=3500, OrderId=2000, SchoolId=502100, StudentId=293400},
                new CourseOrder {  CourseId=1001, CourseName=".NET高级进阶VIP课程1", CoursePrice=4500, OrderId=2001, SchoolId=502101, StudentId=293400},
                new CourseOrder {  CourseId=1002, CourseName=".NET高级进阶VIP课程2", CoursePrice=5500, OrderId=2002, SchoolId=502102, StudentId=293400}
            };
        }

        public virtual int SubmitOrder(CourseOrder order)
        {
            //在这里编写具体的查询业务...

            Console.WriteLine("--------------------------------《核心业务》课程订单被正确提交...");

            return 1000;
        }
    }
}
