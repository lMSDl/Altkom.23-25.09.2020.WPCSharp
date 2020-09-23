﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPCSharp.DesignPrinciples
{
    public class Class1
    {


        public int Id { get; }
        public string CustomerName { get; set; }
        public float Val1 { get; set; }
        public float Val2 { get; set; }

        private float allowedDebid;

        public Class1(int id)
        {
            Id = id;
        }

        public float GetAllowedDebit()
        {
            return allowedDebid;
        }

        public void SetAllowedDebit(float value)
        {
            allowedDebid = value;
        }

        public bool GetDebit()
        {
            return Val1 - Val2 < 0;
        }
    }

    public class Class2
    {
        private ICollection<Class1> Customers { get; } = new List<Class1> { new Class1(1), new Class1(2) };

        public bool DeleteCustomer (Class1 param)
        {
            return Customers.Remove(param);
        }

        public bool Func1(int param1, float param2)
        {
            var customer = Customers.SingleOrDefault(x => x.Id == param1);
            if (customer == null)
                return false;
            if (customer.Val1 - customer.Val2 + customer.GetAllowedDebit() < param2)
                return false;

            customer.Val2 += param2;
            return true;
        }

        public void Func2(int param1, float param2)
        {
            var customer = Customers.SingleOrDefault(x => x.Id == param1);
            if (customer == null)
                return;
            customer.Val1 += param2;
        }
        
        public float? GetBalance(int param1)
        {
            var customer = Customers.Where(x => x.Id == param1).SingleOrDefault();
            return customer?.Val1 - customer?.Val2;
        }
    }
}
