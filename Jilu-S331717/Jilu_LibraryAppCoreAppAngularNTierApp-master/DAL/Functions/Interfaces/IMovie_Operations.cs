using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IMovie_Operations
    {
        Task<Movie> Create(Movie objectToAdd);
        Task<Movie> Read(Int64 entityId);
        Task<List<Movie>> ReadAll();
        Task<Movie> Update(Movie objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
