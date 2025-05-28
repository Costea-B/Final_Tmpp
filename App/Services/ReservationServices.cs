using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ChainOfResponsibility;
using Domain.DbModel;
using Infrastructure.Abstraction;

namespace App.Services
{
    public class ReservationServices
    {
        private readonly ReservationValidationService _validationService;
        private readonly IReservationRepository _reservationRepository;

        public ReservationServices(ReservationValidationService validationService, IReservationRepository reservationRepository)
        {
            _validationService = validationService;
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> CreateReservationAsync(Reservation reservation)
        {
            var isValid = await _validationService.ValidateAsync(reservation);
            if (!isValid)
                return false;
            await _reservationRepository.AddReservationAsync(reservation);
            return true;
        }
    }
}
