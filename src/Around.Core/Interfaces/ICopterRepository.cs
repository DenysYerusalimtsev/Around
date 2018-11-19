﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface ICopterRepository
    {
        List<Copter> GetAll();

        Copter GetCopter(int id);

        Task<List<Copter>> GetAllAsync();

        Task<Copter> Get(int id);

        void Create(Copter copter);

        void Update(int id, Copter copter);

        List<Copter> Search(string search);

        void Delete(int id);
    }
}
