﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public void TAdd(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TGetByID(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }

        public Destination TGetDestinationsWithGuide(int id)
        {
          return  _destinationDal.GetDestinationsWithGuide(id);
        }

        public List<Destination> TGetLast4Destinations()
        {
            return _destinationDal.GetLast4Destinations();
        }
    }
}
