﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Moolah.PayPal;
using System.Configuration;
using Moolah;
using System.Net;

namespace Reunion.Models
{
    public class PaypalWebService
    {
        public PayPalExpressCheckoutToken GeneratePayPalToken(int adults, int kids)
        {
            string userId = ConfigurationManager.AppSettings["userId"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            string signature = ConfigurationManager.AppSettings["signature"].ToString();
            var confirmationUrl = ConfigurationManager.AppSettings["confirmationUrl"].ToString();
            var cancelUrl = ConfigurationManager.AppSettings["cancelUrl"].ToString();
            var configuration = new PayPalConfiguration(Moolah.PaymentEnvironment.Live, userId, password, signature);
            var gateway = new PayPalExpressCheckout(configuration);            

            if (kids != 0 && adults != 0)
            {
               var response = gateway.SetExpressCheckout(new OrderDetails
                {
                    OrderDescription = "Thanks for your order!",
                    Items = new[]{
                        new OrderDetailsItem { Description = "Adult Ticket", Quantity = adults, UnitPrice = 15.00m, ItemUrl = "http://www.dragonsrugby15.com" },
                        new OrderDetailsItem { Description = "Kids Ticket", Quantity = kids, UnitPrice = 7m, ItemUrl = "http://www.dragonsrugby15.com" }
                    },
                    CurrencyCodeType = CurrencyCodeType.USD,
                }, cancelUrl, confirmationUrl);

               if (response.Status == PaymentStatus.Failed)
               {
                   throw new Exception(response.FailureMessage);
               }
               else
               {
                   return response;
               } 
            }
            if (kids == 0 && adults != 0)
            {
                var response = gateway.SetExpressCheckout(new OrderDetails
                {
                    OrderDescription = "Thanks for your order!",
                    Items = new[]{
                        new OrderDetailsItem { Description = "Adult Ticket", Quantity = adults, UnitPrice = 15.00m, ItemUrl = "http://www.dragonsrugby15.com" },
                    },
                    CurrencyCodeType = CurrencyCodeType.USD,
                }, cancelUrl, confirmationUrl);

                if (response.Status == PaymentStatus.Failed)
                {
                    throw new Exception(response.FailureMessage);
                }
                else
                {
                    return response;
                }
            }
            else return null;
        }

          
    }
}