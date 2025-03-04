﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.UnityContainer.Teach
{

    /// <summary>
    /// 学员订单接口
    /// </summary>
    [CacheHandler(Order = 2)]
    [DataValidateHandler(Order = 1)]
    [WriteLogHandler(Order = 4)]
    public interface IOrderService
    {
        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int SubmitOrder(CourseOrder order);
        /// <summary>
        /// 查询所有的订单列表
        /// </summary>
        /// <returns></returns>
        List<CourseOrder> GetAllOrders();

        //其他方法...
    }
}
