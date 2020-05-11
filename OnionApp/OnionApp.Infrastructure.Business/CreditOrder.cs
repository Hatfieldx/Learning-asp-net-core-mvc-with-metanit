using OnionApp.Domain.Core;
using OnionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionApp.Infrastructure.Business
{
    public class CreditOrder : IOrder
    {
        public void MakeOrder(Book book)
        {
            // код покупки книги с помощью кредитной карты
        }
    }
}
