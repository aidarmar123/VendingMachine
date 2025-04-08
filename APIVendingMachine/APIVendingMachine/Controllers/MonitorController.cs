using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIVendingMachine.Models;

namespace APIVendingMachine.Controllers
{
    public class MonitorController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        [HttpGet]
        [Route("api/StateConnection/{vendingMachinId}")]
        public IHttpActionResult StateConnection( int vendingMachinId)
        {
            var vendingMachin = db.VendingMachin.FirstOrDefault(x => x.Id == vendingMachinId);
            if (vendingMachin == null)
                return NotFound();

            var random = new Random();
            return Ok(new { state = random.Next(6) });
        }

        [HttpGet]
        [Route("api/LodaingProduct/{vendingMachinId}")]
        public IHttpActionResult LodaingProduct(int vendingMachinId)
        {
            var vendingMachin = db.VendingMachin.FirstOrDefault(x => x.Id == vendingMachinId);
            if (vendingMachin == null)
                return NotFound();

            var random = new Random();
            return Ok(new { countProducts = random.Next(0, vendingMachin.TotalProduct + 1) });
        }

        int[] banknotsValue = new[] {50,100, 500, 1000, 2000, 5000 };
        int[] coinsValue = new[] {1, 2, 5, 10 };
        [HttpGet]
        [Route("api/Money/{vendingMachinId}")]

        public IHttpActionResult Money(int vendingMachinId)
        {
            var vendingMachin = db.VendingMachin.FirstOrDefault(x => x.Id == vendingMachinId);
            if (vendingMachin == null)
                return NotFound();

            var random = new Random();
            return Ok(new
            {
                banknots = banknotsValue.Select(banknot => new
                {
                    value = banknot,
                    count = random.Next(20)
                }),
                coins = coinsValue.Select(coin => new
                {
                    value = coin,
                    count = random.Next(20)
                }),


            });
        }


    }
}
