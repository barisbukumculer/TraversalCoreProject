﻿using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.Price = command.Price;
            values.DayNight = command.DayNight;
            _context.SaveChanges();
        }
    }
}
