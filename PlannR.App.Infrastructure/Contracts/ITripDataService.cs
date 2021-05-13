﻿using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface ITripDataService : IBaseDataService<EditTripViewModel>
    {
        Task<ICollection<TripListViewModel>> GetAllTripsAsync();
        Task<ICollection<TripListOnDateViewModel>> GetAllTripsOnDateAsync(DateTime date);
        Task<ICollection<TripListBetweenDatesViewModel>> GetAllTripsBetweenDatesAsync(DateTime start, DateTime end);
        Task<TripDetailViewModel> GetTripByIdAsync(Guid id);
    }
}
