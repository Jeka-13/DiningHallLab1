using System;
using System.Runtime.Serialization;
using System.Threading;
using DinningHall.Helpers.Enums;
using DinningHall.Infrastructure.Utils;

namespace DinningHall.Models
{
    public class Waiter
    {
        private static ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        private static Mutex mutex = new Mutex();

        public long Id { get; private set; }
        public WaiterState State;

        public Waiter()
        {
            Id = idGenerator.GetId(this, out bool firstTime);
            State = WaiterState.WaitingForOrder;
        }

        public void StartWaiterWork(Dinning dining)
        {
            Thread.Sleep(100);
            new Thread(() =>
            {
                while (true)
                {
                    if (State == WaiterState.WaitingForOrder) {
                        foreach (var table in dining.tables)
                        {
                            mutex.WaitOne();
                            if (table.State == TableState.WatingForWaiter)
                            {
                                Logger.Log($"Waiter {Id} approched the Table {table.Id}");
                                table.State = TableState.Ordering;
                                mutex.ReleaseMutex();
                                Order order = table.GetOrder(this, dining.menu);
                                table.orderedAt = DateTime.Now;
                                dining.orders.Add(order);

                                dining.server.SendOrder(this, order, table);
                            }
                            else
                                mutex.ReleaseMutex();
                            
                        }
                    }
                }
            }).Start();
        }
    }
    
}