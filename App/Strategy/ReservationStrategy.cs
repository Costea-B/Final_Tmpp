using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace App.Strategy
{
     public class SimpleAllocationStrategy : ITableAllocationStrategy
     {
         private readonly IReservationRepository _reservationRepository;
         public SimpleAllocationStrategy(IReservationRepository reservationRepository)
         {
             _reservationRepository = reservationRepository;
         }
         public string AllocateTable(int guests, string userId, int restaurantId)
         {
             var reservation = new Domain.DbModel.Reservation
             {
                 Date = DateTime.Now,
                 NumberOfGuests = guests,
                 UserId = userId,
                 RestaurantId = restaurantId,
                 ReservationTypeId = (int)Domain.Enum.ReservationType.Standart
             };
             _reservationRepository.AddReservationAsync(reservation).Wait();
             return $"Rezervare standard creată pentru {guests} persoane la data {reservation.Date}.";
         }
     }

     public class VipAllocationStrategy : ITableAllocationStrategy
     {
         private readonly IReservationRepository _reservationRepository;
         public VipAllocationStrategy(IReservationRepository reservationRepository)
         {
             _reservationRepository = reservationRepository;
         }
         public string AllocateTable(int guests, string userId, int restaurantId)
         {
             var reservation = new Domain.DbModel.Reservation
             {
                 Date = DateTime.Now,
                 NumberOfGuests = guests,
                 UserId = userId,
                 RestaurantId = restaurantId,
                 ReservationTypeId = (int)Domain.Enum.ReservationType.Vip
             };
             _reservationRepository.AddReservationAsync(reservation).Wait();
             return $"Rezervare VIP creată pentru {guests} persoane la data {reservation.Date}.";
         }
     }

     public class EventAllocationStrategy : ITableAllocationStrategy
     {
         private readonly IReservationRepository _reservationRepository;
         public EventAllocationStrategy(IReservationRepository reservationRepository)
         {
             _reservationRepository = reservationRepository;
         }
         public string AllocateTable(int guests, string userId, int restaurantId)
         {
             var reservation = new Domain.DbModel.Reservation
             {
                 Date = DateTime.Now,
                 NumberOfGuests = guests,
                 UserId = userId,
                 RestaurantId = restaurantId,
                 ReservationTypeId = (int)Domain.Enum.ReservationType.Event
             };
             _reservationRepository.AddReservationAsync(reservation).Wait();
             return $"Rezervare pentru eveniment creată pentru grup de {guests} persoane la data {reservation.Date}.";
         }
     }

}
