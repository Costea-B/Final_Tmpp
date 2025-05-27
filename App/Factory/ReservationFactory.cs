using App.Strategy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Factory
{
     public class ReservationFactory: IReservationFactory
     {
          private readonly IServiceProvider _provider;

          public ReservationFactory(IServiceProvider provider)
          {
               _provider = provider;
          }

          public IReservation CreateReservation(string type)
          {
               return type.ToLower() switch
               {
                    "standard" => new StandartReservation(_provider.GetRequiredService<SimpleAllocationStrategy>()),
                    "vip" => new VipReservation(_provider.GetRequiredService<VipAllocationStrategy>()),
                    "event" => new EventReservation(_provider.GetRequiredService<EventAllocationStrategy>()),
                    _ => throw new ArgumentException("Tip necunoscut de rezervare")
               };
          }
     }

}
