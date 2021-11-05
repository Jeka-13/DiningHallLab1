using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DinningHall.Helpers.Enums;
using DinningHall.Infrastructure.Preparation;
using DinningHall.Infrastructure.Utils;
using DinningHall.Models;
using DinningHall.Server;
using Microsoft.Extensions.Hosting;

namespace DinningHall
{
    public class Dinning : BackgroundService
    {
        public DinningHallServer server;

        public List<Table> tables = new List<Table>();
        public List<Waiter> waiters = new List<Waiter>();
        public List<Food> menu = new List<Food>();
        public List<Order> orders = new List<Order>();

        public Dinning(DinningHallServer server)
        {
            this.server = server;
            this.server.StartAsync(this);
            Preparation.PrepareMenu(menu);
        }

        public void InitTables()
        {
            Preparation.PrepareTables(tables, 5);

            foreach (var table in tables)
                table.GetClients();
        }

        public void InitWaiters()
        {
            Preparation.PrepareWaiters(waiters, 3);

            foreach (var waiter in waiters)
                waiter.StartWaiterWork(this);
        }

        public void ServeOrder(Order order)
        {
            var table = tables.First(t => t.Id == order.TableId);
            float waitTime = (DateTime.Now.Ticks - table.orderedAt.Ticks) / (10000 * Configurator.TIME_UNIT);

            Logger.Log($"Table {table.Id} received order {order.Id}:");

            Assessor.Assess(waitTime, order);
            orders = orders.Where(o => o.Id != order.Id).ToList();
            table.State = TableState.NoClient;
            table.GetClients();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            InitTables();
            InitWaiters();
            return Task.CompletedTask;
        }
    }
}