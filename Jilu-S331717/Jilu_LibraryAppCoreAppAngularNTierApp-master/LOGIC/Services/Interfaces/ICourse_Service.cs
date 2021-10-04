using LOGIC.Services.Models;
using LOGIC.Services.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICourse_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Course_ResultSet>>> GetAllCourses();
        Task<Generic_ResultSet<Course_ResultSet>> GetCourseById(Int64 id);

        //Task<Generic_ResultSet<Course_ResultSet>> GetCourseByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Course_ResultSet>> AddCourse(string name);
        Task<Generic_ResultSet<Course_ResultSet>> UpdateCourse(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteCourse(Int64 id);

    }
}

