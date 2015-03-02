//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//           http://www.apache.org/licenses/LICENSE-2.0 
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERPWebApi.Controllers
{
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public IEnumerable<Order> Get()
        {
            return Orders;
        }

        // GET: api/Orders/5
        public IEnumerable<Order> Get(string customer)
        {
            var orders = Orders.ToArray();

            var rnd = new Random();

            var customerOrders = new List<Order>();

            int orderCount = rnd.Next(3, 7);

            for (int i = 0; i < orderCount; i++)
            {
                customerOrders.Add(orders[rnd.Next(0, 25)]);
            }

            return customerOrders;
        }

        private IEnumerable<Order> SeedData()
        {
                return new List<Order>()
                {
                    new Order() {OrderNumber = "872891", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "659270", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "981023", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "527220", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "571928", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "129083", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "675356", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "777777", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "982983", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "982673", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "268303", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "362920", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "890383", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "983932", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "768292", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "793831", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "678393", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "561873", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "873732", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "938379", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "469383", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "783793", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "986383", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "787383", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()},
                    new Order() {OrderNumber = "676292", OrderDate = GetRandomDate(), OrderValue = GetRandomOrderValue()}
                };
        }

        private static IEnumerable<Order> _orders = null;

        private IEnumerable<Order> Orders
        {
            get { return _orders ?? (_orders = SeedData()); }
        }


        public class Order
        {
            public string OrderNumber { get; set; }
            public string OrderDate { get; set; }
            public double OrderValue { get; set; }
        }

        private readonly Random _rnd = new Random();

        private string GetRandomDate()
        {
            var to = DateTime.Now;
            var from = DateTime.Now.AddDays(-1000D);
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(_rnd.NextDouble() * range.Ticks));

            return (from + randTimeSpan).ToShortDateString();
        }

        private double GetRandomOrderValue()
        {
            const double min = 1000D;
            const double max = 9999D;

            return Math.Round((_rnd.NextDouble() * (max - min) + min), 2);
        }
    }
}
